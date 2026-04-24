using System;

namespace MiniBank;

public abstract class ContaBase : IConta
{
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Cliente Titular { get; }
    public DateTime DataAbertura{ get; init;} = DateTime.UtcNow;
    public Extrato Extrato {get;} = new Extrato();

    public event EventHandler<TransacaoEventArgs>? TransacaoRealizada;

    protected void OnTransacaoRealizada(Transacao transacao)
    {
        Extrato.Registrar(transacao);
        TransacaoRealizada?.Invoke(this, 
            new TransacaoEventArgs(transacao, this));
    }

    protected ContaBase(string numero, Cliente titular, decimal saldoInicial = 0)
    {
        Numero = numero;
        Titular = titular;
        if(saldoInicial < 0) 
            throw new ArgumentException("Saldo inicial não pode ser negativo");
        Saldo = saldoInicial;
        Extrato.Registrar(new Transacao(saldoInicial, 
            TipoTransacao.Deposito, "Abertura de conta"));
    }

    // Encapsulamento: deposito valida valor
    public void Depositar(decimal valor)
    {
        if (valor <= 0) return;
        Saldo += valor;
        OnTransacaoRealizada(new Transacao(valor, 
            TipoTransacao.Deposito, "Depósito"));
    }

    // Polimorfismo: cada tipo de conta define sua regra de saque
    public abstract bool Sacar(decimal valor);

    public virtual string ExibirExtrato()
    {
        Extrato.Imprimir();
        return $"Saldo atual: {Saldo:C}";
    }
}