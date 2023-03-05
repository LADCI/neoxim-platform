using Neoxim.Platform.SharedKernel.Exceptions;

namespace Neoxim.Platform.SharedKernel.Base
{
    public abstract class BaseException : Exception, IEquatable<BaseException>
    {
        protected BaseException(AppError error) : base(error.ToString())
        {
            Error = error;
        }

        public AppError Error { get; set; }

        public override int GetHashCode()
        {
            return (Error.Code).GetHashCode();
        }


        public bool Equals(BaseException other)
        {
            if(other == null) return false;

            return Error.Code == other.Error.Code;
        }
    }
}