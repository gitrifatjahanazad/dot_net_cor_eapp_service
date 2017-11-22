using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace vs_web_mvc.Models
{
    public class ToDoViewModel
    {
            public List<ToDoItem> ToDos;
            public SelectList Categories;
            public string Category { get; set; }
    }
}
