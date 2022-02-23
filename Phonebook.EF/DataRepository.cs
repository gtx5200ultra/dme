using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Phonebook.Contracts.Models;
using Phonebook.EF.Interfaces;

namespace Phonebook.EF
{
    public class DataRepository : IDataRepository
    {
        private readonly PhonebookContext _context;
        private readonly IMapper _mapper;

        public DataRepository(PhonebookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PhonebookUser>> GetUsersAsync(string sortField, string sortOrder, int page = 1, int itemsOnPage = 10)
        {
            var itemsDbQuery = _context
                .Users
                .Include(x => x.Picture)
                .AsQueryable();

            if (!string.IsNullOrEmpty(sortField))
            {
                itemsDbQuery = sortField switch
                {
                    "firstname" => sortOrder switch
                    {
                        "desc" => itemsDbQuery.OrderByDescending(x => x.FirstName),
                        "asc" => itemsDbQuery.OrderBy(x => x.FirstName),
                        _ => itemsDbQuery
                    },
                    "lastname" => sortOrder switch
                    {
                        "desc" => itemsDbQuery.OrderByDescending(x => x.LastName),
                        "asc" => itemsDbQuery.OrderBy(x => x.LastName),
                        _ => itemsDbQuery
                    },
                    "birthdate" => sortOrder switch
                    {
                        "desc" => itemsDbQuery.OrderByDescending(x => x.BirthDate),
                        "asc" => itemsDbQuery.OrderBy(x => x.BirthDate),
                        _ => itemsDbQuery
                    },
                    _ => itemsDbQuery
                };
            }

            itemsDbQuery = itemsDbQuery.Skip(itemsOnPage * (page - 1)).Take(itemsOnPage);

            var itemsDb = await itemsDbQuery.ToListAsync();
            return _mapper.Map<IEnumerable<PhonebookUser>>(itemsDb);
        }
    }
}