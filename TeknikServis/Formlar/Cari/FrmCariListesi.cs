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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        public void Listele()
        {
            var degerler = from k in db.Tbl_Cari
                           select new
                           {
                               k.ID,
                               k.Ad,
                               k.Soyad,
                               k.Tel,
                               k.Mail,
                               k.Il,
                               k.Ilce,
                               k.Banka,
                               k.VergiDairesi,
                               k.VergiNo,
                               k.Statu,
                               k.Adres,
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_Cari c = new Tbl_Cari();
            c.Ad = TxtCariAd.Text;
            c.Soyad = TxtCariSoyad.Text;
            c.Tel = Msktel.Text;
            c.Mail = TxtMail.Text;
            c.Il = comboBox1.Text;
            c.Ilce = comboBox2.Text;
            c.Banka = TxtBanka.Text;
            c.VergiDairesi = TxtVergiDaire.Text;
            c.VergiNo = TxtVergiNo.Text;
            c.Statu = TxtStatu.Text;
            c.Adres = TxtAdres.Text;
            db.Tbl_Cari.Add(c);
            db.SaveChanges();
            MessageBox.Show("Cari başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtCariID.Text = "";
            TxtCariID.Text = "";
            TxtCariSoyad.Text = "";
            Msktel.Text = "";
            TxtMail.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            TxtBanka.Text = "";
            TxtVergiDaire.Text = "";
            TxtVergiNo.Text = "";
            TxtStatu.Text = "";
            TxtAdres.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                TxtCariID.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                TxtCariAd.Text = dataGridView1.Rows[e.RowIndex].Cells["Ad"].FormattedValue.ToString();
                TxtCariSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells["Soyad"].FormattedValue.ToString();
                Msktel.Text = dataGridView1.Rows[e.RowIndex].Cells["Tel"].FormattedValue.ToString();
                TxtMail.Text = dataGridView1.Rows[e.RowIndex].Cells["Mail"].FormattedValue.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Il"].FormattedValue.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Ilce"].FormattedValue.ToString();
                TxtBanka.Text = dataGridView1.Rows[e.RowIndex].Cells["Banka"].FormattedValue.ToString();
                TxtVergiDaire.Text = dataGridView1.Rows[e.RowIndex].Cells["VergiDairesi"].FormattedValue.ToString();
                TxtVergiNo.Text = dataGridView1.Rows[e.RowIndex].Cells["VergiNo"].FormattedValue.ToString();
                TxtStatu.Text = dataGridView1.Rows[e.RowIndex].Cells["Statu"].FormattedValue.ToString();
                TxtAdres.Text = dataGridView1.Rows[e.RowIndex].Cells["Adres"].FormattedValue.ToString();
            }
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtCariID.Text);
            var deger = db.Tbl_Cari.Find(id);
            deger.Ad = TxtCariAd.Text;
            deger.Soyad = TxtCariSoyad.Text;
            deger.Tel = Msktel.Text;
            deger.Mail = TxtMail.Text;
            deger.Il = comboBox1.Text;
            deger.Ilce = comboBox2.Text;
            deger.Banka = TxtBanka.Text;
            deger.VergiDairesi = TxtVergiDaire.Text;
            deger.VergiNo = TxtVergiNo.Text;
            deger.Statu = TxtStatu.Text;
            deger.Adres = TxtAdres.Text;
            db.SaveChanges();
            MessageBox.Show("Cari başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtCariID.Text);
            var deger = db.Tbl_Cari.Find(id);
            db.Tbl_Cari.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Cari başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Listele();
        }
    }
}
