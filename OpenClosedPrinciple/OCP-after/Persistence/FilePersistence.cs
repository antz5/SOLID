using System.IO;

namespace OCPAfter.Persistence
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