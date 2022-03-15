using CommonAccesslayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Data;

namespace DataAccesslayer
{
    public class EmployeeDataAccessDb
    {
        private DbConnection db = new DbConnection();
        public List<Employees> GetEmployees()
        {
            string query = "select* from employees";
            SqlCommand command=new SqlCommand();
            command.CommandText = query;
            command.Connection = db.cnn;
            if (db.cnn.State == System.Data.ConnectionState.Closed)
                db.cnn.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Employees> employees = new List<Employees>();
            while (reader.Read())
            {
                Employees emp = new Employees();
                emp.ID = (int)reader["ID"];
                emp.Name = reader["Name"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.Mobile = reader["Mobile"].ToString();
                emp.Gender = reader["Gender"].ToString();
                employees.Add(emp);
            }
            db.cnn.Close();
            return employees;
        }
        public Employees GetEmployeesById(int id)
        {
            string query = "select* from employees where ID='"+id+"'";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = db.cnn;
            if (db.cnn.State == System.Data.ConnectionState.Closed)
                db.cnn.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            reader.Read();
            
                Employees emp = new Employees();
                emp.ID = (int)reader["ID"];
                emp.Name = reader["Name"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.Mobile = reader["Mobile"].ToString();
                emp.Gender = reader["Gender"].ToString();
                
            
            db.cnn.Close();
            return emp;
        }
        public bool CreateEmployee(Employees employee)
        {
            string query="insert into Employees values('"+employee.Name+"','"+employee.Email+"','"+employee.Mobile+"','"+employee.Gender+"')";
            SqlCommand cmd = new SqlCommand(query, db.cnn);
            if (db.cnn.State == System.Data.ConnectionState.Closed)
                db.cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.cnn.Close();
            return Convert.ToBoolean(i);
        }
        public bool DeleteEmployee(int id)
        {
            string query = "Delete from Employees where id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query,db.cnn);
            if (db.cnn.State == System.Data.ConnectionState.Closed)
                db.cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.cnn.Close();

            return Convert.ToBoolean (i);
        }
        public bool UpdateEmployee(Employees employees)
        {
            string query = "Update Employees set Name='"+employees.Name+"','"+employees.Email+"','"+employees.Mobile+"','"+employees.Gender+"' where id='"+employees.ID+"'";
            SqlCommand cmd = new SqlCommand(query, db.cnn);
            if (db.cnn.State == System.Data.ConnectionState.Closed)
                db.cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.cnn.Close();
            return Convert.ToBoolean(i);
        }
    }
}
