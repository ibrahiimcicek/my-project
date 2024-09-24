using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Otomasyonu
{
    public partial class TumUyeler : Form
    {
        public TumUyeler()
        {
            InitializeComponent();
        }
        MySqlConnection baglan = new MySqlConnection("Server=localhost;  database=kutuphane; uid=root; password=");
        DataTable tablo = new DataTable();
        private void TumUyeler_Load(object sender, EventArgs e)
        {
            tablo.Clear();
            baglan.Open();
            MySqlDataAdapter adap = new MySqlDataAdapter("select * from uyeler", baglan);
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            tablo.Clear();
            baglan.Open();
            MySqlDataAdapter adap = new MySqlDataAdapter("select * from uyeler", baglan);
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }
    }
}
