MyStudent s1 = new MyStudent("Ates", "12", "PG");
Console.WriteLine(s1);


public class MyStudent: SPSStudent
{
    public string Name { get; private set; }
    public string Year { get; private set; }
    public string Tutor { get; private set; }

    public bool Equals(SPSStudent? other)
    {
        if (other == null) return false;
        return Name == other.Name && Year == other.Year && Tutor == other.Tutor;
    }
    public MyStudent(string name, string year, string tutor)
    {
        Name = name;
        Year = year;
        Tutor = tutor;
    }
    public override string ToString()
    {
        return $"{Name} Year:{Year} Tutor:{Tutor}";
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ Year.GetHashCode() ^ Tutor.GetHashCode();
    }
}
public interface IHashSet<T> 
    where T : SPSStudent, IEquatable<T>
{
    T Add(T value);
    bool IsPresent(T value);
    void Rebalance();
}

public interface SPSStudent : IEquatable<SPSStudent>
{
    string Name { get; }
    string Year { get; }
    string Tutor { get; }
}

