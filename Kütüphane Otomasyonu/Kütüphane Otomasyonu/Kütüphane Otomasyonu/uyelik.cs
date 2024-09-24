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
    public partial class uyelik : Form
    {
        public uyelik()
        {
            InitializeComponent();
        }
        MySqlConnection baglan = new MySqlConnection("Server=localhost;  database=kutuphane; uid=root; password=");
        DataTable tablo = new DataTable();

        public void goster()
        {
            tablo.Clear();
            baglan.Open();
            MySqlDataAdapter adap = new MySqlDataAdapter("select * from uyeler", baglan);
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();


        }
        public void temizle()
        {

            text_tc.Clear();
            text_adSoyad.Clear();
            text_tel_no.Clear();
            text_adres.Clear();
            text_yasagi_ülke.Clear();
          
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();

            res = MessageBox.Show("İptal etmek istediğinize eminmisiniz", " UYARI!!!", MessageBoxButtons.YesNo);


            if (res == DialogResult.Yes)
            {

                Form1 ac = new Form1();
                ac.Show();
                this.Hide();
            }

        }

        private void uyelik_Load(object sender, EventArgs e)
        {
            goster();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txt_ara_TextChanged(object sender, EventArgs e)
        {

            baglan.Open();
            DataTable tbl = new DataTable();
            string vara, cumle;
            vara = txt_ara.Text;
            cumle = "Select * from uyeler where tc like '%" + txt_ara.Text + "%'";
            MySqlDataAdapter adptr = new MySqlDataAdapter(cumle, baglan);
            adptr.Fill(tbl);
            baglan.Close();
            dataGridView1.DataSource = tbl;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            MySqlCommand KOMUT = new MySqlCommand("INSERT INTO uyeler(tc, AdSoyad, DogumTarihi, YasadigiUlke, tel_no, adres) VALUES ('" + text_tc.Text + "','" + text_adSoyad.Text + "','" + dateTimePicker1.Value + "','" + text_yasagi_ülke.Text + "','" + text_tel_no.Text + "','" + text_adres.Text + "')", baglan);
            KOMUT.ExecuteNonQuery();
            baglan.Close();
            goster();
            temizle();

        }
        string id;
        
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secili = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secili].Cells[0].Value.ToString();
            text_tc.Text = dataGridView1.Rows[secili].Cells[1].Value.ToString();
            text_adSoyad.Text = dataGridView1.Rows[secili].Cells[2].Value.ToString();

            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[secili].Cells[3].Value);
            text_yasagi_ülke.Text = dataGridView1.Rows[secili].Cells[4].Value.ToString();
            text_tel_no.Text = dataGridView1.Rows[secili].Cells[5].Value.ToString();
            text_adres.Text = dataGridView1.Rows[secili].Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            MySqlCommand ko = new MySqlCommand("UPDATE uyeler SET tc='" + text_tc.Text + "',AdSoyad='" + text_adSoyad.Text + "',DogumTarihi='" + dateTimePicker1.Value + "',YasadigiUlke='" + text_yasagi_ülke.Text + "',tel_no='" + text_tel_no.Text + "',adres='" + text_adres.Text + "' WHERE id='" + id + "'", baglan);
            ko.ExecuteNonQuery();
            baglan.Close();
            goster();
            temizle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            MySqlCommand komut = new MySqlCommand("DELETE FROM uyeler WHERE id='" + id + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            goster();
            temizle();
        }
    }
}
