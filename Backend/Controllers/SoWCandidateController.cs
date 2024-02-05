using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CandidateSoW.Models;
using System;
using System.Collections.Generic;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoWCandidateController : ControllerBase
    {
        private IConfiguration configuration;
        public SoWCandidateController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        string msg = string.Empty;
        [HttpGet]
        public List<SoWCandidateModel> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            SoWCandidateModel sc = new SoWCandidateModel();
            sc.Type = "get";
            DataSet ds = dop.SowcandidatetableGet(sc, msg);
            List<SoWCandidateModel> list = new List<SoWCandidateModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new SoWCandidateModel
                        {
                            SOW_CandidateId = Convert.ToInt32(dr["SOW_CandidateId"]),
                            SowId = Convert.ToInt32(dr["SowId"]),
                            CandidateId = Convert.ToInt32(dr["CandidateId"]),
                            StatusId = Convert.ToInt32(dr["StatusId"]),
                            SoName = Convert.ToString(dr["SoName"]),
                            CandidateName = Convert.ToString(dr["CandidateName"]),
                            StatusName = Convert.ToString(dr["StatusName"]),
                            MappingDate = (DateTime)dr["MappingDate"]
                        });
                    }
                }
            }
            return list;
        }

        // GET api/<SoWCandidateController>/5
        [HttpGet("{id}")]
        public List<SoWCandidateModel> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            SoWCandidateModel sc = new SoWCandidateModel();
            sc.Type = "getid";
            sc.SOW_CandidateId = id;
            DataSet ds = dop.SowcandidatetableGet(sc, msg);
            List<SoWCandidateModel> list = new List<SoWCandidateModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new SoWCandidateModel
                        {
                            SOW_CandidateId = Convert.ToInt32(dr["SOW_CandidateId"]),
                            SowId = Convert.ToInt32(dr["SowId"]),
                            CandidateId = Convert.ToInt32(dr["CandidateId"]),
                            StatusId = Convert.ToInt32(dr["StatusId"]),
                            SoName = Convert.ToString(dr["SoName"]),
                            CandidateName = Convert.ToString(dr["CandidateName"]),
                            StatusName = Convert.ToString(dr["StatusName"]),
                            MappingDate = (DateTime)dr["MappingDate"]
                        });
                    }
                }
            }
            return list;
        }

        // POST api/<SoWCandidateController>
        [HttpPost]
        public string Post([FromBody] SoWCandidateModel sc)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                //sc.StatusId = 1;
                msg = dop.sowcandidatetable(sc);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            //return msg;
            return JsonConvert.SerializeObject(msg);
        }

        // PUT api/<SoWCandidateController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] SoWCandidateModel sc)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                sc.Type = "update";
                sc.SOW_CandidateId = id;
                msg = dop.sowcandidatetable(sc);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            //return msg;
            return JsonConvert.SerializeObject(msg);
        }

        // DELETE api/<SoWCandidateController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                SoWCandidateModel sc = new SoWCandidateModel();
                sc.Type = "Delete";
                sc.SOW_CandidateId = id;
                msg = dop.sowcandidatetable(sc);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            //return msg;
            return JsonConvert.SerializeObject(msg);
        }


        [HttpGet("SowData")]
        public List<Sow> GetSowData()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            Sow sp = new Sow();
            sp.Type = "getforCandidateMapping";
            DataSet ds = dop.sowtablegetForCandidateMapping(sp, msg);
            List<Sow> list = new List<Sow>();
            try
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            list.Add(new Sow
                            {
                                SowId = Convert.ToInt32(dr["SowId"]),
                                SoName = dr["SoName"].ToString(),
                                JRCode = dr["JRCode"].ToString(),
                                RequestCreationDate = ((DateTime)dr["RequestCreationDate"]),
                                AccountId = Convert.ToInt32(dr["AccountId"]),
                                TechnologyId = Convert.ToInt32(dr["TechnologyId"]),
                                Comments = dr["Comments"].ToString(),
                                LocationId = Convert.ToInt32(dr["LocationId"]),
                                RegionId = Convert.ToInt32(dr["RegionId"]),
                                TargetOpenPositions = Convert.ToInt32(dr["TargetOpenPositions"]),
                                PositionsTobeClosed = Convert.ToInt32(dr["PositionsTobeClosed"]),
                                USTPOCId = Convert.ToInt32(dr["USTPOCId"]),
                                RecruiterId = Convert.ToInt32(dr["RecruiterId"]),
                                USTTPMId = Convert.ToInt32(dr["USTTPMId"]),
                                //DellManagerId = Convert.ToInt32(dr["DellManagerId"]),

                                DellManagerId = dr["DellManagerId"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["DellManagerId"]),



                                StatusId = Convert.ToInt32(dr["StatusId"]),
                                Band = dr["Band"].ToString(),
                                ProjectId = dr["ProjectId"].ToString(),
                                AccountManager = dr["AccountManager"].ToString(),
                                ExternalResource = dr["ExternalResource"].ToString(),
                                InternalResource = dr["InternalResource"].ToString(),
                                AccountName = dr["AccountName"].ToString(),
                                TechnologyName = dr["TechnologyName"].ToString(),
                                Location = dr["Location"].ToString(),
                                Region = dr["Region"].ToString(),
                                USTPOCName = dr["USTPOCName"].ToString(),
                                RecruiterName = dr["RecruiterName"].ToString(),
                                USTTPMName = dr["USTTPMName"].ToString(),
                                DellManagerName = dr["DellManagerName"].ToString(),
                                StatusName = dr["StatusName"].ToString(),
                                Onboardingdate = (DateTime)dr["Onboardingdate"],
                                IsOnHold = (Boolean)dr["IsOnHold"],
                                //AgeingColor = dr["AgeingColor"].ToString()

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


    }
}
