using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetBankDB.Models
{
    [Table("Accounts")]
    public class Accounts
    {
        //static int countID = 200;
        //Creates a class for a new customer asing for basic information
        public int userID { get; set; }

        [Key]
        public int accountID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? dateCreated { get; set; }

        [Required]
        public string accountType { get; set; }

        public double? balance { get; set; }

        [Required]
        public double? interest { get; set; }

        [DataType(DataType.Date)]
        public DateTime? dateInterest { get; set; }

        public int? imf { get; set; }
    }
}
