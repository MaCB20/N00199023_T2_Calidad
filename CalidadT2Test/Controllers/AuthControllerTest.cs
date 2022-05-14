using CalidadT2.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace CalidadT2Test.Controllers
{
    public class AuthControllerTest
    {
        [Test]
        public void LoginViewCase01()
        {
            var controller = new AuthController(null);
            var view = controller.Login() as ViewResult;

            Assert.IsNotNull(view);
            Assert.IsInstanceOf<ViewResult>(view);
        }  
    }
}
