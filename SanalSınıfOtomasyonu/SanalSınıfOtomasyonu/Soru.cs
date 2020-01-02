using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalSınıfOtomasyonu
{
    public class Soru : Konu
    {
        public int SoruId { get; set; }
        public string SoruMetni { get; set; }
        public string SoruA { get; set; }
        public string SoruB { get; set; }
        public string SoruC { get; set; }
        public string SoruD { get; set; }
        public string DogruCevap { get; set; }
    }
}
