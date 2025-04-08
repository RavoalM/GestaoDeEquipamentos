namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante
{
    public RepositorioFabricante repositorioFabricante;

    public TelaFabricante()
    {
        repositorioFabricante = new RepositorioFabricante();
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("Escolha a operação desejada:");
        Console.WriteLine("1 - Cadastro de Fabricantes");
        Console.WriteLine("2 - Edição de Fabricantes");
        Console.WriteLine("3 - Exclusão de Fabricantes");
        Console.WriteLine("4 - Visualização de Fabricantes");
        Console.WriteLine("--------------------------------------------");

        Console.Write("Digite um opção válida: ");
        char opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;
    }

    public void CadastrarFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastrando Fabricante...");
        Console.WriteLine("--------------------------------------------");

        Fabricante novoFabricante = ObterDadosFabricante();

        repositorioFabricante.CadastrarFabricante(novoFabricante);

        Console.WriteLine();
        Console.WriteLine("O fabricante foi cadastrado com sucesso!");
    }

    public void EditarFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando Fabricante...");
        Console.WriteLine("--------------------------------------------");

        VisualizarFabricantes(false);

        Console.Write("Digite o ID do fabricante que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Fabricante novoFabricante = ObterDadosFabricante();

        bool conseguiuEditar = repositorioFabricante.EditarFabricante(idSelecionado, novoFabricante);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O Fabricante foi editado com sucesso!");
    }

    public void ExcluirFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Excluindo Fabricante...");
        Console.WriteLine("--------------------------------------------");

        VisualizarFabricantes(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioFabricante.ExcluirFabricante(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Houve um erro durante a exclusão de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O fabricante foi excluído com sucesso!");
    }

    public void VisualizarFabricantes(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            ExibirCabecalho();

            Console.WriteLine("Visualizando Fabricantes...");
            Console.WriteLine("--------------------------------------------");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -11} | {3, -15}",
            "Id", "Nome", "Email", "Telefone"
        );

        Fabricante[] fabricantesCadastrados = repositorioFabricante.SelecionarFabricantes();

        for (int i = 0; i < fabricantesCadastrados.Length; i++)
        {
            Fabricante e = fabricantesCadastrados[i];

            if (e == null) continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15}",
                e.Id, e.Nome, e.Email, e.Telefone
            );
        }

        Console.WriteLine();
    }

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("--------------------------------------------");
    }

    public Fabricante ObterDadosFabricante()
    {
        Console.Write("Digite o nome do fabricante: ");
        string nome = Console.ReadLine()!.Trim(); ;

        Console.Write("Digite o email do fabricante: ");
        string email = Console.ReadLine()!.Trim(); ;

        Console.Write("Digite o telefone do fabricante ");
        int telefone = Convert.ToInt32(Console.ReadLine()!.Trim());

        Fabricante novoFabricante = new Fabricante(nome, email, telefone);

        return novoFabricante;
    }
}
