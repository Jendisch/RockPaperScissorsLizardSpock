﻿
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class SQLConnection
    {

        SqlConnection conn;
        string table;

        public string CreateConnection()

        {
            using (conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=RockPaperScissorsLizardSpock;Trusted_Connection=True";
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Player_Name, Count(Wins) Total_Wins FROM RPSLS_Table GROUP BY Player_Name ORDER BY Total_Wins DESC", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StringBuilder builder = new StringBuilder();
                        string name = reader.GetString(0);
                        int wins = reader.GetInt32(1);
                        table += builder.AppendFormat("{0} has {1} total wins\n", name, wins);
                        //Below is another way of concating strings together... use method above ^^ whenever possible
                        //table += String.Format("{0} has {1} wins \n", reader.GetString(0), reader.GetInt32(1));
                    }
                }
                return table;
            }
        }

        



        public void InsertData(string playerName, int wins)
        {
            using (conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=RockPaperScissorsLizardSpock;Trusted_Connection=True";
                conn.Open();
                string query = "INSERT INTO RPSLS_Table (Player_Name, Wins) VALUES (@Player_Name, @Wins)";
                SqlCommand insertCommand = new SqlCommand(query, conn);
                insertCommand.Parameters.AddWithValue("@Player_Name", playerName);
                insertCommand.Parameters.AddWithValue("@Wins", wins);

                insertCommand.ExecuteNonQuery();

            }
        }
    }
}


