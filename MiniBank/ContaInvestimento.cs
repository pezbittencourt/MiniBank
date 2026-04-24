using System;

namespace MiniBank;

public sealed class ContaInvestimento : ContaBase
{
    public decimal TaxaDeSaque {get; init;} = 0.02m; // 2% de taxa para saques

    public ContaInvestimento(string numero, Cliente titular, decimal saldoInicial = 0)
    : base(numero, titular, saldoInicial){}

    public override bool Sacar(decimal valor)
    {
        if(valor <= 0) return false;
        decimal valorComTaxa = valor * (1+TaxaDeSaque);
        if(valorComTaxa > Saldo) return false;
        Saldo -= valorComTaxa;
        Extrato.Registrar(new Transacao(valor, TipoTransacao.Saque, "Saque"));
        return true; 
    }
}
