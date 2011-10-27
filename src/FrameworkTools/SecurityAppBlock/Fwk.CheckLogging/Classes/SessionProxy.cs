using System;
using System.Web.SessionState;


using System.Security.Principal;
using Microsoft.Practices.EnterpriseLibrary.Security;

using System.Web;


namespace Security
{
    public static class SessionMannager
    {
       

        static SessionMannager()
        {
            //ImageMapPath = HttpContext.Current.Server.MapPath("/store");
        }
        static SessionProxy _SessionProxy;

        public static SessionProxy Session(HttpSessionState pageSession)
        {
            
            if(_SessionProxy == null)
                _SessionProxy = new SessionProxy(pageSession);
            return _SessionProxy;
        }
    }

    public class SessionProxy
    {
        private HttpSessionState _CurrentSession;


      
        public SessionProxy(HttpSessionState PageSession)
        {
            _CurrentSession = PageSession;
        }

         /// <summary>
        /// Limpia el ProxySession
        /// </summary>
        public void Clear()
        {
            //ClearFilters();

            Error = null;


  
            //_CurrentSession["FirstTime"] = null;
            //_CurrentSession["WasClosed"] = null;

            _CurrentSession["EditNewsList"] = null;


      
       
            
            //CurrentUserInfo = null;
            RuleProvider = null;
            Principal = null;
            
            _CurrentSession = null;
        }

        public void ClearFilters()
        {
            //Limpio los filtros
            //_CurrentSession["CounterFilters"] = null;
            //_CurrentSession["CounterAttributes"] = null;
            //_CurrentSession["FilterTextBoxList"] = null;
            //_CurrentSession["FilterDropDownList"] = null;
            //_CurrentSession["FilterButtonList"] = null;

            
     

            //limpio filtros para JS
            //_CurrentSession["FilterAndValues"] = string.Empty;
          
        }

      
        public  Exception Error
        {
            get { return (Exception)_CurrentSession["Error"]; }
            set { _CurrentSession["Error"] = value; }
        }

       

        public HttpSessionState CurrentSession
        {
            get { return _CurrentSession; }
        }


        //public NewsList EditNewsList
        //{
        //    get { return (NewsList)_CurrentSession["NewsList"]; }
        //    set { _CurrentSession["NewsList"] = value; }
        //}

        //public  Boolean FirstTime
        //{
        //    get { return (Boolean)_CurrentSession["FirstTime"]; }
        //    set { _CurrentSession["FirstTime"] = value; }
        //}

        //public  Boolean WasClosed
        //{
        //    get { return (Boolean)_CurrentSession["WasClosed"]; }
        //    set { _CurrentSession["WasClosed"] = value; }
        //}

        public IAuthorizationProvider RuleProvider
        {
            get { return (IAuthorizationProvider)_CurrentSession["RuleProvider"]; }
            set { _CurrentSession["RuleProvider"] = value; }
        }

        public IPrincipal Principal
        {
            get { return (IPrincipal)_CurrentSession["Principal"]; }
            set { _CurrentSession["Principal"] = value; }
        }
    }

    public class WebUserControlsConstants
    {

        public const string NavigateUrl_Admin_CreateRichNews = "~/Modules/Admin/Admin_CreateRichNews.aspx";
        public const string News_ItemList = "~/UserControl/News_ItemList_Link.ascx";
        public const string News_SimpleView = "~/UserControl/News_SimpleView.ascx";
        public const string NavigateUrl_NewsFullView = "~/Modules/Noticias/NewsFullView.aspx?id={0}";
        public const string NavigateUrl_Admin_NewsUpdate = "~/Modules/Admin/Admin_NewsUpdate.aspx?id={0}";

        public const string NavigateUrl_News = "~/Modules/Noticias/News.aspx?t={0}";

        public const string NotAuthorizedUser_Redirect = @"~/modules/Admin/Admin_NotAuthorizedUser.aspx?id={0}";

        public const string CaptchaPageUrl_News = "~/Modules/Admin/Admin_SecCapt.aspx?t={0}";

        internal const string ImgPath = "/store/news";

        internal const int ImgWidth_Small = 210;
        internal const int ImgHeight_Small = 190;
        internal const int ImgWidth_Medium = 570;
        internal const int ImgHeight_Medium = 500;



        /// <summary>
        /// {4} id de la imagen coincide c0on el id del div q la contiene
        /// </summary>
        internal const string UrlImageTemplate = "<p><img style=\"cursor:pointer;\" width=\"{3}\" height =\"{4}\" onclick=\"javascript:amply(this,'{5}')\" title=\"{0}\" src=\"{1}\" alt=\"{2}\" border=\"0\" /></p>";
   
        /// <summary>
        /// Obtiene 
        /// </summary>
        internal const string ImageDiv = "<div id =\"{0}\" class=\"news_img {1}\">";

        /// <summary>
        /// facebook button Like
        /// {url}
        /// </summary>
        internal const string fb_like = "  <fb:like href=\"{0}\" send=\"true\" width=\"450\" show_faces=\"true\" font=\"verdana\"></fb:like>";
    }
}
