namespace GUI
{
    partial class salesManProductMenu
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
            addProductButton = new Button();
            productList = new ListBox();
            deletebutton = new Button();
            updateButton = new Button();
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // addProductButton
            // 
            addProductButton.Location = new Point(676, 58);
            addProductButton.Name = "addProductButton";
            addProductButton.Size = new Size(169, 60);
            addProductButton.TabIndex = 0;
            addProductButton.Text = "הוספת מוצר";
            addProductButton.UseVisualStyleBackColor = true;
            addProductButton.Click += button1_Click;
            // 
            // productList
            // 
            productList.FormattingEnabled = true;
            productList.ItemHeight = 20;
            productList.Location = new Point(21, 12);
            productList.Name = "productList";
            productList.Size = new Size(456, 424);
            productList.TabIndex = 1;
            productList.SelectedIndexChanged += productList_SelectedIndexChanged;
            // 
            // deletebutton
            // 
            deletebutton.Location = new Point(676, 156);
            deletebutton.Name = "deletebutton";
            deletebutton.Size = new Size(169, 67);
            deletebutton.TabIndex = 2;
            deletebutton.Text = "מחיקת מוצר";
            deletebutton.UseVisualStyleBackColor = true;
            deletebutton.Click += deletebutton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(676, 261);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(169, 66);
            updateButton.TabIndex = 3;
            updateButton.Text = "עדכון מוצר";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(676, 399);
            button1.Name = "button1";
            button1.Size = new Size(174, 60);
            button1.TabIndex = 4;
            button1.Text = "חיפוש מוצר לפי id";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(790, 361);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 5;
            label1.Text = "הכנס id";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(676, 358);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(108, 27);
            textBox1.TabIndex = 6;
            // 
            // salesManProductMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 471);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(updateButton);
            Controls.Add(deletebutton);
            Controls.Add(productList);
            Controls.Add(addProductButton);
            Name = "salesManProductMenu";
            Text = "salesMan";
            Load += salesManProductMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button addProductButton;
        private ListBox productList;
        private Button deletebutton;
        private Button updateButton;
        private Button button1;
        private Label label1;
        private TextBox textBox1;
    }
}