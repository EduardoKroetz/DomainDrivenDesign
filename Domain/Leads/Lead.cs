namespace Domain.Leads;

public class Lead
{
    public Lead(string nome, string email, string telefone, string? empresa)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Empresa = empresa;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public string? Empresa { get; private set; }
}