﻿namespace UnitTestProject1.Definitions.Insurance
{
    using TechTalk.SpecFlow;
    using TestingContext.Interface;
    using UnitTestProject1.Entities;

    [Binding]
    public class InsuranceWhen
    {
        private readonly ITestingContext context;

        public InsuranceWhen(ITestingContext context)
        {
            this.context = context;
        }

        [When(@"insurance(?:\s)?(.*) resolves")]
        public void WhenInsuranceResolves(string key)
        {
            var value = context.All<Insurance>(key);
        }
    }
}
