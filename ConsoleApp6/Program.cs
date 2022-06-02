using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ConApp1
{
    class program
    {
     
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1. Display");
                Console.WriteLine("2. Add Employee");
                Console.WriteLine("3. Modify Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");
                Console.Write("\nEnter Your Choice :");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        ShowAll();
                        break;
                    case 2:
                        AddRecord();
                        break;
                    case 3:
                        UpdateRecord();
                        break;
                    case 4:
                        DeleteRecord();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid Choide");
                        break;
                }
            } while (true);
        }

        private static void AddRecord()
        {

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source =localhost ; Integrated Security = true ; Initial Catalog =  nexturn ";
            int emp_id;
            string emp_fname;
            string emp_lname;
            int salary;
            Console.WriteLine("enter ID");
            emp_id = int.Parse(Console.ReadLine());
            Console.Write("Enter first name:");
            emp_fname = Console.ReadLine();
            Console.Write("Enter last name :");
            emp_lname = Console.ReadLine();
            Console.WriteLine("Enter salary");
            salary = int.Parse(Console.ReadLine());

            string query = "insert into employee values("+emp_id+",'" + emp_fname + "', '" + emp_lname + "'," + salary + ")";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            Console.WriteLine("Record Added");
        }
        private static void ShowAll()
        {

            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlConnection.ConnectionString = "Data Source =localhost ; Integrated Security = true ; Initial Catalog =  nexturn ";

            //  sqlConnection.ConnectionString = "Data source= localhost; user id=phani-laptop; password=a ; Initial Catalog= testdb";
            //sqlConnection.ConnectionString = ConfigurationSettings.AppSettings["connectionString"];

            sqlCommand.CommandText = "select * from employee";
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter.SelectCommand = sqlCommand;
            
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Console.WriteLine(dataTable.Rows[i][0] + "\t" + dataTable.Rows[i][1] + "\t" + dataTable.Rows[i][2] + "\t" + dataTable.Rows[i][3]);
            }
          
        }
        private static void UpdateRecord()
        {
            SqlConnection sqlConnection = new SqlConnection();
           // SqlCommand sqlCommand1 = new SqlCommand();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            sqlConnection.ConnectionString = "Data Source =localhost ; Integrated Security = true ; Initial Catalog =  nexturn ";
            int emp_id;
            string emp_fname;
            string emp_lname;
            int salary;
            Console.WriteLine("enter ID");
            emp_id = int.Parse(Console.ReadLine());
            Console.Write("Enter new first name:");
            emp_fname = Console.ReadLine();
            Console.Write("Enter new last name :");
            emp_lname = Console.ReadLine();
            Console.WriteLine("Enter new salary");
            salary = int.Parse(Console.ReadLine());
            //sqlCommand1.CommandType = CommandType.Text;
            SqlCommand sqlCommand = new SqlCommand("update employee set emp_fname=@emp_fname,emp_lname=@emp_lname where emp_id=@emp_id ", sqlConnection);

            //sqlCommand1.CommandText = "update employee set emp_fname=@emp_fname,emp_lname=@emp_lname where emp_id=@emp_id ";
           // string query = "update employee set emp_fname=@emp_fname,emp_lname=@emp_lname,salary=@salary where emp_id=@emp_id";
            //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@emp_id", emp_id);
            sqlCommand.Parameters.AddWithValue("@emp_fname", emp_fname);
            sqlCommand.Parameters.AddWithValue("@emp_lname", emp_lname);
            sqlCommand1.Parameters.AddWithValue("@salary", salary);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            Console.WriteLine("Record updated ");

        }
        private static void DeleteRecord()
        {
            SqlConnection sqlConnection = new SqlConnection();
            // SqlCommand sqlCommand1 = new SqlCommand();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            sqlConnection.ConnectionString = "Data Source =localhost ; Integrated Security = true ; Initial Catalog =  nexturn ";
            int emp_id;
            //string emp_fname;
            //string emp_lname;
            //int salary;
            Console.WriteLine("enter ID");
            emp_id = int.Parse(Console.ReadLine());
            //Console.Write("Enter new first name:");
            //emp_fname = Console.ReadLine();
            //Console.Write("Enter new last name :");
            //emp_lname = Console.ReadLine();
            //Console.WriteLine("Enter new salary");
            //salary = int.Parse(Console.ReadLine());
            //sqlCommand1.CommandType = CommandType.Text;
            SqlCommand sqlCommand = new SqlCommand("delete from employee where emp_id=@emp_id ", sqlConnection);

            //sqlCommand1.CommandText = "update employee set emp_fname=@emp_fname,emp_lname=@emp_lname where emp_id=@emp_id ";
            // string query = "update employee set emp_fname=@emp_fname,emp_lname=@emp_lname,salary=@salary where emp_id=@emp_id";
            //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@emp_id", emp_id);
            //sqlCommand.Parameters.AddWithValue("@emp_fname", emp_fname);
            //sqlCommand.Parameters.AddWithValue("@emp_lname", emp_lname);
            //  sqlCommand1.Parameters.AddWithValue("@salary", salary);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            Console.WriteLine("Record deleted ");

        }
    }
}
