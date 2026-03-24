using ConnectaMVC.Data;
using ConnectaMVC.Models;

namespace ConnectaMVC.Services;

// Services/TarefaService.cs
public class TarefaService(AppDbContext context)
{

    public List<Tarefa> ListarTodas() => context.Tarefas.ToList();

    public void Adicionar(string titulo)
    {
        context.Tarefas.Add(new Tarefa { Titulo = titulo });
        context.SaveChanges();
    }
}
