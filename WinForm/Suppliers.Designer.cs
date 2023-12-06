namespace WinForm
{
    partial class Suppliers
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
            label10 = new Label();
            btnProduct = new Button();
            label11 = new Label();
            label2 = new Label();
            gridSuppliers = new DataGridView();
            panel2 = new Panel();
            btnClear2 = new Button();
            btnUpdate = new Button();
            label5 = new Label();
            btnRemove = new Button();
            txtVInfo2 = new TextBox();
            label4 = new Label();
            txtVName2 = new TextBox();
            panel1 = new Panel();
            btnClear = new Button();
            btnAdd = new Button();
            label3 = new Label();
            label1 = new Label();
            txtVInfo = new TextBox();
            txtVName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)gridSuppliers).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(431, 403);
            label10.Name = "label10";
            label10.Size = new Size(94, 15);
            label10.TabIndex = 7;
            label10.Text = "Change Supplier";
            // 
            // btnProduct
            // 
            btnProduct.Location = new Point(646, 12);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(122, 23);
            btnProduct.TabIndex = 6;
            btnProduct.Text = "Products";
            btnProduct.UseVisualStyleBackColor = true;
            btnProduct.Click += BtnProduct_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(47, 12);
            label11.Name = "label11";
            label11.Size = new Size(104, 21);
            label11.TabIndex = 8;
            label11.Text = "Supplier List";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 403);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 9;
            label2.Text = "Add Supplier";
            // 
            // gridSuppliers
            // 
            gridSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSuppliers.Location = new Point(30, 41);
            gridSuppliers.Name = "gridSuppliers";
            gridSuppliers.RowHeadersWidth = 51;
            gridSuppliers.RowTemplate.Height = 25;
            gridSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSuppliers.Size = new Size(738, 347);
            gridSuppliers.TabIndex = 5;
            gridSuppliers.CellClick += GridVendors_CellClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnClear2);
            panel2.Controls.Add(btnUpdate);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(btnRemove);
            panel2.Controls.Add(txtVInfo2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtVName2);
            panel2.Location = new Point(414, 411);
            panel2.Name = "panel2";
            panel2.Size = new Size(354, 166);
            panel2.TabIndex = 10;
            // 
            // btnClear2
            // 
            btnClear2.Location = new Point(17, 132);
            btnClear2.Name = "btnClear2";
            btnClear2.Size = new Size(75, 23);
            btnClear2.TabIndex = 7;
            btnClear2.Text = "Clear";
            btnClear2.UseVisualStyleBackColor = true;
            btnClear2.Click += BtnClear2_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(183, 132);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 43);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 3;
            label5.Text = "Contact Info";
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(264, 132);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 7;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += BtnRemove_Click;
            // 
            // txtVInfo2
            // 
            txtVInfo2.Enabled = false;
            txtVInfo2.Location = new Point(118, 40);
            txtVInfo2.Multiline = true;
            txtVInfo2.Name = "txtVInfo2";
            txtVInfo2.Size = new Size(175, 82);
            txtVInfo2.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 14);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 3;
            label4.Text = "Supplier Name";
            // 
            // txtVName2
            // 
            txtVName2.Enabled = false;
            txtVName2.Location = new Point(118, 11);
            txtVName2.Name = "txtVName2";
            txtVName2.Size = new Size(175, 23);
            txtVName2.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtVInfo);
            panel1.Controls.Add(txtVName);
            panel1.Location = new Point(30, 411);
            panel1.Name = "panel1";
            panel1.Size = new Size(354, 166);
            panel1.TabIndex = 11;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(19, 132);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(264, 132);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 43);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 3;
            label3.Text = "Contact Info";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 14);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 3;
            label1.Text = "Supplier Name";
            // 
            // txtVInfo
            // 
            txtVInfo.Location = new Point(118, 40);
            txtVInfo.Multiline = true;
            txtVInfo.Name = "txtVInfo";
            txtVInfo.Size = new Size(175, 82);
            txtVInfo.TabIndex = 2;
            // 
            // txtVName
            // 
            txtVName.Location = new Point(118, 11);
            txtVName.Name = "txtVName";
            txtVName.Size = new Size(175, 23);
            txtVName.TabIndex = 1;
            // 
            // Suppliers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 588);
            Controls.Add(label10);
            Controls.Add(btnProduct);
            Controls.Add(label11);
            Controls.Add(label2);
            Controls.Add(gridSuppliers);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Suppliers";
            Text = "Suppliers";
            ((System.ComponentModel.ISupportInitialize)gridSuppliers).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label10;
        private Button btnProduct;
        private Label label11;
        private Label label2;
        private DataGridView gridSuppliers;
        private Panel panel2;
        private ComboBox cboPCat2;
        private Button btnUpdate;
        private Label label6;
        private Button btnRemove;
        private Label label7;
        private Label label8;
        private TextBox txtPQty2;
        private TextBox txtPPrice2;
        private Label label9;
        private TextBox txtPName2;
        private Panel panel1;
        private Button btnAdd;
        private Label label3;
        private TextBox txtPPrice;
        private Label label1;
        private TextBox txtVName;
        private Label label5;
        private TextBox txtVInfo2;
        private Label label4;
        private TextBox txtVName2;
        private TextBox txtVInfo;
        private Button btnClear2;
        private Button btnClear;
    }
}