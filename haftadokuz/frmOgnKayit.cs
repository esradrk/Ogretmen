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
        public frmOgnKayit()
        {
            InitializeComponent();
        }
     public  bool ogrenciekle(Ogrenci ogr)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                using (cn = new SqlConnection("Data Source=localhost;Initial Catalog=OkulDbSube2Bil;Integrated Security=true"))
                {
                    using (cmd = new SqlCommand($"Insert into tblOgrenciler values(@Ad,@Soyad,@Numara)", cn)//using dispose yapar.Using içine yazılanı dispose eder ve connectionu kapatır.
)
                    {
                    SqlParameter[] p =
                {
                    new SqlParameter("@Ad",ogr.Ad),
                    new SqlParameter("@Soyad",ogr.Soyad),
                    new SqlParameter("@Numara",ogr.Numara),


                };
                cmd.Parameters.AddRange(p);//@ ile başlayan bir şeylerin sqlcommand tarafından algılayabilmesi için bütün parametreleri ekliyoruz
                cn.Open();
                int sonuc = cmd.ExecuteNonQuery();
   
                return sonuc > 0;//işlem yapılıp yapılmadığını kontrol eder. True  olursa çıkış yaparız. Ama false olursa catch bloğuna atar orada da throw olduğu için yine çıkış olur.
                    }
                }
                
            }
            catch (SqlException)
            {
                throw;//hatayı at(fırlat) anlamına gelir.
                
            }
            catch (Exception)
            {
               
                throw;
            }
            //finally//. Bu blok, bir kod bloğu içinde her durumda çalıştırılması gereken kodu içerir.
            //{
            //    if (cn != null && cn.State != ConnectionState.Closed)//connectionun durumu kapalı değilse ve nesne yoksa kapat.
            //    {
            //        cn.Close();
            //        cn.Dispose();
            //      cmd.Dispose();    
            //    }
            //}
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

       
    }
}//dispose metodu bellekten atmaya yardım ediyor.
//interface methotların imzalarını bulunduran yapı. Dispose edilebilir. Tanımlamalar yapılırken I harfiyle başlar.
//garbage collector: çöp toplayıcı. Bellekten işe  yaramaz dosylara bakıp çöpe atıyor.
//bazı nesneleri bizim toplamamız(dispose) gerekiyor. Sql işlemleri gibi.
//cn.dispose() diyerek atabiliriz. 

//oğretmen kayıt yap. Tc,ad,soyad