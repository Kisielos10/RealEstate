using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            //var baseControllerType = typeof(BaseController);
            //var controllerTypes = baseControllerType.Assembly.GetTypes().Where(t => t.IsClass && t != type
            //    && type.IsAssignableFrom(BaseController))
            //typeof(BaseController).Methods().Should().BeDecoratedWith<SwaggerResponseAttribute>(s =>(s.StatusCode == HttpStatusCode.OK.ToString()));

        }
    }
}
