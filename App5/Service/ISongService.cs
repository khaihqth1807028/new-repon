using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App5.Entity;

namespace App5.Service
{
    interface ISongService
    {
        Song CreateSong(MemberCredential memberCredential, Song song);
        List<Song> GetAllSong(MemberCredential memberCredential);
        List<Song> GetMineSongs(MemberCredential memberCredential);
    }
}
