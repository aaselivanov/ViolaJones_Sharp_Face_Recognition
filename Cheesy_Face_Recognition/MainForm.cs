using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using ZedGraph;


namespace Cheesy_Face_Recognition
{
    public partial class MainForm : Form
    {

        //детектор лиц
        private FaceDetector _detector;
        //классы лиц
        private List<FaceClass> _faces;
        //распознанные лица
        private List<RecognizedFace> _recognizedFaces;
        //нераспознанные лица
        private List<Rectangle> _notRecognized;
        //маска значимых областей
        private Image<Gray, Byte> _mask;
        //изображения для формирования нового класса
        private Image<Gray, Byte>[] _currentFaces;
        //их количество
        private int _currentFacesCount;
        //обнаруженные лица
        private Rectangle[] _facesRect;
        //флаг активности захвата видеопотока
        private bool _capturing;
        //захват видеопотока
        private VideoCapture _capture = null;
        // путь к видеофайлу
        private String _videoPath = null;
        //кадр видеопотока
        private Mat _frame;
        //кадр видеопотока
        private Image<Bgr, Byte> _frameImg;

        public MainForm()
        {
            InitializeComponent();

            _detector = new FaceDetector();
            _faces = new List<FaceClass>();
            _notRecognized = new List<Rectangle>();
            _recognizedFaces = new List<RecognizedFace>();
            _currentFaces = new Image<Gray, Byte>[1000];
            _currentFacesCount = 0;
            _facesRect = null;
            _mask = new Image<Gray, byte>("mask.png");
            _mask = _mask.Resize(256, 256, Emgu.CV.CvEnum.Inter.Linear);
            _capturing = false;
            _capture = new VideoCapture();
            zedGraphControl1.GraphPane.Title.Text = "Histogram";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Value";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Count";
        }

        public Mat CalcHistogram(Image<Gray, Byte> image)
        {
            int dim = 4; //разбиение на блоки
            Mat result = new Mat();
            int width = image.Width / dim;
            int height = image.Height / dim;
            //цикл по всем блокам
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    image.ROI = new Rectangle(i * width, j * height, width, height);
                    DenseHistogram hist = new DenseHistogram(16, new RangeF(0, 15));
                    Image<Gray, Byte>[] inp = new Image<Gray, Byte>[1];
                    inp[0] = image;
                    //расчет для текущего блока
                    hist.Calculate(inp, true, null);
                    CvInvoke.Normalize(hist, hist);
                    //добавление к итоговой гистограмме
                    result.PushBack(hist);
                }
            }

