using System;

namespace MiniBank;

public class LogTransacao
{
    public void OnTransacaoRealizada(object? sender, 
        TransacaoEventArgs e)
    {
        Console.WriteLine($"[LOG] {e.Transacao}");
    }
}