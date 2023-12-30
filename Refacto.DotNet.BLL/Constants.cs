using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refacto.DotNet.BLL
{
    public struct Constants
    {
        public struct ProductType
        {
            public static string NORMAL = "NORMAL";
            public static string SEASONAL = "SEASONAL";
            public static string EXPIRABLE = "EXPIRABLE";
            public static string FLASHSALE = "FLASHSALE";

            public ProductType()
            {
            }
        }
    }
}
