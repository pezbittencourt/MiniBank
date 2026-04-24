// See https://aka.ms/new-console-template for more information
using MiniBank;


var banco = new Banco("MiniBank");

var ana = new Cliente("Ana Silva", "123.456.789-00", "ana@mail.com",TipoCliente.PessoaFisica);

banco.AdicionarCliente(ana);

var ccAna = banco.AbrirContaCorrente(ana, 5000m);
var cpAna = banco.AbrirContaPoupanca(ana, 2000m);

var log = new LogTransacao();
var emailNotificador = new NotificadorEmail();
//ccAna.TransacaoRealizada += log.OnTransacaoRealizada;
ccAna.TransacaoRealizada += emailNotificador.OnTransacaoRealizada;

ccAna.Depositar(500m);
ccAna.Depositar(300m);
ccAna.Depositar(100m);

try{
    ccAna.Sacar(2000m);
}
catch(SaldoInsuficienteException ex)
{
    Console.WriteLine($"Operação negada: {ex.Message}");
}
catch(ArgumentException ex)
{
    Console.WriteLine($"Dados de entrada inválidos: {ex.Message}");
}
finally
{
    Console.WriteLine("Operação finalizada");
}