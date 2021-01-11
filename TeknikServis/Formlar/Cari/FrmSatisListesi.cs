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
    public partial class FrmSatisListesi : Form
    {
        public FrmSatisListesi()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        private void FrmSatisListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.Tbl_UrunHareket
                           select new
                           {
                               x.HareketID,
                               x.Tbl_Urun.Ad,
                               Musteri = x.Tbl_Cari.Ad + " " + x.Tbl_Cari.Soyad,
                               Personel = x.Tbl_Personel.Ad + " " + x.Tbl_Personel.Soyad,
                               x.Tarih,
                               x.Adet,
                               x.Fiyat,
                               x.UrunSeriNo
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
    }
}
