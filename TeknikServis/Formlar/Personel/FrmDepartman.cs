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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }

        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        public void Listele()
        {
            var degerler = from u in db.Tbl_Departman
                           select new
                           {
                               u.ID,
                               u.Ad,
                               u.Aciklama
                           };
            dataGridView1.DataSource = degerler.ToList();
            label8.Text = db.Tbl_Departman.Count().ToString();
            label15.Text = db.Tbl_Personel.Count().ToString();
        }
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            Listele();
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text.Length <= 50 && TxtAd.Text != "" && richTextBox1.Text.Length >= 3)
            {
                Tbl_Departman t = new Tbl_Departman();
                t.Ad = TxtAd.Text;
                t.Aciklama = richTextBox1.Text;
                db.Tbl_Departman.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
            else
            {
                MessageBox.Show("Kayıt yapılamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            richTextBox1.Text = "";
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.Tbl_Departman.Find(id);
            db.Tbl_Departman.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Departman silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells["Ad"].FormattedValue.ToString();
            richTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Aciklama"].FormattedValue.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.Tbl_Departman.Find(id);
            deger.Ad = TxtAd.Text;
            deger.Aciklama = richTextBox1.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
