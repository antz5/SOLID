using System;
using OCP_after.BusinessLogic;
using OCPAfter.Logger;

namespace OCPAfter.BusinessLogic
{
    public class LifePolicy: IRating
    {
        private readonly ILogging _logging;
        private readonly RatingEngine _engine;
        public LifePolicy(RatingEngine engine, ILogging logging)
        {
            _logging = logging;
            _engine = engine;
        }       

        public void Rate(Policy policy)
        {
            _logging.Log("Rating LIFE policy...");
            _logging.Log("Validating policy.");
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                _logging.Log("Life policy must include Date of Birth.");
                return;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                _logging.Log("Centenarians are not eligible for coverage.");
                return;
            }
            if (policy.Amount == 0)
            {
                _logging.Log("Life policy must include an Amount.");
                return;
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
                _engine.Rating = baseRate * 2;
                return;
            }
            _engine.Rating = baseRate;
            _logging.Log($"Policy Type : {PolicyType.Life} :: Rating: {_engine.Rating}");
        }
    }
}