using System.Collections.Generic;
using Framework.Core;
using Slice.Data;
using SubjectEngine.Data;

namespace Slice.DataConverter
{
    public sealed class GridRowInfoConverter : IDataConverter<GridRowInfoData, GridRowDto>
    {
        public IEnumerable<GridRowDto> Convert(IEnumerable<GridRowInfoData> entitys)
        {
            List<GridRowDto> dtoList = new List<GridRowDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public GridRowDto Convert(GridRowInfoData entity)
        {
            GridRowDto dto = new GridRowDto();

            dto.Id = entity.Id;
            dto.GridId = entity.GridId;
            dto.Sort = entity.Sort;
            if (entity.Cells != null)
            {
                dto.Cells = new GridCellInfoConverter().Convert(entity.Cells);
            }
            return dto;
        }
    }
}
