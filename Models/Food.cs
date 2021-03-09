using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaloryCounterProject.Models
{
    public class Food
    {
        [Key]
        public int foodId { get; set; }
        public string foodName { get; set; }
        public int foodWeight { get; set; }
        public int calory { get; set; }
        public string foodType { get; set; }
    }
    public class FoodDto
    {
        
        public int foodId { get; set; }
        [DisplayName("food name")]
        public string foodName { get; set; }
        [DisplayName("food weight")]
        public int foodWeight { get; set; }
        [DisplayName("amount of calory")]
        public int calory { get; set; }
        [DisplayName("food type")]
        public string foodType { get; set; }
    }
}