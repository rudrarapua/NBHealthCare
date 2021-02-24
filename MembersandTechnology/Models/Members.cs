using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MembersandTechnology.Models
{
    public class MembersList
    {
        public List<Members> memberlist { get; set; }
    }
    public class Members
    {
        public int MembersId { get; set; }

        public string MemberName { get; set; }

        public int TechnologyID { get; set; }

        public DateTime DateofBirth { get; set; }

        public string Qualification { get; set; }

        public int Yearsofexperiance { get; set; }
    }
}