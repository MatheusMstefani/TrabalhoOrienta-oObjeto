// Alunos: Matheus Marques Stefani | Alan de Oliveira Medeiros
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca;

class Program
{
    static void Main()
    {
        List<Leitor> leitores = new List<Leitor>();
        int opcao = -1;

        while (opcao != 0)
        {
            try
            {
                Console.WriteLine("\n--- SISTEMA BIBLIOTECA UNIPLAC ---");
                Console.WriteLine("1-Novo Leitor | 2-Add Livro | 3-Doar | 4-Pesquisar | 5-Listar | 0-Sair");
                Console.Write("Escolha: ");
                if (!int.TryParse(Console.ReadLine(), out opcao)) continue;

                switch (opcao)
                {
                    case 1:
                        Console.Write("Nome: "); string n = Console.ReadLine();
                        Console.Write("CPF: "); string c = Console.ReadLine();
                        leitores.Add(new Leitor(n, c));
                        break;
                    case 2:
                        Console.Write("CPF: "); string cpfB = Console.ReadLine();
                        var le = leitores.FirstOrDefault(x => x.Cpf == cpfB) ?? throw new Exception("Leitor não existe.");
                        Console.Write("ISBN: "); string isbn = Console.ReadLine();
                        Console.Write("Título: "); string t = Console.ReadLine();
                        Console.Write("Autor: "); string a = Console.ReadLine();
                        le.Livros.Add(new Livro(isbn, t, a));
                        break;
                    case 3:
                        Console.Write("CPF Doador: "); var d = leitores.FirstOrDefault(x => x.Cpf == Console.ReadLine());
                        Console.Write("CPF Receptor: "); var r = leitores.FirstOrDefault(x => x.Cpf == Console.ReadLine());
                        Console.Write("Título: "); string tit = Console.ReadLine();
                        d?.DoarLivro(tit, r!);
                        Console.WriteLine("Doação feita!");
                        break;
                    case 5:
                        leitores.ForEach(l => {
                            Console.WriteLine($"\nLeitor: {l.Nome}");
                            l.Livros.ForEach(liv => Console.WriteLine($" - {liv.ObterResumo()}"));
                        });
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine($"\n[ERRO]: {ex.Message}"); }
        }
    }
}