using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Rennish.WebAPI.Models;
using Rennish.WebAPI.Repository;

namespace Rennish.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private static IProductRepository _repo = new ProductRepository();

        public IEnumerable<Product> GetAllProducts()
        {
            return _repo.GetAll();
        }

        public Product GetProductById(int Id)
        {
            var product = _repo.Get(Id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return product;
            }
        }

        [HttpPost]
        public HttpResponseMessage CreateProduct(Product item)
        {
            if (ModelState.IsValid)
            {
                var result = _repo.Add(item);
                var response = Request.CreateResponse<Product>(HttpStatusCode.Created, result);
                var uri = Url.Link("DefaultApi", new { id = result.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}