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

        [HttpGet]
        [ActionName("GetMembersByTechnologyId")]       
        public MembersList GetMembersByTechId (int TechnologyId)
        {
            MembersList mlst = new MembersList();
            mlst = bz.GetMembers(TechnologyId);
            return mlst;
        }

        [HttpGet]
        [ActionName("GetMemberDetails")]
       
        public MembersDetails GetMemberDetailsByID(int MemberID)
        {
            MembersDetails msd = new MembersDetails();
            msd = bz.getMemberDetails(MemberID);
            return msd;
        }
    }
}
