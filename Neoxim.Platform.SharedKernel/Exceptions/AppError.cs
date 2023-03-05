using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoxim.Platform.SharedKernel.Exceptions
{
    public class AppError
    {
        protected AppError()
        {
        }

        public ErrorCode Code { get; protected set; } = ErrorCode.ERR_GEN_01;
        public string Message { get; protected set; } = "Unexpected error occurred";

        public static AppError CreateNew(ErrorCode code, string message)
        {
            return new AppError
            {
                Code = code,
                Message = message
            };
        }

        public override string ToString()
        {
            return $"{Code} - {Message}";
        }

        public enum ErrorCode
        {
            // Error de base
            ERR_GEN_01,

            // Controller
            ERR_CTL_01,

            // Services
            ERR_SVC_01,

            // Data access
            ERR_DATA_01,

            // External Api calls
            ERR_EXT_API_01
        }
    }
}