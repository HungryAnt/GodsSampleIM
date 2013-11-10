using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gods.Fundation;

namespace GodsSampleIM.Models
{
    public class ContactPerson : NotificationObject
    {
        private string _name;
        private string _description;
        private string _imageName;

        public ContactPerson(string name, string description = "", string imageName = "")
        {
            _name = name;
            _description = description;
            _imageName = imageName;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        public string ImageName
        {
            get { return _imageName; }
            set
            {
                _imageName = value;
                RaisePropertyChanged("ImageName");
            }
        }
    }


}
