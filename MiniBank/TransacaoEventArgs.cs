using System;

namespace MiniBank;

public class TransacaoEventArgs : EventArgs
{
    public Transacao Transacao {get;}
    public IConta Conta {get;}

    public TransacaoEventArgs(Transacao transacao, IConta conta)
    {
        Transacao = transacao;
        Conta = conta;
    }
}