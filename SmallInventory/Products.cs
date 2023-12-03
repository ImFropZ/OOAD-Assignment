using Newtonsoft.Json;
using System.Data;
using System.Text;
using WinForm.Models;

namespace WinForm
{
    public partial class Products : Form
    {
        private string _selectedId = "";

        public Products()
        {
            InitializeComponent();
            this.Text = "SI Project";
            DisplayProduct();
            Program.RefreshSupplierOptions(cboPSupplier);
            Program.RefreshSupplierOptions(cboPSupplier2);
        }

        private void BtnSupplier_Click(object sender, EventArgs e)
        {
            Suppliers obj = new Suppliers();
            this.Hide();
            obj.Show();
            obj.TopMost = true;
        }

        private void DisplayProduct()
        {
            var ds = new DataSet();
            var dataTable = new DataTable("Products");

            dataTable.Columns.Add("ID", typeof(string));
            dataTable.Columns.Add("Supplier ID", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Price", typeof(decimal));
            dataTable.Columns.Add("Quantity", typeof(int));
            dataTable.Columns.Add("Categories", typeof(string));

            ds.Tables.Add(dataTable);

            foreach (var product in Program.Products)
            {
                dataTable.Rows.Add(product.Id, product.SupplierId, product.Name, product.Price, product.Quantity, product.Categories);
            }

            gridProducts.DataSource = ds;
            gridProducts.DataMember = "Products";
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtPName.Text == "" || txtPPrice.Text == "" || txtPQty.Text == "" || cboPSupplier.SelectedIndex == -1 || txtPCat.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    using var client = Program.CreateHttpClient();
                    {
                        var response = await client.PostAsync($"{Program.URI}/products",
                            new StringContent(JsonConvert.SerializeObject(new ProductCreated()
                            {
                                Name = txtPName.Text,
                                Price = decimal.Parse(txtPPrice.Text),
                                Quantity = int.Parse(txtPQty.Text),
                                Categories = txtPCat.Text,
                                SupplierId = Program.Suppliers[cboPSupplier.SelectedIndex].Id

                            }), Encoding.UTF8, "application/json"));

                        if (!response.IsSuccessStatusCode)
                        {
                            // Log the error message
                            System.Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                            MessageBox.Show("Failed to add product.");
                            return;
                        }
                    }
                    ResetAddFields();

                    await Program.FetchData();
                    DisplayProduct();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ResetAddFields()
        {
            txtPName.Clear();
            txtPPrice.Clear();
            txtPQty.Clear();
            txtPCat.Clear();
            cboPSupplier.SelectedIndex = -1;
        }

        private void ResetModificationFields()
        {
            txtPName2.Clear();
            txtPPrice2.Clear();
            txtPQty2.Clear();
            txtPCat2.Clear();
            cboPSupplier2.SelectedIndex = -1;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ResetAddFields();
        }

        private void EnableModificationFields()
        {
            txtPName2.Enabled = true;
            txtPPrice2.Enabled = true;
            txtPQty2.Enabled = true;
            cboPSupplier2.Enabled = true;
            txtPCat2.Enabled = true;
        }

        private void DisableModificationFields()
        {
            txtPName2.Enabled = false;
            txtPPrice2.Enabled = false;
            txtPQty2.Enabled = false;
            txtPCat2.Enabled = false;
            cboPSupplier2.Enabled = false;
        }

        private async void BtnRemove_Click(object sender, EventArgs e)
        {
            if (_selectedId == "")
            {
                MessageBox.Show("Select a product");
            }
            else
            {
                try
                {
                    using var client = Program.CreateHttpClient();
                    {
                        var response = await client.DeleteAsync($"{Program.URI}/products/{_selectedId}");

                        if (!response.IsSuccessStatusCode)
                        {
                            // Log the error message
                            System.Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                            MessageBox.Show("Failed to remove product.");
                            return;
                        }
                    }

                    await Program.FetchData();
                    ResetModificationFields();
                    DisplayProduct();
                    DisableModificationFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPName2.Text == "" || txtPPrice2.Text == "" || txtPQty2.Text == "" || cboPSupplier2.SelectedIndex == -1 || txtPCat.Text == "")
            {
                MessageBox.Show("Missing information");
            }

            try
            {

                using var client = Program.CreateHttpClient();
                var response = await client.PatchAsync($"{Program.URI}/products/{_selectedId}",
                    new StringContent(JsonConvert.SerializeObject(new ProductUpdated()
                    {
                        SupplierId = Program.Suppliers[cboPSupplier2.SelectedIndex].Id,
                        Name = txtPName2.Text,
                        Price = decimal.Parse(txtPPrice2.Text),
                        Quantity = int.Parse(txtPQty2.Text),
                        Categories = txtPCat2.Text
                    }), Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Failed to update product.");
                    System.Console.ReadKey();
                }

                await Program.FetchData();
                DisplayProduct();
                ResetModificationFields();
                DisableModificationFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnClear2_Click(object sender, EventArgs e)
        {
            ResetModificationFields();
        }

        private void GridProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _selectedId = gridProducts.Rows[e.RowIndex].Cells[0].Value.ToString() ?? "";

                txtPName2.Text = gridProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPPrice2.Text = gridProducts.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPQty2.Text = gridProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPCat2.Text = gridProducts.Rows[e.RowIndex].Cells[5].Value.ToString();
                cboPSupplier2.SelectedIndex = cboPSupplier2.FindStringExact(gridProducts.Rows[e.RowIndex].Cells[1].Value.ToString());

                EnableModificationFields();
            }
        }
    }
}
