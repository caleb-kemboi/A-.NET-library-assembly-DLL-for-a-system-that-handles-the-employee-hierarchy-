using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeLib;

namespace TestEmployees
{
	[TestClass]

	public class EmployeeTest
	{
		[TestMethod]
		public void TestAnInvalidCSVListIsInput()
		{
			Assert.ThrowsException<Exception>(() => new Employees(""));

		}

		[TestMethod]
		public void TestOneEmployessReportsToMoreThanoneManger()
		{
			Assert.ThrowsException<Exception>(() => new Employees("John,manager1,100\n" +
				
				"Caleb,manager1," + //error
				"1900\nJames,manager2,100\n" +
				"Caleb,manager3,1900" + //error
				"\nCEO,,1000 \n " +
				"manager1,CEO,1900\n" +
				"manager3,CEO,1900\nsalasia,manager1,1900\nmanager2,CEO,1900"));

		}

		[TestMethod]
		public void TestWhenWehaveMoreThanOneCEO()
		{
			Assert.ThrowsException<Exception>(() => new Employees("John,manager1,100\n" +
				"Caleb,manager1," +
				"1900\nJohn,manager2,100\n" +
				"Anne,,1900" + // error
				"\nCEO,,1000 \n " + // error
				"manager1,CEO,1900\n" +
				"manager3,CEO,1900\nsalasia,manager1,1900\nmanager2,CEO,1900"));

		}

		[TestMethod]
		public void TestExceptionCircularReference()
		{
			Assert.ThrowsException<Exception>(() => new Employees("John,manager1,100\n" +
				"Caleb,manager1," +
				"1900\nJohn,manager2,100\n" +
				"Anne,manager1,1900" +
				"\nCEO,,1000 \n " +
				"manager1,CEO,1900\n" +
				"manager2,manager1,1900\n" + // error
	"Esther,manager1,1900\nmanager2,CEO,1900"));

		}

		[TestMethod]
		public void TestManagersNotListedInEmployessCell()
		{
			Assert.ThrowsException<Exception>(() => new Employees("John,manager1,100\n" +
				"Caleb,manager1," +
				"1900\nJames,manager2,100\n" +
				"Anne,manager5,1900" + //error
				"\nCEO,,1000 \n " +
				"manager1,CEO,1900\n" +
				"employess,manager1,1900\nsalasia,manager1,1900\nmanager2,CEO,1900"));

		}

		[TestMethod]
		public void TestTotalManagerBudgetIsCorrect()
		{

			Employees testEmployee = new Employees("John,manager1,100\n" +
				"Caleb,manager1," +
				"1900\nJames,manager2,100\n" +
				"Anne,manager1,1900" +
				"\nCEO,,1000 \n " +
				"manager1,CEO,1900\n" +
				"employess,manager1,1900\nsalasia,manager1,1900\nmanager2,CEO,1900");

			Assert.AreEqual(4800, testEmployee.managerSalaryBudget("CEO"));

		}
	}
}