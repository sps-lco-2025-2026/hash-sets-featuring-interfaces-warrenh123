MyHashSet<SPSStudent> students = new MyHashSet<SPSStudent>(3);


var student1 = new SPSStudent("Warren", "Year 12", "CAH");
var student2 = new SPSStudent("Warren", "Year 12", "CAH"); //duplicate


students.Add(student1);
students.Add(student2);

Console.WriteLine(students.IsPresent(student1));
Console.WriteLine(students.IsPresent(student2));
Console.WriteLine(student2);