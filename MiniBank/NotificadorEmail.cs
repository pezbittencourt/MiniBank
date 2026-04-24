namespace MiniBank;

public class NotificadorEmail
{
    public void OnTransacaoRealizada(Object sender, TransacaoEventArgs e)
    {
        Console.WriteLine($"[EMAIL] {e.Conta.Titular.Email}: "+ 
                          $"{e.Transacao.Tipo} de {e.Transacao.Valor}");
    }
}