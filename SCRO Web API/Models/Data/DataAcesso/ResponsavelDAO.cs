//using Microsoft.EntityFrameworkCore;
//using SCRO.Models.Paciente;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlTypes;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SCRO.SCRO.Models.Data
//{
//    public class ResponsavelDAO //: IPessoaDAO<Responsavel>, IDisposable
//    {
//         SCROContext Context;

//        public ResponsavelDAO()
//        {
//            this.Context = new SCROContext();
//        }

//        public void Adicionar(Responsavel pessoa)
//        {
//            try
//            {
//                Context.Responsavel.Add(pessoa);
//                Context.SaveChanges();
//            }
//            catch (DbUpdateException ex)
//            {
//                var innerException = ex.InnerException;
//                Console.WriteLine(innerException);
//            }
//        }

//        public void Atualizar(Responsavel pessoa)
//        {
//            Context.Update(pessoa);
//            Context.SaveChanges();
//        }

//        public IList<Responsavel> BuscarPorCelular(long celular)
//        {
//            try
//            {
//                return Context.Responsavel
//                               .Where(r => r.Celular == celular)
//                               .ToList();

//            }
//            catch (SqlNullValueException err)
//            {
//                Console.WriteLine(err.ToString());
//                Console.WriteLine("Responsável não encontrado");
//                return null;
//            }
//        }

//        public IList<Responsavel> BuscarPorCpf(long cpf)
//        {
//            try
//            {
//                return Context.Responsavel
//                               .Where(r => r.CPF == cpf)
//                               .ToList();
//            }
//            catch (SqlNullValueException err)
//            {
//                Console.WriteLine(err.ToString());
//                Console.WriteLine("Responsável não encontrado");
//                return null;
//            }
//        }

//        public IList<Responsavel> BuscarPorEmail(string email)
//        {
//            try
//            {
//                return Context.Responsavel
//                               .Where(r => r.Email.Contains(email))
//                               .ToList();

//            }
//            catch (SqlNullValueException err)
//            {
//                Console.WriteLine(err.ToString());
//                Console.WriteLine("Responsável não encontrado");
//                return null;
//            }
//        }

//        public IList<Responsavel> BuscarPorIdade(int idade)
//        {
//            try
//            {
//                return Context.Responsavel
//                               .Where(r => r.Idade == idade)
//                               .ToList();
//            }
//            catch (SqlNullValueException err)
//            {
//                Console.WriteLine(err.ToString());
//                Console.WriteLine("Responsável não encontrado");
//                return null;
//            }
//        }

//        public IList<Responsavel> BuscarPorNome(string nome)
//        {
//            try
//            {
//                return Context.Responsavel
//                               .Where(r => r.Nome.Contains(nome))
//                               .ToList();
//            }
//            catch (SqlNullValueException err)
//            {
//                Console.WriteLine(err.ToString());
//                Console.WriteLine("Responsável não encontrado");
//                return null;
//            }
//        }

//        public bool VerificaSeExisteCPF(long cpf)
//        {
//            return Context.Responsavel.Any(responsavel => responsavel.CPF == cpf); 
//        }
//        public void Dispose()
//        {
//            Context.Dispose();
//        }

//        public IList<Responsavel> Obter(string nome, int idade, long cpf, long celular, string email)
//        {
//            return Context.Responsavel.Where(responsavel => (responsavel.Nome == nome) ||
//                                                             (responsavel.Idade == idade) ||
//                                                             (responsavel.CPF == cpf) ||
//                                                             (responsavel.Celular == celular) ||
//                                                             (responsavel.Email == email)
//                                            ).ToList();
//        }

//        public IList<Responsavel> ObterTodos()
//        {
//            return Context.Responsavel.ToList();
//        }

//        public void Remover(Responsavel pessoa)
//        {
//            Context.Responsavel.Remove(pessoa);
//            Context.SaveChanges();
//        }
//    }
//}
