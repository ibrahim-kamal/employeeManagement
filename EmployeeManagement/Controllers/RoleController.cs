using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{

    public class RoleController : Controller
    {


        public String view()
        {
            return "view Role";
        }
        [Authorize(Policy = "ViewRole")]
        public String  Index()
        {
            return "view Role";
        }


        [Authorize(Policy = "createRole")]
        public String create()
        {
            return "view Role";
        }


        



        [Authorize(Policy = "DeleteRole")]
        public String delete()
        {
            return "view Role";
        }




        [Authorize(Policy = "CustomEditRole")]
        //[Authorize(Policy = "EditRole")]
        public String custom(String userId)
        {
            return "custom edit Role" + userId;
        }


        [Authorize(Policy = "policyCustom")]
        //[Authorize(Policy = "EditRole")]
        public String policyCustom(String userId)
        {
            return "custom edit Role" + userId;
        }


    }
}
