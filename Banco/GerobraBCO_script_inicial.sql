use GerobraBCO

CREATE TABLE acao
(
	id_acao               int  NOT NULL ,
	nome                  varchar(200)  NULL 
)
go

ALTER TABLE acao
	ADD  PRIMARY KEY (id_acao  ASC)
go

CREATE TABLE tab_backup
(
	id_tab_backup         int IDENTITY(1,1) NOT NULL,
	nome_arquivo          varchar(200)  NULL ,
	dta_backup            datetime  NULL ,
	id_usuario            int  NULL ,
	sin_ativo             bit  NULL ,
	id_tipo_backup        int  NULL 
)
go

ALTER TABLE tab_backup
	ADD  PRIMARY KEY (id_tab_backup  ASC)
go

CREATE TABLE banco
(
	id_banco              int IDENTITY(1,1) NOT NULL,
	numero                varchar(4)  NULL ,
	nome                  varchar(16)  NULL 
)
go

ALTER TABLE banco
	ADD  PRIMARY KEY (id_banco  ASC)
go

CREATE TABLE caixa
(
	id_caixa              int IDENTITY(1,1) NOT NULL,
	dta_movimento         datetime  NULL ,
	tipo_movimento        char(1)  NULL ,
	valor                 numeric(10,2)  NULL ,
	id_documento_fiscal   int  NULL ,
	id_usuario            int  NULL ,
	id_obra               int  NULL 
)
go

ALTER TABLE caixa
	ADD  PRIMARY KEY (id_caixa  ASC)
go

