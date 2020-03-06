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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface Operations
    {
        [OperationContract]
        string GetConnectionString();

        [OperationContract]
        int Register(string name, string pass, string email);

        [OperationContract]
        int Login(string email,string pass);

        [OperationContract]
        int Add_File(string name,string Ext,Byte[] d,int u);

        [OperationContract]
        files Read_File(int id);

        [OperationContract]
        List<files> Fetch_All_Files(int u);

        [OperationContract]
        user_details getUser(int u);

        [OperationContract]
        int Remove_File(int id);
    }
    [DataContract]
    public class user_details
    {
        //int id = -1;
        string Name = "", email = "", pass = "";

        /*[DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }*/

        [DataMember]
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string Password
        {
            get { return pass; }
            set { pass = value; }
        }

    }
    [DataContract]

    public class files
    {
        int id = -1;
        string name = "", ext = "";
        byte[] data;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Extention
        {
            get { return ext; }
            set { ext = value; }
        }

        [DataMember]
        public byte[] d
        {
            get { return data; }
            set { data = value; }
        }
    }

}
