using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Data;
public class AppDbContext (DbContextOptions<AppDbContext> options):IdentityDbContext(options);