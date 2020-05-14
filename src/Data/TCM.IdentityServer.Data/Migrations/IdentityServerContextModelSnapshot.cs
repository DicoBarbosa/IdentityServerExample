﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCM.IdentityServer.Data;

namespace TCM.IdentityServer.Data.Migrations
{
    [DbContext(typeof(IdentityServerContext))]
    partial class IdentityServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TCM.IdentityServer.Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("IsCNPJVerified")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCPFVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("SecurityCode")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("SecurityCodeExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Subject")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2715f962-dec3-46a3-95a1-d50a2ffc4e1e"),
                            Active = true,
                            ConcurrencyStamp = "1a9eccbb-3580-4d93-99f7-504357e49b94",
                            IsCNPJVerified = false,
                            IsCPFVerified = false,
                            Password = "admin",
                            SecurityCodeExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "1204d34f-3590-4a96-ade5-678a2108e9e4",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("67b855a3-f30f-4023-bb51-ab14c5b48811"),
                            Active = true,
                            ConcurrencyStamp = "eb652fe7-756b-49ba-a0a6-fca50bf042ea",
                            IsCNPJVerified = false,
                            IsCPFVerified = false,
                            Password = "testuser",
                            SecurityCodeExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "484ae583-5188-421f-8ea4-68c5f8287b85",
                            UserName = "testuser"
                        });
                });

            modelBuilder.Entity("TCM.IdentityServer.Core.Domain.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Claims");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e100411f-32d3-44f3-a165-6b1d803e7493"),
                            ConcurrencyStamp = "84042d62-5799-4b8a-b1c4-1882b4a588d3",
                            Type = "roles",
                            UserId = new Guid("2715f962-dec3-46a3-95a1-d50a2ffc4e1e"),
                            Value = "global_admin"
                        },
                        new
                        {
                            Id = new Guid("09f86a0d-1942-4de1-98d6-8eac2e7c21fe"),
                            ConcurrencyStamp = "3e7148d4-6b6e-48f9-b3e4-1404ea94f573",
                            Type = "given_name",
                            UserId = new Guid("2715f962-dec3-46a3-95a1-d50a2ffc4e1e"),
                            Value = "Administrador"
                        },
                        new
                        {
                            Id = new Guid("619c957d-d8c8-4ed1-9dc8-f9ae665e2706"),
                            ConcurrencyStamp = "d7675e3b-ca12-4e53-b208-dd74c90b52fb",
                            Type = "roles",
                            UserId = new Guid("67b855a3-f30f-4023-bb51-ab14c5b48811"),
                            Value = "general_user"
                        },
                        new
                        {
                            Id = new Guid("d4640432-41ed-4621-a38c-b15bea21f0ab"),
                            ConcurrencyStamp = "75432bfa-02a1-449a-a607-a318100d72ca",
                            Type = "given_name",
                            UserId = new Guid("67b855a3-f30f-4023-bb51-ab14c5b48811"),
                            Value = "Test User"
                        });
                });

            modelBuilder.Entity("TCM.IdentityServer.Core.Domain.UserLogin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ProviderIdentityKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("TCM.IdentityServer.Core.Domain.UserSecret", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Secrets");
                });

            modelBuilder.Entity("TCM.IdentityServer.Core.Domain.UserClaim", b =>
                {
                    b.HasOne("TCM.IdentityServer.Core.Domain.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCM.IdentityServer.Core.Domain.UserLogin", b =>
                {
                    b.HasOne("TCM.IdentityServer.Core.Domain.User", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCM.IdentityServer.Core.Domain.UserSecret", b =>
                {
                    b.HasOne("TCM.IdentityServer.Core.Domain.User", "User")
                        .WithMany("Secrets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
