using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace exDB06
{
    class Program
    {
        private static string connectionString =
            "Server=ealdb1.eal.local;Database=ejl70_db;User Id=ejl70_usr;Password=Baz1nga70;";
        static void Main(string[] args)
        {
            
            Program prog = new exDB06.Program();
            Console.WriteLine("Choose a method: (1) Insert Pet, (2) Get Pet, (3) Insert Owner, (0) Close application");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    prog.InsertPet(); break;
                case "2":
                    prog.GetPet(); break;
                case "3":
                    prog.InsertOwner(); break;
                case "0":
                    break;
               


            }
            
        }

        private void InsertPet()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("insertPet", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    Console.Clear();
                    Console.WriteLine("Please, insert the parameters :");
                    Console.Write("PetName:");
                    string PetName = Console.ReadLine();
                    Console.Write("PetType:");
                    string PetType = Console.ReadLine();
                    Console.Write("PetBreed:");
                    string PetBreed = Console.ReadLine();
                    Console.Write("PetDOB:");
                    DateTime PetDOB = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("PetWeight:");
                    float PetWeight = float.Parse(Console.ReadLine());
                    Console.Write("OwnerId:");
                    int OwnerId = Convert.ToInt32(Console.ReadLine());
                    
                    cmd1.Parameters.Add(new SqlParameter("@PetName", PetName));
                    cmd1.Parameters.Add(new SqlParameter("@PetType", PetType));
                    cmd1.Parameters.Add(new SqlParameter("@PetBreed", PetBreed));
                    cmd1.Parameters.Add(new SqlParameter("@PetDOB", PetDOB));
                    cmd1.Parameters.Add(new SqlParameter("@PetWeight", PetWeight));
                    cmd1.Parameters.Add(new SqlParameter("@OwnerId", OwnerId));

                    cmd1.ExecuteNonQuery();
                    
                 }
                catch(SqlException e)
                {
                    Console.WriteLine("UPS" + e.Message);
                }
                Console.ReadKey();
            }
        }

        private void GetPet()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    

                    SqlCommand cmd2 = new SqlCommand("getOwner", con);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd2.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string id = reader["PetId"].ToString();
                            string petname = reader["PetName"].ToString();
                            string pettype = reader["PetType"].ToString();
                            string petbreed = reader["PetBreed"].ToString();
                            string petdob = reader["PetDOB"].ToString();
                            string petweight = reader["PetWeight"].ToString();
                            string ownerid = reader["OwnerId"].ToString();
                            Console.WriteLine(id + " " + petname + " " + pettype + " " + petbreed + " " + petdob + " " + petweight + " " + ownerid);

                        }

                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS" + e.Message);
                }
                Console.ReadKey();
            }
        }

        private void InsertOwner()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("insertOwner", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    Console.Clear();
                    Console.WriteLine("Please, insert the parameters :");
                    Console.Write("OwnerLastName:");
                    string OwnerLastName = Console.ReadLine();
                    Console.Write("OwnerFirstName:");
                    string OwnerFirstName = Console.ReadLine();
                    Console.Write("Owner Phone:");
                    string OwnerPhone = Console.ReadLine();
                    Console.Write("Owner Email");
                    string OwnerEmail = Console.ReadLine();
                    
                    cmd1.Parameters.Add(new SqlParameter("@OwnerLastName", OwnerLastName));
                    cmd1.Parameters.Add(new SqlParameter("@OwnerFirstName", OwnerFirstName));
                    cmd1.Parameters.Add(new SqlParameter("@OwnerPhone", OwnerPhone));
                    cmd1.Parameters.Add(new SqlParameter("@OwnerEmail", OwnerEmail));

                    cmd1.ExecuteNonQuery();

                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS" + e.Message);
                }
                Console.ReadKey();
            }
        }




    }
}
