using System.Collections.Generic;
using Lemoras.Remora.Admin.Business.Base;
using Lemoras.Remora.Admin.Domain.Page;

namespace Lemoras.Remora.Admin.Business
{
    public class PageService : BasePageService, IPageService
    {
        public override PageDetail AddPageDetail()
        {
            return default(PageDetail);
        }

        public override Page AddPage()
        {
            return default(Page);
        }

        public override string AddPageProperty()
        {
            return default(string);
        }

        public override void DeletePageDetail(int pageDetailId)
        {
        }

        public override void DeletePage(int pageId)
        {
        }

        public override void DeletePageProperty(int pagePropertyId)
        {
        }

        public override IEnumerable<PageDetail> GetPageDetails()
        {
            return default(IEnumerable<PageDetail>);
        }

        public override IEnumerable<Page> GetPages()
        {
            return default(IEnumerable<Page>);
        }

        public override IEnumerable<string> GetPageProperties()
        {
            return default(IEnumerable<string>);
        }
    }
}
