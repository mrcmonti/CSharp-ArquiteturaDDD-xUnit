﻿using AutoMapper;
using Domain.Dtos.User;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.User;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();

            return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<UserDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
