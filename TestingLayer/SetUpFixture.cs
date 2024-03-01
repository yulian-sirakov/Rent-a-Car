using DataLayer.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLayer
{
    [SetUpFixture]
    public static class SetUpFixture
    {
        public static RentACarDbContext dbContext;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            dbContext = new RentACarDbContext(builder.Options);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown() 
        {
            dbContext.Dispose();
        }
    }
}
