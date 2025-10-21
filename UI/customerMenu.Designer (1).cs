namespace UI
{
    partial class customerMenu
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
            addproduct = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // addproduct
            // 
            addproduct.Location = new Point(626, 67);
            addproduct.Name = "addproduct";
            addproduct.Size = new Size(123, 63);
            addproduct.TabIndex = 0;
            addproduct.Text = "הוספת מוצר";
            addproduct.UseVisualStyleBackColor = true;
            addproduct.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(626, 149);
            button2.Name = "button2";
            button2.Size = new Size(123, 63);
            button2.TabIndex = 1;
            button2.Text = "מחיקת מוצר";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(626, 243);
            button3.Name = "button3";
            button3.Size = new Size(123, 63);
            button3.TabIndex = 2;
            button3.Text = "עדכון מוצר";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(626, 333);
            button4.Name = "button4";
            button4.Size = new Size(123, 63);
            button4.TabIndex = 3;
            button4.Text = "לסיום הזמנה";
            button4.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(132, 103);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 94);
            listBox1.TabIndex = 4;
            // 
            // customerMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(addproduct);
            Name = "customerMenu";
            Text = "customerMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button addproduct;
        private Button button2;
        private Button button3;
        private Button button4;
        private ListBox listBox1;
    }
}