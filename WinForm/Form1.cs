namespace WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "SI Project";
        }
        private void BtnProduct_Click(object sender, EventArgs e)
        {
            var obj = new Products();
            this.Hide();
            obj.Show();
            obj.TopMost = true;
        }

        private void BtnSupplier_Click(object sender, EventArgs e)
        {
            var obj = new Suppliers();
            this.Hide();
            obj.Show();
            obj.TopMost = true;
        }
    }
}