// Alunos: Matheus Marques Stefani | Alan de Oliveira Medeiros
using System;

namespace Biblioteca;

public class Livro
{
    private string _titulo;
    private string _autor;

    public string Isbn { get; init; } // Requisito: Imutável

    public string Titulo
    {
        get => _titulo;
        set => _titulo = !string.IsNullOrWhiteSpace(value) ? value.Trim() : throw new ArgumentException("Título inválido.");
    }

    public string Autor
    {
        get => _autor;
        set => _autor = !string.IsNullOrWhiteSpace(value) ? value.Trim() : throw new ArgumentException("Autor inválido.");
    }

    public Livro(string isbn, string titulo, string autor)
    {
        Isbn = isbn;
        Titulo = titulo;
        Autor = autor;
    }

    // MÉTODO: O livro sabe se descrever
    public string ObterResumo() => $"[ISBN: {Isbn}] {Titulo} - {Autor}";
}