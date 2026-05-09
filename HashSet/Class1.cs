//SPSSTUDENT CLASS

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


//HASHSET CLASS
public class MyHashSet<T>: IHashSet<T> where T: SPSStudent, IEquatable<T>
{
    private List<T?> _linearProbingList;
    private List<List<T>> _chainingList;
    private int _listSize;
    private int count;
    private readonly string _collisionStrategy;
    private const double LoadFactor = 0.75;


    public MyHashSet(int listSize, string collisionStrategy)
    {
        _listSize = listSize;
        count = 0;
        _collisionStrategy = collisionStrategy;

        if(_collisionStrategy == "LinearProbing")
        {
            _linearProbingList = new List<T?>();
            for(int i = 0; i < _listSize; i++)
            {
                _linearProbingList.Add(null);
            }
        }
        else
        {
            _chainingList = new List<List<T>>();
            for(int i = 0; i < _listSize; i++)
            {
                _chainingList.Add(new List<T>());
            }
        }
    }

    public bool IsPresent(T value)
    {
        if(_collisionStrategy == "LinearProbing")
        {
            int index = Index(value);
            int startIndex = index;
            while(_linearProbingList[index] != null)
            {
                if (_linearProbingList[index]!.Equals(value)) return true;
                index = (index + 1) % _listSize;
                if (index == startIndex) break;
            }
            return false;
        }
        else
        {
            foreach(List<T> l in _chainingList)
            {
                if(l.Contains(value)) return true;
            }
            return false;
        }
    }

    public int Index(T value)
    {
        int hashCode = Math.Abs(value.GetHashCode());
        return hashCode % _listSize;
    }


    public T Add(T value)
    {
        int index = Index(value);

        if((double)count / _listSize >= LoadFactor) Rebalance();

        if(_collisionStrategy == "LinearProbing")
        {
            while(_linearProbingList[index] != null)
        {
            if (_linearProbingList[index].Equals(value)) 
            {
                Console.WriteLine("Duplicate");
                return value;
            }
            index = (index + 1) % _listSize;// wrap back to beginning
        }

        _linearProbingList[index] = value;
        count++;
        return value;
        }
        else
        {
            if(!_chainingList[index].Contains(value))
            {
                _chainingList[index].Add(value);
                count++;
            }
            else
            {
                Console.WriteLine("Duplicate");
            }
            return value;
        }
    }
    
    public void Rebalance()
    {
        int oldListSize = _listSize;
        _listSize *= 2;
        count = 0;

        if(_collisionStrategy == "LinearProbing")
        {
            List<T?> oldList = _linearProbingList;
            _linearProbingList = new List<T?>();

            for(int i = 0; i < _listSize; i++) _linearProbingList.Add(null);

            foreach(var t in oldList)
            {
                if(t != null) this.Add(t);
            }
        }
        else
        {
            List<List<T>> oldList = _chainingList;
            _chainingList = new List<List<T>>();

            for(int i = 0; i < _listSize; i++) _chainingList.Add(new List<T>());

            foreach(var i in oldList)
            {
                foreach(var j in i) this.Add(j);
            }
        }

        Console.WriteLine("Rebalanced");
    }
}




//INTERFACES
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