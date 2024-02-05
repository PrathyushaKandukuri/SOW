using CandidateSoW.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractCategoryController : ControllerBase
    {

        private IConfiguration configuration;
        public ContractCategoryController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        string msg = string.Empty;

        // GET: api/<ContractCategoryController>
        [HttpGet]
        public List<ContractCategoryModel> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            ContractCategoryModel ct = new ContractCategoryModel();
            ct.Type = "get";
            DataSet ds = dop.ContractCategoryGet(ct);
            List<ContractCategoryModel> list = new List<ContractCategoryModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new ContractCategoryModel
                        {
                            ContractCategoryId = Convert.ToInt32(dr["ContractCategoryId"]),
                            ContractCategory = dr["ContractCategory"].ToString(),
                        });
                    }
                }
            }
            return list;
        }

        // GET api/<ContractCategoryController>/5
        [HttpGet("{id}")]
        public List<ContractCategoryModel> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            ContractCategoryModel ct = new ContractCategoryModel();
            ct.Type = "getid";
            ct.ContractCategoryId = id;
            DataSet ds = dop.ContractCategoryGet(ct);
            List<ContractCategoryModel> list = new List<ContractCategoryModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new ContractCategoryModel
                        {
                            ContractCategoryId = Convert.ToInt32(dr["ContractCategoryId"]),
                            ContractCategory = dr["ContractCategory"].ToString(),
                        });
                    }
                }
            }
            return list;
        }


        // POST api/<ContractCategoryController>
        [HttpPost]
        public string Post([FromBody] ContractCategoryModel ct)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            ct.Type = "Post";
            string msg = string.Empty;
            try
            {
                msg = dop.ContractCategoryTable(ct);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }

        // PUT api/<ContractCategoryController>/5
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] ContractCategoryModel ct)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                ct.Type = "update";
                ct.ContractCategoryId = id;
                msg = dop.ContractCategoryTable(ct);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            //return msg;
            return JsonConvert.SerializeObject(msg);
        }

        // DELETE api/<ContractCategoryController>/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;

            try
            {
                ContractCategoryModel ct = new ContractCategoryModel();
                ct.Type = "Delete";
                ct.ContractCategoryId = id;
                msg = dop.ContractCategoryTable(ct);
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
