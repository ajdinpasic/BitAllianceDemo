using Microsoft.AspNetCore.Mvc;
using LibraryManagement.BLL.Data;
using LibraryManagement.BLL.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        // GET: api/<MemberController>
        [HttpGet]
        public IEnumerable<MemberDTO> GetMembers()
        {
            return _memberService.GetMembers();
        }

        //// GET api/<MemberController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<MemberController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<MemberController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MemberController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
