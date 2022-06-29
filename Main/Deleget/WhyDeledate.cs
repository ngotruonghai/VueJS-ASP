namespace DLG;

public interface IPerson
{
    double CalcuLateSalary(double salary);
}
public class Employee : IPerson
{
    public double CalcuLateSalary(double salary)
    {
        // Nếu là nhân viên giảm 10%
        return salary - (salary * 0.1);
    }
}
public class Worker : IPerson
{
    public double CalcuLateSalary(double salary)
    {
        // Nếu là nhân viên giảm 5%
        return salary - (salary * 0.05);
    }
}