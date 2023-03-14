using System;

namespace DefaultImplementationsInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployee employee = new Employee(2500);
            Console.WriteLine($"The Tax amount is {employee.GetTaxAmount()}");
            Console.ReadKey();
        }
    }

    public interface IEmployee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public double GetTaxAmount()
        {
            return Salary * 0.05;
        }
    }

    public class Employee : IEmployee
    {
        public Employee(double salary)
        {
            Salary = salary;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }


}
