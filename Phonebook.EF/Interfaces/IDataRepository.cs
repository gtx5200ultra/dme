using System.Collections.Generic;
using System.Threading.Tasks;
using Phonebook.Contracts.Models;

namespace Phonebook.EF.Interfaces
{
    public interface IDataRepository
    {
        Task<IEnumerable<PhonebookUser>> GetUsersAsync(string sortField, string sortOrder, int page = 1,
            int itemsOnPage = 10);
    }
}
