
using CandidateSoW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Xml.Linq;

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreeningController : ControllerBase
    {
        private IConfiguration configuration;
        public ScreeningController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        string msg = string.Empty;


        // GET: api/<AccountController>
        [HttpGet]
        public List<ScreeningModel> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            ScreeningModel ac = new ScreeningModel();
            ac.Type = "get";
            DataSet ds = dop.Screeningableget(ac, msg);
            CandidateController candidatecont = new CandidateController(configuration);
            CandidateModel candidate = new CandidateModel();
            List<ScreeningModel> list2 = new List<ScreeningModel>();
            List<ScreeningModel> list = new List<ScreeningModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        list.Add(new ScreeningModel
                        {
                            ScreeningId = Convert.ToInt32(dr["ScreeningId"]),
                            ScreeningSelected = Convert.ToInt32(dr["ScreeningSelected"]),
                            ScreeningRejected = Convert.ToInt32(dr["ScreeningRejected"]),
                            SowId = Convert.ToInt32(dr["SowId"]),
                            CandidateId = dr["CandidateId"].ToString(),
                            Screening = Convert.ToInt32(dr["Screening"]),
                            SelectedCandidateIds = dr["SelectedCandidateIds"].ToString(),
                            RejectedCandidateIds = dr["RejectedCandidateIds"].ToString(),
                            SOW_CandidateId = Convert.ToInt32(dr["MappingDate"]),
                            MappingDate = (DateTime)dr["MappingDate"]


                        }) ;

                    }
                    foreach (ScreeningModel screeningModel in list)
                    {
                        string[] ids = screeningModel.CandidateId.Split(',');
                        string[] selectedids= screeningModel.SelectedCandidateIds.Split(",");
                        string[] rejectedids =screeningModel.RejectedCandidateIds.Split(',');

                        for (int i = 0; i < ids.Length; i++)
                        {
                            candidate = candidatecont.Get(int.Parse(ids[i]))[0];
                            list2.Add(new ScreeningModel
                            {
                                ScreeningId = screeningModel.ScreeningId,
                                ScreeningSelected = screeningModel.ScreeningSelected,
                                ScreeningRejected = screeningModel.ScreeningRejected,
                                SowId = screeningModel.SowId,
                                CandidateId = candidate.CandidateId.ToString(),
                                Screening = ids.Length,
                                CandidateName = candidate.CandidateName,
                                CandidateUID = candidate.CandidateUid,
                                IsSelected=(selectedids.Where(x=>x== candidate.CandidateId.ToString()).FirstOrDefault())!=null?true:false,
                                SOW_CandidateId=screeningModel.SOW_CandidateId,
                                MappingDate=screeningModel.MappingDate,
                            });
                        }

                    }

                }
            }
            return list2;
        }
        [HttpGet("{id}")]
        public List<ScreeningModel> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            ScreeningModel ac = new ScreeningModel();
            ac.Type = "getid";
            ac.ScreeningId = id;
            DataSet ds = dop.Screeningableget(ac, msg);
            CandidateController candidatecont = new CandidateController(configuration);
            CandidateModel candidate = new CandidateModel();
            List<ScreeningModel> list2 = new List<ScreeningModel>();
            List<ScreeningModel> list = new List<ScreeningModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        list.Add(new ScreeningModel
                        {
                            ScreeningId = Convert.ToInt32(dr["ScreeningId"]),
                            ScreeningSelected = Convert.ToInt32(dr["ScreeningSelected"]),
                            ScreeningRejected = Convert.ToInt32(dr["ScreeningRejected"]),
                            SowId = Convert.ToInt32(dr["SowId"]),
                            CandidateId = dr["CandidateId"].ToString(),
                            Screening = Convert.ToInt32(dr["Screening"]),
                            SelectedCandidateIds = dr["SelectedCandidateIds"].ToString(),
                            RejectedCandidateIds = dr["RejectedCandidateIds"].ToString(),
                            SOW_CandidateId = Convert.ToInt32(dr["MappingDate"]),
                            MappingDate = (DateTime)dr["MappingDate"]


                        });

                    }
                    foreach (ScreeningModel screeningModel in list)
                    {
                        string[] ids = screeningModel.CandidateId.Split(',');
                        string[] selectedids = screeningModel.SelectedCandidateIds.Split(",");
                        string[] rejectedids = screeningModel.RejectedCandidateIds.Split(',');

                        for (int i = 0; i < ids.Length; i++)
                        {
                            candidate = candidatecont.Get(int.Parse(ids[i]))[0];
                            list2.Add(new ScreeningModel
                            {
                                ScreeningId = screeningModel.ScreeningId,
                                ScreeningSelected = screeningModel.ScreeningSelected,
                                ScreeningRejected = screeningModel.ScreeningRejected,
                                SowId = screeningModel.SowId,
                                CandidateId = candidate.CandidateId.ToString(),
                                Screening = ids.Length,
                                CandidateName = candidate.CandidateName,
                                CandidateUID = candidate.CandidateUid,
                                IsSelected = (selectedids.Where(x => x == candidate.CandidateId.ToString()).FirstOrDefault()) != null ? true : false,
                                SOW_CandidateId = screeningModel.SOW_CandidateId,
                                MappingDate = screeningModel.MappingDate,
                            });
                        }

                    }

                }
            }
            return list2;
        }
        [HttpPost]
        public string Post([FromBody] ScreeningModel sp)
        {
            string[] ids = sp.CandidateId.Split(',');
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            sp.Type = "insert";
            sp.ScreeningRejected = ids.Length - sp.ScreeningSelected;
            sp.Screening = ids.Length;
            string msg = string.Empty;
            try
            {
                msg = dop.Screeningtable(sp);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] ScreeningModel ac)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                ac.Type = "update";
                ac.ScreeningId = id;
                ac.ScreeningRejected = ac.Screening - ac.ScreeningSelected;
                msg = dop.Screeningtable(ac);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            //return msg;
            return JsonConvert.SerializeObject(msg);
        }


        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;

            try
            {
                ScreeningModel ac = new ScreeningModel();
                ac.Type = "Delete";
                ac.ScreeningId = id;
                msg = dop.Screeningtable(ac);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            //return msg;
            return JsonConvert.SerializeObject(msg);
        }


    }
}
