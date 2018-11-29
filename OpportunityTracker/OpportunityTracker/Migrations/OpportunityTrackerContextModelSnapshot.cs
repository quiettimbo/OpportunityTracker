﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpportunityTracker.Data;

namespace OpportunityTracker.Migrations
{
    [DbContext(typeof(OpportunityTrackerContext))]
    partial class OpportunityTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpportunityData.Activity", b =>
                {
                    b.Property<int>("ActivityID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("OpportunityID");

                    b.Property<int>("Result");

                    b.HasKey("ActivityID");

                    b.HasIndex("ContactId");

                    b.HasIndex("OpportunityID");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("OpportunityData.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("LinkedInUrl")
                        .HasMaxLength(4096);

                    b.Property<string>("Name");

                    b.Property<string>("Website")
                        .HasMaxLength(4096);

                    b.HasKey("CompanyID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("OpportunityData.Contact", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyID");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CompanyID");

                    b.ToTable("Contact");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Contact");
                });

            modelBuilder.Entity("OpportunityData.Opportunity", b =>
                {
                    b.Property<int>("OpportunityID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyID");

                    b.Property<string>("Description")
                        .HasMaxLength(4096);

                    b.Property<bool>("IsActive");

                    b.Property<string>("PrimaryContactId");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Title");

                    b.HasKey("OpportunityID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("PrimaryContactId");

                    b.ToTable("Opportunities");
                });

            modelBuilder.Entity("OpportunityData.Person", b =>
                {
                    b.HasBaseType("OpportunityData.Contact");

                    b.Property<string>("Email")
                        .HasMaxLength(1024);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.ToTable("Person");

                    b.HasDiscriminator().HasValue("Person");
                });

            modelBuilder.Entity("OpportunityData.Website", b =>
                {
                    b.HasBaseType("OpportunityData.Contact");

                    b.Property<string>("Uri")
                        .HasMaxLength(4096);

                    b.ToTable("Website");

                    b.HasDiscriminator().HasValue("Website");
                });

            modelBuilder.Entity("OpportunityData.Activity", b =>
                {
                    b.HasOne("OpportunityData.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("OpportunityData.Opportunity", "Opportunity")
                        .WithMany("Activities")
                        .HasForeignKey("OpportunityID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpportunityData.Contact", b =>
                {
                    b.HasOne("OpportunityData.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID");
                });

            modelBuilder.Entity("OpportunityData.Opportunity", b =>
                {
                    b.HasOne("OpportunityData.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OpportunityData.Contact", "PrimaryContact")
                        .WithMany()
                        .HasForeignKey("PrimaryContactId");
                });
#pragma warning restore 612, 618
        }
    }
}