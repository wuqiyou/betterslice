using System.Collections.Generic;
using Framework.Core;
using Slice.Data;
using SubjectEngine.Data;

namespace Slice.DataConverter
{
    public sealed class SubitemInfoConverter : IDataConverter<SubitemInfoData, SubitemInfoDto>
    {
        public IEnumerable<SubitemInfoDto> Convert(IEnumerable<SubitemInfoData> entitys)
        {
            List<SubitemInfoDto> dtoList = new List<SubitemInfoDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public SubitemInfoDto Convert(SubitemInfoData entity)
        {
            SubitemInfoDto dto = new SubitemInfoDto();

            dto.SubitemId = entity.Id;
            dto.ItemKey = entity.ItemKey;
            dto.ItemLabel = entity.ItemLabel;
            dto.IsMetaProvider = entity.IsMetaProvider;
            dto.DucType = entity.DucType;

            if (entity.Grid != null)
            {
                dto.Grid = new GridInfoConverter().Convert(entity.Grid);
            }

            return dto;
        }
    }
}
