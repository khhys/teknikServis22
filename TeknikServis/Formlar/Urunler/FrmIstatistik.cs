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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.Tbl_Urun.Count().ToString();
            label3.Text = db.Tbl_Kategori.Count().ToString();
            label5.Text = db.Tbl_Urun.Sum(x => x.Stok).ToString();
            label11.Text = "22";
            label23.Text = (from x in db.Tbl_Urun
                            orderby x.Stok descending
                            select x.Ad).FirstOrDefault();
            label21.Text = (from x in db.Tbl_Urun
                            orderby x.Stok ascending
                            select x.Ad).FirstOrDefault();
            label14.Text = (from x in db.Tbl_Urun
                            orderby x.SatisFiyat descending
                            select x.Ad).FirstOrDefault();
            label17.Text = (from x in db.Tbl_Urun
                            orderby x.SatisFiyat ascending
                            select x.Ad).FirstOrDefault();
            label36.Text = db.Tbl_Urun.Where(x => x.Kategori == 4).Sum(x => x.Stok).ToString();
            label27.Text = db.Tbl_Urun.Where(x => x.Kategori == 1).Sum(x => x.Stok).ToString();
            label34.Text = db.Tbl_Urun.Where(x => x.Kategori == 3).Sum(x => x.Stok).ToString();
            label30.Text = db.Tbl_Urun.Where(x => x.Kategori == 2).Sum(x => x.Stok).ToString();
            label45.Text = (from x in db.Tbl_Urun
                            select x.Marka).Distinct().Count().ToString();

        }

    }
}
