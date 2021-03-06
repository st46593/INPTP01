﻿using NUnit.Framework;
using INPTP_AppForFixing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INPTP_AppForFixing.Tests
{
    [TestFixture()]
    public class BossTests
    {
        [Test()]
        public void BossWithoutSubEmplSalaryBonusTest()
        {
            Boss boss = new Boss(new Department())
            {
                salary = 1000
            };
            boss.InsertEmpl(new EmployeeClass());

            Assert.AreEqual(12000, boss.YearlySalary());
        }

        [Test()]
        public void BossWithOneSubEmplSalaryBonusTest()
        {
            Boss boss = new Boss(new Department())
            {
                salary = 1000
            };
            boss.SetSalaryBonus(100);
            boss.InsertEmpl(new EmployeeClass());

            Assert.AreEqual(12000 + 1200, boss.YearlySalary());
        }


        [Test()]
        public void BossCanHaveSubemployeesTest()
        {
            EmployeeClass empl;
            Boss boss = new Boss(new Department());
            boss.InsertEmpl(empl = new EmployeeClass());

            Assert.IsTrue(boss.HasEmployee(empl));
        }

        [Test()]
        public void BossIsAbleToCountSubemployeesTest()
        {
            Boss boss = new Boss(new Department());
            boss.InsertEmpl(new EmployeeClass());
            boss.InsertEmpl(new EmployeeClass());
            boss.InsertEmpl(new EmployeeClass());

            Assert.AreEqual(3, boss.EmployeeCount);
        }

        [Test()]
        public void BossIsAbleToCountWithoutSubemployeesTest()
        {
            Boss boss = new Boss(new Department());

            Assert.AreEqual(0, boss.EmployeeCount);
        }

        [Test()]
        public void BossIsAbleToKickSubemployeeTest()
        {
            Boss boss = new Boss(new Department());
            EmployeeClass empl = new EmployeeClass();

            boss.InsertEmpl(empl);
            Assert.AreEqual(1, boss.EmployeeCount);
            Assert.IsTrue(boss.HasEmployee(empl));

            boss.PurgeEmpl(empl);
            Assert.AreEqual(0, boss.EmployeeCount);
        }

        [Test()]
        public void BossIsAbleToIgnoreForeignEmployeesTest()
        {
            Boss boss = new Boss(new Department());
            EmployeeClass empl = new EmployeeClass();

            Assert.AreEqual(0, boss.EmployeeCount);
            Assert.IsFalse(boss.HasEmployee(empl));
        }
    }
}