using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetBankDB.Models
{
    [Table("Customers")]
    public class Customers
    {
        //static int countID = 100;
        //Creates a class for a new customer asing for basic information
        [Key]
        public int userID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string fname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lname { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }

        //[MaxLength(4)]
        //[MinLength(4)]
        //[StringLength(4)]
        [Range(1000, 9999)]
        [Required]
        [Display(Name = "Last 4 Digits of Social Security Number")]
        public int ssn { get; set; }

        [Required]
        [Display(Name ="Address")]
        public string address { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
