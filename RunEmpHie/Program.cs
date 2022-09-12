using System;
using EmployeeLib;

namespace RunEmployeeLibrary
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Employees employees = new Employees(
                "name1,manager1,56\n"+
                "name2,manager2,20\n" +
                "name3,manager3,89\n"  +
                "name4,'',100\n" +   // ceo               
                "manager1,name4,90\n" + // manager1 under ceo               
                "manager2,name4,90\n" +                
                "manager3,name4,90"
                );

            int salary = employees.managerSalaryBudget("name4");

            Console.WriteLine(salary);
        }
    }
}