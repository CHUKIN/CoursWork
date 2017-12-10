﻿// <auto-generated />
using CoursWork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CoursWork.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoursWork.Models.Competences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Norm");

                    b.Property<int?>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Competences");
                });

            modelBuilder.Entity("CoursWork.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Dicription");

                    b.Property<string>("Name");

                    b.Property<string>("PhotoUrl");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CoursWork.Models.Departament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Departaments");
                });

            modelBuilder.Entity("CoursWork.Models.KpiResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Result");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("KpiResults");
                });

            modelBuilder.Entity("CoursWork.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourceId");

                    b.Property<string>("Discription");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CourceId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("CoursWork.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DepartamentId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("CoursWork.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CoursWork.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ModuleId");

                    b.Property<string>("Name");

                    b.Property<string>("Question");

                    b.Property<int>("StepNumber");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("CoursWork.Models.TestResults", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Correct");

                    b.Property<int?>("TestId");

                    b.Property<string>("Variant");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("TestResulties");
                });

            modelBuilder.Entity("CoursWork.Models.Theory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ModuleId");

                    b.Property<string>("Name");

                    b.Property<int>("StepNumber");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Theories");
                });

            modelBuilder.Entity("CoursWork.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Gender");

                    b.Property<string>("Login");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Patroyomic");

                    b.Property<int?>("PositionId");

                    b.Property<int?>("RoleId");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CoursWork.Models.UserCourse", b =>
                {
                    b.Property<int>("IdUser");

                    b.Property<int>("IdCouse");

                    b.Property<bool>("Appointment");

                    b.Property<int?>("CourseId");

                    b.Property<bool>("Finished");

                    b.Property<decimal>("ResultPercent");

                    b.Property<int?>("UserId");

                    b.HasKey("IdUser", "IdCouse");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCourses");
                });

            modelBuilder.Entity("CoursWork.Models.UserTestResults", b =>
                {
                    b.Property<int>("IdUser");

                    b.Property<int>("IdTestResults");

                    b.Property<int>("IdTest");

                    b.Property<bool>("Finished");

                    b.Property<int?>("TestId");

                    b.Property<int?>("TestResultsId");

                    b.Property<int?>("UserId");

                    b.HasKey("IdUser", "IdTestResults", "IdTest");

                    b.HasIndex("TestId");

                    b.HasIndex("TestResultsId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTestResulties");
                });

            modelBuilder.Entity("CoursWork.Models.UserTheory", b =>
                {
                    b.Property<int>("IdUser");

                    b.Property<int>("IdTheory");

                    b.Property<bool>("Finished");

                    b.Property<int?>("TheoryId");

                    b.Property<int?>("UserId");

                    b.HasKey("IdUser", "IdTheory");

                    b.HasIndex("TheoryId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTheory");
                });

            modelBuilder.Entity("CoursWork.Models.Competences", b =>
                {
                    b.HasOne("CoursWork.Models.Position", "Position")
                        .WithMany("Competences")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("CoursWork.Models.KpiResult", b =>
                {
                    b.HasOne("CoursWork.Models.User", "User")
                        .WithMany("KpiResults")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CoursWork.Models.Module", b =>
                {
                    b.HasOne("CoursWork.Models.Course", "Cource")
                        .WithMany("Modules")
                        .HasForeignKey("CourceId");
                });

            modelBuilder.Entity("CoursWork.Models.Position", b =>
                {
                    b.HasOne("CoursWork.Models.Departament", "Departament")
                        .WithMany("Positions")
                        .HasForeignKey("DepartamentId");
                });

            modelBuilder.Entity("CoursWork.Models.Test", b =>
                {
                    b.HasOne("CoursWork.Models.Module", "Module")
                        .WithMany("Tests")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("CoursWork.Models.TestResults", b =>
                {
                    b.HasOne("CoursWork.Models.Test", "Test")
                        .WithMany("TestResulties")
                        .HasForeignKey("TestId");
                });

            modelBuilder.Entity("CoursWork.Models.Theory", b =>
                {
                    b.HasOne("CoursWork.Models.Module")
                        .WithMany("Theories")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("CoursWork.Models.User", b =>
                {
                    b.HasOne("CoursWork.Models.Position", "Position")
                        .WithMany("Users")
                        .HasForeignKey("PositionId");

                    b.HasOne("CoursWork.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("CoursWork.Models.UserCourse", b =>
                {
                    b.HasOne("CoursWork.Models.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseId");

                    b.HasOne("CoursWork.Models.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CoursWork.Models.UserTestResults", b =>
                {
                    b.HasOne("CoursWork.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId");

                    b.HasOne("CoursWork.Models.TestResults", "TestResults")
                        .WithMany("UserTestResulties")
                        .HasForeignKey("TestResultsId");

                    b.HasOne("CoursWork.Models.User", "User")
                        .WithMany("UserTestResulties")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CoursWork.Models.UserTheory", b =>
                {
                    b.HasOne("CoursWork.Models.Theory", "Theory")
                        .WithMany("UserTheorys")
                        .HasForeignKey("TheoryId");

                    b.HasOne("CoursWork.Models.User", "User")
                        .WithMany("UserTheorys")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
