using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WikiBeer.Controllers;
using WikiBeer.Core.Models;
using WikiBeer.Core.Models.BreweryDbResults;
using WikiBeer.Core.Models.ViewModels.Beers;
using WikiBeer.Core.Repositories;
using WikiBeer.Tests.Controllers.Base;

namespace WikiBeer.Tests.Controllers
{
    [TestFixture]
    public class BeersControllerTest : ControllerTestBase
    {
        private BeersController _controller;

        [SetUp]
        public new void SetUp()
        {
            _controller = new BeersController(
                new Lazy<IBeerRepository>(() => MockBeerRepository.Object),
                new Lazy<IStyleRepository>(() => MockStyleRepository.Object));
        }

        [Test]
        public void IndexGet_WhenCalled_ShouldReturnViewWithDefaultNavigationSettingsAndFirstPageBeers()
        {
            var breweryDbBeersResult = new BreweryDbCollectionResult<Beer>()
            {
                CurrentPageNumber = 1,
                Instances = new[] { BeerA, BeerB },
                TotalNumberOfPages = 2,
            };
            MockBeerRepository.Setup(m => m.GetAllAsync()).Returns(Task.FromResult(breweryDbBeersResult));


            var result = _controller.Index().Result;
            result.Should().BeOfType<ViewResult>();

            var resultViewModel = (result as ViewResult).ViewData.Model;
            resultViewModel.Should().BeOfType<IndexGet>();

            var indexGet = resultViewModel as IndexGet;
            indexGet.CurrentPageNumber.Should().Be(breweryDbBeersResult.CurrentPageNumber);
            indexGet.TotalNumberOfPages.Should().Be(breweryDbBeersResult.TotalNumberOfPages);

            indexGet.SortBy.SelectedValue.Should().Be(BeersSortBy.NameAsc.ToString());

            indexGet.Style.SelectedValue.Should().Be(default(int).ToString());
            indexGet.Style.SelectedText.Should().Be("All Style");

            indexGet.SearchName.Should().Match(sn => string.IsNullOrWhiteSpace(sn));

            indexGet.Beers.Should().BeSameAs(breweryDbBeersResult.Instances);
        }

        [Test]
        public void IndexPost_WhenCalledWithNavigationQuery_ShouldReturnPartialViewWithCorrespondingNavigationSettingsAndBeers()
        {
            var indexPost = new IndexPost
            {
                Style = StyleA.Id,
                SearchName = string.Empty,
                CurrentPageNumber = 2,
                SortBy = BeersSortBy.NameDesc
            };
            var query = indexPost.GetQuery();

            var mockIndexPost = new Mock<IndexPost>();
            mockIndexPost.Object.Style = indexPost.Style;
            mockIndexPost.Object.SearchName = indexPost.SearchName;
            mockIndexPost.Object.CurrentPageNumber = indexPost.CurrentPageNumber;
            mockIndexPost.Object.SortBy = indexPost.SortBy;
            mockIndexPost.Setup(m => m.GetQuery()).Returns(query);

            var breweryDbBeersResult = new BreweryDbCollectionResult<Beer>()
            {
                CurrentPageNumber = indexPost.CurrentPageNumber,
                Instances = new[] { BeerC, BeerA },
                TotalNumberOfPages = 3,
            };

            MockBeerRepository.Setup(m => m.GetAllAsync(query)).Returns(Task.FromResult(breweryDbBeersResult));


            var result = _controller.Index(mockIndexPost.Object).Result;
            result.Should().BeOfType<PartialViewResult>();

            var resultViewModel = (result as PartialViewResult).ViewData.Model;
            resultViewModel.Should().BeOfType<IndexGet>();

            var indexGet = resultViewModel as IndexGet;
            indexGet.CurrentPageNumber.Should().Be(indexPost.CurrentPageNumber);
            indexGet.TotalNumberOfPages.Should().Be(breweryDbBeersResult.TotalNumberOfPages);

            indexGet.SortBy.SelectedValue.Should().Be(indexPost.SortBy.ToString());

            indexGet.Style.SelectedValue.Should().Be(indexPost.Style.ToString());

            indexGet.SearchName.Should().Be(indexPost.SearchName);

            indexGet.Beers.Should().BeSameAs(breweryDbBeersResult.Instances);
        }

        [Test]
        public void ShowGet_WhenCalledWithBeerId_ShouldReturnViewWithBeerAndItsBreweries()
        {
            var breweryDbBeerDResult = new BreweryDbSingelResult<Beer>()
            {
                Instance = BeerD
            };

            var breweriesOfBeerD = new[] { BreweryA, BreweryB };
            var breweryDbBreweriesOfBeerDResult = new BreweryDbCollectionResult<Brewery>
            {
                Instances = breweriesOfBeerD
            };

            MockBeerRepository.Setup(m => m.GetAsync(BeerD.Id)).Returns(Task.FromResult(breweryDbBeerDResult));
            MockBeerRepository.Setup(m => m.GetBreweries(BeerD.Id)).Returns(Task.FromResult(breweryDbBreweriesOfBeerDResult));


            var result = _controller.Show(BeerD.Id).Result;
            result.Should().BeOfType<ViewResult>();

            var resultViewModel = (result as ViewResult).ViewData.Model;
            resultViewModel.Should().BeOfType<ShowGet>();

            var showGet = resultViewModel as ShowGet;
            showGet.Beer.Should().Be(BeerD);
            showGet.Breweries.Should().BeSameAs(breweriesOfBeerD);
        }

        [Test]
        public void ShowGet_WhenCalledWithUnknownBeerId_ShouldReturnEmptyResult()
        {
            var unknownBeerId = "Yaya";

            MockBeerRepository.Setup(m => m.GetAsync(unknownBeerId)).Returns(Task.FromResult(null as BreweryDbSingelResult<Beer>));
            MockBeerRepository.Setup(m => m.GetBreweries(unknownBeerId)).Returns(Task.FromResult(null as BreweryDbCollectionResult<Brewery>));


            var result = _controller.Show(unknownBeerId).Result;
            result.Should().BeOfType<EmptyResult>();
        }
    }
}
