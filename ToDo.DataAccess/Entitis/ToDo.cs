﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.DataAccess.Entitis;

public class ToDo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public bool IsComplete { get; set; }
}
