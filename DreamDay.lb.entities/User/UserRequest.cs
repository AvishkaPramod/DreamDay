using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDay.lb.entities.User
{
    public class UserRequest
    {
        public string Action {  get; set; }
        public UserAttributes Attributes { get; set; }
    }
}
