namespace CadastrosApi.Models
{
    public class Usuario
    {
        public Guid Id {get; init;}
        public string Nome { get; set; }
        public string Email { get; private set; }
        public int Senha { get; private set; }

        public Usuario(string nome, string email, int senha)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public void AtualizarDados(string nome, string email, int senha)
        {
            if(nome != null)
                Nome = nome;

            if(email != null)
                Email = email;

            if(senha != Senha && senha > 0)
                Senha = senha;
        }
    }
}