// <auto-generated />
using System;
using DETRAN.Persistence.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DETRAN.Persistence.Migrations
{
    [DbContext(typeof(DetranContext))]
    [Migration("20211009234240_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("DETRAN.Domain.Entities.Condutor", b =>
                {
                    b.Property<int>("CondutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNacimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroCnh")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CondutorId");

                    b.ToTable("Condutores");
                });

            modelBuilder.Entity("DETRAN.Domain.Entities.CondutorVeiculo", b =>
                {
                    b.Property<int>("CondutorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CondutorId", "VeiculoId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("CondutoresVeiculos");
                });

            modelBuilder.Entity("DETRAN.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("UsuarioAtivo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UsuarioDataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<string>("UsuarioEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("UsuarioNome")
                        .HasColumnType("TEXT");

                    b.Property<string>("UsuarioSenha")
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DETRAN.Domain.Entities.Veiculo", b =>
                {
                    b.Property<int>("VeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnoDeFabricacao")
                        .HasColumnType("TEXT");

                    b.Property<int>("CondutorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cor")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Marca")
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Placa")
                        .HasColumnType("TEXT");

                    b.HasKey("VeiculoId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("DETRAN.Domain.Entities.CondutorVeiculo", b =>
                {
                    b.HasOne("DETRAN.Domain.Entities.Condutor", "Condutor")
                        .WithMany("CondutorVeiculos")
                        .HasForeignKey("CondutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DETRAN.Domain.Entities.Veiculo", "Veiculo")
                        .WithMany("VeiculoCondures")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
