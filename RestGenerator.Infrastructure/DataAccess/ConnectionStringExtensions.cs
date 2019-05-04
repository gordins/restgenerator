using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RestGenerator.Infrastructure.DataAccess
{
    public static class ConnectionStringExtensions
    {
        public static T Query<T>(this string connectionString, Func<IDbConnection, T> func)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.EnsureOpen();
                return func(connection);
            }
        }

        public static void Execute(this string connectionString, Action<IDbConnection> action)
        {
            using (var db = new SqlConnection(connectionString))
            {
                db.EnsureOpen();
                action(db);
            }
        }

        private static void EnsureOpen(this IDbConnection db)
        {
            if (db.State != ConnectionState.Open)
            {
                db.Open();
            }
        }
    }
}
