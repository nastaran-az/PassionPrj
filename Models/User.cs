using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaloryCounterProject.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string lname { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public double userHeight { get; set; }

        //One user Many Weight
        public ICollection<UserWeight> NweightId { get; set; }
        //one user Many diet
        public ICollection<Diet> Ndiet { get; set; }
    }

    public class UserDto
    {       
        public int Id { get; set; }
        [DisplayName("first name")]
        public string name { get; set; }
        [DisplayName("last name")]
        public string lname { get; set; }
        [DisplayName("user age")]
        public int age { get; set; }
        [DisplayName("user gender")]
        public string gender { get; set; }
        [DisplayName("user height")]
        public double userHeight { get; set; }
       }
}