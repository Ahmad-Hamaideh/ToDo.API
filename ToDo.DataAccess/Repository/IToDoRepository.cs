using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Entitis;

namespace ToDoApp.DataAccess.Repository;

public interface IToDoRepository
{
    Task<IEnumerable<ToDo>> GetItemsAsync();
    Task<ToDo> GetItemByIdAsync(int id);
    Task<ToDo> GetItemByDateAsync(DateTime date);
    void AddItemAsync(ToDo item);
    void UpdateItemAsync(ToDo item);
    Task DeleteItemAsync(int id);
}

