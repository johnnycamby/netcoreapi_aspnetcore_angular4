using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreWebAngularApp.Data;

namespace CoreWebAngularApp.Migrations
{
    [DbContext(typeof(XplicitDbContext))]
    [Migration("20170522091752_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreWebAngularApp.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarModel");

                    b.Property<string>("CarName");

                    b.Property<Guid>("CompanyId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("Rating");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CoreWebAngularApp.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.Property<DateTimeOffset>("FoundedAt");

                    b.Property<string>("ImageLogo");

                    b.Property<string>("Overview");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CoreWebAngularApp.Models.Car", b =>
                {
                    b.HasOne("CoreWebAngularApp.Models.Company", "Company")
                        .WithMany("Cars")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
