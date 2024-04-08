using Library;
using LIBRARY;
using MODELS.MODELS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BL.UserServices
{
    public class UserService
    {
        public SerializeResponse<USER> UserOpration(USER objEntity)
        {
            InsertLog.WriteErrrorLog("UserService=>UserOpration=>Started");
            ConvertDataTable bl = new ConvertDataTable();
            SerializeResponse<USER> objSerializeResponse = new SerializeResponse<USER>();

            DataSet ds = new DataSet();
            SqlDataProvider objSDP = new SqlDataProvider();
            string query = "SP_User";
            try
            {
                if(objEntity.CreateDateTime == new DateTime())
                {
                    objEntity.CreateDateTime = DateTime.Now;
                    //objEntity.CreateDateTime = Convert.ToDateTime("2024-1-1 00:00:00.000"); 
                }
                if (objEntity.UpdatedDateTime == new DateTime())
                {
                    objEntity.UpdatedDateTime = DateTime.Now;
                    //objEntity.UpdatedDateTime = Convert.ToDateTime("2024-1-1 00:00:00.000"); 
                }

                if (objEntity.CreateDateTime == DateTime.MinValue)
                {
                    objEntity.CreateDateTime = DateTime.Now;
                }

                if (objEntity.UpdatedDateTime == DateTime.MinValue)
                {
                    objEntity.UpdatedDateTime = DateTime.Now;
                }

                string Con_str = Connection.ConnectionString;
                SqlParameter prm1 = objSDP.CreateInitializedParameter("@Flag", DbType.String, objEntity.Flag);
                SqlParameter prm2 = objSDP.CreateInitializedParameter("@UserId", DbType.String, objEntity.UserId);
                SqlParameter prm3 = objSDP.CreateInitializedParameter("@UserName", DbType.String, objEntity.UserName);
                SqlParameter prm4 = objSDP.CreateInitializedParameter("@UserAddress", DbType.String, objEntity.UserAddress);
                SqlParameter prm5 = objSDP.CreateInitializedParameter("@UserEmail", DbType.String, objEntity.UserEmail);
                SqlParameter prm6 = objSDP.CreateInitializedParameter("@UserPassword", DbType.String, objEntity.UserPassword);
                SqlParameter prm7 = objSDP.CreateInitializedParameter("@UserMobile", DbType.String, objEntity.UserMobile);
                SqlParameter prm8 = objSDP.CreateInitializedParameter("@CreateDateTime", DbType.DateTime, objEntity.CreateDateTime);
                SqlParameter prm9 = objSDP.CreateInitializedParameter("@UpdatedDateTime", DbType.DateTime, objEntity.UpdatedDateTime);
               /* SqlParameter prm8 = new SqlParameter("@CreateDateTime", SqlDbType.DateTime);
                prm8.Value = objEntity.CreateDateTime != DateTime.MinValue ? objEntity.CreateDateTime : (object)DBNull.Value; // Handle null case

                Console.WriteLine(objEntity.CreateDateTime);

                SqlParameter prm9 = new SqlParameter("@UpdatedDateTime", DbType.String);
                prm9.Value = objEntity.UpdatedDateTime != DateTime.MinValue ? objEntity.UpdatedDateTime : (object)DBNull.Value; // Handle null case*/


                SqlParameter prm10 = objSDP.CreateInitializedParameter("@IsActive", DbType.String, objEntity.IsActive);
          



                SqlParameter[] Sqlpara = { prm1, prm2, prm3, prm4, prm5, prm6, prm7, prm8, prm9, prm10 };

                ds = SqlHelper.ExecuteDataset(Con_str, query, Sqlpara);
                if (objEntity.Flag == "INSERT" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objSerializeResponse.ID= Convert.ToInt16(ds.Tables[0].Rows[0]["StatusCode"]);
                    objSerializeResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
                else if (objEntity.Flag == "LOGIN" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Count != 2)
                {
                    objSerializeResponse.ArrayOfResponse = bl.ListConvertDataTable<USER>(ds.Tables[0]);
                    objSerializeResponse.Message = "200|Data Found";
                }
                else if (objEntity.Flag == "LOGIN" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Count == 2)
                {
                    objSerializeResponse.ID = Convert.ToInt16(ds.Tables[0].Rows[0]["StatusCode"]);
                    objSerializeResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
                else if (objEntity.Flag == "Get" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count == 0)
                {
                    objSerializeResponse.Message = "400|No Data Found";
                }
                else
                {
                    objSerializeResponse.Message = "500|Flag is Invalid";

                }

            }
            catch (Exception ex)
            {
                objSerializeResponse.Message = "500|Exception Occurred";
                InsertLog.WriteErrrorLog("UserserviceBL=>UserOpration=>Exception" + ex.Message + ex.StackTrace);
            }
            return objSerializeResponse;
        }
    }
}
