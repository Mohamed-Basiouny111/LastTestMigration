using ConsoleApp1.Data;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Topics*/
            //Loading strategies => return related Data
            /* --types of Loading strategies
             * 1-Explicit Load
             * 2-Lazy Load (Case: Make Navigation property define (Virtual) to avoid Exception , useing nuget by Backge Proxies)
             * 3-Eager Load
             */
            //creational strateges incase inheritance
            /* exist three stratigy for creation:-
             * 1-table per hairalicy (TPH) => is Default stratigy
             * 2-table per concrete class(can make object(use abstract Class)) (TPC)
             * 3-table per type (TPT)
            */
            //tracking
            /*
             * Default entity is traking
             * AsNotraking=> Like Readonly and can't updated in database
             */
            //how to run sql statement : stord from db , create stpred from code

            Console.WriteLine("Hello, World!");
            //DotnetContext db = new DotnetContext();
            //db.Database.EnsureDeleted();

            //Student std = new Student() { Name = "Mohamed", Degree = 20, Age = 21 };
            //Employee emp = new Employee() { Name = "Ismail", Salary = 2000, Age = 25 };

            //db.students.Add(std);
            //db.Employees.Add(emp);
            //db.people.Add(std);
            //db.people.Add(emp);

            //Console.WriteLine(db.Employees.Count());
            //Console.WriteLine(db.students.Count());
            //Console.WriteLine(db.people.Count());
            //using (DotnetContext db = new DotnetContext())
            //{
            //db.Departments.AddRange(
            //    new Department() { DeptName = "PD" },
            //    new Department() { DeptName = "OS" },
            //    new Department() { DeptName = "EL" }
            //);

            // db.Employees.AddRange(
            //    new Employee() { Name = "empone", Salary = 200, deptNo = 1 },
            //    new Employee() { Name = "emptwo", Salary = 200, deptNo = 2 },
            //    new Employee() { Name = "empthree", Salary = 200, deptNo = 1 },
            //    new Employee() { Name = "emptfour", Salary = 200, deptNo = 1 }

            //);

            #region Loading strategies
            //Get Related Data => Before Create instance from Navigation property and return Null Exception
            //var emp = db.Employees.FirstOrDefault(e => e.Id == 1);  
            //Console.WriteLine(emp.Department.DeptName); //return NULL Exception If Can't create instance (new) from Navigation Property

            //Get Related Data => After Create instance from Navigation property and return Empty
            //var emp = db.Employees.FirstOrDefault(e => e.Id == 1);
            //Console.WriteLine(emp.Department.DeptName);

            //Eager Loading
            //var dept = db.Departments.Include(e=>e.Employees).FirstOrDefault(e => e.Id == 1);
            //foreach (var item in dept.Employees)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //ThenInclude depend on another befor Include
            //var emp = db.Employees.Include(e => e.Department).ThenInclude(x=>x.Employees).FirstOrDefault(e => e.Id == 1);
            //Console.WriteLine(emp?.Department?.DeptName);

            //Explicit Load
            //--1-Collection
            //var dept = db.Departments.FirstOrDefault(e => e.Id == 1);
            //db.Entry(dept).Collection(c => c.Employees).Load();
            //foreach (var item in dept.Employees)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //--2-References
            //var emp = db.Employees.FirstOrDefault(e => e.Id == 1);
            //db.Entry(emp).Reference(e=>e.Department).Load();       
            //Console.WriteLine(emp.Name);

            //Lazy Load => this is the best way for perfermance
            //Don't Load Data if don't use , when use or call loading it 
            //var dept = db.Departments.FirstOrDefault(e => e.Id == 1);//Don' Load Collection if don't use
            //foreach (var item in dept.Employees)//in this Line Load Collection
            //{
            //    Console.WriteLine(item.Name);
            //}

            #endregion

            #region tracking
            //var emp = db.Employees.FirstOrDefault(e => e.Id == 1);
            //Console.WriteLine(db.Entry(emp).State);//Unchanged
            //emp.Name = "Mohamed Basiouny";
            //Console.WriteLine(db.Entry(emp).State);//Modified 

            //var emp = db.Employees.AsNoTracking().FirstOrDefault(e => e.Id == 1);//can't add changes
            //emp.Name = "Mohamed Basiouny";
            //Console.WriteLine(db.Entry(emp).State);//Detached 

            //After Notraking in all database(Make Read only)
            //var emp = db.Employees.FirstOrDefault(e => e.Id == 1);//can't add changes
            //emp.Name = "Mohamed Basiouny";
            //Console.WriteLine(db.Entry(emp).State);//Detached 


            #endregion
            // db.SaveChanges();
            //}
            DotnetContext db = new DotnetContext();

            #region Server or client processing
            //var emp = db.Employees.Select(e => new { e.Id, EName = e.Salary + "" + e.Name });
            //Console.WriteLine(emp.ToQueryString());
            ////Console.WriteLine(emp.ToList()[0].EName);
            #endregion

            #region Run SQL in EF
            //var result = db.Employees.FromSql($"select * from Employees"); //return select * only

            //var result = db.Employees.FromSql($"select Name, Salary from Employees"); //must create type from selected column 
            //var result = db.Database.SqlQuery<halfEmployee>($"select Name, Salary from Employees");  //Solve type is halfEmployee
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region running Stord
            // var result = db.Employees.FromSql($"exec loadallemployees"); //return all data 
            //var result = db.Database.SqlQuery<halfEmployee>($"exec loadsomeemployees"); //if Stord return Some Data, use SqlQuery<new type>
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Name);
            //}
            #endregion


            #region Seperated Configuration 
            //typeof(Student).Assembly => return assemply name , can use any type like student or any type in assemply 
            //Console.WriteLine(typeof(Student).Assembly);
            #endregion

            #region test stord that add by migration 
            //var result = db.Departments.FromSql($"exec LoadDepartment");
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.DeptName);
            //}
            #endregion
        }
    }

    #region Run SQL in EF
    public class halfEmployee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
    }
    #endregion
}
