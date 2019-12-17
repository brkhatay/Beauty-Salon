using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetraEntity.Context
{
   public  class Customer
    {
        public int CustomerID { get; set; }

        public string CustomerOne { get; set; }

        public string psOne { get; set; }

        public string CustomerTwo { get; set; }

        public string psTwo { get; set; }

        public string CustomerThree { get; set; }

        public string psThree { get; set; }

        public int? dayID { get; set; }

        public int? ClockID { get; set; }
    }
}
