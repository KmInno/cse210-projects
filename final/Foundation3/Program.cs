using System;

// Address class
class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    // Constructor
    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    // Method to get the full address as a string
    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_state}\n{_country}";
    }
}

// Base Event class
class Event
{
    protected string _title;
    protected string _description;
    protected string _date;
    protected string _time;
    protected Address _address;

    // Constructor
    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    // Method to get standard details
    public string GetStandardDetails()
    {
        return $"Event Title: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress:\n{_address.GetFullAddress()}";
    }

    // Method to get short description
    public string GetShortDescription()
    {
        return $"Event Type: {this.GetType().Name}\nTitle: {_title}\nDate: {_date}";
    }

    // Virtual method for full details
    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }
}

// Lectures class derived from Event
class Lectures : Event
{
    private string _speakerName;
    private int _capacity;

    // Constructor
    public Lectures(string title, string description, string date, string time, Address address, string speakerName, int capacity)
        : base(title, description, date, time, address)
    {
        _speakerName = speakerName;
        _capacity = capacity;
    }

    // Override method for full details
    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {_speakerName}\nCapacity: {_capacity}";
    }
}

// Reception class derived from Event
class Reception : Event
{
    private string _email;

    // Constructor
    public Reception(string title, string description, string date, string time, Address address, string email)
        : base(title, description, date, time, address)
    {
        _email = email;
    }

    // Override method for full details
    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {_email}";
    }
}

// OutdoorGatherings class derived from Event
class OutdoorGatherings : Event
{
    private string _weatherStatement;

    // Constructor
    public OutdoorGatherings(string title, string description, string date, string time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        _weatherStatement = weatherStatement;
    }

    // Override method for full details
    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {_weatherStatement}";
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        // Create some address objects
        Address address1 = new Address("123 Bukasa Muyenga", "Kamapala", "IL", "Uganda");
        Address address2 = new Address("456 kansanga Nabututi", "Nairobi", "ON", "Kenya");
        Address address3 = new Address("789 Napak Blue", "Tanzania", "Zaire", "TZ");

        // Create some event objects
        Lectures lecture = new Lectures("Tech Innovations", "A talk on the latest in tech", "2024-06-10", "10:00 AM", address1, "Dr. Jane Doe", 100);
        Reception reception = new Reception("Networking Night", "An evening of networking with professionals", "2024-06-15", "7:00 PM", address2, "rsvp@networking.com");
        OutdoorGatherings outdoorGathering = new OutdoorGatherings("Summer Festival", "A fun outdoor festival with music and food", "2024-07-20", "12:00 PM", address3, "Sunny with a chance of showers");

        // List of events
        Event[] events = { lecture, reception, outdoorGathering };

        // Display details of each event
        foreach (var ev in events)
        {
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
        }
    }
}
