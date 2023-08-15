namespace LABCC.Application.UseCases.Users.SignUp;

public sealed class SignUpRequest
{
    public string Email { get; set; }
    public string Nome { get; set; }
    public string CpfOuCnpj { get; set; }
    public string Genero { get; set; }
    public DateOnly DataDeNascimento { get; set; }
    public string Telefone { get; set; }
    public string TipoDeUsuario { get; set; }
    public string StatusDoUsuario { get; set; }
}