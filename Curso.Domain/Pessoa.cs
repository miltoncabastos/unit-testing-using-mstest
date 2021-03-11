using System;

namespace Domain
{
    public class Pessoa
    {
        public Pessoa(string nome, Email email, DateTime ultimoAcesso)
        {
            Nome = nome;
            Email = email;
            UltimoAcesso = ultimoAcesso;
        }

        public long Id { get; set; }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O nome é inválido");
                _nome = value;
            }
        }

        public Email Email { get; set; }

        public DateTime UltimoAcesso { get; set; }

        public bool Ativo { get => UltimoAcesso > DateTime.Today.AddDays(-30); }
    }
}