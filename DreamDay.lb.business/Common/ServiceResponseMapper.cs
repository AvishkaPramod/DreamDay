using DreamDay.lb.shared.Contracts;
using DreamDay.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDay.lb.business.Common
{
    public class ServiceResponseMapper: IMapper<Object, ResponseBase>
    {
        /// <summary>
        /// Map success response
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ResponseBase Map(object input)
        {
            return new ResponseBase
            {
                Result = input,
                IsSuccess = true,
                Error = null
            };
        }
    }
}
