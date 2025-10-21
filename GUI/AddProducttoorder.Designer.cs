
namespace GUI
{
    partial class AddProducttoorder
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
            productname = new Label();
            comboBox1 = new ComboBox();
            productcount = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // productname
            // 
            productname.AutoSize = true;
            productname.Location = new Point(654, 155);
            productname.Name = "productname";
            productname.Size = new Size(69, 20);
            productname.TabIndex = 0;
            productname.Text = "שם מוצר:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(489, 155);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // productcount
            // 
            productcount.AutoSize = true;
            productcount.Location = new Point(595, 201);
            productcount.Name = "productcount";
            productcount.Size = new Size(45, 20);
            productcount.TabIndex = 5;
            productcount.Text = "כמות:";
            // 
            // button1
            // 
            button1.Location = new Point(489, 261);
            button1.Name = "button1";
            button1.Size = new Size(234, 73);
            button1.TabIndex = 11;
            button1.Text = "הוספה";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(489, 198);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(95, 27);
            textBox1.TabIndex = 12;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(139, 76);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(251, 364);
            listBox1.TabIndex = 14;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // AddProducttoorder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 509);
            Controls.Add(listBox1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(productcount);
            Controls.Add(comboBox1);
            Controls.Add(productname);
            Name = "AddProducttoorder";
            Text = "AddProducttoorder";
            Load += AddProducttoorder_Load;
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label productname;
        private ComboBox comboBox1;
        private Label productcount;
        private Button button1;
        private TextBox textBox1;
        private ListBox listBox1;
    }
}