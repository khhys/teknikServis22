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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text.Length <= 50 && TxtAd.Text != "" )
            {
                Tbl_Departman t = new Tbl_Departman();
                t.Ad = TxtAd.Text;
                db.Tbl_Departman.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt yapılamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
