using Okulapp.BLL;
using okulAppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace haftadokuz
{
    public partial class frmOgnKayit : Form
    {
        public int OgrenciId { get; set; }
        public frmOgnKayit()
        {
            InitializeComponent();
            btnsil.Enabled = false; 
        }
        public  bool ogrenciekle(Ogrenci ogr)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                using (cn = new SqlConnection("Data Source=localhost;Initial Catalog=OkulDbSube2Bil;Integrated Security=true"))
                {
                    using (cmd = new SqlCommand($"Insert into tblOgrenciler values(@Ad,@Soyad,@Numara)", cn)
)
                    {
                    SqlParameter[] p =
                {
                    new SqlParameter("@Ad",ogr.Ad),
                    new SqlParameter("@Soyad",ogr.Soyad),
                    new SqlParameter("@Numara",ogr.Numara),


                };
                cmd.Parameters.AddRange(p); cn.Open();
                int sonuc = cmd.ExecuteNonQuery();
   
                return sonuc > 0;  }
                }
                
            }
            catch (SqlException)
            {
                throw;
                
            }
            catch (Exception)
            {
               
                throw;
            }
           
        }
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();

             bool sonuc=obl.ogrenciekle(new Ogrenci { Ad = txtad.Text.Trim(), Soyad = txtsoyad.Text.Trim(), Numara = txtno.Text.Trim() });
                MessageBox.Show(sonuc ? "ekleme başarılı" : "ekleme başarısız");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                   case 2627:
                       MessageBox.Show("Bu numara daha önce girilmiş!");
                       break;
                   default:
                       MessageBox.Show("Veritabanı Hatası!");
                        break;
                }
            }
            catch (Exception) 
            {
                throw;
                MessageBox.Show("Bir Hata Oluştu");
            }          

        }

        private void btnbul_Click(object sender, EventArgs e)
        {
            var frm = new frmOgrBul(this);
            frm.Show();
          

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
           var obl = new OgrenciBL();            
            MessageBox.Show(obl.OgrenciSil(OgrenciId)?"Silme Başarılı":"Silme Başarısız!!!!") ;
            

  

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            var obl = new OgrenciBL();
            MessageBox.Show(obl.OgrenciGuncelle(new Ogrenci {Ad=txtad.Text.Trim(),Soyad=txtsoyad.Text.Trim(),
                Numara=txtno.Text.Trim(),OgrenciId= OgrenciId })? "Güncelleme Başarılı":"Güncelleme Başarısız!");
        }
    }
}