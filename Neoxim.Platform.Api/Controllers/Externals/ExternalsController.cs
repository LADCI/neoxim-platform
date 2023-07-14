using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Neoxim.Platform.Core.Infrastructure;
using Neoxim.Platform.Core.Services;
using Neoxim.Platform.Infrastructure.Externals.Autodesk;

namespace Neoxim.Platform.Api.Controllers.Externals
{
    [ApiController]
    [Route("api/ext-providers")]
    public partial class ExternalsController : ControllerBase
    {
        private readonly APS _aps;
        private readonly IDocumentService _documentService;
        private readonly IStorageService _storageService;
        private readonly IMemoryCache _memoryCache;
        private readonly int CACHE_EXPIRATION_DURATION = 24;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="documentService"></param>
        /// <param name="storageService"></param>
        /// <param name="memoryCache"></param>
        /// <param name="aps"></param>
        public ExternalsController(
            IDocumentService documentService,
            IStorageService storageService,
            IMemoryCache memoryCache, 
            APS aps)
        {
            _documentService = documentService;
            _storageService = storageService;
            _memoryCache = memoryCache;
            _aps = aps;  
        }
    }
}