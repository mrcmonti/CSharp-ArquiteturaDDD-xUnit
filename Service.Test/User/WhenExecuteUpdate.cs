using Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Service.Test.User
{
    public class WhenExecuteUpdate : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo Update")]
        public async Task CanExecutePutMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Name, result.Name);
            Assert.Equal(Email, result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(userDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NameModified, resultUpdate.Name);
            Assert.Equal(EmailModified, resultUpdate.Email);

        }
    }
}
