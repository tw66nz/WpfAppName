using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppName.Model;
using WpfAppName.ViewModel;

namespace WpfAppName.Helper
{
    public class FindPerson
    {
        int id;
        public FindPerson(int id)
        {
            this.id = id;
        }
        public bool PersonPredicate(Person person)
        {
            return person.Id == id;
        }
        public int Id { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public FindPerson() { }
        public FindPerson(int id, string role, string firstName, string lastName, DateTime
       birthday)
        {
            this.Id = id;
            this.Role = role;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
        }
        public FindPerson CopyFromPerson(Person person)
        {
            FindPerson perDPO = new FindPerson();
            RoleViewModel vmRole = new RoleViewModel();
            string role = string.Empty;
            foreach (var r in vmRole.ListRole)
            {
                if (r.Id == person.RoleId)
                {
                    role = r.NameRole;
                    break;
                }
            }
            if (role != string.Empty)
            {
                perDPO.Id = person.Id;
                perDPO.Role = role;
                perDPO.FirstName = person.FirstName;
                perDPO.LastName = person.LastName;
                perDPO.Birthday = person.Birthday;
            }
            return perDPO;
        }
        public FindPerson ShallowCopy()
        {
            return (FindPerson)this.MemberwiseClone();
        }
    }
}