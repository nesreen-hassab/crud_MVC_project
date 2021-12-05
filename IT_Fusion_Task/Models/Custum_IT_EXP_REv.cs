using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_Fusion_Task.Models
{
    [MetadataType(typeof(Custum_IT_EXP_REv))]
    public partial class IT_Expenses_Revenues
    { }
    public class Custum_IT_EXP_REv
    {
        [Required(ErrorMessage = "Please Enter The ID...")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please Enter the Date...")]
        [DataType(DataType.Date)]
        public DateTime? Entry_Date { get; set; }
        [Required(ErrorMessage = "Please Enter Peoduct Name...")]
        [StringLength(50, ErrorMessage = "string lenght 50 character")]
        [MinLength(3, ErrorMessage = "minimum lenght 3 character")]
        public string Exp_Rev_Name { get; set; }
        [Required(ErrorMessage = "Please enter Fees...")]
        [DataType(DataType.Currency)]
        public float? Fees { get; set; }
        public string Note { get; set; }
        [Required(ErrorMessage = "Please chooose type (Expenses or Revenues)...")]
        [Range(1, 2, ErrorMessage = "the values is 1 or 2 only ___(Expenses or Revenues)")]
        public int id_ex_re { get; set; }

        public virtual Eexp_Rev_type Eexp_Rev_type { get; set; }
    }
}