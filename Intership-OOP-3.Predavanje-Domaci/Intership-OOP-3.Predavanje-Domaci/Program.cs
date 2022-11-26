// See https://aka.ms/new-console-template for more information


using Intership_OOP_3.Predavanje_Domaci;

void SetUpPersonsAndEvents(List<Person> people, List<Event> events)
{
    foreach (var person in people)
    {
        person.InitializeEvenets(events);
    }
    events[0].SetEventEmails(new List<string> { people[0].Email, people[3].Email, people[4].Email, people[6].Email, people[7].Email, people[8].Email });
    events[1].SetEventEmails(new List<string> { people[1].Email, people[2].Email, people[4].Email, people[5].Email, people[7].Email, people[8].Email });
    events[2].SetEventEmails(new List<string> { people[1].Email, people[3].Email, people[4].Email, people[7].Email, people[8].Email, people[9].Email });
    events[3].SetEventEmails(new List<string> { people[2].Email, people[4].Email, people[5].Email, people[6].Email, people[7].Email, people[8].Email });
    events[4].SetEventEmails(new List<string> { people[0].Email, people[1].Email, people[3].Email, people[4].Email, people[5].Email, people[9].Email });
    people[0].SetCertainEvents(new List<Event> { events[0], events[4] });
    people[1].SetCertainEvents(new List<Event> { events[1], events[2], events[4] });
    people[2].SetCertainEvents(new List<Event> { events[1], events[3] });
    people[3].SetCertainEvents(new List<Event> { events[0], events[2], events[4] });
    people[4].SetCertainEvents(new List<Event> { events[0], events[1], events[2], events[3], events[4] });
    people[5].SetCertainEvents(new List<Event> { events[1], events[3], events[4] });
    people[6].SetCertainEvents(new List<Event> { events[0], events[3] });
    people[7].SetCertainEvents(new List<Event> { events[0], events[1], events[2], events[3] });
    people[8].SetCertainEvents(new List<Event> { events[0], events[1], events[2], events[3] });
    people[9].SetCertainEvents(new List<Event> { events[2], events[4] });
}

List<Person> ReturnPreDefinedListOfPeople()
{
    return new List<Person>()
    {
        new Person ("Ante", "Antic", "ante.antic@gmail.com"),
        new Person ("Roko", "Rokic", "roko.rokic@gmail.com"),
        new Person ("Mate", "Matic", "mate.matic@gmail.com"),
        new Person ("Marko", "Markic", "marko.markic@gmail.com"),
        new Person ("Petar", "Petric", "petar.petric@gmail.com"),
        new Person ("Matija", "Matijic", "matija.matijic@gmail.com"),
        new Person ("Karlo", "Karlic", "karlo.karlic@gmail.com"),
        new Person ("Zeljko", "Zeljkic", "zeljko.zeljkic@gmail.com"),
        new Person ("Toni", "Tonic", "toni.tonic@gmail.com"),
        new Person ("Lovre", "Lovric", "lovre.lovric@gmail.com")
    };
}

List<Event> ReturnPreDefinedListOfEvents()
{
    return new List<Event>()
    {
        new Event("Ultra 2023", "Split", new DateTime(2022, 2, 7), new DateTime(2023, 12, 21)),
        new Event("Tomorowland 2023", "Boom", new DateTime(2023, 7, 21), new DateTime(2023, 7, 23)),
        new Event("FIFA 2022", "Quatar", new DateTime(2022, 11, 18), new DateTime(2022, 11, 20)),
        new Event("Interliber", "Zagreb", new DateTime(2021, 11, 8), new DateTime(2021, 11, 13)),
        new Event("Aviation Nation 2022", "Nellis Airforce Base", new DateTime(2022, 11, 5), new DateTime(2022, 11, 6))
    };
}

