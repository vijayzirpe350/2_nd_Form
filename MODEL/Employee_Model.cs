using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
   public  class Employee_Model
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Resume { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
}
