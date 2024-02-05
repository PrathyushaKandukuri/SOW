using CandidateSoW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Xml.Linq;

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private IConfiguration configuration;
        public BillingController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        string msg = string.Empty;

        [HttpGet]
        public List<BillingModel> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            BillingModel sp = new BillingModel();
            sp.Type = "get";
            DataSet ds = dop.billingtableget(sp, msg);
            List<BillingModel> list = new List<BillingModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new BillingModel
                        {
                            BillingId = Convert.ToInt32(dr["BillingId"]),
                            ResourceStartDate = (DateTime)dr["ResourceStartDate"],
                            ResourceEndDate = (DateTime)dr["ResourceEndDate"],
                            Domain = dr["Domain"].ToString(),
                            Currency = dr["Currency"].ToString(),
                            BillRate = (double)dr["BillRate"],
                            Hours = (double)dr["Hours"],
                            TotalBilledhrs = (double)dr["TotalBilledhrs"],
                            SowId = Convert.ToInt32(dr["SowId"]),
                            CandidateId = Convert.ToInt32(dr["CandidateId"]),
                            CustomerTypeId = Convert.ToInt32(dr["CustomerTypeId"]),
                            EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                            ProjectTypeId = Convert.ToInt32(dr["ProjectTypeId"]),

                            Billable = (Boolean)dr["Billable"],
                            ClientProjectRole = dr["ClientProjectRole"].ToString(),
                            ClientProjectRoleDesc = dr["ClientProjectRoleDesc"].ToString(),
                            AliasName = dr["AliasName"].ToString(),
                            AllocationPercentage = Convert.ToDouble(dr["Allocationtage"]),
                            Comments = dr["Comments"].ToString(),
                            ProjectManagerTypeId = Convert.ToInt32(dr["ProjectManagerTypeId"]),
                            ContractCategoryId = Convert.ToInt32(dr["ContractCategoryId"]),
                            DepartmentTypeId = Convert.ToInt32(dr["DepartmentTypeId"]),
                            BussinessUnitId = Convert.ToInt32(dr["BussinessUnitId"]),
                            JobCodeId = Convert.ToInt32(dr["JobCodeId"]),
                            FrequencyId = Convert.ToInt32(dr["FrequencyId"]),

                            CandidateName = dr["CandidateName"].ToString(),
                            CandidateUid = dr["CandidateUid"].ToString(),
                            ContractCategory = dr["ContractCategory"].ToString(),

                            CustomerId = dr["CustomerId"].ToString(),
                            CustomerName = dr["CustomerName"].ToString(),
                            DepartmentId = Convert.ToInt32(dr["DepartmentId"]),

                            DepartmentDescription = dr["DepartmentDescription"].ToString(),

                            EmployeeType = dr["EmployeeType"].ToString(),
                            Frequency = dr["Frequency"].ToString(),

                            JobCode = dr["JobCode"].ToString(),
                            JobDescription = dr["JobDescription"].ToString(),
                            ProjectManagerId = dr["ProjectManagerId"].ToString(),
                            ProjectManagerName = dr["ProjectManagerName"].ToString(),
                            ProjectStartDate = (DateTime)dr["ProjectStartDate"],
                            ProjectEndDate = (DateTime)dr["ProjectEndDate"],
                            ProjectId = dr["ProjectId"].ToString(),
                            ProjectDescription = dr["ProjectDescription"].ToString(),
                            JoiningDate = (DateTime)dr["JoiningDate"],
                            BussinessUnit = dr["BussinessUnit"].ToString(),
                            BussinessUnitDescription = dr["BussinessUnitDescription"].ToString(),
                             LocationTypeId = Convert.ToInt32(dr["LocationTypeId"]),
                            LocationId = dr["LocationId"].ToString(),
                            LocationDescription = dr["LocationDescription"].ToString(),
                            RegionId = Convert.ToInt32(dr["RegionId"]),
                            Region = dr["Region"].ToString(),
                            USTTPMId = Convert.ToInt32(dr["USTTPMId"]),
                            USTTPMUID = dr["USTTPMUID"].ToString(),
                            USTTPMName = dr["USTTPMName"].ToString(),
                            TerminationDate= (DateTime)dr["TerminationDate"],
                            OBU = Convert.ToInt32(dr["OBU"]),
                            OBUDescription = dr["OBUDescription"].ToString()

                        }) ;
                    }
                }
            }
            return list;
        }
        [HttpPost]
        public string Post([FromBody] BillingModel sp)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            sp.Type = "insert"; 
            string msg = string.Empty;
            try
            {
                msg = dop.billingtable(sp);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }



       
        [HttpGet("{projectid}")]
        public List<BillingModel> Get(string projectid)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            BillingModel sp = new BillingModel();
            sp.Type = "getid";
            sp.ProjectId = projectid;
            DataSet ds = dop.billingtableget(sp, msg);
            List<BillingModel> list = new List<BillingModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new BillingModel
                        {
                            BillingId = Convert.ToInt32(dr["BillingId"]),
                            ResourceStartDate = (DateTime)dr["ResourceStartDate"],
                            ResourceEndDate = (DateTime)dr["ResourceEndDate"],
                            Domain = dr["Domain"].ToString(),
                            Currency = dr["Currency"].ToString(),
                            BillRate = (double)dr["BillRate"],
                            Hours = (double)dr["Hours"],
                            TotalBilledhrs = (double)dr["TotalBilledhrs"],
                            SowId = Convert.ToInt32(dr["SowId"]),
                            CandidateId = Convert.ToInt32(dr["CandidateId"]),
                            CustomerTypeId = Convert.ToInt32(dr["CustomerTypeId"]),
                            EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                            ProjectTypeId = Convert.ToInt32(dr["ProjectTypeId"]),

                            Billable = (Boolean)dr["Billable"],
                            ClientProjectRole = dr["ClientProjectRole"].ToString(),
                            ClientProjectRoleDesc = dr["ClientProjectRoleDesc"].ToString(),
                            AliasName = dr["AliasName"].ToString(),
                            AllocationPercentage = Convert.ToDouble(dr["Allocationtage"]),
                            Comments = dr["Comments"].ToString(),
                            ProjectManagerTypeId = Convert.ToInt32(dr["ProjectManagerTypeId"]),
                            ContractCategoryId = Convert.ToInt32(dr["ContractCategoryId"]),
                            DepartmentTypeId = Convert.ToInt32(dr["DepartmentTypeId"]),
                            BussinessUnitId = Convert.ToInt32(dr["BussinessUnitId"]),
                            JobCodeId = Convert.ToInt32(dr["JobCodeId"]),
                            FrequencyId = Convert.ToInt32(dr["FrequencyId"]),

                            CandidateName = dr["CandidateName"].ToString(),
                            CandidateUid = dr["CandidateUid"].ToString(),
                            ContractCategory = dr["ContractCategory"].ToString(),

                            CustomerId = dr["CustomerId"].ToString(),
                            CustomerName = dr["CustomerName"].ToString(),
                            DepartmentId = Convert.ToInt32(dr["DepartmentId"]),

                            DepartmentDescription = dr["DepartmentDescription"].ToString(),

                            EmployeeType = dr["EmployeeType"].ToString(),
                            Frequency = dr["Frequency"].ToString(),

                            JobCode = dr["JobCode"].ToString(),
                            JobDescription = dr["JobDescription"].ToString(),
                            ProjectManagerId = dr["ProjectManagerId"].ToString(),
                            ProjectManagerName = dr["ProjectManagerName"].ToString(),
                            ProjectStartDate = (DateTime)dr["ProjectStartDate"],
                            ProjectEndDate = (DateTime)dr["ProjectEndDate"],
                            ProjectId = dr["ProjectId"].ToString(),
                            ProjectDescription = dr["ProjectDescription"].ToString(),
                            JoiningDate = (DateTime)dr["JoiningDate"],
                            BussinessUnit = dr["BussinessUnit"].ToString(),
                            BussinessUnitDescription = dr["BussinessUnitDescription"].ToString(),
                            LocationTypeId = Convert.ToInt32(dr["LocationTypeId"]),
                            LocationId = dr["LocationId"].ToString(),
                            LocationDescription = dr["LocationDescription"].ToString(),
                            RegionId = Convert.ToInt32(dr["RegionId"]),
                            Region = dr["Region"].ToString(),
                              USTTPMId = Convert.ToInt32(dr["USTTPMId"]),
                            USTTPMUID = dr["USTTPMUID"].ToString(),
                            USTTPMName = dr["USTTPMName"].ToString(),
                            TerminationDate = (DateTime)dr["TerminationDate"],
                            OBU = Convert.ToInt32(dr["OBU"]),
                            OBUDescription = dr["OBUDescription"].ToString()
                        });
                    }
                }
            }
            return list;
        }


        [HttpPut("{id}")]
        public void update([FromBody] BillingModel sp, int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                sp.Type = "update";
                sp.BillingId = id;
                msg = dop.billingtable(sp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                BillingModel sp = new BillingModel();
                sp.Type = "Delete";
                sp.BillingId = id;
                msg = dop.billingtable(sp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }


    }
}
