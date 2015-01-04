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
    public class DARegister
    {
        public static List<Register> GetRegisters()
        {
            string sql = "SELECT ID, RegisterName, Device, PurchaseDate, ExpireDate FROM Registers";
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql);
            List<Register> Registers = null;
            if (reader != null)
            {
                Registers = new List<Register>();
                while (reader.Read())
                {
                    Register register = new Register();
                    register.Id = (int)reader["ID"];
                    register.RegisterName = reader["RegisterName"].ToString();
                    register.Device = reader["Device"].ToString();
                    register.PurchaseDate = (DateTime)reader["PurchaseDate"];
                    register.ExpireDate = (DateTime)reader["ExpireDate"];
                    Registers.Add(register);
                }
            }
            
            return Registers;
        }

        public static int InsertRegister(Register register)
        {
            string sql = "INSERT INTO Registers VALUES(@RegisterName,@Device,@PurchaseDate,@ExpireDate)";
            DbParameter par1 = Database.AddParameter("AdminDB", "@RegisterName", register.RegisterName);
            DbParameter par2 = Database.AddParameter("AdminDB", "@Device", register.Device);
            DbParameter par3 = Database.AddParameter("AdminDB", "@PurchaseDate", register.PurchaseDate);
            DbParameter par4 = Database.AddParameter("AdminDB", "@ExpireDate", register.ExpireDate);
            return Database.InsertData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4);
        }
    }
}