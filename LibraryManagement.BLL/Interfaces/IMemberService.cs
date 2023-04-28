﻿using LibraryManagement.BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.BLL.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<MemberDTO> GetMembers();
    }
}
