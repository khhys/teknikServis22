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
    
    public partial class Tbl_Cari
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Cari()
        {
            this.Tbl_FaturaBilgi = new HashSet<Tbl_FaturaBilgi>();
            this.Tbl_UrunHareket = new HashSet<Tbl_UrunHareket>();
            this.Tbl_UrunKabul = new HashSet<Tbl_UrunKabul>();
        }
    
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Banka { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNo { get; set; }
        public string Statu { get; set; }
        public string Adres { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FaturaBilgi> Tbl_FaturaBilgi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UrunHareket> Tbl_UrunHareket { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UrunKabul> Tbl_UrunKabul { get; set; }
    }
}
