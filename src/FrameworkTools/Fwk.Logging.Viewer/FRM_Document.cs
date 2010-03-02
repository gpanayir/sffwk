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
        Fwk.Logging.Targets.Target _Target;
        public FRM_Document()
        {
            InitializeComponent();
         
        }

        #region <public methods>
        public void AddImages()
        {
            //grdLogs.Rows.Add(GetImageByType(pEvent.LogType), pEvent.Id, pEvent.DateAndTime, pEvent.Message, pEvent.Source, pEvent.Machine, pEvent.User);


            foreach (DataGridViewRow row in grdLogs.Rows)
            {


                EventType wEventType =  (EventType)row.Cells["Type"].Value;
                row.Cells["Logtype"].Value = GetImageByType(wEventType);
                row.Cells["Logtype"].ToolTipText = wEventType.ToString();
            }
        }
        public void Populate(Fwk.Logging.Targets.Target target)
        {

            _Target = target;
            grdLogs.BindingContextChanged += new EventHandler(grdLogs_BindingContextChanged);

            Event ev =new Event();
          
            this.eventBindingSource.DataSource = _Target.SearchByParam(ev);

            grdLogs.Refresh();

        }
       

        void grdLogs_BindingContextChanged(object sender, EventArgs e)
        {
            List<Event> pEvenList = (List<Event>)eventBindingSource.DataSource;
            foreach (DataGridViewRow row in grdLogs.Rows)
            {
                Event x = (Event)row.DataBoundItem;
                row.Cells[0].Value = GetImageByType(x.LogType);
                row.Cells[0].ToolTipText = x.LogType.ToString();
            }
        }
        

        private Image GetImageByType(EventType pEventType)
        {
            switch (pEventType)
            {
                case EventType.Error:
                    {
                        return (Image)Fwk.Logging.Viewer.Properties.Resources.Error;
                    }
                case EventType.Information:
                    {
                        return (Image)Fwk.Logging.Viewer.Properties.Resources.Information;
                    }
                case EventType.Warning:
                    {
                        return (Image)Fwk.Logging.Viewer.Properties.Resources.Warning;
                    }
              
                case EventType.Audit:
                    {
                        return (Image)Fwk.Logging.Viewer.Properties.Resources.audit;
                    }
            }
            return ctlImages.Images[4];
        }
        #endregion



     


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
                {

                    msg.Request = node.InnerXml;
                    msg.MessageContenType = MessageContenType.Service;
                }
                node = Fwk.Xml.Node.NodeGet(doc.FirstChild, "Response");
                if (node != null)
                    msg.Response = node.InnerXml;

                node = Fwk.Xml.Node.NodeGet(doc.FirstChild, "Error");
                if (node != null)
                {
                    msg.AnyMessage = node.OuterXml;
                    msg.MessageContenType = MessageContenType.ServiceError;
                }
                if (string.IsNullOrEmpty(msg.AnyMessage) &&
                    string.IsNullOrEmpty(msg.Request) &&
                    string.IsNullOrEmpty(msg.Response))
                {
                    msg.AnyMessage = pMessage;
                    msg.MessageContenType = MessageContenType.Other;
                }

                
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

        private void grdLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        ServiceErrorView _ServiceErrorView;
        ServicesView _ServicesView;
        OtherView _OtherView;
        private void grdLogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            if (grdLogs.CurrentRow == null) return;
            Event x = (Event)((System.Windows.Forms.BindingSource)grdLogs.DataSource).Current;
       
            Message wMessage = LoadMessage(x.Message.Text);

            if (wMessage.MessageContenType == MessageContenType.ServiceError)
            {
                if( _ServiceErrorView == null)
                    _ServiceErrorView = new ServiceErrorView ();
                _ServiceErrorView.Populate(wMessage);

                AddtoPanel(_ServiceErrorView);
            }

            if (wMessage.MessageContenType == MessageContenType.Service)
            {
                if (_ServicesView == null)
                    _ServicesView = new ServicesView();
                _ServicesView.Populate(wMessage);

                AddtoPanel(_ServicesView);
            }
            if (wMessage.MessageContenType == MessageContenType.Other)
            {
                if (_OtherView == null)
                    _OtherView = new OtherView();
                _OtherView.Populate(wMessage);

                AddtoPanel(_OtherView);
            }

           
        }
        public void AddtoPanel(Control pControlToAdd)
        {

            if (panel1.Contains(pControlToAdd)) return;

            pControlToAdd.Location = new System.Drawing.Point(1, 1);
            pControlToAdd.Width = panel1.Width - 60;
            pControlToAdd.Height = panel1.Height - 60;
            pControlToAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                   | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            panel1.Controls.Clear();
            panel1.Controls.Add(pControlToAdd);

        }

       
    }

    
    [XmlInclude(typeof(Message)), Serializable]
    public class Message
    {
        MessageContenType _MessageContenType = MessageContenType.Other;

        internal MessageContenType MessageContenType
        {
            get { return _MessageContenType; }
            set { _MessageContenType = value; }
        }
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


    internal enum MessageContenType
    { 
        Service ,
        ServiceError,
        Other
    }

}