using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_SQL_PRACTICE_1
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleDataContext db = new SampleDataContext();

            // this returns employee by department 

            string s = string.Empty;
            foreach(var x in db.GetEmployeesByDepartment(1,ref s))
            {
                Console.WriteLine( x.FirstName + " " + x.LastName + " " + x.DepartmentId );
            }

            // code behind 

            /*
            Create procedure GetEmployeesByDepartment
           @DepartmentId int,
             @DepartmentName nvarchar(50) out
              as
          Begin
         Select @DepartmentName = Name
         from Departments where ID = @DepartmentId

           Select* from Employees
           where DepartmentId = @DepartmentId

            End
            */



            // lazy loading 

            foreach(var dept in db.Departments)
            {
                foreach(var emp in dept.Employees)
                {
                    Console.WriteLine(emp.FirstName + emp.LastName);
                }

            }


            // eager loading 

            //trick 1 :  Projection

            





            // projection


            var res = db.Departments.Select(x => new
            {
                dept = x.Name,
                empl = x.Employees

            });

            db.Log = Console.Out;

            foreach(var x in res)
            {
                Console.WriteLine(x.dept);

                foreach(var e in x.empl)
                {
                    Console.WriteLine(e.FirstName + " " + e.LastName);
                }

            }















                
                
                
                      
            }
                      

            }














        }
   