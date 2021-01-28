using Newtonsoft.Json;

namespace OCPAfter.JSONCommonConverter
{
    public class JsonCommonConverter<Policy> : IJsonCommonConverter<Policy>
    {
        public Policy Deserialize(string policyJson, Newtonsoft.Json.JsonConverter converter)
        {
           return JsonConvert.DeserializeObject<Policy>(policyJson, converter);
        }
    }    
}