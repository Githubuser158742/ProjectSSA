using ITBedrijf.Models;
using ITBedrijf.PresentationModels;
using ITBedrijfProject.DataAcces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace ITBedrijf.DataAccess
{
    public class DAOrganisation
    {
        public static List<Organisation> GetOrganisations()
        {
            string sql = "SELECT ID, Login, Password, DbName, DbLogin, DbPassword, OrganisationName, Address, Email, Phone FROM Organisations";
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql);
            List<Organisation> Organisations = null;
            if (reader != null)
            {
                Organisations = new List<Organisation>();
                while (reader.Read())
                {
                    Organisation organisation = new Organisation();
                    organisation.Id = (int)reader["ID"];
                    organisation.Login = reader["Login"].ToString();
                    organisation.Password = reader["Password"].ToString();
                    organisation.DbName = reader["DbName"].ToString();
                    organisation.DbLogin = reader["DbLogin"].ToString();
                    organisation.DbPassword = reader["DbPassword"].ToString();
                    organisation.OrganisationName = reader["OrganisationName"].ToString();
                    organisation.Address = reader["Address"].ToString();
                    organisation.Email = reader["Email"].ToString();
                    organisation.Phone = reader["Phone"].ToString();

                    Organisations.Add(organisation);
                }
            }
            return Organisations;
        }

        public static int InsertOrganisation(Organisation o)
        {
                string sql = "INSERT INTO Organisations VALUES(@Login,@Password,@DbName,@DbLogin,@DbPassword,@OrganisationName,@Address,@Email,@Phone)";
                DbParameter par1 = Database.AddParameter("AdminDB", "@Login", o.Login);
                DbParameter par2 = Database.AddParameter("AdminDB", "@Password", o.Password);
                DbParameter par3 = Database.AddParameter("AdminDB", "@DbName", o.DbName);
                DbParameter par4 = Database.AddParameter("AdminDB", "@DbLogin", o.DbLogin);
                DbParameter par5 = Database.AddParameter("AdminDB", "@DbPassword", o.DbPassword);
                DbParameter par6 = Database.AddParameter("AdminDB", "@OrganisationName", o.OrganisationName);
                DbParameter par7 = Database.AddParameter("AdminDB", "@Address", o.Address);
                DbParameter par8 = Database.AddParameter("AdminDB", "@Email", o.Email);
                DbParameter par9 = Database.AddParameter("AdminDB", "@Phone", o.Phone);

                int id = Database.InsertData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4, par5, par6, par7, par8, par9);
                
            CreateDatabase(o);

            return id;
        }

        private static void CreateDatabase(Organisation o)
        {
            // create the actual database
            //string create = File.ReadAllText(HostingEnvironment.MapPath(@"~/App_Data/create.txt")); //only for the web
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string create = File.ReadAllText(path+"\\Data\\create.txt"); // only for desktop
            string sql = create.Replace("@@DbName", o.DbName).Replace("@@DbLogin", o.DbLogin).Replace("@@DbPassword", o.DbPassword);
            foreach (string commandText in RemoveGo(sql))
            {
                Database.ModifyData(Database.GetConnection("ClientDB"), commandText);
            }

            // create login, user and tables
            DbTransaction trans = null;
            try
            {
                trans = Database.BeginTransaction("ClientDB");

                //string fill = File.ReadAllText(HostingEnvironment.MapPath(@"~/App_Data/fill.txt")); // only for the web
                string fill = File.ReadAllText(path+"\\Data\\fill.txt"); // only for desktop
                string sql2 = fill.Replace("@@DbName", o.DbName).Replace("@@DbLogin", o.DbLogin).Replace("@@DbPassword", o.DbPassword);

                foreach (string commandText in RemoveGo(sql2))
                {
                    Database.ModifyData(trans, commandText);
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Console.WriteLine(ex.Message);
            }
        }

        private static string[] RemoveGo(string input)
        {
            string[] splitter = new string[] { "\r\nGO\r\n" };
            string[] commandTexts = input.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            return commandTexts;
        }


        public static Organisation GetOrganisationById(int id)
        {
            string sql = "SELECT ID, Login, Password, DbName, DbLogin, DbPassword, OrganisationName, Address, Email, Phone FROM Organisations WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@ID", id);
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1);
            Organisation organisation = null;
            if (reader != null)
            {
                organisation = new Organisation();
                while (reader.Read())
                {
                    organisation.Id = (int)reader["ID"];
                    organisation.Login = reader["Login"].ToString();
                    organisation.Password = reader["Password"].ToString();
                    organisation.DbName = reader["DbName"].ToString();
                    organisation.DbLogin = reader["DbLogin"].ToString();
                    organisation.DbPassword = reader["DbPassword"].ToString();
                    organisation.OrganisationName = reader["OrganisationName"].ToString();
                    organisation.Address = reader["Address"].ToString();
                    organisation.Email = reader["Email"].ToString();
                    organisation.Phone = reader["Phone"].ToString();
                }
            }
            return organisation;
        }

        public static int UpdateOrganisation(int id, Organisation organisation)
        {
            string sql = "UPDATE Organisations SET OrganisationName=@OrganisationName, Login=@Login, Password=@Password, DbName=@DbName, DbLogin=@DbLogin, DbPassword=@DbPassword, Address=@Address, Email=@Email, Phone=@Phone WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@ID", id);
            DbParameter par2 = Database.AddParameter("AdminDB", "@OrganisationName", organisation.OrganisationName);
            DbParameter par3 = Database.AddParameter("AdminDB", "@Login", organisation.Login);
            DbParameter par4 = Database.AddParameter("AdminDB", "@Password", organisation.Password);
            DbParameter par5 = Database.AddParameter("AdminDB", "@DbName", organisation.DbName);
            DbParameter par6 = Database.AddParameter("AdminDB", "@DbLogin", organisation.DbLogin);
            DbParameter par7 = Database.AddParameter("AdminDB", "@DbPassword", organisation.DbPassword);
            DbParameter par8 = Database.AddParameter("AdminDB", "@Address", organisation.Address);
            DbParameter par9 = Database.AddParameter("AdminDB", "@Email", organisation.Email);
            DbParameter par10 = Database.AddParameter("AdminDB", "@Phone", organisation.Phone);

            return Database.ModifyData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4, par5, par6, par7, par8, par9, par10);
        }
    }
}