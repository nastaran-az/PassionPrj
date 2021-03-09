using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaloryCounterProject.Models
{
    public class UserWeight
    {
        [Key]
        public int weightId { get; set; }
        public string date { get; set; }
        public int numberweight { get; set; }
        public double weight { get; set; }
        [ForeignKey("User")]
        public int userId;
    }
    public class UserWeightDto
    {
        public int weightId { get; set; }
        [DisplayName("date of this weight")]
        public string date { get; set; }
        [DisplayName("number weight")]
        public int numberweight { get; set; }
        [DisplayName("weight")]
        public double weight { get; set; }
        public int userId;
    }
}