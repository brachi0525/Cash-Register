namespace UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            customer = new Button();
            shopKipper = new Button();
            SuspendLayout();
            // 
            // customer
            // 
            customer.Location = new Point(443, 164);
            customer.Name = "customer";
            customer.Size = new Size(153, 73);
            customer.TabIndex = 0;
            customer.Text = "לקוח";
            customer.UseVisualStyleBackColor = true;
            customer.Click += button1_Click;
            // 
            // shopKipper
            // 
            shopKipper.Location = new Point(239, 164);
            shopKipper.Name = "shopKipper";
            shopKipper.Size = new Size(163, 73);
            shopKipper.TabIndex = 1;
            shopKipper.Text = "מוכר";
            shopKipper.UseVisualStyleBackColor = true;
            shopKipper.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(shopKipper);
            Controls.Add(customer);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button customer;
        private Button shopKipper;
    }
}
