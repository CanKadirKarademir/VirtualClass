using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SanalSınıfOtomasyonu
{
    public class Sinav
    {
        public Sinav()
        {
            this.SoruList = new List<Soru>();
        }
        public int SinavId { get; set; }
        public int DersId { get; set; }
        public int KullaniciId { get; set; }
        public int DogruCevap { get; set; }
        public int YanlisCevap { get; set; }
        public DateTime GirisTarihi { get; set; }
        public int OgrenciId { get; set; }
        public List<Soru> SoruList { get; set; }

        public void SoruOlustur(int kullaniciId)
        {
            string notGetId = string.Empty;

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@KullaniciId",SqlDbType.Int)
            };
            sqlParameters[0].Value = kullaniciId;
            SqlDataReader reader = VeritabaniIslemleri.ExecuteReader("SoruGetir", sqlParameters, CommandType.StoredProcedure);
            while (reader.Read())
            {
                Soru item = new Soru
                {
                    SoruA = reader["A"].ToString(),
                    SoruD = reader["D"].ToString(),
                    KonuId = Convert.ToInt32(reader["KonuId"]),
                    SoruMetni = reader["Soru"].ToString(),
                    SoruB = reader["B"].ToString(),
                    DogruCevap = reader["DogruCevap"].ToString(),
                    SoruC = reader["C"].ToString(),
                    SoruId = Convert.ToInt32(reader["SoruId"].ToString())
                };
                if (notGetId == string.Empty)
                    notGetId = item.SoruId.ToString();
                else
                    notGetId += "," + item.SoruId.ToString();
                SoruList.Add(item);
            }

            string notGetIn = notGetId == string.Empty
                ? string.Empty
                : string.Format("where SoruId not in ({0})", notGetId);
            string strquery = string.Format("Select Top({0}) * from Sorular {1} order by NEWID()",
                20 - SoruList.Count, notGetIn);
            SqlDataReader readerNowed = VeritabaniIslemleri.ExecuteReader(strquery);
            while (readerNowed.Read())
            {
                Soru item = new Soru
                {
                    SoruA = readerNowed["A"].ToString(),
                    SoruD = readerNowed["D"].ToString(),
                    KonuId = Convert.ToInt32(readerNowed["KonuId"]),
                    SoruMetni = readerNowed["Soru"].ToString(),
                    SoruB = readerNowed["B"].ToString(),
                    DogruCevap = readerNowed["DogruCevap"].ToString(),
                    SoruC = readerNowed["C"].ToString(),
                    SoruId = Convert.ToInt32(readerNowed["SoruId"].ToString())
                };
                SoruList.Add(item);
            }
        }
    }
}