using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CaloryCounterProject.Models
{
    public class Diet
    {
        [Key]
        public int dietId { get; set; }
        public string dateDiet { get; set; }
        [ForeignKey("UserWeight")]
        public int weightId;

    }
    public class DietDto
    {
        public int dietId { get; set; }
        [DisplayName("Date")]
        public string dateDiet { get; set; }
        public int weightId;
    }
}