using CandidateSoW.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationTypeController : ControllerBase
    {
        private IConfiguration configuration;
        public LocationTypeController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        string msg = string.Empty;
        [HttpGet]
        public List<LocationTypeModel> Get()
        {

            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            LocationTypeModel ls = new LocationTypeModel();
            ls.Type = "get";
            DataSet ds = dop.locationTypetableget(ls, msg);
            List<LocationTypeModel> list = new List<LocationTypeModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new LocationTypeModel
                        {
                            LocationTypeId = Convert.ToInt32(dr["LocationTypeId"]),
                            LocationId = dr["LocationId"].ToString(),
                            LocationDescription = dr["LocationDescription"].ToString(),
                            RegionId = Convert.ToInt32(dr["RegionId"]),
                        });
                    }
                }
            }
            return list;
        }



        // GET: api/<LocationController>
        [HttpGet]
        [Route("getbyregion")]
        public List<LocationTypeModel> GetByRegion(int id)
        {

            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            LocationTypeModel ls = new LocationTypeModel();
            ls.Type = "getbyregionid";
            ls.RegionId = id;
            DataSet ds = dop.locationTypetableget(ls, msg);
            List<LocationTypeModel> list = new List<LocationTypeModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new LocationTypeModel
                        {
                            //LocationTypeId = Convert.ToInt32(dr["LocationId"]),
                            LocationId = dr["LocationId"].ToString(),
                            LocationDescription = dr["LocationDescription"].ToString(),
                            RegionId = Convert.ToInt32(dr["RegionId"]),
                        });
                    }
                }
            }
            return list;
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public List<LocationTypeModel> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            LocationTypeModel ls = new LocationTypeModel();
            ls.Type = "getid";
            ls.LocationTypeId = id;
            DataSet ds = dop.locationTypetableget(ls, msg);
            List<LocationTypeModel> list = new List<LocationTypeModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new LocationTypeModel
                        {
                            //LocationTypeId = Convert.ToInt32(dr["LocationId"]),
                            LocationId = dr["LocationId"].ToString(),
                            LocationDescription = dr["LocationDescription"].ToString(),
                            RegionId = Convert.ToInt32(dr["RegionId"]),
                        });
                    }
                }
            }
            return list;
        }

        // POST api/<LocationController>
        [HttpPost]
        public String Post([FromBody] LocationTypeModel ls)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            ls.Type = "post";
            string msg = string.Empty;
            try
            {
                msg = dop.locationTypetable(ls);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            //return msg;
            return JsonConvert.SerializeObject(msg);
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] LocationTypeModel ls)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                ls.Type = "update";
                ls.LocationTypeId = id;
                msg = dop.locationTypetable(ls);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            //return msg;
            return JsonConvert.SerializeObject(msg);
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                LocationTypeModel ls = new LocationTypeModel();
                ls.Type = "Delete";
                ls.LocationTypeId = id;
                msg = dop.locationTypetable(ls);
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
