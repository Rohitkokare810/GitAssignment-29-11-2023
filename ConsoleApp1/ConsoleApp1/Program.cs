using System;

public delegate void SpinDelegate(ref int energyLevel, ref int winningProbability);

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Lucky Spin Game!");

        Console.Write("Enter Your Name: ");
        string playerName = Console.ReadLine();

        int energyLevel = 1;
        int winningProbability = 100;
        int spinsLeft = 5;

        SpinDelegate spinDelegate = Spin;

        for (int spinNumber = 1; spinNumber <= 10; spinNumber++)
        {
            if (spinsLeft > 0)
            {
                Console.WriteLine($"Spin {spinNumber}:");
                spinDelegate.Invoke(ref energyLevel, ref winningProbability);
                Console.WriteLine($"Energy Level: {energyLevel}, Winning Probability: {winningProbability}");
                spinsLeft--;
            }
            else
            {
                Console.WriteLine("No more spins left. Game over!");
                break;
            }
        }

        DetermineWinner(energyLevel, winningProbability);
        Console.ReadKey();
    }

    static void Spin(ref int energyLevel, ref int winningProbability)
    {
        switch (energyLevel)
        {
            case 1:
                energyLevel += 1;
                winningProbability += 10;
                break;
            case 2:
                energyLevel += 2;
                winningProbability += 20;
                break;
            case 3:
                energyLevel -= 3;
                winningProbability -= 30;
                break;
            case 4:
                energyLevel += 4;
                winningProbability += 40;
                break;
            case 5:
                energyLevel += 5;
                winningProbability += 50;
                break;
            case 6:
                energyLevel -= 1;
                winningProbability -= 60;
                break;
            case 7:
                energyLevel += 1;
                winningProbability += 70;
                break;
            case 8:
                energyLevel -= 2;
                winningProbability -= 20;
                break;
            case 9:
                energyLevel -= 3;
                winningProbability -= 30;
                break;
            case 10:
                energyLevel += 10;
                winningProbability += 100;
                break;
        }
    }

    static void DetermineWinner(int energyLevel, int winningProbability)
    {
        Console.WriteLine("\nGame Over! Results:");

        if (energyLevel >= 4 && winningProbability > 60)
        {
            Console.WriteLine("Winner!");
        }
        else if (energyLevel >= 1 && winningProbability > 50)
        {
            Console.WriteLine("Runner Up!");
        }
        else
        {
            Console.WriteLine("Loser!");
        }
    }
}
