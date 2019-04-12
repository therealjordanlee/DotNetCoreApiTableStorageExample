using System.Threading.Tasks;
using DotNetCoreApiTableStorageExample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreApiTableStorageExample.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private IMessageRepository _messageRepository;

        public HomeController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetTableValue()
        {
            var result = await _messageRepository.GetRecord("123", "123");
            return Ok(result);
        }
    }
}
