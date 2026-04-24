namespace MiniBank;

public class Banco
{
    public string Nome { get; }
    private readonly List<Cliente> clientes = new();     // agregacao
    private readonly List<IConta> contas = new();        // agregacao
    private int proximoNumeroConta = 1;

    public Banco(string nome) { Nome = nome; }

    public void AdicionarCliente(Cliente cliente)
    {
        if (clientes.Any(c => c.Cpf == cliente.Cpf))
            throw new InvalidOperationException("Cliente ja cadastrado.");
        clientes.Add(cliente);  // recebe de fora, nao cria
    }

    public ContaCorrente AbrirContaCorrente(Cliente cliente, decimal saldoInicial = 0)
    {
        var conta = new ContaCorrente($"CC-{proximoNumeroConta++:D4}", cliente, saldoInicial);
        contas.Add(conta);
        return conta;
    }

    public ContaPoupanca AbrirContaPoupanca(Cliente cliente, decimal saldoInicial = 0)
    {
        var conta = new ContaPoupanca($"CP-{proximoNumeroConta++:D4}", cliente, saldoInicial);
        contas.Add(conta);
        return conta;
    }

    public IReadOnlyList<IConta> ListarContas() => contas;
}