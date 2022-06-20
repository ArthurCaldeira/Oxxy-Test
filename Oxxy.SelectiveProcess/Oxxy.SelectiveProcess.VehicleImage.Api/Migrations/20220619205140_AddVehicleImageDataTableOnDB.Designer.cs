﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oxxy.SelectiveProcess.VehicleImage.Api.Model.Context;

#nullable disable

namespace Oxxy.SelectiveProcess.VehicleImage.Api.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20220619205140_AddVehicleImageDataTableOnDB")]
    partial class AddVehicleImageDataTableOnDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Oxxy.SelectiveProcess.VehicleImage.Api.Model.VehicleImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("image_data");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int")
                        .HasColumnName("vehicle_id");

                    b.HasKey("Id");

                    b.ToTable("VehicleImages");
                });
#pragma warning restore 612, 618
        }
    }
}
