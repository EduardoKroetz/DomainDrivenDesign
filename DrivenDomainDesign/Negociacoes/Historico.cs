using Domain.Funis;

namespace Domain.Negociacoes;

public class Historico
{
    public Historico(decimal? valorEstimado)
    {
        Id = Guid.NewGuid();
        ValorEstimado = valorEstimado;
        Etapa = null;
        Tipo = HistoricoTipo.ALTERACAO_VALOR_ESTIMADO;
        CriadoEm = DateTime.Now;
    }

    public Historico(Etapa? etapa)
    {
        Id = Guid.NewGuid();
        ValorEstimado = null;
        Etapa = etapa;
        Tipo = HistoricoTipo.TRANSICAO_ETAPA;
        CriadoEm = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public Etapa? Etapa { get; private set; }
    public decimal? ValorEstimado { get; private set; }
    public string Tipo { get; set; }
    public DateTime CriadoEm { get; private set; }
}

public static class HistoricoTipo
{
    public const string TRANSICAO_ETAPA = "TRANSICAO_ETAPA";
    public const string ALTERACAO_VALOR_ESTIMADO = "ALTERACAO_VALOR_ESTIMADO";
}