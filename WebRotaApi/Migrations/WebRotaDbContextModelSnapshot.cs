﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebRotaApi.Persistence;

namespace WebRotaApi.Migrations
{
    [DbContext(typeof(WebRotaDbContext))]
    partial class WebRotaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebRotaApi.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("WebRotaApi.Models.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("OwnerId");

                    b.HasKey("Id");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("WebRotaApi.Models.OrganisationMember", b =>
                {
                    b.Property<int>("MemberId");

                    b.Property<int>("OrganisationId");

                    b.HasKey("MemberId", "OrganisationId");

                    b.HasIndex("OrganisationId");

                    b.ToTable("OrganisationMembers");
                });

            modelBuilder.Entity("WebRotaApi.Models.OrganisationMember", b =>
                {
                    b.HasOne("WebRotaApi.Models.Member", "Member")
                        .WithMany("Organisations")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRotaApi.Models.Organisation", "Organisation")
                        .WithMany("Members")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
