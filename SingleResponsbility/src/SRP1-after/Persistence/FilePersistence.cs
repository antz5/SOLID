using System.IO;

namespace SRP1_after.Persistence
{
    
    public class FilePersistence : IFilePersistence
    {
        const string fileName = "policy.json";
        public string GetPolicyFromSource()
        {            
            return File.ReadAllText(fileName);
        }
    }
}