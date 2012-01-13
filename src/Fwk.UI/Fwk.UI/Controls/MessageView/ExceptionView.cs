using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using DevExpress.XtraBars;

namespace Fwk.UI.Controls
{
    public partial class ExceptionView : MessageBase
    {

        #region --[enums]--

        private enum FormExpansion
        {
            Show = 0,
            Hide = 1
        };

        #endregion

        #region --[Properties]--

        private const int _HeightExpanded = 368;
        private const int _HeightCollapsed = 228;
        private FormExpansion _Detalle = FormExpansion.Show;
        private string _Source = String.Empty;
        private string _Detail = String.Empty;

        [CategoryAttribute("Bigbang.Factory"), Description("")]
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        
        [CategoryAttribute("Bigbang.Factory"), Description("")]
        public string Detail
        {
            get { return _Detail; }
            set { _Detail = value; }
        }
        /// <summary>
        ///Color del texbox
        /// </summary>
        [CategoryAttribute("Bigbang.Factory"), Description("")]
        public Color TextMessageColor
        {
            set { txtMessage.BackColor = value; }
            get { return txtMessage.BackColor; }
        }
        /// <summary>
        ///Color de texto del Mensaje
        /// </summary>
        [CategoryAttribute("Bigbang.Factory"), Description("")]
        public Color TextMessageForeColor
        {
            set { txtMessage.ForeColor = value; }
            get { return txtMessage.ForeColor; }
        }
        /// <summary>
        ///Visibilidad de los botones Yes / No
        /// </summary>
        [CategoryAttribute("Bigbang.Factory"), Description("")]
        public BarItemVisibility ButtonsYesNoVisible
        {
            set
            {

                btnOk.Visibility = value;
                btnNo.Visibility = value;
            }
            get { return btnOk.Visibility; }
        }
        #endregion

        #region --[constructor]--

        /// <summary>
        /// Inicializa una nueva instancia de la clase ExceptionView
        /// </summary>
        public ExceptionView()
        {
            InitializeComponent();
      
            
        }
        /// <summary>
        /// Muestra el Mensaje
        /// </summary>
        /// <param name="pMessage">Mensaje a mostrar</param>
        /// <param name="pMessageBoxButtons">Specifies constants defining which buttons to display on a System.Windows.Forms.MessageBox.</param>
        /// <param name="MessageBoxIcon">Specifies constants defining which information to display.</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Show(String pSource, String pMessage, String pDetail, String pTitle)
        {
            using (ExceptionView wfrmMessageView = new ExceptionView())
            {
                wfrmMessageView.Text = pTitle;
                wfrmMessageView.Message = pMessage;
                wfrmMessageView.Source = pSource;
                wfrmMessageView.Detail = pDetail;
                wfrmMessageView.ShowDialog();

                return wfrmMessageView.DialogResult;
            }
        }
        /// <summary>
        /// Muestra el Mensaje
        /// </summary>
        /// <param name="pMessage">Mensaje a mostrar</param>
        /// <param name="pMessageBoxButtons">Specifies constants defining which buttons to display on a System.Windows.Forms.MessageBox.</param>
        /// <param name="MessageBoxIcon">Specifies constants defining which information to display.</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Show(Exception e, String pTitle)
        {

            using (ExceptionView wfrmMessageView = new ExceptionView())
            {

                wfrmMessageView.Detail =string.Concat("Codigo de error : ",Fwk.Exceptions.ExceptionHelper.GetFwkErrorId(e),Environment.NewLine, Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e));
                wfrmMessageView.Message = e.Message;
                wfrmMessageView.Source = e.Source;

                if (!String.IsNullOrEmpty(pTitle))
                    wfrmMessageView.Text = pTitle;
                wfrmMessageView.ShowDialog();
                return wfrmMessageView.DialogResult;
            }
        }
        #endregion

        #region --[event handlers]--

        /// <summary>
        /// Responde al evento load del formulario
        /// inicializando algunos parametros del mismo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTechnicalMsg_Load(object sender, EventArgs e)
        {

            txtSource.Text = _Source;
            txtMessage.Text = base.Message;
            txtDetail.Text = _Detail;
         
        }

        private void ctlBarManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch(e.Item.Name)
            {
                case "btnExpandCollapse":
                    ShowDetail(e.Item);
                    break;
                case "btnSave":
                    SaveAs();
                    break;
                case "btnMail":
                    SendMail();
                    break;
                case "btnCopy":
                    CopyToClipBoard();
                    break;
                default:
                    break;
            }
        }
        
        #endregion

        #region --[toolbar methods]--

        /// <summary>
        /// Muestra la secci�n detalles del error del formulario.
        /// </summary>
        private void ShowDetail(BarItem pItem)
        {

            if (_Detalle == FormExpansion.Show)
            {
                this.Height = _HeightExpanded;
                pItem.Glyph = Fwk.UI.Properties.Resources.collapseVertical_16;
                //mnuExpandir.ToolTipText = "Ocultar detalle...";
                //mnuExpandir.Image = Fwk.Bases.FrontEnd.Controls.Properties.Resources.MaxImage;//imgFormExpansion.Images[1];
                _Detalle = FormExpansion.Hide;
            }
            else
            {
                this.Height = _HeightCollapsed;
                pItem.Glyph = Fwk.UI.Properties.Resources.expandVertical_16;
                //mnuExpandir.ToolTipText = "Ver detalle...";
                //mnuExpandir.Image = Fwk.Bases.FrontEnd.Controls.Properties.Resources.MinImage;
                _Detalle = FormExpansion.Show;
            }
            
        }

        /// <summary>
        /// Almacena informaci�n de la excepci�n en un archivo de texto.
        /// </summary>
        private void SaveAs()
        {
            FileStream wFs = null;
            string wPath = String.Empty;
            SaveFileDialog wDlg = new SaveFileDialog();
            wDlg.Filter = "Documentos de Texto|*.txt";

            if (wDlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            wFs = File.OpenWrite(wDlg.FileName);

            StreamWriter wSw = new StreamWriter(wFs);
            wSw.Write(txtDetail.Text);
            wSw.Close();
            wFs.Close();
        }

        /// <summary>
        /// Copia la excepci�n al clipboard.
        /// </summary>
        private void CopyToClipBoard()
        {
            Clipboard.SetDataObject(txtDetail.Text, true);
        }

        /// <summary>
        /// Envia la excepci�n por mail.
        /// </summary>
        private void SendMail()
        {
            System.Diagnostics.Process.Start("mailto:?body=" + txtDetail.Text);
        }
        #endregion

        private void btnOk_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNo_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
       
    }
}