using CandidateSoW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class L2Controller : ControllerBase
    {
        private IConfiguration configuration;
        public L2Controller(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        string msg = string.Empty;


        [HttpGet]
        public List<L2Model> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            L2Model ac = new L2Model();
            ac.Type = "get";
            DataSet ds = dop.L2Tableget(ac, msg);
            List<L2Model> list = new List<L2Model>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new L2Model
                        {
                            L2Id = Convert.ToInt32(dr["L2Id"]),
                            L2Selected = Convert.ToInt32(dr["L2Selected"]),
                            L2Rejected = Convert.ToInt32(dr["L2Rejected"]),
                            L2 = Convert.ToInt32(dr["L2"]),
                            L1Id = Convert.ToInt32(dr["L1Id"]),
                            Onhold = Convert.ToInt32(dr["Onhold"])
                        });
                    }
                }
            }
            return list;
        }

        [HttpGet("{id}")]
        public List<L2Model> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            L2Model ac = new L2Model();

            ac.Type = "getid";
            ac.L2Id = id;
            DataSet ds = dop.L2Tableget(ac, msg);
            List<L2Model> list = new List<L2Model>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new L2Model
                        {
                            L2Id = Convert.ToInt32(dr["L2Id"]),
                            L2Selected = Convert.ToInt32(dr["L2Selected"]),
                            L2Rejected = Convert.ToInt32(dr["L2Rejected"]),
                            L2 = Convert.ToInt32(dr["L2"]),
                            L1Id = Convert.ToInt32(dr["L1Id"]),
                            Onhold = Convert.ToInt32(dr["Onhold"])
                        });
                    }
                }
            }
            return list;
        }

        [HttpPost]
        public string Post([FromBody] L2Model sp)
        {


            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);


            string msg = string.Empty;
            try
            {
                sp.Type = "insert";

                //sp.L1Total = sp.Screening;


                msg = dop.L2table(sp);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] L2Model ac)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                ac.Type = "update";
                ac.L2Id = id;
                msg = dop.L2table(ac);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
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
                L2Model ac = new L2Model();
                ac.Type = "Delete";
                ac.L2Id = id;
                msg = dop.L2table(ac);
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
