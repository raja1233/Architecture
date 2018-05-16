using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using architecture.Web.Controllers;
using System.Net.Http;
using System.Web.Http;
using architecture.ViewModel;
using System.Web.Http.Results;
using Moq;
using architecture.Data.Repository;

namespace architecture.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Test1()
        {
            try
            {
                //var controller = new PersonApiController();
                //controller.Request = new HttpRequestMessage();
                //controller.Configuration = new HttpConfiguration();

                ////Act on Test
                //var respose = controller.Get();
                //PersonVIewModel vm = new PersonVIewModel();
                //var contentRes = respose as OkNegotiatedContentResult<PersonVIewModel>;
                //Assert.IsNotNull(contentRes);
                ////Assert.IsNotNull(vm.Age);
                //Assert.IsFalse("john smith" == vm.Name);

            }
            catch(Exception e)
            {

            }
           
        }

        [TestMethod]
        public void Test2()
        {
            try
            {
                //var controller = new PersonApiController();
                //controller.Request = new HttpRequestMessage();
                //controller.Configuration = new HttpConfiguration();
                //var response = controller.Get(1);
                //PersonVIewModel p = new PersonVIewModel();
                //var result = response as OkNegotiatedContentResult<PersonVIewModel>;
                //Assert.IsNotNull(p.ID);
                //Assert.AreSame("Raja", p.Name);

            }
            catch (Exception e)
            {

            }
        }

        [TestMethod]
        public void test_controller_with_valid_model()
        {
            try
            {  //Arrange
                ////var controller = new PersonApiController();
                //controller.ModelState.Clear();
                ////var vm = new PersonVIewModel();
                //var result = controller.PostPerson(new PersonVIewModel());
                //Assert.IsNotNull(result);
            }
           catch(Exception e)
            {

            }
          
        }
        [TestMethod]
        public void testDelete()
        {

        }
    }
    
}
