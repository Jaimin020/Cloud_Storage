using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cloud_CRUD.Models;

namespace Cloud_CRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service : Operations
    {
        Database_Context db = new Database_Context();

        public int Add_File(string name, string Ext, byte[] d, int u)
        {
            User_Details uo = db.Users.FirstOrDefault(x => x.Id == u);
            try
            {
                Files f = new Files()
                {
                    name = name,
                    extention = Ext,
                    data = d,
                    user=uo
                };
                db.Files.Add(f);
                db.SaveChanges();
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return -1;
        }

        public List<files> Fetch_All_Files(int u)
        {
            User_Details fl = db.Users.Include("files").FirstOrDefault(x=>x.Id==u);
            List<files> list = new List<files>();
            foreach(Files j in fl.files)
            {
                list.Add(new files()
                {
                    Id=j.Id,
                    Name=j.name,
                    Extention=j.extention,
                    d=null
                });
            }
               
            return list;
        }

        public string GetConnectionString()
        {
            return db.Database.Connection.ConnectionString;
        }

        public user_details getUser(int u)
        {
            User_Details ud= db.Users.Find(u);
            return new user_details()
            {
                name = ud.name,
                Email = ud.Email,
                Password = ud.Password
            };
        }

        public int Login(string email, string pass)
        {
            try
            {
                User_Details u=db.Users.FirstOrDefault(x => x.Email == email && x.Password==pass);
                if(u==null)
                {
                    return -1;
                }
                return u.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public files Read_File(int id)
        {
            Files f = db.Files.Find(id);
            //System.IO.File.WriteAllBytes(t,f.data);
            files ob = new files()
            {
                Id=f.Id,
                Name = f.name,
                Extention = f.extention,
                d = f.data
            };
            return ob;
        }

        public int Register(string name,string pass,string email)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = db.Database.Connection.ConnectionString;
            User_Details u = new User_Details()
            {
                name =name,
                Email = email,
                Password = pass
            };
            try
            {
                db.Users.Add(u);
                db.SaveChanges();
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public int Remove_File(int id)
        {
            try
            {
                db.Files.Remove(db.Files.Find(id));
                db.SaveChanges();
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return -1;
        }
    }
}
