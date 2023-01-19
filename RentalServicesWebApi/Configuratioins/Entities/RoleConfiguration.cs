﻿using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentalServicesWebApi.Configuratioins.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {


        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "Customer"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMIN"
                }
                );

        }
    }
}

