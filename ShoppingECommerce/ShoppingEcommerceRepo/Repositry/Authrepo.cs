using Microsoft.Data.SqlClient;
using ShoppingEcomerceCommon.Model;
using ShoppingEcomerceCommon.Model.Viewmodel;
using ShoppingEcommerceRepo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcommerceRepo.Repositry
{
    public class Authrepo : IAuthrepo
    {
        public async Task<bool> Register(RegisterShoppingVM RegisterModel)
        {
            try
            {
                int returnValue;
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = Databasesetting.connectionstring;

                    await con.OpenAsync();

                    using (SqlCommand command = new SqlCommand("shm.sp_InsertRegisterShopping", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Name", RegisterModel.Name);
                        command.Parameters.AddWithValue("@Mobilenumber", RegisterModel.Mobilenumber);
                        command.Parameters.AddWithValue("@Email", RegisterModel.Email);
                        command.Parameters.AddWithValue("@Password", RegisterModel.password); 
                        command.Parameters.AddWithValue("@Role", RegisterModel.Role);

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

        public async Task<RegisterShoppingVM> Login(LoginModel loginModel)
        {
            RegisterShoppingVM result = new RegisterShoppingVM();
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = Databasesetting.connectionstring;

                    using (SqlCommand command = new SqlCommand("shm.sp_Login", con))
                    {
                        await con.OpenAsync();

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@Email", loginModel.EmailId);
                        command.Parameters.AddWithValue("@Password", loginModel.Password);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                result.Id = reader["registerid"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["registerid"]);
                                result.Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString();
                                result.Email = reader["Email"] is DBNull ? null : reader["Email"].ToString();
                                result.Mobilenumber = reader["Mobilenumber"] is DBNull ? null : reader["Mobilenumber"].ToString();
                                result.Role = reader["role"] is DBNull ? null : reader["role"].ToString();
                                //result.password = reader["password"] is DBNull ? null : reader["password"].ToString();
                                //result.password = reader.GetString("password");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return result;
        }
    }
}
