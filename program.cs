// 1. Initialize your custom HashSet
MyHashSet<SPSStudent> studentRegistry = new MyHashSet<SPSStudent>();

// 2. Create some student instances
var student1 = new SPSStudent("Warren", "Year 12", "Mr. Anderson");
var student2 = new SPSStudent("Warren", "Year 12", "Mr. Anderson"); // A duplicate
var student3 = new SPSStudent("Jane", "Year 11", "Ms. Stevens");

// 3. Test the Add logic
Console.WriteLine("Adding Student 1...");
studentRegistry.Add(student1);

Console.WriteLine("Adding Student 2 (Duplicate)...");
studentRegistry.Add(student2);

// 4. Verify results
Console.WriteLine($"Is Jane present? {studentRegistry.IsPresent(student3)}");
Console.WriteLine($"Is Warren present? {studentRegistry.IsPresent(student1)}");

// 5. Test your ToString override
Console.WriteLine($"Student Details: {student1}");