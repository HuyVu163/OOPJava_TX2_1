using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace B1
{
    public interface IEmployee
    {
        public int calculateSalary();
        public string getName();
    }

    public abstract class Employee : IEmployee
    {
        private string name;
        private int paymentPerHour;

        public Employee(string name, int paymentPerHour)
        {
            this.name = name;
            this.paymentPerHour = paymentPerHour;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return this.name;
        }
        public int getPaymentPerHour()
        {
            return this.paymentPerHour;
        }
        public void setPaymentPerHour(int paymentPerHour)
        {
            this.paymentPerHour = paymentPerHour;
        }
        public abstract int calculateSalary();


        public override string ToString()
        {
            return $"Name: {name}, PaymentPerHour: {paymentPerHour}";
        }


    }

        public class PartTimeEmployee : Employee
        {
            private int workingHours;

            public int getWorkingHours()
            {
                return workingHours;
            }

            public void setWorkingHours(int workingHours)
            {
                this.setWorkingHours(workingHours);
            }

            public PartTimeEmployee(string name, int paymentPerHour, int workingHours) : base(name, paymentPerHour)
            {
                this.workingHours = workingHours;
            }

            public override int calculateSalary()
            {
                return getWorkingHours() * getPaymentPerHour();
            }

        }

        public class FullTimeEmployee : Employee
        {
            public FullTimeEmployee(string name, int paymentPerHour) : base(name, paymentPerHour)
            {
            }

            public override int calculateSalary()
            {
                return 8 * getPaymentPerHour();
            }
        }
    }
