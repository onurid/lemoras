using System.Collections.Generic;
using Lemoras.Remora.Core.Attribute;
using Lemoras.Remora.Core.Interceptor;
using Lemoras.Remora.Kernel.Domain.Page;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Business.Base
{
    public interface IPageService : IBasePageService, IRoleInterceptor, ITransientDependency
    {
    }

    public interface IBasePageService
    {
        [RoleSet("GetPages")]
        IEnumerable<Page> GetPages();

        [RoleSet("AddPage")]
        Page AddPage();

        [RoleSet("DeletePage")]
        void DeletePage(int pageId);

        [RoleSet("GetPageDetails")]
        IEnumerable<PageDetail> GetPageDetails();

        [RoleSet("AddPageDetail")]
        PageDetail AddPageDetail();

        [RoleSet("DeletePageDetail")]
        void DeletePageDetail(int pageDetailId);

        [RoleSet("GetPageProperties")]
        IEnumerable<string> GetPageProperties();

        [RoleSet("AddPageProperty")]
        string AddPageProperty();

        [RoleSet("DeletePageProperty")]
        void DeletePageProperty(int pagePropertyId);
    }
}
