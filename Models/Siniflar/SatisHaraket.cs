using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHaraket
    {
        [Key]
        public int SatisID { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int UrunID { set; get; }
        public virtual Urun Urun { get; set; }
        public int CariID { set; get; }
        public virtual Cariler Cariler { get; set; }
        public int PersonelID { set; get; }
        public virtual Personel Personel { get; set; }

    }
}