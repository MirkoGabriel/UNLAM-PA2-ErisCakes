using AutoMapper;
using ErisCakesWebApi.Controllers;
using ErisCakesWebApi.Interfaces;
using ErisCakesWebApi.Models;
using ErisCakesWebApi.Repository;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Controllers
{
    public class BakeryRequestsControllerTest
    {
        private readonly IBakeryRequestRepository _bakeryRequestRepository;
        private readonly IMapper _mapper;

        public BakeryRequestsControllerTest()
        {
            _bakeryRequestRepository = A.Fake<IBakeryRequestRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void CreatBakeryRequest_success()
        {
            BakeryRequest bakeryRequest = new BakeryRequest();
            ICollection<BakeryRequestRecipe> BakeryRequestRecipes;
            BakeryRequestRecipe bakeryRequestRecipe = new BakeryRequestRecipe();
            bakeryRequest.RecipeStatus = "Ingresado";
            bakeryRequest.BillingStatus = "Pendiente";
            bakeryRequest.BudgetPice =98;
            bakeryRequest.HomeDelivery =true;
            bakeryRequest.ShippingPrice =45;
            bakeryRequest.AdditionalComments ="";
            bakeryRequest.JobScore =500;
            bakeryRequest.ClientId =1;
            bakeryRequestRecipe.BakeryRequestId =1;
            bakeryRequestRecipe.BakeryRecipeId = 1;

            var controller = new BakeryRequestsController(_bakeryRequestRepository, _mapper);
            var result = controller.PostBakeryRequest(bakeryRequest);
            result.Should().NotBeNull();
        }

        [Fact]
        public void CreatBakeryRequest__with_exception_invalid_RecipeStatus()
        {
            BakeryRequest bakeryRequest = new BakeryRequest();
            ICollection<BakeryRequestRecipe> BakeryRequestRecipes;
            BakeryRequestRecipe bakeryRequestRecipe = new BakeryRequestRecipe();
            bakeryRequest.RecipeStatus = "";
            bakeryRequest.BillingStatus = "Pendiente";
            bakeryRequest.BudgetPice = 98;
            bakeryRequest.HomeDelivery = true;
            bakeryRequest.ShippingPrice = 45;
            bakeryRequest.AdditionalComments = "";
            bakeryRequest.JobScore = 500;
            bakeryRequest.ClientId = 1;
            bakeryRequestRecipe.BakeryRequestId = 1;
            bakeryRequestRecipe.BakeryRecipeId = 1;

            var controller = new BakeryRequestsController(_bakeryRequestRepository, _mapper);
            var result = controller.PostBakeryRequest(bakeryRequest);
            result.Exception.Message.Should().Be("One or more errors occurred. (El estado del pedido solo se permiten valores como: 'Pendiente', 'Terminado', 'Ingresado' y 'Demorado')");
        }

        [Fact]
        public void CreatBakeryRequest__with_exception_invalid_BillingStatus()
        {
            BakeryRequest bakeryRequest = new BakeryRequest();
            ICollection<BakeryRequestRecipe> BakeryRequestRecipes;
            BakeryRequestRecipe bakeryRequestRecipe = new BakeryRequestRecipe();
            bakeryRequest.RecipeStatus = "Ingresado";
            bakeryRequest.BillingStatus = "";
            bakeryRequest.BudgetPice = 98;
            bakeryRequest.HomeDelivery = true;
            bakeryRequest.ShippingPrice = 45;
            bakeryRequest.AdditionalComments = "";
            bakeryRequest.JobScore = 500;
            bakeryRequest.ClientId = 1;
            bakeryRequestRecipe.BakeryRequestId = 1;
            bakeryRequestRecipe.BakeryRecipeId = 1;

            var controller = new BakeryRequestsController(_bakeryRequestRepository, _mapper);
            var result = controller.PostBakeryRequest(bakeryRequest);
            result.Exception.Message.Should().Be("One or more errors occurred. (El estado del presupuesto solo se permiten valores como: 'Aprobado', 'Rechazado' y 'Pendiente')");
        }

        [Fact]
        public void CreatBakeryRequest__with_exception_invalid_BudgetPice()
        {
            BakeryRequest bakeryRequest = new BakeryRequest();
            ICollection<BakeryRequestRecipe> BakeryRequestRecipes;
            BakeryRequestRecipe bakeryRequestRecipe = new BakeryRequestRecipe();
            bakeryRequest.RecipeStatus = "Ingresado";
            bakeryRequest.BillingStatus = "Pendiente";
            bakeryRequest.BudgetPice = -98;
            bakeryRequest.HomeDelivery = true;
            bakeryRequest.ShippingPrice = 45;
            bakeryRequest.AdditionalComments = "";
            bakeryRequest.JobScore = 500;
            bakeryRequest.ClientId = 1;
            bakeryRequestRecipe.BakeryRequestId = 1;
            bakeryRequestRecipe.BakeryRecipeId = 1;

            var controller = new BakeryRequestsController(_bakeryRequestRepository, _mapper);
            var result = controller.PostBakeryRequest(bakeryRequest);
            result.Exception.Message.Should().Be("One or more errors occurred. (El precio del presupuesto tiene que se mayor a 0)");
        }

        [Fact]
        public void CreatBakeryRequest__with_exception_invalid_ShippingPrice()
        {
            BakeryRequest bakeryRequest = new BakeryRequest();
            ICollection<BakeryRequestRecipe> BakeryRequestRecipes;
            BakeryRequestRecipe bakeryRequestRecipe = new BakeryRequestRecipe();
            bakeryRequest.RecipeStatus = "Ingresado";
            bakeryRequest.BillingStatus = "Pendiente";
            bakeryRequest.BudgetPice = 98;
            bakeryRequest.HomeDelivery = true;
            bakeryRequest.ShippingPrice = -45;
            bakeryRequest.AdditionalComments = "";
            bakeryRequest.JobScore = 500;
            bakeryRequest.ClientId = 1;
            bakeryRequestRecipe.BakeryRequestId = 1;
            bakeryRequestRecipe.BakeryRecipeId = 1;

            var controller = new BakeryRequestsController(_bakeryRequestRepository, _mapper);
            var result = controller.PostBakeryRequest(bakeryRequest);
            result.Exception.Message.Should().Be("One or more errors occurred. (El precio del viaje tiene que se mayor a 0)");
        }

        [Fact]
        public void CreatBakeryRequest__with_exception_invalid_JobScore_less_than_0()
        {
            BakeryRequest bakeryRequest = new BakeryRequest();
            ICollection<BakeryRequestRecipe> BakeryRequestRecipes;
            BakeryRequestRecipe bakeryRequestRecipe = new BakeryRequestRecipe();
            bakeryRequest.RecipeStatus = "Ingresado";
            bakeryRequest.BillingStatus = "Pendiente";
            bakeryRequest.BudgetPice = 98;
            bakeryRequest.HomeDelivery = true;
            bakeryRequest.ShippingPrice = 45;
            bakeryRequest.AdditionalComments = "";
            bakeryRequest.JobScore = -500;
            bakeryRequest.ClientId = 1;
            bakeryRequestRecipe.BakeryRequestId = 1;
            bakeryRequestRecipe.BakeryRecipeId = 1;

            var controller = new BakeryRequestsController(_bakeryRequestRepository, _mapper);
            var result = controller.PostBakeryRequest(bakeryRequest);
            result.Exception.Message.Should().Be("One or more errors occurred. (La satisfaccion del cliente tiene que estar entre 0 y 1000)");
        }

        [Fact]
        public void CreatBakeryRequest__with_exception_invalid_JobScore_more_than_1000()
        {
            BakeryRequest bakeryRequest = new BakeryRequest();
            ICollection<BakeryRequestRecipe> BakeryRequestRecipes;
            BakeryRequestRecipe bakeryRequestRecipe = new BakeryRequestRecipe();
            bakeryRequest.RecipeStatus = "Ingresado";
            bakeryRequest.BillingStatus = "Pendiente";
            bakeryRequest.BudgetPice = 98;
            bakeryRequest.HomeDelivery = true;
            bakeryRequest.ShippingPrice = 45;
            bakeryRequest.AdditionalComments = "";
            bakeryRequest.JobScore = 1001;
            bakeryRequest.ClientId = 1;
            bakeryRequestRecipe.BakeryRequestId = 1;
            bakeryRequestRecipe.BakeryRecipeId = 1;

            var controller = new BakeryRequestsController(_bakeryRequestRepository, _mapper);
            var result = controller.PostBakeryRequest(bakeryRequest);
            result.Exception.Message.Should().Be("One or more errors occurred. (La satisfaccion del cliente tiene que estar entre 0 y 1000)");
        }
    }
}
