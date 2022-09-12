using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ASchryer_Spectrum_List_Project.Models
{
    // class of individual results
    public class Contact
    {
        public cName name { get; set; }
        public cLocation location { get; set; }
        public cPicture picture { get; set; }

        public string firstNameString { get { return name.first; } }
        public string lastNameString { get { return name.last; } }
        public string nameString { get { return name.first + " " + name.last; } }
        public string locationString { get { return location.city + ", " + location.state; } }
        public string pictureThumbString { get { return picture.thumbnail; } }
        public string pictureLargeString { get { return picture.large; } }
        public string ageString { get { return age.ToString() + " years old"; } }

        public string email { get; set; }
        public string phone { get; set; }
        public int age { get; set; }
        public string gender { get; set; }

        public Contact()
        {
            this.name = new cName();
            this.location = new cLocation();
            this.picture = new cPicture();
        }

        public class cName
        {
            public string first { get; set; }
            public string last { get; set; }
        }

        public class cLocation
        {
            public string city { get; set; }
            public string state { get; set; }
        }

        public class cPicture
        {
            public string large { get; set; }
            public string thumbnail { get; set; }
        }
    }
}
