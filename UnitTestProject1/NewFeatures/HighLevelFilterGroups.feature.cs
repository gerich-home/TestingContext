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
namespace UnitTestProject1.NewFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class HighLevelFilterGroupsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "HighLevelFilterGroups.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "HighLevelFilterGroups", "In order to write high level tests\r\nAs a test writer\r\nI want to specify OR and NO" +
                    "T-AND groups", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "HighLevelFilterGroups")))
            {
                UnitTestProject1.NewFeatures.HighLevelFilterGroupsFeature.FeatureSetup(null);
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
        
        public virtual void FeatureBackground()
        {
#line 6
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name"});
            table1.AddRow(new string[] {
                        "1",
                        "Microsoft"});
            table1.AddRow(new string[] {
                        "2",
                        "Adobe"});
            table1.AddRow(new string[] {
                        "3",
                        "Oracle"});
            table1.AddRow(new string[] {
                        "4",
                        "Kaspersky"});
            table1.AddRow(new string[] {
                        "5",
                        "MeraRu"});
#line 7
 testRunner.Given("I have companies", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "CompanyId",
                        "Name",
                        "Type"});
            table2.AddRow(new string[] {
                        "1",
                        "1",
                        "Ms1",
                        "Supplementary"});
            table2.AddRow(new string[] {
                        "2",
                        "2",
                        "Ad1",
                        "Business"});
            table2.AddRow(new string[] {
                        "3",
                        "3",
                        "Or1",
                        "Supplementary"});
            table2.AddRow(new string[] {
                        "4",
                        "4",
                        "Ka1",
                        "Supplementary"});
            table2.AddRow(new string[] {
                        "5",
                        "5",
                        "Me1",
                        "Business"});
#line 14
 testRunner.And("I have departments in companies", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "DepartmentId",
                        "Name",
                        "EmploymentType"});
            table3.AddRow(new string[] {
                        "1",
                        "5",
                        "Peter",
                        "PartTime"});
            table3.AddRow(new string[] {
                        "2",
                        "3",
                        "Alex",
                        "PartTime"});
            table3.AddRow(new string[] {
                        "3",
                        "4",
                        "Richard",
                        "FullTime"});
#line 21
 testRunner.And("I have empleyees in departments", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "DepartmentId",
                        "Name",
                        "Budget"});
            table4.AddRow(new string[] {
                        "1",
                        "5",
                        "proj1",
                        "100"});
            table4.AddRow(new string[] {
                        "2",
                        "4",
                        "proj2",
                        "100"});
            table4.AddRow(new string[] {
                        "3",
                        "2",
                        "proj3",
                        "50"});
#line 26
 testRunner.And("I have work projects in departments", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "CompanyId",
                        "Name",
                        "Type"});
            table5.AddRow(new string[] {
                        "1",
                        "5",
                        "Software of Alex",
                        "Intellectual"});
#line 31
 testRunner.And("I have companies property", ((string)(null)), table5, "And ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("use OrGroup to find company with department with either employees, projects or de" +
            "partment type")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "HighLevelFilterGroups")]
        public virtual void UseOrGroupToFindCompanyWithDepartmentWithEitherEmployeesProjectsOrDepartmentType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("use OrGroup to find company with department with either employees, projects or de" +
                    "partment type", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 36
 testRunner.When("i search for company", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
  testRunner.And("i need company to have a department", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
  testRunner.And("i need department to either be \"Business\" type or have \"PartTime\" employee or hav" +
                    "e project with budjet 100 or more", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.Then("companies \"Adobe, Oracle, Kaspersky, MeraRu\" should be found for company requirem" +
                    "ents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("use NotGroup to find company with department that is not qualified to have all th" +
            "ree conditions")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "HighLevelFilterGroups")]
        public virtual void UseNotGroupToFindCompanyWithDepartmentThatIsNotQualifiedToHaveAllThreeConditions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("use NotGroup to find company with department that is not qualified to have all th" +
                    "ree conditions", ((string[])(null)));
#line 41
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 42
 testRunner.When("i search for company", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
  testRunner.And("i need company to have a department", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
  testRunner.And("i need department to NOT have all three, \"Business\" type, \"PartTime\" employee, pr" +
                    "oject budjet 100 or more", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.Then("companies \"Microsoft, Adobe, Oracle, Kaspersky\" should be found for company requi" +
                    "rements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("have Exception, notifying that you should specify direct relation between propert" +
            "y and NotGroup or between employee and property")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "HighLevelFilterGroups")]
        public virtual void HaveExceptionNotifyingThatYouShouldSpecifyDirectRelationBetweenPropertyAndNotGroupOrBetweenEmployeeAndProperty()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("have Exception, notifying that you should specify direct relation between propert" +
                    "y and NotGroup or between employee and property", ((string[])(null)));
#line 47
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 48
 testRunner.When("i search for company", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
  testRunner.And("i need company to have a department", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
  testRunner.And("i need company to have \"Intellectual\" property", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
  testRunner.And("i need department to NOT have all three, \"Business\" type, \"PartTime\" employee, pr" +
                    "oject budjet 100 or more", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
  testRunner.And("I need employee name mentioned in company property", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.Then("searching for company should result exception mentioning \"Not\", \"Employee\" and \"C" +
                    "ompanyProperty\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("when explicitly stated, NotGroup should allow to find data")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "HighLevelFilterGroups")]
        public virtual void WhenExplicitlyStatedNotGroupShouldAllowToFindData()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("when explicitly stated, NotGroup should allow to find data", ((string[])(null)));
#line 55
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 56
 testRunner.When("i search for company", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
  testRunner.And("i need company to have a department", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
  testRunner.And("i need company to have \"Intellectual\" property", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
  testRunner.And("for company property i need department to NOT have all three, \"Business\" type, \"P" +
                    "artTime\" employee, project budjet 100 or more", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
  testRunner.And("I need employee name mentioned in company property", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.Then("companies \"MeraRu\" should be found for company requirements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
