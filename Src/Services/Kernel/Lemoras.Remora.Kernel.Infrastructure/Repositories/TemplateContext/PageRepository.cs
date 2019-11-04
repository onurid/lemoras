using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Kernel.Domain.BoundedContext;
using Lemoras.Remora.Kernel.Domain.Page;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Infrastructure.Repositories.TemplateContext
{
    public class PageRepository : BaseRepository<IEFRepository<ITemplateContext>, IPageModelKey>, IPageRepository
    {
        public Page AddNewPage(Page page, bool isPassive = true)
        {
            this.Add<Page, int>(page);
            return page;
        }

        public List<Page> GetPages()
        {
            return GetAll<Page>().ToList();
        }

        public void RowDeletePage(int pageId)
        {
            this.RowDelete<Page>(pageId);
        }

        //public List<Page> GetPagesByRole(IEnumerable<int> roleIds)
        //{
        //    return GetAll<PageRole>(x => roleIds.Contains(x.RoleId)).Select(x => x.Page).ToList();
        //}
    }
}