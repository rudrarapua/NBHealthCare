using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MAT.Service.BusinessObjects;
using MAT.Model.Models;
using System.Configuration;
using System.Threading.Tasks;

namespace MembersandTechnology.Controllers
{
    public class MembersController : ApiController
    {
        //string conString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        BizMembers bz = new BizMembers();

        [HttpPost]
        [ActionName("GetMembersByTechnologyId")]       
        public MembersList GetMembersByTechId (Technology technology)
        {
            MembersList mlst = new MembersList();
            mlst = bz.GetMembers(technology.TechnologyId);
            return mlst;
        }

        [HttpPost]
        [ActionName("GetMemberDetails")]
       
        public MembersDetails GetMemberDetailsByID(Member member)
        {
            MembersDetails msd = new MembersDetails();
            msd = bz.getMemberDetails(member.MemberId);
            return msd;
        }
    }
}
