using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalSınıfOtomasyonu
{
    public class Sinav
    {
        public int SinavId { get; set; }
        public int DersId { get; set; }
        public int  KullaniciId { get; set; }
        public int DogruCevap { get; set; }
        public int YanlisCevap { get; set; }
        public DateTime GirisTarihi { get; set; }
        public int OgrenciId { get; set; }

    }
}
