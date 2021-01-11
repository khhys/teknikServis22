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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        public void Listele()
        {
            var degerler = from u in db.Tbl_Personel
                           select new
                           {
                               u.ID,
                               u.Ad,
                               u.Soyad,
                               Departman=u.Tbl_Departman.Ad,
                               u.mail,
                               u.Tel
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.Tbl_Personel
                           select new
                           {
                               u.ID,
                               u.Ad,
                               u.Soyad,
                               Departman=u.Tbl_Departman.Ad,
                               u.mail,
                               u.Tel
                           };
            dataGridView1.DataSource = degerler.ToList();
            string ad1, soyad1, ad2, soyad2, ad3, soyad3, ad4, soyad4;
            //pers1
            ad1 = db.Tbl_Personel.First(x => x.ID == 1).Ad;
            soyad1 = db.Tbl_Personel.First(x => x.ID == 1).Soyad;
            label5.Text = db.Tbl_Personel.First(x => x.ID == 1).Tbl_Departman.Ad;
            label8.Text = db.Tbl_Personel.First(x => x.ID == 1).mail;
            label3.Text = ad1 + " " + soyad1;
            //pers3
            ad3 = db.Tbl_Personel.First(x => x.ID == 3).Ad;
            soyad3 = db.Tbl_Personel.First(x => x.ID == 3).Soyad;
            label12.Text = db.Tbl_Personel.First(x => x.ID == 3).Tbl_Departman.Ad;
            label10.Text = db.Tbl_Personel.First(x => x.ID == 3).mail;
            label14.Text = ad3 + " " + soyad3;
            //pers2
            ad2 = db.Tbl_Personel.First(x => x.ID == 2).Ad;
            soyad2 = db.Tbl_Personel.First(x => x.ID == 2).Soyad;
            label24.Text = db.Tbl_Personel.First(x => x.ID == 2).Tbl_Departman.Ad;
            label22.Text = db.Tbl_Personel.First(x => x.ID == 2).mail;
            label26.Text = ad2 + " " + soyad2;
            //pers4
            ad4 = db.Tbl_Personel.First(x => x.ID == 4).Ad;
            soyad4 = db.Tbl_Personel.First(x => x.ID == 4).Soyad;
            label18.Text = db.Tbl_Personel.First(x => x.ID == 4).Tbl_Departman.Ad;
            label16.Text = db.Tbl_Personel.First(x => x.ID == 4).mail;
            label20.Text = ad4 + " " + soyad4;

            comboBox1.DataSource = db.Tbl_Departman.ToList();
            comboBox1.DisplayMember = "Ad";
            comboBox1.ValueMember = "ID";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells["Ad"].FormattedValue.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells["Soyad"].FormattedValue.ToString();
            //TxtFoto.Text = dataGridView1.Rows[e.RowIndex].Cells["Foto"].FormattedValue.ToString();
            TxtMail.Text = dataGridView1.Rows[e.RowIndex].Cells["mail"].FormattedValue.ToString();
            MskTel.Text = dataGridView1.Rows[e.RowIndex].Cells["Tel"].FormattedValue.ToString();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_Personel t = new Tbl_Personel();
            t.Ad = TxtAd.Text;
            t.Soyad = TxtSoyad.Text;
            t.Foto = TxtFoto.Text;
            t.mail = TxtMail.Text;
            t.Tel = MskTel.Text;
            t.Departman = byte.Parse(comboBox1.SelectedValue.ToString());
            db.Tbl_Personel.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel başarıyla kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            comboBox1.Text = "";
            TxtFoto.Text = "";
            TxtMail.Text = "";
            MskTel.Text = "";
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.Tbl_Personel.Find(id);
            db.Tbl_Personel.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Personel başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.Tbl_Personel.Find(id);
            deger.Ad = TxtAd.Text;
            deger.Soyad = TxtSoyad.Text;
            deger.Departman = byte.Parse(comboBox1.SelectedValue.ToString());
            deger.Foto = TxtFoto.Text;
            deger.mail = TxtMail.Text;
            deger.Tel = MskTel.Text;
            db.SaveChanges();
            MessageBox.Show("Personel başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
