using Framework.Core;
using Slice.Data;
using SubjectEngine.Data;
using System.Collections.Generic;
using System;

namespace Slice.DataConverter
{
    public class KeywordConverter : IDataConverter<KeywordData, KeywordDto>
    {
        public IEnumerable<KeywordDto> Convert(IEnumerable<KeywordData> entitys)
        {
            List<KeywordDto> dtoList = new List<KeywordDto>();

            entitys.ForAll(e => dtoList.Add(Convert(e)));

            return dtoList;
        }

        public KeywordDto Convert(KeywordData entity)
        {
            KeywordDto dto = new KeywordDto();
            dto.Id = entity.Id;
            if (entity.Id != null)
            {
                dto.StringId = entity.Id.ToString();
            }
            dto.Display = entity.Name;
            dto.Name = entity.Name;
            dto.Slug = entity.Name.ToSlug();
            dto.TemplateId = entity.TemplateId;

            return dto;
        }
    }
}
