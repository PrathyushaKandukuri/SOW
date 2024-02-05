using CandidateSoW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public BusinessUnitController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        // GET: api/<BusinessUnitController>
        [HttpGet]
        public List<BussinessUnitModel> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            BussinessUnitModel Bu = new BussinessUnitModel();
            Bu.Type = "get";
            DataSet ds = new DataSet();
            ds=dop.BussinessUnitTableGet(Bu);
            List<BussinessUnitModel> list = new List<BussinessUnitModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new BussinessUnitModel
                        {
                            BussinessUnitId = Convert.ToInt32(dr["BussinessUnitId"]),
                            BussinessUnit = dr["BussinessUnit"].ToString(),
                            BussinessUnitDescription = dr["BussinessUnitDescription"].ToString(),
                        });
                    }
                }
            }
            return list;

        }

        
        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public List<BussinessUnitModel> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            BussinessUnitModel Bu = new BussinessUnitModel();
            Bu.Type = "getid";
            Bu.BussinessUnitId = id;
            DataSet ds = dop.BussinessUnitTableGet(Bu);
            List<BussinessUnitModel> list = new List<BussinessUnitModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new BussinessUnitModel
                        {
                            BussinessUnitId = Convert.ToInt32(dr["BussinessUnitId"]),
                            BussinessUnit = dr["BussinessUnit"].ToString(),
                            BussinessUnitDescription= dr["BussinessUnitDescription"].ToString(),
                        });
                    }
                }
            }
            return list;
        }

        // POST api/<BusinessUnitController>
        [HttpPost]
        public string Post([FromBody] BussinessUnitModel BU)
        {
            string msg = "";
            string dbconn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbconn);
            BU.Type = "post";
            try
            {
                msg=dop.BussinessUnitTable(BU);
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }

        // PUT api/<BusinessUnitController>/5
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] BussinessUnitModel Bu)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                Bu.Type = "update";
                Bu.BussinessUnitId = id;
                msg = dop.BussinessUnitTable(Bu);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            
            return JsonConvert.SerializeObject(msg);
        }

        // DELETE api/<BusinessUnitController>/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;

            try
            {
                BussinessUnitModel Bu = new BussinessUnitModel();
                Bu.Type = "Delete";
                Bu.BussinessUnitId = id;
                msg = dop.BussinessUnitTable(Bu);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            
            return JsonConvert.SerializeObject(msg);
        }
    }
}

