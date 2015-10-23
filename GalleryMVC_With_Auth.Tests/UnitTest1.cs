using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GalleryMVC_With_Auth.Controllers;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GalleryMVC_With_Auth.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Mock<IQueryable<Album>> albumMock = new Mock<IQueryable<Album>>();
            Mock<IPicturesRepository> repMock = new Mock<IPicturesRepository>();

            repMock.Setup(x => x.Albums.Select(xy => xy).ToList()).Returns(new List<Album> {new Album {Description = "desc"} });
            List<Album> f = new List<Album> {new Album {Description = "desc"}};

            //Act
            HomeController hc = new HomeController(repMock.Object);

            //Assert
            var c = hc.Index();

        }
    }
}
