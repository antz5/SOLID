using System;
using OCPBefore;
using OCPBefore.Logger;

namespace OCPBefore.BusinessLogic
{
    public class LifePolicy
    {
        private readonly ILogging _logging;

        public LifePolicy(Logger.ILogging logging)
        {
            _logging = logging;
        }
        public decimal Rate(Policy policy)
        {
            var rate = 0M;
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                _logging.Log("Life policy must include Date of Birth.");
                return 0;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                _logging.Log("Centenarians are not eligible for coverage.");
                return 0;
            }
            if (policy.Amount == 0)
            {
                _logging.Log("Life policy must include an Amount.");
                return 0;
            }
            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
            {
                rate = baseRate * 2;
                return rate;
            }

            return baseRate;
        }
    }
}