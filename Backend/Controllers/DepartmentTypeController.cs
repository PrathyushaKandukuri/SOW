using CandidateSoW.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentTypeController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public DepartmentTypeController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
      
        [HttpGet]
        public List<DepartmentTypeModel> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            DepartmentTypeModel Dep = new DepartmentTypeModel();
            Dep.Type = "get";
            DataSet ds = new DataSet();
            ds = dop.DepartmentTypeTableGet(Dep);
            List<DepartmentTypeModel> list = new List<DepartmentTypeModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new DepartmentTypeModel
                        {
                            DepartmentTypeId = Convert.ToInt32(dr["DepartmentTypeId"]),
                            DepartmentId = Convert.ToInt32(dr["DepartmentId"]),
                            DepartmentDescription = dr["DepartmentDescription"].ToString()

                        });
                    }
                }
            }
            return list;

        }
        [HttpGet("{id}")]
        public List<DepartmentTypeModel> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            DepartmentTypeModel Dep = new DepartmentTypeModel();
            Dep.Type = "getid";
            Dep.DepartmentTypeId = id;
            DataSet ds = new DataSet();
            ds = dop.DepartmentTypeTableGet(Dep);
            List<DepartmentTypeModel> list = new List<DepartmentTypeModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new DepartmentTypeModel
                        {
                            DepartmentTypeId = Convert.ToInt32(dr["DepartmentTypeId"]),
                            DepartmentId = Convert.ToInt32(dr["DepartmentId"]),
                            DepartmentDescription = dr["DepartmentDescription"].ToString()

                        });
                    }
                }
            }
            return list;

        }


       
        [HttpPost]
        public string Post([FromBody] DepartmentTypeModel Dep)
        {
            string msg = "";
            string dbconn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbconn);
            Dep.Type = "post";
            try
            {
                msg = dop.DepartmentTypeTable(Dep);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }

        
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] DepartmentTypeModel Dep)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                Dep.Type = "update";
                Dep.DepartmentTypeId = id;
                msg = dop.DepartmentTypeTable(Dep);
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
                DepartmentTypeModel Bu = new DepartmentTypeModel();
                Bu.Type = "Delete";
                Bu.DepartmentTypeId = id;
                msg = dop.DepartmentTypeTable(Bu);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return JsonConvert.SerializeObject(msg);
        }
    }
}
