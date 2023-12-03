namespace WinForm
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
            label1 = new Label();
            BtnProduct = new Button();
            BtnVendor = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(42, 9);
            label1.Name = "label1";
            label1.Size = new Size(320, 37);
            label1.TabIndex = 0;
            label1.Text = "Small Inventory System";
            // 
            // BtnProduct
            // 
            BtnProduct.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            BtnProduct.Location = new Point(137, 67);
            BtnProduct.Name = "BtnProduct";
            BtnProduct.Size = new Size(127, 53);
            BtnProduct.TabIndex = 1;
            BtnProduct.Text = "Product";
            BtnProduct.UseVisualStyleBackColor = true;
            BtnProduct.Click += BtnProduct_Click;
            // 
            // BtnVendor
            // 
            BtnVendor.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            BtnVendor.Location = new Point(137, 126);
            BtnVendor.Name = "BtnVendor";
            BtnVendor.Size = new Size(127, 53);
            BtnVendor.TabIndex = 1;
            BtnVendor.Text = "Supplier";
            BtnVendor.UseVisualStyleBackColor = true;
            BtnVendor.Click += BtnSupplier_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 206);
            Controls.Add(BtnVendor);
            Controls.Add(BtnProduct);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button BtnProduct;
        private Button BtnVendor;
    }
}