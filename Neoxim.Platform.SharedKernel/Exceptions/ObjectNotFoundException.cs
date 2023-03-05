using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.SharedKernel.Exceptions
{
    public class ObjectNotFoundException : BaseException
    {
        public ObjectNotFoundException(string id, string className)
            : base(AppError.CreateNew(AppError.ErrorCode.ERR_DATA_01, $"Not found an instance of {className} with this id {id}"))
        {
        }
    }
}