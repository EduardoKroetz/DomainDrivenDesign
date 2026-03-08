namespace Domain.Negociacoes;

public class Atividade
{
    public Atividade(string nome, string? descricao, DateTime? dataInicio, DateTime? dataTermino)
    {
        if (dataInicio.HasValue && dataTermino.HasValue && dataInicio > dataTermino)
            throw new Exception("A data de início não pode ser maior que a data de término");

        Id = Guid.NewGuid();    
        Nome = nome;
        DataInicio = dataInicio;
        DataTermino = dataTermino;
        Descricao = descricao;
        Status = AtividadeStatus.NOVA;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public DateTime? DataInicio { get; private set; }
    public DateTime? DataTermino { get; private set; }
    public string? Descricao { get; private set; }
    public string Status { get; private set; }
}

public static class AtividadeStatus
{
    public const string NOVA = "NOVA";
    public const string EM_PROGRESSO = "EM_PROGRESSO";
    public const string CONCLUIDA = "CONCLUIDA";
    public const string ABANDONADA = "ABANDONADA";
}