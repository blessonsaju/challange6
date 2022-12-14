using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace submissionCHALLANGE_6.DAL
{
    public class desgDal
    {
        public SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public desgDal()
        {
            //call conncetionstring;conncetion string should be set in the web.conf file
            string conn = ConfigurationManager.ConnectionStrings["rose"].ConnectionString;
            con = new SqlConnection(conn);
            cmd.Connection = con;
        }
        public SqlConnection GetCon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public DataTable Getdeprt(BAL.desgBal obj)
        {
            string s = "SELECT * FROM Dept";
            SqlCommand cmd = new SqlCommand(s, GetCon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int InsertDesig(BAL.desgBal obj)
        {
            string qry = "insert into tbldesignation values('" + obj.Desgination + "','" + obj.DepId + "')";
            SqlCommand cmd = new SqlCommand(qry, GetCon());
            return cmd.ExecuteNonQuery();
        }


        public DataTable desigview(BAL.desgBal obj)
        {
            string s = "select * from tbldesignation td inner join Dept dt on td.depId=dt.depId";
            SqlCommand cmd = new SqlCommand(s, GetCon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int desgUpdate(BAL.desgBal obj)
        {
            string s = "update tbldesignation set DesignationName='" + obj.Desgination + "' where DesignationId='" + obj.DesgId + "'";
            SqlCommand cmd = new SqlCommand(s, GetCon());
            return cmd.ExecuteNonQuery();
        }

        public int updatedept(BAL.desgBal obj)
        {
            string l = "select depId from tbldesignation where DesignationId='" + obj.DesgId + "'";
            SqlCommand cmd = new SqlCommand(l, GetCon());
            object up= cmd.ExecuteScalar();
            string s="update Dept set depname='" +obj.Department+ "'  where depId='" + up + "'";
             cmd = new SqlCommand(s, GetCon());
            return cmd.ExecuteNonQuery();
        }

        public int Deletedesig(BAL.desgBal obj)
        {
            string s = "delete from tbldesignation where DesignationId='" + obj.DesgId + "'";
            SqlCommand cmd = new SqlCommand(s, GetCon());
            return cmd.ExecuteNonQuery();
        }

        public DataSet exedataset(String sql)
        {
            cmd.CommandType = CommandType.Text; //set command type
            cmd.CommandText = sql; //pass sql command to command text
            SqlDataAdapter sd = new SqlDataAdapter(cmd);//Createadapter class because disconnected architecture
            DataSet ds = new DataSet();//create dataset
            sd.Fill(ds);
            return ds;


        }

        public DataSet dropselect()
        {
            string s = "select * from Dept";
            SqlCommand cmd = new SqlCommand(s, GetCon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }
    }
}