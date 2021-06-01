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
            Assert.IsTrue(GPU_Repo.ReadID(0) != null);
        }

        [Test]
        public void CanUpdateGPUElements()
        {
            Repo GPU_Repo = new Repo();
            GPU_Repo.Update(GPU_Repo.GetGPUFromUserInput("0"), "test_brand", "test_name", 4, 4, 4);
            Assert.IsTrue(GPU_Repo.GetGPUFromUserInput("0").Brand == "test_brand");
        }

        [Test]
        public void CanDeleteGPU()
        {
            Repo GPU_Repo = new Repo();
            GPU_Repo.Delete(GPU_Repo.GetGPUFromUserInput("0"));
            Assert.IsTrue(GPU_Repo.ReadID(0) == null);
        }
    }
}