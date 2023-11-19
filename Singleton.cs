using System;


// Example 1
public class Singleton
{
    private Singleton()
    {
        Console.WriteLine("Singleton Pattern!!\n");
    }
    private static Singleton instance = null;

    public static Singleton GetInstance()
    {
        if (instance == null)
        {
            Console.WriteLine("Instance Created");   // This statement will be printed once.
            instance = new Singleton();
            return instance;
        }
        return instance;
    }
}


// Example 2

public class GameManager
{
    private GameManager()
    {
        Console.WriteLine("GameManager initialized.");
    }

    private static GameManager instance = null;

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            Console.WriteLine("Creating GameManager instance");
            instance = new GameManager();
            return instance;
        }
        return instance;
    }

    public void StartGame(string gameName)
    {
        Console.WriteLine($"Starting the game: {gameName}");
    }
}

class Program
{
    static void Main()
    {
        // Example 1


        Singleton.GetInstance();
        Singleton.GetInstance();
        Singleton.GetInstance();

        // Example 2

        // Accessing the game manager.
        GameManager gameManager1 = GameManager.GetInstance();
        GameManager gameManager2 = GameManager.GetInstance();
        GameManager gameManager3 = GameManager.GetInstance();

        // All three calls will return the same instance.
        gameManager1.StartGame("Chess");
        gameManager2.StartGame("Sudoku");
        gameManager3.StartGame("Tic Tac Toe");

        Console.ReadLine();
    }

    
  
}
