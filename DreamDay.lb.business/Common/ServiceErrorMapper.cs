using DreamDay.lb.shared.Contracts;
using DreamDay.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDay.lb.business.Common
{
    /// <summary>
    /// ServiceErrorMapper
    /// </summary>
    /// <seealso cref="DreamDay.lb.shared.Contracts.IMapper{DreamDay.lb.shared.Models.ResponseMessage, DreamDay.lb.shared.Models.ResponseBase}" />
    public class ServiceErrorMapper: IMapper<ResponseMessage, ResponseBase>
    {
        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public ResponseBase Map(ResponseMessage input) => new ResponseBase
        {
            IsSuccess = false,
            Error = input
        };
    }
}
