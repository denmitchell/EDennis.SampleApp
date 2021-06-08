using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDennis.SampleApp.Tests
{
    public class DatabaseFixture<TContext> : IDisposable
        where TContext: DbContext
    {
        public virtual int DatabasePoolCount { get; } = 1;

        protected BlockingCollection<string> DbQueue { get; } = new BlockingCollection<string>();

        public DatabaseFixture()
        {
            var ctxName = typeof(TContext).Name;

            for (int i = 0; i < DatabasePoolCount; i++)
            {
                var dbName = $"{ctxName}_{i:D3}";
                DeleteDatabase(dbName);
                CreateDatabase(dbName);
                DbQueue.Add(dbName);
            }
        }

        public TContext GetContext(out string dbName)
        {
            dbName = DbQueue.Take();
            return GetContext(dbName);
        }

        public void ReturnContext(string dbName)
        {
            DbQueue.Add(dbName);
        }


        private TContext GetContext(string dbName)
        {
            var cxnString = $"Server=(localdb)\\MSSQLLocalDB;Database={dbName};" +
                $"Trusted_Connection=True;MultipleActiveResultSets=True;";

            var options = new DbContextOptionsBuilder<TContext>()
                .UseSqlServer(cxnString)
                .Options;

            var ctx = (TContext)Activator.CreateInstance(typeof(TContext), options);

            return ctx;
        }

        private void CreateDatabase(string dbName)
        {
            using var ctx = GetContext(dbName);
            ctx.Database.Migrate();
        }

        private void DeleteDatabase(string dbName)
        {
            using var ctx = GetContext(dbName);
            ctx.Database.EnsureDeleted();
        }

        public void Dispose()
        {
            var ctxName = typeof(TContext).Name;

            for (int i = 0; i < DatabasePoolCount; i++)
            {
                var dbName = $"{ctxName}_{i:D3}";
                DeleteDatabase(dbName);
            }

        }


    }
}
