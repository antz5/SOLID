namespace OCPAfter.JSONCommonConverter
{
    public interface IJsonCommonConverter<T>
    {
        T Deserialize (string policyJson , Newtonsoft.Json.JsonConverter converter);
    }
}