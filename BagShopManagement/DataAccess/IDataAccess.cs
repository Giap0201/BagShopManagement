using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BagShopManagement.DataAccess
{
    public interface IDataAccess
    {
        DataTable ExecuteQuery(string query, params SqlParameter[] parameters);
        int ExecuteNonQuery(string query, params SqlParameter[] parameters);
        object? ExecuteScalar(string query, List<SqlParameter>? parameters = null);
    }
}
