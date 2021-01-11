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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            //FrmYeniUrun fr = new FrmYeniUrun();
            //fr.close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
            Tbl_Urun t = new Tbl_Urun();
            t.Ad = TxtUrunAd.Text;
            t.Marka = TxtMarka.Text;
            t.AlisFiyat = decimal.Parse(TxtAlisFiyat.Text);
            t.SatisFiyat = decimal.Parse(TxtSatisFiyat.Text);
            t.Stok = short.Parse(TxtStok.Text);
            //t.Kategori = byte.Parse(TxtKategori.Text);
            db.Tbl_Urun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürünler başarıyla kaydedildi.");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
