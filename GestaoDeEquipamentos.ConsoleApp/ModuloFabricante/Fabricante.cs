namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class Fabricante
{
    public int Id;
    public string Nome;
    public string Email;
    public int Telefone;

    public Fabricante(string nome, string email, int telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }
}
