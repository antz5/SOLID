using OCPAfter;
using OCP_after.BusinessLogic;
using OCPAfter.Logger;

namespace OCPAfter.BusinessLogic
{
    public class LandPolicy: IRating
    {
        private readonly ILogging _logging;
        private readonly RatingEngine _engine;

        public LandPolicy(RatingEngine engine, ILogging logging)
        {
            _logging = logging;
            _engine = engine;
        }
        public void Rate(Policy policy)
        {
            _logging.Log("Rating LAND policy...");
            _logging.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _logging.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _logging.Log("Insufficient bond amount.");
                return;
            }
            _engine.Rating = policy.BondAmount * 0.05m;
            _logging.Log($"Policy Type : {PolicyType.Land} :: Rating: {_engine.Rating}");
        }
    }
}