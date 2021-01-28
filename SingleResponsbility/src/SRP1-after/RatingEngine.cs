using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SRP1_after.BusinessLogic;
using SRP1_after.JSONCommonConverter;
using SRP1_after.Logger;
using SRP1_after.Persistence;

namespace SRP1
{
    public class RatingEngine
    {
        private readonly ILogging _logging;
        private readonly IFilePersistence _filePersistence;
        private readonly IJsonCommonConverter<Policy> _jsonCommonConverter;

        public RatingEngine(ILogging logging, IFilePersistence filePersistence, IJsonCommonConverter<Policy> jsonCommonConverter)
        {
            _logging = logging;
            _filePersistence = filePersistence;
            _jsonCommonConverter = jsonCommonConverter;
        }
        public decimal Rating { get; set; }
        public void Rate()
        {
            _logging.Log("Starting rate.");

            _logging.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = _filePersistence.GetPolicyFromSource();

            var policy = _jsonCommonConverter.Deserialize(policyJson, new StringEnumConverter());

            switch (policy.Type)
            {
                case PolicyType.Auto:
                    _logging.Log("Rating AUTO policy...");
                    _logging.Log("Validating policy.");
                    Rating = new AutoPolicy(_logging).Rate(policy);
                    _logging.Log($"Policy Type : {PolicyType.Auto} :: Rating: {Rating}");
                    break;

                case PolicyType.Land:
                    _logging.Log("Rating LAND policy...");
                    _logging.Log("Validating policy.");

                    Rating = new LandPolicy(_logging).Rate(policy);
                    _logging.Log($"Policy Type : {PolicyType.Land} :: Rating: {Rating}");
                    break;

                case PolicyType.Life:
                    _logging.Log("Rating LIFE policy...");
                    _logging.Log("Validating policy.");

                    Rating = new LifePolicy(_logging).Rate(policy);
                    _logging.Log($"Policy Type : {PolicyType.Life} :: Rating: {Rating}");
                    break;
                default:
                    _logging.Log("Unknown policy type");
                    break;
            }

            _logging.Log("Rating completed.");
        }
    }
}