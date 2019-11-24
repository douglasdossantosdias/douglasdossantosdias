namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pessoa()
        {
            this.cliente = new HashSet<cliente>();
            this.conta_bancaria1 = new HashSet<conta_bancaria>();
            this.endereco = new HashSet<endereco>();
            this.fornecedor = new HashSet<fornecedor>();
            this.funcionario = new HashSet<funcionario>();
            this.pessoa1 = new HashSet<pessoa>();
            this.telefone = new HashSet<telefone>();
            this.usuario = new HashSet<usuario>();
        }

        [Display(Name = "Nome da Pessoa")]
        public int id_pessoa { get; set; }

        [Display(Name = "Nome da Pessoa")]
        public string nome { get; set; }

        [Display(Name = "Nome Jurídico")]
        public string nome_juridico { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string nome_fantasia { get; set; }

        [Display(Name = "CNPJ")]
        public string cnpj { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string inscricao_estadual { get; set; }

        [Display(Name = "Sexo")]
        public string sexo { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [Display(Name = "Data de Nascimento")]
        public string dta_nascimento { get; set; }
        public Nullable<int> ano_chegada { get; set; }

        [Display(Name = "Naturalidade")]
        public string naturalidade { get; set; }

        [Display(Name = "Estado Civíl")]
        public Nullable<int> id_estado_civil { get; set; }
        public string nome_conjuge { get; set; }
        public string nome_pai { get; set; }

        [Display(Name = "Nome da Mãe")]
        public string nome_mae { get; set; }

        [Display(Name = "Tipo sanguíneo")]
        public Nullable<int> id_tipo_sanguineo { get; set; }

        [Display(Name = "Grau de instrução")]
        public Nullable<int> id_grau_instrucao { get; set; }
        public string registro_conselho_profissional { get; set; }

        [Display(Name = "RG")]
        public string rg { get; set; }
        public string orgao_expedidor_rg { get; set; }
        public Nullable<System.DateTime> dta_expedicao_rg { get; set; }

        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [Display(Name = "PIS/PASEP")]
        public string pis_pasep { get; set; }

        [Display(Name = "Título de eleitor")]
        public string titulo_eleitor { get; set; }
        public string zona_eleitoral { get; set; }
        public string secao_eleitoral { get; set; }
        public Nullable<System.DateTime> dta_ultima_votacao { get; set; }
        public Nullable<System.DateTime> dta_emissao_titulo { get; set; }
        public string cidade_titulo { get; set; }
        public string certificado_reservista { get; set; }
        public string categoria_militar { get; set; }
        public string regiao_militar { get; set; }
        public string registro_cnh { get; set; }
        public string categoria_cnh { get; set; }
        public Nullable<System.DateTime> dta_primeira_cnh { get; set; }
        public Nullable<System.DateTime> dta_emissao_cnh { get; set; }
        public Nullable<System.DateTime> dta_validade_cnh { get; set; }

        [Display(Name = "Conta bancária")]
        public string conta_bancaria { get; set; }

        [Display(Name = "E-mail")]
        public string email { get; set; }
        public string id_uf_rg { get; set; }
        public string id_uf_conselho_profissional { get; set; }
        public string id_uf_titulo { get; set; }


        [Display(Name = "CNH")]
        public string cnh { get; set; }


        [Display(Name = "Nacionalidade")]
        public Nullable<int> id_nacionalidade { get; set; }
        public string nome_reduzido { get; set; }
        public Nullable<int> id_cor_raca { get; set; }
        public string email_pessoal { get; set; }
        public Nullable<int> id_municipio_naturalidade { get; set; }


        [Display(Name = "Tipo de Pessoa")]
        public Nullable<int> id_tipo_pessoa { get; set; }


        [Display(Name = "Cargo")]
        public Nullable<int> id_cargo { get; set; }


        [Display(Name = "Contato na Empresa")]
        public Nullable<int> id_empresa_contato { get; set; }


        [Display(Name = "Ativo")]
        public Nullable<bool> sin_ativo { get; set; }
    
        public virtual cargo cargo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente> cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<conta_bancaria> conta_bancaria1 { get; set; }
        public virtual cor_raca cor_raca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<endereco> endereco { get; set; }
        public virtual estado_civil estado_civil { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fornecedor> fornecedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<funcionario> funcionario { get; set; }
        public virtual grau_instrucao grau_instrucao { get; set; }
        public virtual nacionalidade nacionalidade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pessoa> pessoa1 { get; set; }
        public virtual pessoa pessoa2 { get; set; }
        public virtual tipo_sanguineo tipo_sanguineo { get; set; }
        public virtual tipo_pessoa tipo_pessoa { get; set; }
        public virtual pessoa_imagem pessoa_imagem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<telefone> telefone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuario { get; set; }
    }
}
