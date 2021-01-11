using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar.Cari
{
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_UrunHareket t = new Tbl_UrunHareket();
            t.Urun = int.Parse(TxtUrunId.Text);
            t.Musteri = int.Parse(TxtMusteri.Text);
            t.Personel = short.Parse(TxtPersonel.Text);
            t.Tarih = DateTime.Parse(TxtTarih.Text);
            t.Adet = short.Parse(TxtAdet.Text);
            t.Fiyat = decimal.Parse(TxtSatisFiyat.Text);
            t.UrunSeriNo = TxtSeriNo.Text;
            db.Tbl_UrunHareket.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün satışı başarıyla gerçekleştirildi.");
        }
    }
}
