using SRP1;
using SRP1_after.Logger;

namespace SRP1_after.BusinessLogic
{
    public class LandPolicy
    {
        private readonly ILogging _logging;

        public LandPolicy(ILogging logging)
        {
            _logging = logging;
        }
        public decimal Rate(Policy policy)
        {

            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _logging.Log("Land policy must specify Bond Amount and Valuation.");
                return 0M;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _logging.Log("Insufficient bond amount.");
                return 0M;
            }
            return policy.BondAmount * 0.05m;
        }
    }
}