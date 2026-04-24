using System;

namespace MiniBank;

public enum TipoTransacao{ Deposito=1, Saque=2, Transferencia=3}

public class Transacao
{    
    public decimal Valor {get; private set;}
    public DateTime Data {get; private init;} = DateTime.UtcNow;
    public TipoTransacao Tipo {get; private set;}
    public string Descricao {get; private set;}

    public Transacao(decimal valor, TipoTransacao tipo, 
        string descricao)
    {
        Valor = valor;
        Tipo = tipo;
        Descricao = descricao;
    }

    public override string ToString() => 
        $"[{Data:g}] {Tipo} - {Valor:C} | {Descricao}";
}
