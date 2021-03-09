using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaloryCounterProject.Models
{
    public class Foodxdiet
    {
        [Key]
        public int FdId { get; set; }
        [ForeignKey("Diet")]
        public int dietId { get; set; }
        [ForeignKey("Food")]
        public int foodId { get; set; }
        public virtual Diet Diet { get; set; }
        public virtual Food Food { get; set; }
    }
    public class FoodxdietDto
    {
        public int FdId { get; set; }
        public int dietId { get; set; }
        public int foodId { get; set; }
      
    }
}