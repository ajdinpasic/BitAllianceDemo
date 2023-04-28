using LibraryManagement.BLL.Data;
using LibraryManagement.BLL.Interfaces;
using LibraryManagement.DAL.Interfaces;
using LibraryManagement.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.BLL.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public IEnumerable<MemberDTO> GetMembers()
        {
            var members = _memberRepository.GetMembers();
            var converted = members.Select(

                x => new MemberDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName

                }

                );  // Conversion from MODEL/ENTITY to VIEW/DTO
            return converted;
        }
    }
}
