using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmCariIller : Form
    {
        public FrmCariIller()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        SqlConnection con = new SqlConnection(@"Data Source=ASUS-NOTEBOOK\SQLEXPRESS;Initial Catalog=DB_TeknikServis;Integrated Security=True");
        private void FrmCariIller_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Tbl_Cari.OrderBy(x => x.Il).
                GroupBy(y => y.Il).
                Select(z => new { İl = z.Key, Toplam = z.Count() }).ToList();
            con.Open();
            SqlCommand komut = new SqlCommand("select Il, COUNT(*) from Tbl_Cari group by Il", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Series1"].Points.AddXY(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            con.Close();

        }
    }
}
