using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Core.ViewModels
{
    public class PagingViewModel
    {
        public int NumberOfPages { get; set; }

        public int CureentPage { get; set; }

        public object Data { get; set; }
    }
}
