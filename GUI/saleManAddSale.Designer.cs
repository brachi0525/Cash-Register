namespace GUI
{
    partial class saleManAddSale
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
            button1 = new Button();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            checkBox1 = new CheckBox();
            monthCalendar1 = new MonthCalendar();
            label5 = new Label();
            monthCalendar2 = new MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(294, 382);
            button1.Name = "button1";
            button1.Size = new Size(289, 75);
            button1.TabIndex = 13;
            button1.Text = "הוספה";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(434, 315);
            numericUpDown2.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(61, 27);
            numericUpDown2.TabIndex = 10;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(266, 315);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(61, 27);
            numericUpDown1.TabIndex = 11;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // textBox1
            // 
            textBox1.Location = new Point(597, 314);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(57, 27);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(514, 321);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 5;
            label3.Text = "Count";
            label3.TextAlign = ContentAlignment.TopRight;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(344, 321);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 6;
            label4.Text = "cost";
            label4.TextAlign = ContentAlignment.TopRight;
            label4.Click += label4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(207, 21);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 7;
            label2.Text = "DateEndSale";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(660, 318);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 8;
            label1.Text = "ProductID";
            label1.Click += label1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(138, 317);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.Yes;
            checkBox1.Size = new Size(71, 24);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "IsClub";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(118, 50);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(569, 21);
            label5.Name = "label5";
            label5.Size = new Size(107, 20);
            label5.TabIndex = 7;
            label5.Text = "DateBeginSale";
            label5.TextAlign = ContentAlignment.TopRight;
            label5.Click += label5_Click;
            // 
            // monthCalendar2
            // 
            monthCalendar2.Location = new Point(479, 50);
            monthCalendar2.Name = "monthCalendar2";
            monthCalendar2.TabIndex = 15;
            monthCalendar2.DateChanged += monthCalendar2_DateChanged;
            // 
            // saleManAddSale
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 511);
            Controls.Add(monthCalendar2);
            Controls.Add(monthCalendar1);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "saleManAddSale";
            Text = "saleManAddSale";
            Load += saleManAddSale_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
        private CheckBox checkBox1;
        private MonthCalendar monthCalendar1;
        private Label label5;
        private MonthCalendar monthCalendar2;
    }
}