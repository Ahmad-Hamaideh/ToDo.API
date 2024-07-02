using ToDoApp.DataAccess.Entitis;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.BLL;

public interface IToDoService
{
    Task<IEnumerable<ToDo>> GetItemsAsync();
    Task<ToDo> GetItemByIdAsync(int id);
    Task<ToDo> GetItemByDateAsync(DateTime date);
    void AddItemAsync(ToDo item);
    void UpdateItemAsync(ToDo item);
    void DeleteItemAsync(int id);
}