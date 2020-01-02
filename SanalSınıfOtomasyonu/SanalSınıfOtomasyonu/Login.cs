using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SanalSınıfOtomasyonu
{
    public partial class Login : XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@KullaniciAdi",SqlDbType.NVarChar),
                new SqlParameter("@KullaniciSifre",SqlDbType.NVarChar)
            };
            parameters[0].Value = txtKullaniciAd.Text;
            parameters[1].Value = txtSifre.Text;
            DataTable dataTable = VeritabaniIslemleri.ExecuteDataTable( "Giris",
                parameters, CommandType.StoredProcedure);
            if (dataTable.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dataTable.Rows[0]["KullaniciTuru"]))
                {
                    Ogretmen ogr = new Ogretmen
                    {
                        KullaniciAd = dataTable.Rows[0]["KullaniciAd"].ToString(),
                        KullaniciAdSoyad = dataTable.Rows[0]["KullaniciSoyad"].ToString(),
                        KullaniciId = Convert.ToInt32(dataTable.Rows[0]["KullaniciId"]),
                        KullaniciSifre = dataTable.Rows[0]["KullaniciSifre"].ToString(),
                        DersId = Convert.ToInt32(dataTable.Rows[0]["DersId"]),
                        OgretmenId = Convert.ToInt32(dataTable.Rows[0]["OgretmenId"])
                    };
                    OgretmenSayfasi frm = new OgretmenSayfasi(ogr);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    Ogrenci ogr = new Ogrenci
                    {
                        KullaniciAd = dataTable.Rows[0]["KullaniciAd"].ToString(),
                        KullaniciAdSoyad = dataTable.Rows[0]["KullaniciSoyad"].ToString(),
                        KullaniciId = Convert.ToInt32(dataTable.Rows[0]["KullaniciId"]),
                        KullaniciSifre = dataTable.Rows[0]["KullaniciSifre"].ToString(),
                        OgrenciId = Convert.ToInt32(dataTable.Rows[0]["OgrenciId"]),
                        OgrenciNo = Convert.ToInt32(dataTable.Rows[0]["OgrenciNo"])
                    };
                    OgrenciSayfasi frm = new OgrenciSayfasi(ogr);
                    frm.Show();
                    this.Hide();
                }
            }
            else
                XtraMessageBox.Show("Kullanıcı bilgileri yanlış girildi...", "Hatalı Giriş!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            
        }
    }
}