List<Person> ReturnAllPeopleWhoAttendedTheEvent(Event Event, List<Person> people)
{
    var peopleToReturn = new List<Person>();
    foreach(var person in people)
    {
        if (person.Events.ContainsKey(Event.Id))
        {
            if(person.Events.GetValueOrDefault(Event.Id) is true)
            {
                peopleToReturn.Add(person);
            }
        }
    }
    return peopleToReturn;
}
List<Person> ReturnAllPeopleWhoDidNotAttendedTheEvent(Event Event, List<Person> people)
{
    var peopleToReturn = new List<Person>();
    foreach (var person in people)
    {
        if (person.Events.ContainsKey(Event.Id))
        {
            if (person.Events.GetValueOrDefault(Event.Id) is false)
            {
                peopleToReturn.Add(person);
            }
        }
    }
    return peopleToReturn;
}

void EventsThatHaveEnded(List<Event> events, List<Person> people)
{
    var peopleThatHaveAtended = new List<Person>();
    var peopleThatDidNotAtend = new List<Person>();
    foreach (var item in events)
    {
        if (DateTime.Compare(DateTime.Now, item.EndDate) > 0)
        {
            Console.WriteLine("--------------------------------SLJEDECI EVENT-----------------------------------------");
            Console.WriteLine($"\n \n Naziv -> {item.Name} \n Lokacija -> {item.Location} \n Prije Koliko dana je bilo -> {(DateTime.Now - item.EndDate).Days} \n Trajanje Eventa -> {(item.EndDate - item.BegginingDate).TotalHours} h \n\n");
            peopleThatHaveAtended = ReturnAllPeopleWhoAttendedTheEvent(item, people);
            peopleThatDidNotAtend = ReturnAllPeopleWhoDidNotAttendedTheEvent(item, people);
            Console.WriteLine("\n Ljudi koji su dosli na event: \n");
            foreach(var person in peopleThatHaveAtended)
            {
                Console.WriteLine($"Ime: {person.Name} \n Prezime: {person.Surname} \n Email: {person.Email} \n");
            }
            Console.WriteLine("\n Ljudi koji nisu dosli na event: \n");
            foreach (var person in peopleThatDidNotAtend)
            {
                Console.WriteLine($" Ime: {person.Name} \n Prezime: {person.Surname} \n Email: {person.Email} \n");
            }
        }
    }
}

void SetPeopleWhoWillNotAttendAEvent(List<Event> events, List<Person> people)
{
    Console.WriteLine("\n Unesi ID Eventa: \n");
    var eventToChange = Console.ReadLine();
    var temp = new Guid(eventToChange);
    Console.WriteLine("\n Unesi Emailove(razmak nakon svakog emaila, sve u istu liniju) \n ");
    var emails = Console.ReadLine();
    string[] peopleEmails = emails.Split(' ');
    foreach(var item in peopleEmails)
    {
        events.Find(x => x.Id.ToString() == eventToChange).Emails.Remove(item);
        people.Find(x => x.Email == item).Events[temp] = false;
    }
}

void DeleteEvent(List<Event> events, List<Person> people)
{
    Console.WriteLine("\n Unesi ID Eventa: \n");
    var eventToChange = Console.ReadLine();
    var temp = new Guid(eventToChange);
    var temp2 = events.Find(x => x.Id == temp);
    if(temp2 is null)
    {
        Console.WriteLine("\n Nepostoji Event! \n");
        return;
    }
    if(DateTime.Compare(DateTime.Now,events.Find(x => x.Id.ToString() == eventToChange).BegginingDate) < 0)
    {
        foreach(var person in people)
        {
            person.Events.Remove(temp);
        }
        events.Remove(temp2);
    }
}

void ActiveEvents(List<Event> events, List<Person> people)
{
    foreach(var item in events)
    {
        if((DateTime.Compare(DateTime.Now, item.BegginingDate) > 0) && (DateTime.Compare(DateTime.Now, item.EndDate) < 0))
        {
            Console.WriteLine($"\n ID: {item.Id} \n Naziv: {item.Name} \n Lokacija: {item.Location} \n Zavrsave za: {(item.EndDate - DateTime.Now).Days} d");
            Console.WriteLine("\n \n Sudionici: \n \n");
            foreach(var person in item.Emails)
            {
                Console.WriteLine($"Sudionik: {person}");
            }
        }
    }
}

