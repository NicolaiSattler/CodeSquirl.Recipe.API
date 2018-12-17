using System.Data;
using Autofac;
using CodeSquirl.System;
using Npgsql;

namespace CodeSquirl.RecipeApp.API
{
    public class APIModule : Module
    {
        private readonly string _connectionString;

        public APIModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(connection => new NpgsqlConnection(_connectionString)).As<IDbConnection>();
            builder.RegisterType<ProductController>().InstancePerRequest();
        }
    }
}
