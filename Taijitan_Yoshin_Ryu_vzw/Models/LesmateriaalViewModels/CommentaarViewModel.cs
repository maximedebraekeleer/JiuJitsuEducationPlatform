using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Models.LesmateriaalViewModels
{
    public class CommentaarViewModel
    {
        public List<Commentaar> Commentaren { get; set; }

        public CommentaarViewModel(List<Commentaar> commentaren)
        {
            Commentaren = commentaren;
        }
    }
}
