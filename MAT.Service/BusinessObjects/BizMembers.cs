using MAT.Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Text;      

namespace MAT.Service.BusinessObjects
{
    public class BizMembers
    {
        public MembersList GetMembers(int technologyid)
        {
            List<Members> mbsList = new List<Members>();
            MembersList mlst = new MembersList();
            string conString = ConfigurationManager.ConnectionStrings["MembersDBContext"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conString))
            {
               
                string spName = "MembersByTechID";
                SqlCommand cmd = new SqlCommand(spName, conn);
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "TechnologyId";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = technologyid.ToString();
                cmd.Parameters.Add(param1);

                //open connection
                conn.Open();

                //set the SqlCommand type to stored procedure and execute
                cmd.CommandType = CommandType.StoredProcedure;
                //var cmd = conn.CreateCommand();
                //cmd.CommandText = "select m.MemberID,m.MemberName from Members m join Technology t  on t.TechnologyID = m.TechnologyID where t.TechnologyID = @TechnologyId";
                //SqlParameter param1 = new SqlParameter();
                //param1.ParameterName = "TechnologyId";
                //param1.SqlDbType = SqlDbType.Int;
                //param1.Value = Tid;
                //cmd.Parameters.Add(param1);
                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                Console.WriteLine("Retrieved records:");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var age = 0;
                        Members mb = new Members();
                        mb.MembersId = dr.GetInt32(0);
                        mb.MemberName = dr.GetString(1);
                        age = dr.GetInt32(2);
                        //display retrieved record
                        Console.WriteLine("{0},{1}", mb.MembersId,ToString(),mb.MemberName);
                        if (age > 25)
                        {
                            mbsList.Add(mb);
                        }
                    }
                
                }
                
                else
                {
                    Console.WriteLine("No data found.");
                }
                mlst.memberlist = mbsList;
                //close data reader
                dr.Close();

                //close connection
                conn.Close();
            }
            return mlst;
        }

        public MembersDetails getMemberDetails(int memberid)
        {
            MembersDetails mb = new MembersDetails();
            // List<MembersDetails> mbs = new List<MembersDetails>();
            string conString = ConfigurationManager.ConnectionStrings["MembersDBContext"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conString))
            {

                string spName = "[MemberDetailsByID]";
                SqlCommand cmd = new SqlCommand(spName, conn);
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "MemberId";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = memberid;
                cmd.Parameters.Add(param1);

                //open connection
                conn.Open();

                //set the SqlCommand type to stored procedure and execute
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                Console.WriteLine("Retrieved records:");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        
                        mb.MembersId = dr.GetInt32(0);
                        mb.MemberName = dr.GetString(1);
                        mb.TechnologyID = dr.GetInt32(2);
                        mb.DateofBirth = dr.GetDateTime(3);
                        mb.Qualification = dr.GetString(4);
                        mb.Yearsofexperiance = dr.GetInt32(5);
                    }

                }

                else
                {
                    Console.WriteLine("No data found.");
                }
                dr.Close();
                //close connection
                conn.Close();
            }
            return mb;
        }
    }
}