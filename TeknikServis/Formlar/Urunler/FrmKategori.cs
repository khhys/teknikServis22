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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        public void Listele()
        {
            var degerler = from k in db.Tbl_Kategori
                           select new
                           {
                               k.ID,
                               k.Ad
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
        private void FrmKategori_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_Kategori t = new Tbl_Kategori();
            t.Ad = TxtAdd.Text;
            db.Tbl_Kategori.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla kaydedildi.");
            Listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtIDd.Text = "";
            TxtAdd.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtIDd.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
            TxtAdd.Text = dataGridView1.Rows[e.RowIndex].Cells["Ad"].FormattedValue.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtIDd.Text);
            var deger = db.Tbl_Kategori.Find(id);
            db.Tbl_Kategori.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtIDd.Text);
            var deger = db.Tbl_Kategori.Find(id);
            deger.Ad = TxtAdd.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
