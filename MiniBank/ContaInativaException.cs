using System;

namespace MiniBank;

public class ContaInativaException : Exception
{
    public ContaInativaException(string numeroConta):
        base($"Conta {numeroConta} está inativa.")
    {
        
    }
}