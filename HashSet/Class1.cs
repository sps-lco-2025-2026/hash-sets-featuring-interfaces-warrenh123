public class SPSStudent: ISPSStudent
{
    private readonly string _name;
    private readonly string _year;
    private readonly string _tutor;

    public string Name => _name;
    public string Year => _year;
    public string Tutor => _tutor;
    

    public bool Equals(SPSStudent? other)
    {
        if (other == null) return false;
        return Name == other.Name && Year == other.Year && Tutor == other.Tutor;
    }
    public SPSStudent(string name, string year, string tutor)
    {
        _name = name;
        _year = year;
        _tutor = tutor;
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

public class MyHashSet<T>: IHashSet<T> where T: SPSStudent, IEquatable<T>
{
    private readonly List<T> _listOfItems = new List<T>();

    public MyHashSet(){ }

    public bool IsPresent(T value)
    {
        return _listOfItems.Contains(value);
    }

    public T Add(T value)
    {
        if(!IsPresent(value))
        {
            _listOfItems.Add(value);
            return value;
        }
        else
        {
            return null;
        }
    }

    public void Rebalance()//just for build
    {
        Console.WriteLine("Rebalancing....");
    }
   
}


public interface IHashSet<T> where T : SPSStudent, IEquatable<T>
{
    T Add(T value);
    bool IsPresent(T value);
    void Rebalance();
}

public interface ISPSStudent : IEquatable<SPSStudent>
{
    string Name { get; }
    string Year { get; }
    string Tutor { get; }
}