void UpCommingEvents(List<Event> events, List<Person> people)
{
    foreach (var item in events)
    {
        if (DateTime.Compare(DateTime.Now, item.BegginingDate) < 0)
        {
            Console.WriteLine($"\n ID: {item.Id} \n Naziv: {item.Name} \n Lokacija: {item.Location} \n Pocinje za: {(item.BegginingDate - DateTime.Now).Days} d \n Trajanje: {(item.EndDate - item.BegginingDate).TotalHours} h \n");
            Console.WriteLine("\n \n Sudionici: \n \n");
            foreach (var person in item.Emails)
            {
                Console.WriteLine($"Sudionik: {person}");
            }
        }
    }
}

void RemovePeopleFromEvent(List<Event> events, List<Person> people)
{
    Console.WriteLine("\n Unesi ID Eventa: \n");
    var eventToChange = Console.ReadLine();
    var temp = new Guid(eventToChange);
    Console.WriteLine("\n Unesi Emailove(razmak nakon svakog emaila, sve u istu liniju) \n ");
    var emails = Console.ReadLine();
    string[] peopleEmails = emails.Split(' ');
    var listOfEmails = new List<string>();
    foreach (var person in peopleEmails)
    {
        var temp3 = events.Find(x => x.Id == temp).Emails.Contains(person);
        if (!temp3)
        {
            Console.WriteLine("\n UNESENA OSOBA NIJE U EVENTU \n");
        }
        else
        {
            events.Find(x => x.Id == temp).Emails.Remove(person);
            listOfEmails.Add(person);
        }
    }
    foreach (var person in listOfEmails)
    {
        people.Find(x => x.Email == person).Events.Remove(temp);
    }

}

void Start()
{
    var people = ReturnPreDefinedListOfPeople();
    var events = ReturnPreDefinedListOfEvents();
    SetUpPersonsAndEvents(people, events);
    Console.WriteLine("Pocetak Aplikacije!\n \n");
    while (true)
    {
        Console.WriteLine("\n \n 1 - Aktivni Eventi \n 2 - Nadolazeći Eventi \n 3 - Eventi Koji Su Završili \n 4 - Kreiraj Event \n 5 - Izadi Iz Programa \n");
        var input = Console.ReadLine();
        var eventForChange = "";
        var emails = "";
        var flag = false;
        switch (input)
        {
            case "1":
                ActiveEvents(events, people);
                var firstMenuFlag = false;
                while (true)
                {
                    Console.WriteLine("\n \n 1 - Zabiljezi neprisutnost \n 2 - Povratak na glavni izbornik \n");
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            SetPeopleWhoWillNotAttendAEvent(events, people);
                            firstMenuFlag = true;
                            break;
                        case "2":
                            firstMenuFlag = true;
                            break;
                        default:
                            Console.WriteLine("\n Krivi unos! \n");
                            break;
                    }
                    if (firstMenuFlag)
                    {
                        break;
                    }
                }
                break;
            case "2":
                UpCommingEvents(events, people);
                var secondMenuFlag = false;
                while (true)
                {
                    Console.WriteLine("\n \n 1 - Izbrisi event \n 2 - Ukloni osobe s eventa \n 3 - Povratak na glavni izbornik \n");
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            DeleteEvent(events, people);
                            secondMenuFlag= true;
                            break;
                        case "2":
                            RemovePeopleFromEvent(events, people);
                            secondMenuFlag = true;
                            break;
                            case "3":
                            secondMenuFlag = true;
                            break;
                        default:
                            Console.WriteLine("\n Krivi unos! \n");
                            break;
                    }
                    if(secondMenuFlag)
                    { 
                        break;
                    }
                }
                break;
            case "3":
                EventsThatHaveEnded(events, people);
                break;
            case "4":
                Console.WriteLine("4");
                break;
            case "5":
                flag = true;
                break;
            default:
                Console.WriteLine("\n\nNEDOZVOLJENI UNOS\n\n");
                break;
        }
        if (flag)
        {
            Console.WriteLine("\n Gasenje Programa!\n");
            break;
        }
    }
}

Start();
