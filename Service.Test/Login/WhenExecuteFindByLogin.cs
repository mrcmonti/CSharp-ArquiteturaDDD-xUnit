using Domain.DTO;
using Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Service.Test.Login
{
    public class WhenExecuteFindByLogin
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o Login")]
        public async Task CanExecuteByLoginMethod()
        {
            var email = Faker.Internet.Email();

            var returnObject = new
            {
                authenticated = true,
                UserName = email,
                access_token = Guid.NewGuid(),
            };

            var loginDto = new LoginDTO
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(x => x.FindByLogin(loginDto)).ReturnsAsync(returnObject);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);

            Assert.NotNull(result);
        }
    }
}
