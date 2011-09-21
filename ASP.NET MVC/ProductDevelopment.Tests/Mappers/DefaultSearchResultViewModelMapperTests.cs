using AutoMapperAssist;
using NUnit.Framework;
using ProductDevelopment.Web.Mappers;
using ProductDevelopment.Web.Models;
using Should;

namespace ProductDevelopment.Tests.Mappers
{
    [TestFixture]
    public class DefaultSearchResultViewModelMapperTests
    {
        [Test]
        public void Assert_that_the_mapping_configuration_is_valid()
        {
            var mapper = new DefaultSearchResultViewModelMapper();
            mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void Check_that_created_by_is_set_to_CreatorUser_Username()
        {
            var mapper = new DefaultSearchResultViewModelMapper();
            var result = mapper.CreateInstance(new Defect {CreatorUser = new User {Username = "expected result"}});
            result.CreatedBy.ShouldEqual("expected result");
        }

        [Test]
        public void Check_that_assigned_to_is_set_to_AssignedUser_Username()
        {
            var mapper = new DefaultSearchResultViewModelMapper();
            var result = mapper.CreateInstance(new Defect {AssignedToUser = new User {Username = "The assigned to user"}});
            result.AssignedTo.ShouldEqual("The assigned to user");
        }
    }
}