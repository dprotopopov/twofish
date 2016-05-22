namespace twofish
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonEncrypt = new System.Windows.Forms.RadioButton();
            this.radioButtonDecrypt = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonSharp = new System.Windows.Forms.RadioButton();
            this.radioButtonCpp = new System.Windows.Forms.RadioButton();
            this.textBoxIV = new System.Windows.Forms.TextBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.buttonInput = new System.Windows.Forms.Button();
            this.buttonOutput = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonRun = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButtonECB = new System.Windows.Forms.RadioButton();
            this.radioButtonCBC = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "IV (HEX)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Key (HEX)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Direction";
            // 
            // radioButtonEncrypt
            // 
            this.radioButtonEncrypt.AutoSize = true;
            this.radioButtonEncrypt.Checked = true;
            this.radioButtonEncrypt.Location = new System.Drawing.Point(21, 25);
            this.radioButtonEncrypt.Name = "radioButtonEncrypt";
            this.radioButtonEncrypt.Size = new System.Drawing.Size(88, 24);
            this.radioButtonEncrypt.TabIndex = 3;
            this.radioButtonEncrypt.TabStop = true;
            this.radioButtonEncrypt.Text = "Encrypt";
            this.radioButtonEncrypt.UseVisualStyleBackColor = true;
            this.radioButtonEncrypt.CheckedChanged += new System.EventHandler(this.UpdateCommandBox);
            // 
            // radioButtonDecrypt
            // 
            this.radioButtonDecrypt.AutoSize = true;
            this.radioButtonDecrypt.Location = new System.Drawing.Point(125, 23);
            this.radioButtonDecrypt.Name = "radioButtonDecrypt";
            this.radioButtonDecrypt.Size = new System.Drawing.Size(89, 24);
            this.radioButtonDecrypt.TabIndex = 4;
            this.radioButtonDecrypt.Text = "Decrypt";
            this.radioButtonDecrypt.UseVisualStyleBackColor = true;
            this.radioButtonDecrypt.CheckedChanged += new System.EventHandler(this.UpdateCommandBox);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tools";
            // 
            // radioButtonSharp
            // 
            this.radioButtonSharp.AutoSize = true;
            this.radioButtonSharp.Checked = true;
            this.radioButtonSharp.Location = new System.Drawing.Point(21, 25);
            this.radioButtonSharp.Name = "radioButtonSharp";
            this.radioButtonSharp.Size = new System.Drawing.Size(54, 24);
            this.radioButtonSharp.TabIndex = 6;
            this.radioButtonSharp.TabStop = true;
            this.radioButtonSharp.Text = "C#";
            this.radioButtonSharp.UseVisualStyleBackColor = true;
            this.radioButtonSharp.CheckedChanged += new System.EventHandler(this.UpdateCommandBox);
            // 
            // radioButtonCpp
            // 
            this.radioButtonCpp.AutoSize = true;
            this.radioButtonCpp.Location = new System.Drawing.Point(125, 25);
            this.radioButtonCpp.Name = "radioButtonCpp";
            this.radioButtonCpp.Size = new System.Drawing.Size(63, 24);
            this.radioButtonCpp.TabIndex = 7;
            this.radioButtonCpp.Text = "C++";
            this.radioButtonCpp.UseVisualStyleBackColor = true;
            this.radioButtonCpp.CheckedChanged += new System.EventHandler(this.UpdateCommandBox);
            // 
            // textBoxIV
            // 
            this.textBoxIV.Location = new System.Drawing.Point(243, 87);
            this.textBoxIV.Name = "textBoxIV";
            this.textBoxIV.Size = new System.Drawing.Size(496, 26);
            this.textBoxIV.TabIndex = 8;
            this.textBoxIV.Text = "00000000000000000000000000000000";
            this.textBoxIV.TextChanged += new System.EventHandler(this.UpdateCommandBox);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(243, 126);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(496, 26);
            this.textBoxKey.TabIndex = 9;
            this.textBoxKey.Text = "00000000000000000000000000000000";
            this.textBoxKey.TextChanged += new System.EventHandler(this.UpdateCommandBox);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Input file";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Output file";
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(243, 422);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(496, 26);
            this.inputBox.TabIndex = 12;
            this.inputBox.Text = "input.txt";
            this.inputBox.TextChanged += new System.EventHandler(this.UpdateCommandBox);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(243, 462);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(496, 26);
            this.outputBox.TabIndex = 13;
            this.outputBox.Text = "output.txt";
            this.outputBox.TextChanged += new System.EventHandler(this.UpdateCommandBox);
            // 
            // buttonInput
            // 
            this.buttonInput.Location = new System.Drawing.Point(773, 418);
            this.buttonInput.Name = "buttonInput";
            this.buttonInput.Size = new System.Drawing.Size(104, 34);
            this.buttonInput.TabIndex = 14;
            this.buttonInput.Text = "Browse...";
            this.buttonInput.UseVisualStyleBackColor = true;
            this.buttonInput.Click += new System.EventHandler(this.buttonInput_Click);
            // 
            // buttonOutput
            // 
            this.buttonOutput.Location = new System.Drawing.Point(773, 454);
            this.buttonOutput.Name = "buttonOutput";
            this.buttonOutput.Size = new System.Drawing.Size(104, 34);
            this.buttonOutput.TabIndex = 15;
            this.buttonOutput.Text = "Browse...";
            this.buttonOutput.UseVisualStyleBackColor = true;
            this.buttonOutput.Click += new System.EventHandler(this.buttonOutput_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // commandBox
            // 
            this.commandBox.Location = new System.Drawing.Point(243, 508);
            this.commandBox.Multiline = true;
            this.commandBox.Name = "commandBox";
            this.commandBox.ReadOnly = true;
            this.commandBox.Size = new System.Drawing.Size(496, 91);
            this.commandBox.TabIndex = 16;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(773, 508);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(104, 33);
            this.buttonRun.TabIndex = 17;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Mode";
            // 
            // radioButtonECB
            // 
            this.radioButtonECB.AutoSize = true;
            this.radioButtonECB.Checked = true;
            this.radioButtonECB.Location = new System.Drawing.Point(21, 22);
            this.radioButtonECB.Name = "radioButtonECB";
            this.radioButtonECB.Size = new System.Drawing.Size(67, 24);
            this.radioButtonECB.TabIndex = 19;
            this.radioButtonECB.TabStop = true;
            this.radioButtonECB.Text = "ECB";
            this.radioButtonECB.UseVisualStyleBackColor = true;
            this.radioButtonECB.CheckedChanged += new System.EventHandler(this.UpdateCommandBox);
            // 
            // radioButtonCBC
            // 
            this.radioButtonCBC.AutoSize = true;
            this.radioButtonCBC.Location = new System.Drawing.Point(125, 22);
            this.radioButtonCBC.Name = "radioButtonCBC";
            this.radioButtonCBC.Size = new System.Drawing.Size(67, 24);
            this.radioButtonCBC.TabIndex = 20;
            this.radioButtonCBC.Text = "CBC";
            this.radioButtonCBC.UseVisualStyleBackColor = true;
            this.radioButtonCBC.CheckedChanged += new System.EventHandler(this.UpdateCommandBox);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonECB);
            this.groupBox1.Controls.Add(this.radioButtonCBC);
            this.groupBox1.Location = new System.Drawing.Point(243, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 59);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonDecrypt);
            this.groupBox2.Controls.Add(this.radioButtonEncrypt);
            this.groupBox2.Location = new System.Drawing.Point(243, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 64);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonCpp);
            this.groupBox3.Controls.Add(this.radioButtonSharp);
            this.groupBox3.Location = new System.Drawing.Point(243, 290);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(496, 61);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "128",
            "192",
            "256"});
            this.comboBox1.Location = new System.Drawing.Point(243, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 24;
            this.comboBox1.Text = "128";
            this.comboBox1.TextChanged += new System.EventHandler(this.UpdateCommandBox);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(105, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "Key size";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 66);
            this.button1.TabIndex = 26;
            this.button1.Text = "Swap";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 372);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "Buffer (16 bytes block)";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(243, 370);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 26);
            this.numericUpDown1.TabIndex = 28;
            this.numericUpDown1.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.UpdateCommandBox);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 669);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.commandBox);
            this.Controls.Add(this.buttonOutput);
            this.Controls.Add(this.buttonInput);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.textBoxIV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "twofish";
            this.Load += new System.EventHandler(this.UpdateCommandBox);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonEncrypt;
        private System.Windows.Forms.RadioButton radioButtonDecrypt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonSharp;
        private System.Windows.Forms.RadioButton radioButtonCpp;
        private System.Windows.Forms.TextBox textBoxIV;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Button buttonInput;
        private System.Windows.Forms.Button buttonOutput;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButtonECB;
        private System.Windows.Forms.RadioButton radioButtonCBC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

