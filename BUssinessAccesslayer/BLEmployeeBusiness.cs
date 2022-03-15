﻿
using CommonAccesslayer.Models;
using DataAccesslayer;
using System;
using System.Collections.Generic;

namespace BUssinessAccesslayer
{
    public class BLEmployeeBusiness
    {
        private EmployeeDataAccessDb employeeData;
        public BLEmployeeBusiness()
        {
            employeeData = new EmployeeDataAccessDb();
        }
       public List<Employees>GetEmployees()
        {
            return employeeData.GetEmployees();

        }
        public Employees GetEmployeeById(int id)
        {
            return employeeData.GetEmployeesById(id);
        }
        public bool DeleteEmployee(int id)
        {
            return employeeData.DeleteEmployee(id);
        }
        public bool CreateEmployee(Employees emp)
        {
            return employeeData.CreateEmployee(emp);
        }
        public bool UpdateEmployee(Employees emp)
        {
            return employeeData.UpdateEmployee(emp);
        }
    }
}
