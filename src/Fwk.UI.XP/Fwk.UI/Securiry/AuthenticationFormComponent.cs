using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.UI.Security.Controls
{
    [ToolboxItem(true), ToolboxBitmap(typeof(AuthenticationFormComponent), "AuthenticationFormComponent")]
    public partial class AuthenticationFormComponent : Control
    {
        #region [Properties]
        
        
       

        /// <summary>
        /// Icono a mostrar
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Icono a mostrar")]
        public Image Auth_Title_Image{get;set;}
 
        /// <summary>
        /// Titulo
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Titulo")]
        public String Auth_Title_Text{get;set;}
       
        [CategoryAttribute("Fwk.Factory"), Description("Font")]
        public Font Auth_Title_Font{get;set;}
       
        #endregion
        public AuthenticationFormComponent()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }


        /// <summary>
        /// Levanta el formulario  FRM_AuthenticationForm_ASPNet. 
        /// Luego de esta llamada lea los resultados de la autorizacion directamente desde 
        /// FormBase.Principal.Identity
        /// </summary>
        /// <param name="pMessage">Mensaje a mostrar</param>
        /// <returns>DialogResult</returns>
        public DialogResult Show(String pMessage, string user, string password)
        {
            using (FRM_AuthenticationForm_ASPNet wAuthForm = new FRM_AuthenticationForm_ASPNet())
            {
                wAuthForm.Auth_Title_Font = Font;
                wAuthForm.Auth_Title_Image = Auth_Title_Image;
                wAuthForm.Auth_Title_Text = Auth_Title_Text;
                wAuthForm.InitCredentials(user, password);
                wAuthForm.ShowDialog(this);
        
                return wAuthForm.DialogResult;
            }
           
        }
    }
}
