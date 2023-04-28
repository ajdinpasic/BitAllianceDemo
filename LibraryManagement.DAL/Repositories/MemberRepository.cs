using LibraryManagement.DAL.Data;
using LibraryManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public MemberRepository() { }

        public IEnumerable<Member> GetMembers()
        {
            List<Member> members = new List<Member>
            {
                new Member
                {
                    MemberId = Guid.NewGuid(),
                    FirstName = "Hello",
                    LastName = "There"
                },
                 new Member
                {
                    MemberId = Guid.NewGuid(),
                    FirstName = "Hello",
                    LastName = "There"
                }
            };
            return members;
        }
    }
}
