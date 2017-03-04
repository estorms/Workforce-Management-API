using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WorkforceManagement.Data;

namespace WorkforceManagement.Migrations
{
    [DbContext(typeof(WorkforceDbContext))]
    partial class WorkforceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorkforceManagement.Models.Computer", b =>
                {
                    b.Property<int>("ComputerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatePurchased");

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("SerialNumber");

                    b.HasKey("ComputerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("WorkforceManagement.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("WorkforceManagement.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("WorkforceManagement.Models.EmployeeTraining", b =>
                {
                    b.Property<int>("EmployeeTrainingId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<int>("TrainingId");

                    b.HasKey("EmployeeTrainingId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TrainingId");

                    b.ToTable("EmployeeTraining");
                });

            modelBuilder.Entity("WorkforceManagement.Models.Training", b =>
                {
                    b.Property<int>("TrainingId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Topic");

                    b.HasKey("TrainingId");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("WorkforceManagement.Models.Computer", b =>
                {
                    b.HasOne("WorkforceManagement.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("WorkforceManagement.Models.Employee", b =>
                {
                    b.HasOne("WorkforceManagement.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorkforceManagement.Models.EmployeeTraining", b =>
                {
                    b.HasOne("WorkforceManagement.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorkforceManagement.Models.Training", "Training")
                        .WithMany()
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
