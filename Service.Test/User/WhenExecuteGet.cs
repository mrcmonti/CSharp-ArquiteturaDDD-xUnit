using Domain.Dtos.User;
using Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Service.Test.User
{
    public class WhenExecuteGet : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo GET")]
        public async Task CanExecuteGetMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Get(Id)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(Id);
            Assert.NotNull(result);
            Assert.True(result.Id == Id);
            Assert.Equal(Name, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto) null));
            _service = _serviceMock.Object;

            var record = await _service.Get(Id);
            Assert.Null(record);
        }
    }
}
