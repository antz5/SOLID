using OCP_after.BusinessLogic;
using OCPAfter;
using OCPAfter.BusinessLogic;
using OCPAfter.Logger;

namespace OCP_after.Factory
{
    public class RatingFactory
    {
        private readonly ILogging _logging;
        public RatingFactory(ILogging logging)
        {
            _logging = logging;
        }
        public IRating Create (Policy policy, RatingEngine engine)
        {
            return policy.Type switch
            {
                PolicyType.Auto => new AutoPolicy(engine, _logging),
                PolicyType.Land => new LandPolicy(engine, _logging),
                PolicyType.Life => new LifePolicy(engine, _logging),
                _ => null,
            };            
        }
    }
}