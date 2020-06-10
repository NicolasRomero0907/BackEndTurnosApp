using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Modelo;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Repositorios
{
    public class ClienteRepo : IRepo<Cliente>
    {

        private string connectionString;

        public ClienteRepo(IConfiguration configuration)
        {

            connectionString = configuration.GetValue<string>("DevConnection:ConnectionString");

        }

        internal IDbConnection Connection
        {

            get
            {

                return new NpgsqlConnection(connectionString);

            }

        }

        public void Add(Cliente item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {

                dbConnection.Open();
                return dbConnection.Query<Cliente>("SELECT * FROM CLIENTE").ToList();
            }

        }

        public Cliente FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente item)
        {
            throw new NotImplementedException();
        }
    }

}
