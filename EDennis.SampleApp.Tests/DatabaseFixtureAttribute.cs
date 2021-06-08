using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDennis.SampleApp.Tests
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DatabaseFixtureAttribute : Attribute
    {
        public int DatabasePoolSize { get; }
        public DatabaseFixtureAttribute(int dbPoolSize)
        {
            DatabasePoolSize = dbPoolSize;
        }
    }
}
