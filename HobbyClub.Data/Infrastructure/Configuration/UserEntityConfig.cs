﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using HobbyClub.Data.Entities;

namespace HobbyClub.Data.Infrastructure.Configuration
{
    public class UserEntityConfig : EntityTypeConfiguration<User>
    {
        public UserEntityConfig()
        {
            this.ToTable("User");
            this.HasKey<Guid>(u => u.UserId);
            this.Property(p => p.CreationDate)
                .HasColumnType("datetime2");
            this.Property(p => p.Name)
                .IsRequired();
            this.Property(p => p.Surname)
                .IsRequired();
            this.Property(p => p.Mail)
                .IsRequired();
            this.HasMany<Event>(e => e.Events)
                .WithMany(u => u.Users)
                .Map(us =>
                {
                    us.MapLeftKey("UserId");
                    us.MapRightKey("EventId");
                    us.ToTable("UserEvent");
                });
            this.HasMany<Group>(u => u.Groups)
                .WithMany(u => u.Users)
                .Map(us =>
                {
                    us.MapLeftKey("UserId");
                    us.MapRightKey("GroupId");
                    us.ToTable("UserGroup");
                });
            this.HasMany<Interest>(e => e.Interests)
                 .WithMany(u => u.Users)
                 .Map(us =>
                 {
                     us.MapLeftKey("UserId");
                     us.MapRightKey("InterestId");
                     us.ToTable("UserInterest");
                 });
        }
    }
}
