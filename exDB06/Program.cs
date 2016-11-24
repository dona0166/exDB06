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
            Console.WriteLine("Choose a method: (1) Insert Pet, (2) Get Pet, (3) Insert Owner, (4) Get Owner By Last Name, (5) Get Owner By Email, (0) Close application");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    prog.InsertPet(); break;
                case "2":
                    prog.GetPet(); break;
                case "3":
                    prog.InsertOwner(); break;
                case "4":
                    prog.GetOwnerByLastName(); break;
                case "5":
                    prog.GetOwnerById(); break;
                case "0":
                    break;
               


            }
            
        }

        private void InsertPet()
        {
            Console.Clear();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insertPet", con);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                    cmd.Parameters.Add(new SqlParameter("@PetName", PetName));
                    cmd.Parameters.Add(new SqlParameter("@PetType", PetType));
                    cmd.Parameters.Add(new SqlParameter("@PetBreed", PetBreed));
                    cmd.Parameters.Add(new SqlParameter("@PetDOB", PetDOB));
                    cmd.Parameters.Add(new SqlParameter("@PetWeight", PetWeight));
                    cmd.Parameters.Add(new SqlParameter("@OwnerId", OwnerId));

                    cmd.ExecuteNonQuery();
                    
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
            Console.Clear();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    

                    SqlCommand cmd = new SqlCommand("getOwner", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

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
            Console.Clear();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insertOwner", con);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                    
                    cmd.Parameters.Add(new SqlParameter("@OwnerLastName", OwnerLastName));
                    cmd.Parameters.Add(new SqlParameter("@OwnerFirstName", OwnerFirstName));
                    cmd.Parameters.Add(new SqlParameter("@OwnerPhone", OwnerPhone));
                    cmd.Parameters.Add(new SqlParameter("@OwnerEmail", OwnerEmail));

                    cmd.ExecuteNonQuery();

                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS" + e.Message);
                }
                Console.ReadKey();
            }
        }

        private void GetOwnerByLastName()
        {
            Console.Clear();
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("getOwnerByLastName", con);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.Write("Please, insert the Last Name:");
                string LastName = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@LastName", LastName));

                try
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string id = reader["OwnerId"].ToString();
                            string ownerlastname = reader["OwnerLastName"].ToString();
                            string ownerfirstname = reader["OwnerFirstName"].ToString();
                            string ownerphone = reader["OwnerPhone"].ToString();
                            string owneremail = reader["OwnerEmail"].ToString();
                            Console.WriteLine(id + " " + ownerlastname + " " + ownerfirstname + " " + ownerphone+ " " + owneremail);
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

        private void GetOwnerByEmail()
        {
            Console.Clear();
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("getOwnerByEmail", con);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.Write("Please, insert the Email Adress:");
                string Email = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@Email", Email));

                try
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string id = reader["OwnerId"].ToString();
                            string ownerlastname = reader["OwnerLastName"].ToString();
                            string ownerfirstname = reader["OwnerFirstName"].ToString();
                            string ownerphone = reader["OwnerPhone"].ToString();
                            string owneremail = reader["OwnerEmail"].ToString();
                            Console.WriteLine(id + " " + ownerlastname + " " + ownerfirstname + " " + ownerphone + " " + owneremail);
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




    }
}
