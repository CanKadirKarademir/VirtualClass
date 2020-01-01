using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SanalSınıfOtomasyonu
{
    public partial class OgretmenSayfasi : DevExpress.XtraEditors.XtraForm
    {
        public OgretmenSayfasi()
        {
            InitializeComponent();
        }

        private void OgretmenSayfasi_Load(object sender, EventArgs e)
        {
            gridOgrenciBilgileri.DataSource = VeritabaniIslemleri.ExecuteDataTable("Select * From Ogrenci");
        }
    }
}