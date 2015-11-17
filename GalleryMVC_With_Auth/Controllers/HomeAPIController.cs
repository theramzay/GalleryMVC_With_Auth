﻿using System.Web.Http;
using GalleryMVC_With_Auth.Domain.Abstract;

namespace GalleryMVC_With_Auth.Controllers
{
    public class HomeAPIController : ApiController
    {
        private readonly IPicturesRepository _repository;

        public HomeAPIController(IPicturesRepository repository)
        {
            _repository = repository;
        }
    }
}