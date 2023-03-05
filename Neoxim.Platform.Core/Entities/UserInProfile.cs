using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class UserInProfile : BaseEntity
    {
        public User User { get; protected set; }
        public Profile Profile { get; protected set; }
    }
}