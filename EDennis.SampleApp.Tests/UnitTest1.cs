using System;
using Xunit;

namespace EDennis.SampleApp.Tests
{
    public class UnitTest1 :IClassFixture<DatabaseFixture<ColorContext>>
    {

        public UnitTest1(DatabaseFixture<ColorContext> fixture)
        {
            Fixture = fixture;
        }

        public DatabaseFixture<ColorContext> Fixture { get; }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [InlineData(16)]
        public void Test1(int dummy)
        {
            using var ctx = Fixture.GetContext(out string dbName);
            ctx.Rgb.Add(new Rgb { Red = 150, Green = 150, Blue = dummy });
            ctx.SaveChanges();
            Fixture.ReturnContext(dbName);
        }
    }
}
