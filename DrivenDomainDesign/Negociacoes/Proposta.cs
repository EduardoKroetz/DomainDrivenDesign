namespace Domain.Negociacoes;

public class Proposta
{
    public Proposta(string nome, string descricao, decimal valor)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Status = PropostaStatus.NOVA;
        Anexos = new();
        CriadaEm = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Valor { get; private set; }
	public string? Descricao { get; private set; }
    public string Status { get; private set; }
	public string? MotivoRejeicao { get; private set; }
    public List<string> Anexos { get; private set; }
    public DateTime CriadaEm { get; set; }

    public void Aceitar()
    {
        if (Status == PropostaStatus.NOVA)
            throw new Exception("A proposta só pode ser aceita após ter sido enviada.");

        if (Status == PropostaStatus.REJEITADA)
            throw new Exception("Uma proposta rejeitada não pode ser aceita.");

        Status = PropostaStatus.ACEITA;
    }

    public void Enviar()
    {
        if (Status != PropostaStatus.NOVA)
            throw new Exception("Somente novas propostas podem ser enviadas.");

        Status = PropostaStatus.ENVIADA;
    }
}

public static class PropostaStatus
{
    public static string NOVA => "NOVA";
    public static string ENVIADA => "ENVIADA";
    public static string ACEITA => "ACEITA";
    public static string REJEITADA => "REJEITADA";
}

