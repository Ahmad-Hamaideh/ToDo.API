using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Entitis;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DataAccess;

namespace ToDoApp.DataAccess.Repository;

public class ToDoRepository : IToDoRepository
{
    private readonly AppDbContext _context;

    public ToDoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ToDo>> GetItemsAsync()
    {
        return await _context.ToDos.ToListAsync();
    }

    public async Task<ToDo> GetItemByIdAsync(int id)
    {
        return await _context.ToDos.FindAsync(id);
    }

    public async void AddItemAsync(ToDo item)
    {
        await _context.ToDos.AddAsync(item);
        _context.SaveChanges();
    }

    public void UpdateItemAsync(ToDo item)
    {
        _context.ToDos.Update(item);

        _context.SaveChanges();

    }
    public async Task<ToDo> GetItemByDateAsync(DateTime date)
    {
        return await _context.ToDos
            .FirstOrDefaultAsync(item => item.Date.Date == date.Date);
    }

    public async Task DeleteItemAsync(int id)
    {
        var item = await _context.ToDos.FindAsync(id);
        if (item != null)
        {
            _context.ToDos.Remove(item);
            _context.SaveChanges();
        }
    }
}
