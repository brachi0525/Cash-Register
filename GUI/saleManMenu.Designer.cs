namespace GUI
{
    partial class saleManMenu
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
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(328, 78);
            button1.Name = "button1";
            button1.Size = new Size(138, 78);
            button1.TabIndex = 0;
            button1.Text = "טיפול במוצרים";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(328, 191);
            button2.Name = "button2";
            button2.Size = new Size(138, 78);
            button2.TabIndex = 0;
            button2.Text = "טיפול במבצעים";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(328, 298);
            button3.Name = "button3";
            button3.Size = new Size(138, 78);
            button3.TabIndex = 0;
            button3.Text = "טיפול בלקוחות";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // saleManMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 473);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "saleManMenu";
            Text = "saleManMenu";
            Load += saleManMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
    }
}