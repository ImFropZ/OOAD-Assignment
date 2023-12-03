namespace WinForm
{
    partial class Products
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
            gridProducts = new DataGridView();
            btnAdd = new Button();
            txtPName = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            label12 = new Label();
            txtPCat = new TextBox();
            cboPSupplier = new ComboBox();
            btnClear = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtPQty = new TextBox();
            txtPPrice = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            txtPCat2 = new TextBox();
            label14 = new Label();
            btnUpdate = new Button();
            btnRemove = new Button();
            btnClear2 = new Button();
            cboPSupplier2 = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtPQty2 = new TextBox();
            txtPPrice2 = new TextBox();
            label9 = new Label();
            txtPName2 = new TextBox();
            label10 = new Label();
            btnVendor = new Button();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)gridProducts).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // gridProducts
            // 
            gridProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProducts.Location = new Point(29, 37);
            gridProducts.Name = "gridProducts";
            gridProducts.RowHeadersWidth = 51;
            gridProducts.RowTemplate.Height = 25;
            gridProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridProducts.Size = new Size(738, 297);
            gridProducts.TabIndex = 0;
            gridProducts.CellClick += GridProducts_CellClick;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAdd.Location = new Point(264, 166);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // txtPName
            // 
            txtPName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPName.Location = new Point(118, 45);
            txtPName.Name = "txtPName";
            txtPName.Size = new Size(175, 23);
            txtPName.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(17, 48);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 3;
            label1.Text = "Product name";
            // 
            // panel1
            // 
            panel1.Controls.Add(label12);
            panel1.Controls.Add(txtPCat);
            panel1.Controls.Add(cboPSupplier);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtPQty);
            panel1.Controls.Add(txtPPrice);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtPName);
            panel1.Location = new Point(29, 373);
            panel1.Name = "panel1";
            panel1.Size = new Size(354, 200);
            panel1.TabIndex = 4;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(17, 18);
            label12.Name = "label12";
            label12.Size = new Size(50, 15);
            label12.TabIndex = 7;
            label12.Text = "Supplier";
            // 
            // txtPCat
            // 
            txtPCat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPCat.Location = new Point(118, 137);
            txtPCat.Name = "txtPCat";
            txtPCat.Size = new Size(175, 23);
            txtPCat.TabIndex = 6;
            // 
            // cboPSupplier
            // 
            cboPSupplier.FormattingEnabled = true;
            cboPSupplier.Items.AddRange(new object[] { "Appliance", "Beverage", "Clothes", "Electronic", "Electric", "Food", "" });
            cboPSupplier.Location = new Point(118, 13);
            cboPSupplier.Name = "cboPSupplier";
            cboPSupplier.Size = new Size(175, 23);
            cboPSupplier.TabIndex = 4;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnClear.Location = new Point(17, 166);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(17, 136);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 3;
            label5.Text = "Category";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(17, 107);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 3;
            label4.Text = "Quantity";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(17, 77);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 3;
            label3.Text = "Price";
            // 
            // txtPQty
            // 
            txtPQty.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPQty.Location = new Point(118, 104);
            txtPQty.Name = "txtPQty";
            txtPQty.Size = new Size(175, 23);
            txtPQty.TabIndex = 3;
            // 
            // txtPPrice
            // 
            txtPPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPPrice.Location = new Point(118, 74);
            txtPPrice.Name = "txtPPrice";
            txtPPrice.Size = new Size(175, 23);
            txtPPrice.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 364);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 3;
            label2.Text = "Add Product";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtPCat2);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(btnUpdate);
            panel2.Controls.Add(btnRemove);
            panel2.Controls.Add(btnClear2);
            panel2.Controls.Add(cboPSupplier2);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtPQty2);
            panel2.Controls.Add(txtPPrice2);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtPName2);
            panel2.Location = new Point(413, 373);
            panel2.Name = "panel2";
            panel2.Size = new Size(354, 200);
            panel2.TabIndex = 4;
            // 
            // txtPCat2
            // 
            txtPCat2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPCat2.Enabled = false;
            txtPCat2.Location = new Point(116, 136);
            txtPCat2.Name = "txtPCat2";
            txtPCat2.Size = new Size(175, 23);
            txtPCat2.TabIndex = 14;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Location = new Point(17, 20);
            label14.Name = "label14";
            label14.Size = new Size(50, 15);
            label14.TabIndex = 13;
            label14.Text = "Supplier";
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnUpdate.Location = new Point(182, 166);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRemove.Location = new Point(263, 166);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 11;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += BtnRemove_Click;
            // 
            // btnClear2
            // 
            btnClear2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnClear2.Location = new Point(17, 166);
            btnClear2.Name = "btnClear2";
            btnClear2.Size = new Size(75, 23);
            btnClear2.TabIndex = 5;
            btnClear2.Text = "Clear";
            btnClear2.UseVisualStyleBackColor = true;
            btnClear2.Click += BtnClear2_Click;
            // 
            // cboPSupplier2
            // 
            cboPSupplier2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cboPSupplier2.Enabled = false;
            cboPSupplier2.FormattingEnabled = true;
            cboPSupplier2.Items.AddRange(new object[] { "Appliance", "Beverage", "Clothes", "Electronic", "Electric", "Food", "" });
            cboPSupplier2.Location = new Point(116, 12);
            cboPSupplier2.Name = "cboPSupplier2";
            cboPSupplier2.Size = new Size(175, 23);
            cboPSupplier2.TabIndex = 9;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(17, 136);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 3;
            label6.Text = "Category";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(17, 107);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 3;
            label7.Text = "Quantity";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(17, 77);
            label8.Name = "label8";
            label8.Size = new Size(33, 15);
            label8.TabIndex = 3;
            label8.Text = "Price";
            // 
            // txtPQty2
            // 
            txtPQty2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPQty2.Enabled = false;
            txtPQty2.Location = new Point(116, 107);
            txtPQty2.Name = "txtPQty2";
            txtPQty2.Size = new Size(175, 23);
            txtPQty2.TabIndex = 8;
            // 
            // txtPPrice2
            // 
            txtPPrice2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPPrice2.Enabled = false;
            txtPPrice2.Location = new Point(116, 74);
            txtPPrice2.Name = "txtPPrice2";
            txtPPrice2.Size = new Size(175, 23);
            txtPPrice2.TabIndex = 7;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(17, 48);
            label9.Name = "label9";
            label9.Size = new Size(82, 15);
            label9.TabIndex = 3;
            label9.Text = "Product name";
            // 
            // txtPName2
            // 
            txtPName2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPName2.Enabled = false;
            txtPName2.Location = new Point(116, 45);
            txtPName2.Name = "txtPName2";
            txtPName2.Size = new Size(175, 23);
            txtPName2.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(428, 364);
            label10.Name = "label10";
            label10.Size = new Size(93, 15);
            label10.TabIndex = 3;
            label10.Text = "Change Product";
            // 
            // btnVendor
            // 
            btnVendor.Location = new Point(645, 8);
            btnVendor.Name = "btnVendor";
            btnVendor.Size = new Size(122, 23);
            btnVendor.TabIndex = 1;
            btnVendor.Text = "Vendor";
            btnVendor.UseVisualStyleBackColor = true;
            btnVendor.Click += BtnSupplier_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(46, 8);
            label11.Name = "label11";
            label11.Size = new Size(100, 21);
            label11.TabIndex = 3;
            label11.Text = "Product List";
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 588);
            Controls.Add(label10);
            Controls.Add(btnVendor);
            Controls.Add(label11);
            Controls.Add(label2);
            Controls.Add(gridProducts);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Products";
            Text = "Products";
            ((System.ComponentModel.ISupportInitialize)gridProducts).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridProducts;
        private Button btnAdd;
        private TextBox txtPName;
        private Label label1;
        private Panel panel1;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtPQty;
        private TextBox txtPPrice;
        private Label label2;
        private Panel panel2;
        private Label label7;
        private Label label8;
        private TextBox txtPQty2;
        private TextBox txtPPrice2;
        private Label label9;
        private TextBox txtPName2;
        private Label label10;
        private ComboBox cboPSupplier;
        private Label label6;
        private ComboBox cboPSupplier2;
        private Button btnVendor;
        private Label label11;
        private Button btnClear;
        private Button btnUpdate;
        private Button btnRemove;
        private Button btnClear2;
        private Label label12;
        private TextBox txtPCat;
        private TextBox txtPCat2;
        private Label label14;
    }
}