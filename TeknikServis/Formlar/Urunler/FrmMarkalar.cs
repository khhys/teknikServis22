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
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities1 db = new DB_TeknikServisEntities1();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.Tbl_Urun.OrderBy(x => x.Marka).GroupBy(y => y.Marka).
                Select(z => new
                {
                    Marka = z.Key,
                    Toplam = z.Count()
                });
            dataGridView1.DataSource = degerler.ToList();
            label2.Text = db.Tbl_Urun.Count().ToString();
            label3.Text = (from x in db.Tbl_Urun
                            select x.Marka).Distinct().Count().ToString();
            label7.Text = (from x in db.Tbl_Urun
                            orderby x.SatisFiyat descending
                            select x.Marka).FirstOrDefault();
            //Soldaki chart
            chart1.Series["Series1"].Points.AddXY("Siemens", 4);
            chart1.Series["Series1"].Points.AddXY("Arçelik", 6);
            chart1.Series["Series1"].Points.AddXY("Lenovo", 2);
            chart1.Series["Series1"].Points.AddXY("Vestel", 3);
            chart1.Series["Series1"].Points.AddXY("Beko", 4);
            chart1.Series["Series1"].Points.AddXY("Bosch", 2);
            chart1.Series["Series1"].Points.AddXY("Samsung", 4);
            //Sağdaki chart
            chart2.Series["Kategoriler"].Points.AddXY("Küçük Ev Aletleri", 7);
            chart2.Series["Kategoriler"].Points.AddXY("Beyaz Eşya", 6);
            chart2.Series["Kategoriler"].Points.AddXY("Bilgisayar", 4);
            chart2.Series["Kategoriler"].Points.AddXY("TV", 3);
            chart2.Series["Kategoriler"].Points.AddXY("Mobilya", 2);
            chart2.Series["Kategoriler"].Points.AddXY("Diğer", 2);
            chart2.Series["Kategoriler"].Points.AddXY("Telefon", 1);

        }

    }
}
