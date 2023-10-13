using Microsoft.EntityFrameworkCore;
using Shared.Database;

namespace Menu.Salads;

public sealed class SaladsDbContext(DbContextOptions<SaladsDbContext> options)
    : BaseDbContext(options, Schema)
{
    public const string Schema = "salads";
}
