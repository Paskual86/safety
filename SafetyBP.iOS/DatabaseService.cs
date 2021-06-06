using System;
using System.IO;
using SafetyBP.Core.Constants;
using SafetyBP.Core.Interfaces;
using SafetyBP.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace SafetyBP.iOS
{
    public class DatabaseService : IDatabaseService
    {
        public DatabaseService()
        {

        }

        public string GetDbPath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                DbConstants.DB_NAME);
        }
    }
}
