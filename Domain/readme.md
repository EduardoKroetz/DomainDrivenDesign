
## Leads
- Pode ser Empresa ou Pessoa
- O Lead possui uma origem (Formulário do Site, Indicação, Importação de Lista, Evento, Rede Social)
- O Lead só se torna um negociação quando o vendedor decide trabalhar sobre ele

## Funil de Vendas
- Representa o processo comercial da empresa
- Cada empresa pode ter vários funis
- Cada funil possui várias etapas

## Etapas do Funil
- Possui ordem
- Uma negociação sempre está em uma etapa
- Uma negociação pode avançar e retroceder nas etapas do fúnil
- Algumas etapas possuem regras especiais
	- Ex Etapa: Proposta enviada -> Deve existir uma proposta registrada
	- Ex2 Etapa: Negociação -> Deve existir uma valor

## Negociação
- Representa uma oportunidade real de venda
- Uma negociação:
	- pertence a um lead
	- pertence a um funil
	- está em uma etapa
	- possui valor estimado
	- possui responsável (vendedor)
	- Não pode pular etapas
	- Pode ser perdida (deve registrar motivo de perda)

## Atividades
- Vendedores registram atividades na negociação.

-----

Vendedores
	- NomeCompleto
Leads
	- Nome
	- Email
	- Telefone
	- Empresa
Funis
	- Nome
	- Etapas
		- Nome
		- Ordem
		- Cor
		- RegraTransicao (PROPOSTA_ENVIADA, POSSUIR_VALOR_ESTIMADO, POSSUIR_ATIVIDADE)
Negociacoes
	- Lead
	- EtapaAtual
	- ValorEstimado
	- Vendedor
	- MotivoPerda
	- HistoricosEtapas
		- Etapa
		- Descricao
		- DataCriacao
		- AlteradoPeloVendedor
	- Atividades
		- Nome
		- DataInicio
		- DataTermino
		- Descricao
		- Status (PENDENTE, CONCLUIDA, CANCELADA)
	- Propostas
		- Nome
		- Valor
		- Descrição
		- Status (NOVA, ENVIADA, REJEITADA, ACEITA)
		- PropostaRejeitada
			- Motivo
		- Anexos
			- Nome
			- Link