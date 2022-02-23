using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Phonebook.Contracts;
using Phonebook.EF;

namespace Phonebook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhonebookController : ControllerBase
    {
        private readonly ILogger<PhonebookController> _logger;
        private readonly IDataRepository _dataRepository;

        public PhonebookController(
            ILogger<PhonebookController> logger, 
            IDataRepository dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        /// <summary>
        /// Retrieve users from database
        /// </summary>
        /// <param name="sortField">Possible values: fisrtname, lastname, birthdate</param>
        /// <param name="sortOrder">Possible values: asc, desc</param>
        /// <param name="page">Default: 1</param>
        /// <param name="itemsOnPage">Default: 10</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PhonebookUser>> Get(string sortField, string sortOrder, int page = 1, int itemsOnPage = 10)
        {
            if (page < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(page), "Page must be great than 0");
            }

            if (itemsOnPage <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(page), "Items on page must be great than 1");
            }

            return await _dataRepository.GetUsersAsync(sortField, sortOrder, page, itemsOnPage);
        }
    }
}
