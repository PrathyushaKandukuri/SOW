using CandidateSoW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IConfiguration configuration;
        public EmployeeController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        string msg = string.Empty;

        // GET: api/<AccountController>
        [HttpGet]
        public List<Employee> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            Employee ac = new Employee();
            ac.Type = "get";
            DataSet ds = dop.Employeetableget(ac, msg);
            List<Employee> list = new List<Employee>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new Employee
                        {
                            EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                            EmployeeType = dr["EmployeeType"].ToString(),
                           
                        });
                    }
                }
            }
            return list;
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public List<Employee> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            Employee ac = new Employee();
            ac.Type = "getid";
            ac.EmployeeId = id;
            DataSet ds = dop.Employeetableget(ac, msg);
           
            List<Employee> list = new List<Employee>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new Employee
                        {
                            EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                            EmployeeType = dr["EmployeeType"].ToString(),

                        });
                    }
                }
            }
            return list;
        }

        // POST api/<AccountController>
        [HttpPost]
        public String Post([FromBody] Employee ac)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            ac.Type = "post";
            try
            {
                msg = dop.Employeetable(ac);
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
        public String Put(int id, [FromBody] Employee ac)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                ac.Type = "update";
                ac.EmployeeId = id;
                msg = dop.Employeetable(ac);
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
                Employee ac = new Employee();
                ac.Type = "Delete";
                ac.EmployeeId = id;
                msg = dop.Employeetable(ac);
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
