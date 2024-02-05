using CandidateSoW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private IConfiguration configuration;
        public ProjectController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        string msg = string.Empty;

        // GET: api/<AccountController>
        [HttpGet]
        public List<ProjectType> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            ProjectType ac = new ProjectType();
            ac.Type = "get";
            DataSet ds = dop.Projecttableget(ac, msg);
            List<ProjectType> list = new List<ProjectType>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new ProjectType
                        {
                            ProjectTypeId = Convert.ToInt32(dr["ProjectTypeId"]),
                            ProjectId =dr["ProjectId"].ToString(),
                            ProjectDescription = dr["ProjectDescription"].ToString(),
                            ProjectStartDate = (DateTime)dr["ProjectStartDate"],
                            ProjectEndDate = (DateTime)dr["ProjectEndDate"],
                        });
                    }
                }
            }
            return list;
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public List<ProjectType> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            ProjectType ac = new ProjectType();
            ac.Type = "getid";
            ac.ProjectTypeId = id;
            DataSet ds = dop.Projecttableget(ac, msg);
            List<ProjectType> list = new List<ProjectType>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new ProjectType
                        {
                            ProjectTypeId = Convert.ToInt32(dr["ProjectTypeId"]),
                            ProjectId = dr["ProjectId"].ToString(),
                            ProjectDescription = dr["ProjectDescription"].ToString(),
                            ProjectStartDate = (DateTime)dr["ProjectStartDate"],
                            ProjectEndDate = (DateTime)dr["ProjectEndDate"],
                        });
                    }
                }
            }
            return list;
        }

        // POST api/<AccountController>
        [HttpPost]
        public String Post([FromBody] ProjectType ac)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            ac.Type = "post";
            try
            {
                msg = dop.Projecttable(ac);
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
        public String Put(int id, [FromBody] ProjectType ac)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                ac.Type = "update";
                ac.ProjectTypeId = id;
                msg = dop.Projecttable(ac);
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
                ProjectType ac = new ProjectType();
                ac.Type = "Delete";
                ac.ProjectTypeId = id;
                msg = dop.Projecttable(ac);
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
