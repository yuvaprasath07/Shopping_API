using Microsoft.Data.SqlClient;
using ShoppingEcomerceCommon.Model;
using ShoppingEcommerceRepo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcommerceRepo.Repositry
{
    public class categroyrepo : Icategroyrepo
    {
        public Dictionary<int, string> categroylookup()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Databasesetting.connectionstring))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("shm.GetTopCategories", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            Dictionary<int, string> data = new Dictionary<int, string>();

                            while (reader.Read())
                            {
                                int categoryId = reader.GetInt32(reader.GetOrdinal("CategoryId"));
                                string category = reader.GetString(reader.GetOrdinal("Category"));

                                // Add to the dictionary
                                data.Add(categoryId, category);
                            }

                            return data;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                // Log or handle the SQL exception appropriately.
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Handle other exceptions as needed.
                return null;
            }
        }

    }

}

