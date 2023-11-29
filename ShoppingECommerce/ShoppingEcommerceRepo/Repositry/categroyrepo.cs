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
        public List<Dictionary<string, object>> categroylookup()
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
                            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

                            while (reader.Read())
                            {
                                int categoryId = reader.GetInt32(reader.GetOrdinal("CategoryId"));
                                string category = reader.GetString(reader.GetOrdinal("Category"));

                                var categoryData = new Dictionary<string, object>
                                {
                                    { "id", categoryId },
                                    { "name", category }
                                };

                                data.Add(categoryData);
                            }

                            return data;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }


    }

}

