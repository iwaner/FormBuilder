using System.Configuration;

namespace FormBuilder.DataAccess
{
    public class DataAccessBase
    {
        #region Properties
        static private string _connectionString = string.Empty;
        static public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                    _connectionString = ConfigurationManager.ConnectionStrings["FormBuilderConnection"].ConnectionString;
                return _connectionString;
            }
        }
        #endregion
    }
}
