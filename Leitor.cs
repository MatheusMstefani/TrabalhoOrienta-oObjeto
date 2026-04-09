// Alunos: Matheus Marques Stefani | Alan de Oliveira Medeiros
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca;

public class Leitor
{
    private string _nome;
    private string _cpf;

    public string Nome
    {
        get => _nome;
        set => _nome = !string.IsNullOrWhiteSpace(value) ? value.Trim() : throw new ArgumentException("Nome inválido.");
    }

    public string Cpf
    {
        get => _cpf;
        set => _cpf = !string.IsNullOrWhiteSpace(value) ? value.Trim() : throw new ArgumentException("CPF inválido.");
    }

    public List<Livro> Livros { get; private set; }

    public Leitor(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
        Livros = new List<Livro>();
    }

    // MÉTODO: O leitor gerencia sua doação
    public void DoarLivro(string titulo, Leitor receptor)
    {
        var livro = Livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
        if (livro == null) throw new Exception("Livro não encontrado com este leitor.");
        
        this.Livros.Remove(livro);
        receptor.Livros.Add(livro);
    }
}