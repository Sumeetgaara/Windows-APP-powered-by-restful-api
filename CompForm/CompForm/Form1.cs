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
namespace CompForm
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string URI = "http://localhost:54513/api/stock/";
            GetStockInformation(URI,true);


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
                            dataGridView1.DataSource = stockList;
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
        

        private void button2_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text.ToString();
            string URI = "http://localhost:54513/api/stock?symbol="+value;
            GetStockInformation(URI, true);
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var chart = new CHart();
            chart.Show();
        }
    }

           
 }

