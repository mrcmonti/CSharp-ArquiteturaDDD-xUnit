using Data.Context;
using Data.Implementations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Data.Test
{
    public class CompleteUserCrud : BaseTest, IClassFixture<DbTeste>
    {
        private IServiceProvider _serviceProvider;

        public CompleteUserCrud(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "User Crud")]
        [Trait("Crud", "UserEntity")]
        public async Task Can_Do_User_Crud()
        {
            using(var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repository = new UserImplementation(context);
                UserEntity entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var registerCreated = await _repository.InsertAsync(entity);
                Assert.NotNull(registerCreated);
                Assert.Equal(entity.Email, registerCreated.Email);
                Assert.Equal(entity.Name, registerCreated.Name);
                Assert.False(registerCreated.Id == Guid.Empty);

                entity.Name = Faker.Name.First();

                var registerUpdated = await _repository.UpdateAsync(entity);
                Assert.NotNull(registerUpdated);
                Assert.Equal(entity.Email, registerUpdated.Email);
                Assert.Equal(entity.Name, registerUpdated.Name);
                Assert.False(registerCreated.Id == Guid.Empty);

                var registerSelected = await _repository.SelectAsync(registerUpdated.Id);
                Assert.NotNull(registerSelected);
                Assert.Equal(registerSelected.Email, registerUpdated.Email);
                Assert.Equal(registerSelected.Name, registerUpdated.Name);

                var registers = await _repository.SelectAsync();
                Assert.NotNull(registerSelected);
                Assert.True(registers.Any());

                var deleted = await _repository.DeleteAsync(registerSelected.Id);
                Assert.True(deleted);



            }
        }
    }
}
