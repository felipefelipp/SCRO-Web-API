﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models.Data.Contexto;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    [DbContext(typeof(SCROContext))]
    partial class SCROContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Classificacao.CategoriaPergunta", b =>
                {
                    b.Property<int>("CategoriaPerguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoriaPerguntaId")
                        .HasDefaultValueSql("NEXT VALUE FOR CategoriaPerguntaSequence");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Descricao");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.HasKey("CategoriaPerguntaId");

                    b.ToTable("CategoriaPergunta", (string)null);
                });

            modelBuilder.Entity("Models.Classificacao.ClassificacaoPaciente", b =>
                {
                    b.Property<int>("ClassificacaoPacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClassificacaoPacienteId")
                        .HasDefaultValueSql("NEXT VALUE FOR ClassificacaoPacienteSequence");

                    b.Property<int>("AtendimentoPacienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int")
                        .HasColumnName("PacienteId");

                    b.HasKey("ClassificacaoPacienteId");

                    b.ToTable("ClassificacaoPaciente", (string)null);
                });

            modelBuilder.Entity("Models.Classificacao.Pergunta", b =>
                {
                    b.Property<int>("PerguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PerguntaId")
                        .HasDefaultValueSql("NEXT VALUE FOR PerguntaSequence");

                    b.Property<int?>("CategoriaPerguntaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<string>("TextoPergunta")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("DescricaoPergunta");

                    b.HasKey("PerguntaId");

                    b.HasIndex("CategoriaPerguntaId");

                    b.ToTable("Pergunta", (string)null);
                });

            modelBuilder.Entity("Models.Classificacao.PerguntaSelecionadaPaciente", b =>
                {
                    b.Property<int>("PerguntaSelecionadaPacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PerguntaSelecionadaPacienteId")
                        .HasDefaultValueSql("NEXT VALUE FOR PerguntaSelecionadaPacienteSequence");

                    b.Property<int>("ClassificacaoPacienteId")
                        .HasColumnType("int")
                        .HasColumnName("ClassificacaoPacienteId");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("PerguntaId")
                        .HasColumnType("int")
                        .HasColumnName("PerguntaId");

                    b.HasKey("PerguntaSelecionadaPacienteId");

                    b.ToTable("PerguntaSelecionadaPaciente", (string)null);
                });

            modelBuilder.Entity("Models.Classificacao.Resposta", b =>
                {
                    b.Property<int>("RespostaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RespostaId")
                        .HasDefaultValueSql("NEXT VALUE FOR RespostaSequence");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<string>("RespostaCheckBox")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("RespostaCheckBox");

                    b.Property<string>("RespostaComboBox")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("RespostaComboBox");

                    b.Property<DateTime?>("RespostaData")
                        .HasColumnType("Datetime")
                        .HasColumnName("RespostaData");

                    b.Property<string>("RespostaRadioButtom")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("RespostaRadioButtom");

                    b.Property<bool>("RespostaTexto")
                        .HasColumnType("bit")
                        .HasColumnName("RespostaTexto");

                    b.Property<bool>("RespostaTextoArea")
                        .HasColumnType("bit")
                        .HasColumnName("RespostaTextoArea");

                    b.Property<int>("ValorResposta")
                        .HasColumnType("int")
                        .HasColumnName("ValorResposta");

                    b.Property<int>("ValorTipoResposta")
                        .HasColumnType("int")
                        .HasColumnName("ValorTipoResposta");

                    b.HasKey("RespostaId");

                    b.ToTable("Resposta", (string)null);
                });

            modelBuilder.Entity("Models.Classificacao.RespostaSelecionadaPaciente", b =>
                {
                    b.Property<int>("RespostaSelecionadaPacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RespostaSelecionadaPacienteId")
                        .HasDefaultValueSql("NEXT VALUE FOR RespostaSelecionadaSequence");

                    b.Property<int>("ClassificacaoPacienteId")
                        .HasColumnType("int")
                        .HasColumnName("ClassificacaoPacienteId");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("PerguntaId")
                        .HasColumnType("int");

                    b.Property<int>("RespostaId")
                        .HasColumnType("int");

                    b.Property<string>("ValorRespostaTexto")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ValorRespostaTexto");

                    b.Property<string>("ValorRespostaTextoArea")
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ValorRespostaTextoArea");

                    b.HasKey("RespostaSelecionadaPacienteId");

                    b.ToTable("RespostaSelecionadaPaciente", (string)null);
                });

            modelBuilder.Entity("Models.Cliente.Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PacienteId")
                        .HasDefaultValueSql("NEXT VALUE FOR PacienteSequence");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("bairro");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("cep");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("cpf");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("celular");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("municipio");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<int>("Numero")
                        .HasColumnType("int")
                        .HasColumnName("numero");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("profissao");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("rg");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("rua");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("char(1)")
                        .HasColumnName("sexo");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("telefone");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("uf");

                    b.HasKey("PacienteId");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("Celular")
                        .IsUnique();

                    b.ToTable("Paciente", (string)null);
                });

            modelBuilder.Entity("Models.Cliente.Responsavel", b =>
                {
                    b.Property<int>("ResponsavelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ResponsavelId")
                        .HasDefaultValueSql("NEXT VALUE FOR ResponsavelSequence");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("cpf");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("celular");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("rg");

                    b.HasKey("ResponsavelId");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("Celular")
                        .IsUnique();

                    b.HasIndex("PacienteId");

                    b.ToTable("Responsavel", (string)null);
                });

            modelBuilder.Entity("Models.Funcionario.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UsuarioId")
                        .HasDefaultValueSql("NEXT VALUE FOR UsuarioSequence");

                    b.Property<string>("COREN")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("coren");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("cpf");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("crm");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("celular");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("rg");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("senha");

                    b.HasKey("UsuarioId");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("Celular")
                        .IsUnique();

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("SCRO_Web_API.Models.Atendimento.AtendimentoPaciente", b =>
                {
                    b.Property<int>("AtendimentoPacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AtendimentoPacienteId")
                        .HasDefaultValueSql("NEXT VALUE FOR AtendimentoSequence");

                    b.Property<DateTime>("DataAtendimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("SenhaClassificacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AtendimentoPacienteId");

                    b.ToTable("Atendimento", (string)null);
                });

            modelBuilder.Entity("SCRO_Web_API.Models.Classificacao.Resultado", b =>
                {
                    b.Property<int>("ResultadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR ResultadoSequence");

                    b.Property<int>("ClassificacaoPacienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("ResultadoClassificacaoCor")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ResultadoClassificacaoCor");

                    b.Property<int>("ResultadoCor")
                        .HasColumnType("int");

                    b.Property<int>("ValorResultadoClassificacao")
                        .HasColumnType("int");

                    b.HasKey("ResultadoId");

                    b.ToTable("Resultado", (string)null);
                });

            modelBuilder.Entity("Models.Classificacao.Pergunta", b =>
                {
                    b.HasOne("Models.Classificacao.CategoriaPergunta", "CategoriaPergunta")
                        .WithMany()
                        .HasForeignKey("CategoriaPerguntaId");

                    b.Navigation("CategoriaPergunta");
                });

            modelBuilder.Entity("Models.Cliente.Responsavel", b =>
                {
                    b.HasOne("Models.Cliente.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("SCRO_Web_API.Models.Atendimento.AtendimentoPaciente", b =>
                {
                    b.HasOne("Models.Classificacao.ClassificacaoPaciente", "ClassificacaoPaciente")
                        .WithOne("AtendimentoPaciente")
                        .HasForeignKey("SCRO_Web_API.Models.Atendimento.AtendimentoPaciente", "AtendimentoPacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassificacaoPaciente");
                });

            modelBuilder.Entity("Models.Classificacao.ClassificacaoPaciente", b =>
                {
                    b.Navigation("AtendimentoPaciente")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
