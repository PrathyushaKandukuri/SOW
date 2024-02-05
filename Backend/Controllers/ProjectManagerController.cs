using CandidateSoW.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagerController : ControllerBase
    {

        private IConfiguration configuration;
        public ProjectManagerController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        string msg = string.Empty;
        // GET: api/<ProjectManagerController>
        [HttpGet]
        public List<ProjectManagerModel> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop=new Db(dbConn);
            ProjectManagerModel pm = new ProjectManagerModel();
            pm.Type = "get";
            DataSet ds = dop.ProjectManagerTableGet(pm);
            List<ProjectManagerModel> list = new List<ProjectManagerModel>(); 
            if(ds.Tables.Count > 0)
            {
                if(ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new ProjectManagerModel
                        {
                            ProjectManagerTypeId = Convert.ToInt32(dr["ProjectManagerTypeId"]),
                            ProjectManagerId = dr["ProjectManagerId"].ToString(),
                            ProjectManagerName = dr["ProjectManagerName"].ToString(),
                           
                        });
                    }
                }
            }
            return list;
        }
       


        // GET api/<ProjectManagerController>/5
        [HttpGet("{id}")]
        public List<ProjectManagerModel> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            ProjectManagerModel pm = new ProjectManagerModel();
            pm.Type = "getid";
            pm.ProjectManagerTypeId = id;
            DataSet ds = dop.ProjectManagerTableGet(pm);
            List<ProjectManagerModel> list = new List<ProjectManagerModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new ProjectManagerModel
                        {
                            ProjectManagerTypeId = Convert.ToInt32(dr["ProjectManagerTypeId"]),
                            ProjectManagerId = dr["ProjectManagerId"].ToString(),
                            ProjectManagerName = dr["ProjectManagerName"].ToString(),
                           
                        });
                    }
                }
            }
            return list;
        }

        // POST api/<ProjectManagerController>
        [HttpPost]
        public string Post([FromBody] ProjectManagerModel pm)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            pm.Type = "Post";
            string msg = string.Empty;
            try
            {
                msg = dop.ProjectManagerTable(pm);
            }
            catch(Exception ex)
            {
                msg=ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }

        // PUT api/<ProjectManagerController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] ProjectManagerModel pm)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                pm.Type = "update";
                pm.ProjectManagerTypeId = id;
                msg = dop.ProjectManagerTable(pm);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }

        // DELETE api/<ProjectManagerController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                ProjectManagerModel pm=new ProjectManagerModel();
                pm.Type = "Delete";
                pm.ProjectManagerTypeId=id;
                msg = dop.ProjectManagerTable(pm);
            }
            catch(Exception ex)
            {
                msg=ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }
    }
}
