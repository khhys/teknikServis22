using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        public void metot1()
        {
            var degerler = from u in db.Tbl_Urun
                           select new
                           {
                               u.ID,
                               u.Ad,
                               u.Marka,
                               Kategori=u.Tbl_Kategori.Ad,
                               u.Stok,
                               u.AlisFiyat,
                               u.SatisFiyat
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            //tolist add remove
            //var degerler = db.Tbl_Urun.ToList();
            metot1();
            comboBox1.DataSource = db.Tbl_Kategori.ToList();
            comboBox1.DisplayMember = "Ad";
            comboBox1.ValueMember = "ID";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_Urun t = new Tbl_Urun();
            t.Ad = TxtUrunAd.Text;
            t.Marka = TxtMarka.Text;
            t.AlisFiyat = decimal.Parse(TxtAlisFiyat.Text);
            t.SatisFiyat = decimal.Parse(TxtSatisFiyat.Text);
            t.Stok = short.Parse(TxtStok.Text);
            t.Durum = false;
            t.Kategori = byte.Parse(comboBox1.SelectedValue.ToString());
            db.Tbl_Urun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            metot1();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot1();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                TxtUrunID.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
                TxtUrunAd.Text = dataGridView1.Rows[e.RowIndex].Cells["Ad"].FormattedValue.ToString();
                TxtMarka.Text = dataGridView1.Rows[e.RowIndex].Cells["Marka"].FormattedValue.ToString();
                TxtAlisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells["AlisFiyat"].FormattedValue.ToString();
                TxtSatisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells["SatisFiyat"].FormattedValue.ToString();
                TxtStok.Text = dataGridView1.Rows[e.RowIndex].Cells["Stok"].FormattedValue.ToString();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtUrunID.Text);
            var deger = db.Tbl_Urun.Find(id);
            db.Tbl_Urun.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            var degerler = db.Tbl_Urun.ToList();
            dataGridView1.DataSource = degerler;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtUrunID.Text);
            var deger = db.Tbl_Urun.Find(id);
            deger.Ad = TxtUrunAd.Text;
            deger.Marka = TxtMarka.Text;
            deger.AlisFiyat = decimal.Parse(TxtAlisFiyat.Text);
            deger.SatisFiyat = decimal.Parse(TxtSatisFiyat.Text);
            deger.Kategori = byte.Parse(comboBox1.SelectedValue.ToString());
            deger.Stok = short.Parse(TxtStok.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            metot1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtUrunID.Text = "";
            TxtUrunAd.Text = "";
            TxtMarka.Text = "";
            TxtAlisFiyat.Text = "";
            TxtSatisFiyat.Text = "";
            TxtStok.Text = "";
            comboBox1.Text = "";
        }
    }


}
