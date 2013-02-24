using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VivaldiSite
{

    public partial class disp_singin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public Boolean ConnectToWebService(string url)
        {
            Fwk.Bases.Connector.WebServiceWrapper wrapper = new Fwk.Bases.Connector.WebServiceWrapper();
            wrapper.SourceInfo = url;

            return wrapper.RetriveProviders().Count > 0;
        }
    }
}