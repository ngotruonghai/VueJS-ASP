namespace DLG;
/*
 Yêu càu có 1 List các Person, trong list Person có nhiều loại tuổi khác nhau
    Đặt ra:
        -Với mỗi yêu cầu lọc theo tuổi
 */
// Định nghĩa các điều kiện ở hàm khác nhau
public class OperationFillter
{
    public delegate bool DeledateFillterPerson(Person p);
    public static bool isChild(Person p)
    {
        return p.Age <= 17; // Thiếu niên
    }
    public static bool isAdult(Person p)
    {
        return p.Age >= 18; // Thiếu niên
    }
    public static bool isSenior(Person p)
    {
        return p.Age >= 60; // Thiếu niên
    }
    public static void DisplayPeople(string title, List<Person> listPerson, DeledateFillterPerson deledateFillter)
    {
        Console.WriteLine(title);
        foreach(Person p in listPerson)
        {
            if(deledateFillter(p))
            {
                Console.WriteLine($"Tên là {p.Name} và tuổi là {p.Age}");
            }
        }
    }
}