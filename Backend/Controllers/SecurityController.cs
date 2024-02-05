using CandidateSoW.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandidateSoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private IConfiguration configuration;
        public SecurityController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        string msg = string.Empty;

        [HttpGet]
        public List<SecurityQuestionModel> Get()
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            SecurityQuestionModel st = new SecurityQuestionModel();
            st.Type = "get";
            DataSet ds = dop.GetSecurityQuestions(st, msg);
            List<SecurityQuestionModel> list = new List<SecurityQuestionModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new SecurityQuestionModel
                        {
                            QuestionId = Convert.ToInt32(dr["QuestionId"]),
                            Question = dr["Question"].ToString(),
                        });
                    }
                }
            }
            return list;
        }

        [HttpGet("{id}")]
        public List<SecurityQuestionModel> Get(int id)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            SecurityQuestionModel st = new SecurityQuestionModel();
            st.Type = "getid";
            st.QuestionId = id;
            DataSet ds = dop.GetSecurityQuestions(st, msg);
            List<SecurityQuestionModel> list = new List<SecurityQuestionModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new SecurityQuestionModel
                        {
                            QuestionId = Convert.ToInt32(dr["QuestionId"]),
                            Question = dr["Question"].ToString(),
                        });
                    }
                }
            }
            return list;
        }

        [HttpPost]
        public string Post([FromBody] SecurityAnswerModel st)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                msg = dop.SecurityAnswertable(st);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return JsonConvert.SerializeObject(msg);
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] SecurityAnswerModel st)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            string msg = string.Empty;
            try
            {
                st.Type = "update";
                st.AnswerId = id;
                msg = dop.SecurityAnswertable(st);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return JsonConvert.SerializeObject(msg);
        }

        [HttpPost]
        [Route("ValidateSecurityAnswers")]
        public string ValidateSecurityAnswers([FromBody] SecurityAnswerModel st)
        {

            string message = string.Empty;

            try
            {
                // Call the ValidateSecurityAnswers method passing the required parameters
                string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
                Db dop = new Db(dbConn);
                message = dop.ValidateSecurityAnswers(st);


            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return JsonConvert.SerializeObject(message);
        }




        [HttpGet]
        [Route("SecurityAnswer")]
        public List<SecurityAnswerModel> GetAnswer(string emailid)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            SecurityAnswerModel st = new SecurityAnswerModel();
            st.Type = "get";
            st.EmailId = emailid;
            DataSet ds = dop.GetSecurityAnswers(st, msg);
            List<SecurityAnswerModel> list = new List<SecurityAnswerModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new SecurityAnswerModel
                        {
                            AnswerId = Convert.ToInt32(dr["AnswerId"]),
                            EmailId = Convert.ToString(dr["Emailid"]),

                            QuestionId1 = Convert.ToInt32(dr["QuestionId1"]),
                            Answer1 = dr["Answer1"].ToString(),

                            QuestionId2 = Convert.ToInt32(dr["QuestionId2"]),
                            Answer2 = dr["Answer2"].ToString(),

                            QuestionId3 = Convert.ToInt32(dr["QuestionId3"]),
                            Answer3 = dr["Answer3"].ToString()
                        });
                    }
                }
            }
            return list;
        }


        [HttpGet]
        [Route("GetSelectedSecurityQns")]
        public List<SecurityAnswerModel> GetSelectedSecurityQuestions(string emailid)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            SecurityAnswerModel st = new SecurityAnswerModel();
            st.Type = "getquestions";
            st.EmailId = emailid;
            List<SecurityAnswerModel> list = new List<SecurityAnswerModel>();
            List<int> selectedQuestions = new List<int>();

            while (selectedQuestions.Count < 3)
            {
                int randomQuestionId = new Random().Next(1, 13); // Assuming question IDs range from 1 to 12

                if (!selectedQuestions.Contains(randomQuestionId))
                {
                    selectedQuestions.Add(randomQuestionId);

                    st.QuestionId1 = randomQuestionId;
                    st.QuestionId2 = selectedQuestions.Count >= 2 ? new Random().Next(1, 13) : 0;
                    st.QuestionId3 = selectedQuestions.Count >= 3 ? new Random().Next(1, 13) : 0;

                    DataSet ds = dop.GetSecurityQns(st);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        list.Add(new SecurityAnswerModel
                        {
                            QuestionId1 = Convert.ToInt32(dr["QuestionId1"]),
                            QuestionId2 = Convert.ToInt32(dr["QuestionId2"]),
                            QuestionId3 = Convert.ToInt32(dr["QuestionId3"])
                        });
                    }
                }
            }

            return list;
        }




        [HttpGet]
        [Route("GetSecurityQns")]
        public List<SecurityAnswerModel> GetSecurityQuestions(string emailid)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            Db dop = new Db(dbConn);
            SecurityAnswerModel st = new SecurityAnswerModel();
            st.Type = "getquestions";
            st.EmailId = emailid;
            DataSet ds = dop.GetSecurityQns(st);
            List<SecurityAnswerModel> list = new List<SecurityAnswerModel>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new SecurityAnswerModel
                        {

                            QuestionId1 = Convert.ToInt32(dr["QuestionId1"]),


                            QuestionId2 = Convert.ToInt32(dr["QuestionId2"]),


                            QuestionId3 = Convert.ToInt32(dr["QuestionId3"]),

                        });
                    }
                }
            }
            return list;
        }
    }
}
