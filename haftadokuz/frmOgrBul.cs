using Okulapp.BLL;
using okulAppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace haftadokuz
{
    public partial class frmOgrBul : Form
    {
        frmOgnKayit frm;
        public frmOgrBul(frmOgnKayit frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            OgrenciBL obl = new OgrenciBL();
            Ogrenci ogr = obl.OgrenciBul(txtNumara.Text.Trim());


            if (ogr!=null)
            {

                frm.txtad.Text = ogr.Ad;
                frm.txtsoyad.Text = ogr.Soyad;
                frm.txtno.Text = ogr.Numara;
                frm.OgrenciId = ogr.OgrenciId;
            }
            else
            {
                MessageBox.Show("Öğrenci Bulunamadı!!!");
            }
        }
    }
}
