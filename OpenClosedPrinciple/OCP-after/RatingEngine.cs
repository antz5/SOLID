using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OCP_after.Factory;
using OCPAfter.BusinessLogic;
using OCPAfter.JSONCommonConverter;
using OCPAfter.Logger;
using OCPAfter.Persistence;

namespace OCPAfter
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

            var raterFactory = new RatingFactory(_logging);
            var rater = raterFactory.Create(policy, this);
            rater.Rate(policy);          

            _logging.Log("Rating completed.");
        }
    }
}