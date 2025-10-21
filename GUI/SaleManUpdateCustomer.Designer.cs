namespace GUI
{
    partial class SaleManUpdateCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBox1;
        private TextBox textBoxName;
        private TextBox textBoxPhone;
        private TextBox textBox3;
        private Button buttonUpdate;
        private Label labelName;
        private Label labelPhone;
        private Label labelAdress;
        private Label labelChooseCustomer;

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
            comboBox1 = new ComboBox();
            textBoxName = new TextBox();
            textBoxPhone = new TextBox();
            textBox3 = new TextBox();
            buttonUpdate = new Button();
            labelChooseCustomer = new Label();
            labelName = new Label();
            labelPhone = new Label();
            labelAdress = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(160, 30);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(160, 77);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(200, 27);
            textBoxName.TabIndex = 1;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(160, 117);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(200, 27);
            textBoxPhone.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(160, 157);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(200, 27);
            textBox3.TabIndex = 3;
            textBox3.TextChanged += textBoxEmail_TextChanged;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(160, 200);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(100, 30);
            buttonUpdate.TabIndex = 5;
            buttonUpdate.Text = "עדכן לקוח";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // labelChooseCustomer
            // 
            labelChooseCustomer.AutoSize = true;
            labelChooseCustomer.Location = new Point(40, 33);
            labelChooseCustomer.Name = "labelChooseCustomer";
            labelChooseCustomer.Size = new Size(119, 20);
            labelChooseCustomer.TabIndex = 1;
            labelChooseCustomer.Text = "בחר לקוח לעדכון:";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(40, 80);
            labelName.Name = "labelName";
            labelName.Size = new Size(31, 20);
            labelName.TabIndex = 2;
            labelName.Text = "שם";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(40, 120);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(47, 20);
            labelPhone.TabIndex = 3;
            labelPhone.Text = "טלפון:";
            // 
            // labelAdress
            // 
            labelAdress.AutoSize = true;
            labelAdress.Location = new Point(40, 160);
            labelAdress.Name = "labelAdress";
            labelAdress.Size = new Size(52, 20);
            labelAdress.TabIndex = 4;
            labelAdress.Text = "כתובת";
            labelAdress.Click += labelEmail_Click;
            // 
            // SaleManUpdateCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 260);
            Controls.Add(comboBox1);
            Controls.Add(labelChooseCustomer);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            Controls.Add(labelPhone);
            Controls.Add(textBoxPhone);
            Controls.Add(labelAdress);
            Controls.Add(textBox3);
            Controls.Add(buttonUpdate);
            Name = "SaleManUpdateCustomer";
            Text = "עדכון לקוח";
            Load += SaleManUpdateCustomer_Load_1;
            ResumeLayout(false);
            PerformLayout();
            #endregion

        }
    }
}


