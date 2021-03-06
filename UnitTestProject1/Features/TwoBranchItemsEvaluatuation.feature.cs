﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace UnitTestProject1.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class TwoBranchItemsEvaluatuationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TwoBranchItemsEvaluatuation.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "TwoBranchItemsEvaluatuation", "In order to find entity from existing data\r\nAs a test writer\r\nI want to find enti" +
                    "ty by defined conditions, describing a complex tree of entity interconnections", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "TwoBranchItemsEvaluatuation")))
            {
                UnitTestProject1.Features.TwoBranchItemsEvaluatuationFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Two branch search with condition between collections of those branches")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TwoBranchItemsEvaluatuation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("twobranch1")]
        public virtual void TwoBranchSearchWithConditionBetweenCollectionsOfThoseBranches()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Two branch search with condition between collections of those branches", new string[] {
                        "twobranch1"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("insurance B is taken from insurancesSource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
   testRunner.And("insurance B is created in year 2010", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
   testRunner.And("for insurance B exists an assignment B", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
   testRunner.And("assignment B has type \'Dependent\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
   testRunner.And("assignments B have covered people", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
   testRunner.And("for insurance B exists a tax B", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
   testRunner.And("tax B has type \'Federal\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
   testRunner.And("average payment per person in assignments B, specified in taxes B is over 10$", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.Then("insurance B name must contain \'@twobranch1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
   testRunner.And("assignment B Id must be 7", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Two branch search failure with condition between collections of those branches")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TwoBranchItemsEvaluatuation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("twobranch1")]
        public virtual void TwoBranchSearchFailureWithConditionBetweenCollectionsOfThoseBranches()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Two branch search failure with condition between collections of those branches", new string[] {
                        "twobranch1"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("insurance B is taken from insurancesSource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
   testRunner.And("insurance B is created in year 2010", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
   testRunner.And("for insurance B exists an assignment B", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
   testRunner.And("assignment B has type \'Dependent\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
   testRunner.And("assignments B have covered people", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
   testRunner.And("for insurance B exists a tax B", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
   testRunner.And("tax B has type \'Federal\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
   testRunner.And("average payment per person in assignments B, specified in taxes B is over 17$", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.When("i try resolving insurance B", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then("resolution logger must produce info for filter, mentioning \'Assignment \"B\"\' and \'" +
                    "17\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
