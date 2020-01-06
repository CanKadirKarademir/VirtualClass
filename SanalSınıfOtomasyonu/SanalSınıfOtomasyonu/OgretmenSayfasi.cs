using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SanalSınıfOtomasyonu
{
    public partial class OgretmenSayfasi : XtraForm
    {
        public OgretmenSayfasi()
        {
            
        }
        private Ogretmen _ogretmen;
        private Soru _soru = new Soru();
        private Ogrenci _ogrenci = new Ogrenci();

        public OgretmenSayfasi(Ogretmen ogretmen)
        {
            _ogretmen = ogretmen;

            InitializeComponent();
        }
        private void OgretmenSayfasi_Load(object sender, EventArgs e)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@DersId", SqlDbType.Int)
            };
            parameter[0].Value = Convert.ToInt32(_ogretmen.DersId);

            lookUpTur.Properties.DataSource = VeritabaniIslemleri.ExecuteDataTable(
                 @"select KonuId as 'Konu Kodu', KonuTuru as 'Konu Türü' From Konular where DersId=@DersId", parameter);
            lookUpTur.Properties.DisplayMember = "Konu Türü";
            lookUpTur.Properties.ValueMember = "Konu Kodu";
            GridSoruYukleme();
            GridOgrenciYukleme();
        }


        private void GridSoruYukleme() =>
            gridSorular.DataSource = VeritabaniIslemleri.ExecuteDataTable("select * from Sorular");

        private void GridOgrenciYukleme() => gridOgrenciBilgileri.DataSource =
            VeritabaniIslemleri.ExecuteDataTable(
                "select * from Kullanici K  join Ogrenci O on K.KullaniciId=O.KullaniciId ");
        private void OgretmenSayfasi_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e) =>
            Application.Exit();

        public Boolean KontrolEt()
        {
            bool isTrue = true;
            
            if (lookUpTur.ItemIndex == null || txtSoru.Text =="" || txtA.Text == "" || txtB.Text == "" ||
                txtC.Text == "" || txtD.Text == "" || cmbDogruCevap.SelectedItem == null)
                isTrue = false;
            else
                isTrue = true;

            return isTrue;
        }
        public void Temizle()
        {
            lookUpTur.Text = "";
            txtSoru.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            cmbDogruCevap.SelectedItem = "";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (KontrolEt())
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@KonuId", SqlDbType.Int),
                    new SqlParameter("@Soru", SqlDbType.NVarChar),
                    new SqlParameter("@A", SqlDbType.NVarChar),
                    new SqlParameter("@B", SqlDbType.NVarChar),
                    new SqlParameter("@C", SqlDbType.NVarChar),
                    new SqlParameter("@D", SqlDbType.NVarChar),
                    new SqlParameter("@DogruCevap", SqlDbType.NVarChar)
                };
                parameters[0].Value = Convert.ToInt32(lookUpTur.GetColumnValue("Konu Kodu"));
                parameters[1].Value = txtSoru.Text;
                parameters[2].Value = txtA.Text;
                parameters[3].Value = txtB.Text;
                parameters[4].Value = txtC.Text;
                parameters[5].Value = txtD.Text;
                parameters[6].Value = cmbDogruCevap.SelectedItem;
                int eklemeSonuc = VeritabaniIslemleri.ExecuteNonQuery("SoruEkleme", parameters, CommandType.StoredProcedure);

                if (eklemeSonuc == -1)
                {
                    XtraMessageBox.Show("Soru Ekleme İşlemi Yapılamadı", "Hatalı İşlem!", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    Temizle();
                }
                else
                {
                    XtraMessageBox.Show("Soru Ekleme İşlemi Başarılı ", "Geçerli İşlem!", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Temizle();
                }
            }
            else
            {
                XtraMessageBox.Show("Soru Ekleme İşlemi Yapılamadı", "Hatalı İşlem!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Temizle();

            }

            GridSoruYukleme();
        }


        private void gridSorular_Click(object sender, EventArgs e)
        {
            txtSoru2.Text = gridView1.GetFocusedRowCellValue("Soru").ToString();
            txtA2.Text = gridView1.GetFocusedRowCellValue("A").ToString();
            txtB2.Text = gridView1.GetFocusedRowCellValue("B").ToString();
            txtC2.Text = gridView1.GetFocusedRowCellValue("C").ToString();
            txtD2.Text = gridView1.GetFocusedRowCellValue("D").ToString();
            cmbDogruCevap2.Text = gridView1.GetFocusedRowCellValue("DogruCevap").ToString();


            _soru.KonuId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("KonuId"));
            _soru.SoruId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("SoruId"));

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            _soru.SoruMetni = txtSoru2.Text;
            _soru.SoruA = txtA2.Text;
            _soru.SoruB = txtB2.Text;
            _soru.SoruC = txtC2.Text;
            _soru.SoruD = txtD2.Text;
            _soru.DogruCevap = cmbDogruCevap2.Text;
            SqlParameter[] elements = new SqlParameter[]
            {
                    new SqlParameter("@KonuId", SqlDbType.Int),
                    new SqlParameter("@Soru", SqlDbType.NVarChar),
                    new SqlParameter("@A", SqlDbType.NVarChar),
                    new SqlParameter("@B", SqlDbType.NVarChar),
                    new SqlParameter("@C", SqlDbType.NVarChar),
                    new SqlParameter("@D", SqlDbType.NVarChar),
                    new SqlParameter("@DogruCevap", SqlDbType.NVarChar),
                    new SqlParameter("@SoruId",SqlDbType.Int)

            };
            elements[0].Value = _soru.KonuId;
            elements[1].Value = _soru.SoruMetni;
            elements[2].Value = _soru.SoruA;
            elements[3].Value = _soru.SoruB;
            elements[4].Value = _soru.SoruC;
            elements[5].Value = _soru.SoruD;
            elements[6].Value = _soru.DogruCevap;
            elements[7].Value = _soru.SoruId;
            int eklemeSonuc = VeritabaniIslemleri.ExecuteNonQuery("SoruGuncelle", elements, CommandType.StoredProcedure);

            if (eklemeSonuc == 0)
            {
                XtraMessageBox.Show("Soru Güncelleme İşlemi Yapılamadı", "Hatalı İşlem!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Temizle();
            }
            else
            {
                XtraMessageBox.Show("Soru Güncelleme İşlemi Başarılı ", "Geçerli İşlem!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Temizle();
            }
            GridSoruYukleme();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            _soru.SoruMetni = txtSoru2.Text;
            _soru.SoruA = txtA2.Text;
            _soru.SoruB = txtB2.Text;
            _soru.SoruC = txtC2.Text;
            _soru.SoruD = txtD2.Text;
            _soru.DogruCevap = cmbDogruCevap2.Text;
            SqlParameter[] elements = new SqlParameter[]
            {
                new SqlParameter("@SoruId",SqlDbType.Int)

            };
            elements[0].Value = _soru.SoruId;

            int eklemeSonuc = VeritabaniIslemleri.ExecuteNonQuery("SoruSilme", elements, CommandType.StoredProcedure);

            if (eklemeSonuc == 0)
            {
                XtraMessageBox.Show("Soru Silme İşlemi Yapılamadı", "Hatalı İşlem!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Temizle();
            }
            else
            {
                XtraMessageBox.Show("Soru Silme İşlemi Başarılı ", "Geçerli İşlem!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Temizle();
            }
            GridSoruYukleme();
        }

        private void gridOgrenciBilgileri_Click(object sender, EventArgs e)
        {
            _ogrenci.OgrenciNo = Convert.ToInt32(gridView2.GetFocusedRowCellValue("OgrenciNo"));
            _ogrenci.KullaniciAdSoyad = gridView2.GetFocusedRowCellValue("KullaniciAdSoyad").ToString();
            _ogrenci.KullaniciAd = gridView2.GetFocusedRowCellValue("KullaniciAd").ToString();
            _ogrenci.KullaniciId = Convert.ToInt32(gridView2.GetFocusedRowCellValue("KullaniciId"));
            _ogrenci.OgrenciId = Convert.ToInt32(gridView2.GetFocusedRowCellValue("OgrenciId"));


            txtOgrenciNo.Text = _ogrenci.OgrenciNo.ToString();
            txtOgrenciAdSoyad.Text = _ogrenci.KullaniciAdSoyad;
        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            İstatistik frm = new İstatistik();
            frm.Show();
        }
    }
}