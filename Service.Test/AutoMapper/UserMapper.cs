using Domain.Dtos.User;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Service.Test.AutoMapper
{
    public class UserMapper : BaseTestService
    {
        [Fact(DisplayName = "É possivel mapear os modelos")]
        public void CanMapModels()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            //Model => Entity
            var dtoEntity = Mapper.Map<UserEntity>(model);
            Assert.Equal(dtoEntity.Id, model.Id);
            Assert.Equal(dtoEntity.Name, model.Name);
            Assert.Equal(dtoEntity.Email, model.Email);
            Assert.Equal(dtoEntity.CreatedAt, model.CreatedAt);
            Assert.Equal(dtoEntity.UpdatedAt, model.UpdatedAt);

            //Entity => Dto
            var userDto = Mapper.Map<UserDto>(dtoEntity);
            Assert.Equal(dtoEntity.Id, userDto.Id);
            Assert.Equal(dtoEntity.Name, userDto.Name);
            Assert.Equal(dtoEntity.Email, userDto.Email);
            Assert.Equal(dtoEntity.CreatedAt, userDto.CreatedAt);

        }
    }
}
