//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IT_Fusion_Task.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class IT_Expenses_Revenues
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> Entry_Date { get; set; }
        public string Exp_Rev_Name { get; set; }
        public Nullable<decimal> Fees { get; set; }
        public string Note { get; set; }
        public int id_ex_re { get; set; }
    
        public virtual Eexp_Rev_type Eexp_Rev_type { get; set; }
    }
}
