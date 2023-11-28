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
        public async Task<bool> adminproductadd(Addproductadmin AddproductadminModel)
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

    }
}
