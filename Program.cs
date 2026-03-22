// Alunos: Matheus Marques Stefani | Alan de Oliveira Medeiros

using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    public class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public Livro(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
        }
    }

    public class Leitor
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public List<Livro> Livros { get; set; }

        public Leitor(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
            Livros = new List<Livro>();
        }

        public void AdicionarLivro(Livro novoLivro)
        {
            Livros.Add(novoLivro);
        }

        public void RemoverLivro(Livro livro)
        {
            Livros.Remove(livro);
        }
    }

    class Program
    {
        static void Main()
        {
            List<Leitor> leitores = new List<Leitor>();
            int opcao = -1;

            while (opcao != 0)
            {
                ExibirMenu();
                if (!int.TryParse(Console.ReadLine(), out opcao)) continue;

                if (opcao == 1) CadastrarLeitor(leitores);
                else if (opcao == 2) ListarLeitores(leitores);
                else if (opcao == 3) EditarLeitor(leitores);
                else if (opcao == 4) ExcluirLeitor(leitores);
                else if (opcao == 5) IncluirLivroLeitor(leitores);
                else if (opcao == 6) EditarLivroLeitor(leitores);
                else if (opcao == 7) RemoverLivroLeitor(leitores);
                else if (opcao == 8) DoarLivro(leitores);
                else if (opcao == 9) ListarTudo(leitores);
                else if (opcao == 10) ListarLivrosEspecifico(leitores);
                else if (opcao == 11) PesquisarLivroEspecifico(leitores);
            }
        }

        static void ExibirMenu()
        {
            Console.WriteLine("\n--- MENU BIBLIOTECA ---");
            Console.WriteLine("1 - Cadastrar leitor");
            Console.WriteLine("2 - Listar todos os leitores (apenas dados)");
            Console.WriteLine("3 - Editar leitor");
            Console.WriteLine("4 - Excluir leitor");
            Console.WriteLine("5 - Incluir livro para um leitor");
            Console.WriteLine("6 - Editar livro especifico do leitor");
            Console.WriteLine("7 - Remover livro de um leitor");
            Console.WriteLine("8 - Doar livro para outro leitor");
            Console.WriteLine("9 - Listar todos os leitores e seus respectivos livros");
            Console.WriteLine("10 - Listar um leitor especifico e seus respectivos livros");
            Console.WriteLine("11 - Pesquisar por um livro especifico");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opcao: ");
        }

        static void CadastrarLeitor(List<Leitor> leitores)
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine()!;

            if (leitores.Where(c => c.Cpf.Equals(cpf)).Any())
            {
                Console.WriteLine("Erro: CPF ja cadastrado no sistema.");
            }
            else
            {
                Console.Write("Digite o Nome do leitor: ");
                string nome = Console.ReadLine()!;
                leitores.Add(new Leitor(nome, cpf));
                Console.WriteLine("Leitor cadastrado com sucesso!");
            }
        }

        static void ListarLeitores(List<Leitor> leitores)
        {
            foreach (var leitor in leitores)
            {
                Console.WriteLine($"Nome: {leitor.Nome} | CPF: {leitor.Cpf}");
            }
        }

        static void EditarLeitor(List<Leitor> leitores)
        {
            Console.Write("Digite o CPF do leitor que deseja editar: ");
            string cpf = Console.ReadLine()!;
            
            var leitor = leitores.Where(c => c.Cpf.Equals(cpf)).FirstOrDefault();
            if (leitor != null)
            {
                Console.WriteLine($"-> Leitor encontrado: {leitor.Nome}");
                Console.Write("Digite o novo Nome: ");
                leitor.Nome = Console.ReadLine()!;
                Console.WriteLine("Dados atualizados.");
            }
            else Console.WriteLine("Leitor nao encontrado.");
        }

        static void ExcluirLeitor(List<Leitor> leitores)
        {
            Console.Write("Digite o CPF do leitor que deseja excluir: ");
            string cpf = Console.ReadLine()!;
            
            var leitor = leitores.Where(c => c.Cpf.Equals(cpf)).FirstOrDefault();
            if (leitor != null)
            {
                leitores.Remove(leitor);
                Console.WriteLine("Leitor excluido.");
            }
            else Console.WriteLine("Leitor nao encontrado.");
        }

        static void IncluirLivroLeitor(List<Leitor> leitores)
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine()!;
            
            var leitor = leitores.Where(c => c.Cpf.Equals(cpf)).FirstOrDefault();
            if (leitor != null)
            {
                Console.Write("Digite o Titulo do livro: ");
                string titulo = Console.ReadLine()!;
                Console.Write("Digite o Autor do livro: ");
                string autor = Console.ReadLine()!;
                
                leitor.AdicionarLivro(new Livro(titulo, autor));
                Console.WriteLine("Livro adicionado ao leitor.");
            }
            else Console.WriteLine("Leitor nao encontrado.");
        }

        static void EditarLivroLeitor(List<Leitor> leitores)
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine()!;
            
            var leitor = leitores.Where(c => c.Cpf.Equals(cpf)).FirstOrDefault();
            if (leitor != null)
            {
                Console.Write("Digite o Titulo atual do livro que deseja editar: ");
                string titulo = Console.ReadLine()!;
                
                var livro = leitor.Livros.Where(l => l.Titulo.Equals(titulo)).FirstOrDefault();
                if (livro != null)
                {
                    Console.Write("Digite o novo Titulo: ");
                    livro.Titulo = Console.ReadLine()!;
                    Console.Write("Digite o novo Autor: ");
                    livro.Autor = Console.ReadLine()!;
                    Console.WriteLine("Livro atualizado.");
                }
                else Console.WriteLine("Livro nao encontrado com este leitor.");
            }
            else Console.WriteLine("Leitor nao encontrado.");
        }

        static void RemoverLivroLeitor(List<Leitor> leitores)
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine()!;
            
            var leitor = leitores.Where(c => c.Cpf.Equals(cpf)).FirstOrDefault();
            if (leitor != null)
            {
                Console.Write("Digite o Titulo do livro que deseja remover: ");
                string titulo = Console.ReadLine()!;
                
                var livro = leitor.Livros.Where(l => l.Titulo.Equals(titulo)).FirstOrDefault();
                if (livro != null)
                {
                    leitor.RemoverLivro(livro);
                    Console.WriteLine("Livro removido.");
                }
                else Console.WriteLine("Livro nao encontrado.");
            }
            else Console.WriteLine("Leitor nao encontrado.");
        }

        static void DoarLivro(List<Leitor> leitores)
        {
            Console.Write("Digite o CPF do leitor DOADOR: ");
            string cpfDoador = Console.ReadLine()!;
            var doador = leitores.Where(c => c.Cpf.Equals(cpfDoador)).FirstOrDefault();

            Console.Write("Digite o CPF do leitor RECEBEDOR: ");
            string cpfRecebedor = Console.ReadLine()!;
            var recebedor = leitores.Where(c => c.Cpf.Equals(cpfRecebedor)).FirstOrDefault();

            if (doador != null && recebedor != null)
            {
                Console.Write("Digite o Titulo do livro a ser doado: ");
                string titulo = Console.ReadLine()!;
                
                var livro = doador.Livros.Where(l => l.Titulo.Equals(titulo)).FirstOrDefault();
                if (livro != null)
                {
                    doador.RemoverLivro(livro);
                    recebedor.AdicionarLivro(livro);
                    Console.WriteLine("Doacao realizada com sucesso.");
                }
                else Console.WriteLine("Livro nao encontrado com o doador.");
            }
            else Console.WriteLine("Doador ou Recebedor nao encontrado.");
        }

        static void ListarTudo(List<Leitor> leitores)
        {
            foreach (var leitor in leitores)
            {
                Console.WriteLine($"\n[Leitor: {leitor.Nome} | CPF: {leitor.Cpf}]");
                if (!leitor.Livros.Any()) Console.WriteLine("  Nenhum livro cadastrado.");
                
                foreach (var livro in leitor.Livros)
                {
                    Console.WriteLine($"  - Livro: {livro.Titulo} | Autor: {livro.Autor}");
                }
            }
        }

        static void ListarLivrosEspecifico(List<Leitor> leitores)
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine()!;
            
            var leitor = leitores.Where(c => c.Cpf.Equals(cpf)).FirstOrDefault();
            if (leitor != null)
            {
                Console.WriteLine($"\n[Livros de {leitor.Nome}]");
                if (!leitor.Livros.Any()) Console.WriteLine("  Nenhum livro cadastrado.");
                
                foreach (var livro in leitor.Livros)
                {
                    Console.WriteLine($"  - Titulo: {livro.Titulo} | Autor: {livro.Autor}");
                }
            }
            else Console.WriteLine("Leitor nao encontrado.");
        }

        static void PesquisarLivroEspecifico(List<Leitor> leitores)
        {
            Console.Write("Digite o Titulo do livro que deseja buscar: ");
            string tituloBusca = Console.ReadLine()!;

            var leitoresComLivro = leitores.Where(c => c.Livros.Where(l => l.Titulo.Equals(tituloBusca)).Any());

            if (leitoresComLivro.Any())
            {
                Console.WriteLine("\nEste livro pertence ao(s) seguinte(s) leitor(es):");
                foreach (var leitor in leitoresComLivro)
                {
                    Console.WriteLine($"Nome: {leitor.Nome} | CPF: {leitor.Cpf}");
                }
            }
            else Console.WriteLine("Nenhum leitor possui este livro.");
        }
    }
}