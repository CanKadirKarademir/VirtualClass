using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SanalSınıfOtomasyonu
{
    public partial class OgrenciSayfasi : DevExpress.XtraEditors.XtraForm
    {
        private Ogrenci _ogrenci;
        public OgrenciSayfasi(Ogrenci ogrenci)
        {
            _ogrenci = ogrenci;
            InitializeComponent();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OgrenciSayfasi_Load(object sender, EventArgs e)
        {
            lblAd.Text = _ogrenci.KullaniciAd;
            lblOgrenciNo.Text = _ogrenci.OgrenciNo.ToString();
        }

        private void OgrenciSayfasi_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();
    }
}