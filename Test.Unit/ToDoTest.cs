using NUnit.Framework;
using GetOrganized.Models;
using GetOrganized.Controllers;
using System.Web.Mvc;

namespace Test.Unit
{
    [TestFixture]
    public class ToDoTest
    {
        [SetUp]
        public void SetUp()
        {
            ToDo.ThingsToBeDone = new System.Collections.Generic.List<ToDo> { new ToDo { Title = "Get Milk" }, new ToDo { Title = "Get Bacon" } };
        }

        [Test]
        public void Should_Display_A_List_of_ToDo_Items()
        {
            var viewResult = (ViewResult)new ToDoController().Index();
            Assert.AreEqual(ToDo.ThingsToBeDone, viewResult.ViewData.Model);
        }

        [Test]
        public void Should_Load_Create_View()
        {
            var viewResult = (ViewResult)new ToDoController().Create();
            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Should_Add_ToDo_Item()
        {
            var todo = new ToDo { Title = "Learn MVC controller" };

            var redirectToRouteResult = (RedirectToRouteResult)new ToDoController().Create(todo);

            Assert.Contains(todo, ToDo.ThingsToBeDone);

            Assert.AreEqual("Index", redirectToRouteResult.RouteValues["action"]);
        }

        [Test]
        public void Should_Delete_ToDo_Item()
        {
            var mistakeToDo = ToDo.ThingsToBeDone[0];

            var redirectToRouteResult = (RedirectToRouteResult)new ToDoController().Delete(mistakeToDo.Title);

            Assert.IsFalse(ToDo.ThingsToBeDone.Contains(mistakeToDo));

            Assert.AreEqual("Index", redirectToRouteResult.RouteValues["action"]);
        }

        [Test]
        public void Should_Load_ToDo_Item_For_Editing()
        {
            var editToDo = ToDo.ThingsToBeDone[0];
            var viewResult = (ViewResult)new ToDoController().Edit(editToDo.Title);

            Assert.AreEqual(editToDo, viewResult.ViewData.Model);
        }

        [Test]
        public void Should_Edit_ToDo_Item()
        {
            var editedToDo = new ToDo { Title = "Get A LOT MORE milk" };

            var resirectToResult = (RedirectToRouteResult)new ToDoController().Edit("Get Milk", editedToDo);

            Assert.Contains(editedToDo, ToDo.ThingsToBeDone);

            Assert.AreEqual("Index", resirectToResult.RouteValues["action"]);
        }
    }
}
