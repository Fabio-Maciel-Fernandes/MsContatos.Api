using MsContatos.Core.Models;

namespace MsContatos.Infra.Services.Interfaces
{
    public interface IContatoServices : IServices<Contato>
    {
        public Task<IEnumerable<Contato>> GetAllAsync(int? ddd, CancellationToken cancellationToken);
    }
}
