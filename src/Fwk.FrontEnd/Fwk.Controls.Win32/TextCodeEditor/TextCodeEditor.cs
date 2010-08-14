using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using CSharpBinding.FormattingStrategy;
using ICSharpCode.TextEditor.Document;

namespace Fwk.Controls.Win32.TextCodeEditor
{
    public partial class TextCodeEditor : UserControl
    {
        public TextCodeEditor()
        {

            this.InitializeComponent();
            this.FormattingStrategy();
            this.IndentLines();

        }


        #region --[PROPIEDADES]--

        // <summary>
        /// Supported Languages.
        /// </summary>
        public enum TipoLenguaje
        {

            CSHARP = 2,
            C64CHARP = 3,
            CPP = 4,
            HTML = 5,
            JAVA = 6,
            JAVASCRIPT = 7,

            Text = 9,
            VBNET = 10,
            VBSCRIPT = 11,
            XML = 12
        }


        private TipoLenguaje m_Lenguaje = TipoLenguaje.C64CHARP;

        [DesignOnly(false), Browsable(true), Category("Text Control"), Description("Texto enriqucido del control text code editor.-")]
        public override string Text
        {
            get
            {
                this.txtEditor.Refresh();
                return this.txtEditor.Document.TextBufferStrategy.GetText(0, this.txtEditor.Document.TextLength);
            }
            set
            {
                this.txtEditor.Refresh();
                this.txtEditor.Document.TextContent = value;
                this.IndentLines();
            }
        }
 

 



        [Browsable(true), Category("Propertie"),
        Description("Titulo del text code editor"),
        Bindable(true)]
        public string TitleText
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }


        [Bindable(true), Category("Text Control"), Description("Determina si se muestra el titulo del control"), Browsable(true)]
        public bool TitleVisible
        {
            get
            {
                return this.lblTitle.Visible;
            }
            set
            {
                int x = 0;
                int y = 0x10;
                if (value)
                {
                    y = 0x10;
                }
                else
                {
                    y = 0;
                }
                Point point = new Point(x, y);
                this.txtEditor.Location = point;
                this.lblTitle.Visible = value;
            }
        }
 






        #endregion

        #region --[METODOS]--

        private void FormattingStrategy()
        {
            IFormattingStrategy strategy = new CSharpFormattingStrategy();
            this.txtEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            this.txtEditor.Document.FormattingStrategy = strategy;
        }

 

 

        



        private void IndentLines()
        {
            TextAreaControl control = new TextAreaControl(this.txtEditor);
            new CSharpFormattingStrategy().IndentLines(control.TextArea, 0, this.txtEditor.Document.TotalNumberOfLines - 1);
        }
        #endregion

  

    }
}
