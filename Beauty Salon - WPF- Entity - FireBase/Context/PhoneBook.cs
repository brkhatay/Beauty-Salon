using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetraEntity.Context
{
    public class PhoneBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PoneID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Note { get; set; }


    }
}
