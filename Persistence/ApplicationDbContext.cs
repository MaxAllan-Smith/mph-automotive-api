using Microsoft.EntityFrameworkCore;

namespace mph_automotive_api.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {

    };
}
