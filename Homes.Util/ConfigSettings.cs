using System.Configuration;

namespace Homes.Util
{
    public class ConfigSettings
    {
        public static string ConnectionStringName
        {
            get
            {
                var conString = ConfigurationManager.ConnectionStrings["CodedHomes_Connectionstring"] != null ? ConfigurationManager.ConnectionStrings["CodedHomes_Connectionstring"].ToString() : "DefaultConnection";
                return conString;
            }
        }

        //Simple memebrship needs to know the User table and the primary key Column fields too
        public static string UserTableName
        {
            get
            {
                var usrTable = ConfigurationManager.AppSettings["UsersTableName"] != null ? ConfigurationManager.AppSettings["UsersTableName"].ToString() : "Users";
                return usrTable;
            }
        }

        public static string UserPrimaryKeyColumnName
        {
            get
            {
                var usrPrimaryKey = ConfigurationManager.AppSettings["UserPrimaryKeyColumnName"] != null ? ConfigurationManager.AppSettings["UserPrimaryKeyColumnName"].ToString() : "Id";
                return usrPrimaryKey;
            }
        }
    }
}