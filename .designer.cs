namespace VisionSetUp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PrintFormButton = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.barcodeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AddBarcodeButton = new System.Windows.Forms.Button();
            this.ModelSetUpButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.comboBox_channel = new System.Windows.Forms.ComboBox();
            this.comboBox_interrupt = new System.Windows.Forms.ComboBox();
            this.comboBox_color = new System.Windows.Forms.ComboBox();
            this.comboBox_format = new System.Windows.Forms.ComboBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LoginButton = new System.Windows.Forms.ToolStripButton();
            this.begionButton = new System.Windows.Forms.ToolStripButton();
            this.stopTestButton = new System.Windows.Forms.ToolStripButton();
            this.continuePrintButton = new System.Windows.Forms.ToolStripButton();
            this.stopPrintButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.selectCameraVersion = new System.Windows.Forms.ToolStripComboBox();
            this.modelTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resultTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(490, 532);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 92);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // resultTextBox
            // 
            this.resultTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.resultTextBox.Enabled = false;
            this.resultTextBox.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultTextBox.ForeColor = System.Drawing.Color.OrangeRed;
            this.resultTextBox.Location = new System.Drawing.Point(6, 20);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(460, 54);
            this.resultTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // PrintFormButton
            // 
            this.PrintFormButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PrintFormButton.Location = new System.Drawing.Point(6, 109);
            this.PrintFormButton.Name = "PrintFormButton";
            this.PrintFormButton.Size = new System.Drawing.Size(460, 35);
            this.PrintFormButton.TabIndex = 7;
            this.PrintFormButton.Text = "进入打印界面";
            this.PrintFormButton.UseVisualStyleBackColor = true;
            this.PrintFormButton.Click += new System.EventHandler(this.PrintFormButton_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.nameTextBox);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.barcodeTextBox);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.PrintFormButton);
            this.groupBox8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox8.Location = new System.Drawing.Point(12, 529);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(472, 155);
            this.groupBox8.TabIndex = 14;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "当前正在打印：";
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(110, 25);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(347, 26);
            this.nameTextBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "产品名称：";
            // 
            // barcodeTextBox
            // 
            this.barcodeTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.barcodeTextBox.Enabled = false;
            this.barcodeTextBox.Location = new System.Drawing.Point(110, 63);
            this.barcodeTextBox.Name = "barcodeTextBox";
            this.barcodeTextBox.ReadOnly = true;
            this.barcodeTextBox.Size = new System.Drawing.Size(347, 26);
            this.barcodeTextBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "条码编号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(592, 638);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(370, 46);
            this.label5.TabIndex = 18;
            this.label5.Text = "Amend By JunshuoLi";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AddBarcodeButton);
            this.groupBox2.Controls.Add(this.ModelSetUpButton);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboBox_port);
            this.groupBox2.Controls.Add(this.comboBox_channel);
            this.groupBox2.Controls.Add(this.comboBox_interrupt);
            this.groupBox2.Controls.Add(this.comboBox_color);
            this.groupBox2.Controls.Add(this.comboBox_format);
            this.groupBox2.Controls.Add(this.stopButton);
            this.groupBox2.Controls.Add(this.continueButton);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(642, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 351);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测试连接界面  仅限测试使用";
            // 
            // AddBarcodeButton
            // 
            this.AddBarcodeButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddBarcodeButton.Location = new System.Drawing.Point(12, 304);
            this.AddBarcodeButton.Name = "AddBarcodeButton";
            this.AddBarcodeButton.Size = new System.Drawing.Size(302, 30);
            this.AddBarcodeButton.TabIndex = 7;
            this.AddBarcodeButton.Text = "AddBarcode";
            this.AddBarcodeButton.UseVisualStyleBackColor = true;
            this.AddBarcodeButton.Click += new System.EventHandler(this.AddBarcodeButton_Click);
            // 
            // ModelSetUpButton
            // 
            this.ModelSetUpButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ModelSetUpButton.Location = new System.Drawing.Point(12, 268);
            this.ModelSetUpButton.Name = "ModelSetUpButton";
            this.ModelSetUpButton.Size = new System.Drawing.Size(302, 30);
            this.ModelSetUpButton.TabIndex = 5;
            this.ModelSetUpButton.Text = "ModelSetUp";
            this.ModelSetUpButton.UseVisualStyleBackColor = true;
            this.ModelSetUpButton.Click += new System.EventHandler(this.ModelSetUpButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "CHANNEL:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "INTERRUPT:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "COLOUR:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "VIDEO:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "PORT:";
            // 
            // comboBox_port
            // 
            this.comboBox_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_port.FormattingEnabled = true;
            this.comboBox_port.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox_port.Location = new System.Drawing.Point(113, 97);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(201, 28);
            this.comboBox_port.TabIndex = 9;
            // 
            // comboBox_channel
            // 
            this.comboBox_channel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_channel.FormattingEnabled = true;
            this.comboBox_channel.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox_channel.Location = new System.Drawing.Point(113, 131);
            this.comboBox_channel.Name = "comboBox_channel";
            this.comboBox_channel.Size = new System.Drawing.Size(201, 28);
            this.comboBox_channel.TabIndex = 8;
            // 
            // comboBox_interrupt
            // 
            this.comboBox_interrupt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_interrupt.FormattingEnabled = true;
            this.comboBox_interrupt.Items.AddRange(new object[] {
            "callback",
            "thread"});
            this.comboBox_interrupt.Location = new System.Drawing.Point(113, 166);
            this.comboBox_interrupt.Name = "comboBox_interrupt";
            this.comboBox_interrupt.Size = new System.Drawing.Size(201, 28);
            this.comboBox_interrupt.TabIndex = 7;
            // 
            // comboBox_color
            // 
            this.comboBox_color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_color.FormattingEnabled = true;
            this.comboBox_color.Items.AddRange(new object[] {
            "Y8",
            "RGB15",
            "RGB16",
            "RGB24",
            "RGB32"});
            this.comboBox_color.Location = new System.Drawing.Point(113, 200);
            this.comboBox_color.Name = "comboBox_color";
            this.comboBox_color.Size = new System.Drawing.Size(201, 28);
            this.comboBox_color.TabIndex = 6;
            // 
            // comboBox_format
            // 
            this.comboBox_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_format.FormattingEnabled = true;
            this.comboBox_format.Items.AddRange(new object[] {
            "NTSC",
            "PAL",
            "CIF NTSC",
            "CIF PAL",
            "QCIF NTSC",
            "QCIF PAL"});
            this.comboBox_format.Location = new System.Drawing.Point(113, 234);
            this.comboBox_format.Name = "comboBox_format";
            this.comboBox_format.Size = new System.Drawing.Size(201, 28);
            this.comboBox_format.TabIndex = 5;
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopButton.Location = new System.Drawing.Point(12, 61);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(302, 30);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.continueButton.Location = new System.Drawing.Point(12, 25);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(302, 30);
            this.continueButton.TabIndex = 3;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(12, 28);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(624, 495);
            this.hWindowControl1.TabIndex = 20;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(624, 495);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoginButton,
            this.begionButton,
            this.stopTestButton,
            this.continuePrintButton,
            this.stopPrintButton,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.selectCameraVersion,
            this.modelTextBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(975, 25);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // LoginButton
            // 
            this.LoginButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LoginButton.Image = ((System.Drawing.Image)(resources.GetObject("LoginButton.Image")));
            this.LoginButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(76, 22);
            this.LoginButton.Text = "验证身份";
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // begionButton
            // 
            this.begionButton.Image = ((System.Drawing.Image)(resources.GetObject("begionButton.Image")));
            this.begionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.begionButton.Name = "begionButton";
            this.begionButton.Size = new System.Drawing.Size(76, 22);
            this.begionButton.Text = "启动测试";
            this.begionButton.Click += new System.EventHandler(this.begionButton_Click);
            // 
            // stopTestButton
            // 
            this.stopTestButton.Image = ((System.Drawing.Image)(resources.GetObject("stopTestButton.Image")));
            this.stopTestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopTestButton.Name = "stopTestButton";
            this.stopTestButton.Size = new System.Drawing.Size(76, 22);
            this.stopTestButton.Text = "停止测试";
            this.stopTestButton.Click += new System.EventHandler(this.stopTestButton_Click);
            // 
            // continuePrintButton
            // 
            this.continuePrintButton.Image = ((System.Drawing.Image)(resources.GetObject("continuePrintButton.Image")));
            this.continuePrintButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.continuePrintButton.Name = "continuePrintButton";
            this.continuePrintButton.Size = new System.Drawing.Size(76, 22);
            this.continuePrintButton.Text = "继续打印";
            this.continuePrintButton.Click += new System.EventHandler(this.continuePrintButton_Click);
            // 
            // stopPrintButton
            // 
            this.stopPrintButton.Image = ((System.Drawing.Image)(resources.GetObject("stopPrintButton.Image")));
            this.stopPrintButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopPrintButton.Name = "stopPrintButton";
            this.stopPrintButton.Size = new System.Drawing.Size(76, 22);
            this.stopPrintButton.Text = "停止打印";
            this.stopPrintButton.Click += new System.EventHandler(this.stopPrintButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton1.Text = "历史数据查询";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(92, 22);
            this.toolStripLabel1.Text = "选择测试模板：";
            // 
            // selectCameraVersion
            // 
            this.selectCameraVersion.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.selectCameraVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectCameraVersion.Name = "selectCameraVersion";
            this.selectCameraVersion.Size = new System.Drawing.Size(121, 25);
            this.selectCameraVersion.SelectedIndexChanged += new System.EventHandler(this.selectCameraVersion_SelectedIndexChanged);
            // 
            // modelTextBox
            // 
            this.modelTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.modelTextBox.Name = "modelTextBox";
            this.modelTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 689);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.hWindowControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PrintFormButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox barcodeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ComboBox comboBox_port;
        private System.Windows.Forms.ComboBox comboBox_channel;
        private System.Windows.Forms.ComboBox comboBox_interrupt;
        private System.Windows.Forms.ComboBox comboBox_color;
        private System.Windows.Forms.ComboBox comboBox_format;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.Button ModelSetUpButton;
        private System.Windows.Forms.Button AddBarcodeButton;
        public System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox selectCameraVersion;
        private System.Windows.Forms.ToolStripButton LoginButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox modelTextBox;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton begionButton;
        private System.Windows.Forms.ToolStripButton stopTestButton;
        private System.Windows.Forms.ToolStripButton continuePrintButton;
        private System.Windows.Forms.ToolStripButton stopPrintButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}