MyHashSet<SPSStudent> students = new MyHashSet<SPSStudent>(3, "LinearProbing");

var warren = new SPSStudent("Warren", "Year 12", "CAH");
var warrenDuplicate = new SPSStudent("Warren", "Year 12", "CAH");
var Toby = new SPSStudent("Toby", "Year 11", "JBT");
var Duy = new SPSStudent("Duy", "Year 13", "MKL");
var Ates = new SPSStudent("Ates", "Year 12", "CAH");

students.Add(warren);
students.Add(warrenDuplicate);
students.Add(Toby);
students.Add(Duy);        
students.Add(Ates);

Console.WriteLine(students.IsPresent(warren));
Console.WriteLine(students.IsPresent(warrenDuplicate));
Console.WriteLine(students.IsPresent(new SPSStudent("NOTPRESENT", "Year 12", "AAA"))); 