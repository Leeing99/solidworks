using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwAPIdiploma
{
    internal class GetSolidworks
    {
        private static SldWorks swApp;

        public GetSolidworks()
        {

        }


        internal static SldWorks GetApplication()
        {
            if (swApp == null)
            {
                swApp = Activator.CreateInstance(Type.GetTypeFromProgID("sldworks.Application")) as SldWorks;
                swApp.Visible = true;
                return swApp;
            }
            return swApp;
        }

    }
}
