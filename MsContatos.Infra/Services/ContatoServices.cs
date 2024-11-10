using MsContatos.Core.Models;
using MsContatos.Infra.Repositories.Interfaces;
using MsContatos.Infra.Services.Interfaces;
using MsContatos.Shared.Extensions;
using System.ComponentModel.DataAnnotations;

namespace MsContatos.Infra.Services
{
    public class ContatoServices : IContatoServices
    {
        private readonly IContatoRepository _repository;

        public ContatoServices(IContatoRepository repository)
        {
            _repository = repository;           
        }

        public void CreateAsync(Contato model)
        {
            if (model.Ok())
            {
                _repository.CreateAsync(model);
            }
            else
            {
                throw new ValidationException(model.ObterErros());
            }
        }

        public void DeleteAsync(int id)
        {
            _repository.DeleteAsync(id);
        }

        public async Task<bool> ExistAsync(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id, cancellationToken) != null;
        }

        public async Task<IEnumerable<Contato>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }

        public async Task<IEnumerable<Contato>> GetAllAsync(int? ddd, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(ddd, cancellationToken);
        }

        public async Task<Contato> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }

        public void UpdateAsync(Contato model)
        {
            if (model.Ok())
            {
                _repository.UpdateAsync(model);
            }
            else
            {
                throw new ValidationException(model.ObterErros());
            }              
        }
    }
}