            image.ROI = Rectangle.Empty;
            return result;
        }

        //распознавание лица
        private void RecognizeFace(Rectangle rect, Image<Gray, Byte> face, Image<Gray, Byte> lbp, Mat histogram, decimal threshold)
        {
            //минимальное расстояние до класса
            double mindist = double.MaxValue;
            //класс-результат
            FaceClass answer = null;
            //цикл по всем классам лиц
            foreach (FaceClass f in _faces)
            {
                //цикл по всем гистограммам класса
                foreach (Mat h in f.GetHist())
                {
                    double dist = CvInvoke.CompareHist(histogram, h, Emgu.CV.CvEnum.HistogramCompMethod.Chisqr);
                    //сравнить расстояние с минимальным
                    if (dist <= mindist)
                    {
                        //обновить минимальное расстояние
                        mindist = dist;
                        //принять результатом данный класс лиц
                        answer = f;
                    }
                }
            }
            //если расстояние меньше порогового обновить список распознанных лиц
            if (mindist < (double)threshold)
            {
                bool contains = false;
                CvInvoke.EqualizeHist(lbp, lbp);
                foreach (RecognizedFace element in _recognizedFaces)
                {
                    if ((element.GetFaceClass().GetName() == answer.GetName()) && (mindist < element.GetDist()))
                    {
                        _notRecognized.Add(element.GetRect());
                        element.SetFace(face);
                        element.SetLBP(lbp);
                        element.SetRect(rect);
                        element.SetHist(histogram);
                        element.SetDist(mindist);
                        contains = true;
                    }
                    //иначе добавить лицо в список нераспознанных лиц
                    else if ((element.GetFaceClass().GetName() == answer.GetName()) && (mindist >= element.GetDist()))
                    {
                        contains = true;
                        _notRecognized.Add(rect);
                    }
                }
                if (!contains)
                {
                    _recognizedFaces.Add(new RecognizedFace(answer, rect, face, lbp, histogram, mindist));
                }
            }
            else
            {
                _notRecognized.Add(rect);
            }
        }

        //обработка списка лиц
        private void ProcessFaces()
        {
            //для каждого лица в списке обнаруженных
            foreach (Rectangle rect in _facesRect)
            {
                _frameImg.ROI = rect;
                Image<Gray, Byte> face = _frameImg.Convert<Gray, Byte>();
                _frameImg.ROI = Rectangle.Empty;
                //масштабирование
                face = face.Resize(256, 256, Emgu.CV.CvEnum.Inter.Linear);
                //размытие по Гауссу
                CvInvoke.GaussianBlur(face, face, new Size((int)blurUpDown.Value * 2 - 1, (int)blurUpDown.Value * 2 - 1), 0);
                //LBP преобразованиеLBPHFaceRecognizer
                Image<Gray, Byte> lbpNoMask = LBPTransformer.CSTransform(face);
                Image<Gray, Byte> lbp = new Image<Gray, byte>(256, 256, new Gray(0));
                CvInvoke.cvCopy(lbpNoMask, lbp, _mask);
                //расчет гистограммы
                Mat histogram = CalcHistogram(lbp);
                //распознавание
                RecognizeFace(rect, face, lbp, histogram, thresholdUpDown.Value);
            }
        }

        //обработка кадра
        private void ProcessFrame(object sender, EventArgs arg)
        {
            //обнуление списков лиц
            _recognizedFaces = new List<RecognizedFace>();
            _notRecognized = new List<Rectangle>();
            _frameImg = new Image<Bgr, Byte>(_capture.Width, _capture.Height);
            _frame = new Mat();

            //получение кадра видеопотока
            _capture.Retrieve(_frame, 0);
            _frameImg = _frame.ToImage<Bgr, Byte>();
            //обнаружение лиц
            _facesRect = _detector.GetFacesRect(_frameImg, (double)neighborsUpDown.Value, (int)minsizeUpDown.Value, (int)scalefactorUpDown.Value);
            if (_facesRect.Length == 1)
            {
                addFaceButton.Invoke(new Action(() => { addFaceButton.Enabled = true; }));
            }
            else
            {
                addFaceButton.Invoke(new Action(() => { addFaceButton.Enabled = false; }));
            }
            //обработка списка обнаруженных лиц
            ProcessFaces();
            //вывод данных
            DrawDetected();
        }

        //очистка данных с формы
        private void ClearData()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            capFaceImageBox.Image = null;
            lbpImageBox.Image = null;
            distLabel.Invoke(new Action(() =>
            {
                distLabel.Text = " ";
            }));
        }

        //вывод данных на форму
        private void DrawDetected()
        {
            bool contains = false;
            //цикл по всем распознанным лицам
            foreach (RecognizedFace face in _recognizedFaces)
            {
                //выделить зеленым в кадре
                _frameImg.Draw(face.GetRect(), new Bgr(0, 255, 0), 3);
                //написать в кадре имя класса
                _frameImg.Draw(face.GetFaceClass().GetName(), face.GetRect().Location, Emgu.CV.CvEnum.FontFace.HersheyComplex, 3, new Bgr(0, 255, 0),2);
                //вывод данных на форму
                faceClassesListBox.Invoke(new Action(() =>
                {
                    if (face.GetFaceClass().GetName() == (string)faceClassesListBox.SelectedItem)
                    {
                        capFaceImageBox.Image = face.GetFace().Resize(capFaceImageBox.Width,capFaceImageBox.Height,Emgu.CV.CvEnum.Inter.Linear);
                        lbpImageBox.Image = face.GetLBP().Resize(lbpImageBox.Width, lbpImageBox.Height, Emgu.CV.CvEnum.Inter.Linear);
                        DrawHistogram(face.GetHist());

                        distLabel.Text = face.GetDist().ToString();
                        contains = true;
                    }
                }));
            }
            if (!contains) ClearData();
            //выделить все нераспознанные лица красным
            foreach (Rectangle rect in _notRecognized)
            {
                _frameImg.Draw(rect, new Bgr(0, 0, 255), 3);
            }
            _frameImg = _frameImg.Resize(captureBox.Width, (int)(_frame.Height * (captureBox.Width / (double)_frame.Width)), Emgu.CV.CvEnum.Inter.Linear);
            captureBox.Image = _frameImg;
        }
        //функция отрисовки гистограммы на форме
        private void DrawHistogram(Mat histogram)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            int dim = histogram.Height;
            Image<Gray, Double> histimg = histogram.ToImage<Gray, Double>();
            double[] hist = new double[dim];
            double[] xvalues = new double[dim];
            for (int i = 0; i < dim; i++)
            {
                xvalues[i] = i;
                hist[i] = histimg.Data[i, 0, 0];
            }
            BarItem bar1 = pane.AddBar("", xvalues, hist, Color.DeepSkyBlue);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        //открытие класса лиц
        private void OpenFaceClass(object sender, CancelEventArgs e)
        {
            foreach (string name in openFileDialog1.FileNames)
            {
                if (File.Exists(name))
                {
                    Stream TestFileStream = File.OpenRead(name);
                    BinaryFormatter deserializer = new BinaryFormatter();
                    FaceClass face = (FaceClass)deserializer.Deserialize(TestFileStream);
                    TestFileStream.Close();
                    _faces.Add(face); faceClassesListBox.Items.Add(face.GetName());
                }
            }
        }

        private void AddFaceButton_Click(object sender, EventArgs e)
        {
            if ((_currentFacesCount < 1000) && (_facesRect.Length > 0))
            {
                for (int qwe = 0; qwe < _facesRect.Length; qwe++)
                {
                    Image<Gray, Byte> fr = _frame.ToImage<Gray, Byte>();
                    fr.ROI = _facesRect[qwe];
                    _currentFaces[_currentFacesCount] = fr.Resize(256, 256, Emgu.CV.CvEnum.Inter.Linear);
                    CvInvoke.GaussianBlur(_currentFaces[_currentFacesCount], _currentFaces[_currentFacesCount],
    new Size((int)blurUpDown.Value * 2 - 1, (int)blurUpDown.Value * 2 - 1), 0);
                    imageBox4.Image = _currentFaces[_currentFacesCount].Resize(imageBox4.Width, imageBox4.Height, Emgu.CV.CvEnum.Inter.Linear);
                    _currentFacesCount++;
                    countLabel.Text = _currentFacesCount.ToString();
                    addClassButton.Enabled = true;
                    removeFaceButton.Enabled = true;
                }
            }
        }

        //добавление нового класса лиц
        private void AddClassButton_Click(object sender, EventArgs e)
        {
            //инициализация
            Image<Gray, Byte>[] img = new Image<Gray, Byte>[_currentFacesCount];
            Image<Gray, Byte> face = _currentFaces[0].Resize(256, 256, Emgu.CV.CvEnum.Inter.Linear);
            Mat[] hist = new Mat[_currentFacesCount];
            //обработкавсех лиц списка формирования нового класса и расчет гистограмм
            for (int i = 0; i < _currentFacesCount; i++)
            {
                Image<Gray, Byte> lbpNoMask = LBPTransformer.CSTransform(_currentFaces[i]);
                img[i] = new Image<Gray, byte>(256, 256, new Gray(0));
                CvInvoke.cvCopy(lbpNoMask, img[i], _mask);
                hist[i] = CalcHistogram(img[i]);
            }
            _faces.Add(new FaceClass(face, hist, classNameTextBox.Text));
            faceClassesListBox.Items.Add(classNameTextBox.Text);
            _currentFaces = new Image<Gray, Byte>[1000];
            _currentFacesCount = 0;
            countLabel.Text = "0";
            addClassButton.Enabled = false;
            removeFaceButton.Enabled = false;
            imageBox4.Image = null;
        }

        //смена выбранного класса лиц
        private void FaceClassesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (FaceClass face in _faces)
            {
                if (face.GetName() == (string)faceClassesListBox.SelectedItem)
                {
                    classImageImageBox.Image = face.GetImg().Resize(classImageImageBox.Width, classImageImageBox.Height, Emgu.CV.CvEnum.Inter.Linear);
                }
            }
            if (faceClassesListBox.SelectedItem != null)
            {
                saveClassButton.Enabled = true;
                removeClassButton.Enabled = true;
            }
            else
            {
                saveClassButton.Enabled = false;
                removeClassButton.Enabled = false;
            }
        }

        //удаление класса лиц из списка
        private void RemoveFaceButton_Click(object sender, EventArgs e)
        {
            _currentFacesCount--;
            countLabel.Text = _currentFacesCount.ToString();
            if (_currentFacesCount != 0)
            {
                imageBox4.Image = _currentFaces[_currentFacesCount - 1];
            }
            else
            {
                removeFaceButton.Enabled = false;
                addClassButton.Enabled = false;
                imageBox4.Image = null;
            }
        }

        //запуск обработки видеопотока
        private void VideoButton_Click(object sender, EventArgs e)
        {
            if (_capturing)
            {
                startButton.Text = "Начать";
                _capturing = false;
                _capture.Stop();
            }
            else
            {
                try
                {
                    startButton.Text = "Остановить";
                    _capturing = true;
                    if (radioButton1.Checked)
                    {
                        _capture.Dispose();
                        _capture = new VideoCapture();
                        _capture.ImageGrabbed += ProcessFrame;
                        _capture.Start();
                    }
                    else
                    {
                        _capture.Dispose();
                        _capture = new VideoCapture(_videoPath);
                        _capture.ImageGrabbed += ProcessFrame;
                        _capture.Start();
                    }
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
        }

        //сохранение класса лиц в файл
        private void SaveFaceClass(object sender, CancelEventArgs e)
        {
            saveFileDialog1.ShowDialog();

            FaceClass tosave = null;
            foreach (FaceClass face in _faces)
            {
                if (face.GetName() == faceClassesListBox.SelectedItem.ToString())
                {
                    tosave = face;
                }
            }
            Stream fileStream = File.Create(saveFileDialog1.FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fileStream, tosave);
            fileStream.Close();
        }

        //далее обработчики нажатий кнопок формы
        private void SaveClassButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

            FaceClass tosave = null;
            foreach (FaceClass face in _faces)
            {
                if (face.GetName() == faceClassesListBox.SelectedItem.ToString())
                {
                    tosave = face;
                }
            }
            Stream fileStream = File.Create(saveFileDialog1.FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fileStream, tosave);
            fileStream.Close();
        }
        private void OpenClassButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        private void RemoveClassButton_Click(object sender, EventArgs e)
        {
            _faces.RemoveAll(f => f.GetName() == (string)faceClassesListBox.SelectedItem);
            faceClassesListBox.Items.Remove(faceClassesListBox.SelectedItem);
        }
        private void OpenVideoButton_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }
        private void OpenFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            _videoPath = openFileDialog2.FileName;
            videoPathLabel.Text = _videoPath;
        }

        private void radioButtonFromFile_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFromFile.Checked == true)
            {
                openVideoButton.Enabled = true;
            }
            else 
            {
                openVideoButton.Enabled = false;
            }
        }
    }
}

