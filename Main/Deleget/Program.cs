using System;
using System.Text;
namespace DLG;

// Khai báo Delegate
public delegate int SumDelegate(int x, int y);
public delegate void DisplayDelegate(int sum);
// for Munticast
public delegate void DelegateMath(int x, int y);


public class Program
{
    // Khai báo deledate thay thế interface
    public delegate double PersonSalary(double x);

    public static void Main(string[] args)
    {
        // Cấu hình Console hiểu Unicode
        Console.OutputEncoding = Encoding.UTF8;

        Program obj = new Program();
        // Gọi phương thức
        //obj.Display(obj.Sum(10, 20)); /*Gọi hàm theo cách thông thường*/

        // Gọi theo Delegate
        // Khởi tạo instance (object) cho delegate: Single delegate
        SumDelegate sum = obj.Sum;
        DisplayDelegate display = obj.Display;
        // Execute
        int total = sum(100, 20);
        display(total);


        //Munticast Delegate
        //Trường hợp 1 có thể += hoặc -= để remove delegate
        //DelegateMath math = new DelegateMath(Program.Add);
        //math += Program.Sub;

        // Trường hợp 2
        Console.WriteLine("=============================Deledate==============================");
        DelegateMath d1 = new DelegateMath(Add);
        DelegateMath d2 = new DelegateMath(Sub);
        DelegateMath d3 = Multiply;
        DelegateMath d4 = d1 + d2 + d3;
        d4.Invoke(10, 20);
        Console.WriteLine("\n (1) Deledate trừ ra d2");
        d4 -= d2;
        d4.Invoke(10, 20);
        Console.WriteLine("\n =============================Begin Interface Demo==============================");
        double employee = CalculationSalary(new Employee(), 100);
        Console.WriteLine($"Lương công nhân là: {employee}");

        Console.WriteLine("\n =============================Begin Interface Using Deledate Demo==============================");
        // Định nghĩa cách tính lương
        // Lợi thé: không cần new(), đơn giản trỏ tới hàm mong muốn
        double employeedelegate = CalculationSalaryDeledate(GetSalaryByEmploy, 1000);
        Console.WriteLine($"Lương nhân viên là: {employeedelegate}");

        Console.WriteLine("\n =============================Begin call back Deledate==============================");
        List<Person> list = new List<Person>();
        Random rand = new Random();
        for (int i = 0; i < 10; i++)
        {
            Person person = new Person
            {
                Name = $"Thằng số {i + 1}",
                Age = rand.Next(0, 100)
            };
            list.Add(person);
        }
        OperationFillter.DisplayPeople("isChild", list, OperationFillter.isChild);
        OperationFillter.DisplayPeople("isSenior", list, OperationFillter.isSenior);
        OperationFillter.DisplayPeople("isAdult", list, OperationFillter.isAdult);
    }
    public int Sum(int a, int b)
    {
        return a + b;
    }
    public void Display(int sum)
    {
        Console.WriteLine($"Tổng 2 số  = {sum}");
    }

    // Giả sữ ta có nhieu62 phương thức thực hiện nhiều việc
    public static void Add(int x, int y)
    {
        Console.WriteLine($"Tổng 2 số {x} và {y} là= {x + y}");
    }
    public static void Sub(int x, int y)
    {
        Console.WriteLine($"Hiệu 2 số {x} và {y} là= {x - y}");
    }
    public static void Multiply(int x, int y)
    {
        Console.WriteLine($"Nhân 2 số {x} và {y} là= {x / y}");
    }

    // Hàm trả ra lương
    public static double CalculationSalary(IPerson p, double salary)
    {
        return p.CalcuLateSalary(salary);
    }

    // Định nghĩa cách tính lương cho Deledate
    public static double CalculationSalaryDeledate(PersonSalary p, double salary)
    {
        return p.Invoke(salary);
    }
    public static double GetSalaryByEmploy(double a)
    {
        return a - (a * 0.1);
    }
    public static double GetSalaryByWork(double a)
    {
        return a - (a * 0.05);
    }
}