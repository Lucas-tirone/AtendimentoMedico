
using Application.Common;

namespace Application.Interfaces
{
    public interface IDoctorService
    {
        Task<Result> DeleteAsync(int id);
    }
}
