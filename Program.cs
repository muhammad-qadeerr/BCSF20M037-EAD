using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAD_A3
{
    //Question-1,d

    class Book
    {
        public string Title { get; }
        public string Author { get; }

        public Book(string title, string author = "Unknown")
        {
            Title = title;
            Author = author;
        }
    }

    //2-Generics: 
    //a.MyList<T> generic class: 
    class MyList<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public bool Remove(T item)
        {
            return items.Remove(item);
        }

        public void Display()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
    class Program
    {
        //Question-1,a 
        static void Greet(string greeting = "Hello", string name = "World")
        {
            Console.WriteLine($"{greeting}, {name}!");
        }
        //Question-1,b
        static double CalculateArea(double length = 1.0, double width = 1.0)
        {
            return length * width;
        }
        //Question-1,c 
        static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        static int AddNumbers(int a, int b, int c = 0)
        {
            return a + b + c;
        }
        //2-Generics: 
        //b- Swap<T> generic method: 
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        static T Sum<T>(params T[] values)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(double))
            {
                dynamic sum = 0;
                foreach (T value in values)
                {
                    sum += value;
                }
                return sum;
            }
            else
            {
                throw new ArgumentException("Unsupported data type");
            }
        }
        static Dictionary<int, string> studentDatabase = new Dictionary<int, string>();
        static void InitializeDatabase()
        {
            studentDatabase.Add(101, "Alice");
            studentDatabase.Add(102, "Bob");
            studentDatabase.Add(103, "Charlie");
            studentDatabase.Add(104, "David");
        }

        static void DisplayStudentDatabase()
        {
            Console.WriteLine("Student Database:");
            foreach (var entry in studentDatabase)
            {
                Console.WriteLine($"Student ID: {entry.Key}, Name: {entry.Value}");
            }
        }

        static void SearchStudentByID()
        {
            Console.Write("Enter student ID: ");
            int studentID = int.Parse(Console.ReadLine());
            if (studentDatabase.ContainsKey(studentID))
            {
                Console.WriteLine($"Student ID: {studentID}, Name: {studentDatabase[studentID]}");
            }
            else
            {
                Console.WriteLine("Student ID not found.");
            }
        }

        static void UpdateStudentName()
        {
            Console.Write("Enter student ID: ");
            int idToUpdate = int.Parse(Console.ReadLine());
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();
            if (studentDatabase.ContainsKey(idToUpdate))
            {
                studentDatabase[idToUpdate] = newName;
                Console.WriteLine("Name updated successfully.");
            }
            else
            {
                Console.WriteLine("Student ID not found.");
            }
        }
        static void Main(string[] args)
        {
            //Question-1,a 

            Greet();
            Greet("Hello");
            Greet("Hello", "Ali");
            Console.WriteLine();

            //Question-1,b 

            double area1 = CalculateArea(); // Default value 
            double area2 = CalculateArea(4.5);
            double area3 = CalculateArea(3.0, 2.0);
            Console.WriteLine(area1);
            Console.WriteLine(area2);
            Console.WriteLine(area3);
            Console.WriteLine();

            //Question-1,c 

            int sum1 = AddNumbers(2, 3);
            int sum2 = AddNumbers(1, 2, 3);
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.WriteLine();

            //Question-1,d 

            Book book1 = new Book("The Book");
            Book book2 = new Book("Another Book", "Author Name");
            Console.WriteLine($"Book 1: {book1.Title}, Author: {book1.Author}"); // Author will be "Unknown" 
            Console.WriteLine($"Book 2: {book2.Title}, Author: {book2.Author}");
            Console.WriteLine();



            //2-Generics: 
            //b- Swap<T> generic method: 
            Console.WriteLine("2-Generics b- Swap<T> generic method:");
            Console.WriteLine();
            int num1 = 5, num2 = 10;
            Swap(ref num1, ref num2);
            Console.WriteLine($"Swapped numbers are: {num1}, {num2}");
            string str1 = "Hello", str2 = "World";
            Swap(ref str1, ref str2);
            Console.WriteLine($"Swapped strings are: {str1}, {str2}");
            Console.WriteLine();




            //2-Generics: 
            //c- SUM<T> generic method: 
            Console.WriteLine("2-Generics:b- SUM<T> generic method:");
            Console.WriteLine();
            int su1 = Sum(1, 2, 3);
            double su2 = Sum(2.5, 3.7, 1.2);
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.WriteLine("2-Generics:b- LIST<T> generic method:");
            Console.WriteLine();




            //GENERIC LIST 
            MyList<int> intL = new MyList<int>();
            intL.Add(20);
            intL.Add(30);
            Console.WriteLine("Integer List:");
            intL.Display();
            intL.Remove(20);
            // Display the modified integer list 
            Console.WriteLine("Modified Integer List:");
            intL.Display();
            //String List 
            MyList<string> stringList = new MyList<string>();
            stringList.Add("Apple");
            stringList.Add("Banana");
            stringList.Add("Cherry");
            Console.WriteLine("String List:");
            stringList.Display();
            stringList.Remove("Banana");
            Console.WriteLine("Modified String List:");
            stringList.Display();
            Console.WriteLine();




            // Student database system
            InitializeDatabase();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. View the student database");
                Console.WriteLine("2. Search for a student by ID");
                Console.WriteLine("3. Update a student's name");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                Console.WriteLine("Please Enter Your Choice:");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayStudentDatabase();
                        break;

                    case 2:
                        SearchStudentByID();
                        break;

                    case 3:
                        UpdateStudentName();
                        break;

                    case 4:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}