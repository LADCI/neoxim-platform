using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.SharedKernel.Exceptions
{
    public class ObjectAlreadyExistsException : BaseException
    {
        public ObjectAlreadyExistsException(string name, string className)
            : base(AppError.CreateNew(AppError.ErrorCode.ERR_DATA_01, $"An instance of {className} with the same name ({name}) already exists."))
        {
        }
    }
}