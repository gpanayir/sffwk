using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Common;
using DevExpress.XtraEditors;

namespace Fwk.UI.Controls
{
    /// <summary>
    /// Esta es la clase que define la Tool bar para los componentes que reprecentan colecciones
    /// Reprecenta las acciones basicas de Agregar Editar y Remover.- 
    /// </summary>
    [DefaultEvent("OnActionClick")]
    [Designer(typeof(Designers.FwkControlDesigner))]
    public partial class UC_ToolBarListEditor : XtraUserControl
    {
        /// <summary>
        /// Evento que Click de todos los botones Retorna un evento con una enumeracion
        /// <see cref="Fwk.UI.Common.ActionTypes"/>
        /// </summary>
        [Category("Fwk.Factory")]
        public event OnActionClickHandler OnActionClick;

        /// <summary>
        /// Define el estili de pintado de un elemento determinado.-
        /// </summary>
        [Category("Fwk.Factory")]
        public DevExpress.XtraBars.BarItemPaintStyle CaptionsStyle
        {
            get { return this.bAddNewQuestion.PaintStyle; }
            set {

                this.bAddNewQuestion.PaintStyle = value;
                this.bDeleteQuestion.PaintStyle = value;
                this.bEditQuestion.PaintStyle = value;
            }
        }
        public UC_ToolBarListEditor()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento Click del boton agregar nuevo elemento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAddNewQuestion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (OnActionClick != null)
                OnActionClick(ActionTypes.Create);
        }
        /// <summary>
        /// Evento Click del boton editar nuevo elemento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bEditQuestion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (OnActionClick != null)
                OnActionClick(ActionTypes.Edit);
        }

        /// <summary>
        /// Evento Click del boton eliminar nuevo elemento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDeleteQuestion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (OnActionClick != null)
                OnActionClick(ActionTypes.Remove);
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Browsable(false)]
        public DevExpress.XtraBars.BarManager WorkingArea_ToolBar
        {
            get
            {
                return this.FwkBarBarManager;
            }
        }
    }
}
