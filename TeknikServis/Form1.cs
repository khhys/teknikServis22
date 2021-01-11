using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnUrunListesiForm_Click(object sender, EventArgs e)
        {
            Formlar.FrmUrunListesi frm = new Formlar.FrmUrunListesi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void BtnYeniUrunForm_Click(object sender, EventArgs e)
        {
            Formlar.FrmYeniUrun frm = new Formlar.FrmYeniUrun();
            //frm.MdiParent = this;
            frm.Show();
        }
        private void CikisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnKategoriListesi_Click(object sender, EventArgs e)
        {
            Formlar.FrmKategori fr = new Formlar.FrmKategori();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnYeniKategori_Click(object sender, EventArgs e)
        {
            Formlar.FrmYeniKategori fr = new Formlar.FrmYeniKategori();
            fr.Show();
        }

        private void BtnUrunIstatistik_Click(object sender, EventArgs e)
        {
            Formlar.FrmIstatistik fr = new Formlar.FrmIstatistik();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnMarkaIstatistik_Click(object sender, EventArgs e)
        {
            Formlar.FrmMarkalar fr = new Formlar.FrmMarkalar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnCariList_Click(object sender, EventArgs e)
        {
            Formlar.FrmCariListesi fr = new Formlar.FrmCariListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnCariIlista_Click(object sender, EventArgs e)
        {
            Formlar.FrmCariIller fr = new Formlar.FrmCariIller();
            fr.MdiParent = this;
            fr.Show();
        }

        private void yeniCariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formlar.FrmCariEkle fr = new Formlar.FrmCariEkle();
            fr.Show();
        }

        private void BtnDepartmanListesi_Click(object sender, EventArgs e)
        {
            Formlar.FrmDepartman fr = new Formlar.FrmDepartman();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnYeniDepartman_Click(object sender, EventArgs e)
        {
            Formlar.FrmYeniDepartman fr = new Formlar.FrmYeniDepartman();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void BtnPersonelListesi_Click(object sender, EventArgs e)
        {
            Formlar.FrmPersonel fr = new Formlar.FrmPersonel();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnHesapMakinesi_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void BtnDovizKurlari_Click(object sender, EventArgs e)
        {
            Formlar.FrmDovizKurlari fr = new Formlar.FrmDovizKurlari();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnWord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }

        private void FrmYoutube_Click(object sender, EventArgs e)
        {
            Formlar.FrmYoutube fr = new Formlar.FrmYoutube();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnAjanda_Click(object sender, EventArgs e)
        {
            Formlar.FrmNotlar fr = new Formlar.FrmNotlar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnYeniPersonel_Click(object sender, EventArgs e)
        {
            Formlar.Personel.FrmYeniPersonel fr = new Formlar.Personel.FrmYeniPersonel();
            fr.Show();
        }

        private void BtnArizaliUrunListesi_Click(object sender, EventArgs e)
        {
            Formlar.Urunler.FrmArizaliUrunListesi fr = new Formlar.Urunler.FrmArizaliUrunListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnYeniUrunSatis_Click(object sender, EventArgs e)
        {
            Formlar.Cari.FrmUrunSatis fr = new Formlar.Cari.FrmUrunSatis();
            fr.Show();
        }

        private void BtnSatisListesi_Click(object sender, EventArgs e)
        {
            Formlar.Cari.FrmSatisListesi fr = new Formlar.Cari.FrmSatisListesi();
            fr.MdiParent = this;
            fr.Show();
        }
    }
}
