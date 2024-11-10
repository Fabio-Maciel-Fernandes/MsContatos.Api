using MsContatos.Core.Models;

namespace MsContatos.Infra.Repositories.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        public Task<IEnumerable<Contato>> GetAllAsync(int? ddd, CancellationToken cancellationToken);
    }
}
