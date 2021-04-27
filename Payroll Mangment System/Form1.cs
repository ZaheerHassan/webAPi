using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Mangment_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Login();
           
        }

        public static async Task<Boolean> Login()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var User = new Payroll_Mangment_System.Repo.User() { username = "zaheer", password = "Password" };
            var response = await client.PostAsJsonAsync("Auth/Login", JsonConvert.SerializeObject(User));

            MessageBox.Show(response.ToString());
            return true;
        }

    }
}
