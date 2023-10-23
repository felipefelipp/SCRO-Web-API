//using Microsoft.EntityFrameworkCore;
//using SCRO.Models.Paciente;
//using SCRO.Models.Paciente;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlTypes;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;

//namespace SCRO.SCRO.Models.Data
//{
//    public class PacienteDAO//: IPessoaDAO<Paciente>, IDisposable
//    {
//         SCROContext Context;

//        public PacienteDAO()
//        {
//            this.Context = new SCROContext();   
//        }
//        public void Adicionar(Paciente p)
//        {
//            try
//            {
//                Context.Paciente.Add(p);
//                Context.SaveChanges();
//            } catch (DbUpdateException ex) 
//            {
//                var innerException = ex.InnerException;
//                Console.WriteLine(innerException);
//            }
//        }

//        public void Atualizar(Paciente p)
//        {
//            Context.Update(p);
//            Context.SaveChanges();  
//        }

//        public IList<Paciente> BuscarPorCelular(long celular)
//        {
//            try
//            {
//                return Context.Paciente
//                               .Where(p => p.Celular == celular)
//                               .ToList();

//            }
//            catch (SqlNullValueException err)
//            {
//                Console.WriteLine(err.ToString());
//                Console.WriteLine("Paciente não encontrado");
//                return null;
//            }
//        }

//        public IList<Paciente> BuscarPorCpf(long cpf)
//        {
//            try
//            {
//                return Context.Paciente
//                               .Where(p => p.CPF == cpf)
//                               .ToList();
//            }
//            catch (SqlNullValueException err)
//            {
//                Console.WriteLine(err.ToString());
//                Console.WriteLine("Paciente não encontrado");
//                return null;
//            }
//        }

//        public IList<Paciente> BuscarPorEmail(string email)
//        {
//            try
//            {
//                return Context.Paciente
//                               .Where(p => p.Email.Contains(email))
//                               .ToList();

//            }
//            catch (SqlNullValueException err)
//            {
//                Console.WriteLine(err.ToString());
//                Console.WriteLine("Paciente não encontrado");
//                return null;
//            }
//        }

//        public IList<Paciente> BuscarPorIdade(int idade)
//        {
//            try
//            {
//                return Context.Paciente
//                               .Where(p => p.Idade == idade)
//                               .ToList();
//            }
//            catch (SqlNullValueException err)
//            {
//                Console.WriteLine(err.ToString());
//                Console.WriteLine("Paciente não encontrado");
//                return null;
//            }
//        }

//        public IList<Paciente> BuscarPorNome(string nome)
//        {
//            try
//            {
//                return Context.Paciente
//                               .Where(p => p.Nome.Contains(nome))
//                               .ToList();
//            }
//            catch (SqlNullValueException err)
//            {
//                Console.WriteLine(err.ToString());
//                Console.WriteLine("Paciente não encontrado");
//                return null;
//            }
//        }

//        public bool VerificaSeExisteCPF(long cpf)
//        {
//            return Context.Paciente.Any(paciente => paciente.CPF == cpf);
//        }

//        public void Dispose()
//        {
//            Context.Dispose();
//        }

//        public IList<Paciente> Obter(string nome, int idade, long cpf , long celular , string email)
//        { 
//            return Context.Paciente.Where(paciente => (paciente.Nome.Contains(nome)) ||
//                                                      (paciente.Idade == idade) ||
//                                                      (paciente.CPF == cpf) ||
//                                                      (paciente.Celular == celular) ||
//                                                      (paciente.Email.Contains(email))
//                                         ).ToList();
//        }


//        public IList<Paciente> ObterTodos()
//        {
//            return Context.Paciente.ToList();             
//        }


//        public void Remover(Paciente p)
//        {
//            Context.Paciente.Remove(p);
//            Context.SaveChanges();
//        }
//    }
//}
