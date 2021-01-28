using SRP1;
using SRP1_after.Logger;

namespace SRP1_after.BusinessLogic
{
    public class AutoPolicy
    {
        private readonly ILogging _logging;

        public AutoPolicy(ILogging logging)
        {
            _logging = logging;
        }
        public decimal Rate(Policy policy)
        {
            decimal rating =0M;
            if (string.IsNullOrEmpty(policy.Make))
            {
                _logging.Log("Auto policy must specify Make");
                return rating;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    rating = 1000m;
                }
                rating = 900m;
            }
            return rating;
        }
    }
}