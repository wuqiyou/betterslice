﻿using Slice.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Slice.Service.Contract
{
    public interface IGeneralService : IBaseService
    {
        IEnumerable<LanguageDto> GetLanguages();
        IEnumerable<MetadataDto> GetMetadata();
        IEnumerable<MainMenuDto> GetPublishedMenus();
        UserIdentity Authenticate(string email, string encryptedPassword);
    }
}
