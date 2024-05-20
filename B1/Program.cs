using B1;

class Program
{
    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Add full-time employee");
            Console.WriteLine("2. Add part-time employee ");
            Console.WriteLine("3. Find employee with highest salary");
            Console.WriteLine("4. Find employee by name");
            Console.WriteLine("5. Exit ");
            Console.WriteLine("Chooose an option");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid output.Please enter a number");
            }
            switch (option)
            {
                case 1:
                    AddFullTimeEmployee(employees);
                    break;
                case 2:
                    AddPartTimeEmployee(employees);
                    break;
                case 3:
                    FindHighestSalaryEmployee(employees);
                    break;
                case 4:
                    FindEmployeeByName(employees);
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }

    static void AddFullTimeEmployee(List<Employee> employees)
    {
        try
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter payment per hour: ");
            int paymentPerHour = int.Parse(Console.ReadLine());
            employees.Add(new FullTimeEmployee(name, paymentPerHour));
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter correct data.");
        }
    }

    static void AddPartTimeEmployee(List<Employee> employees)
    {
        try
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter payment per hour: ");
            int paymentPerHour = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter working hours: ");
            int workingHours = int.Parse(Console.ReadLine());
            employees.Add(new PartTimeEmployee(name, paymentPerHour, workingHours));
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter correct data.");
        }
    }

    static void FindHighestSalaryEmployee(List<Employee> employees)
    {
        if (employees.Count == 0)
        {
            Console.Write("No employees found.");
            return;
        }

        var highestSalaryEmployee = employees.OrderByDescending(e => e.calculateSalary()).FirstOrDefault();
        Console.WriteLine($"Employee with highest salary: {highestSalaryEmployee}");
    }

    static void FindEmployeeByName(List<Employee> employees)
    {
        Console.WriteLine("Enter name to search: ");
        string name = Console.ReadLine();

        var foundEmployees = employees.Where(e => e.getName().Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundEmployees.Count == 0)
        {
            Console.WriteLine("No employees found with the given name.");
        }
        else
        {
            foreach (var employee in foundEmployees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}