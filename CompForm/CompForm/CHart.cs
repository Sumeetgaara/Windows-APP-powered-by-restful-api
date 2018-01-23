using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CompForm
{
    public partial class CHart : Form
    {
        
        public CHart()
        {
            InitializeComponent();

        }

        

        private  void button5_Click(object sender, EventArgs e)
        {
            //string value = tbVisualise.Text.ToString();
            //string URI = "http://localhost:54513/api/stock?symbol=" + value;
            //GetStockInformation(URI, true);
            

        }
        public async void GetStockInformation(string url, Boolean flag)
        {
            List<Stock> stockList = new List<Stock>();
            List<Stock> dupList = new List<Stock>();

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var stockJson = await response.Content.ReadAsStringAsync();

                        stockList = JsonConvert.DeserializeObject<Stock[]>(stockJson).ToList();
                        if (flag == true)
                        {
                            chart1.DataSource = stockList;
                            
                        }
                        else
                        {
                            dupList.Clear();
                            dupList = stockList;
                        }
                    }
                }
            }
        }

        private void CHart_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.Stocks' table. You can move, or remove it, as needed.
            this.stocksTableAdapter.Fill(this.masterDataSet.Stocks);

        }
    }
}
