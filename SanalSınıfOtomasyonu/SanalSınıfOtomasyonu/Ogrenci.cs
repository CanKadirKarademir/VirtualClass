using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SanalSınıfOtomasyonu
{
    public class Ogrenci : Kullanici
    {
        public int OgrenciId { get; set; }
        public int OgrenciNo { get; set; }
        public override bool KullaniciTuru()
        {
            return false;
        }
        public Sinav Sinav { get; set; }

        public void SinavBaslat(int kullaniciId)
        {
            Sinav item = new Sinav();
            item.SoruOlustur(kullaniciId);
            Sinav = item;
        }
    }
}