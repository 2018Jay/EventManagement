using Library;
using LIBRARY;
using MODELS.MODELS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace BL.AdminServices
{
    public class AdminService
    {
        public SerializeResponse<ADMIN> AdminOpration(ADMIN objEntity)
        {
            InsertLog.WriteErrrorLog("AdminService=>AdminOpration=>Started");
            ConvertDataTable bl = new ConvertDataTable();
            SerializeResponse<ADMIN> objSerializeResponse = new SerializeResponse<ADMIN>();

            DataSet ds = new DataSet();
            SqlDataProvider objSDP = new SqlDataProvider();
            string query = "SP_Admin";
            try
            {
                if (objEntity.CreateDateTime == new DateTime())
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
                SqlParameter prm2 = objSDP.CreateInitializedParameter("@AdminId", DbType.String, objEntity.AdminId);
                SqlParameter prm3 = objSDP.CreateInitializedParameter("@AdminName", DbType.String, objEntity.AdminName);
                SqlParameter prm4 = objSDP.CreateInitializedParameter("@AdminAddress", DbType.String, objEntity.AdminAddress);
                SqlParameter prm5 = objSDP.CreateInitializedParameter("@AdminEmail", DbType.String, objEntity.AdminEmail);
                SqlParameter prm6 = objSDP.CreateInitializedParameter("@AdminPassword", DbType.String, objEntity.AdminPassword);
                SqlParameter prm7 = objSDP.CreateInitializedParameter("@AdminMobile", DbType.String, objEntity.AdminMobile);
                SqlParameter prm8 = objSDP.CreateInitializedParameter("@CreateDateTime", DbType.DateTime, objEntity.CreateDateTime);
                SqlParameter prm9 = objSDP.CreateInitializedParameter("@UpdatedDateTime", DbType.DateTime, objEntity.UpdatedDateTime);
              

                SqlParameter prm10 = objSDP.CreateInitializedParameter("@IsActive", DbType.String, objEntity.IsActive);




                SqlParameter[] Sqlpara = { prm1, prm2, prm3, prm4, prm5, prm6, prm7, prm8, prm9, prm10 };

                ds = SqlHelper.ExecuteDataset(Con_str, query, Sqlpara);
                if (objEntity.Flag == "INSERT" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objSerializeResponse.ID = Convert.ToInt16(ds.Tables[0].Rows[0]["StatusCode"]);
                    objSerializeResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
                else if (objEntity.Flag == "LOGIN" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Count != 2)
                {
                    objSerializeResponse.ArrayOfResponse = bl.ListConvertDataTable<ADMIN>(ds.Tables[0]);
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
