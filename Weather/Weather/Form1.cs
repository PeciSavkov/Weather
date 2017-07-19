using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;

namespace Weather
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        string url1;
        string url2;
        string json;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbCity.Text == "")
            {
                MessageBox.Show("Полето за град не може да бъде празно!");
                return;
            }
            try
            {
                url1 = "http://api.openweathermap.org/data/2.5/weather?q=" + tbCity.Text + ",&appid=62326bbf104d6025a0bad581efe42a7e&units=metric&lang=bg";
                json = client.GetStringAsync(url1).Result;
                
            }
            catch
            {
                MessageBox.Show("Заявката неможа да се изпълни");
                return;
            }
            cWeather wea = JsonConvert.DeserializeObject<cWeather>(json);
            lblName.Text = tbCity.Text;
            lblName.Visible = true;
            lblTemp.Text = Convert.ToString(wea.main.temp) + " °C";
            lblTemp.Visible = true;
            lblHumidity.Text = Convert.ToString(wea.main.humidity) + " %";
            lblHumidity.Visible = true;
            lblPresure.Text = Convert.ToString(wea.main.pressure) + " hpa";
            lblPresure.Visible = true;
            lblWindSpeed.Text = Convert.ToString(wea.wind.speed + " m/s");
            lblWindSpeed.Visible = true;
            lblDes.Text = Convert.ToString(wea.weather.ElementAt(0).description);
            lblDes.Visible = true;
            url2 = "http://openweathermap.org/img/w/" + Convert.ToString(wea.weather.ElementAt(0).icon + ".png");
            pbWeather.Load(url2);



            DateTime time = DateTime.Now;
            lblDt.Text = Convert.ToString(time);
            lblDt.Visible = true;
        }
    }
}
