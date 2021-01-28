using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SRP1;

namespace SRP1_after.JSONCommonConverter
{
    public class JsonCommonConverter<Policy> : IJsonCommonConverter<Policy>
    {
        public Policy Deserialize(string policyJson, Newtonsoft.Json.JsonConverter converter)
        {
           return JsonConvert.DeserializeObject<Policy>(policyJson, converter);
        }
    }    
}