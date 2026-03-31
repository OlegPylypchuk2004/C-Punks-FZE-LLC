using System.Threading;
using Cysharp.Threading.Tasks;

namespace Services
{
    public interface IService
    {
        public UniTask InitializeAsync(CancellationToken cancellationToken);
    }
}