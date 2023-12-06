using Newtonsoft.Json;
using WinForm.Models;

namespace WinForm
{
    internal static class Program
    {
        public static string URI = "https://localhost:44358/api";

        public static List<Product> Products;
        public static List<Supplier> Suppliers;

        public static HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            var client = new HttpClient(handler);
            return client;
        }

        static async Task<List<Product>> GetProducts(string apiUrl)
        {
            using var client = CreateHttpClient();
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<Result<List<Product>>>(jsonString);

                // Assuming ApiResponse class has a Data property of type List<Product>
                return apiResponse?.Data ?? new List<Product>();
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
            }
        }

        static async Task<List<Supplier>> GetSuppliers(string apiUrl)
        {
            using var client = CreateHttpClient();
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<Result<List<Supplier>>>(jsonString);

                // Assuming ApiResponse class has a Data property of type List<Product>
                return apiResponse?.Data ?? new List<Supplier>();
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
            }
        }


        public static async Task FetchData()
        {
            var products = await GetProducts($"{URI}/products");
            var suppliers = await GetSuppliers($"{URI}/suppliers");

            Products = products;
            Suppliers = suppliers;
        }

        public static void RefreshSupplierOptions(ComboBox cboPSupplier)
        {
            cboPSupplier.Items.Clear();
            cboPSupplier.Items.AddRange(Suppliers.Select(s => s.Name).ToArray());
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FetchData().Wait();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}