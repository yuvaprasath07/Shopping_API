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
    public class Addcartrepo : Iaddcartrepo
    {
        public async Task<bool> addpcart(Addcart addcart)
        {
            try
            {
                int returnValue;
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = Databasesetting.connectionstring;

                    await con.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.InsertIntoAddcart", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@productcartid", addcart.productcartid);
                        command.Parameters.AddWithValue("@userid", addcart.userid);

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

        public async Task<List<cartGet>> cartget()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Databasesetting.connectionstring))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("dbo.GetShoppingData", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            List<cartGet> data = new List<cartGet>();

                            while (reader.Read())
                            {
                                int registerid = reader.GetInt32(reader.GetOrdinal("registerid"));
                                string Name = reader.GetString(reader.GetOrdinal("Name"));
                                int price = reader.GetInt32(reader.GetOrdinal("price"));
                                string model = reader.GetString(reader.GetOrdinal("model"));
                                string Description = reader.GetString(reader.GetOrdinal("Description"));
                                string Imagefilepath = reader.GetString(reader.GetOrdinal("Imagefilepath"));

                                cartGet addproductadmin = new cartGet
                                {
                                    registerid = registerid,
                                    Name = Name,
                                    price = price,
                                    model = model,
                                    Description = Description,
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

