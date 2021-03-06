﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    class TodoRepository:ITodoRepository
    {
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;


        public TodoRepository(IGenericList<TodoItem> initialDbState =null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y = > if x is not null , expression returns x. Else it will return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                throw new DuplicateTodoItemException("duplicate id: {0}",todoItem.Id);
            }
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public TodoItem Get(Guid todoId)
        {
           TodoItem d=(TodoItem)_inMemoryTodoDatabase.Where(s => s.Id == todoId).ToList().First();
            if (d == null)
            {
                return null;
            }
            return d;
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(s => !(s.IsCompleted)).ToList();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(s=>s.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(s => (s.IsCompleted)).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            throw new NotImplementedException();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            bool t=_inMemoryTodoDatabase.Where(s => s.Id == todoId).Any(s => s.MarkAsCompleted());
            return t;
        }

        public bool Remove(Guid todoId)
        {
            var found=_inMemoryTodoDatabase.Where(s => s.Id == todoId).First();
            _inMemoryTodoDatabase.Remove(found);
            return true;
        }

        public TodoItem Update(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    internal class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException()
        {
        }

        public DuplicateTodoItemException(string message, Guid id) : base(message)
        {
        }

        public DuplicateTodoItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateTodoItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

