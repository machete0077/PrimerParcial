using System;
using System.Web.Http;
using System.Web.Http.Results;
using DocumentFormat.OpenXml.Wordprocessing;
using EvalEnriqueArce.Controllers;
using EvalEnriqueArce.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvalEnriqueArce.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestGet()
        {
            //arrange
            PaisesController controller = new PaisesController();
            Pais pais = new Pais();
            {
                Name = "Bolivia",
                Capital = "Sucre",
                Poblacion = 1501211,
                LatLng = "-150°,85°",
                TimeZone = "9:04/15/19",
                Moneda = "Euros",
                Bandera = "https://www.pinterest.com/marcela7340/bolivia/"
            };
            //act
            IHttpActionResult ActionResult = controller.PostPais(pais);
            var createdResult = ActionResult as
            CreatedAtRouteNegotiatedContentResult<PaisesController>;
            //assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["name"]);
        }
    }
}
