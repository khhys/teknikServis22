//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknikServis
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_UrunKabul
    {
        public int IslemID { get; set; }
        public int Cari { get; set; }
        public Nullable<short> Personel { get; set; }
        public Nullable<System.DateTime> GelisTar { get; set; }
        public Nullable<System.DateTime> CikisTar { get; set; }
        public string UrunSeriNo { get; set; }
    
        public virtual Tbl_Cari Tbl_Cari { get; set; }
        public virtual Tbl_Personel Tbl_Personel { get; set; }
    }
}
