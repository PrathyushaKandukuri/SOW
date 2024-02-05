using CandidateSoW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class L1Controller : ControllerBase
    {
        private IConfiguration configuration;
        public L1Controller(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        string msg = string.Empty;
        [HttpGet]
        public List<L1> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            L1 ac = new L1();
            ac.Type = "get";
            DataSet ds = dop.L1Tableget(ac, msg);
            List<L1> list = new List<L1>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new L1
                        {
                            L1Id = Convert.ToInt32(dr["L1Id"]),
                            L1Selected = Convert.ToInt32(dr["L1Selected"]),
                            L1Rejected = Convert.ToInt32(dr["L1Rejected"]),
                            L1Total = Convert.ToInt32(dr["L1"]),
                            ScreeningId = Convert.ToInt32(dr["ScreeningId"]),
                            Screening = Convert.ToInt32(dr["Screening"]),
                            OnHold = Convert.ToInt32(dr["Onhold"])
                        });
                    }
                }
            }
            return list;
        }

        [HttpGet("{id}")]
        public List<L1> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            L1 ac = new L1();

            ac.Type = "getid";
            ac.L1Id = id;
            DataSet ds = dop.L1Tableget(ac, msg);
            List<L1> list = new List<L1>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new L1
                        {
                            L1Id = Convert.ToInt32(dr["L1Id"]),
                            L1Selected = Convert.ToInt32(dr["L1Selected"]),
                            L1Rejected = Convert.ToInt32(dr["L1Rejected"]),
                            L1Total = Convert.ToInt32(dr["L1"]),
                            ScreeningId = Convert.ToInt32(dr["ScreeningId"]),
                            Screening = Convert.ToInt32(dr["Screening"]),
                            OnHold = Convert.ToInt32(dr["Onhold"])
                        });
                    }
                }
            }
            return list;
        }

        [HttpPost]
        public string Post([FromBody] L1 sp)
        {
            ScreeningModel s = new ScreeningModel();

            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);


            string msg = string.Empty;
            try
            {
                sp.Type = "insert";
                //sp.L1Rejected = sp.L1Total ;
                //sp.L1Total = sp.Screening;


                msg = dop.L1table(sp);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] L1 ac)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                ac.Type = "update";
                ac.L1Id = id;

                msg = dop.L1table(ac);
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
                L1 ac = new L1();
                ac.Type = "Delete";
                ac.L1Id = id;
                msg = dop.L1table(ac);
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
