using System;

namespace MiniBank;

public interface IDebitavel
{
    bool Sacar(decimal valor);
}
