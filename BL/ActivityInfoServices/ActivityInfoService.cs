using Library;
using LIBRARY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using MODELS.MODELS;

namespace BL.ActivityInfoServices
{
    public class ActivityInfoService
    {
        public SerializeResponse<ACTIVITYINFO> ActivityInfoOpration(ACTIVITYINFO objEntity)
        {
            InsertLog.WriteErrrorLog("UserService=>UserOpration=>Started");
            ConvertDataTable bl = new ConvertDataTable();
            SerializeResponse<ACTIVITYINFO> objSerializeResponse = new SerializeResponse<ACTIVITYINFO>();

            DataSet ds = new DataSet();
            SqlDataProvider objSDP = new SqlDataProvider();
            string query = "SP_ActivityInfo";
            try
            {
                if (objEntity.CreatedDateTime == new DateTime())
                {
                    objEntity.CreatedDateTime = DateTime.Now;
                    //objEntity.CreateDateTime = Convert.ToDateTime("2024-1-1 00:00:00.000"); 
                }
                if (objEntity.UpdatedDateTime == new DateTime())
                {
                    objEntity.UpdatedDateTime = DateTime.Now;
                    //objEntity.UpdatedDateTime = Convert.ToDateTime("2024-1-1 00:00:00.000"); 
                }

                if (objEntity.CreatedDateTime == DateTime.MinValue)
                {
                    objEntity.CreatedDateTime = DateTime.Now;
                }

                if (objEntity.UpdatedDateTime == DateTime.MinValue)
                {
                    objEntity.UpdatedDateTime = DateTime.Now;
                }
          
                string Con_str = Connection.ConnectionString;
                SqlParameter prm1 = objSDP.CreateInitializedParameter("@Flag", DbType.String, objEntity.Flag);
                SqlParameter prm2 = objSDP.CreateInitializedParameter("@ActivityId", DbType.String, objEntity.ActivityId);
                SqlParameter prm3 = objSDP.CreateInitializedParameter("@ActivityName", DbType.String, objEntity.ActivityName);
                SqlParameter prm4 = objSDP.CreateInitializedParameter("@ActivityDESC", DbType.String, objEntity.ActivityDESC);
                SqlParameter prm5 = objSDP.CreateInitializedParameter("@ActivityStartDateTime", DbType.String, objEntity.ActivityStartDateTime);
                SqlParameter prm6 = objSDP.CreateInitializedParameter("@ActivityEndDateTime", DbType.String, objEntity.ActivityEndDateTime);
                SqlParameter prm7 = objSDP.CreateInitializedParameter("@ActivityPrice", DbType.String, objEntity.ActivityPrice);
                SqlParameter prm8 = objSDP.CreateInitializedParameter("@CreateDateTime", DbType.DateTime, objEntity.CreatedDateTime);
                SqlParameter prm9 = objSDP.CreateInitializedParameter("@UpdatedDateTime", DbType.DateTime, objEntity.UpdatedDateTime);
                SqlParameter prm10 = objSDP.CreateInitializedParameter("@EventId", DbType.String, objEntity.EventId);




                SqlParameter[] Sqlpara = { prm1, prm2, prm3, prm4, prm5, prm6, prm7, prm8, prm9, prm10 };

                ds = SqlHelper.ExecuteDataset(Con_str, query, Sqlpara);
                if (objEntity.Flag == "INSERT" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objSerializeResponse.ID = Convert.ToInt16(ds.Tables[0].Rows[0]["StatusCode"]);
                    objSerializeResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
                else if (objEntity.Flag == "GETALL" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Count != 2)
                {
                    objSerializeResponse.ArrayOfResponse = bl.ListConvertDataTable<ACTIVITYINFO>(ds.Tables[0]);
                    objSerializeResponse.Message = "200|Data Found";
                }
                else if (objEntity.Flag == "GETALL" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Count == 2)
                {
                    objSerializeResponse.ID = Convert.ToInt16(ds.Tables[0].Rows[0]["StatusCode"]);
                    objSerializeResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
                else if (objEntity.Flag == "GETALL" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count == 0)
                {
                    objSerializeResponse.Message = "400|No Data Found";
                }
                else if (objEntity.Flag == "GETBYEVENTID" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Count != 2)
                {
                    objSerializeResponse.ArrayOfResponse = bl.ListConvertDataTable<ACTIVITYINFO>(ds.Tables[0]);
                    objSerializeResponse.Message = "200|Data Found";
                }
                else if (objEntity.Flag == "GETBYEVENTID" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Count == 2)
                {
                    objSerializeResponse.ID = Convert.ToInt16(ds.Tables[0].Rows[0]["StatusCode"]);
                    objSerializeResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
                else if (objEntity.Flag == "GETBYEVENTID" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count == 0)
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
