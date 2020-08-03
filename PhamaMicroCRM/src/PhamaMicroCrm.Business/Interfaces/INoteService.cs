using PhamaMicroCrm.Model.Entities;
using System;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Business.Interfaces
{
    public interface INoteService : IDisposable
    {
        Task Add(Note note);
        Task Update(Note note);
        Task Remove(Note note);
    }
}
