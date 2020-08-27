using System;

namespace Tools.Database
{
    public class ConnectionInfo
    {
        private readonly string _ConnectionString;

        public string ConnectionString
        {
            get { return _ConnectionString; }
        }

        public ConnectionInfo(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _ConnectionString = connectionString;
        }
    }
}
