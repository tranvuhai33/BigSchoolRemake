using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BigSchoolRemake.Models
{
    public class Course
    {
        public int id { get; set; }
        public ApplicationUser Lecturer { get; set; }
        [Required]
        public string LecturerId { get; set; }
        [Required]
        [StringLength(255)]
        public string Place { get; set; }
        public DateTime datetime { get; set; }
        public Category Category { get; set; }
        [Required]
        public byte CategoryID { get; set; }
    }
}