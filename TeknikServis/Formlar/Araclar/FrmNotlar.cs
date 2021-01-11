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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Tbl_Notlar.Where(x => x.Durum == false).ToList();
            dataGridView2.DataSource = db.Tbl_Notlar.Where(x => x.Durum == true).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_Notlar t = new Tbl_Notlar();
            t.Baslik = TxtBaslik.Text;
            t.Icerik = RichtxtIcerik.Text;
            t.Durum = false;
            db.Tbl_Notlar.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtBaslik.Text = "";
            RichtxtIcerik.Text = "";
            checkBox1.Checked = false;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Tbl_Notlar.Where(x => x.Durum == false).ToList();
            dataGridView2.DataSource = db.Tbl_Notlar.Where(x => x.Durum == true).ToList();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                int id = int.Parse(TxtID.Text);
                var deger = db.Tbl_Notlar.Find(id);
                deger.Durum = true;
                db.SaveChanges();
                MessageBox.Show("Not durumu değiştirildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.CurrentRow.Selected = true;
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
            TxtBaslik.Text = dataGridView1.Rows[e.RowIndex].Cells["Baslik"].FormattedValue.ToString();
            RichtxtIcerik.Text = dataGridView1.Rows[e.RowIndex].Cells["Icerik"].FormattedValue.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.Tbl_Notlar.Find(id);
            db.Tbl_Notlar.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Not başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
