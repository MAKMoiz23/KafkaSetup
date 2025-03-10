using KafkaOrderSystem.Producer.Database;
using Microsoft.EntityFrameworkCore;

namespace KafkaOrderSystem.Producer.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ApiDbContext context = scope.ServiceProvider.GetRequiredService<ApiDbContext>();

            context.Database.Migrate();
        }
    }
}
