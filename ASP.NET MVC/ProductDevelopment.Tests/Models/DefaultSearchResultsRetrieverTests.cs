using System.Linq;
using AutoMoq;
using NUnit.Framework;
using ProductDevelopment.Web.Infrastructure.Data;
using ProductDevelopment.Web.Mappers;
using ProductDevelopment.Web.Models;
using Should;

namespace ProductDevelopment.Tests.Models
{
    [TestFixture]
    public class DefaultSearchResultsRetrieverTests
    {
        private AutoMoqer mocker;

        [SetUp]
        public void Setup()
        {
            mocker = new AutoMoqer();
        }

        [Test]
        public void Should_return_mapped_results_from_the_repository()
        {
            var defects = new Defect[] {}.AsQueryable();

            mocker.GetMock<IRepository<Defect>>()
                .Setup(x => x.All())
                .Returns(defects);

            var expectedResults = new DefectSearchResultsViewModel[] {};
            mocker.GetMock<IDefaultSearchResultViewModelMapper>()
                .Setup(x => x.CreateSet(defects))
                .Returns(expectedResults);

            var retriever = mocker.Create<DefaultSearchResultsRetriever>();

            var results = retriever.GetSearchResults();

            results.ShouldBeSameAs(expectedResults);
        }
    }
}