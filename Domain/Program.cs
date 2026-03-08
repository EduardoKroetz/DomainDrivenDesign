using Domain.Funis;
using DrivenDomainDesign.Funis;
using DrivenDomainDesign.Leads;
using DrivenDomainDesign.Negociacoes;

var funil = new Funil("Vendas InfoProdutos", 10);

var etapa_1 = funil.AdicionarEtapa("Novo Lead", "#fcba03");
var etapa_2 = funil.AdicionarEtapa("Contato Inicial", "#fc7f03", ERegraTransicao.POSSUIR_ATIVIDADE);
var etapa_3 = funil.AdicionarEtapa("Diagnóstico", "#f4fc03", ERegraTransicao.POSSUIR_VALOR_ESTIMADO);
var etapa_4 = funil.AdicionarEtapa("Proposta Enviada", "#03a5fc", ERegraTransicao.PROPOSTA_ENVIADA);
var etapa_5 = funil.AdicionarEtapa("Negociação", "#2803fc");
var etapa_6 = funil.AdicionarEtapa("Fechado", "#03fc3d");
var etapa_7 = funil.AdicionarEtapa("Perdido", "#fc0303", null, perda: true);

var lead = new Lead(
    nome: "Pedro Costa", 
    email: "pedrocosta@gmail.com", 
    telefone: "55998312343", 
    empresa: null
);

var negociacao = new Negociacao(lead, funil);

negociacao.CriarAtividade(
    nome: "Ligar para Lead", 
    descricao: "Ligar para o Pedro", 
    dataInicio: DateTime.Now, 
    dataTermino: DateTime.Now.AddDays(1)
);

negociacao.Avancar();

negociacao.AlterarValorEstimado(500.30m);

negociacao.Avancar();

var proposta = negociacao.CriarProposta("Curso Marketing Digital", "Essa proposta tem como base fornecer...", 400m);
negociacao.EnviarProposta(proposta.Id);

negociacao.Perda();
