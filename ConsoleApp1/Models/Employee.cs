using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    #region For strategies
    //public class Employee : Person
    //{
    //    public int Salary { get; set; }

    //} 
    #endregion

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        [ForeignKey("Department")]
        public int deptNo { get; set; }
        //public virtual Department Department { get; set; } //return NULL Exception when use data of department, If Can't create instance 
        public virtual Department Department { get; set; } = new Department(); //return empty,because craete instance 
    }

    public class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }

        //navigation property
        //Befor Lazy Loading
        //public List<Employee> Employees { get; set; } = new List<Employee>();

        //After Lazy Loading
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
