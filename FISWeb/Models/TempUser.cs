//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FISWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TempUser
    {
        public string tempuser_id { get; set; }
        public string descriptions { get; set; }
    
        public virtual User User { get; set; }
    }
}
