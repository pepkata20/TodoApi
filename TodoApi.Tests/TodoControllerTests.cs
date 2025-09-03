using Microsoft.EntityFrameworkCore;
using TodoApi.Controllers;
using TodoApi.Data;
using TodoApi.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Tests
{
    public class TodoControllerTests
    {
        private static TodoContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + System.Guid.NewGuid())
                .Options;

            return new TodoContext(options);
        }

        [Fact]
        public async Task GetTodos_ReturnsAllTodos()
        {
            using var context = GetInMemoryDbContext();
            context.TodoItems.Add(new TodoItem { Title = "Test 1", Description = "Desc 1" });
            context.TodoItems.Add(new TodoItem { Title = "Test 2", Description = "Desc 2" });
            await context.SaveChangesAsync();

            var controller = new TodoController(context);
            var result = await controller.GetTodos();

            var todos = Assert.IsType<List<TodoItem>>(result.Value);
            Assert.Equal(2, todos.Count);
        }

        [Fact]
        public async Task GetTodo_ReturnsTodoItem()
        {
            using var context = GetInMemoryDbContext();
            var todo = new TodoItem { Title = "Test", Description = "Desc" };
            context.TodoItems.Add(todo);
            await context.SaveChangesAsync();

            var controller = new TodoController(context);
            var result = await controller.GetTodo(todo.Id);

            var item = Assert.IsType<TodoItem>(result.Value);
            Assert.Equal("Test", item.Title);
        }

        [Fact]
        public async Task CreateTodo_AddsNewTodo()
        {
            using var context = GetInMemoryDbContext();
            var controller = new TodoController(context);

            var newTodo = new TodoItem { Title = "New", Description = "New Desc" };
            var result = await controller.CreateTodo(newTodo);

            var createdAt = Assert.IsType<CreatedAtActionResult>(result.Result);
            var item = Assert.IsType<TodoItem>(createdAt.Value);
            Assert.Equal("New", item.Title);
            Assert.Equal(1, await context.TodoItems.CountAsync());
        }

        [Fact]
        public async Task UpdateTodo_ChangesTodo()
        {
            using var context = GetInMemoryDbContext();
            var todo = new TodoItem { Title = "Old", Description = "Old Desc" };
            context.TodoItems.Add(todo);
            await context.SaveChangesAsync();

            var controller = new TodoController(context);
            todo.Title = "Updated";
            await controller.UpdateTodo(todo.Id, todo);

            var updated = await context.TodoItems.FindAsync(todo.Id);
            Assert.NotNull(updated); // Ensure 'updated' is not null before dereferencing
            Assert.Equal("Updated", updated!.Title); // Use null-forgiving operator
        }

        [Fact]
        public async Task DeleteTodo_RemovesTodo()
        {
            using var context = GetInMemoryDbContext();
            var todo = new TodoItem { Title = "ToDelete", Description = "Desc" };
            context.TodoItems.Add(todo);
            await context.SaveChangesAsync();

            var controller = new TodoController(context);
            await controller.DeleteTodo(todo.Id);

            Assert.Empty(context.TodoItems);
        }
    }
}