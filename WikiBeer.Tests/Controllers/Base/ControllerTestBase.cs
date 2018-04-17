using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WikiBeer.Core.Models;
using WikiBeer.Core.Models.BreweryDbResults;
using WikiBeer.Core.Repositories;

namespace WikiBeer.Tests.Controllers.Base
{
    public class ControllerTestBase
    {
        protected Mock<IBeerRepository> MockBeerRepository;
        protected Mock<IStyleRepository> MockStyleRepository;

        protected Beer BeerA;
        protected Beer BeerB;
        protected Beer BeerC;
        protected Beer BeerD;

        protected Style StyleA;
        protected Style StyleB;

        protected Brewery BreweryA;
        protected Brewery BreweryB;

        protected Label LabelA;
        protected Label LabelB;

        [SetUp]
        protected void SetUp()
        {
            SetUpDomainData();
            SetUpRepositories();
        }

        private void SetUpDomainData()
        {
            BreweryA = new Brewery
            {
                Id = "1",
                Name = "BreweryA",
                Description = "BreweryA Description"
            };
            BreweryB = new Brewery
            {
                Id = "2",
                Name = "BreweryB",
                Description = "BreweryB Description"
            };

            StyleA = new Style
            {
                Id = 1,
                Name = "StyleA",
                Description = "StyleA Description"
            };
            StyleB = new Style
            {
                Id = 2,
                Name = "StyleB",
                Description = "StyleB Description"
            };

            LabelA = new Label
            {
                LargeImagePath = "LA",
                MediumImagePath = "MA",
                SmallImagePath = "SA"
            };
            LabelB = new Label
            {
                LargeImagePath = "LB",
                MediumImagePath = "MB",
                SmallImagePath = "SB"
            };

            BeerA = new Beer
            {
                Name = "BeerA",
                Id = "1",
                Description = "BeerA Description",
                Style = StyleA,
                Label = LabelA
            };
            BeerB = new Beer
            {
                Name = "BeerB",
                Id = "2",
                Description = "BeerB Description",
                Style = StyleB,
                Label = LabelB
            };
            BeerC = new Beer
            {
                Name = "BeerC",
                Id = "3",
                Description = "BeerC Description",
                Style = StyleA
            };
            BeerD = new Beer
            {
                Name = "BeerD",
                Id = "4",
                Description = "BeerD Description",
                Style = StyleB
            };
        }

        private void SetUpRepositories()
        {
            MockBeerRepository = new Mock<IBeerRepository>();
            MockStyleRepository = new Mock<IStyleRepository>();

            MockStyleRepository.Setup(m => m.GetAllAsync()).Returns(Task.FromResult(
                new BreweryDbCollectionResult<Style>
                {
                    Instances = new[] { StyleA, StyleB },
                }));
        }
    }
}