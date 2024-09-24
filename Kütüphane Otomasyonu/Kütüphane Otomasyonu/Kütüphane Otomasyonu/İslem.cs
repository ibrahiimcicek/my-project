using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Kütüphane_Otomasyonu
{
    public partial class İslem : Form
    {
        public İslem()
        {
            InitializeComponent();
        }
        MySqlConnection baglan = new MySqlConnection("Server=localhost;  database=kutuphane; uid=root; password=");
        DataTable tablo = new DataTable();
        public void temizle()
        {
            
            text_kAD.Clear();
            text_kSeriNo.Clear();
            text_KYazar.Clear();
            text_YaYinEvi.Clear();
            text_KDil.Clear();
            text_Ssayisi.Clear();
        }
        public void goster()
        {
            tablo.Clear();
            baglan.Open();
            MySqlDataAdapter adap = new MySqlDataAdapter("select * from kitapalar", baglan);
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();

            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            MySqlCommand ekle = new MySqlCommand("INSERT INTO kitapalar(seriNo, kitapAD, Yazar, BasimTarihi, kitapDil, SayfaSayisi, YayinEvi) VALUES ('" + text_kSeriNo.Text + "','" + text_kAD.Text + "','" + text_KYazar.Text + "','" + dateTimePicker1.Value + "','" + text_KDil.Text + "','" + text_Ssayisi.Text + "','" + text_YaYinEvi.Text + "')", baglan);
            ekle.ExecuteNonQuery();
     
            MessageBox.Show("kayıt başarılı");
            baglan.Close();
            goster();
            temizle();
        }

        private void İslem_Load(object sender, EventArgs e)
        {
            goster();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }
        string id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secili].Cells[0].Value.ToString();
            text_kSeriNo.Text = dataGridView1.Rows[secili].Cells[1].Value.ToString();
            text_kAD.Text = dataGridView1.Rows[secili].Cells[2].Value.ToString();
            text_KYazar.Text = dataGridView1.Rows[secili].Cells[3].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[secili].Cells[4].Value);
            text_KDil.Text = dataGridView1.Rows[secili].Cells[5].Value.ToString();
            text_Ssayisi.Text = dataGridView1.Rows[secili].Cells[6].Value.ToString();
            text_YaYinEvi.Text = dataGridView1.Rows[secili].Cells[7].Value.ToString();

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

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            MySqlCommand komut = new MySqlCommand("UPDATE kitapalar SET seriNo='" + text_kSeriNo.Text + "',kitapAD='" + text_kAD.Text + "',Yazar='" + text_KYazar.Text + "',BasimTarihi='" + dateTimePicker1.Text + "',kitapDil='" + text_KDil.Text + "',SayfaSayisi='" + text_Ssayisi.Text + "',YayinEvi='" + text_YaYinEvi.Text + "' WHERE id='" + id + "' ", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            goster();
            temizle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            MySqlCommand komut = new MySqlCommand("DELETE FROM kitapalar WHERE id='"+id+"'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            goster();
            temizle();
        }

        private void txt_ara_TextChanged(object sender, EventArgs e)
        {

            baglan.Open();
            DataTable tbl = new DataTable();
            string vara, cumle;
            vara = txt_ara.Text;
            cumle = "Select * from kitapalar where kitapAD like '%" + txt_ara.Text + "%'";
            MySqlDataAdapter adptr = new MySqlDataAdapter(cumle, baglan);
            adptr.Fill(tbl);
            baglan.Close();
            dataGridView1.DataSource = tbl;
        }

        public string connectionString { get; set; }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
