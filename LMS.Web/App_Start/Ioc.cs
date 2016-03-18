using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using LMS.Domain.Repositories;
using LMS.Web.Controllers.ModelBuilders;

namespace LMS.Web
{
    /// <summary>
    ///  Class to implement DI using ninject 
    /// </summary>
    /// 
    public static class IoC
    {
        public static StandardKernel Kernal { get; private set; }

        public static void RegisterTypes()
        {
            Kernal = new StandardKernel();

            // Bindings
            Kernal.Bind<IIssueDtoBuilder>().To<IssueDtoBuilder>();
            Kernal.Bind<IBookDtoBuilder>().To<BookDtoBuilder>();
            Kernal.Bind<IStockDtoBuilder>().To<StockDtoBuilder>();
            Kernal.Bind<ILmsSearchDtoBuilder>().To<LmsSearchDtoBuilder>();
            Kernal.Bind<IBookRepository>().To<BookRepository>();
            Kernal.Bind<IStockRepository>().To<StockRepository>();
            Kernal.Bind<IIssueRepository>().To<IssueRepository>();
        }
    }
}