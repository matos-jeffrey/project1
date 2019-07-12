using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetBankDB.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        //static int countID = 100;
        //Creates a class for a new customer asing for basic information
        [Key]
        public int id { get; set; }

        [Required]
        public int accountID { get; set; }

        [Required]
        public int userID { get; set; }

        [Required]      
        public DateTime transactionDate { get; set; }

        [Required]
        public string transactionProcessed { get; set; }
    }
}
