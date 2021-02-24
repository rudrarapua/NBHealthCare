using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAT.Model.Models
{
    public class MembersList
    {
        public List<Members> memberlist { get; set; }
    }
    public class Members
    {
        public int MembersId { get; set; }

        public string MemberName { get; set; }

        //public int TechnologyID { get; set; }

        //public DateTime DateofBirth { get; set; }

        //public string Qualification { get; set; }

        //public int Yearsofexperiance { get; set; }
    }

    public class MembersDetails
    {
        public int MembersId { get; set; }

        public string MemberName { get; set; }

        public int TechnologyID { get; set; }

        public DateTime DateofBirth { get; set; }

        public string Qualification { get; set; }

        public int Yearsofexperiance { get; set; }
    }

    public class Member
    {
        public int MemberId { get; set; }
    }

    public class Technology
    {
        public int TechnologyId { get; set; }
    } 
}
