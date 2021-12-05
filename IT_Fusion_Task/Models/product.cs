using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Fusion_Task.Models
{
    public class product
    {
        public int ID { get; set; }
        public DateTime? Entry_Date { get; set; }
        public string Exp_Rev_Name { get; set; }
        public decimal? Fees { get; set; }
        public string Note { get; set; }
        public string Exp_Rev_type { get; set; }
    }
}