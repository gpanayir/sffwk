using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.Logging;
using System.Xml.Serialization;
using System.Xml;

namespace Fwk.Logging.Viewer
{
    public partial class FRM_Document : Form
    {
        public FRM_Document()
        {
            InitializeComponent();
            txtMessage1.Width = (this.Width / 2) - 5;
        }

        #region <public methods>
        public void AddEventLog(Event pEvent)
        {
            grdLogs.Rows.Add(GetImageByType(pEvent.Type), pEvent.Id, pEvent.DateAndTime, pEvent.Message, pEvent.Source, pEvent.Machine, pEvent.User);
        }
        public void Populate(List<Event> pEvenList)
        {
            grdLogs.BindingContextChanged += new EventHandler(grdLogs_BindingContextChanged);
            this.eventBindingSource.DataSource = pEvenList;
            grdLogs.Refresh();

        }

        void grdLogs_BindingContextChanged(object sender, EventArgs e)
        {
            List<Event> pEvenList = (List<Event>)eventBindingSource.DataSource;
            foreach (DataGridViewRow row in grdLogs.Rows)
            {
                Event x = (Event)row.DataBoundItem;
                row.Cells[0].Value = GetImageByType(x.Type);
            }
        }


        private Image GetImageByType(EventType pEventType)
        {
            switch (pEventType)
            {
                case EventType.Error:
                    {
                        return ctlImages.Images[0];
                    }
                case EventType.Information:
                    {
                        return ctlImages.Images[1];
                    }
                case EventType.Warning:
                    {
                        return ctlImages.Images[2];
                    }
                case EventType.Debug:
                    {
                        return ctlImages.Images[3];
                    }
                case EventType.Audit:
                    {
                        return ctlImages.Images["UDDI Server Search.ico"];
                    }
            }
            return ctlImages.Images[4];
        }
        #endregion



        private void grdLogs_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grdLogs.CurrentRow == null) return;
            Event x = (Event)grdLogs.CurrentRow.DataBoundItem;
            Message wMessage = LoadMessage(x.Message);
            if (!string.IsNullOrEmpty(wMessage.AnyMessage))
            {
                lblMessage1.Text = "Message";
                txtMessage1.Text = wMessage.AnyMessage;

                lblMessage1.Visible = false;
                txtMessage2.Visible = false;

            }

            if (!string.IsNullOrEmpty(wMessage.Request))
            {
                lblMessage1.Text = "Request";
                txtMessage1.Text = wMessage.Request;
            }

            if (!string.IsNullOrEmpty(wMessage.Response))
            {
                lblMessage2.Visible = true;
                txtMessage2.Visible = true;
                txtMessage2.Text = wMessage.Response;
            }
            txtMessage1.Anchor = AnchorStyles.None;
            txtMessage1.Anchor = AnchorStyles.Top;

            //Mostrar ambos
            if (string.IsNullOrEmpty(wMessage.AnyMessage) && !string.IsNullOrEmpty(wMessage.Response))
            {
                txtMessage1.Width = (this.Width / 2) - 5;
                txtMessage2.Left = (this.Width / 2) + 5;
                txtMessage2.Width = (this.Width / 2) - 10;
            }
            else
            {
                txtMessage1.Width = grdLogs.Width;
                txtMessage1.Anchor = AnchorStyles.Right;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMessage"></param>
        /// <returns></returns>
        internal static Message LoadMessage(String pMessage)
        {
            Message msg = new Message();
            StringBuilder s = new StringBuilder();
            s.AppendLine("<Message>");
            s.AppendLine(pMessage);
            s.AppendLine("</Message>");
            XmlNode node = null;
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            try
            {
                doc.LoadXml(s.ToString());
               
                node = Fwk.Xml.Node.NodeGet(doc.FirstChild, "Request");
                if (node != null)
                    msg.Request = node.InnerXml;

                node = Fwk.Xml.Node.NodeGet(doc.FirstChild, "Response");
                if (node != null)
                    msg.Response = node.InnerXml;

                node = Fwk.Xml.Node.NodeGet(doc.FirstChild, "AnyMessage");
                if (node != null)
                    msg.AnyMessage = node.InnerXml;

                
            }
            catch (Exception  )
            {
                msg.AnyMessage = pMessage;
            }

            return msg;
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
           
        }
    }

    
    [XmlInclude(typeof(Message)), Serializable]
    public class Message
    {
        private String _Request;
       
        
        private String _Response;

        
        private String _AnyMessage;




        [XmlElement(ElementName = "Request", DataType = "string")]
        public String Request
        {
            get { return _Request; }
            set { _Request = value; }
        }
        [XmlElement(ElementName = "Response", DataType = "string")]
        public String Response
        {
            get { return _Response; }
            set { _Response = value; }
        }
        [XmlElement(ElementName = "AnyMessage", DataType = "string")]
        public String AnyMessage
        {
            get { return _AnyMessage; }
            set { _AnyMessage = value; }
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pMessage"></param>
        ///// <returns></returns>
        //internal  static Message LoadMessage(String pMessage)
        //{
        //    Message msg = new Message ();
        //    StringBuilder s = new StringBuilder();
        //    s.AppendLine("<Message>");
        //    s.AppendLine(pMessage);
        //    s.AppendLine("</Message>");
        //    try
        //    {
        //         msg = (Message)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(Message), s.ToString());
        //    }
        //    catch(Exception xx )
        //    {
        //        msg.AnyMessage = pMessage;
        //    }

        //    return msg;
        //}
    }


}