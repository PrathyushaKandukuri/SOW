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
    public class JobCodeController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public JobCodeController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        string msg = string.Empty;
        // GET: api/<JobCodeController>
        [HttpGet]
        public List<JobCodeModel> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            JobCodeModel model = new JobCodeModel();
            model.Type = "get";
            DataSet ds = dop.JobCodeTableget(model);
            List<JobCodeModel> list = new List<JobCodeModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new JobCodeModel
                        {
                            JobCodeId= Convert.ToInt32(dr["JobCodeId"]),
                            JobCode = dr["JobCode"].ToString(),
                            JobDescription = dr["JobDescription"].ToString(),
                        });
                    }
                }
            }
            return list;

        }

        // POST api/<JobCodeController>
        [HttpPost]
        public string Post([FromBody] JobCodeModel jobcode)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);

            jobcode.Type = "post";
            string message=string.Empty;
            try
            {
                msg = dop.JobCodeTable(jobcode);

            }
            catch (Exception ex)
            {
                msg=ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
            

        }


        // GET api/<JobCodeController>/5
        [HttpGet("{id}")]
        public List<JobCodeModel> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            JobCodeModel model = new JobCodeModel();
            model.Type = "getid";
            model.JobCodeId = id;
            DataSet ds = dop.JobCodeTableget(model);
            List<JobCodeModel> list = new List<JobCodeModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new JobCodeModel
                        {
                            JobCodeId = Convert.ToInt32(dr["JobCodeId"]),
                            JobCode = dr["JobCode"].ToString(),
                            JobDescription = dr["JobDescription"].ToString(),
                        });
                    }
                }
            }
            return list;

        }



        // PUT api/<JobCodeController>/5
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] JobCodeModel jobcode)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                jobcode.Type = "update";
                jobcode.JobCodeId = id;
                msg = dop.JobCodeTable(jobcode);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            //return msg;
            return JsonConvert.SerializeObject(msg);
        }

        // DELETE api/<JobCodeController>/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;

            try
            {
                JobCodeModel jobcode = new JobCodeModel();
                jobcode.Type = "Delete";
                jobcode.JobCodeId = id;
                msg = dop.JobCodeTable(jobcode);
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
