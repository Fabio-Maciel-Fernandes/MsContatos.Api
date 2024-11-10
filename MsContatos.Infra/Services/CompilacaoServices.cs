using MsContatos.Core.Models;
using MsContatos.Infra.Repositories.Interfaces;
using MsContatos.Infra.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MsContatos.Infra.Services
{
    public class CompilacaoServices : IServices<Compilacao>
    {
        private readonly IRepository<Compilacao> _repository;
       
        public CompilacaoServices(IRepository<Compilacao> repository)
        {
            _repository = repository;
        }

        public void CreateAsync(Compilacao model)
        {
            if (model.Ok())
            {
                _repository.CreateAsync(model);
            }
            else
            {
                throw new ValidationException(model.ErrrsString());
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

        public async Task<IEnumerable<Compilacao>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }

        public async Task<Compilacao> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }

        public void UpdateAsync(Compilacao model)
        {
            if (model.Ok())
            {
                _repository.UpdateAsync(model);
            }
            else
            {
                throw new ValidationException(model.ErrrsString());
            }

        }
    }
}