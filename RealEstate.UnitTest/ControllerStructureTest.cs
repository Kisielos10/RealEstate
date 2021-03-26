using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Types;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RealEstate.API.Controllers;
using Xunit;

namespace RealEstate.UnitTest
{
    public class ControllerStructureTest 
    {
        [Fact]
        public void BaseControllerHasAttribute()
        {
            typeof(BaseController).Should().BeDecoratedWith<SwaggerResponseAttribute>();
        }
        [Fact]
        public void EndpointsSwaggerAttribute()
        {
            
            var asm = typeof(BaseController).Assembly;

            //AllTypes.From(asm).ThatDeriveFrom<BaseController>().ToArray().SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)).ToList().Should().;

            var methods = asm.GetTypes()
                .Where(type => typeof(BaseController).IsAssignableFrom(type)) 
                .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)).ToList();

            using (new AssertionScope())
            {
                foreach (var method in methods)
                {
                    method.Should().BeDecoratedWith<SwaggerResponseAttribute>();
                    //TODO zrobić żeby github generował exe
                    //check if the method has SwaggerResponse attribute  
                    //var result = Attribute.IsDefined(method, typeof(SwaggerResponseAttribute));
                    //Assert.True(result, $"{method.Name} should be declared with SwaggerResponse Attribute");
                }
            }
        }
    }
}
