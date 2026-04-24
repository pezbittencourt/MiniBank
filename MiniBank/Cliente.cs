using System;

namespace MiniBank;

public sealed class Cliente
{
    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public string Email { get; private set; }
    public TipoCliente Tipo {get; private set;}

    public Cliente(string nome, string cpf, string email, TipoCliente tipo)
    {
        if(string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome é obrigatório.");
        Nome = nome;
        Cpf = cpf;
        if(string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            throw new ArgumentException("Email inválido.");
        Email = email;
        Tipo = tipo;
    }

    public override string ToString() => $"{Nome} (CPF: {Cpf})";
}
