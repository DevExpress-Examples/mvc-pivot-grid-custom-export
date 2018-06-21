using System.Data;
using System.Data.OleDb;
using System.Web;

namespace MVCxPivotGrid_CustomExport.Models
{
    public class NwindModel
    {
        public static DataTable GetData()
        {
            DataTable dataTableInvoices = new DataTable();
            using (OleDbConnection connection = GetConnection())
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Empty, connection);
                adapter.SelectCommand.CommandText = "SELECT * FROM [SalesPerson]";
                adapter.Fill(dataTableInvoices);
            }
            return dataTableInvoices;
        }

        static OleDbConnection GetConnection()
        {
            OleDbConnection connection = new OleDbConnection();
            //Jet 4
            //connection.ConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", HttpContext.Current.Server.MapPath("~/App_Data/nwind.mdb"));
            //OLEDB 12
            connection.ConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", HttpContext.Current.Server.MapPath("~/App_Data/nwind.mdb"));
            return connection;
        }
    }
}