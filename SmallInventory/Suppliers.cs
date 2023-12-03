using Newtonsoft.Json;
using System.Data;
using System.Text;
using WinForm.Models;

namespace WinForm
{
    public partial class Suppliers : Form
    {
        private string _selectedId = "";

        public Suppliers()
        {
            InitializeComponent();
            this.Text = "SI Project";
            DisplaySupplier();
        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            var obj = new Products();
            this.Hide();
            obj.Show();
            obj.TopMost = true;
        }

        private void DisplaySupplier()
        {
            var ds = new DataSet();
            var dataTable = new DataTable("Suppliers");

            dataTable.Columns.Add("ID", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Contact Info", typeof(string));

            ds.Tables.Add(dataTable);

            foreach (var supplier in Program.Suppliers)
            {
                dataTable.Rows.Add(supplier.Id, supplier.Name, supplier.ContactInformation);
            }

            gridSuppliers.DataSource = ds;
            gridSuppliers.DataMember = "Suppliers";
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtVName.Text == "" || txtVInfo.Text == "")
            {
                MessageBox.Show("Missing information");
            }

            try
            {
                using var client = Program.CreateHttpClient();
                {
                    var response = await client.PostAsync($"{Program.URI}/suppliers",
                        new StringContent(JsonConvert.SerializeObject(new SupplierCreated()
                        {
                            Name = txtVName.Text,
                            ContactInformation = txtVInfo.Text
                        }), Encoding.UTF8, "application/json"));

                    if (!response.IsSuccessStatusCode)
                    {
                        // Log the error message
                        System.Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                        MessageBox.Show("Failed to add supplier.");
                        return;
                    }
                }
                ResetAddFields();

                await Program.FetchData();
                DisplaySupplier();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetAddFields()
        {
            txtVName.Clear();
            txtVInfo.Clear();
        }

        private void ResetModificationFields()
        {
            txtVName2.Clear();
            txtVInfo2.Clear();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ResetAddFields();
        }

        private void EnableModificationFields()
        {
            txtVName2.Enabled = true;
            txtVInfo2.Enabled = true;
        }

        private void DisableModificationFields()
        {
            txtVName2.Enabled = false;
            txtVInfo2.Enabled = false;
        }

        private async void BtnRemove_Click(object sender, EventArgs e)
        {
            if (_selectedId == "")
            {
                MessageBox.Show("Select a supplier");
            }
            else
            {
                try
                {
                    using var client = Program.CreateHttpClient();
                    {
                        var response = await client.DeleteAsync($"{Program.URI}/suppliers/{_selectedId}");

                        if (!response.IsSuccessStatusCode)
                        {
                            // Log the error message
                            System.Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                            MessageBox.Show("Failed to remove supplier.");
                            return;
                        }
                    }

                    await Program.FetchData();
                    ResetModificationFields();
                    DisplaySupplier();
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
            if (_selectedId == "")
            {
                MessageBox.Show("Select a supplier");
            }

            if (txtVName2.Text == "" || txtVInfo2.Text == "")
            {
                MessageBox.Show("Missing information");
            }

            else
            {
                try
                {
                    using var client = Program.CreateHttpClient();
                    var response = await client.PatchAsync($"{Program.URI}/suppliers/{_selectedId}",
                        new StringContent(JsonConvert.SerializeObject(new SupplierUpdated()
                        {
                            Name = txtVName2.Text,
                            ContactInformation = txtVInfo2.Text
                        }), Encoding.UTF8, "application/json"));

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Failed to update supplier.");
                        System.Console.ReadKey();
                    }

                    await Program.FetchData();
                    DisplaySupplier();
                    ResetModificationFields();
                    DisableModificationFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnClear2_Click(object sender, EventArgs e)
        {
            ResetModificationFields();
        }

        private void GridVendors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _selectedId = gridSuppliers.Rows[e.RowIndex].Cells[0].Value.ToString() ?? "";

                txtVName2.Text = gridSuppliers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtVInfo2.Text = gridSuppliers.Rows[e.RowIndex].Cells[2].Value.ToString();

                EnableModificationFields();
            }
        }
    }
}
