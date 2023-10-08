using System;

namespace EAD_Assignment_02
{
   
    class Program
    {
        // Task-1
        static string ConcateNames(string firstName, string secondName)
        {
            return firstName + " " +  secondName;

        }

        // Task-2
        static string ExtractLast5Char(string sentence)
        { 
          if(sentence.Length <=5)  // Check if the lenght is already less than 5, then return sentence as it is.
          {
                return sentence;
          }
          else
          {
            string lastFiveChar = sentence.Substring(sentence.Length - 5);
            return lastFiveChar;
          }
        }

        // Task-3

        static void DisplayTemperature()
        {
            Console.Write("Enter the current temperature (in degrees Celsius): ");
            double temperature = double.Parse(Console.ReadLine());
           

            Console.Write("Enter the name of your city: ");
            string city = Console.ReadLine();

            string message = $"The temperature in {city} is {temperature} degrees Celsius.";
            Console.WriteLine(message);
        }

        // Task-6


        static int sumOfScores(int[] scores)
        {
            int sum = 0;
            int i = 0;
            do
            {
                sum += scores[i];
                i++;
            }
            while (i < scores.Length); 
            
            return sum;
        }

        // Task-7

        static int findMax(int[] values)
        {
            int max = values[0], i = 0;

            while(i< values.Length)
            {
                if(max < values[i])
                {
                    max = values[i];
                  
                }
                i++;
            }
            Console.WriteLine(max);
            return max;
        }

        // Task-8

        static void reverseArray(int[] array)
        {
            int start = 0;
            int end = array.Length - 1;

            while (start < end)
            {
                // Swap the elements at the start and end positions
                int temp = array[start];
                array[start] = array[end];
                array[end] = temp;

                start++;
                end--;
            }
        }

        // Task-9,a

        static void intBoxing(int x)
        {
            x = 42;
            // Boxing to convert int into object
            object boxedX = x;
            int y = (int)boxedX; // unbox the object and store value in new object.
            Console.WriteLine($"Value of y (Unboxed) is: {y}");
        }

        // Task-9,b

        static void doubleBoxing(double doubleValue)
        {
            doubleValue = 3.14159;
            // Boxing to convert int into object
            object boxedDouble = doubleValue;
            double unboxedValue = (double)boxedDouble; // unbox the object and store value in new object.
            Console.WriteLine($"Value of unboxedDouble is: {unboxedValue}");
        }

        static void Main(string[] args)
        {
            // Task-1

            //Console.WriteLine("Write the first name: ");
            //string firstName = Console.ReadLine();
            //Console.WriteLine("Write the second name: ");
            //string secondName = Console.ReadLine();
            //string completeName = ConcateNames(firstName,secondName);
            //Console.WriteLine("Full Name is: {0} ", completeName);

            // Task-2

            string sentence = "Hello, My name is Issac, I am learning C# programming";
            string last5ch = ExtractLast5Char(sentence);
            Console.WriteLine("Last 5 characters of given sentence are: " + last5ch);

            // Task-3

            //DisplayTemperature();

            // Task-4

            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            for(int i = 0; i<numbers.Length;i++)
            {
                Console.WriteLine(numbers[i]);
            }
            Console.WriteLine();

            // Task-5,a

            string[] fruits = new string[] { "Banana", "Apple", "Mango", "Orange", "Guava" };

            for(int i = 0; i<fruits.Length;i++)
            {
                Console.WriteLine(fruits[i]);
            }
            Console.WriteLine();

            // Task-5,b

            string[] colors = new string[] { "Red", "Green", "Blue", "Black", "Pink" };

            foreach(string color in colors)
            {
                Console.WriteLine(color);
            }

            //  Task-6 

            int[] scores = new int[10] { 34, 45, 56, 67, 88, 45, 67, 34, 56, 77 };

            Console.WriteLine($"Total Score is: {sumOfScores(scores)}");

            // Task-7

            int[] values = new int[] { 3, 46, 5, 6, 7, 10, 23, 45 };
            Console.WriteLine($"Max Value in array: {findMax(values)}");


            // Task-8

            int[] numArray = new int[] { 1, 2, 3, 4, 5 };

            reverseArray(numArray);

            Console.Write("Reversed Array: ");
            foreach(int i in numArray)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            // Task-9,a

            int x = 42;
            intBoxing(x);

            // Task-9,b

            double doubleVal = 3.14159;
            doubleBoxing(doubleVal);

            // Task-10,a

            int[] numberss = new int[] { 2, 3, 4, 5, 6, 7 };
            for(int i = 0;i< numberss.Length;i++)
            {
                object val = numberss[i];
                int newVar = (int)val;
                int squaredVal = newVar * newVar;
                Console.WriteLine($"Original Integer: {newVar} , Squared Value: {squaredVal}");  
            }
            Console.WriteLine();


            //  Task-10,b

            List<object> commonList = new List<object>();   
            commonList.Add( 42 );  // Adding int
            commonList.Add(2.34);  // Adding double
            commonList.Add("Hello"); // Adding String
            commonList.Add('c');  // Adding character

            // Retrieve elements from the list and unbox them
            int intValue = (int)commonList[0];
            double doubleValue = (double)commonList[1];
            string stringValue = (string)commonList[2];
            char charValue = (char)commonList[3];

            // Confirmation by priting the value and type

            foreach (var item in commonList)
            {
                Type itemType = item.GetType();
                Console.WriteLine($"Element: {item}, Type: {itemType}");
            }


            // Task-11,a

            dynamic myVariable = 4;
            Console.WriteLine($"Current Value of Dynamic: {myVariable}");
            myVariable = "Hello, Dynamic!";
            Console.WriteLine($"New Value of Dynamic: {myVariable}");

            // Task-11,b

            dynamic myVariable2 = 50;
            Console.WriteLine($"Type of myVariable2 is: {myVariable2.GetType()}");

            myVariable2 = 3.45678 ;
            Console.WriteLine($"Type of myVariable2 is: {myVariable2.GetType()}");

            myVariable2 = "This is a value!";
            Console.WriteLine($"Type of myVariable2 is: {myVariable2.GetType()}");

            myVariable = DateTime.Now;
            Console.WriteLine($"Type of myVariable2 is: {myVariable2.GetType()}");




        }

    }

}