CREATE TABLE cargo
(
	id_cargo              int IDENTITY(1,1) NOT NULL,
	nome                  varchar(100)  NOT NULL ,
	carga_horaria         int  NOT NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE cargo
	ADD  PRIMARY KEY (id_cargo  ASC)
go

CREATE TABLE centro_custo
(
	id_centro_custo       int IDENTITY(1,1) NOT NULL,
	codigo                varchar(10)  NULL ,
	descricao             varchar(200)  NULL ,
	ativo                 bit  NULL ,
	sintetico             bit  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE centro_custo
	ADD  PRIMARY KEY (id_centro_custo  ASC)
go

CREATE TABLE cidade
(
	id_cidade             int IDENTITY(1,1) NOT NULL,
	nome                  varchar(100)  NOT NULL ,
	sin_vara_federal      char(1)  NOT NULL ,
	codigo_ibge           int  NULL ,
	id_orgao              int  NULL ,
	observacao            varchar(MAX)  NULL ,
	uf                    char(2)  NULL ,
	id_uf                 int  NULL 
)
go

ALTER TABLE cidade
	ADD  PRIMARY KEY (id_cidade  ASC)
go

CREATE TABLE cliente
(
	id_cliente            int IDENTITY(1,1) NOT NULL,
	id_tipo_cliente       int  NULL ,
	id_pessoa             int  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE cliente
	ADD  PRIMARY KEY (id_cliente  ASC)
go

CREATE TABLE conta_bancaria
(
	id_conta_bancaria     int IDENTITY(1,1) NOT NULL,
	agencia               varchar(5)  NULL ,
	conta                 varchar(14)  NULL ,
	id_banco              int  NULL ,
	id_pessoa             int  NULL 
)
go

ALTER TABLE conta_bancaria
	ADD  PRIMARY KEY (id_conta_bancaria  ASC)
go

CREATE TABLE cor_raca
(
	id_cor_raca           int IDENTITY(1,1) NOT NULL,
	descricao             varchar(50)  NOT NULL 
)
go

ALTER TABLE cor_raca
	ADD  PRIMARY KEY (id_cor_raca  ASC)
go

CREATE TABLE custo
(
	id_custo              int IDENTITY(1,1) NOT NULL,
	id_obra               int  NULL ,
	id_centro_custo       int  NULL ,
	quantidade            integer  NULL ,
	id_rel_material_fornecedor  int  NULL ,
	id_rel_servico_fornecedor  int  NULL ,
	id_documento_fiscal   int  NULL ,
	id_usuario            int  NULL 
)
go

ALTER TABLE custo
	ADD  PRIMARY KEY (id_custo  ASC)
go

CREATE TABLE diario_obra
(
	id_diario_obra        int IDENTITY(1,1) NOT NULL,
	descricao             varchar(max)  NULL ,
	dta_diario            datetime  NULL ,
	id_obra               int  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE diario_obra
	ADD  PRIMARY KEY (id_diario_obra  ASC)
go

CREATE TABLE documento
(
	id_documento          int IDENTITY(1,1) NOT NULL,
	id_obra               int  NULL ,
	id_tipo_documento     int  NULL ,
	numero                varchar(10)  NULL ,
	dta_documento         datetime  NULL ,
	sin_ativo             bit  NULL ,
	endereco_arquivo      varchar(200)  NULL ,
	extensao_arquivo      varchar(200)  NULL ,
	nome_arquivo          varchar(200)  NULL 
)
go

ALTER TABLE documento
	ADD  PRIMARY KEY (id_documento  ASC)
go

CREATE TABLE documento_fiscal
(
	id_documento_fiscal   int IDENTITY(1,1) NOT NULL,
	descricao             varchar(200)  NULL ,
	numero                varchar(20)  NULL ,
	serie                 varchar(10)  NULL ,
	dta_doc_fiscal        datetime  NULL ,
	id_tipo_documento_fiscal  int  NULL 
)
go

ALTER TABLE documento_fiscal
	ADD  PRIMARY KEY (id_documento_fiscal  ASC)
go

CREATE TABLE endereco
(
	id_endereco           int IDENTITY(1,1) NOT NULL,
	logradouro            varchar(max)  NULL ,
	complemento           varchar(100)  NULL ,
	numero                varchar(10)  NULL ,
	bairro                varchar(100)  NULL ,
	id_cidade             int  NULL ,
	id_pessoa             int  NULL ,
	cep                   varchar(8)  NULL 
)
go

ALTER TABLE endereco
	ADD  PRIMARY KEY (id_endereco  ASC)
go

CREATE TABLE estado_civil
(
	id_estado_civil       int IDENTITY(1,1) NOT NULL,
	descricao             varchar(50)  NULL 
)
go

ALTER TABLE estado_civil
	ADD  PRIMARY KEY (id_estado_civil  ASC)
go

CREATE TABLE fornecedor
(
	id_fornecedor         int IDENTITY(1,1) NOT NULL,
	id_tipo_fornecedor    int  NULL ,
	id_pessoa             int  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE fornecedor
	ADD  PRIMARY KEY (id_fornecedor  ASC)
go

CREATE TABLE funcionario
(
	id_funcionario        int IDENTITY(1,1) NOT NULL,
	id_tipo_funcionario   int  NULL ,
	id_pessoa             int  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE funcionario
	ADD  PRIMARY KEY (id_funcionario  ASC)
go

CREATE TABLE grau_instrucao
(
	id_grau_instrucao     int IDENTITY(1,1) NOT NULL,
	descricao             varchar(30)  NOT NULL ,
	ordem                 int  NULL ,
	id_tipo_curso         int  NULL 
)
go

ALTER TABLE grau_instrucao
	ADD  PRIMARY KEY (id_grau_instrucao  ASC)
go

CREATE TABLE grupo
(
	id_grupo              int IDENTITY(1,1) NOT NULL,
	nome                  varchar(200)  NULL 
)
go

ALTER TABLE grupo
	ADD  PRIMARY KEY (id_grupo  ASC)
go

CREATE TABLE historico_cliente
(
	id_historico_cliente  int IDENTITY(1,1) NOT NULL,
	descricao             varchar(max)  NULL ,
	dta_historico         datetime  NULL ,
	sin_ativo             bit  NULL ,
	id_cliente            int  NULL 
)
go

ALTER TABLE historico_cliente
	ADD  PRIMARY KEY (id_historico_cliente  ASC)
go

CREATE TABLE log
(
	id_log                int IDENTITY(1,1) NOT NULL,
	dta_log               int  NULL ,
	banco_dados           varchar(200)  NULL ,
	entidade              varchar(200)  NULL ,
	id_entidade           integer  NULL ,
	id_usuario            int  NULL ,
	id_acao               int  NULL 
)
go

ALTER TABLE log
	ADD  PRIMARY KEY (id_log  ASC)
go

CREATE TABLE material
(
	id_material           int IDENTITY(1,1) NOT NULL,
	id_tipo_material      int  NULL ,
	nome                  varchar(200)  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE material
	ADD  PRIMARY KEY (id_material  ASC)
go

CREATE TABLE migracao
(
	id_migracao           int IDENTITY(1,1) NOT NULL,
	dta_migracao          datetime  NULL ,
	entidade_origem       varchar(200)  NULL ,
	entidade_destino      varchar(200)  NULL ,
	id_funcionario        int  NULL ,
	sin_ativo             bit  NULL ,
	id_usuario            int  NULL 
)
go

ALTER TABLE migracao
	ADD  PRIMARY KEY (id_migracao  ASC)
go

CREATE TABLE modulo
(
	id_modulo             int IDENTITY(1,1) NOT NULL,
	nome                  varchar(200)  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE modulo
	ADD  PRIMARY KEY (id_modulo  ASC)
go

CREATE TABLE nacionalidade
(
	id_nacionalidade      int IDENTITY(1,1) NOT NULL,
	descricao             varchar(50)  NULL 
)
go

ALTER TABLE nacionalidade
	ADD  PRIMARY KEY (id_nacionalidade  ASC)
go

CREATE TABLE obra
(
	id_obra               int IDENTITY(1,1) NOT NULL,
	cod_obra              varchar(10)  NULL ,
	descricao             varchar(200)  NULL ,
	dta_inicio            datetime  NULL ,
	dta_fim               datetime  NULL ,
	dta_previsao_inicio   datetime  NULL ,
	dta_previsao_fim      datetime  NULL ,
	orcamento_previsao    numeric(10,2)  NULL ,
	orcamento_total       int  NULL ,
	id_endereco           int  NULL ,
	id_status_obra        int  NULL ,
	id_tipo_obra          int  NULL ,
	sin_ativo             bit  NULL ,
	_default_             int  NULL 
)
go

ALTER TABLE obra
	ADD  PRIMARY KEY (id_obra  ASC)
go

CREATE TABLE pais
(
	id_pais               int IDENTITY(1,1) NOT NULL,
	nome                  varchar(200)  NULL 
)
go

ALTER TABLE pais
	ADD  PRIMARY KEY (id_pais  ASC)
go

CREATE TABLE permissao
(
	id_permissao          int IDENTITY(1,1) NOT NULL,
	listar                bit  NULL ,
	editar                bit  NULL ,
	criar                 integer  NULL ,
	excluir               bit  NULL ,
	visualizar            bit  NULL ,
	id_modulo             int  NULL ,
	id_grupo              int  NULL 
)
go

ALTER TABLE permissao
	ADD  PRIMARY KEY (id_permissao  ASC)
go

CREATE TABLE pessoa
(
	id_pessoa             int IDENTITY(1,1) NOT NULL,
	nome                  varchar(100)  NOT NULL ,
	nome_juridico         varchar(200)  NULL ,
	nome_fantasia         varchar(200)  NULL ,
	cnpj                  varchar(14)  NULL ,
	inscricao_estadual    varchar(14)  NULL ,
	sexo                  char(1)  NULL ,
	dta_nascimento        datetime  NULL ,
	ano_chegada           integer  NULL ,
	naturalidade          varchar(30)  NULL ,
	id_estado_civil       integer  NULL ,
	nome_conjuge          varchar(100)  NULL ,
	nome_pai              varchar(100)  NULL ,
	nome_mae              varchar(100)  NULL ,
	id_tipo_sanguineo     int  NULL ,
	id_grau_instrucao     int  NULL ,
	registro_conselho_profissional  varchar(10)  NULL ,
	rg                    varchar(20)  NULL ,
	orgao_expedidor_rg    varchar(10)  NULL ,
	dta_expedicao_rg      datetime  NULL ,
	cpf                   varchar(14)  NULL ,
	pis_pasep             varchar(14)  NULL ,
	titulo_eleitor        varchar(15)  NULL ,
	zona_eleitoral        varchar(4)  NULL ,
	secao_eleitoral       varchar(4)  NULL ,
	dta_ultima_votacao    datetime  NULL ,
	dta_emissao_titulo    datetime  NULL ,
	cidade_titulo         varchar(30)  NULL ,
	certificado_reservista  varchar(12)  NULL ,
	categoria_militar     varchar(4)  NULL ,
	regiao_militar        varchar(4)  NULL ,
	registro_cnh          varchar(50)  NULL ,
	categoria_cnh         varchar(4)  NULL ,
	dta_primeira_cnh      datetime  NULL ,
	dta_emissao_cnh       datetime  NULL ,
	dta_validade_cnh      datetime  NULL ,
	conta_bancaria        varchar(30)  NULL ,
	email                 varchar(100)  NULL ,
	id_uf_rg              char(2)  NULL ,
	id_uf_conselho_profissional  char(2)  NULL ,
	id_uf_titulo          char(2)  NULL ,
	cnh                   varchar(15)  NULL ,
	id_nacionalidade      int  NULL ,
	nome_reduzido         varchar(50)  NULL ,
	id_cor_raca           int  NULL ,
	email_pessoal         varchar(100)  NULL ,
	id_municipio_naturalidade  int  NULL ,
	id_tipo_pessoa        int  NULL ,
	id_cargo              int  NULL ,
	id_empresa_contato    int  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE pessoa
	ADD  PRIMARY KEY (id_pessoa  ASC)
go

CREATE TABLE pessoa_imagem
(
	id_pessoa             int IDENTITY(1,1) NOT NULL,
	foto                  varbinary(max)  NULL ,
	extensao_foto         varchar(5)  NULL 
)
go

ALTER TABLE pessoa_imagem
	ADD  PRIMARY KEY (id_pessoa  ASC)
go

CREATE TABLE rel_cliente_obra
(
	id_rel_cliente_obra   int IDENTITY(1,1) NOT NULL,
	id_cliente            int  NULL ,
	id_obra               int  NULL 
)
go

ALTER TABLE rel_cliente_obra
	ADD  PRIMARY KEY (id_rel_cliente_obra  ASC)
go

CREATE TABLE rel_fornecedor_obra
(
	id_rel_fornecedor_obra  int  NOT NULL 
)
go

ALTER TABLE rel_fornecedor_obra
	ADD  PRIMARY KEY (id_rel_fornecedor_obra  ASC)
go

CREATE TABLE rel_funcionario_obra
(
	id_rel_funcionario_obra  int  NOT NULL ,
	id_funcionario        int  NULL ,
	id_obra               int  NULL 
)
go

ALTER TABLE rel_funcionario_obra
	ADD  PRIMARY KEY (id_rel_funcionario_obra  ASC)
go

CREATE TABLE rel_grupo_usuario
(
	id_rel_grupo_usuario  int  NOT NULL ,
	id_grupo              int  NULL ,
	id_usuario            int  NULL 
)
go

ALTER TABLE rel_grupo_usuario
	ADD  PRIMARY KEY (id_rel_grupo_usuario  ASC)
go

CREATE TABLE rel_material_fornecedor
(
	id_rel_material_fornecedor  int IDENTITY(1,1) NOT NULL,
	id_fornecedor         int  NULL ,
	id_material           int  NULL ,
	unidade               varchar(10)  NULL ,
	preco_unitario        numeric(10,2)  NULL ,
	marca                 varchar(200)  NULL ,
	modelo                int  NULL ,
	cor                   int  NULL ,
	peso                  numeric(10,3)  NULL ,
	textura               varchar(200)  NULL ,
	altura                numeric(10,3)  NULL ,
	largura               numeric(10,3)  NULL ,
	profundidade          numeric(10,3)  NULL 
)
go

ALTER TABLE rel_material_fornecedor
	ADD  PRIMARY KEY (id_rel_material_fornecedor  ASC)
go

CREATE TABLE rel_servico_fornecedor
(
	id_rel_servico_fornecedor  int IDENTITY(1,1) NOT NULL,
	id_fornecedor         int  NULL ,
	id_servico            int  NULL ,
	unidade               varchar(10)  NULL ,
	preco_unitario        numeric(10,2)  NULL ,
	_default_             int  NULL 
)
go

ALTER TABLE rel_servico_fornecedor
	ADD  PRIMARY KEY (id_rel_servico_fornecedor  ASC)
go

CREATE TABLE relatorio
(
	id_relatorio          int IDENTITY(1,1) NOT NULL,
	dta_relatorio         datetime  NULL ,
	dta_ultima_atualizacao  datetime  NULL ,
	nome_view             varchar(200)  NULL ,
	id_modulo             int  NULL 
)
go

ALTER TABLE relatorio
	ADD  PRIMARY KEY (id_relatorio  ASC)
go

CREATE TABLE senha
(
	id_senha              int IDENTITY(1,1) NOT NULL,
	senha                 varchar(16)  NULL ,
	id_usuario            int  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE senha
	ADD  PRIMARY KEY (id_senha  ASC)
go

CREATE TABLE servico
(
	id_servico            int IDENTITY(1,1) NOT NULL,
	id_tipo_servico       int  NULL ,
	nome                  varchar(200)  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE servico
	ADD  PRIMARY KEY (id_servico  ASC)
go

CREATE TABLE servico_terceiro
(
	id_servico_obra       int IDENTITY(1,1) NOT NULL, 
	nome                  varchar(200)  NULL ,
)
go

ALTER TABLE servico_terceiro
	ADD  PRIMARY KEY (id_servico_obra  ASC)
go

CREATE TABLE status_obra
(
	id_status_obra        int IDENTITY(1,1) NOT NULL, 
	descricao             varchar(200)  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE status_obra
	ADD  PRIMARY KEY (id_status_obra  ASC)
go

CREATE TABLE telefone
(
	id_telefone           int IDENTITY(1,1) NOT NULL, 
	sta_tipo              varchar(200)  NULL ,
	numero                varchar(12)  NULL ,
	ramal                 varchar(10)  NULL ,
	id_pessoa             int  NULL ,
	id_obra               int  NULL 
)
go

ALTER TABLE telefone
	ADD  PRIMARY KEY (id_telefone  ASC)
go

CREATE TABLE tipo_backup
(
	id_tipo_backup        int IDENTITY(1,1) NOT NULL, 
	nome                  varchar(200)  NULL 
)
go

ALTER TABLE tipo_backup
	ADD  PRIMARY KEY (id_tipo_backup  ASC)
go

CREATE TABLE tipo_cliente
(
	id_tipo_cliente       int IDENTITY(1,1) NOT NULL, 
	descricao             varchar(200)  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE tipo_cliente
	ADD  PRIMARY KEY (id_tipo_cliente  ASC)
go

CREATE TABLE tipo_curso
(
	id_tipo_curso         int IDENTITY(1,1) NOT NULL, 
	nome                  varchar(250)  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE tipo_curso
	ADD  PRIMARY KEY (id_tipo_curso  ASC)
go

CREATE TABLE tipo_documento
(
	id_tipo_documento     int IDENTITY(1,1) NOT NULL, 
	nome                  varchar(200)  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE tipo_documento
	ADD  PRIMARY KEY (id_tipo_documento  ASC)
go

CREATE TABLE tipo_documento_fiscal
(
	id_tipo_documento_fiscal  int IDENTITY(1,1) NOT NULL, 
	nome                  varchar(200)  NULL 
)
go

ALTER TABLE tipo_documento_fiscal
	ADD  PRIMARY KEY (id_tipo_documento_fiscal  ASC)
go

CREATE TABLE tipo_fornecedor
(
	id_tipo_fornecedor    int IDENTITY(1,1) NOT NULL, 
	nome                  varchar(200)  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE tipo_fornecedor
	ADD  PRIMARY KEY (id_tipo_fornecedor  ASC)
go

CREATE TABLE tipo_funcionario
(
	id_tipo_funcionario   int IDENTITY(1,1) NOT NULL, 
	nome                  varchar(200)  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE tipo_funcionario
	ADD  PRIMARY KEY (id_tipo_funcionario  ASC)
go

CREATE TABLE tipo_material
(
	id_tipo_material      int IDENTITY(1,1) NOT NULL, 
	nome                  varchar(200)  NULL 
)
go

ALTER TABLE tipo_material
	ADD  PRIMARY KEY (id_tipo_material  ASC)
go

CREATE TABLE tipo_obra
(
	id_tipo_obra          int IDENTITY(1,1) NOT NULL, 
	descricao             varchar(200)  NULL 
)
go

ALTER TABLE tipo_obra
	ADD  PRIMARY KEY (id_tipo_obra  ASC)
go

CREATE TABLE tipo_pessoa
(
	id_tipo_pessoa        int IDENTITY(1,1) NOT NULL, 
	nome                  varchar(250)  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE tipo_pessoa
	ADD  PRIMARY KEY (id_tipo_pessoa  ASC)
go

CREATE TABLE tipo_sanguineo
(
	id_tipo_sanguineo     int IDENTITY(1,1) NOT NULL, 
	descricao             char(3)  NULL 
)
go

ALTER TABLE tipo_sanguineo
	ADD  PRIMARY KEY (id_tipo_sanguineo  ASC)
go

CREATE TABLE tipo_servico
(
	id_tipo_servico       int IDENTITY(1,1) NOT NULL, 
	nome                  varchar(200)  NULL 
)
go

ALTER TABLE tipo_servico
	ADD  PRIMARY KEY (id_tipo_servico  ASC)
go

CREATE TABLE tipo_usuario
(
	id_tipo_usuario       int IDENTITY(1,1) NOT NULL, 
	descricao             varchar(200)  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE tipo_usuario
	ADD  PRIMARY KEY (id_tipo_usuario  ASC)
go

CREATE TABLE uf
(
	id_uf                 int IDENTITY(1,1) NOT NULL, 
	sigla                 char(2)  NOT NULL ,
	nome                  varchar(30)  NULL ,
	id_pais               int  NULL 
)
go

ALTER TABLE uf
	ADD  PRIMARY KEY (id_uf  ASC)
go

CREATE TABLE usuario
(
	id_usuario            int IDENTITY(1,1) NOT NULL, 
	id_tipo_usuario       int  NULL ,
	id_pessoa             int  NULL ,
	sin_ativo             bit  NULL 
)
go

ALTER TABLE usuario
	ADD  PRIMARY KEY (id_usuario  ASC)
go


ALTER TABLE tab_backup
	ADD  FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
go

ALTER TABLE tab_backup
	ADD  FOREIGN KEY (id_tipo_backup) REFERENCES tipo_backup(id_tipo_backup)
go

ALTER TABLE caixa
	ADD  FOREIGN KEY (id_documento_fiscal) REFERENCES documento_fiscal(id_documento_fiscal)
go

ALTER TABLE caixa
	ADD  FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
go

ALTER TABLE caixa
	ADD  FOREIGN KEY (id_obra) REFERENCES obra(id_obra)
go

ALTER TABLE cidade
	ADD  FOREIGN KEY (id_uf) REFERENCES uf(id_uf)
go

ALTER TABLE cliente
	ADD  FOREIGN KEY (id_tipo_cliente) REFERENCES tipo_cliente(id_tipo_cliente)
go

ALTER TABLE cliente
	ADD  FOREIGN KEY (id_pessoa) REFERENCES pessoa(id_pessoa)
go

ALTER TABLE conta_bancaria
	ADD  FOREIGN KEY (id_banco) REFERENCES banco(id_banco)
go

ALTER TABLE conta_bancaria
	ADD  FOREIGN KEY (id_pessoa) REFERENCES pessoa(id_pessoa)
go

ALTER TABLE custo
	ADD  FOREIGN KEY (id_obra) REFERENCES obra(id_obra)
go

ALTER TABLE custo
	ADD  FOREIGN KEY (id_centro_custo) REFERENCES centro_custo(id_centro_custo)
go

ALTER TABLE custo
	ADD  FOREIGN KEY (id_rel_material_fornecedor) REFERENCES rel_material_fornecedor(id_rel_material_fornecedor)
go

ALTER TABLE custo
	ADD  FOREIGN KEY (id_rel_servico_fornecedor) REFERENCES rel_servico_fornecedor(id_rel_servico_fornecedor)
go

ALTER TABLE custo
	ADD  FOREIGN KEY (id_documento_fiscal) REFERENCES documento_fiscal(id_documento_fiscal)
go

ALTER TABLE custo
	ADD  FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
go

ALTER TABLE diario_obra
	ADD  FOREIGN KEY (id_obra) REFERENCES obra(id_obra)
go

ALTER TABLE documento
	ADD  FOREIGN KEY (id_obra) REFERENCES obra(id_obra)
go

ALTER TABLE documento
	ADD  FOREIGN KEY (id_tipo_documento) REFERENCES tipo_documento(id_tipo_documento)
go

ALTER TABLE documento_fiscal
	ADD  FOREIGN KEY (id_tipo_documento_fiscal) REFERENCES tipo_documento_fiscal(id_tipo_documento_fiscal)
go

ALTER TABLE endereco
	ADD  FOREIGN KEY (id_cidade) REFERENCES cidade(id_cidade)
go

ALTER TABLE endereco
	ADD  FOREIGN KEY (id_pessoa) REFERENCES pessoa(id_pessoa)
go

ALTER TABLE fornecedor
	ADD  FOREIGN KEY (id_tipo_fornecedor) REFERENCES tipo_fornecedor(id_tipo_fornecedor)
go

ALTER TABLE fornecedor
	ADD  FOREIGN KEY (id_pessoa) REFERENCES pessoa(id_pessoa)
go

ALTER TABLE funcionario
	ADD  FOREIGN KEY (id_tipo_funcionario) REFERENCES tipo_funcionario(id_tipo_funcionario)
go

ALTER TABLE funcionario
	ADD  FOREIGN KEY (id_pessoa) REFERENCES pessoa(id_pessoa)
go

ALTER TABLE grau_instrucao
	ADD  FOREIGN KEY (id_tipo_curso) REFERENCES tipo_curso(id_tipo_curso)
go

ALTER TABLE historico_cliente
	ADD  FOREIGN KEY (id_cliente) REFERENCES cliente(id_cliente)
go

ALTER TABLE log
	ADD  FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
go

ALTER TABLE log
	ADD  FOREIGN KEY (id_acao) REFERENCES acao(id_acao)
go

ALTER TABLE material
	ADD  FOREIGN KEY (id_tipo_material) REFERENCES tipo_material(id_tipo_material)
go

ALTER TABLE migracao
	ADD  FOREIGN KEY (id_funcionario) REFERENCES funcionario(id_funcionario)
go

ALTER TABLE migracao
	ADD  FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
go

ALTER TABLE obra
	ADD  FOREIGN KEY (id_endereco) REFERENCES endereco(id_endereco)
go

ALTER TABLE obra
	ADD  FOREIGN KEY (id_status_obra) REFERENCES status_obra(id_status_obra)
go

ALTER TABLE obra
	ADD  FOREIGN KEY (id_tipo_obra) REFERENCES tipo_obra(id_tipo_obra)
go

ALTER TABLE permissao
	ADD  FOREIGN KEY (id_modulo) REFERENCES modulo(id_modulo)
go

ALTER TABLE permissao
	ADD  FOREIGN KEY (id_grupo) REFERENCES grupo(id_grupo)
go

ALTER TABLE pessoa
	ADD  FOREIGN KEY (id_estado_civil) REFERENCES estado_civil(id_estado_civil)
go

ALTER TABLE pessoa
	ADD  FOREIGN KEY (id_tipo_sanguineo) REFERENCES tipo_sanguineo(id_tipo_sanguineo)
go

ALTER TABLE pessoa
	ADD  FOREIGN KEY (id_nacionalidade) REFERENCES nacionalidade(id_nacionalidade)
go

ALTER TABLE pessoa
	ADD  FOREIGN KEY (id_cor_raca) REFERENCES cor_raca(id_cor_raca)
go

ALTER TABLE pessoa
	ADD  FOREIGN KEY (id_grau_instrucao) REFERENCES grau_instrucao(id_grau_instrucao)
go

ALTER TABLE pessoa
	ADD  FOREIGN KEY (id_tipo_pessoa) REFERENCES tipo_pessoa(id_tipo_pessoa)
go

ALTER TABLE pessoa
	ADD  FOREIGN KEY (id_cargo) REFERENCES cargo(id_cargo)
go

ALTER TABLE pessoa
	ADD  FOREIGN KEY (id_empresa_contato) REFERENCES pessoa(id_pessoa)
go

ALTER TABLE pessoa_imagem
	ADD  FOREIGN KEY (id_pessoa) REFERENCES pessoa(id_pessoa)
go

ALTER TABLE rel_cliente_obra
	ADD  FOREIGN KEY (id_cliente) REFERENCES cliente(id_cliente)
go

ALTER TABLE rel_cliente_obra
	ADD  FOREIGN KEY (id_obra) REFERENCES obra(id_obra)
go

ALTER TABLE rel_funcionario_obra
	ADD  FOREIGN KEY (id_funcionario) REFERENCES funcionario(id_funcionario)
go

ALTER TABLE rel_funcionario_obra
	ADD  FOREIGN KEY (id_obra) REFERENCES obra(id_obra)
go

ALTER TABLE rel_grupo_usuario
	ADD  FOREIGN KEY (id_grupo) REFERENCES grupo(id_grupo)
go

ALTER TABLE rel_grupo_usuario
	ADD  FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
go

ALTER TABLE rel_material_fornecedor
	ADD  FOREIGN KEY (id_fornecedor) REFERENCES fornecedor(id_fornecedor)
go

ALTER TABLE rel_material_fornecedor
	ADD  FOREIGN KEY (id_material) REFERENCES material(id_material)
go

ALTER TABLE rel_servico_fornecedor
	ADD  FOREIGN KEY (id_fornecedor) REFERENCES fornecedor(id_fornecedor)
go

ALTER TABLE rel_servico_fornecedor
	ADD  FOREIGN KEY (id_servico) REFERENCES servico(id_servico)
go

ALTER TABLE relatorio
	ADD  FOREIGN KEY (id_modulo) REFERENCES modulo(id_modulo)
go

ALTER TABLE senha
	ADD  FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
go

ALTER TABLE servico
	ADD  FOREIGN KEY (id_tipo_servico) REFERENCES tipo_servico(id_tipo_servico)
go

ALTER TABLE telefone
	ADD  FOREIGN KEY (id_pessoa) REFERENCES pessoa(id_pessoa)
go

ALTER TABLE telefone
	ADD  FOREIGN KEY (id_obra) REFERENCES obra(id_obra)
go

ALTER TABLE uf
	ADD  FOREIGN KEY (id_pais) REFERENCES pais(id_pais)
go

ALTER TABLE usuario
	ADD  FOREIGN KEY (id_tipo_usuario) REFERENCES tipo_usuario(id_tipo_usuario)
go

ALTER TABLE usuario
	ADD  FOREIGN KEY (id_pessoa) REFERENCES pessoa(id_pessoa)
go
