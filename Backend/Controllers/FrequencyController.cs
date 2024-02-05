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
    public class FrequencyController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public FrequencyController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        string msg = string.Empty;



        [HttpGet]
        public List<FrequencyModel> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            FrequencyModel model = new FrequencyModel();
            model.Type = "get";
            DataSet ds = dop.FrequencyTableget(model);
            List<FrequencyModel> list = new List<FrequencyModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new FrequencyModel
                        {
                            FrequencyId = Convert.ToInt32(dr["FrequencyId"]),
                            Frequency = dr["Frequency"].ToString(),
                           
                        });
                    }
                }
            }
            return list;

        }

        
        [HttpPost]
        public string Post([FromBody] FrequencyModel frequencyModel)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);

            frequencyModel.Type = "post";
            string message = string.Empty;
            try
            {
                msg = dop.FrequencyTable(frequencyModel);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return JsonConvert.SerializeObject(msg);


        }


        
        [HttpGet("{id}")]
        public List<FrequencyModel> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            FrequencyModel model = new FrequencyModel();
            model.Type = "getid";
            model.FrequencyId= id;
            DataSet ds = dop.FrequencyTableget(model);
            List<FrequencyModel> list = new List<FrequencyModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new FrequencyModel
                        {
                            FrequencyId = Convert.ToInt32(dr["FrequencyId"]),
                            Frequency = dr["Frequency"].ToString(),

                        });
                    }
                }
            }
            return list;

        }



        
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] FrequencyModel frequencyModel)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                frequencyModel.Type = "update";
                frequencyModel.FrequencyId = id;
                msg = dop.FrequencyTable(frequencyModel);
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
                FrequencyModel frequencyModel = new FrequencyModel();
                frequencyModel.Type = "Delete";
                frequencyModel.FrequencyId = id;
                msg = dop.FrequencyTable(frequencyModel);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            
            return JsonConvert.SerializeObject(msg);
        }
    }
}
