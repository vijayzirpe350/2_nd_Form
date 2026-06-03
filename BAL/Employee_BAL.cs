using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{  
    public class Employee_BAL
    {
        Employee_DAL DAL = new Employee_DAL();


        public List<Employee_Model> GetCountry()
        {
          return DAL.GetCountry();
        }

        public List<Employee_Model>State(int id)
        {
            return DAL.State(id);
        }


        public int CreateEmp(Employee_Model EM)
        {
            return DAL.CreateEmp(EM);
        }


        public List<Employee_Model> EmployList()
        {
            return DAL.EmployList();
        }
            





    }
}
