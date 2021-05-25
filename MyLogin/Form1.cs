using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace MyLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //ambil dari app setting dan masukkan ke variabel
            String valueTestString = ConfigurationManager.AppSettings["TestString"];
            int valueTestAngka = int.Parse(ConfigurationManager.AppSettings["TestAngka"]);

            //menampilkan variabel via message box
            MessageBox.Show("Isi Test String: " + valueTestString);
            MessageBox.Show("Isi Test Angka: " + valueTestAngka);
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = (from s in db.TB_M_USERs where s.username == txtUsername.Text select s).First();
            if (user.password == txtPassword.Text)
            {
                this.Hide();
                MasterProduct a = new MasterProduct();
                a.Show();
            }
            else
            {
                MessageBox.Show("Password Error");
            }
        }
    }
}

