using Domain.Funis;
using Domain.Leads;

namespace Domain.Negociacoes;

public class Negociacao
{
    public Negociacao(Lead lead, Funil funil)
    {
        Id = Guid.NewGuid();
        Lead = lead;
        Funil = funil;
        EtapaAtual = funil.PrimeiraEtapa();
    }

    public Guid Id { get; private set; }
    public Lead Lead { get; private set; }
    public Funil Funil { get; private set; }
    public Etapa EtapaAtual { get; private set; }
    public decimal? ValorEstimado { get; private set; }

    private readonly List<Proposta> _propostas = new();
    public IReadOnlyCollection<Proposta> Propostas => _propostas;

    private readonly List<Atividade> _atividades = new();
    public IReadOnlyCollection<Atividade> Atividades => _atividades;

    private readonly List<Historico> _historicos = new();
    public IReadOnlyCollection<Historico> Historicos => _historicos;

    public void AlterarValorEstimado(decimal novoValorEstimado)
    {
        _historicos.Add(new Historico(novoValorEstimado));

        ValorEstimado = novoValorEstimado;
    }

    public void Avancar()
    {
        if (EtapaAtual == Funil.EtapaPerda)
            throw new Exception("Essa negociação foi perdida e não pode mais avançar.");

        var proximaEtapa = Funil.Etapas.FirstOrDefault(e => e.Ordem == EtapaAtual.Ordem + 1);
        if (proximaEtapa is null)
            throw new Exception("O Funil não possui mais etapas.");

        ValidarRegrasTransicao(proximaEtapa);

        _historicos.Add(new Historico(proximaEtapa));

        EtapaAtual = proximaEtapa;
    }

    public void Perda()
    {
        if (Funil.EtapaPerda is null)
            throw new Exception("O Fúnil deve possuir uma etapa de perda configurada.");

        if (EtapaAtual == Funil.EtapaPerda)
            throw new Exception("Negociação já foi perdida.");

        ValidarRegrasTransicao(Funil.EtapaPerda);

        _historicos.Add(new Historico(Funil.EtapaPerda));

        EtapaAtual = Funil.EtapaPerda;
    }

    private void ValidarRegrasTransicao(Etapa etapa)
    {
        if (etapa.RegraTransicao is null)
            return;

        switch (etapa.RegraTransicao)
        {
            case ERegraTransicao.PROPOSTA_ENVIADA:
                if (!_propostas.Any(p => p.Status == PropostaStatus.ENVIADA))
                    throw new Exception("A negociação deve possuir uma proposta enviada para realizar a transição");
            break;
            case ERegraTransicao.POSSUIR_VALOR_ESTIMADO:
                if (ValorEstimado is null)
                    throw new Exception("A negociação deve possuir um valor estimado para realizar a transição");
            break;
            case ERegraTransicao.POSSUIR_ATIVIDADE:
                if (!_atividades.Any())
                    throw new Exception("A negociação deve possuir uma atividade pra realizar a transição");
            break;
        }
    }

    public Proposta CriarProposta(string nome, string descricao, decimal valor)
    {
        var proposta = new Proposta(nome, descricao, valor);

        _propostas.Add(proposta);

        return proposta;
    }

    public void AceitarProposta(Guid propostaId)
    {
        if (_propostas.Any(p => p.Status == PropostaStatus.ACEITA))
            throw new Exception("Já existe proposta aceita.");

        var proposta = _propostas.First(p => p.Id == propostaId);

        proposta.Aceitar();
    }

    public void EnviarProposta(Guid propostaId)
    {
        var proposta = _propostas.First(p => p.Id == propostaId);

        proposta.Enviar();
    }

    public void CriarAtividade(string nome, string? descricao, DateTime? dataInicio, DateTime? dataTermino)
    {
        var novaAtividade = new Atividade(nome, descricao, dataInicio, dataTermino);

        _atividades.Add(novaAtividade);
    }
}
