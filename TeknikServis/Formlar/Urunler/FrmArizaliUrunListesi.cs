using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar.Urunler
{
    public partial class FrmArizaliUrunListesi : Form
    {
        public FrmArizaliUrunListesi()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        private void FrmArizaliUrunListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.Tbl_UrunKabul
                           select new
                           {
                               ID = x.IslemID,
                               Cari = x.Tbl_Cari.Ad + x.Tbl_Cari.Soyad,
                               Personel = x.Tbl_Personel.Ad + x.Tbl_Personel.Soyad,
                               Geliş_Tarihi = x.GelisTar,
                               Çıkış_Tarihi = x.CikisTar,
                               x.UrunSeriNo
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
    }
}
