using Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Test.User
{
    public class UserTest
    {
        public static string Name { get; set; }
        public static string Email { get; set; }
        public static string NameModified { get; set; }
        public static string EmailModified { get; set; }
        public static Guid Id { get; set; }
        public List<UserDto> listUserDto = new List<UserDto>();
        public UserDto userDto;
        public UserDtoCreate userDtoCreate;
        public UserDtoCreateResult userDtoCreateResult;
        public UserDtoUpdate userDtoUpdate;
        public UserDtoUpdateResult userDtoUpdateResult;

        public UserTest() 
        {
            Id = Guid.NewGuid();
            Name = Faker.Name.FullName();
            Email = Faker.Internet.Email();
            NameModified = Faker.Name.FullName();
            EmailModified = Faker.Name.FullName();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };

                listUserDto.Add(dto);
            }

            userDto = new UserDto()
            {
                Id = Id,
                Name = Name,
                Email = Email
            };

            userDtoCreate = new UserDtoCreate()
            {
                Name = Name,
                Email = Email
            };

            userDtoCreateResult = new UserDtoCreateResult()
            {
                Id = Id,
                Name = Name,
                Email = Email,
                CreatedAt = DateTime.UtcNow
            };

            userDtoUpdate = new UserDtoUpdate()
            {
                Id = Id,
                Name = NameModified,
                Email = EmailModified,
            };

            userDtoUpdateResult = new UserDtoUpdateResult()
            {
                Id = Id,
                Name = NameModified,
                Email = EmailModified,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
