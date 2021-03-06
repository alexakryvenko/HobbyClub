﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using HobbyClub.Data.Entities;

namespace HobbyClub.Data.Infrastructure.Configuration
{
    public class PhotoEntityConfig : EntityTypeConfiguration<Photo>
    {
        public PhotoEntityConfig()
        {
            this.ToTable("Photo");
            this.HasKey<Guid>(p => p.PhotoId);
            this.Property(p => p.Value).IsRequired();
            this.HasOptional(e => e.User)
                .WithOptionalPrincipal(e => e.Photo)
                .Map(e => e.MapKey("PhotoId"));
            this.HasOptional(e => e.Group)
                .WithOptionalPrincipal(e => e.Logo)
                .Map(e => e.MapKey("LogoId"));
            this.HasOptional(e => e.Event)
                .WithOptionalPrincipal(e => e.Logo)
                .Map(e => e.MapKey("LogoId"));
            this.HasOptional(e => e.Interest)
                .WithOptionalPrincipal(e => e.Logo)
                .Map(e => e.MapKey("LogoId"));
        }
    }
}
