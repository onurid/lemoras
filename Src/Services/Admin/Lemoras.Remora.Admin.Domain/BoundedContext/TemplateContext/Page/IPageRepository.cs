using System.Collections.Generic;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Domain.Page
{
    public interface IPageRepository : IBaseRepository<IPageModelKey>, ITransientDependency
    {
        Page AddNewPage(Page page, bool isPassive = true);
        void RowDeletePage(int pageId);
        List<Page> GetPages();

        //List<Page> GetPagesByRole(IEnumerable<int> roleIds);
    }
}