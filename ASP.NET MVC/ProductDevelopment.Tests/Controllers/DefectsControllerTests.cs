using System;
using System.Web.Mvc;
using AutoMoq.Helpers;
using Machine.Specifications;
using ProductDevelopment.Web.Controllers;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Tests.Controllers
{
    [Subject(typeof (DefectsController))]
    public class when_someone_visits_the_defects_page : with_automoqer
    {
        private Establish context =
            () =>
                {
                    expectedSearchResults = new DefectSearchResultsViewModel[] {};
                    GetMock<IDefaultSearchResultsRetriever>()
                        .Setup(x => x.GetSearchResults())
                        .Returns(expectedSearchResults);

                    controller = Create<DefectsController>();
                };

        private Because of =
            () => result = controller.Index();

        private It should_return_a_view_result =
            () => result.ShouldBeOfType(typeof (ViewResult));

        private It should_set_the_view_name_to_index =
            () => result.CastAs<ViewResult>().ViewName.ShouldEqual("Index");

        private It should_return_the_defect_search_results =
            () => result.CastAs<ViewResult>().Model.ShouldBeTheSameAs(expectedSearchResults);

        private static DefectsController controller;
        private static ActionResult result;
        private static DefectSearchResultsViewModel[] expectedSearchResults;
    }

    //[TestFixture]
    //public class DefectsControllerTests
    //{
    //    [Test]
    //    public void Should_return_default_view_with_search_results_on_Index_GET()
    //    {
    //        // Arrange
    //        var mockDefectRepo = new Mock<IRepository<Defect>>();
    //        mockDefectRepo.Setup(x => x.All()).Returns(MockDefectsData().AsQueryable());
    //        var mockProjectRepo = new Mock<IRepository<Project>>();
    //        var mockUserRepo = new Mock<IUserRepository>();
    //        var mockSeverityRepo = new Mock<IRepository<Severity>>();
    //        var controller = new DefectsController(mockDefectRepo.Object, mockProjectRepo.Object, mockUserRepo.Object, mockSeverityRepo.Object);

    //        // Act
    //        var result = controller.Index();

    //        // Assert
    //        result.ShouldBeType<ViewResult>();
    //        result.ViewName.ShouldBeEmpty();

    //        var model = (IEnumerable<DefectSearchResultsViewModel>)result.Model;

    //        model.First().Project.ShouldEqual("Tech Throwdown Test Project");
    //        model.First().Summary.ShouldEqual("Test defect summary 1");
    //        model.First().Severity.ShouldEqual("No Worries");
    //        model.First().CreatedBy.ShouldEqual("test user");
    //        model.First().AssignedTo.ShouldEqual("test user");

    //        model.Last().Project.ShouldEqual("Tech Throwdown Test Project");
    //        model.Last().Summary.ShouldEqual("This is a test defect summary 3");
    //        model.Last().Severity.ShouldEqual("No Worries");
    //        model.Last().CreatedBy.ShouldEqual("test user");
    //        model.Last().AssignedTo.ShouldEqual("test user");
    //    }

    //    [Test]
    //    public void Should_return_default_view_with_drop_down_values_on_Create_GET()
    //    {
    //        // Arrange
    //        var mockDefectRepo = new Mock<IRepository<Defect>>();
    //        var mockProjectRepo = new Mock<IRepository<Project>>();
    //        mockProjectRepo.Setup(x => x.All()).Returns(MockProjectData().AsQueryable());
    //        var mockUserRepo = new Mock<IUserRepository>();
    //        mockUserRepo.Setup(x => x.All()).Returns(MockUserData().AsQueryable());
    //        var mockSeverityRepo = new Mock<IRepository<Severity>>();
    //        mockSeverityRepo.Setup(x => x.All()).Returns(MockSeverityData().AsQueryable());
    //        var controller = new DefectsController(mockDefectRepo.Object, mockProjectRepo.Object, mockUserRepo.Object, mockSeverityRepo.Object);

    //        // Act
    //        var result = controller.Create();

    //        // Assert
    //        result.ShouldBeType<ViewResult>();
    //        result.ViewName.ShouldBeEmpty();

    //        var model = (DefectInputModel)result.Model;

    //        model.CreatorUserId = MockUserData().First().UserId;
    //        model.AssignedToUserId = MockUserData().First().UserId;

    //        model.ProjectSelectList.First().Value = "1";
    //        model.ProjectSelectList.First().Text = "test project 1";
    //        model.ProjectSelectList.Last().Value = "2";
    //        model.ProjectSelectList.Last().Text = "test project 2";

    //        model.UserSelectList.First().Value = "1";
    //        model.UserSelectList.First().Text = "test user 1";
    //        model.UserSelectList.Last().Value = "2";
    //        model.UserSelectList.Last().Text = "test user 2";

    //        model.SeveritySelectList.First().Value = "1";
    //        model.SeveritySelectList.First().Text = "test severity 1";
    //        model.SeveritySelectList.Last().Value = "2";
    //        model.SeveritySelectList.Last().Text = "test severity 2";
    //    }

    //    [Test]
    //    public void Should_return_search_view_when_good_values_on_Create_POST()
    //    {
    //        // Arrange
    //        var mockDefectRepo = new Mock<IRepository<Defect>>();
    //        var mockProjectRepo = new Mock<IRepository<Project>>();
    //        var mockUserRepo = new Mock<IUserRepository>();
    //        var mockSeverityRepo = new Mock<IRepository<Severity>>();
    //        var defect = MockDefectsData().First();
    //        var controller = new DefectsController(mockDefectRepo.Object, mockProjectRepo.Object, mockUserRepo.Object, mockSeverityRepo.Object);

    //        // Act
    //        var result = controller.Create(defect);

    //        // Assert
    //        result.ShouldBeType<RedirectToRouteResult>();

    //        var redirect = (RedirectToRouteResult)result;
    //        redirect.RouteValues["action"].ShouldEqual("Index");
    //    }

    //    private static IEnumerable<Project> MockProjectData()
    //    {
    //        return new List<Project>
    //                   {
    //                       new Project
    //                           {
    //                               ProjectId = 1,
    //                               Name = "test project 1"
    //                           },
    //                       new Project
    //                           {
    //                               ProjectId = 2,
    //                               Name = "test project 2"
    //                           }
    //                   };
    //    }

    //    private static IEnumerable<User> MockUserData()
    //    {
    //        return new List<User>
    //                   {
    //                       new User
    //                           {
    //                               UserId = 1,
    //                               Username = "test user 1"
    //                           },
    //                       new User
    //                           {
    //                               UserId = 2,
    //                               Username = "test user 2"
    //                           }
    //                   };
    //    }

    //    private static IEnumerable<Defect> MockDefectsData()
    //    {
    //        var mockProject = new Project
    //        {
    //            Name = "Tech Throwdown Test Project"
    //        };
    //        var mockUser = new User
    //        {
    //            Username = "test user"
    //        };
    //        var mockSeverity = new Severity
    //        {
    //            SeverityDescription = "No Worries"
    //        };
    //        var mockDefects = new List<Defect>
    //                              {
    //                                  new Defect
    //                                      {
    //                                          Project = mockProject,
    //                                          Summary = "Test defect summary 1",
    //                                          StepsToReproduce = "Test steps to reproduce 1",
    //                                          CreatorUser = mockUser,
    //                                          AssignedToUser = mockUser,
    //                                          Severity = mockSeverity
    //                                      },
    //                                  new Defect
    //                                      {
    //                                          Project = mockProject,
    //                                          Summary = "This is a test defect summary 3",
    //                                          StepsToReproduce = "Test steps to reproduce 3",
    //                                          CreatorUser = mockUser,
    //                                          AssignedToUser = mockUser,
    //                                          Severity = mockSeverity
    //                                      }
    //                              };
    //        return mockDefects;
    //    }

    //    private static IEnumerable<Severity> MockSeverityData()
    //    {
    //        return new List<Severity>
    //                   {
    //                       new Severity
    //                           {
    //                               SeverityId = 1,
    //                               SeverityDescription = "test severity 1"
    //                           },
    //                       new Severity
    //                           {
    //                               SeverityId = 2,
    //                               SeverityDescription = "test severity 2"
    //                           }
    //                   };
    //    }
    //}
}