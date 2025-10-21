namespace GUI
{
    partial class saleManUpdeteSale
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
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            checkBox1 = new CheckBox();
            monthCalendar2 = new MonthCalendar();
            monthCalendar1 = new MonthCalendar();
            label5 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.Location = new Point(417, 225);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 17;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(417, 192);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 16;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(510, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 14;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(667, 28);
            label4.Name = "label4";
            label4.Size = new Size(121, 20);
            label4.TabIndex = 13;
            label4.Text = "בחר מבצע לעדכון";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(560, 229);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 12;
            label3.Text = "כמות";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(560, 192);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 11;
            label2.Text = "מחיר";
            // 
            // button1
            // 
            button1.Location = new Point(371, 326);
            button1.Name = "button1";
            button1.Size = new Size(348, 112);
            button1.TabIndex = 9;
            button1.Text = "עדכן";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(520, 270);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.Yes;
            checkBox1.Size = new Size(71, 24);
            checkBox1.TabIndex = 18;
            checkBox1.Text = "IsClub";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // monthCalendar2
            // 
            monthCalendar2.Location = new Point(6, 5);
            monthCalendar2.Name = "monthCalendar2";
            monthCalendar2.TabIndex = 22;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(6, 225);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(294, 9);
            label5.Name = "label5";
            label5.Size = new Size(107, 20);
            label5.TabIndex = 19;
            label5.Text = "DateBeginSale";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(285, 242);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 20;
            label1.Text = "DateEndSale";
            label1.TextAlign = ContentAlignment.TopRight;
            label1.Click += label1_Click;
            // 
            // saleManUpdeteSale
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(monthCalendar2);
            Controls.Add(monthCalendar1);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Name = "saleManUpdeteSale";
            Text = "saleManUpdeteSale";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button button1;
        private CheckBox checkBox1;
        private MonthCalendar monthCalendar2;
        private MonthCalendar monthCalendar1;
        private Label label5;
        private Label label1;
    }
}