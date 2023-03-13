using MVCminiProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVCminiProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            Country_Bind();
            
            // State_Bind();
            Grid();
            return View();
        }
       
        [HttpPost]
        public ActionResult Index(User Obj)
        {
            BALUser obj = new BALUser();
            obj.SaveDate(Obj.Name, Obj.Phone,Obj.Email, Obj.CityId,Obj.Password);
            return RedirectToAction("Index");
        }
       
        public void Country_Bind()
        {
            BALUser obj = new BALUser();
            DataSet ds= obj.GetCountry();
            List<SelectListItem>
                CountryList= new List<SelectListItem>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                CountryList.Add(new SelectListItem
                {
                    Text = dr["CountryName"].ToString(),
                    Value = dr["CountryId"].ToString()
                });
            }
            ViewBag.Country= CountryList;
        }
        public JsonResult State_Bind(int Country_Id)
        {
            User Obj= new User();
            BALUser obj= new BALUser();
            DataSet ds = obj.GetState(Country_Id);
            List<SelectListItem>
                StatesList= new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                StatesList.Add(new SelectListItem
                {
                    Text = dr["StateName"].ToString(),
                    Value = dr["StateId"].ToString()
                });
            }
           // ViewBag.StateName = StatesList;
            return Json(StatesList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult City_Bind(int State_Id)
        
        {
            
            BALUser obj = new BALUser();
            DataSet ds = obj.GetCity(State_Id);
            List<SelectListItem> CityList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                CityList.Add(new SelectListItem
                {
                    Text = dr["cityName"].ToString(),
                    Value = dr["CityId"].ToString()
                });
            }
            // ViewBag.StateName = StatesList;
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Grid()
        {
            BALUser objUser = new BALUser();
            DataSet ds = new DataSet();
            ds = objUser.GetUser();
            User objDetails = new User();
            List<User> LstUserDt1 = new List<User>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                User obj = new User();
                obj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                obj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                obj.Phone = Convert.ToInt64( ds.Tables[0].Rows[i]["Phone"].ToString());
                obj.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                obj.CountryName = ds.Tables[0].Rows[i]["CountryName"].ToString();
                obj.StateName = ds.Tables[0].Rows[i]["StateName"].ToString();
                obj.CityName = ds.Tables[0].Rows[i]["CityName"].ToString();
                obj.Password = ds.Tables[0].Rows[i]["Password"].ToString();
                /*obj.ProfilePic = ds.Tables[0].Rows[i]["Profilepic"].ToString();*/
                LstUserDt1.Add(obj);

            }
            objDetails.ListUser = LstUserDt1;

            return View(objDetails);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Country_Bind();
            User obj = new User();
            obj.Id = Id;
            BALUser obj1 = new BALUser();
            SqlDataReader dr;
            dr = obj1.GetData(obj.Id);
            while (dr.Read())
            {
               // obj.Id = Convert.ToInt32(dr["id"].ToString());
                obj.Name = dr["Name"].ToString();
                obj.Phone =Convert.ToInt64( dr["Phone"].ToString());
                obj.Email = dr["Email"].ToString();
                obj.CountryName = dr["CountryName"].ToString();
                obj.StateName = dr["StateName"].ToString();
                obj.CityName = dr["CityName"].ToString();
                obj.Password = dr["Password"].ToString();
            }
            dr.Close();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(User Obj)
        {
            BALUser obj = new BALUser();
            obj.updateDate(Obj.Id, Obj.Name, Obj.Phone,Obj.Email,Obj.CityId,Obj.Password);
            return RedirectToAction("Index");
        }
       
        public ActionResult Delete(User Obj)
        {
            BALUser obj = new BALUser();
            obj.DeleteDate(Obj.Id);
            return RedirectToAction("Index");
            // ViewBag.message("Delete sucessfullu");
        }
        [HttpPost]
        public ActionResult Detail(int id)
        {
            Country_Bind();
            User obj = new User();
            obj.Id =id;
            BALUser obj1 = new BALUser();
            SqlDataReader dr;
            dr = obj1.GetData(obj.Id);
            while (dr.Read())
            {
                // obj.Id = Convert.ToInt32(dr["id"].ToString());
                obj.Name = dr["Name"].ToString();
                obj.Phone = Convert.ToInt64(dr["Phone"].ToString());
                obj.Email = dr["Email"].ToString();
                obj.CountryName = dr["CountryName"].ToString();
                obj.StateName = dr["StateName"].ToString();
                obj.CityName = dr["CityName"].ToString();
                obj.Password = dr["Password"].ToString();
            }
            dr.Close();
            return PartialView("Detail",obj);
        }

        /* public ActionResult Detail(int Id)
         {
             BALUser frnds = new BALUser();
             frnds = db.FriendsInfo.Find(Id);
             return PartialView("_Detail", frnds);
         }*/
        [HttpPost]
        public ActionResult ProfileP(User Obj)
        {
            BALUser obj = new BALUser();
            obj.ProfileP(obj.ProfileP);
            return RedirectToAction("Index");
        }



    }
}