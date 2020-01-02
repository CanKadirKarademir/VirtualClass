using System.Data.SqlClient;
using SanalSınıfOtomasyonu;

namespace SanalSınıfOtomasyonu
{
    public class Ogretmen : Kullanici
    {
        public int OgretmenId { get; set; }
        public int DersId { get; set; }
        public override bool KullaniciTuru()
        {
            return true;
        }
    }
}
