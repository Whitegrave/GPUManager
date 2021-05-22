using NUnit.Framework;
using Controllers;
using Data;
using Models;
using Views;

namespace Unit_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
 
        [Test]
        public void CanSetMenuByInt()
        {
            View UserInterface = new View();
            UserInterface.SetMenu(2);
            Assert.IsTrue(UserInterface.GetMenu() == MenuPage.ReadAll);
        }

        [Test]
        public void CanSetMenuExplicitly()
        {
            View UserInterface = new View();
            UserInterface.SetMenu(MenuPage.ReadAll);
            Assert.IsTrue(UserInterface.GetMenu() == MenuPage.ReadAll);
        }

        [Test]
        public void GPUArrayPopulated()
        {
            Repo GPU_Repo = new Repo();
            Assert.IsTrue(GPU_Repo.GPU_Data[0].Repo_ID == 1);
        }
    }
}