using Exemplo.Nancy.WebApi.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Exemplo.Nancy.WebApi
{
    public static class DbManager
    {
        private static readonly string ConnectionString;

        static DbManager()
        {
            var databaseDir = HttpContext.Current.Server.MapPath(@"\App_Data");
            var databasePath = Path.Combine(databaseDir, "exemplo.db");

            if (!Directory.Exists(databaseDir)) Directory.CreateDirectory(databaseDir);
            if (!File.Exists(databasePath))
            {
                var fs = File.Create(databasePath);
                fs.Close();
            }

            ConnectionString = string.Format(@"Filename={0}", databasePath);
        }

        #region Cliente

        public static List<Cliente> GetAllClients()
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var model = db.GetCollection<Cliente>().FindAll();
                return model.ToList();
            }
        }

        public static Cliente GetClientById(int id)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var model = db.GetCollection<Cliente>().FindById(id);
                return model;
            }
        }

        public static bool SaveClient(Cliente model)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                return db.GetCollection<Cliente>().Upsert(model);
            }
        }

        #endregion

        #region Estabelecimento

        public static List<Estabelecimento> GetAllEstablishments()
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var model = db.GetCollection<Estabelecimento>().FindAll();
                return model.ToList();
            }
        }

        public static Estabelecimento GetEstablishmentById(int id)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var model = db.GetCollection<Estabelecimento>().FindById(id);
                return model;
            }
        }

        public static bool SaveEstablishment(Estabelecimento model)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                return db.GetCollection<Estabelecimento>().Upsert(model);
            }
        }

        public static bool DeleteClient(int id)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                return db.GetCollection<Cliente>().Delete(id);
            }
        }

        #endregion

        #region Pagamento
        
        public static Pagamento GetPaymentByIdEstablishment(int id)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var model = db.GetCollection<Pagamento>().FindOne(x => x.IdEstabelecimento == id);
                return model;
            }
        }

        public static bool SavePayment(Pagamento model)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                return db.GetCollection<Pagamento>().Upsert(model);
            }
        }

        public static bool DeletePayment(int id)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                return db.GetCollection<Pagamento>().Delete(id);
            }
        }

        #endregion
    }
}