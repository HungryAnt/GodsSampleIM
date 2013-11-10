using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gods.Fundation;

namespace GodsSampleIM.Models
{
    public class ContactCategory : NotificationObject
    {
        private string _name;
        private List<ContactPerson> _contactPersons;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public List<ContactPerson> ContactPersons
        {
            get { return _contactPersons; }
            set
            {
                _contactPersons = value;
                RaisePropertyChanged("ContactPersons");
            }
        }

        public ContactCategory(string name)
        {
            _name = name;
        }
    }
}
