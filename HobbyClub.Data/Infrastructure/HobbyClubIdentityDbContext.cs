﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using HobbyClub.Data.Entities;
using Microsoft.AspNet.Identity;
using HobbyClub.Data.Infrastructure.Configuration;
namespace HobbyClub.Data.Infrastructure
{
    public class HobbyClubIdentityDbContext : IdentityDbContext<User>
    {
        public HobbyClubIdentityDbContext() : base("HobbyClubConnection") { }
        static HobbyClubIdentityDbContext()
        {
            Database.SetInitializer<HobbyClubIdentityDbContext>(new IdentityDbInit());
        }
        public static HobbyClubIdentityDbContext Create()
        {
            return new HobbyClubIdentityDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new EventEntityConfig());
            modelBuilder.Configurations.Add(new GroupEntityConfig());
            modelBuilder.Configurations.Add(new InterestEntityConfig());
            modelBuilder.Configurations.Add(new PhotoEntityConfig());
            modelBuilder.Configurations.Add(new IdentityUserEntityConfig());
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }

    //public class IdentityDbInit : NullDatabaseInitializer<HobbyClubIdentityDbContext>
    //{
    //}
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<HobbyClubIdentityDbContext>
    {
        protected override void Seed(HobbyClubIdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }
        public void PerformInitialSetup(HobbyClubIdentityDbContext context)
        {
            AppUserManager userMgr = new AppUserManager(new UserStore<User>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<Role>(context));
            string roleName = "Admin";
            string userName = "Admin";
            string password = "Qwerty";
            string email = " admin@example.com ";
            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new Role(roleName));
            }
            User user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new User { UserName = userName, Email = email, SecondName = "Adminium", CreationDate = System.DateTime.Today },
                password);
                user = userMgr.FindByName(userName);
            }
            if (!userMgr.IsInRole(user.Id, roleName))
            {
                userMgr.AddToRole(user.Id, roleName);
            }
        }
    }
}