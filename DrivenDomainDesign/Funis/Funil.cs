namespace Domain.Funis;

public class Funil
{
    public Funil(string nome, int maximoEtapas)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        MaximoEtapas = maximoEtapas;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public int MaximoEtapas { get; private set; }
    public Etapa? EtapaPerda { get; private set; }

    private readonly List<Etapa> _etapas = new();
    public IReadOnlyCollection<Etapa> Etapas => _etapas;

    public Etapa PrimeiraEtapa()
    {
        if (!_etapas.Any())
            throw new Exception("Funil não possui etapas.");

        return _etapas.First(e => e.Ordem == 1);
    }

    public Etapa AdicionarEtapa(string nome, string? cor, ERegraTransicao? regraTransicao = null, bool perda = false)
    {
        if (_etapas.Count >= MaximoEtapas)
            throw new Exception("O máximo de etapas do fúnil já foi atingido");

        if (_etapas.Any(e => e.Nome == nome))
            throw new Exception("Já existe um etapa com este nome");

        var ordem = _etapas.Any() ? _etapas.Max(e => e.Ordem) + 1 : 1;

        var novaEtapa = new Etapa(nome, ordem, cor, regraTransicao);

        _etapas.Add(novaEtapa);

        if (perda)
        {
            if (EtapaPerda != null)
                throw new Exception("Já existe etapa de perda");

            EtapaPerda = novaEtapa;
        }

        return novaEtapa;
    }
}
