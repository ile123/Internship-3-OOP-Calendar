using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intership_OOP_3.Predavanje_Domaci
{
    public class Event
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime BegginingDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string>? Emails { get; private set; }

        public Event(string Name, string Location, DateTime BegginingDate, DateTime EndDate)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.Location = Location;
            this.BegginingDate = BegginingDate;
            this.EndDate = EndDate;
        }

        public void SetEventEmails(List<string> emails)
        {
            this.Emails = emails;
        }
        public void PrintAllEmails()
        {
            foreach(var item in this.Emails)
            {
                Console.WriteLine($"Email: {item} \n");
            }
        }
    }
}
