using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zad2;

namespace zad3
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void TestMethod1()
        { 
            IGenericList<TodoItem> g=new GenericList<TodoItem>();
            ITodoRepository testt=new TodoRepository();
            TodoItem ana=new TodoItem("Ana");
            
            testt.Add(new TodoItem("Luka"));
          Assert.AreEqual(ana, testt.Add(ana));
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void ExpectException()
        {
            IGenericList<TodoItem> g = new GenericList<TodoItem>();
            ITodoRepository testt = new TodoRepository();
            TodoItem ana = new TodoItem("Ana");

            testt.Add(ana);
            testt.Add(ana);
        }
        [TestMethod]
        public void TestGet()
        {
            IGenericList<TodoItem> g = new GenericList<TodoItem>();
            ITodoRepository testt = new TodoRepository();
            TodoItem ana = new TodoItem("Ana");
            TodoItem luka = new TodoItem("Luka");
            testt.Add(ana);
            Assert.AreEqual(ana, testt.Get(ana.Id));
            Assert.AreEqual(null, testt.Get(luka.Id));
        }

        [TestMethod]
        public void TestGetActive()
        {
            IGenericList<TodoItem> g = new GenericList<TodoItem>();
            ITodoRepository testt = new TodoRepository();
            TodoItem ana = new TodoItem("Ana");
            TodoItem luka = new TodoItem("Luka");
            ana.MarkAsCompleted();
            testt.Add(ana);
            testt.Add(luka);
            List<TodoItem> list = testt.GetActive();
            Assert.AreEqual(false,list.Contains(ana));
            Assert.AreEqual(true, list.Contains(luka));

        }

        [TestMethod]
        public void TestGetAll()
        {
            IGenericList<TodoItem> g = new GenericList<TodoItem>();
            ITodoRepository testt = new TodoRepository();
            TodoItem anja = new TodoItem("Ana");
           // Assert.AreEqual(DateTime.Now,ana.DateCreated);
            TodoItem marko = new TodoItem("Luka");
            TodoItem ana = new TodoItem("Anja");
            TodoItem luka = new TodoItem("Marko");
            ana.MarkAsCompleted();
            testt.Add(anja);
            testt.Add(ana);
            testt.Add(luka);
            testt.Add(marko);
           
            //Assert.AreEqual(0,ana.DateCreated);
          // Assert.AreEqual(0,luka.DateCreated);
           // Assert.AreEqual(0,marko.DateCreated);

            List<TodoItem> list = testt.GetAll();
           // Assert.AreEqual(3,list.IndexOf(marko));
            Assert.AreEqual(2, list.IndexOf(luka));
           // Assert.AreEqual(3, list.IndexOf(luka));
        }
        [TestMethod]
        public void TestGetComplited()
        {
            IGenericList<TodoItem> g = new GenericList<TodoItem>();
            ITodoRepository testt = new TodoRepository();
            TodoItem ana = new TodoItem("Ana");
            TodoItem luka = new TodoItem("Luka");
            ana.MarkAsCompleted();
            testt.Add(ana);
            testt.Add(luka);
            List<TodoItem> list = testt.GetCompleted();
            Assert.AreEqual(true, list.Contains(ana));
            Assert.AreEqual(false, list.Contains(luka));

        }

        [TestMethod]
        public void TestRemove()
        {
            IGenericList<TodoItem> g = new GenericList<TodoItem>();
            ITodoRepository testt = new TodoRepository();
            TodoItem anja = new TodoItem("Ana");
            // Assert.AreEqual(DateTime.Now,ana.DateCreated);
            TodoItem marko = new TodoItem("Luka");
            TodoItem ana = new TodoItem("Anja");
            TodoItem luka = new TodoItem("Marko");
            ana.MarkAsCompleted();
            testt.Add(anja);
            testt.Add(ana);
            testt.Add(luka);
            testt.Add(marko);
            testt.Remove(ana.Id);
            testt.Remove(anja.Id);
            Assert.AreEqual(false,testt.Remove(ana.Id));
            Assert.AreEqual(null,testt.Get(ana.Id));

        }

        [TestMethod]
        public void TestMarkAsComplited()
        {
            IGenericList<TodoItem> g = new GenericList<TodoItem>();
            ITodoRepository testt = new TodoRepository();
            TodoItem anja = new TodoItem("Ana");
            // Assert.AreEqual(DateTime.Now,ana.DateCreated);
            TodoItem marko = new TodoItem("Luka");
            TodoItem ana = new TodoItem("Anja");
            TodoItem luka = new TodoItem("Marko");
            testt.Add(anja);
            testt.Add(ana);
            testt.Add(luka);
            testt.Add(marko);
            testt.MarkAsCompleted(ana.Id);
            List<TodoItem> list=testt.GetCompleted();
            Assert.AreEqual(true,list.Contains(ana));
            Assert.AreEqual(false, list.Contains(anja));
        }

        [TestMethod]
        public void TestFilter()
        {
            IGenericList<TodoItem> g = new GenericList<TodoItem>();
            ITodoRepository testt = new TodoRepository();
            TodoItem anja = new TodoItem("Ana");
            // Assert.AreEqual(DateTime.Now,ana.DateCreated);
            TodoItem marko = new TodoItem("Luka");
            TodoItem ana = new TodoItem("Anja");
            TodoItem luka = new TodoItem("Marko");
            testt.Add(anja);
            testt.Add(ana);
            testt.Add(luka);
            testt.Add(marko);
            List<TodoItem> list=testt.GetFiltered(s => s.Equals(ana));
            Assert.AreEqual(true,list.Contains(ana));
            

        }

        [TestMethod]
        public void UpdateTest()
        {
            var dateTime = new DateTime();
            var firstTodoItem = new TodoItem("Ana");

            firstTodoItem.DateCreated = dateTime;

            var todoRepository = new TodoRepository();

            Assert.AreEqual(firstTodoItem, todoRepository.Update(firstTodoItem));
            Assert.AreEqual(1, todoRepository.GetAll().Count);
            Assert.AreEqual(dateTime, firstTodoItem.DateCreated);

            var newDateTime = new DateTime();
            firstTodoItem.DateCreated = newDateTime;

            Assert.AreEqual(firstTodoItem, todoRepository.Update(firstTodoItem));
            Assert.AreEqual(newDateTime, firstTodoItem.DateCreated);
            Assert.AreEqual(1, todoRepository.GetAll().Count);

        }
      
            [TestMethod]
            public void ConstructionTest()
            {
                var todoItem = new TodoItem("Ana");

                Assert.AreEqual(null, todoItem.DateCompleted);
                Assert.AreNotEqual(null, todoItem.DateCreated);
            }

            [TestMethod]
            public void MarkAsCompletedTest()
            {
                var todoItem = new TodoItem("Ana");

                Assert.AreEqual(true, todoItem.MarkAsCompleted());
                Assert.AreEqual(false, todoItem.MarkAsCompleted());
            }

            [TestMethod]
            public void EqualsTest()
            {
                var todoItem = new TodoItem("Ana");
                var otherTodoItem = new TodoItem("Ana");

                Assert.AreNotEqual(null, todoItem);
                Assert.AreEqual(todoItem, todoItem);
                Assert.AreNotEqual(otherTodoItem, todoItem);
            }

            [TestMethod]
            public void HashCodeTest()
            {
                var todoItem = new TodoItem("Marko");
                var otherTodoItem = new TodoItem("Marko");

                Assert.AreNotEqual(otherTodoItem.GetHashCode(), todoItem.GetHashCode());
            }


        }
}
