using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSMSpecsTrialRun
{
    [TestClass]
    public partial class when_transferring_between_two_accounts
    {
        static new Dictionary<string, Action> __results = new Dictionary<string, Action>();
        
        [ClassInitialize]
        public static void _Setup(TestContext context)
        {
            MSMSpec.TestExecutionHelper.Process<when_transferring_between_two_accounts>(__results);
        }
        
        [TestMethod]
        public void It_should_debit_the_from_account_by_the_amount_transferred()
        {
            __results["should_debit_the_from_account_by_the_amount_transferred"]();
        }
        
        [TestMethod]
        public void It_should_credit_the_to_account_by_the_amount_transferred()
        {
            __results["should_credit_the_to_account_by_the_amount_transferred"]();
        }
    }
}

namespace MSMSpecsTrialRun
{
    [TestClass]
    public partial class when_transferring_an_amount_larger_than_the_balance_of_the_from_account
    {
        static new Dictionary<string, Action> __results = new Dictionary<string, Action>();
        
        [ClassInitialize]
        public static void _Setup(TestContext context)
        {
            MSMSpec.TestExecutionHelper.Process<when_transferring_an_amount_larger_than_the_balance_of_the_from_account>(__results);
        }
        
        [TestMethod]
        public void It_should_not_allow_the_transfer()
        {
            __results["should_not_allow_the_transfer"]();
        }
    }
}

namespace MSMSpecsTrialRun
{
    [TestClass]
    public partial class AccountSpecs
    {
        static new Dictionary<string, Action> __results = new Dictionary<string, Action>();
        
        [ClassInitialize]
        public static void _Setup(TestContext context)
        {
            MSMSpec.TestExecutionHelper.Process<AccountSpecs>(__results);
        }
    }
}

