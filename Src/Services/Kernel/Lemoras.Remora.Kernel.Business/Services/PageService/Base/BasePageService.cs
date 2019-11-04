using System.Collections.Generic;
using Lemoras.Remora.Kernel.Domain.Factory;
using Lemoras.Remora.Kernel.Domain.Page;
using OYASAR.Framework.Core;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Utils;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Kernel.Business.Base
{
    public abstract class BasePageService : IBasePageService
    {
        protected readonly IRepositoryFactory repositories;

        public BasePageService()
        {
            repositories = Invoke<IRepositoryFactory>.Call();
        }

        public virtual PageDetail AddPageDetail()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual Page AddPage()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual string AddPageProperty()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeletePageDetail(int pageDetailId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeletePage(int pageId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeletePageProperty(int pagePropertyId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<PageDetail> GetPageDetails()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<Page> GetPages()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<string> GetPageProperties()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }
    }
}
