using Infrastructure.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class UserIdentityDbContext : IdentityDbContext<ApplicaionUser> 
{ 
    public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options) 
    { 
         
    } 
 
    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
        
    } 
 
 
}