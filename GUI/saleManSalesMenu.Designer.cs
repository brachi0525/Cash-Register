namespace GUI
{
    partial class saleManSalesMenu
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
            addSaleButton = new Button();
            updateButton = new Button();
            deletebutton = new Button();
            saleList = new ListBox();
            SuspendLayout();
            // 
            // addSaleButton
            // 
            addSaleButton.Location = new Point(559, 79);
            addSaleButton.Name = "addSaleButton";
            addSaleButton.Size = new Size(169, 60);
            addSaleButton.TabIndex = 4;
            addSaleButton.Text = "הוספת מבצע";
            addSaleButton.UseVisualStyleBackColor = true;
            addSaleButton.Click += addProductButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(559, 282);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(169, 66);
            updateButton.TabIndex = 7;
            updateButton.Text = "עדכון מבצע";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // deletebutton
            // 
            deletebutton.Location = new Point(559, 177);
            deletebutton.Name = "deletebutton";
            deletebutton.Size = new Size(169, 67);
            deletebutton.TabIndex = 6;
            deletebutton.Text = "מחיקת מבצע";
            deletebutton.UseVisualStyleBackColor = true;
            deletebutton.Click += deletebutton_Click;
            // 
            // saleList
            // 
            saleList.FormattingEnabled = true;
            saleList.ItemHeight = 20;
            saleList.Location = new Point(27, 12);
            saleList.Name = "saleList";
            saleList.Size = new Size(456, 424);
            saleList.TabIndex = 5;
            saleList.SelectedIndexChanged += productList_SelectedIndexChanged;
            // 
            // saleManSalesMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(updateButton);
            Controls.Add(deletebutton);
            Controls.Add(saleList);
            Controls.Add(addSaleButton);
            Name = "saleManSalesMenu";
            Text = "saleManSalesMenu";
            Load += saleManSalesMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button addSaleButton;
        private Button updateButton;
        private Button deletebutton;
        private ListBox saleList;
    }
}