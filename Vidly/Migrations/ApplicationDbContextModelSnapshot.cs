﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vidly.Models;

namespace Vidly.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vidly.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsSubscribedToNewsletter");

                    b.Property<byte>("MembershipTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Vidly.Models.MembershipType", b =>
                {
                    b.Property<byte>("Id");

                    b.Property<byte>("DiscountRate");

                    b.Property<byte>("DurationInMonth");

                    b.Property<string>("Name");

                    b.Property<short>("SignUpFee");

                    b.HasKey("Id");

                    b.ToTable("MembershipType");

                    b.HasData(
                        new { Id = (byte)1, DiscountRate = (byte)0, DurationInMonth = (byte)0, Name = "Pay as you go", SignUpFee = (short)0 },
                        new { Id = (byte)2, DiscountRate = (byte)10, DurationInMonth = (byte)1, Name = "Monthly", SignUpFee = (short)30 },
                        new { Id = (byte)3, DiscountRate = (byte)15, DurationInMonth = (byte)3, Name = "Quarterly", SignUpFee = (short)90 },
                        new { Id = (byte)4, DiscountRate = (byte)20, DurationInMonth = (byte)12, Name = "Yearly", SignUpFee = (short)300 }
                    );
                });

            modelBuilder.Entity("Vidly.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Vidly.Models.Customer", b =>
                {
                    b.HasOne("Vidly.Models.MembershipType", "MembershipType")
                        .WithMany()
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
