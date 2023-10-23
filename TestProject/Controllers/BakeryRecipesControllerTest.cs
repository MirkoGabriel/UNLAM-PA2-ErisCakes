using AutoMapper;
using ErisCakesWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using ErisCakesWebApi.Controllers;
using FluentAssertions;
using ErisCakesWebApi.Models;
using ErisCakesWebApi.Interfaces;
using Newtonsoft.Json.Linq;

namespace TestProject.Controllers
{
    public class BakeryRecipesControllerTest
    {
        private readonly IBakeryRecipesRepository _bakeryRecipesRepository;
        private readonly IMapper _mapper;

        public BakeryRecipesControllerTest()
        {
            _bakeryRecipesRepository = A.Fake<IBakeryRecipesRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void CreatBakeryRecipes_with_exception()
        {
            BakeryRecipe bakeryRecipe = new BakeryRecipe();
            bakeryRecipe.Name = "Tiramisu";
            bakeryRecipe.Kind ="Postre";
            bakeryRecipe.Ingredients = "";
            bakeryRecipe.Procedure = "";
            bakeryRecipe.Price = -21;
            var controller = new BakeryRecipesController(_bakeryRecipesRepository, _mapper);
            var result = controller.PostBakeryRecipe(bakeryRecipe);
            result.Exception.Message.Should().Be("One or more errors occurred. (Recipe price must be gratter than 0)");    
        }

        [Fact]
        public void CreatBakeryRecipes_success()
        {
            BakeryRecipe bakeryRecipe = new BakeryRecipe();
            bakeryRecipe.Name = "Tiramisu";
            bakeryRecipe.Kind = "Postre";
            bakeryRecipe.Ingredients = "";
            bakeryRecipe.Procedure = "";
            bakeryRecipe.Price = 21;
            var controller = new BakeryRecipesController(_bakeryRecipesRepository, _mapper);
            var result = controller.PostBakeryRecipe(bakeryRecipe);
            result.Should().NotBeNull();   
        }
    }
}
