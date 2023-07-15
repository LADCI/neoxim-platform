namespace Neoxim.Platform.Core.Enums
{
    [Flags]
    public enum DocumentTypeEnum
    {
        NONE = 0,
        IFC = 1,
        DWG = 2,
        RVT = 4,
        ARCH = 8,
        PDF = 16,
        EXCEL = 32,
        WORD = 64,
        PPT = 128,

        IS_APS_MODELS = IFC | DWG | RVT | ARCH
    }
}