using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.DAL.Data;

namespace LibraryManagement.DAL.Interfaces
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
    }
}
