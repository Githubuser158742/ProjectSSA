using ITBedrijf.Models;
using ITBedrijf.PresentationModels;
using ITBedrijfProject.DataAcces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ITBedrijf.DataAccess
{
    public class DAOrganisationRegister
    {
        public static List<OrganisationRegister> GetOrganisationRegisterById(int id)
        {
            string sql = "SELECT Organisations.OrganisationName, Organisations.Login, Organisation_Register.OrganisationID, Registers.RegisterName, Registers.Device, Organisation_Register.RegisterID, Organisation_Register.FromDate, Organisation_Register.UntilDate";
            sql += " FROM Organisation_Register";
            sql += " INNER JOIN Organisations";
            sql += " ON Organisation_Register.OrganisationID=Organisations.ID";
            sql += " INNER JOIN Registers";
            sql += " ON Organisation_Register.RegisterID=Registers.ID";
            sql += " WHERE OrganisationID=@OrganisationID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@OrganisationID", id);
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1);
            List<OrganisationRegister> organisationRegisters = null;
            if (reader != null)
            {
                organisationRegisters = new List<OrganisationRegister>();
                while (reader.Read())
                {
                    OrganisationRegister organisationRegister = new OrganisationRegister();
                    organisationRegister.OrganisationID = (int)reader["OrganisationID"];
                    organisationRegister.RegisterID = (int)reader["RegisterID"];
                    organisationRegister.FromDate = (DateTime)reader["FromDate"];
                    organisationRegister.UntilDate = (DateTime)reader["UntilDate"];
                    organisationRegister.RegisterName = reader["RegisterName"].ToString();
                    organisationRegister.OrganisationName = reader["OrganisationName"].ToString();
                    organisationRegister.Login = reader["Login"].ToString();
                    organisationRegister.Device = reader["Device"].ToString();
                    organisationRegisters.Add(organisationRegister);
                }
            }
            return organisationRegisters;
        }

        public static OrganisationRegister GetOrganisationRegisterByIds(int OrganisationID, int RegisterID)
        {
            string sql = "SELECT Organisations.OrganisationName, Organisations.Login, Organisation_Register.OrganisationID, Registers.RegisterName, Registers.Device, Organisation_Register.RegisterID, Organisation_Register.FromDate, Organisation_Register.UntilDate";
            sql += " FROM Organisation_Register";
            sql += " INNER JOIN Organisations";
            sql += " ON Organisation_Register.OrganisationID=Organisations.ID";
            sql += " INNER JOIN Registers";
            sql += " ON Organisation_Register.RegisterID=Registers.ID";
            sql += " WHERE OrganisationID=@OrganisationID AND RegisterID=@RegisterID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@OrganisationID", OrganisationID);
            DbParameter par2 = Database.AddParameter("AdminDB", "@RegisterID", RegisterID);
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1, par2);
            OrganisationRegister organisationRegister = null;
            if (reader != null)
            {
                organisationRegister = new OrganisationRegister();
                while (reader.Read())
                {
                    organisationRegister.OrganisationID = (int)reader["OrganisationID"];
                    organisationRegister.RegisterID = (int)reader["RegisterID"];
                    organisationRegister.FromDate = (DateTime)reader["FromDate"];
                    organisationRegister.UntilDate = (DateTime)reader["UntilDate"];
                    organisationRegister.RegisterName = reader["RegisterName"].ToString();
                    organisationRegister.OrganisationName = reader["OrganisationName"].ToString();
                    organisationRegister.Login = reader["Login"].ToString();
                    organisationRegister.Device = reader["Device"].ToString();
                }
            }
            return organisationRegister;
        }

        public static int InsertOrganisationRegister(OrganisationRegister organisationRegister)
        {
            string sql = "INSERT INTO Organisation_Register VALUES(@OrganisationID,@RegisterID,@FromDate,@UntilDate)";
            DbParameter par1 = Database.AddParameter("AdminDB", "@OrganisationID", organisationRegister.OrganisationID);
            DbParameter par2 = Database.AddParameter("AdminDB", "@RegisterID", organisationRegister.RegisterID);
            DbParameter par3 = Database.AddParameter("AdminDB", "@FromDate", organisationRegister.FromDate);
            DbParameter par4 = Database.AddParameter("AdminDB", "@UntilDate", organisationRegister.UntilDate);

            return Database.InsertData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4);
        }

        public static int UpdateOrganisationRegister(int oldOrganisationID, OrganisationRegister organisationRegister)
        {
            string sql = "UPDATE Organisation_Register SET OrganisationID=@OrganisationID, RegisterID=@RegisterID, FromDate=@FromDate, UntilDate=@UntilDate WHERE OrganisationID=@OrganisationIDold AND RegisterID=@RegisterID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@OrganisationID", organisationRegister.OrganisationID);
            DbParameter par2 = Database.AddParameter("AdminDB", "@RegisterID", organisationRegister.RegisterID);
            DbParameter par3 = Database.AddParameter("AdminDB", "@FromDate", organisationRegister.FromDate);
            DbParameter par4 = Database.AddParameter("AdminDB", "@UntilDate", organisationRegister.UntilDate);
            DbParameter par5 = Database.AddParameter("AdminDB", "@OrganisationIDold", oldOrganisationID);

            return Database.ModifyData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4, par5);
        }
    }
}