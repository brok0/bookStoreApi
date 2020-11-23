using AutoMapper;
using bookStore.BusinessLogic.Abstractions;
using bookStore.Domain.Models;
using bookStoreApi.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookStoreApi.Controllers
{
    [ApiController]
    public class AppController : ControllerBase
    {
        public readonly IAppService _appService;
        public readonly IMapper _mapper;
        public AppController(IAppService appService,IMapper mapper)
        {
            _appService = appService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("/book")]
        public async Task <IActionResult> GetOneBookAsync([FromQuery]int id)
        {
            var book = await _appService.GetOneBookAsync(id);
            return Ok(_mapper.Map<BookReadDto>(book));

        }
        [HttpGet]
        [Route("/author")]
        public async Task <IActionResult> GetOneAuthorAsync([FromQuery] int id)
        {
            var author = await _appService.GetOneAuthorAsync(id);
            return Ok(_mapper.Map<AuthorReadDto>(author));

        }
        [HttpGet]
        [Route("/printing")]
        public async Task<IActionResult> GetOnePrintingAsync([FromQuery] int id)
        {
            var printing = await _appService.GetOnePrintingAsync(id);
            return Ok(_mapper.Map<PrintingReadDto>(printing));
        }


        [HttpDelete]
        [Route("/book/delete")]
        public async Task <IActionResult> DeleteBook ([FromQuery] int id)
        {
            await _appService.DeleteBookAsync(id);
            return NoContent();
        }
        [HttpDelete]
        [Route("/author/delete")]
        public async Task <IActionResult> DeleteAuthor ([FromQuery] int id)
        {
            await _appService.DeleteAuthorAsync(id);
            return NoContent();
        }
        [HttpDelete]
        [Route("/printing/delete")]
        public async Task <IActionResult> DeletePrinting([FromQuery]int id)
        {
            await _appService.DeletePrintingAsync(id);
            return NoContent();
        }

        [HttpGet]
        [Route("/book/all")]
        public async Task <IActionResult> GetAllBooksAsync()
        {
            var books = await _appService.GetAllBooksAsync();
            return Ok(_mapper.Map<IEnumerable<BookReadDto>>(books));
        }

        [HttpGet]
        [Route("/author/all")]
        public async Task <IActionResult> GetAllAuthors()
        {
            var authors = await _appService.GetAllAuthorsAsync();
            return Ok(_mapper.Map<IEnumerable<AuthorReadDto>>(authors));
        }
        [HttpGet]
        [Route("/printing/all")]
        public async Task <IActionResult> GetAllPrintings()
        {
            var printings = await _appService.GetAllPrintingsAsync();
            return Ok(_mapper.Map<IEnumerable<PrintingReadDto>>(printings));
        }

        [HttpPost]
        [Route("/book/new")]
        public async Task <IActionResult> CreateNewBook([FromBody] BookCreateDto book)
        {
            var newBook = await _appService.AddNewBookAsync(_mapper.Map<Book>(book));
            return Ok();
        }
        [HttpPost]
        [Route("/author/new")]
        public async Task <IActionResult> CreateNewAuthor ([FromBody] AuthorCreateDto author)
        {
          
            await _appService.AddAuthorAsync(_mapper.Map<Author>(author));
            return Ok();
        }

        [HttpPost]
        [Route("/printing/new")]
        public async Task <IActionResult> CreateNewPrinting ([FromBody] PrintingCreateDto printing)
        {
            
            await _appService.AddPrintingAsync(_mapper.Map<Printing>(printing));
            return Ok();
        }

        [HttpPut]
        [Route("/book/edit")]
        public async Task<IActionResult> UpdateBook([FromBody] BookUpdateDto book)
        {
            var newBook = await _appService.UpdateBookAsync(_mapper.Map<Book>(book));
            return Ok();
        }


        
        /*[HttpPost]
        [Route("/author/edit")]
        public async Task<IActionResult> UpdateAuthor([FromBody] AuthorCreateDto author)
        {
            await _appService.u(_mapper.Map<Author>(author));
            return Ok();
        }

        [HttpPost]
        [Route("/printing/edit")]
        public async Task<IActionResult> UpdatePrinting([FromBody] PrintingCreateDto printing)
        {
            await _appService.AddPrintingAsync(_mapper.Map<Printing>(printing));
            return Ok();
        }*/
    }
}
