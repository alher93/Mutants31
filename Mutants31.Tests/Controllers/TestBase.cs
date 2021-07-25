using Microsoft.EntityFrameworkCore;

namespace Mutants31.Tests.Controllers
{
    public class TestBase
    {
        protected ApplicationDBContext BuildContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                                                    .UseInMemoryDatabase(dbName).Options;

            return new ApplicationDBContext(options);
        }
    }
}
