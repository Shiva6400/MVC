using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace MVCminiProject.Models
{
    public class BALUser
    {
        SqlConnection con = new SqlConnection("Data Source=SANKET;Initial Catalog=MVCminiProject;Integrated Security=True");


        public void SaveDate(string Name,Int64 Phone,string Email,int CityId,string Password)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SaveData");
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@CityId", CityId);
            cmd.Parameters.AddWithValue("@Password", Password);
           /* cmd.Parameters.AddWithValue("@Profilepic", profilepic);*/
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataSet GetCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Country");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;



            con.Close();
        }
        public DataSet GetState(int CountryId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "State");
            cmd.Parameters.AddWithValue("@CountryId", CountryId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;



            con.Close();
        }
        public DataSet GetCity(int stateId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "City");
            cmd.Parameters.AddWithValue("@stateId", stateId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

            con.Close();
        }
        public DataSet GetUser()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Gridview");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;



            con.Close();
        }
        public SqlDataReader GetData(int Id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "featch");
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;



            con.Close();
        }
        public void updateDate(int Id, string Name, Int64 Phone,string Email,int Cityid,string Password)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "update");
            cmd.Parameters.AddWithValue("@ID", Id);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@CityId", Cityid);
            cmd.Parameters.AddWithValue("Password", Password);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void DeleteDate(int Id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "delete");
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void ProfileP(string ProfilePic)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ProfilePic");
            
            cmd.ExecuteNonQuery();
            con.Close();

        }

        internal void ProfileP(Action<string> profileP)
        {
            throw new NotImplementedException();
        }
    }
}