namespace NMEAInserter
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.driverIDLabel = new System.Windows.Forms.Label();
            this.driverIDComboBox = new System.Windows.Forms.ComboBox();
            this.carIDLabel = new System.Windows.Forms.Label();
            this.carIDComboBox = new System.Windows.Forms.ComboBox();
            this.startInsertingButton = new System.Windows.Forms.Button();
            this.indexLabel = new System.Windows.Forms.Label();
            this.successInsertingLabel = new System.Windows.Forms.Label();
            this.successInsertingTextBox = new System.Windows.Forms.TextBox();
            this.failedInsertingLabel = new System.Windows.Forms.Label();
            this.failedInsertingTextBox = new System.Windows.Forms.TextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.errorCodeLabel = new System.Windows.Forms.Label();
            this.nullAllowanceCheckBox = new System.Windows.Forms.CheckBox();
            this.sensorIDcomboBox = new System.Windows.Forms.ComboBox();
            this.sensorIdLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // driverIDLabel
            // 
            this.driverIDLabel.AutoSize = true;
            this.driverIDLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.driverIDLabel.Location = new System.Drawing.Point(12, 35);
            this.driverIDLabel.Name = "driverIDLabel";
            this.driverIDLabel.Size = new System.Drawing.Size(68, 16);
            this.driverIDLabel.TabIndex = 0;
            this.driverIDLabel.Text = "Driver ID";
            // 
            // driverIDComboBox
            // 
            this.driverIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driverIDComboBox.FormattingEnabled = true;
            this.driverIDComboBox.Items.AddRange(new object[] {
            "1（富井先生）",
            "4（森先生）",
            "17 植村",
            "20 茨城",
            "21 濱崎",
            "24 小池",
            "26 磯部",
            "28 吉瀬",
            "29 猪谷",
            "30 勝村",
            "31 渡辺",
            "32 石田",
            "33 深野"});
            this.driverIDComboBox.Location = new System.Drawing.Point(15, 55);
            this.driverIDComboBox.Name = "driverIDComboBox";
            this.driverIDComboBox.Size = new System.Drawing.Size(121, 20);
            this.driverIDComboBox.TabIndex = 1;
            this.driverIDComboBox.SelectedIndexChanged += new System.EventHandler(this.driverIDComboBox_SelectedIndexChanged);
            // 
            // carIDLabel
            // 
            this.carIDLabel.AutoSize = true;
            this.carIDLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.carIDLabel.Location = new System.Drawing.Point(151, 35);
            this.carIDLabel.Name = "carIDLabel";
            this.carIDLabel.Size = new System.Drawing.Size(52, 16);
            this.carIDLabel.TabIndex = 2;
            this.carIDLabel.Text = "Car ID";
            // 
            // carIDComboBox
            // 
            this.carIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carIDComboBox.FormattingEnabled = true;
            this.carIDComboBox.Items.AddRange(new object[] {
            "3（LEAF）",
            "8（LEAF_XXXXXX）",
            "11 2018春LEAF-ZE1",
            "12 2018春DAYZ"});
            this.carIDComboBox.Location = new System.Drawing.Point(154, 55);
            this.carIDComboBox.Name = "carIDComboBox";
            this.carIDComboBox.Size = new System.Drawing.Size(121, 20);
            this.carIDComboBox.TabIndex = 3;
            // 
            // startInsertingButton
            // 
            this.startInsertingButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.startInsertingButton.Location = new System.Drawing.Point(15, 82);
            this.startInsertingButton.Name = "startInsertingButton";
            this.startInsertingButton.Size = new System.Drawing.Size(121, 28);
            this.startInsertingButton.TabIndex = 4;
            this.startInsertingButton.Text = "Start inserting";
            this.startInsertingButton.UseVisualStyleBackColor = true;
            this.startInsertingButton.Click += new System.EventHandler(this.startInsertingButton_Click);
            // 
            // indexLabel
            // 
            this.indexLabel.AutoSize = true;
            this.indexLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.indexLabel.Location = new System.Drawing.Point(172, 88);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(103, 16);
            this.indexLabel.TabIndex = 5;
            this.indexLabel.Text = "inserting index";
            // 
            // successInsertingLabel
            // 
            this.successInsertingLabel.AutoSize = true;
            this.successInsertingLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.successInsertingLabel.Location = new System.Drawing.Point(15, 117);
            this.successInsertingLabel.Name = "successInsertingLabel";
            this.successInsertingLabel.Size = new System.Drawing.Size(160, 16);
            this.successInsertingLabel.TabIndex = 6;
            this.successInsertingLabel.Text = "Success inserting data";
            // 
            // successInsertingTextBox
            // 
            this.successInsertingTextBox.Location = new System.Drawing.Point(18, 137);
            this.successInsertingTextBox.MaxLength = 0;
            this.successInsertingTextBox.Multiline = true;
            this.successInsertingTextBox.Name = "successInsertingTextBox";
            this.successInsertingTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.successInsertingTextBox.Size = new System.Drawing.Size(512, 150);
            this.successInsertingTextBox.TabIndex = 7;
            // 
            // failedInsertingLabel
            // 
            this.failedInsertingLabel.AutoSize = true;
            this.failedInsertingLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.failedInsertingLabel.Location = new System.Drawing.Point(18, 294);
            this.failedInsertingLabel.Name = "failedInsertingLabel";
            this.failedInsertingLabel.Size = new System.Drawing.Size(143, 16);
            this.failedInsertingLabel.TabIndex = 8;
            this.failedInsertingLabel.Text = "Failed inserting data";
            // 
            // failedInsertingTextBox
            // 
            this.failedInsertingTextBox.Location = new System.Drawing.Point(18, 314);
            this.failedInsertingTextBox.MaxLength = 0;
            this.failedInsertingTextBox.Multiline = true;
            this.failedInsertingTextBox.Name = "failedInsertingTextBox";
            this.failedInsertingTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.failedInsertingTextBox.Size = new System.Drawing.Size(512, 150);
            this.failedInsertingTextBox.TabIndex = 9;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.fileNameLabel.Location = new System.Drawing.Point(13, 13);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(86, 16);
            this.fileNameLabel.TabIndex = 10;
            this.fileNameLabel.Text = "File name ...";
            // 
            // errorCodeLabel
            // 
            this.errorCodeLabel.AutoSize = true;
            this.errorCodeLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.errorCodeLabel.Location = new System.Drawing.Point(21, 471);
            this.errorCodeLabel.Name = "errorCodeLabel";
            this.errorCodeLabel.Size = new System.Drawing.Size(94, 16);
            this.errorCodeLabel.TabIndex = 11;
            this.errorCodeLabel.Text = "Error code ...";
            // 
            // nullAllowanceCheckBox
            // 
            this.nullAllowanceCheckBox.AutoSize = true;
            this.nullAllowanceCheckBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nullAllowanceCheckBox.Location = new System.Drawing.Point(416, 55);
            this.nullAllowanceCheckBox.Name = "nullAllowanceCheckBox";
            this.nullAllowanceCheckBox.Size = new System.Drawing.Size(138, 20);
            this.nullAllowanceCheckBox.TabIndex = 12;
            this.nullAllowanceCheckBox.Text = "Allow null Trip ID";
            this.nullAllowanceCheckBox.UseVisualStyleBackColor = true;
            // 
            // sensorComboBox
            // 
            this.sensorIDcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sensorIDcomboBox.FormattingEnabled = true;
            this.sensorIDcomboBox.Items.AddRange(new object[] {
                "1 747Pro&WAA010",
                "3 N-06C",
                "4 747Pro&WAA010",
                "6 AT3S0",
                "7 SC-01C",
                "8 AT570",
                "9 MZ604",
                "10 MZ604",
                "11 A1_07",
                "12 AT570",
                "13 AT570",
                "14 Nexus7",
                "15 SO-04D",
                "16 AT570",
                "17 Nexus7",
                "18 Nexus7",
                "19 ACE",
                "20 Nexus7",
                "21 XperiaGX_SO",
                "22 SO-02F",
                "23 Nexus6",
                "24 Nexus7(2012)",
                "25 Nexus7",
                "26 Zenfone2",
                "27 SKT01",
                "98 Simulation",
                "99 simulation"
            });
            this.sensorIDcomboBox.Location = new System.Drawing.Point(289, 55);
            this.sensorIDcomboBox.Name = "sensorIDComboBox";
            this.sensorIDcomboBox.Size = new System.Drawing.Size(121, 20);
            this.sensorIDcomboBox.TabIndex = 13;
            // 
            // sensorIdLabel
            // 
            this.sensorIdLabel.AutoSize = true;
            this.sensorIdLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.sensorIdLabel.Location = new System.Drawing.Point(286, 36);
            this.sensorIdLabel.Name = "sensorIdLabel";
            this.sensorIdLabel.Size = new System.Drawing.Size(52, 16);
            this.sensorIdLabel.TabIndex = 14;
            this.sensorIdLabel.Text = "SensorID";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 496);
            this.Controls.Add(this.sensorIdLabel);
            this.Controls.Add(this.sensorIDcomboBox);
            this.Controls.Add(this.nullAllowanceCheckBox);
            this.Controls.Add(this.errorCodeLabel);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.failedInsertingTextBox);
            this.Controls.Add(this.failedInsertingLabel);
            this.Controls.Add(this.successInsertingTextBox);
            this.Controls.Add(this.successInsertingLabel);
            this.Controls.Add(this.indexLabel);
            this.Controls.Add(this.startInsertingButton);
            this.Controls.Add(this.carIDComboBox);
            this.Controls.Add(this.carIDLabel);
            this.Controls.Add(this.driverIDComboBox);
            this.Controls.Add(this.driverIDLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "NMEAInserter";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label driverIDLabel;
        private System.Windows.Forms.ComboBox driverIDComboBox;
        private System.Windows.Forms.Label carIDLabel;
        private System.Windows.Forms.ComboBox carIDComboBox;
        private System.Windows.Forms.Button startInsertingButton;
        private System.Windows.Forms.Label indexLabel;
        private System.Windows.Forms.Label successInsertingLabel;
        private System.Windows.Forms.TextBox successInsertingTextBox;
        private System.Windows.Forms.Label failedInsertingLabel;
        private System.Windows.Forms.TextBox failedInsertingTextBox;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label errorCodeLabel;
        private System.Windows.Forms.CheckBox nullAllowanceCheckBox;
        private System.Windows.Forms.ComboBox sensorIDcomboBox;
        private System.Windows.Forms.Label sensorIdLabel;
    }
}

