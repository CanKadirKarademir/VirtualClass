using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SanalSınıfOtomasyonu
{
    public partial class OgrenciSayfasi : DevExpress.XtraEditors.XtraForm
    {
        public OgrenciSayfasi()
        {
            
        }
        private Ogrenci _ogrenci;
        private int _soruIndis = 0;
        private Soru _soru = new Soru();
        public OgrenciSayfasi(Ogrenci ogrenci)
        {
            _ogrenci = ogrenci;
            InitializeComponent();
        }

        private void SoruGetir(int soruIndis)
        {
            txtSoru.Text = _ogrenci.Sinav.SoruList[soruIndis].SoruMetni;
            txtA.Text = _ogrenci.Sinav.SoruList[soruIndis].SoruA;
            txtB.Text = _ogrenci.Sinav.SoruList[soruIndis].SoruB;
            txtC.Text = _ogrenci.Sinav.SoruList[soruIndis].SoruC;
            txtD.Text = _ogrenci.Sinav.SoruList[soruIndis].SoruD;

            _soru.SoruMetni = _ogrenci.Sinav.SoruList[soruIndis].SoruMetni;
            _soru.SoruA = _ogrenci.Sinav.SoruList[soruIndis].SoruA;
            _soru.SoruB = _ogrenci.Sinav.SoruList[soruIndis].SoruB;
            _soru.SoruC = _ogrenci.Sinav.SoruList[soruIndis].SoruC;
            _soru.SoruD = _ogrenci.Sinav.SoruList[soruIndis].SoruD;
            _soru.SoruId = _ogrenci.Sinav.SoruList[soruIndis].SoruId;
            _soru.DogruCevap = _ogrenci.Sinav.SoruList[soruIndis].DogruCevap;
            _soru.KonuId = _ogrenci.Sinav.SoruList[soruIndis].KonuId;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OgrenciSayfasi_Load(object sender, EventArgs e)
        {
            lblAdSoyad.Text = _ogrenci.KullaniciAdSoyad;
            lblOgrenciNo.Text = _ogrenci.OgrenciNo.ToString();
        }
        private void OgrenciSayfasi_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        public int[,] Cozumler = new int[20, 2];
        private void btnIlerle_Click(object sender, EventArgs e)
        {
            if (radioGroupCevaplar.SelectedIndex == 0 && _soru.DogruCevap == "A")
            {
                /* Doğru çözümler 1 yanlışlar 0 */
                Cozumler[_soruIndis, 0] = _soru.SoruId;
                Cozumler[_soruIndis, 1] = 1;
            }
            else if (radioGroupCevaplar.SelectedIndex == 1 && _soru.DogruCevap == "B")
            {
                Cozumler[_soruIndis, 0] = _soru.SoruId;
                Cozumler[_soruIndis, 1] = 1;
            }
            else if (radioGroupCevaplar.SelectedIndex == 2 && _soru.DogruCevap == "C")
            {
                Cozumler[_soruIndis, 0] = _soru.SoruId;
                Cozumler[_soruIndis, 1] = 1;
            }
            else if (radioGroupCevaplar.SelectedIndex == 3 && _soru.DogruCevap == "D")
            {
                Cozumler[_soruIndis, 0] = _soru.SoruId;
                Cozumler[_soruIndis, 1] = 1;
            }
            else
            {
                Cozumler[_soruIndis, 0] = _soru.SoruId;
                Cozumler[_soruIndis, 1] = 0;
            }

            if (_soruIndis < _ogrenci.Sinav.SoruList.Count - 1)
            {
                _soruIndis++;
                SoruGetir(_soruIndis);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            if (radioGroupCevaplar.SelectedIndex == 0 && _soru.DogruCevap == "A")
            {
                /* Doğru çözümler 1 yanlışlar 0 */
                Cozumler[_soruIndis, 0] = _soru.SoruId;
                Cozumler[_soruIndis, 1] = 1;
            }
            else if (radioGroupCevaplar.SelectedIndex == 1 && _soru.DogruCevap == "B")
            {
                Cozumler[_soruIndis, 0] = _soru.SoruId;
                Cozumler[_soruIndis, 1] = 1;
            }
            else if (radioGroupCevaplar.SelectedIndex == 2 && _soru.DogruCevap == "C")
            {
                Cozumler[_soruIndis, 0] = _soru.SoruId;
                Cozumler[_soruIndis, 1] = 1;
            }
            else if (radioGroupCevaplar.SelectedIndex == 3 && _soru.DogruCevap == "D")
            {
                Cozumler[_soruIndis, 0] = _soru.SoruId;
                Cozumler[_soruIndis, 1] = 1;
            }
            else
            {
                Cozumler[_soruIndis, 0] = _soru.SoruId;
                Cozumler[_soruIndis, 1] = 0;
            }

            if (_soruIndis > 0)
            {
                _soruIndis--;
                SoruGetir(_soruIndis);
            }
        }

        private void btnBitir_Click(object sender, EventArgs e)
        {
            int DogruToplam = 0;
            int YanlisToplam = 0;
            for (int k = 0; k < 19; k++)
            {
                DogruToplam += Cozumler[k, 1];
            }

            YanlisToplam = (20 - DogruToplam);
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@KullaniciId", SqlDbType.Int),
                new SqlParameter("@DogruCevap", SqlDbType.NVarChar),
                new SqlParameter("@YanlisCevap", SqlDbType.NVarChar),
                new SqlParameter("@AldigiPuan", SqlDbType.Int),
                new SqlParameter("@GirisTarihi", SqlDbType.DateTime),
                new SqlParameter("@OgrenciId", SqlDbType.Int)
            };
            parameters[0].Value = Convert.ToInt32(_ogrenci.KullaniciId);
            parameters[1].Value = DogruToplam.ToString();
            parameters[2].Value = YanlisToplam.ToString();
            parameters[3].Value = (DogruToplam * 5);
            parameters[4].Value = DateTime.Today; 
            parameters[5].Value = _ogrenci.OgrenciId;

            int SinavId = Convert.ToInt32(VeritabaniIslemleri.ExecuteScalar("SinavOlustur",parameters,CommandType.StoredProcedure));

            
                MessageBox.Show("Test"+SinavId.ToString());
           
            for (int i = 0; i < 19; i++)
            {
                SqlParameter[] elements = new SqlParameter[]
                {
                    new SqlParameter("@SınavId",SqlDbType.Int),
                    new SqlParameter("@SoruId", SqlDbType.Int),
                    new SqlParameter("@Durum", SqlDbType.Bit)
                };
                elements[0].Value = SinavId;
                elements[1].Value = Cozumler[i, 0];
                elements[2].Value = Cozumler[i, 1];
                VeritabaniIslemleri.ExecuteNonQuery("CozumEkleme", elements, CommandType.StoredProcedure);
            }
            XtraMessageBox.Show("Soru Ekleme İşlemi Başarılı ", "Geçerli İşlem!", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            Application.Exit();
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            _ogrenci.SinavBaslat(_ogrenci.KullaniciId);
            _soruIndis = 0;
            SoruGetir(_soruIndis);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            İstatistik frm = new İstatistik();
            frm.Show();
        }
    }
}