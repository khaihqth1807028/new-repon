using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App5.Entity;

namespace App5.Service
{
    interface IFileService
    {
        Task<bool> SaveMemberCredentialToFile(MemberCredential memberCredential);

        Task<MemberCredential> ReadMemberCredentialFromFile();
    }
}
