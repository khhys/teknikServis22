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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_Cari t = new Tbl_Cari();
            t.Ad = TxtAd.Text;
            t.Soyad = TxtSoyad.Text;
            t.Tel = TxtTel.Text;
            t.Mail = TxtMail.Text;
            t.Il = Txtil.Text;
            t.Ilce = Txtilce.Text;
            t.Banka = TxtBanka.Text;
            t.VergiDairesi = TxtVergiDaire.Text;
            t.VergiNo = TxtVergiNo.Text;
            t.Statu = TxtStatu.Text;
            t.Adres = TxtAdres.Text;
            db.Tbl_Cari.Add(t);
            db.SaveChanges();
            MessageBox.Show("Cari başarıyla kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }
    }
}
