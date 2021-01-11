using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar.Personel
{
    public partial class FrmYeniPersonel : Form
    {
        public FrmYeniPersonel()
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
            Tbl_Personel t = new Tbl_Personel();
            t.Ad = TxtAd.Text;
            t.Soyad = TxtSoyad.Text;
            //t.Departman = byte.Parse(TxtDepartman.Text.ToString());
            t.Foto = TxtFoto.Text;
            t.mail = TxtMail.Text;
            t.Tel = TxtTel.Text;
            db.Tbl_Personel.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
