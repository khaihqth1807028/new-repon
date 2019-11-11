using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App5.Entity;

namespace App5.Service
{
    interface IMemberService
    {
        Member Register(Member member);

        MemberCredential Login(MemberLogin memberLogin);

        Member GetInformation(string token);
    }
}
