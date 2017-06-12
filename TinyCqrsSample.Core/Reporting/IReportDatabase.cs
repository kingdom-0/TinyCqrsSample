using System;
using System.Collections.Generic;

namespace TinyCqrsSample.Core.Reporting
{
    public interface IReportDatabase
    {
        DiaryItemDto GetById(Guid id);

        void Add(DiaryItemDto item);

        void Delete(Guid id);

        List<DiaryItemDto> GetItems();
    }
}
