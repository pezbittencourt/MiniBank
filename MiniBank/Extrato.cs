using System;

namespace MiniBank;

public class Extrato
{
    private readonly List<Transacao> _transacoes = [];
    public IReadOnlyList<Transacao> Transacoes => 
        _transacoes.AsReadOnly();
    
    public void Registrar(Transacao transacao) => 
        _transacoes.Add(transacao);

    public void Imprimir()
    {
        Console.WriteLine("===EXTRATO===");
        foreach(var transacao in _transacoes)
            Console.WriteLine(transacao);
        Console.WriteLine("=============");
    }
}
