using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetraEntity.Context
{
    public class CustomerLOG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        
        public string Clock { get; set; }
        public string CustomerOne { get; set; }
        public string BeforeCustomerOne { get; set; }

        public string psOne { get; set; }
        public string BeforepsOne { get; set; }

        public string CustomerTwo { get; set; }
        public string BeforeCustomerTwo { get; set; }

        public string psTwo { get; set; }
        public string BeforepsTwo { get; set; }

        public string CustomerThree { get; set; }
        public string BeforeCustomerThree { get; set; }

        public string psThree { get; set; }
        public string BeforepsThree { get; set; }

        public DateTime updateDate { get; set; }
    }
}
