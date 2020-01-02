using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalSınıfOtomasyonu
{
    public abstract class Kullanici
    {
        public int KullaniciId { get; set; }
        public string KullaniciAd { get; set; }
        public string KullaniciAdSoyad { get; set; }
        public string KullaniciSifre { get; set; }
        public abstract Boolean KullaniciTuru();
    }
}
