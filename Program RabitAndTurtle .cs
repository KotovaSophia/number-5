using System;
using System.Threading;

class AnimalThread
{
    private string name;
    private ThreadPriority priority;
    private int distance;
    private readonly int maxDistance = 100;

    public AnimalThread(string name, ThreadPriority priority)
    {
        this.name = name;
        this.priority = priority;
        this.distance = 0;
    }

    public void Run()
    {
        Random rand = new Random();

        while (distance < maxDistance)
        {
            Console.WriteLine($"{name} is at {distance} meters.");
            Thread.Sleep(100);

            int randomFactor = rand.Next(1, 6);
            distance += randomFactor;


            if (name == "Rabbit" && distance >= 50)
            {
                Console.WriteLine("Rabbit slowed down!");
                priority = ThreadPriority.Lowest;
            }
            else if (name == "Turtle" && distance >= 50)
            {
                Console.WriteLine("Turtle sped up!");
                priority = ThreadPriority.Highest;
            }

            Thread.CurrentThread.Priority = priority;

            Console.WriteLine($"{name} finished the race!");
        }
    }

    class RabbitAndTurtle
    {
        static void Main()
        {
            AnimalThread rabbit = new AnimalThread("Rabbit", ThreadPriority.Highest);
            AnimalThread turtle = new AnimalThread("Turtle", ThreadPriority.Lowest);

            Thread rabbitThread = new Thread(rabbit.Run);
            Thread turtleThread = new Thread(turtle.Run);

            rabbitThread.Start();
            turtleThread.Start();

            rabbitThread.Join();
            turtleThread.Join();
        }
    }
}