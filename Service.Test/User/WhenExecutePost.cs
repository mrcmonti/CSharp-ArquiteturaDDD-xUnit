using Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Service.Test.User
{
    public class WhenExecutePost : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo Post")]
        public async Task CanExecutePostMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Name, result.Name);
            Assert.Equal(Email, result.Email);
        }
    }
}
