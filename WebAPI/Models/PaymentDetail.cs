using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // needed for the key attribute
using System.ComponentModel.DataAnnotations.Schema; // needed for the column attribute
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    // this defines the entity which will be put in the database as a table    
    public class PaymentDetail
    {
        [Key] // PMId will be the primary key for PaymentDetail
        public int PMId { get; set; }
        [Required] // all of these properties are mandatory to insert a payment detail
        [Column(TypeName = "nvarchar(100)")]  // sets the corresponding SQL data type for the string properties
        public string CardOwnerName { get; set; }
        [Required]
        [Column(TypeName = "varchar(16)")]
        public string CardNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public string ExpirationDate { get; set; }
        [Required]
        [Column(TypeName = "varchar(3)")]
        public string CVV { get; set; }
    }
}
