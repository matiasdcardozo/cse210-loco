using System;
using System.Collections.Generic;

class Activity
{
    private DateTime date;
    private int durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        this.date = date;
        this.durationMinutes = durationMinutes;
    }

    public virtual double GetDistance()
    {
        return 0; // Base class does not have distance information
    }

    public virtual double GetSpeed()
    {
        return 0; // Base class does not have speed information
    }

    public virtual double GetPace()
    {
        return 0; // Base class does not have pace information
    }

    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} - {GetType().Name} ({durationMinutes} min)";
    }
}

class Running : Activity
{
    private double distanceMiles;

    public Running(DateTime date, int durationMinutes, double distanceMiles) : base(date, durationMinutes)
    {
        this.distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return distanceMiles;
    }

    public override double GetSpeed()
    {
        return (distanceMiles / durationMinutes) * 60;
    }

    public override double GetPace()
    {
        return 60 / (distanceMiles / durationMinutes);
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance: {distanceMiles} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
    }
}

class Cycling : Activity
{
    private double speedMph;

    public Cycling(DateTime date, int durationMinutes, double speedMph) : base(date, durationMinutes)
    {
        this.speedMph = speedMph;
    }

    public override double GetSpeed()
    {
        return speedMph;
    }

    public override double GetPace()
    {
        return 60 / speedMph;
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Speed: {speedMph} mph, Pace: {GetPace()} min/mile";
    }
}

class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int durationMinutes, int laps) : base(date, durationMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000; // Convert laps to kilometers
    }

    public override double GetSpeed()
    {
        return (GetDistance() / durationMinutes) * 60 * 60; // Speed in km/h
    }

    public override double GetPace()
    {
        return durationMinutes / GetDistance();
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min/km";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // Create sample activities
        activities.Add(new Running(new DateTime(2024, 4, 9), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2024, 4, 10), 45, 15.0));
        activities.Add(new Swimming(new DateTime(2024, 4, 11), 60, 20));

        // Display summary for each activity
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}