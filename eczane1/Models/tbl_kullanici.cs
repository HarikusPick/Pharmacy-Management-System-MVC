//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eczane1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_kullanici
    {
        public int kullanici_id { get; set; }
        public string kullanici_nickname { get; set; }
        public string kullanici_password { get; set; }
        public string kullanici_ad { get; set; }
        public string kullanici_soyad { get; set; }
        public string kullanici_telefon { get; set; }
        public Nullable<int> rol_id { get; set; }
    
        public virtual tbl_rol tbl_rol { get; set; }
    }
}
