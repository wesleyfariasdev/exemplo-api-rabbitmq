namespace ExemploRabbitMQ.Api.Data.Relatorio;

public static class RelatorioData
{
    public static List<SolicitacaoRelatorio> Relatorios { get; } = new List<SolicitacaoRelatorio>
    {
        new SolicitacaoRelatorio
        {
            Id = Guid.NewGuid(),
            Nome = "Relatório de Vendas",
            Status = Status.Pendente,
            DataProcessamento = null
        },
        new SolicitacaoRelatorio
        {
            Id = Guid.NewGuid(),
            Nome = "Relatório de Estoque",
            Status = Status.EmProcessamento,
            DataProcessamento = null
        }
    };
}

public class SolicitacaoRelatorio
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public Status Status { get; set; }
    public DateTime? DataProcessamento { get; set; }
}

public enum Status
{
    Pendente = 0,
    EmProcessamento = 1,
    Concluido = 2,
    Erro = 3
}