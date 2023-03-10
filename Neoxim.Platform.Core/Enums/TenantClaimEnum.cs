using System.ComponentModel;

namespace Neoxim.Platform.Core.Enums
{
    public enum TenantClaimEnum
    {
        [Description("Admin can do every thing")]
        ADMIN,

        [Description("This role allow you to upload documents")]
        UPLOAD,

        [Description("This role allow you to download documents")]
        DOWNLOAD,

        [Description("This role allow you to create and edit a resource")]
        WRITE,

        [Description("This is a limited role. It is only for read resources")]
        READ
    }
}