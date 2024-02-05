using CandidateSoW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreeningProfileController : ControllerBase
    {
        private IConfiguration configuration;
        public ScreeningProfileController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        string msg = string.Empty;

        [HttpGet("profiles/{type}")]
        public List<SoWCandidateModel> GetProfiles(string type, int sowid,DateTime startdate,DateTime enddate)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            SoWCandidateModel model = new SoWCandidateModel();
            model.Type = type;
            model.EndDate = enddate;
            model.StartDate = startdate;
            DataSet ds = dop.GetProfilesBySo(model, sowid, msg);

            List<SoWCandidateModel> list = new List<SoWCandidateModel>();
            try
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            list.Add(new SoWCandidateModel
                            {

                                CandidateUid = dr["CandidateUid"].ToString(),
                                CandidateName = dr["CandidateName"].ToString(),
                                MappingDate = ((DateTime)dr["MappingDate"]),

                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return list;
        }


        // GET api/<StatusController>/5
        [HttpGet("{id}")]
        public List<ScreeningProfilesModel> Get(int id, DateTime startdate,DateTime enddate) 
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            ScreeningProfilesModel st = new ScreeningProfilesModel();
            st.Type = "ScreeningSelected";
            st.SowId = id;
            st.StartDate = startdate;
            st.EndDate = enddate;
            DataSet ds = dop.Screeningprofiletableget(st, msg);
            List<ScreeningProfilesModel> list = new List<ScreeningProfilesModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new ScreeningProfilesModel
                        {
                            SowId = Convert.ToInt32(dr["SowId"]),
                            ProjectId = dr["ProjectId"].ToString(),
                            JRCode = dr["JRCode"].ToString(),
                            StatusId = Convert.ToInt32(dr["StatusId"]),
                            StatusName = dr["StatusName"].ToString(),
                            ScreeningSelected = Convert.ToInt32(dr["screeningSelected"]),
                            Screeningrejceted = Convert.ToInt32(dr["screeningrejceted"]),
                            L1selected = Convert.ToInt32(dr["L1selected"]),
                            L1rejected = Convert.ToInt32(dr["L1rejected"]),
                            L2selected= Convert.ToInt32(dr["L2selected"]),
                            L2rejceted = Convert.ToInt32(dr["L2rejceted"]),
                            OfferAccepted = Convert.ToInt32(dr["OfferAccepted"]),
                            OfferRejected = Convert.ToInt32(dr["OfferRejected"]),
                            TotalProfilesTagged = Convert.ToInt32(dr["TotalProfilesTagged"]),
                            TotalProfilesRejected = Convert.ToInt32(dr["TotalProfilesRejected"]),
                            ScreeningONhold = Convert.ToInt32(dr["ScreeningOnHold"]),
                            L1OnHold = Convert.ToInt32(dr["L1OnHold"]), 
                            L2OnHold = Convert.ToInt32(dr["L2OnHold"]),
                            InProgress = Convert.ToInt32(dr["InProgress"])
                        });
                    }
                }
            }
            return list;
        }



    }
}
