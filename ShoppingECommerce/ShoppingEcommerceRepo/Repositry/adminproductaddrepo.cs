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
    public class adminproductaddrepo : Iadminproductaddrepo
    {
        public async Task<bool> adminproductadd(AddproductadminDB AddproductadminModel)
        {
            try
            {
                int returnValue;
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = Databasesetting.connectionstring;

                    await con.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.InsertAdminProduct", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@price", AddproductadminModel.price);
                        command.Parameters.AddWithValue("@model", AddproductadminModel.model);
                        command.Parameters.AddWithValue("@Description", AddproductadminModel.Description);
                        command.Parameters.AddWithValue("@category", AddproductadminModel.category);
                        command.Parameters.AddWithValue("@Imagefilepath", AddproductadminModel.Imagefilepath);

                        SqlParameter resultParameter = new SqlParameter("@ReturnValue", SqlDbType.Int);
                        resultParameter.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(resultParameter);

                        await command.ExecuteNonQueryAsync();

                        returnValue = (int)resultParameter.Value;
                    }

                    await con.CloseAsync();

                    return returnValue == 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<AddproductadminDB> productget()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Databasesetting.connectionstring))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("shm.GetProductInfo", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            List<AddproductadminDB> data = new List<AddproductadminDB>();

                            while (reader.Read())
                            {
                                int productId = reader.GetInt32(reader.GetOrdinal("productId"));
                                int price = reader.GetInt32(reader.GetOrdinal("price"));
                                string model = reader.GetString(reader.GetOrdinal("model"));
                                string Description = reader.GetString(reader.GetOrdinal("Description"));
                                int category = reader.GetInt32(reader.GetOrdinal("category"));
                                string Imagefilepath = reader.GetString(reader.GetOrdinal("Imagefilepath"));

                                AddproductadminDB addproductadmin = new AddproductadminDB
                                {
                                    Id = productId,
                                    price = price,
                                    model = model,
                                    Description = Description,
                                    category = category,
                                    Imagefilepath = Imagefilepath
                                };

                                data.Add(addproductadmin);
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
