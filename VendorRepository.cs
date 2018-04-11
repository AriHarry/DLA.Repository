using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using BusinessObject;


namespace DLA.Repository
{
  public   class VendorRepository:IVendor
    {
      private string _connstring = @"Data Source=ARISH;Initial Catalog=Greens;Integrated Security=True";
      public int Add(VendorObject VenObj)
      {
          int retval = 0;
          SqlConnection conn = new SqlConnection(_connstring);
          SqlCommand cmd = new SqlCommand();
          SqlParameter param = new SqlParameter();

          if (conn.State == ConnectionState.Closed)
              conn.Open();

          cmd.Connection = conn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "News_Insert";


          param = new SqlParameter("@DisplayMsg", SqlDbType.VarChar, 50, "DisplayMsg");
          param.Direction = ParameterDirection.Input;
          param.Value = VenObj.DisplayMsg;
          cmd.Parameters.Add(param);

          param = new SqlParameter("@Msg_Title", SqlDbType.VarChar, 1000, "Msg_Title");
          param.Direction = ParameterDirection.Input;
          param.Value = VenObj.Msg_Title;
          cmd.Parameters.Add(param);

          param = new SqlParameter("@Full_Message", SqlDbType.VarChar, 1000, "Full_Message");
          param.Direction = ParameterDirection.Input;
          param.Value = VenObj.Full_Message;
          cmd.Parameters.Add(param);

           

          retval = cmd.ExecuteNonQuery();
          if (conn.State == ConnectionState.Open)
              conn.Close();
          return retval;
      }


      public int Update(VendorObject VenObj)
      {
          int retval = 0;
          SqlConnection conn = new SqlConnection(_connstring);
          SqlCommand cmd = new SqlCommand();
          SqlParameter param = new SqlParameter();


          if (conn.State == ConnectionState.Closed)
              conn.Open();

          cmd.Connection = conn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "News_Update";

          param = new SqlParameter("@MsgId", SqlDbType.Int, 4, "MsgId");
          param.Direction = ParameterDirection.Input;
          param.Value = VenObj.MsgId;
          cmd.Parameters.Add(param);

          param = new SqlParameter("@DisplayMsg", SqlDbType.VarChar, 1000, "DisplayMsg");
          param.Direction = ParameterDirection.Input;
          param.Value = VenObj.DisplayMsg;
          cmd.Parameters.Add(param);

          param = new SqlParameter("@Msg_Title", SqlDbType.VarChar, 1000, "Msg_Title");
          param.Direction = ParameterDirection.Input;
          param.Value = VenObj.Msg_Title;
          cmd.Parameters.Add(param);

          param = new SqlParameter("@Full_Message", SqlDbType.VarChar, 1000, "Full_Message");
          param.Direction = ParameterDirection.Input;
          param.Value = VenObj.Full_Message;
          cmd.Parameters.Add(param);

          

          retval = cmd.ExecuteNonQuery();
          if (conn.State == ConnectionState.Open)
              conn.Close();

          return retval;
      }


      public int Delete(int MsgId)
      {

          int retval = 0;
          SqlConnection conn = new SqlConnection(_connstring);
          SqlCommand cmd = new SqlCommand();
          SqlParameter param = new SqlParameter();

          if (conn.State == ConnectionState.Closed)
              conn.Open();

          cmd.Connection = conn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "News_Delete";

          param = new SqlParameter("@MsgId", SqlDbType.Int, 4, "MsgId");
          param.Direction = ParameterDirection.Input;
          param.Value = MsgId;
          cmd.Parameters.Add(param);

          retval = cmd.ExecuteNonQuery();
          if (conn.State == ConnectionState.Open)
              conn.Close();

          return retval;
      }

      public VendorObject GetById(int MsgId)
      {

          SqlConnection conn = new SqlConnection(_connstring);
          SqlCommand cmd = new SqlCommand();
          SqlParameter param = new SqlParameter();
          SqlDataReader reader;

          if (conn.State == ConnectionState.Closed)
              conn.Open();
          cmd.Connection = conn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "News_GetById";

          param = new SqlParameter("@MsgId", SqlDbType.Int, 4, "MsgId");
          param.Direction = ParameterDirection.Input;
          param.Value = MsgId;
          cmd.Parameters.Add(param);
          reader = cmd.ExecuteReader();
          VendorObject VenObj = new VendorObject();
          while (reader.Read())
          {
              VenObj.MsgId = reader.GetInt32(reader.GetOrdinal("MsgId"));
              VenObj.DisplayMsg = reader.GetString(reader.GetOrdinal("DisplayMsg"));
              VenObj.Msg_Title = reader.GetString(reader.GetOrdinal("Msg_Title"));
              VenObj.Full_Message = reader.GetString(reader.GetOrdinal("Full_Message"));
             

          }
          if (conn.State == ConnectionState.Open)
              conn.Close();
          return VenObj;
      }

      public List<VendorObject> GetAll()
      {
         
          SqlConnection conn = new SqlConnection(_connstring);
          SqlCommand cmd = new SqlCommand();
          
          SqlDataReader reader;

          if (conn.State == ConnectionState.Closed)
              conn.Open();
          cmd.Connection = conn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "News_GetAll";

          reader = cmd.ExecuteReader();
          List<VendorObject> VendorList = new List<VendorObject>();

          while (reader.Read())
          {

              VendorObject VenObj = new VendorObject();
              {
                  VenObj.MsgId = reader.GetInt32(reader.GetOrdinal("MsgId"));
                  VenObj.DisplayMsg = reader.GetString(reader.GetOrdinal("DisplayMsg"));
                  VenObj.Msg_Title = reader.GetString(reader.GetOrdinal("Msg_Title"));
                  VenObj.Full_Message = reader.GetString(reader.GetOrdinal("Full_Message"));
                  
                  
              }
              VendorList.Add(VenObj);
          }
          if (conn.State == ConnectionState.Open)
              conn.Close();
          return VendorList;
      }
    }
}
