using Library;
using LIBRARY;
using MODELS.MODELS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace BL.EventServices
{
    public class EventInfoService
    {
        public SerializeResponse<EVENTINFO> EventInfoOpration(EVENTINFO objEntity)
        {
            InsertLog.WriteErrrorLog("UserService=>UserOpration=>Started");
            ConvertDataTable bl = new ConvertDataTable();
            SerializeResponse<EVENTINFO> objSerializeResponse = new SerializeResponse<EVENTINFO>();

            DataSet ds = new DataSet();
            SqlDataProvider objSDP = new SqlDataProvider();
            string query = "SP_EventInfo";
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
                SqlParameter prm2 = objSDP.CreateInitializedParameter("@EventId", DbType.String, objEntity.EventId);
                SqlParameter prm3 = objSDP.CreateInitializedParameter("@EventName", DbType.String, objEntity.EventName);
                SqlParameter prm4 = objSDP.CreateInitializedParameter("@EventDESC", DbType.String, objEntity.EventDESC);
                SqlParameter prm5 = objSDP.CreateInitializedParameter("@EventStartDate", DbType.String, objEntity.EventStartDate);
                SqlParameter prm6 = objSDP.CreateInitializedParameter("@EventEndDate", DbType.String, objEntity.EventEndDate);
                SqlParameter prm7 = objSDP.CreateInitializedParameter("@EventImgPath", DbType.String, objEntity.EventImgPath);
                SqlParameter prm8 = objSDP.CreateInitializedParameter("@CreateDateTime", DbType.DateTime, objEntity.CreatedDateTime);
                SqlParameter prm9 = objSDP.CreateInitializedParameter("@UpdatedDateTime", DbType.DateTime, objEntity.UpdatedDateTime);
                SqlParameter prm10 = objSDP.CreateInitializedParameter("@AdminId", DbType.String, objEntity.AdminId);




                SqlParameter[] Sqlpara = { prm1, prm2, prm3, prm4, prm5, prm6, prm7, prm8, prm9, prm10 };

                ds = SqlHelper.ExecuteDataset(Con_str, query, Sqlpara);
                if (objEntity.Flag == "INSERT" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objSerializeResponse.ID = Convert.ToInt16(ds.Tables[0].Rows[0]["StatusCode"]);
                    objSerializeResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
                else if (objEntity.Flag == "GETALL" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Count != 2)
                {
                    objSerializeResponse.ArrayOfResponse = bl.ListConvertDataTable<EVENTINFO>(ds.Tables[0]);
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
