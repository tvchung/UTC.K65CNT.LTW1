using Microsoft.AspNetCore.Mvc;
using TvcLesson06Models.Models;

namespace TvcLesson06Models.Controllers
{
    public class TvcMemberController : Controller
    {
        // mock data
        private static readonly List<TvcMember> _tvcMembers = new List<TvcMember>()
        {
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcMemberUserName = "chungchung",
                TvcMemberPassword = "123456a@",
                TvcMemberEmail = "chungtrinhj@gmail.com",
                TvcMemberFullName = "Trịnh Văn Chung"
            },

            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcMemberUserName = "tranthib",
                TvcMemberPassword = "123456",
                TvcMemberEmail = "tranthib@gmail.com",
                TvcMemberFullName = "Trần Thị B"
            },

            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcMemberUserName = "levanc",
                TvcMemberPassword = "123456",
                TvcMemberEmail = "levanc@gmail.com",
                TvcMemberFullName = "Lê Văn C"
            },

            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcMemberUserName = "phamthid",
                TvcMemberPassword = "123456",
                TvcMemberEmail = "phamthid@gmail.com",
                TvcMemberFullName = "Phạm Thị D"
            },

            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcMemberUserName = "hoangvane",
                TvcMemberPassword = "123456",
                TvcMemberEmail = "hoangvane@gmail.com",
                TvcMemberFullName = "Hoàng Văn E"
            }
        };

        // GET: LIST
        public IActionResult TvcIndex()
        {
            return View(_tvcMembers);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        public IActionResult TvcCreate()
        {
            return View();
        }

        /// <summary>
        /// Create - submit form
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult TvcCreate(TvcMember tvcMember)
        {
            tvcMember.TvcMemberId = Guid.NewGuid().ToString();
            _tvcMembers.Add(tvcMember);
            return RedirectToAction("TvcIndex");
        }

        /// <summary>
        /// TvcEdit
        /// </summary>
        /// <returns></returns>

        public IActionResult TvcEdit(string id)
        {
            var  tvcMember = _tvcMembers.FirstOrDefault(x=>x.TvcMemberId.Equals(id));
            return View(tvcMember);
        }

        /// <summary>
        /// TvcEdit - submit form
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult TvcEdit(string id, TvcMember tvcMember)
        {

            for (int i = 0; i < _tvcMembers.Count; i++)
            {
                if(_tvcMembers[i].TvcMemberId == id)
                {
                    _tvcMembers[i].TvcMemberId=tvcMember.TvcMemberId;
                    _tvcMembers[i].TvcMemberUserName = tvcMember.TvcMemberUserName;
                    _tvcMembers[i].TvcMemberPassword = tvcMember.TvcMemberPassword;
                    _tvcMembers[i].TvcMemberFullName = tvcMember.TvcMemberFullName;
                    _tvcMembers[i].TvcMemberEmail = tvcMember.TvcMemberEmail;

                    break;
                }
               
            }
            
            return RedirectToAction("TvcIndex");
        }
        public IActionResult TvcGetDetails() 
        {
            var tvcMember = new TvcMember()
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcMemberUserName = "ChungTrinh",
                TvcMemberPassword = "Chung111@",
                TvcMemberFullName = "Trịnh Văn Chung",
                TvcMemberEmail = "chungtrinhj@gmail.com"
            };
            return View(tvcMember);
        }

    }
}
