namespace VisionSetUp
{
    partial class ModelSetUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelSetUp));
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.comboBox_channel = new System.Windows.Forms.ComboBox();
            this.comboBox_color = new System.Windows.Forms.ComboBox();
            this.comboBox_format = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveModel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nametextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.collectModelToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ModelTestToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.selectCameraVersion = new System.Windows.Forms.ToolStripComboBox();
            this.modelTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.ModelWrite = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(12, 33);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(446, 584);
            this.hWindowControl1.TabIndex = 9;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(446, 584);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "CHANNEL:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "COLOUR:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "VIDEO:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 21;
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
            this.comboBox_port.Location = new System.Drawing.Point(112, 15);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(201, 28);
            this.comboBox_port.TabIndex = 20;
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
            this.comboBox_channel.Location = new System.Drawing.Point(112, 49);
            this.comboBox_channel.Name = "comboBox_channel";
            this.comboBox_channel.Size = new System.Drawing.Size(201, 28);
            this.comboBox_channel.TabIndex = 19;
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
            this.comboBox_color.Location = new System.Drawing.Point(112, 83);
            this.comboBox_color.Name = "comboBox_color";
            this.comboBox_color.Size = new System.Drawing.Size(201, 28);
            this.comboBox_color.TabIndex = 17;
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
            this.comboBox_format.Location = new System.Drawing.Point(112, 117);
            this.comboBox_format.Name = "comboBox_format";
            this.comboBox_format.Size = new System.Drawing.Size(201, 28);
            this.comboBox_format.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_port);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboBox_format);
            this.groupBox1.Controls.Add(this.comboBox_color);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBox_channel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(465, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 156);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // saveModel
            // 
            this.saveModel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveModel.Location = new System.Drawing.Point(12, 57);
            this.saveModel.Name = "saveModel";
            this.saveModel.Size = new System.Drawing.Size(301, 35);
            this.saveModel.TabIndex = 8;
            this.saveModel.Text = "save";
            this.saveModel.UseVisualStyleBackColor = true;
            this.saveModel.Click += new System.EventHandler(this.saveModel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nametextBox);
            this.groupBox2.Controls.Add(this.saveModel);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(465, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 105);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input what you want to create：";
            // 
            // nametextBox
            // 
            this.nametextBox.Location = new System.Drawing.Point(12, 25);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.Size = new System.Drawing.Size(301, 26);
            this.nametextBox.TabIndex = 28;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collectModelToolStripButton,
            this.ModelTestToolStripButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.selectCameraVersion,
            this.modelTextBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(815, 27);
            this.toolStrip1.TabIndex = 30;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // collectModelToolStripButton
            // 
            this.collectModelToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("collectModelToolStripButton.Image")));
            this.collectModelToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.collectModelToolStripButton.Name = "collectModelToolStripButton";
            this.collectModelToolStripButton.Size = new System.Drawing.Size(110, 24);
            this.collectModelToolStripButton.Text = "capture one";
            this.collectModelToolStripButton.Click += new System.EventHandler(this.collectModelToolStripButton_Click);
            // 
            // ModelTestToolStripButton
            // 
            this.ModelTestToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ModelTestToolStripButton.Image")));
            this.ModelTestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ModelTestToolStripButton.Name = "ModelTestToolStripButton";
            this.ModelTestToolStripButton.Size = new System.Drawing.Size(102, 24);
            this.ModelTestToolStripButton.Text = "Testbutton";
            this.ModelTestToolStripButton.Click += new System.EventHandler(this.ModelTestToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(173, 24);
            this.toolStripLabel1.Text = "choose Created-Mode：";
            // 
            // selectCameraVersion
            // 
            this.selectCameraVersion.BackColor = System.Drawing.SystemColors.MenuBar;
            this.selectCameraVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectCameraVersion.Items.AddRange(new object[] {
            "全景",
            "其它"});
            this.selectCameraVersion.Name = "selectCameraVersion";
            this.selectCameraVersion.Size = new System.Drawing.Size(121, 27);
            this.selectCameraVersion.SelectedIndexChanged += new System.EventHandler(this.ModelComboBox_SelectedIndexChanged);
            // 
            // modelTextBox
            // 
            this.modelTextBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.modelTextBox.Name = "modelTextBox";
            this.modelTextBox.Size = new System.Drawing.Size(100, 27);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteButton.Location = new System.Drawing.Point(47, 623);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(376, 34);
            this.deleteButton.TabIndex = 31;
            this.deleteButton.Text = "Delete this Model";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // ModelWrite
            // 
            this.ModelWrite.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ModelWrite.Location = new System.Drawing.Point(477, 195);
            this.ModelWrite.Name = "ModelWrite";
            this.ModelWrite.Size = new System.Drawing.Size(301, 35);
            this.ModelWrite.TabIndex = 32;
            this.ModelWrite.Text = "ModelWrite";
            this.ModelWrite.UseVisualStyleBackColor = true;
            this.ModelWrite.Click += new System.EventHandler(this.ModelWrite_Click);
            // 
            // ModelSetUp
            // 
            this.AcceptButton = this.saveModel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 669);
            this.Controls.Add(this.ModelWrite);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hWindowControl1);
            this.Name = "ModelSetUp";
            this.Text = "模板设置";
            this.Load += new System.EventHandler(this.ModelSetUp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_port;
        private System.Windows.Forms.ComboBox comboBox_channel;
        private System.Windows.Forms.ComboBox comboBox_color;
        private System.Windows.Forms.ComboBox comboBox_format;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveModel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox nametextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton collectModelToolStripButton;
        private System.Windows.Forms.ToolStripButton ModelTestToolStripButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ToolStripComboBox selectCameraVersion;
        private System.Windows.Forms.ToolStripTextBox modelTextBox;
        private System.Windows.Forms.Button ModelWrite;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}