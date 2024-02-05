using CandidateSoW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IConfiguration configuration;
        public CustomerController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        string msg = string.Empty;

        // GET: api/<AccountController>
        [HttpGet]
        public List<CustomerType> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            CustomerType ac = new CustomerType();
            ac.Type = "get";
            DataSet ds = dop.Customertableget(ac, msg);
            List<CustomerType> list = new List<CustomerType>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new CustomerType
                        {
                            CustomerTypeId = Convert.ToInt32(dr["CustomerTypeId"]),
                            CustomerId = dr["CustomerId"].ToString(),
                            CustomerName = dr["CustomerName"].ToString(),
                        });
                    }
                }
            }
            return list;
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public List<CustomerType> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            CustomerType ac = new CustomerType();
            ac.Type = "getid";
            ac.CustomerTypeId = id;
            DataSet ds = dop.Customertableget(ac, msg);
            List<CustomerType> list = new List<CustomerType>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new CustomerType
                        {
                            CustomerTypeId = Convert.ToInt32(dr["CustomerTypeId"]),
                            CustomerId = dr["CustomerId"].ToString(),
                            CustomerName = dr["CustomerName"].ToString(),
                        });
                    }
                }
            }
            return list;
        }

        // POST api/<AccountController>
        [HttpPost]
        public String Post([FromBody] CustomerType ac)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            ac.Type = "post";
            try
            {
                msg = dop.Customertable(ac);
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
        public String Put(int id, [FromBody] CustomerType ac)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                ac.Type = "update";
                ac.CustomerTypeId = id;
                msg = dop.Customertable(ac);
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
                CustomerType ac = new CustomerType();
                ac.Type = "Delete";
                ac.CustomerTypeId = id;
                msg = dop.Customertable(ac);
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
