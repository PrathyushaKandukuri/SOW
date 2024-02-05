using CandidateSoW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleDetailsController : ControllerBase
    {
        private IConfiguration configuration;
        public RoleDetailsController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        string msg = string.Empty;

        // GET: api/<AccountController>
        [HttpGet]
        public List<RoleDetails> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            RoleDetails ac = new RoleDetails();
            ac.Type = "get";
            DataSet ds = dop.RoleDetailtableget(ac, msg);
            List<RoleDetails> list = new List<RoleDetails>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new RoleDetails
                        {
                            RoleDetailsId = Convert.ToInt32(dr["RoleDetailId"]),
                            RoleDetailsName = dr["RoleDetails"].ToString(),
                        });
                    }
                }
            }
            return list;
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public List<RoleDetails> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            RoleDetails ac = new RoleDetails();
            ac.Type = "getid";
            ac.RoleDetailsId = id;
            DataSet ds = dop.RoleDetailtableget(ac, msg);
            List<RoleDetails> list = new List<RoleDetails>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new RoleDetails
                        {
                            RoleDetailsId = Convert.ToInt32(dr["RoleDetailId"]),
                            RoleDetailsName = dr["RoleDetails"].ToString(),
                        });
                    }
                }
            }
            return list;
        }

        // POST api/<AccountController>
        [HttpPost]
        public String Post([FromBody] RoleDetails ac)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                msg = dop.RoleDetailtable(ac);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            //return msg;
            return JsonConvert.SerializeObject(msg);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] RoleDetails ac)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                ac.Type = "update";
                ac.RoleDetailsId = id;
                msg = dop.RoleDetailtable(ac);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            //return msg;
            return JsonConvert.SerializeObject(msg);
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;

            try
            {
                RoleDetails ac = new RoleDetails();
                ac.Type = "Delete";
                ac.RoleDetailsId = id;
                msg = dop.RoleDetailtable(ac);
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
