
using CandidateSoW.Common;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CandidateSoW.Models
{
    public class Db
    {

        private string connstr;
        //private readonly ILogger _logger;

        public Db(string dbConn)
        {
            connstr = dbConn;

        }
        //public Db(ILogger logger)
        //{
        //    _logger = logger;
        //}





        public string sowtable(Sow sp)
        {
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("Sow_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SowId", sp.SowId);
                cmd.Parameters.AddWithValue("@SoName", sp.SoName);
                cmd.Parameters.AddWithValue("@JRCode", sp.JRCode);
                cmd.Parameters.AddWithValue("@RequestCreationDate", sp.RequestCreationDate);
                cmd.Parameters.AddWithValue("@AccountId", sp.AccountId);
                cmd.Parameters.AddWithValue("@TechnologyId", sp.TechnologyId);
                cmd.Parameters.AddWithValue("@Comments", sp.Comments);
                cmd.Parameters.AddWithValue("@LocationId", sp.LocationId);
                cmd.Parameters.AddWithValue("@RegionId", sp.RegionId);
                cmd.Parameters.AddWithValue("@TargetOpenPositions", sp.TargetOpenPositions);
                cmd.Parameters.AddWithValue("@PositionsTobeClosed", sp.PositionsTobeClosed);
                cmd.Parameters.AddWithValue("@USTPOCId", sp.USTPOCId);
                cmd.Parameters.AddWithValue("@RecruiterId", sp.RecruiterId);
                cmd.Parameters.AddWithValue("@USTTPMId", sp.USTTPMId);
                cmd.Parameters.AddWithValue("@DellManagerId", sp.DellManagerId);
                cmd.Parameters.AddWithValue("@StatusId", sp.StatusId);
                cmd.Parameters.AddWithValue("@Band", sp.Band);
                cmd.Parameters.AddWithValue("@ProjectId", sp.ProjectId);
                cmd.Parameters.AddWithValue("@AccountManager", sp.AccountManager);
                cmd.Parameters.AddWithValue("@ExternalResource", string.IsNullOrEmpty(sp.ExternalResource) ? (object)DBNull.Value : sp.ExternalResource);
                cmd.Parameters.AddWithValue("@InternalResource", string.IsNullOrEmpty(sp.InternalResource) ? (object)DBNull.Value : sp.InternalResource);

                cmd.Parameters.AddWithValue("@Type", sp.Type);
                cmd.Parameters.AddWithValue("@Onboardingdate", sp.Onboardingdate);
                cmd.Parameters.AddWithValue("@IsOnHold", sp.IsOnHold);
                cmd.Parameters.AddWithValue("@JobDesc", sp.JobDesc);
                cmd.Parameters.AddWithValue("@RoledetailsId", sp.RoleDetailsId);
                cmd.Parameters.AddWithValue("@experienceinyears", sp.experienceinyears);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }

                con.Close();


            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;
        }
        public string imp_candidateData(string jsonData)
        {

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string msg = string.Empty;
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_candidateDataImport", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@json", jsonData);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        msg = rdr["status"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                }
                return msg;
            }
        }

       


        public string imp_candidatePAN(string jsonData)
        {

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string msg = string.Empty;
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_candidateDataImport_PAN", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAN", jsonData);
                 //   cmd.Parameters.AddWithValue("@Status", jsonData);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        msg = rdr["status"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                }
                return msg;
            }
        }





        public string imp_sowData(string jsonData)
        {

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string msg = string.Empty;
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_sowDataImport", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@json", jsonData);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        msg = rdr["status"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                }
                return msg;
            }
        }

        //get record
        public DataSet sowtableget(Sow sp, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Sow_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SowId", sp.SowId);
                cmd.Parameters.AddWithValue("@SoName", sp.SoName);
                cmd.Parameters.AddWithValue("@JRCode", sp.JRCode);
                cmd.Parameters.AddWithValue("@RequestCreationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@AccountId", sp.AccountId);
                cmd.Parameters.AddWithValue("@TechnologyId", sp.TechnologyId);
                cmd.Parameters.AddWithValue("@Comments", sp.Comments);
                cmd.Parameters.AddWithValue("@LocationId", sp.LocationId);
                cmd.Parameters.AddWithValue("@RegionId", sp.RegionId);
                cmd.Parameters.AddWithValue("@TargetOpenPositions", sp.TargetOpenPositions);
                cmd.Parameters.AddWithValue("@PositionsTobeClosed", sp.PositionsTobeClosed);
                cmd.Parameters.AddWithValue("@USTPOCId", sp.USTPOCId);
                cmd.Parameters.AddWithValue("@RecruiterId", sp.RecruiterId);
                cmd.Parameters.AddWithValue("@USTTPMId", sp.USTTPMId);
                cmd.Parameters.AddWithValue("@DellManagerId", sp.DellManagerId);
                cmd.Parameters.AddWithValue("@StatusId", sp.StatusId);
                cmd.Parameters.AddWithValue("@Band", sp.Band);
                cmd.Parameters.AddWithValue("@ProjectId", sp.ProjectId);
                cmd.Parameters.AddWithValue("@AccountManager", sp.AccountManager);
                //cmd.Parameters.AddWithValue("@ExternalResource", sp.ExternalResource);
                //cmd.Parameters.AddWithValue("@InternalResource", sp.InternalResource);

                cmd.Parameters.AddWithValue("@ExternalResource", string.IsNullOrEmpty(sp.ExternalResource) ? (object)DBNull.Value : sp.ExternalResource);
                cmd.Parameters.AddWithValue("@InternalResource", string.IsNullOrEmpty(sp.InternalResource) ? (object)DBNull.Value : sp.InternalResource);

                cmd.Parameters.AddWithValue("@Type", sp.Type);
                cmd.Parameters.AddWithValue("@Onboardingdate", sp.Onboardingdate);
                cmd.Parameters.AddWithValue("@IsOnHold", sp.IsOnHold);
                cmd.Parameters.AddWithValue("@JobDesc", sp.JobDesc);
                cmd.Parameters.AddWithValue("@RoledetailsId", sp.RoleDetailsId);
                cmd.Parameters.AddWithValue("@experienceinyears", sp.experienceinyears);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        public List<CandidateModel> GetAllCandidateData(CandidateModel candidateModel)
        {
            
            string msg = string.Empty;
            List<CandidateModel> lstmain = new List<CandidateModel>();
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_getAllCandidateData", con);
                cmd.CommandType = CommandType.StoredProcedure;
              
                cmd.Parameters.AddWithValue("@CandidateId", candidateModel.CandidateId);
                cmd.Parameters.AddWithValue("@Type",candidateModel.Type );
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CandidateModel obj = new CandidateModel();
                    obj.CandidateId = Int32.Parse(dt.Rows[i]["CandidateId"].ToString() ?? "0");
                    obj.CandidateName = dt.Rows[i]["CandidateName"].ToString();
                    obj.CandidateUid = dt.Rows[i]["CandidateUid"].ToString();
                    obj.DOB = DateTime.Parse(dt.Rows[i]["DOB"].ToString() ?? "2000-01-01");
                    obj.Address = dt.Rows[i]["Address"].ToString();
                    obj.Status = dt.Rows[i]["Status"].ToString(); ;
                    obj.Pincode = dt.Rows[i]["Pincode"].ToString();
                    obj.Email = dt.Rows[i]["EmailId"].ToString();
                    obj.Skills = dt.Rows[i]["Skills"].ToString();
                    obj.Gender = dt.Rows[i]["Gender"].ToString();
                    obj.JoiningDate = DateTime.Parse(dt.Rows[i]["JoiningDate"].ToString() ?? "2000-01-01");
                    obj.isInternal = Boolean.Parse(dt.Rows[i]["isInternal"].ToString() ?? "false");
                    obj.MobileNo = dt.Rows[i]["MobileNo"].ToString();
                    obj.Location = dt.Rows[i]["Location"].ToString();
                    obj.PAN = dt.Rows[i]["PAN"].ToString();
                    obj.PANNumber = dt.Rows[i]["PANNumber"].ToString();
                    //obj.TerminationDate = DateTime.Parse(dt.Rows[i]["TerminationDate"].ToString() ?? "2000-01-01");
                    lstmain.Add(obj);
                }
                return lstmain;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return lstmain;
        }

        public List<CandidateModel> GetCandidateById(int id)
        {
            CandidateModel candidateModel = new CandidateModel();
            candidateModel.CandidateId=id;
            candidateModel.Type = "getbyid";
            string msg = string.Empty;
            List<CandidateModel> lstmain = new List<CandidateModel>();
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_getAllCandidateData", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CandidateId", candidateModel.CandidateId);
                cmd.Parameters.AddWithValue("@Type", candidateModel.Type);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CandidateModel obj = new CandidateModel();
                    obj.CandidateId = Int32.Parse(dt.Rows[i]["CandidateId"].ToString() ?? "0");
                    obj.CandidateName = dt.Rows[i]["CandidateName"].ToString();
                    obj.CandidateUid = dt.Rows[i]["CandidateUid"].ToString();
                    obj.DOB = DateTime.Parse(dt.Rows[i]["DOB"].ToString() ?? "2000-01-01");
                    obj.Address = dt.Rows[i]["Address"].ToString();
                    obj.Status = dt.Rows[i]["Status"].ToString(); ;
                    obj.Pincode = dt.Rows[i]["Pincode"].ToString();
                    obj.Email = dt.Rows[i]["EmailId"].ToString();
                    obj.Skills = dt.Rows[i]["Skills"].ToString();
                    obj.Gender = dt.Rows[i]["Gender"].ToString();
                    obj.JoiningDate = DateTime.Parse(dt.Rows[i]["JoiningDate"].ToString() ?? "2000-01-01");
                    obj.isInternal = Boolean.Parse(dt.Rows[i]["isInternal"].ToString() ?? "false");
                    obj.MobileNo = dt.Rows[i]["MobileNo"].ToString();
                    obj.Location = dt.Rows[i]["Location"].ToString();
                    obj.PAN = dt.Rows[i]["PAN"].ToString();
                    obj.PANNumber = dt.Rows[i]["PANNumber"].ToString();
                    //obj.TerminationDate = DateTime.Parse(dt.Rows[i]["TerminationDate"].ToString() ?? "2000-01-01");
                    lstmain.Add(obj);
                }
                return lstmain;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return lstmain;
        }

        public string candidateTable(CandidateModel candidate)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string msg = string.Empty;
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_addCandidateData", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CandidateName", candidate.CandidateName);
                    cmd.Parameters.AddWithValue("@CandidateUid", candidate.CandidateUid);
                    cmd.Parameters.AddWithValue("@EmailId", candidate.Email);
                    cmd.Parameters.AddWithValue("@MobileNo", candidate.MobileNo);
                    if (candidate.DOB.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@DOB", candidate.DOB.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
                    }


                   // cmd.Parameters.AddWithValue("@DOB", candidate.DOB);
                    cmd.Parameters.AddWithValue("@Location", candidate.Location);

                    if (candidate.JoiningDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@JoiningDate", candidate.JoiningDate.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@JoiningDate", DBNull.Value);
                    }

                   // cmd.Parameters.AddWithValue("@JoiningDate", candidate.JoiningDate);
                    cmd.Parameters.AddWithValue("@Skills", candidate.Skills);
                    cmd.Parameters.AddWithValue("@IsInternal", candidate.isInternal);
                    //cmd.Parameters.AddWithValue("@Address", candidate.Address);
                    cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(candidate.Address) ? (object)DBNull.Value : candidate.Address);

                    // cmd.Parameters.AddWithValue("@Pincode", candidate.Pincode);
                    cmd.Parameters.AddWithValue("@Pincode", string.IsNullOrEmpty(candidate.Pincode) ? (object)DBNull.Value : candidate.Pincode);

                    cmd.Parameters.AddWithValue("@Status", candidate.Status);
                    cmd.Parameters.AddWithValue("@Gender", candidate.Gender);
                    cmd.Parameters.AddWithValue("@PAN", candidate.PAN);
                    cmd.Parameters.AddWithValue("@PANNumber", candidate.PANNumber);
                    // cmd.Parameters.AddWithValue("@TerminationDate", candidate.TerminationDate);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        msg = rdr["status"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                }
                return msg;
            }
        }
        public string updateCandidateTable(int id, CandidateModel candidate)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string msg = string.Empty;
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_editCandidateData", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CandidateId", id);
                    cmd.Parameters.AddWithValue("@CandidateName", candidate.CandidateName);
                    cmd.Parameters.AddWithValue("@candidateUid", candidate.CandidateUid);
                    cmd.Parameters.AddWithValue("@EmailId", candidate.Email);
                    cmd.Parameters.AddWithValue("@MobileNo", candidate.MobileNo);
                    cmd.Parameters.AddWithValue("@DOB", candidate.DOB);
                    cmd.Parameters.AddWithValue("@Location", candidate.Location);
                    cmd.Parameters.AddWithValue("@JoiningDate", candidate.JoiningDate);
                    cmd.Parameters.AddWithValue("@Skills", candidate.Skills);
                    cmd.Parameters.AddWithValue("@IsInternal", candidate.isInternal);
                    cmd.Parameters.AddWithValue("@Address", candidate.Address);
                    cmd.Parameters.AddWithValue("@Pincode", candidate.Pincode);
                    cmd.Parameters.AddWithValue("@Status", candidate.Status);
                    cmd.Parameters.AddWithValue("@Gender", candidate.Gender);
                    cmd.Parameters.AddWithValue("@PAN", candidate.PAN);
                    cmd.Parameters.AddWithValue("@PANNumber", candidate.PANNumber);
                    //   cmd.Parameters.AddWithValue("@TerminationDate", candidate.TerminationDate);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    msg = "Success";
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                }
                return msg;
            }
        }
        public string deleteCandidateData(int id)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                string msg = string.Empty;
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_deleteCandidateData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CandidateId", id);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        msg = rdr["status"].ToString();
                    }

                    con.Close();


                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                }
                return msg;
            }
        }
        public string sowcandidatetable(SoWCandidateModel sc)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);

            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("SowCandidate_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SOW_CandidateId", sc.SOW_CandidateId);
                cmd.Parameters.AddWithValue("@SowId", sc.SowId);
                cmd.Parameters.AddWithValue("@CandidateId", sc.CandidateId);
                cmd.Parameters.AddWithValue("@StatusId", sc.StatusId);
                cmd.Parameters.AddWithValue("@MappingDate", sc.MappingDate);
                cmd.Parameters.AddWithValue("@Type", sc.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
                con.Close();
               
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

        //get record
        public DataSet SowcandidatetableGet(SoWCandidateModel sc, string msg)
        {
            msg = string.Empty;

            SqlConnection con = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SowCandidate_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SOW_CandidateId", sc.SOW_CandidateId);
                cmd.Parameters.AddWithValue("@SowId", sc.SowId);
                cmd.Parameters.AddWithValue("@CandidateId", sc.CandidateId);
                cmd.Parameters.AddWithValue("@StatusId", sc.StatusId);
                cmd.Parameters.AddWithValue("@MappingDate", sc.MappingDate);
                cmd.Parameters.AddWithValue("@Type", sc.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public DataSet sowtablegetForCandidateMapping(Sow sp, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Sow_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SowId", sp.SowId);
                cmd.Parameters.AddWithValue("@SoName", sp.SoName);
                cmd.Parameters.AddWithValue("@JRCode", sp.JRCode);
                cmd.Parameters.AddWithValue("@RequestCreationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@AccountId", sp.AccountId);
                cmd.Parameters.AddWithValue("@TechnologyId", sp.TechnologyId);
                cmd.Parameters.AddWithValue("@Comments", sp.Comments);
                cmd.Parameters.AddWithValue("@LocationId", sp.LocationId);
                cmd.Parameters.AddWithValue("@RegionId", sp.RegionId);
                cmd.Parameters.AddWithValue("@TargetOpenPositions", sp.TargetOpenPositions);
                cmd.Parameters.AddWithValue("@PositionsTobeClosed", sp.PositionsTobeClosed);
                cmd.Parameters.AddWithValue("@USTPOCId", sp.USTPOCId);
                cmd.Parameters.AddWithValue("@RecruiterId", sp.RecruiterId);
                cmd.Parameters.AddWithValue("@USTTPMId", sp.USTTPMId);
                cmd.Parameters.AddWithValue("@DellManagerId", sp.DellManagerId);
                cmd.Parameters.AddWithValue("@StatusId", sp.StatusId);
                cmd.Parameters.AddWithValue("@Band", sp.Band);
                cmd.Parameters.AddWithValue("@ProjectId", sp.ProjectId);
                cmd.Parameters.AddWithValue("@AccountManager", sp.AccountManager);
                cmd.Parameters.AddWithValue("@ExternalResource", sp.ExternalResource);
                cmd.Parameters.AddWithValue("@InternalResource", sp.InternalResource);
                cmd.Parameters.AddWithValue("@Type", sp.Type);
                cmd.Parameters.AddWithValue("@Onboardingdate", sp.Onboardingdate);
                cmd.Parameters.AddWithValue("@IsOnHold", sp.IsOnHold);

                cmd.Parameters.AddWithValue("@JobDesc", sp.JobDesc);
                cmd.Parameters.AddWithValue("@RoledetailsId", sp.RoleDetailsId);
                cmd.Parameters.AddWithValue("@experienceinyears", sp.experienceinyears);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public string Domaintable(DomainModel dm)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);

            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("Domain_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DomainId", dm.DomainId);
                cmd.Parameters.AddWithValue("@DomainName", dm.DomainName);
                cmd.Parameters.AddWithValue("@Type", dm.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }


        public DataSet Domaintableget(DomainModel dm, string msg)
        {
            msg = string.Empty;

            SqlConnection con = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Domain_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DomainId", dm.DomainId);
                cmd.Parameters.AddWithValue("@DomainName", dm.DomainName);
                cmd.Parameters.AddWithValue("@Type", dm.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public string Techtable(TechnologyModel ts)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);

            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("Technology_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TechnologyId", ts.TechnologyId);
                cmd.Parameters.AddWithValue("@TechnologyName", ts.TechnologyName);
                cmd.Parameters.AddWithValue("@DomainId", ts.DomainId);
                cmd.Parameters.AddWithValue("@Type", ts.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

        public DataSet techtableget(TechnologyModel ts, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Technology_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TechnologyId", ts.TechnologyId);
                cmd.Parameters.AddWithValue("@TechnologyName", ts.TechnologyName);
                cmd.Parameters.AddWithValue("@DomainId", ts.DomainId);
                cmd.Parameters.AddWithValue("@Type", ts.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public string USTTPMtable(USTTPMModel tpm)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);

            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("USTTPM_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USTTPMId", tpm.USTTPMId);
                cmd.Parameters.AddWithValue("@USTTPMName", tpm.USTTPMName);
                cmd.Parameters.AddWithValue("@USTTPMUID", tpm.USTTPMUID);
                cmd.Parameters.AddWithValue("@Type", tpm.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;
        }

        public DataSet usttpmget(USTTPMModel tpm, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("USTTPM_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USTTPMId", tpm.USTTPMId);
                cmd.Parameters.AddWithValue("@USTTPMName", tpm.USTTPMName);
                cmd.Parameters.AddWithValue("@USTTPMUID", tpm.USTTPMUID);
                cmd.Parameters.AddWithValue("@Type", tpm.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        public string dellmanagertable(DellManagerModel dl)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);

            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("DellManager_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DellManagerId", dl.DellManagerId);
                cmd.Parameters.AddWithValue("@DellManagerName", dl.DellManagerName);
                cmd.Parameters.AddWithValue("@Type", dl.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

        public DataSet dellmanagerget(DellManagerModel dl, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("DellManager_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DellManagerId", dl.DellManagerId);
                cmd.Parameters.AddWithValue("@DellManagerName", dl.DellManagerName);
                cmd.Parameters.AddWithValue("@Type", dl.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public string ustpoctable(USTPOCModel us)
        {
            //var jsonString = msg;

            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("USTPOC_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USTPOCId", us.USTPOCId);
                cmd.Parameters.AddWithValue("@USTPOCName", us.USTPOCName);
                cmd.Parameters.AddWithValue("@Type", us.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;
        }

        public DataSet ustpocget(USTPOCModel us, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("USTPOC_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USTPOCId", us.USTPOCId);
                cmd.Parameters.AddWithValue("@USTPOCName", us.USTPOCName);
                cmd.Parameters.AddWithValue("@Type", us.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        public string recruiter(RecruiterModel rc)
        {

            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("Recruiter_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RecruiterId", rc.RecruiterId);
                cmd.Parameters.AddWithValue("@RecruiterName", rc.RecruiterName);
                cmd.Parameters.AddWithValue("@Type", rc.Type);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }



            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;
        }

        public DataSet recruiterget(RecruiterModel rc, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Recruiter_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RecruiterId", rc.RecruiterId);
                cmd.Parameters.AddWithValue("@RecruiterName", rc.RecruiterName);
                cmd.Parameters.AddWithValue("@Type", rc.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public string Accounttable(AccountModel ac)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand("Account_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountId", ac.AccountId);
                cmd.Parameters.AddWithValue("@AccountName", ac.AccountName);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;

        }




        //get record
        public DataSet Accounttableget(AccountModel ac, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Account_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountId", ac.AccountId);
                cmd.Parameters.AddWithValue("@AccountName", ac.AccountName);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public string Regiontable(RegionModel rs)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);

            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("Region_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RegionId", rs.RegionId);
                cmd.Parameters.AddWithValue("@Region", rs.Region);
                cmd.Parameters.AddWithValue("@Type", rs.Type);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;

        }




        //get record
        public DataSet Regiontableget(RegionModel rs, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Region_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RegionId", rs.RegionId);
                cmd.Parameters.AddWithValue("@Region", rs.Region);
                cmd.Parameters.AddWithValue("@Type", rs.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }



        public string locationtable(LocationModel ls)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);

            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("Location_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocationId", ls.LocationId);
                cmd.Parameters.AddWithValue("@Location", ls.Location);
                cmd.Parameters.AddWithValue("@RegionId", ls.RegionId);
                cmd.Parameters.AddWithValue("@Type", ls.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;

        }

        public DataSet locationtableget(LocationModel ls, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Location_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocationId", ls.LocationId);
                cmd.Parameters.AddWithValue("@Location", ls.Location);
                cmd.Parameters.AddWithValue("@RegionId", ls.RegionId);
                cmd.Parameters.AddWithValue("@Type", ls.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public string Statustable(StatusModel st)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);

            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            try
            {
                SqlCommand cmd = new SqlCommand("Status_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatusId", st.StatusId);
                cmd.Parameters.AddWithValue("@StatusName", st.StatusName);
                cmd.Parameters.AddWithValue("@Type", st.Type);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                msg = "success";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;
        }

        public DataSet Statusget(StatusModel st, string msg)
        {
            msg = string.Empty;

            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Status_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatusId", st.StatusId);
                cmd.Parameters.AddWithValue("@StatusName", st.StatusName);
                cmd.Parameters.AddWithValue("@Type", st.Type);
                cmd.Parameters.AddWithValue("@StatusType", st.StatusType);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        public string logintable(LoginModel ln)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty; try
            {
                SqlCommand cmd = new SqlCommand("loginproc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginName", ln.LoginName);
                cmd.Parameters.AddWithValue("@EmailId", ln.EmailId);
                cmd.Parameters.AddWithValue("@RoleName", ln.RoleName);
                cmd.Parameters.AddWithValue("@ScreenNames", ln.ScreenNames);
                cmd.Parameters.AddWithValue("@Status", ln.Status);
                cmd.Parameters.AddWithValue("@PermissionName", ln.PermissionName);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                msg = "success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

        // parameterized queries

        //public string logintable(LoginModel ln)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connstr))
        //        {
        //            string query = "INSERT INTO LoginTable (LoginName, EmailId, RoleName, ScreenNames, Status, PermissionName) VALUES (@LoginName VARCHAR(50), @EmailId, @RoleName, @ScreenNames, @Status, @PermissionName)";
        //            using (SqlCommand cmd = new SqlCommand(query, con))
        //            {
        //                cmd.Parameters.AddWithValue("@LoginName", ln.LoginName);
        //                cmd.Parameters.AddWithValue("@EmailId", ln.EmailId);
        //                cmd.Parameters.AddWithValue("@RoleName", ln.RoleName);
        //                cmd.Parameters.AddWithValue("@ScreenNames", ln.ScreenNames);
        //                cmd.Parameters.AddWithValue("@Status", ln.Status);
        //                cmd.Parameters.AddWithValue("@PermissionName", ln.PermissionName);
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //            }
        //            msg = "success";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //    }
        //    return JsonConvert.SerializeObject(msg);
        //}

        //public DataSet loginget(string LoginName, string LoginPassword)
        //{
        //    string msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connstr))
        //        {
        //            string query = "SELECT * FROM LoginTable WHERE LoginName = @LoginName AND LoginPassword = @LoginPassword";
        //            using (SqlCommand cmd = new SqlCommand(query, con))
        //            {
        //                cmd.Parameters.AddWithValue("@LoginName", LoginName);
        //                cmd.Parameters.AddWithValue("@LoginPassword", EncryptData.Encrypt(LoginPassword));
        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                da.Fill(ds);
        //            }
        //            msg = "Success";
        //            return ds;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //    }
        //    return ds;
        //}

        //-------------------------------------------------------//

        //store procedure with setiing the datatype and its length
        //public DataSet loginget(string LoginName, string LoginPassword)
        //{
        //    string msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connstr))
        //        {
        //            SqlCommand cmd = new SqlCommand("loginproc", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@LoginName", SqlDbType.VarChar, 50).Value = LoginName;
        //            cmd.Parameters.Add("@LoginPassword", SqlDbType.VarChar, 50).Value = EncryptData.Encrypt(LoginPassword);

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            da.Fill(ds);
        //            msg = "Success";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //    }
        //    return ds;
        //}

        //public string logintable(LoginModel ln)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connstr))
        //        {
        //            SqlCommand cmd = new SqlCommand("loginproc", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@LoginName", SqlDbType.VarChar, 50).Value = ln.LoginName;
        //            cmd.Parameters.Add("@EmailId", SqlDbType.VarChar, 50).Value = ln.EmailId;
        //            cmd.Parameters.Add("@RoleName", SqlDbType.VarChar, 50).Value = ln.RoleName;
        //            cmd.Parameters.Add("@ScreenNames", SqlDbType.VarChar, 50).Value = ln.ScreenNames;
        //            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = ln.Status;
        //            cmd.Parameters.Add("@PermissionName", SqlDbType.VarChar, 50).Value = ln.PermissionName;

        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            msg = "success";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //    }
        //    return JsonConvert.SerializeObject(msg);
        //}

        //


        public DataSet loginget(string EmailId, string LoginPassword)
        {
            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("loginproc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailId", EmailId);
                cmd.Parameters.AddWithValue("@LoginPassword", EncryptData.Encrypt(LoginPassword));
                //cmd.Parameters.AddWithValue("@EmailId", ln.EmailId);
                //cmd.Parameters.AddWithValue("@RoleName", ln.RoleName);
                //cmd.Parameters.AddWithValue("@ScreenNames", ln.ScreenNames);
                //cmd.Parameters.AddWithValue("@Status", ln.Status);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";

                return ds;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        public string updateLoginTable(string EmailId, LoginModel lm)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string msg = string.Empty;
                try
                {
                    SqlCommand cmd = new SqlCommand("editlogin", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailId", EmailId);

                    cmd.Parameters.AddWithValue("@FailureAttempts", lm.FailureAttempts);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        msg = rdr["status"].ToString();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                return msg;
            }
        }
         public string updateProfile(string EmailId,LoginModel lm)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string msg = string.Empty;
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_loginData", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailId", EmailId);

                    cmd.Parameters.AddWithValue("@loginName", lm.LoginName);
                    cmd.Parameters.AddWithValue("@Image", lm.Image);
                    cmd.Parameters.AddWithValue("@MobileNo", lm.MobileNo);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        msg = rdr["status"].ToString();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                return msg;
            }
        }



        public DataSet DashboardStatsget(string period)
        {
            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("DashboardStats", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PeriodType", period);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }

        public DataSet DashboardCandidateStatsget(string period)
        {
            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("DashboardCandidateStats", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PeriodType", period);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        public DataSet getRoles(RegistrationModel rc, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Registration_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginName", rc.LoginName);
                cmd.Parameters.AddWithValue("@LoginPassword", rc.LoginPassword);
                cmd.Parameters.AddWithValue("@EmailId", rc.EmailId);
                cmd.Parameters.AddWithValue("@RoleId", rc.RoleId);
                cmd.Parameters.AddWithValue("@LoginId", rc.LoginId);
                cmd.Parameters.AddWithValue("@Type", rc.Type);
                cmd.Parameters.AddWithValue("@FailureAttempts", rc.FailureAttempts);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public string Userdetails(RegistrationModel rc)
        {
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand("Registration_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginName", rc.LoginName);
                //Encrypting the password before inserting
                cmd.Parameters.AddWithValue("@LoginPassword", EncryptData.Encrypt(rc.LoginPassword));
                cmd.Parameters.AddWithValue("@EmailId", rc.EmailId);
                cmd.Parameters.AddWithValue("@RoleId", rc.RoleId);
                cmd.Parameters.AddWithValue("@LoginId", rc.LoginId);
                cmd.Parameters.AddWithValue("@Type", rc.Type);
                cmd.Parameters.AddWithValue("@FailureAttempts", rc.FailureAttempts);
                //cmd.Parameters.AddWithValue("@IsLock", rc.IsLock);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

        public DataSet getLoginDetails(RegistrationModel rc, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Registration_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginName", rc.LoginName);
                cmd.Parameters.AddWithValue("@LoginPassword", rc.LoginPassword);
                cmd.Parameters.AddWithValue("@EmailId", rc.EmailId);
                cmd.Parameters.AddWithValue("@RoleId", rc.RoleId);
                cmd.Parameters.AddWithValue("@LoginId", rc.LoginId);
                cmd.Parameters.AddWithValue("@Type", rc.Type);
                cmd.Parameters.AddWithValue("@FailureAttempts", rc.FailureAttempts);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public string UpdateUser(RegistrationModel rc)
        {
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand("Registration_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginName", rc.LoginName);
                cmd.Parameters.AddWithValue("@LoginPassword", rc.LoginPassword);
                cmd.Parameters.AddWithValue("@EmailId", rc.EmailId);
                cmd.Parameters.AddWithValue("@RoleId", rc.RoleId);
                cmd.Parameters.AddWithValue("@LoginId", rc.LoginId);
                cmd.Parameters.AddWithValue("@Type", rc.Type);
                cmd.Parameters.AddWithValue("@FailureAttempts", rc.FailureAttempts);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

        public string DeleteUser(RegistrationModel rc)
        {
            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("Registration_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginName", rc.LoginName);
                cmd.Parameters.AddWithValue("@LoginPassword", rc.LoginPassword);
                cmd.Parameters.AddWithValue("@EmailId", rc.EmailId);
                cmd.Parameters.AddWithValue("@RoleId", rc.RoleId);
                cmd.Parameters.AddWithValue("@LoginId", rc.LoginId);
                cmd.Parameters.AddWithValue("@Type", rc.Type);
                cmd.Parameters.AddWithValue("@FailureAttempts", rc.FailureAttempts);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public string changePassword(ChangePasswordModel cp)
        {
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;
            if (cp.OldPassword.Length == 0)
            {
                cp.OldPassword = "pwd";
            }
            try
            {
                SqlCommand cmd = new SqlCommand("ChangePassword_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailId", cp.EmailId);
                cmd.Parameters.AddWithValue("@OldPassword", EncryptData.Encrypt(cp.OldPassword));
                cmd.Parameters.AddWithValue("@NewPassword", EncryptData.Encrypt(cp.NewPassword));
                cmd.Parameters.AddWithValue("@Type", cp.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;
        }

        public DataSet Sowgetdate(Sow sp, DateTime Startdate, DateTime Enddate)
        {
            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("sow_date", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SowId", sp.SowId);
                cmd.Parameters.AddWithValue("@SoName", sp.SoName);
                cmd.Parameters.AddWithValue("@JRCode", sp.JRCode);
                cmd.Parameters.AddWithValue("@RequestCreationDate", sp.RequestCreationDate);
                cmd.Parameters.AddWithValue("@AccountId", sp.AccountId);
                cmd.Parameters.AddWithValue("@TechnologyId", sp.TechnologyId);
                cmd.Parameters.AddWithValue("@Comments", sp.Comments);
                cmd.Parameters.AddWithValue("@LocationId", sp.LocationId);
                cmd.Parameters.AddWithValue("@RegionId", sp.RegionId);
                cmd.Parameters.AddWithValue("@TargetOpenPositions", sp.TargetOpenPositions);
                cmd.Parameters.AddWithValue("@PositionsTobeClosed", sp.PositionsTobeClosed);
                cmd.Parameters.AddWithValue("@USTPOCId", sp.USTPOCId);
                cmd.Parameters.AddWithValue("@RecruiterId", sp.RecruiterId);
                cmd.Parameters.AddWithValue("@USTTPMId", sp.USTTPMId);
                cmd.Parameters.AddWithValue("@DellManagerId", sp.DellManagerId);
                cmd.Parameters.AddWithValue("@StatusId", sp.StatusId);
                cmd.Parameters.AddWithValue("@Band", sp.Band);
                cmd.Parameters.AddWithValue("@ProjectId", sp.ProjectId);
                cmd.Parameters.AddWithValue("@AccountManager", sp.AccountManager);
                cmd.Parameters.AddWithValue("@ExternalResource", string.IsNullOrEmpty(sp.ExternalResource) ? (object)DBNull.Value : sp.ExternalResource);
                cmd.Parameters.AddWithValue("@InternalResource", string.IsNullOrEmpty(sp.InternalResource) ? (object)DBNull.Value : sp.InternalResource);

                cmd.Parameters.AddWithValue("@StartDate", Startdate);
                cmd.Parameters.AddWithValue("@EndDate", Enddate);
                cmd.Parameters.AddWithValue("@Type", sp.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        public List<CandidateModel> GetCandidateDate(DateTime StartDate, DateTime EndDate)
        {
            string msg = string.Empty;
            List<CandidateModel> lstmain = new List<CandidateModel>();
            DataTable dt = new DataTable();
            try
            {
                string query = "select CandidateId,CandidateName,MobileNo,DOB,EmailId,Location,Skills,JoiningDate,IsInternal,Address,B.StatusName Status,Pincode,Gender from Candidate A Inner Join[dbo].[Status] B On" +
                    " A.Status = B.StatusId where (CONVERT(date, JoiningDate) between  @StartDate and  @EndDate) and A.isDeleted=0 ";



                using (SqlConnection con = new SqlConnection(connstr))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = StartDate;
                        cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = EndDate;
                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            adp.Fill(dt);
                        }
                    }
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CandidateModel obj = new CandidateModel();
                    obj.CandidateId = Int32.Parse(dt.Rows[i]["CandidateId"].ToString() ?? "0");
                    obj.CandidateName = dt.Rows[i]["CandidateName"].ToString();
                    obj.DOB = DateTime.Parse(dt.Rows[i]["DOB"].ToString() ?? "2000-01-01");
                    obj.Address = dt.Rows[i]["Address"].ToString();
                    obj.Status = dt.Rows[i]["Status"].ToString();
                    obj.Pincode = dt.Rows[i]["Pincode"].ToString();
                    obj.Email = dt.Rows[i]["EmailId"].ToString();
                    obj.Skills = dt.Rows[i]["Skills"].ToString();
                    obj.Gender = dt.Rows[i]["Gender"].ToString();
                    obj.JoiningDate = DateTime.Parse(dt.Rows[i]["JoiningDate"].ToString() ?? "2000-01-01");
                    obj.isInternal = Boolean.Parse(dt.Rows[i]["isInternal"].ToString() ?? "false");
                    obj.MobileNo = dt.Rows[i]["MobileNo"].ToString();
                    obj.Location = dt.Rows[i]["Location"].ToString();
                    obj.TerminationDate = DateTime.Parse(dt.Rows[i]["TerminationDate"].ToString() ?? "2000-01-01");
                    obj.PANNumber = dt.Rows[i]["PANNumber"].ToString();
                    obj.PAN = dt.Rows[i]["PAN"].ToString();
                    lstmain.Add(obj);
                }
                return lstmain;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return lstmain;
        }


        public DataSet GetSecurityQuestions(SecurityQuestionModel st, string msg)
        {
            msg = string.Empty;

            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SecurityQues_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QuestionId", st.QuestionId);
                cmd.Parameters.AddWithValue("@Question", st.Question);
                cmd.Parameters.AddWithValue("@Type", st.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }



        public string SecurityAnswertable(SecurityAnswerModel st)
        {
            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("SecurityAns_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AnswerId", st.AnswerId);
                cmd.Parameters.AddWithValue("@EmailId", st.EmailId);
                cmd.Parameters.AddWithValue("@QuestionId1", st.QuestionId1);
                cmd.Parameters.AddWithValue("@Answer1", st.Answer1);

                cmd.Parameters.AddWithValue("@QuestionId2", st.QuestionId2);
                cmd.Parameters.AddWithValue("@Answer2", st.Answer2);

                cmd.Parameters.AddWithValue("@QuestionId3", st.QuestionId3);
                cmd.Parameters.AddWithValue("@Answer3", st.Answer3);

                cmd.Parameters.AddWithValue("@Type", st.Type);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                msg = "success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }


        public string ValidateSecurityAnswers(SecurityAnswerModel st)
        {

            string msg = string.Empty;

            using (SqlConnection connection = new SqlConnection(connstr))
            {

                try
                {


                    SqlCommand command = new SqlCommand("ValidateSecuityQnA_proc", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Input parameters
                    command.Parameters.AddWithValue("@EmailId", st.EmailId);
                    command.Parameters.AddWithValue("@QuestionId1", st.QuestionId1);
                    command.Parameters.AddWithValue("@Answer1", st.Answer1);
                    command.Parameters.AddWithValue("@QuestionId2", st.QuestionId2);
                    command.Parameters.AddWithValue("@Answer2", st.Answer2);
                    command.Parameters.AddWithValue("@QuestionId3", st.QuestionId3);
                    command.Parameters.AddWithValue("@Answer3", st.Answer3);

                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        msg = rdr["status"].ToString();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
                return msg;

            }


        }






        public DataSet GetSelectedSecurityQns(SecurityAnswerModel st)
        {
            string msg = string.Empty;
            // Assuming connectionString is defined in the DB class

            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SecurityAns_proc", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Emailid", st.EmailId);
                    cmd.Parameters.AddWithValue("@QuestionId1", st.QuestionId1);
                    cmd.Parameters.AddWithValue("@QuestionId2", st.QuestionId2);
                    cmd.Parameters.AddWithValue("@QuestionId3", st.QuestionId3);
                    cmd.Parameters.AddWithValue("@Type", st.Type);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    msg = "Success";
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }

            return ds;
        }



        public DataSet GetSecurityQns(SecurityAnswerModel st)
        {
            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SecurityAns_proc", con);

                SqlParameter outputParam = new SqlParameter("@msg", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emailid", st.EmailId);
                cmd.Parameters.AddWithValue("@AnswerId", st.AnswerId);
                cmd.Parameters.AddWithValue("@QuestionId1", st.QuestionId1);
                cmd.Parameters.AddWithValue("@Answer1", st.Answer1);
                cmd.Parameters.AddWithValue("@QuestionId2", st.QuestionId2);
                cmd.Parameters.AddWithValue("@Answer2", st.Answer2);
                cmd.Parameters.AddWithValue("@QuestionId3", st.QuestionId3);
                cmd.Parameters.AddWithValue("@Answer3", st.Answer3);
                cmd.Parameters.AddWithValue("@Type", st.Type);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return ds;
        }


        public DataSet GetSecurityAnswers(SecurityAnswerModel st, string msg)
        {
            msg = string.Empty;

            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SecurityAns_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AnswerId", st.AnswerId);
                cmd.Parameters.AddWithValue("@LoginId", st.EmailId);
                cmd.Parameters.AddWithValue("@QuestionId1", st.QuestionId1);
                cmd.Parameters.AddWithValue("@Answer1", st.Answer1);

                cmd.Parameters.AddWithValue("@QuestionId2", st.QuestionId2);
                cmd.Parameters.AddWithValue("@Answer2", st.Answer2);

                cmd.Parameters.AddWithValue("@QuestionId3", st.QuestionId3);
                cmd.Parameters.AddWithValue("@Answer3", st.Answer3);
                cmd.Parameters.AddWithValue("@Type", st.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }


        public string Add_sowData_DB(string jsonData)
        {

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string msg = string.Empty;
                try
                {
                    SqlCommand cmd = new SqlCommand("sowDataADD_TO_SOW", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@json", jsonData);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        msg = rdr["status"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                }
                return msg;
            }
        }


        //public string Add_sowData_DB(string jsonData)
        //{

        //    using (SqlConnection conn = new SqlConnection(connstr))
        //    {
        //        string msg = string.Empty;
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("sowDataADD_TO_USTTPM", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@json", jsonData);
        //            conn.Open();
        //            SqlDataReader rdr = cmd.ExecuteReader();
        //            while (rdr.Read())
        //            {
        //                msg = rdr["status"].ToString();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            msg = ex.Message;
        //        }
        //        finally
        //        {
        //            if (conn.State == ConnectionState.Open)
        //            {
        //                conn.Close();
        //            }

        //        }
        //        return msg;
        //    }
        //}

        public string Employeetable(Employee ac)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand("Employee_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", ac.EmployeeId);
                cmd.Parameters.AddWithValue("@EmployeeType", ac.EmployeeType);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;

        }




        //get record
        public DataSet Employeetableget(Employee ac, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Employee_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", ac.EmployeeId);
                cmd.Parameters.AddWithValue("@EmployeeType", ac.EmployeeType);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }


        public string Customertable(CustomerType ac)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand("CustomerType_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerTypeId", ac.CustomerTypeId);
                cmd.Parameters.AddWithValue("@CustomerId ", ac.CustomerId);
                cmd.Parameters.AddWithValue("@CustomerName", ac.CustomerName);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;

        }




        //get record
        public DataSet Customertableget(CustomerType ac, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("CustomerType_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerTypeId", ac.CustomerTypeId);
                cmd.Parameters.AddWithValue("@CustomerId ", ac.CustomerId);
                cmd.Parameters.AddWithValue("@CustomerName", ac.CustomerName);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }





        public string Projecttable(ProjectType ac)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand("ProjectType_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectTypeId", ac.ProjectTypeId);
                cmd.Parameters.AddWithValue("@ProjectId ", ac.ProjectId);
                cmd.Parameters.AddWithValue("@ProjectDescription", ac.ProjectDescription);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;

        }




        //get record
        public DataSet Projecttableget(ProjectType ac, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("ProjectType_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectTypeId", ac.ProjectTypeId);
                cmd.Parameters.AddWithValue("@ProjectId ", ac.ProjectId);
                cmd.Parameters.AddWithValue("@ProjectDescription", ac.ProjectDescription);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                cmd.Parameters.AddWithValue("@ProjectStartDate", ac.ProjectStartDate);
                cmd.Parameters.AddWithValue("@ProjectEndDate", ac.ProjectEndDate);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }



        public string JobCodeTable(JobCodeModel jobcode)
        {
            SqlConnection conn = new SqlConnection(connstr);

            string msg = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand("JobCode_proc", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@JobCodeId", jobcode.JobCodeId);
                cmd.Parameters.AddWithValue("@JobCode", jobcode.JobCode);
                cmd.Parameters.AddWithValue("@JobDescription", jobcode.JobDescription);
                cmd.Parameters.AddWithValue("@Type", jobcode.Type);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            return msg;

        }
        public DataSet JobCodeTableget(JobCodeModel jobcode)
        {
            string msg = string.Empty;
            SqlConnection conn = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("JobCode_proc", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@JobCodeId", jobcode.JobCodeId);
                cmd.Parameters.AddWithValue("@JobCode", jobcode.JobCode);
                cmd.Parameters.AddWithValue("@JobDescription", jobcode.JobDescription);
                cmd.Parameters.AddWithValue("@Type", jobcode.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        public DataSet FrequencyTableget(FrequencyModel frequencyModel)
        {
            string msg = string.Empty;
            SqlConnection conn = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Frequency_proc", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FrequencyId", frequencyModel.FrequencyId);
                cmd.Parameters.AddWithValue("@Frequency", frequencyModel.Frequency);

                cmd.Parameters.AddWithValue("@Type", frequencyModel.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        public string FrequencyTable(FrequencyModel frequencyModel)
        {
            SqlConnection conn = new SqlConnection(connstr);

            string msg = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand("Frequency_proc", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FrequencyId", frequencyModel.FrequencyId);
                cmd.Parameters.AddWithValue("@Frequency", frequencyModel.Frequency);

                cmd.Parameters.AddWithValue("@Type", frequencyModel.Type);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            return msg;

        }

        public string BussinessUnitTable(BussinessUnitModel bussinessUnit)
        {
            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("BussinessUnit_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BussinessUnitId", bussinessUnit.BussinessUnitId);
                cmd.Parameters.AddWithValue("@BussinessUnit", bussinessUnit.BussinessUnit);
                cmd.Parameters.AddWithValue("@BussinessUnitDescription", bussinessUnit.BussinessUnitDescription);
                cmd.Parameters.AddWithValue("@Type", bussinessUnit.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


            }
            return msg;
        }
        public DataSet BussinessUnitTableGet(BussinessUnitModel bussinessUnit)
        {
            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("BussinessUnit_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BussinessUnitId", bussinessUnit.BussinessUnitId);
                cmd.Parameters.AddWithValue("@BussinessUnit", bussinessUnit.BussinessUnit);
                cmd.Parameters.AddWithValue("@BussinessUnitDescription", bussinessUnit.BussinessUnitDescription);
                cmd.Parameters.AddWithValue("@Type", bussinessUnit.Type);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public string DepartmentTypeTable(DepartmentTypeModel Department)
        {
            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("DepartmentType_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DepartmentTypeId", Department.DepartmentTypeId);
                cmd.Parameters.AddWithValue("@DepartmentId", Department.DepartmentId);
                cmd.Parameters.AddWithValue("@DepartmentDescription", Department.DepartmentDescription);
                cmd.Parameters.AddWithValue("@Type", Department.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


            }
            return msg;
        }

        public DataSet DepartmentTypeTableGet(DepartmentTypeModel Department)
        {
            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("DepartmentType_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DepartmentTypeId", Department.DepartmentTypeId);
                cmd.Parameters.AddWithValue("@DepartmentId", Department.DepartmentId);
                cmd.Parameters.AddWithValue("@DepartmentDescription", Department.DepartmentDescription);
                cmd.Parameters.AddWithValue("@Type", Department.Type);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;
            }


            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        public DataSet billingtableget(BillingModel sp, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Billing_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BillingId", sp.BillingId);
                cmd.Parameters.AddWithValue("@ResourceStartDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ResourceEndDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Domain", sp.Domain);
                cmd.Parameters.AddWithValue("@Currency", sp.Currency);
                cmd.Parameters.AddWithValue("@BillRate", sp.BillRate);
                cmd.Parameters.AddWithValue("@Hours", sp.Hours);
                cmd.Parameters.AddWithValue("@TotalBilledhrs", sp.TotalBilledhrs);
                cmd.Parameters.AddWithValue("@SowId", sp.SowId);
                cmd.Parameters.AddWithValue("@CandidateId", sp.CandidateId);

                cmd.Parameters.AddWithValue("@Type", sp.Type);
                cmd.Parameters.AddWithValue("@CustomerTypeId", sp.CustomerTypeId);
                cmd.Parameters.AddWithValue("@EmployeeId", sp.EmployeeId);
                cmd.Parameters.AddWithValue("@ProjectTypeId", sp.ProjectTypeId);
                cmd.Parameters.AddWithValue("@Billable", sp.Billable);
                cmd.Parameters.AddWithValue("@ClientProjectRole", sp.ClientProjectRole);
                cmd.Parameters.AddWithValue("@ClientProjectRoleDesc", sp.ClientProjectRoleDesc);
                cmd.Parameters.AddWithValue("@AliasName", sp.AliasName);
                cmd.Parameters.AddWithValue("@Allocationtage", sp.AllocationPercentage);
                cmd.Parameters.AddWithValue("@Comments", sp.Comments);
                cmd.Parameters.AddWithValue("@ProjectManagerTypeId", sp.ProjectManagerTypeId);
                cmd.Parameters.AddWithValue("@ContractCategoryId", sp.ContractCategoryId);


                cmd.Parameters.AddWithValue("@DepartmentTypeId", sp.DepartmentTypeId);
                cmd.Parameters.AddWithValue("@BussinessUnitId", sp.BussinessUnitId);
                cmd.Parameters.AddWithValue("@JobCodeId", sp.JobCodeId);
                cmd.Parameters.AddWithValue("@FrequencyId", sp.FrequencyId);
                cmd.Parameters.AddWithValue("@LocationTypeId", sp.LocationTypeId);
                cmd.Parameters.AddWithValue("@RegionId", sp.RegionId);
                cmd.Parameters.AddWithValue("@USTTPMId", sp.USTTPMId);
                cmd.Parameters.AddWithValue("@OBU", sp.OBU);
                cmd.Parameters.AddWithValue("@OBUDescription", sp.OBUDescription);
                cmd.Parameters.AddWithValue("@ProjectId", sp.ProjectId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        public string billingtable(BillingModel sp)
        {
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("Billing_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BillingId", sp.BillingId);
                cmd.Parameters.AddWithValue("@ResourceStartDate", sp.ResourceStartDate);
                cmd.Parameters.AddWithValue("@ResourceEndDate", sp.ResourceEndDate);
                cmd.Parameters.AddWithValue("@Domain", sp.Domain);
                cmd.Parameters.AddWithValue("@Currency", sp.Currency);
                cmd.Parameters.AddWithValue("@BillRate", sp.BillRate);
                cmd.Parameters.AddWithValue("@Hours", sp.Hours);
                cmd.Parameters.AddWithValue("@TotalBilledhrs", sp.TotalBilledhrs);
                cmd.Parameters.AddWithValue("@SowId", sp.SowId);
                cmd.Parameters.AddWithValue("@CandidateId", sp.CandidateId);
                cmd.Parameters.AddWithValue("@CustomerTypeId", sp.CustomerTypeId);
                cmd.Parameters.AddWithValue("@EmployeeId", sp.EmployeeId);
                cmd.Parameters.AddWithValue("@ProjectTypeId", sp.ProjectTypeId);

                cmd.Parameters.AddWithValue("@Type", sp.Type);
                cmd.Parameters.AddWithValue("@Billable", sp.Billable);
                cmd.Parameters.AddWithValue("@ClientProjectRole", sp.ClientProjectRole);
                cmd.Parameters.AddWithValue("@ClientProjectRoleDesc", sp.ClientProjectRoleDesc);
                cmd.Parameters.AddWithValue("@AliasName", sp.AliasName);
                cmd.Parameters.AddWithValue("@Allocationtage", sp.AllocationPercentage);
                cmd.Parameters.AddWithValue("@Comments", sp.Comments);
                cmd.Parameters.AddWithValue("@ProjectManagerTypeId", sp.ProjectManagerTypeId);
                cmd.Parameters.AddWithValue("@ContractCategoryId", sp.ContractCategoryId);

                cmd.Parameters.AddWithValue("@DepartmentTypeId", sp.DepartmentTypeId);
                cmd.Parameters.AddWithValue("@BussinessUnitId", sp.BussinessUnitId);
                cmd.Parameters.AddWithValue("@JobCodeId", sp.JobCodeId);
                cmd.Parameters.AddWithValue("@FrequencyId", sp.FrequencyId);
                cmd.Parameters.AddWithValue("@LocationTypeId", sp.LocationTypeId);
                cmd.Parameters.AddWithValue("@RegionId", sp.RegionId);
                cmd.Parameters.AddWithValue("@USTTPMId", sp.USTTPMId);
                cmd.Parameters.AddWithValue("@OBU", sp.OBU);
                cmd.Parameters.AddWithValue("@OBUDescription", sp.OBUDescription);
                cmd.Parameters.AddWithValue("@ProjectId", sp.ProjectId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;
        }
        public DataSet ContractCategoryGet(ContractCategoryModel ct)
        {
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("ContractCategory_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContractCategoryId", ct.ContractCategoryId);
                cmd.Parameters.AddWithValue("@ContractCategory", ct.ContractCategory);
                cmd.Parameters.AddWithValue("@Type", ct.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        public string ContractCategoryTable(ContractCategoryModel ct)
        {
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("ContractCategory_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContractCategoryId", ct.ContractCategoryId);
                cmd.Parameters.AddWithValue("@ContractCategory", ct.ContractCategory);
                cmd.Parameters.AddWithValue("@Type", ct.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public string ProjectManagerTable(ProjectManagerModel projectmanager)
        {
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("ProjectManager_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectManagerTypeId", projectmanager.ProjectManagerTypeId);
                cmd.Parameters.AddWithValue("@ProjectManagerId", projectmanager.ProjectManagerId);
                cmd.Parameters.AddWithValue("@ProjectManagerName", projectmanager.ProjectManagerName);
                cmd.Parameters.AddWithValue("@Type", projectmanager.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }




        public DataSet ProjectManagerTableGet(ProjectManagerModel projectmanager)
        {
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("ProjectManager_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectManagerTypeId", projectmanager.ProjectManagerTypeId);
                cmd.Parameters.AddWithValue("@ProjectManagerId", projectmanager.ProjectManagerId);
                cmd.Parameters.AddWithValue("@ProjectManagerName", projectmanager.ProjectManagerName);
                cmd.Parameters.AddWithValue("@Type", projectmanager.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        public string locationTypetable(LocationTypeModel ls)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);

            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("LocationType_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocationTypeId", ls.LocationTypeId);
                cmd.Parameters.AddWithValue("@LocationId", ls.LocationId);
                cmd.Parameters.AddWithValue("@LocationDescription", ls.LocationDescription);
                cmd.Parameters.AddWithValue("@RegionId", ls.RegionId);
                cmd.Parameters.AddWithValue("@Type", ls.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;

        }

        public DataSet locationTypetableget(LocationTypeModel ls, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("LocationType_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocationTypeId", ls.LocationTypeId);
                cmd.Parameters.AddWithValue("@LocationId", ls.LocationId);
                cmd.Parameters.AddWithValue("@LocationDescription", ls.LocationDescription);
                cmd.Parameters.AddWithValue("@RegionId", ls.RegionId);
                cmd.Parameters.AddWithValue("@Type", ls.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        public DataSet GetByTPMName(USTTPMModel usttpm)
        {
            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("ProjectDetailsByUSTTPM_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@USTTPMName", usttpm.USTTPMName);

                cmd.Parameters.AddWithValue("@Type", usttpm.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public DataSet Screeningableget(ScreeningModel ac, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);


            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Screening_Proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ScreeningId", ac.ScreeningId);
                cmd.Parameters.AddWithValue("@ScreeningSelected", ac.ScreeningSelected);
                cmd.Parameters.AddWithValue("@ScreeningRejected", ac.ScreeningRejected);
                cmd.Parameters.AddWithValue("@SowId", ac.SowId);
                cmd.Parameters.AddWithValue("@CandidateId", ac.CandidateId);
                cmd.Parameters.AddWithValue("@Screening", ac.Screening);
                cmd.Parameters.AddWithValue("@SelectedCandidateIds", ac.SelectedCandidateIds);
                cmd.Parameters.AddWithValue("@RejectedCandidateIds", ac.RejectedCandidateIds);
                cmd.Parameters.AddWithValue("@SOW_CandidateId", ac.SOW_CandidateId);
                cmd.Parameters.AddWithValue("@Type", ac.Type);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        public string Screeningtable(ScreeningModel ac)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand("Screening_Proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ScreeningId", ac.ScreeningId);
                cmd.Parameters.AddWithValue("@ScreeningSelected", ac.ScreeningSelected);
                cmd.Parameters.AddWithValue("@ScreeningRejected", ac.ScreeningRejected);
                cmd.Parameters.AddWithValue("@SowId", ac.SowId);
                cmd.Parameters.AddWithValue("@CandidateId", ac.CandidateId);
                cmd.Parameters.AddWithValue("@Screening", ac.Screening);
                cmd.Parameters.AddWithValue("@SelectedCandidateIds", ac.SelectedCandidateIds);
                cmd.Parameters.AddWithValue("@RejectedCandidateIds", ac.RejectedCandidateIds);
                cmd.Parameters.AddWithValue("@SOW_CandidateId", ac.SOW_CandidateId);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;

        }
        public DataSet L1Tableget(L1 ac, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);


            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("L1_Proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@L1Id", ac.L1Id);
                cmd.Parameters.AddWithValue("@L1Selected", ac.L1Selected);
                cmd.Parameters.AddWithValue("@L1Rejected", ac.L1Rejected);
                cmd.Parameters.AddWithValue("@L1", ac.L1Total);
                cmd.Parameters.AddWithValue("@OnHold", ac.OnHold);
                cmd.Parameters.AddWithValue("@ScreeningId", ac.ScreeningId);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public string L1table(L1 ac)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand("L1_Proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@L1Id", ac.L1Id);
                cmd.Parameters.AddWithValue("@L1Selected", ac.L1Selected);
                cmd.Parameters.AddWithValue("@L1Rejected", ac.L1Rejected);
                cmd.Parameters.AddWithValue("@L1", ac.L1Total);

                cmd.Parameters.AddWithValue("@ScreeningId", ac.ScreeningId);
                cmd.Parameters.AddWithValue("@OnHold", ac.OnHold);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;

        }
        public DataSet L2Tableget(L2Model ac, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);


            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("L2_Proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@L2Id", ac.L2Id);
                cmd.Parameters.AddWithValue("@L2Selected", ac.L2Selected);
                cmd.Parameters.AddWithValue("@L2Rejected", ac.L2Rejected);
                cmd.Parameters.AddWithValue("@L2", ac.L2);

                cmd.Parameters.AddWithValue("@L1Id", ac.L1Id);
                cmd.Parameters.AddWithValue("@Onhold", ac.Onhold);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public string L2table(L2Model ac)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);
            SqlConnection con = new SqlConnection(connstr);
            string msg = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand("L2_Proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@L2Id", ac.L2Id);
                cmd.Parameters.AddWithValue("@L2Selected", ac.L2Selected);
                cmd.Parameters.AddWithValue("@L2Rejected", ac.L2Rejected);
                cmd.Parameters.AddWithValue("@L2", ac.L2);

                cmd.Parameters.AddWithValue("@L1Id", ac.L1Id);
                cmd.Parameters.AddWithValue("@Onhold", ac.Onhold);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;

        }

        public DataSet Screeningprofiletableget(ScreeningProfilesModel ac, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);


            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SCREENINGPROFILES_Proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SowId", ac.SowId);
                cmd.Parameters.AddWithValue("@Type", ac.Type);
                cmd.Parameters.AddWithValue("@StartDate", ac.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", ac.EndDate);
                //cmd.Parameters.AddWithValue("@ProjectId", ac.ProjectId);
                //cmd.Parameters.AddWithValue("@JRCode", ac.JRCode);
                //cmd.Parameters.AddWithValue("@StatusId", ac.StatusId);
                //cmd.Parameters.AddWithValue("@StatusName", ac.StatusName);
                //cmd.Parameters.AddWithValue("@TotalScreeningSelected", ac.ScreeningSelected);
                //cmd.Parameters.AddWithValue("@TotalScreeningRejected", ac.Screeningrejceted);
                //cmd.Parameters.AddWithValue("@TotalL1Selected", ac.L1selected);
                //cmd.Parameters.AddWithValue("@TotalL1Rejected", ac.L1rejected);
                //cmd.Parameters.AddWithValue("@TotalL2Selected",ac.L2selected);
                //cmd.Parameters.AddWithValue("@TotalL2Rejected", ac.L1rejected);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public DataSet GetProfilesBySo(SoWCandidateModel candidate, int sowid, string msg)
        {
            msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);


            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("CandidateProfilesBySo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                 
                cmd.Parameters.AddWithValue("@SowId", sowid);
                cmd.Parameters.AddWithValue("@Type", candidate.Type);
                cmd.Parameters.AddWithValue("@StartDate",candidate.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", candidate.EndDate);
           
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        public string RoleDetailtable(RoleDetails dm)
        {
            //var jsonString = JsonConvert.SerializeObject(msg);

            string msg = string.Empty;
            SqlConnection con = new SqlConnection(connstr);
            try
            {
                SqlCommand cmd = new SqlCommand("RoleDetails_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleDetailId", dm.RoleDetailsId);
                cmd.Parameters.AddWithValue("@RoleDetails", dm.RoleDetailsName);
                cmd.Parameters.AddWithValue("@Type", dm.Type);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    msg = rdr["status"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }


        public DataSet RoleDetailtableget(RoleDetails dm, string msg)
        {
            msg = string.Empty;

            SqlConnection con = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("RoleDetails_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleDetailId", dm.RoleDetailsId);
                cmd.Parameters.AddWithValue("@RoleDetails", dm.RoleDetailsName);
                cmd.Parameters.AddWithValue("@Type", dm.Type);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
                return ds;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }








    }



}