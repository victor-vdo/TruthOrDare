using System;
using TruthOrDare.Domain.Commands.Truth;
using TruthOrDare.Domain.Contracts.Repositories;
using TruthOrDare.Domain.Contracts.Services;
using TruthOrDare.Domain.Entities.Models;

namespace TruthOrDare.Domain.Services
{
    public class TruthService : ITruthService
    {
        private readonly ITruthRepository _truthRepository;
        public TruthService(ITruthRepository truthRepository)
        {
            _truthRepository = truthRepository;
        }

        public Truth GetById(Guid id)
        {
            try
            {
                var truth = _truthRepository.Read(id);
                return truth;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Get User By Id Error");
            }
        }

        public void Add(TruthAddCommand command)
        {
            try
            {
                var user = new Truth {Description = command.Description, Type = command.Type };
                _truthRepository.Create(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(TruthUpdateCommand command)
        {
            try
            {
                var truth = _truthRepository.Read(command.Id);
                truth.Type = command.Type;
                truth.Description = command.Description;
                _truthRepository.Update(truth);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(TruthDeleteCommand command)
        {
            try
            {
                var truth = _truthRepository.Read(command.Id);
                _truthRepository.Delete(truth);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
