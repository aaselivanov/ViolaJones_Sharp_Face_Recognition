namespace Cheesy_Face_Recognition
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxVideo = new System.Windows.Forms.GroupBox();
            this.captureBox = new Emgu.CV.UI.ImageBox();
            this.startButton = new System.Windows.Forms.Button();
            this.videoPathLabel = new System.Windows.Forms.Label();
            this.openVideoButton = new System.Windows.Forms.Button();
            this.radioButtonFromFile = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.labelScaleFactor = new System.Windows.Forms.Label();
            this.labelMinSize = new System.Windows.Forms.Label();
            this.labelMinNeighbours = new System.Windows.Forms.Label();
            this.scalefactorUpDown = new System.Windows.Forms.NumericUpDown();
            this.minsizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.neighborsUpDown = new System.Windows.Forms.NumericUpDown();
            this.thresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.labelGaussSetting = new System.Windows.Forms.Label();
            this.blurUpDown = new System.Windows.Forms.NumericUpDown();
            this.addFaceButton = new System.Windows.Forms.Button();
            this.distLabel = new System.Windows.Forms.Label();
            this.faceClassesListBox = new System.Windows.Forms.ListBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.GroupBoxSelectedClass = new System.Windows.Forms.GroupBox();
            this.classImageImageBox = new Emgu.CV.UI.ImageBox();
            this.lbpImageBox = new Emgu.CV.UI.ImageBox();
            this.capFaceImageBox = new Emgu.CV.UI.ImageBox();
            this.imageBox4 = new Emgu.CV.UI.ImageBox();
            this.countLabel = new System.Windows.Forms.Label();
            this.removeFaceButton = new System.Windows.Forms.Button();
            this.addClassButton = new System.Windows.Forms.Button();
            this.classNameTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.saveClassButton = new System.Windows.Forms.Button();
            this.removeClassButton = new System.Windows.Forms.Button();
            this.ClassLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.captureBox)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scalefactorUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minsizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neighborsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurUpDown)).BeginInit();
            this.GroupBoxSelectedClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classImageImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbpImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capFaceImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxVideo
            // 
            this.groupBoxVideo.Controls.Add(this.captureBox);
            this.groupBoxVideo.Controls.Add(this.startButton);
            this.groupBoxVideo.Controls.Add(this.videoPathLabel);
            this.groupBoxVideo.Controls.Add(this.openVideoButton);
            this.groupBoxVideo.Controls.Add(this.radioButtonFromFile);
            this.groupBoxVideo.Controls.Add(this.radioButton1);
            this.groupBoxVideo.Location = new System.Drawing.Point(13, 13);
            this.groupBoxVideo.Name = "groupBoxVideo";
            this.groupBoxVideo.Size = new System.Drawing.Size(527, 589);
            this.groupBoxVideo.TabIndex = 0;
            this.groupBoxVideo.TabStop = false;
            this.groupBoxVideo.Text = "Захват кадра";
            // 
            // captureBox
            // 
            this.captureBox.Location = new System.Drawing.Point(6, 66);
            this.captureBox.Name = "captureBox";
            this.captureBox.Size = new System.Drawing.Size(512, 512);
            this.captureBox.TabIndex = 2;
            this.captureBox.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(435, 14);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(83, 29);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Начать";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.VideoButton_Click);
            // 
            // videoPathLabel
            // 
            this.videoPathLabel.AutoSize = true;
            this.videoPathLabel.Location = new System.Drawing.Point(168, 48);
            this.videoPathLabel.Name = "videoPathLabel";
            this.videoPathLabel.Size = new System.Drawing.Size(34, 13);
            this.videoPathLabel.TabIndex = 3;
            this.videoPathLabel.Text = "Путь:";
            // 
            // openVideoButton
            // 
            this.openVideoButton.Enabled = false;
            this.openVideoButton.Location = new System.Drawing.Point(87, 43);
            this.openVideoButton.Name = "openVideoButton";
            this.openVideoButton.Size = new System.Drawing.Size(75, 23);
            this.openVideoButton.TabIndex = 2;
            this.openVideoButton.Text = "Открыть...";
            this.openVideoButton.UseVisualStyleBackColor = true;
            this.openVideoButton.Click += new System.EventHandler(this.OpenVideoButton_Click);
            // 
            // radioButtonFromFile
            // 
            this.radioButtonFromFile.AutoSize = true;
            this.radioButtonFromFile.Location = new System.Drawing.Point(7, 43);
            this.radioButtonFromFile.Name = "radioButtonFromFile";
            this.radioButtonFromFile.Size = new System.Drawing.Size(74, 17);
            this.radioButtonFromFile.TabIndex = 1;
            this.radioButtonFromFile.TabStop = true;
            this.radioButtonFromFile.Text = "Из файла";
            this.radioButtonFromFile.UseVisualStyleBackColor = true;
            this.radioButtonFromFile.CheckedChanged += new System.EventHandler(this.radioButtonFromFile_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "С камеры";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.labelScaleFactor);
            this.groupBoxSettings.Controls.Add(this.labelMinSize);
            this.groupBoxSettings.Controls.Add(this.labelMinNeighbours);
            this.groupBoxSettings.Controls.Add(this.scalefactorUpDown);
            this.groupBoxSettings.Controls.Add(this.minsizeUpDown);
            this.groupBoxSettings.Controls.Add(this.neighborsUpDown);
            this.groupBoxSettings.Controls.Add(this.thresholdUpDown);
            this.groupBoxSettings.Controls.Add(this.label1);
            this.groupBoxSettings.Controls.Add(this.labelGaussSetting);
            this.groupBoxSettings.Controls.Add(this.blurUpDown);
            this.groupBoxSettings.Location = new System.Drawing.Point(547, 509);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(413, 93);
            this.groupBoxSettings.TabIndex = 1;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Настройки";
            // 
            // labelScaleFactor
            // 
            this.labelScaleFactor.AutoSize = true;
            this.labelScaleFactor.Location = new System.Drawing.Point(189, 73);
            this.labelScaleFactor.Name = "labelScaleFactor";
            this.labelScaleFactor.Size = new System.Drawing.Size(124, 13);
            this.labelScaleFactor.TabIndex = 9;
            this.labelScaleFactor.Text = "Фактор шкалирования";
            // 
            // labelMinSize
            // 
            this.labelMinSize.AutoSize = true;
            this.labelMinSize.Location = new System.Drawing.Point(189, 47);
            this.labelMinSize.Name = "labelMinSize";
            this.labelMinSize.Size = new System.Drawing.Size(121, 13);
            this.labelMinSize.TabIndex = 8;
            this.labelMinSize.Text = "Минимальный размер";
            // 
            // labelMinNeighbours
            // 
            this.labelMinNeighbours.AutoSize = true;
            this.labelMinNeighbours.Location = new System.Drawing.Point(189, 16);
            this.labelMinNeighbours.Name = "labelMinNeighbours";
            this.labelMinNeighbours.Size = new System.Drawing.Size(112, 13);
            this.labelMinNeighbours.TabIndex = 7;
            this.labelMinNeighbours.Text = "kNN - число соседей";
            // 
            // scalefactorUpDown
            // 
            this.scalefactorUpDown.DecimalPlaces = 1;
            this.scalefactorUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scalefactorUpDown.Location = new System.Drawing.Point(321, 66);
            this.scalefactorUpDown.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            65536});
            this.scalefactorUpDown.Name = "scalefactorUpDown";
            this.scalefactorUpDown.Size = new System.Drawing.Size(43, 20);
            this.scalefactorUpDown.TabIndex = 6;
            this.scalefactorUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // minsizeUpDown
            // 
            this.minsizeUpDown.Location = new System.Drawing.Point(321, 40);
            this.minsizeUpDown.Name = "minsizeUpDown";
            this.minsizeUpDown.Size = new System.Drawing.Size(43, 20);
            this.minsizeUpDown.TabIndex = 5;
            this.minsizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // neighborsUpDown
            // 
            this.neighborsUpDown.Location = new System.Drawing.Point(321, 14);
            this.neighborsUpDown.Name = "neighborsUpDown";
            this.neighborsUpDown.Size = new System.Drawing.Size(43, 20);
            this.neighborsUpDown.TabIndex = 4;
            this.neighborsUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // thresholdUpDown
            // 
            this.thresholdUpDown.Location = new System.Drawing.Point(135, 38);
            this.thresholdUpDown.Name = "thresholdUpDown";
            this.thresholdUpDown.Size = new System.Drawing.Size(43, 20);
            this.thresholdUpDown.TabIndex = 3;
            this.thresholdUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Порог распознавания";
            // 
            // labelGaussSetting
            // 
            this.labelGaussSetting.AutoSize = true;
            this.labelGaussSetting.Location = new System.Drawing.Point(3, 13);
            this.labelGaussSetting.Name = "labelGaussSetting";
            this.labelGaussSetting.Size = new System.Drawing.Size(125, 13);
            this.labelGaussSetting.TabIndex = 1;
            this.labelGaussSetting.Text = "Фильтр Гаусса - сигма";
            // 
            // blurUpDown
            // 
            this.blurUpDown.Location = new System.Drawing.Point(135, 12);
            this.blurUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blurUpDown.Name = "blurUpDown";
            this.blurUpDown.Size = new System.Drawing.Size(43, 20);
            this.blurUpDown.TabIndex = 0;
            this.blurUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // addFaceButton
            // 
            this.addFaceButton.Enabled = false;
            this.addFaceButton.Location = new System.Drawing.Point(968, 451);
            this.addFaceButton.Name = "addFaceButton";
            this.addFaceButton.Size = new System.Drawing.Size(168, 28);
            this.addFaceButton.TabIndex = 2;
            this.addFaceButton.Text = "Добавить лицо в базу";
            this.addFaceButton.UseVisualStyleBackColor = true;
            this.addFaceButton.Click += new System.EventHandler(this.AddFaceButton_Click);
            // 
            // distLabel
            // 
            this.distLabel.AutoSize = true;
            this.distLabel.Location = new System.Drawing.Point(550, 493);
            this.distLabel.Name = "distLabel";
            this.distLabel.Size = new System.Drawing.Size(147, 13);
            this.distLabel.TabIndex = 3;
            this.distLabel.Text = "Дистанция распознавания:";
            // 
            // faceClassesListBox
            // 
            this.faceClassesListBox.FormattingEnabled = true;
            this.faceClassesListBox.Location = new System.Drawing.Point(966, 13);
            this.faceClassesListBox.Name = "faceClassesListBox";
            this.faceClassesListBox.Size = new System.Drawing.Size(170, 303);
            this.faceClassesListBox.TabIndex = 4;
            this.faceClassesListBox.SelectedIndexChanged += new System.EventHandler(this.FaceClassesListBox_SelectedIndexChanged);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(547, 207);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(413, 272);
            this.zedGraphControl1.TabIndex = 5;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // GroupBoxSelectedClass
            // 
            this.GroupBoxSelectedClass.Controls.Add(this.classImageImageBox);
            this.GroupBoxSelectedClass.Controls.Add(this.lbpImageBox);
            this.GroupBoxSelectedClass.Controls.Add(this.capFaceImageBox);
            this.GroupBoxSelectedClass.Location = new System.Drawing.Point(547, 13);
            this.GroupBoxSelectedClass.Name = "GroupBoxSelectedClass";
            this.GroupBoxSelectedClass.Size = new System.Drawing.Size(413, 176);
            this.GroupBoxSelectedClass.TabIndex = 6;
            this.GroupBoxSelectedClass.TabStop = false;
            this.GroupBoxSelectedClass.Text = "Определённый класс";
            // 
            // classImageImageBox
            // 
            this.classImageImageBox.Location = new System.Drawing.Point(7, 20);
            this.classImageImageBox.Name = "classImageImageBox";
            this.classImageImageBox.Size = new System.Drawing.Size(128, 128);
            this.classImageImageBox.TabIndex = 2;
            this.classImageImageBox.TabStop = false;
            // 
            // lbpImageBox
            // 
            this.lbpImageBox.Location = new System.Drawing.Point(284, 20);
            this.lbpImageBox.Name = "lbpImageBox";
            this.lbpImageBox.Size = new System.Drawing.Size(128, 128);
            this.lbpImageBox.TabIndex = 2;
            this.lbpImageBox.TabStop = false;
            // 
            // capFaceImageBox
            // 
            this.capFaceImageBox.Location = new System.Drawing.Point(146, 21);
            this.capFaceImageBox.Name = "capFaceImageBox";
            this.capFaceImageBox.Size = new System.Drawing.Size(128, 128);
            this.capFaceImageBox.TabIndex = 2;
            this.capFaceImageBox.TabStop = false;
            // 
            // imageBox4
            // 
            this.imageBox4.Location = new System.Drawing.Point(988, 320);
            this.imageBox4.Name = "imageBox4";
            this.imageBox4.Size = new System.Drawing.Size(128, 128);
            this.imageBox4.TabIndex = 2;
            this.imageBox4.TabStop = false;
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(965, 482);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(93, 13);
            this.countLabel.TabIndex = 7;
            this.countLabel.Text = "Добавлено: 0/30";
            // 
            // removeFaceButton
            // 
            this.removeFaceButton.Location = new System.Drawing.Point(968, 499);
            this.removeFaceButton.Name = "removeFaceButton";
            this.removeFaceButton.Size = new System.Drawing.Size(168, 23);
            this.removeFaceButton.TabIndex = 8;
            this.removeFaceButton.Text = "Удалить лицо из базы";
            this.removeFaceButton.UseVisualStyleBackColor = true;
            this.removeFaceButton.Click += new System.EventHandler(this.RemoveFaceButton_Click);
            // 
            // addClassButton
            // 
            this.addClassButton.Location = new System.Drawing.Point(970, 541);
            this.addClassButton.Name = "addClassButton";
            this.addClassButton.Size = new System.Drawing.Size(81, 21);
            this.addClassButton.TabIndex = 9;
            this.addClassButton.Text = "Добавить";
            this.addClassButton.UseVisualStyleBackColor = true;
            this.addClassButton.Click += new System.EventHandler(this.AddClassButton_Click);
            // 
            // classNameTextBox
            // 
            this.classNameTextBox.Location = new System.Drawing.Point(1053, 541);
            this.classNameTextBox.Name = "classNameTextBox";
            this.classNameTextBox.Size = new System.Drawing.Size(83, 20);
            this.classNameTextBox.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(969, 568);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Открыть";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OpenClassButton_Click);
            // 
            // saveClassButton
            // 
            this.saveClassButton.Location = new System.Drawing.Point(1053, 568);
            this.saveClassButton.Name = "saveClassButton";
            this.saveClassButton.Size = new System.Drawing.Size(82, 23);
            this.saveClassButton.TabIndex = 12;
            this.saveClassButton.Text = "Сохранить";
            this.saveClassButton.UseVisualStyleBackColor = true;
            this.saveClassButton.Click += new System.EventHandler(this.SaveClassButton_Click);
            // 
            // removeClassButton
            // 
            this.removeClassButton.Location = new System.Drawing.Point(1017, 591);
            this.removeClassButton.Name = "removeClassButton";
            this.removeClassButton.Size = new System.Drawing.Size(71, 23);
            this.removeClassButton.TabIndex = 13;
            this.removeClassButton.Text = "Удалить";
            this.removeClassButton.UseVisualStyleBackColor = true;
            this.removeClassButton.Click += new System.EventHandler(this.RemoveClassButton_Click);
            // 
            // ClassLabel
            // 
            this.ClassLabel.AutoSize = true;
            this.ClassLabel.Location = new System.Drawing.Point(970, 527);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(46, 13);
            this.ClassLabel.TabIndex = 14;
            this.ClassLabel.Text = "Классы";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog2_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 614);
            this.Controls.Add(this.ClassLabel);
            this.Controls.Add(this.removeClassButton);
            this.Controls.Add(this.saveClassButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.classNameTextBox);
            this.Controls.Add(this.addClassButton);
            this.Controls.Add(this.removeFaceButton);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.imageBox4);
            this.Controls.Add(this.GroupBoxSelectedClass);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.faceClassesListBox);
            this.Controls.Add(this.distLabel);
            this.Controls.Add(this.addFaceButton);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxVideo);
            this.Name = "MainForm";
            this.Text = "Face Recognition alpha v.0.1";
            this.groupBoxVideo.ResumeLayout(false);
            this.groupBoxVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.captureBox)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scalefactorUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minsizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neighborsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurUpDown)).EndInit();
            this.GroupBoxSelectedClass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.classImageImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbpImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capFaceImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxVideo;
        private Emgu.CV.UI.ImageBox captureBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label videoPathLabel;
        private System.Windows.Forms.Button openVideoButton;
        private System.Windows.Forms.RadioButton radioButtonFromFile;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.NumericUpDown thresholdUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelGaussSetting;
        private System.Windows.Forms.NumericUpDown blurUpDown;
        private System.Windows.Forms.NumericUpDown scalefactorUpDown;
        private System.Windows.Forms.NumericUpDown minsizeUpDown;
        private System.Windows.Forms.NumericUpDown neighborsUpDown;
        private System.Windows.Forms.Button addFaceButton;
        private System.Windows.Forms.Label distLabel;
        private System.Windows.Forms.ListBox faceClassesListBox;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label labelScaleFactor;
        private System.Windows.Forms.Label labelMinSize;
        private System.Windows.Forms.Label labelMinNeighbours;
        private System.Windows.Forms.GroupBox GroupBoxSelectedClass;
        private Emgu.CV.UI.ImageBox capFaceImageBox;
        private Emgu.CV.UI.ImageBox lbpImageBox;
        private Emgu.CV.UI.ImageBox imageBox4;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Button removeFaceButton;
        private System.Windows.Forms.Button addClassButton;
        private System.Windows.Forms.TextBox classNameTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button saveClassButton;
        private System.Windows.Forms.Button removeClassButton;
        private System.Windows.Forms.Label ClassLabel;
        private Emgu.CV.UI.ImageBox classImageImageBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

