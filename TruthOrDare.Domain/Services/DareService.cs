using System;
using System.Collections.Generic;
using TruthOrDare.Domain.Commands.Dare;
using TruthOrDare.Domain.Contracts.Repositories;
using TruthOrDare.Domain.Contracts.Services;
using TruthOrDare.Domain.Entities.Models;
using TruthOrDare.Domain.Enums;

namespace DareOrDare.Domain.Services
{
    public class DareService : IDareService
    {
        private readonly IDareRepository _dareRepository;
        public DareService(IDareRepository dareRepository)
        {
            _dareRepository = dareRepository;
        }

        public Dare GetById(Guid id)
        {
            try
            {
                var dare = _dareRepository.Read(id);
                return dare;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Get User By Id Error");
            }
        }
        public List<Dare> GetByType(int type)
        {
            try
            {
                var EType = (ETruthOrDareType)type;
                var list = _dareRepository.GetDareListByType(EType);
                return list;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Get User By Id Error");
            }
        }

        public void Add(DareAddCommand command)
        {
            try
            {
                var dare = new Dare { Description = command.Description, Type = command.Type };
                _dareRepository.Create(dare);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(DareUpdateCommand command)
        {
            try
            {
                var dare = _dareRepository.Read(command.Id);
                dare.Type = command.Type;
                dare.Description = command.Description;
                _dareRepository.Update(dare);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(DareDeleteCommand command)
        {
            try
            {
                var dare = _dareRepository.Read(command.Id);
                _dareRepository.Delete(dare);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
