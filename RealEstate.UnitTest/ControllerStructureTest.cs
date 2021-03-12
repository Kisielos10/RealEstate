using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using FluentAssertions;
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

            var methods = asm.GetTypes()
                .Where(type => typeof(BaseController).IsAssignableFrom(type)) 
                .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)).ToList();
                    
            foreach (var method in methods)
            {
                //method.Should().BeDecoratedWith<SwaggerResponseAttribute>(s =>(s.StatusCode == HttpStatusCode.OK.ToString()));

                //check if the method has SwaggerResponse attribute  
                var result = Attribute.IsDefined(method, typeof(SwaggerResponseAttribute));
                Assert.True(result, $"{method.Name} should be declared with SwaggerResponse Attribute");
            }
        }
    }
}
