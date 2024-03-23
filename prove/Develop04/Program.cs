using System;
using System.Threading;

// Base class for mindfulness activities
public abstract class MindfulnessActivity
{
    protected int duration;

    // Constructor
    public MindfulnessActivity(int duration)
    {
        this.duration = duration;
    }

    // Method to display starting message
    protected virtual void DisplayStartingMessage(string activityName, string description)
    {
        Console.WriteLine($"Starting {activityName} Activity:");
        Console.WriteLine(description);
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    // Method to display ending message
    protected virtual void DisplayEndingMessage(string activityName)
    {
        Console.WriteLine($"Congratulations! You have completed the {activityName} Activity.");
        Console.WriteLine($"Total time: {duration} seconds");
        Console.WriteLine("Good job!");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    // Abstract method to perform the activity
    public abstract void PerformActivity();
}

// Breathing activity
public class BreathingActivity : MindfulnessActivity
{
    // Constructor
    public BreathingActivity(int duration) : base(duration) { }

    // Method to perform the breathing activity
    public override void PerformActivity()
    {
        DisplayStartingMessage("Breathing", "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000); // Pause for 1 second
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }

        DisplayEndingMessage("Breathing");
    }
}

// Reflection activity
public class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // Constructor
    public ReflectionActivity(int duration) : base(duration) { }

    // Method to perform the reflection activity
    public override void PerformActivity()
    {
        DisplayStartingMessage("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(5000); // Pause for 5 seconds
            Console.WriteLine("Spinner..."); // Placeholder for spinner animation
            Thread.Sleep(3000); // Pause for 3 seconds
        }

        DisplayEndingMessage("Reflection");
    }
}

// Listing activity
public class ListingActivity : MindfulnessActivity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // Constructor
    public ListingActivity(int duration) : base(duration) { }

    // Method to perform the listing activity
    public override void PerformActivity()
    {
        DisplayStartingMessage("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Random rand = new Random();
        string prompt = listingPrompts[rand.Next(listingPrompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");

        Console.WriteLine("Start listing...");
        Thread.Sleep(duration * 1000); // Pause for specified duration in seconds

        Console.WriteLine($"You listed {duration / 5} items.");

        DisplayEndingMessage("Listing");
    }
}

// Main class
public class Program
{
    // Main method
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness App!");
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");

        int choice;
        do
        {
            Console.Write("Enter your choice (1-3): ");
            choice = Convert.ToInt32(Console.ReadLine());
        } while (choice < 1 || choice > 3);

        Console.Write("Enter duration (in seconds): ");
        int duration = Convert.ToInt32(Console.ReadLine());

        MindfulnessActivity activity;
        switch (choice)
        {
            case 1:
                activity = new BreathingActivity(duration);
                break;
            case 2:
                activity = new ReflectionActivity(duration);
                break;
            case 3:
                activity = new ListingActivity(duration);
                break;
            default:
                return;
        }

        activity.PerformActivity();
    }
}