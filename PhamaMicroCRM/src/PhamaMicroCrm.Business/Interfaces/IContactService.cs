using PhamaMicroCrm.Model.Entities;
using System;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Business.Interfaces
{
    public interface IContactService : IDisposable
    {
        Task Add(Contact contact);
        Task Update(Contact contact);
        Task Remove(Guid id);
    }
}
