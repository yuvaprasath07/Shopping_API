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
                        command.Parameters.AddWithValue("@cartid", addcart.cartid);
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
    }
}
