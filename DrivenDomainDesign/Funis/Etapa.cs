namespace Domain.Funis;

public class Etapa
{
    public Etapa(string nome, int ordem, string? cor, ERegraTransicao? regraTransicao)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Ordem = ordem;
        Cor = cor;
        RegraTransicao = regraTransicao;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public int Ordem { get; private set; }
    public string? Cor { get; private set; }
    public ERegraTransicao? RegraTransicao { get; private set; }
}

public enum ERegraTransicao
{
    PROPOSTA_ENVIADA,
    POSSUIR_VALOR_ESTIMADO,
    POSSUIR_ATIVIDADE,   
}