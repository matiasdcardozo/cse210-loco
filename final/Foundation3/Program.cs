using System;

class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public override string ToString()
    {
        return $"{streetAddress}, {city}, {state}, {country}";
    }
}

class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public virtual string GenerateStandardDetails()
    {
        return $"Event Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
    }

    public virtual string GenerateFullDetails()
    {
        return GenerateStandardDetails();
    }

    public virtual string GenerateShortDescription()
    {
        return $"Type of Event: Generic\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GenerateFullDetails()
    {
        return base.GenerateFullDetails() + $"\nType of Event: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GenerateFullDetails()
    {
        return base.GenerateFullDetails() + $"\nType of Event: Reception\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GenerateFullDetails()
    {
        return base.GenerateFullDetails() + $"\nType of Event: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "NY", "USA");
        Event event1 = new Lecture("Tech Talk", "A talk on the latest technology trends", new DateTime(2024, 4, 10), new TimeSpan(14, 0, 0), address1, "John Doe", 50);
        Event event2 = new Reception("Networking Event", "An opportunity to network with industry professionals", new DateTime(2024, 4, 15), new TimeSpan(18, 30, 0), address1, "rsvp@example.com");
        Event event3 = new OutdoorGathering("Summer BBQ", "Enjoy a summer barbecue with friends and family", new DateTime(2024, 6, 20), new TimeSpan(12, 0, 0), address1, "Sunny");

        Console.WriteLine("Event 1:");
        Console.WriteLine(event1.GenerateStandardDetails());
        Console.WriteLine(event1.GenerateFullDetails());
        Console.WriteLine(event1.GenerateShortDescription());
        Console.WriteLine();

        Console.WriteLine("Event 2:");
        Console.WriteLine(event2.GenerateStandardDetails());
        Console.WriteLine(event2.GenerateFullDetails());
        Console.WriteLine(event2.GenerateShortDescription());
        Console.WriteLine();

        Console.WriteLine("Event 3:");
        Console.WriteLine(event3.GenerateStandardDetails());
        Console.WriteLine(event3.GenerateFullDetails());
        Console.WriteLine(event3.GenerateShortDescription());
    }
}