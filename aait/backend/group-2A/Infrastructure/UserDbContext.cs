using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Model;

namespace Persistence;

public class UserIdentityDbContext : IdentityDbContext<ApplicaionUser> 
{ 
    public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options) 
    { 
         
    } 
 
    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
        
    } 
 
 
}