using System;

namespace MiniBank;

public class SaldoInsuficienteException : Exception
{
    public decimal SaldoAtual {get;}
    public decimal ValorSolicitado {get;}

    public SaldoInsuficienteException(decimal saldo, decimal valor)
        : base($"Saldo {saldo:C} insuficiente para operação de {valor:C}")
    {
        ValorSolicitado = valor;
        SaldoAtual = saldo;
    }
}