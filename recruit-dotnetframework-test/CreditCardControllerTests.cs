using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using recruit_dotnetframework.Controllers;
using recruit_dotnetframework.Models;
using BadRequestResult = System.Web.Http.Results.BadRequestResult;

namespace recruit_dotnetframework_test;

    [TestFixture]
    public class CreditCardControllerTests
    {
        [Test]
        public void ValidateCreditCard_ValidCreditCard_ReturnsOk()
        {
            // Arrange
            var controller = new CreditCardController();
            var validCreditCard = new CreditCard
            {
                CreditCardNumber = "4111111111111111",
                CVC = "123",
                ExpiryDate = new System.DateTime(2025, 12, 31)
            };
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = controller.SaveCreditCard(validCreditCard);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.TryGetContentValue(out string message); 
            message.Should().Be("Credit card is valid.");
        }

        // The below unit test does not pass, as the ModelState.IsValid is always true.
        // TODO: Figure out how to make ModelState actually work in unit test.
        [Test]
        public void ValidateCreditCard_InvalidCreditCard_ReturnsBadRequest()
        {
            // Arrange
            var controller = new CreditCardController();
            var invalidCreditCard = new CreditCard
            {
                CreditCardNumber = "1234",
                CVC = "1",
                ExpiryDate = new System.DateTime(2020, 12, 31)
            };
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = controller.SaveCreditCard(invalidCreditCard);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
