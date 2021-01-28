using OCPAfter;
using OCP_after.BusinessLogic;
using OCPAfter.Logger;


namespace OCPAfter.BusinessLogic
{
    public class AutoPolicy : IRating
    {
        private readonly ILogging _logging;
        private readonly RatingEngine _engine;

        public AutoPolicy(RatingEngine engine, ILogging logging)
        {
            _logging = logging;
            _engine = engine;
        }
        public void Rate(Policy policy)
        {
            _logging.Log("Rating AUTO policy...");
            _logging.Log("Validating policy.");
            if (string.IsNullOrEmpty(policy.Make))
            {
                _logging.Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _engine.Rating = 1000m;
                }
                _engine.Rating = 900m;
            }
            _logging.Log($"Policy Type : {PolicyType.Auto} :: Rating: {_engine.Rating}");
        }
    }
}