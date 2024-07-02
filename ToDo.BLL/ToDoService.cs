using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Entitis;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DataAccess.Repository;

namespace ToDoApp.BLL;

public class ToDoService : IToDoService
{
    private readonly IToDoRepository _repository;

    public ToDoService(IToDoRepository repository)
    {
        _repository = repository;
    }


    public async Task<IEnumerable<ToDo>> GetItemsAsync()
    {
        return await _repository.GetItemsAsync();
    }

    public async Task<ToDo> GetItemByIdAsync(int id)
    {
        if (id <= 0) throw new ArgumentException("The id must be a positive number.", nameof(id));

        return await _repository.GetItemByIdAsync(id);
    }

    public async Task<ToDo> GetItemByDateAsync(DateTime date)
    {
        if (date == DateTime.MinValue) throw new ArgumentNullException("Invalid date format. Please use MM/dd/yyyy.");

        return await _repository.GetItemByDateAsync(date);
    }

    public void AddItemAsync(ToDo item)
    {
        if (item == null) throw new ArgumentNullException("The item must be a not null .", nameof(item));

        item.Date = DateTime.Today;
        _repository.AddItemAsync(item);
    }

    public void UpdateItemAsync(ToDo item)
    {
        if (item == null) throw new ArgumentNullException("The item must be a not null .", nameof(item));
        _repository.UpdateItemAsync(item);
    }

    public void DeleteItemAsync(int id)
    {
        if (id <= 0) throw new ArgumentException("The id must be a positive number.", nameof(id));

        _repository.DeleteItemAsync(id);
    }
}
