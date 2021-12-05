using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_Fusion_Task.Models
{
    [MetadataType(typeof(Custum_ex_re_type))]
    public partial class Eexp_Rev_type
    { }
    public class Custum_ex_re_type
    {
        public int id_ex_re { get; set; }
        public string ex_re_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IT_Expenses_Revenues> IT_Expenses_Revenues { get; set; }
    }
}