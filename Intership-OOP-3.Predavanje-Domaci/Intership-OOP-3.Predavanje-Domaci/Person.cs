using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intership_OOP_3.Predavanje_Domaci
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; }
        public string Email { get; }
        public Dictionary<Guid, bool> Events { get; private set; }

        public Person(string Name, string Surname, string Email)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Events= new Dictionary<Guid, bool>();
        }

        public void InitializeEvenets(List<Event> events)
        {
            foreach(var item in events)
            {
                this.Events.Add(item.Id, false);
            }
        }

        public void SetCertainEvents(List<Event> events)
        {
            foreach(var item in events)
            {
                this.Events[item.Id] = true;  
            }
        }

        public void PrintAllEvents()
        {
            foreach(var item in this.Events)
            {
                Console.WriteLine($"Id: {item.Key} \t Value: {item.Value} \n");
            }
        }

    }
}
