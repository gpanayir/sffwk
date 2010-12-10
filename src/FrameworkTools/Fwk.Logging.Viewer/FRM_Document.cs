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
using System.Linq;
namespace Fwk.Logging.Viewer
{
    public partial class FRM_Document : Form
    {
        Fwk.Logging.Targets.Target _Target;
        EventGridList currentEvents = null;
        ServiceErrorView _ServiceErrorView;
        ServicesView _ServicesView;
        OtherView _OtherView;
        public FRM_Document()
        {
            InitializeComponent();

        }

        #region <public methods>

        public void Populate(Fwk.Logging.Targets.Target target)
        {

            _Target = target;
            //grdLogs.BindingContextChanged += new EventHandler(grdLogs_BindingContextChanged);

            Event ev = new Event();
            
            Events wEvents = _Target.SearchByParam(ev);

            currentEvents = Get_EventGridList(wEvents);
            this.eventGridListBindingSource.DataSource = null;
            this.eventGridListBindingSource.DataSource = currentEvents;

            grdLogs.Refresh();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventIdList"></param>
        public void Remove(List<string> eventIdList)
        {
            _Target.Remove(eventIdList);
        }
        public void RemoveAll()
        {

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
            catch (Exception)
            {
                msg.AnyMessage = pMessage;
            }

            return msg;
        }





        private void grdLogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (grdLogs.CurrentRow == null) return;
            EventGrid x = (EventGrid)((System.Windows.Forms.BindingSource)grdLogs.DataSource).Current;

            Message wMessage = LoadMessage(x.Message.Text);

            if (wMessage.MessageContenType == MessageContenType.ServiceError)
            {
                if (_ServiceErrorView == null)
                    _ServiceErrorView = new ServiceErrorView();
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
       
        private void FRM_Document_Activated(object sender, EventArgs e)
        {
            FRM_Main.Current_Document = this;
        }

        private void filter1_OnFilterChanged(Event eventFilter, DateTime endDate)
        {
            Events wEvents = null;
            this.eventGridListBindingSource.DataSource = null;
            if (endDate == Fwk.HelperFunctions.DateFunctions.NullDateTime)
            {
                wEvents = _Target.SearchByParam(eventFilter);
               
            }
            else
            {
                wEvents = _Target.SearchByParam(eventFilter, endDate);
              
            }

            currentEvents = Get_EventGridList(wEvents);
            this.eventGridListBindingSource.DataSource = null;
            this.eventGridListBindingSource.DataSource = currentEvents;
            grdLogs.Refresh();
        }



        private void FRM_Document_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {
                List<Guid> wGuids = new List<Guid>();
                foreach (DataGridViewRow row in grdLogs.SelectedRows)
                {
                    wGuids.Add((Guid)row.Cells["Id"].Value);
                }
                try
                {
                    _Target.Remove(wGuids);
                    currentEvents.Remove(wGuids);
                    grdLogs.Refresh();

                }
                catch (Exception ex)
                {
                    ExceptionViewer.Show(ex);
                }
            }

        }
        public override void Refresh()
        {
            this.filter1.Refresh();
            Event ev = new Event();
            Events wEvents = _Target.SearchByParam(ev);
            currentEvents = Get_EventGridList(wEvents);
            this.eventGridListBindingSource.DataSource = null;
            this.eventGridListBindingSource.DataSource = currentEvents;
            grdLogs.Refresh();
            base.Refresh();



        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEvents"></param>
        /// <returns></returns>
        EventGridList Get_EventGridList(Events pEvents)
        {
            if (pEvents.Count == 0) return new EventGridList();
            var lst = from e in pEvents select new EventGrid(e);
            EventGridList lst2 = new EventGridList();
            lst2.AddRange(lst.ToArray<EventGrid>());
            return lst2;
        }
        //void AddImages()
        //{
        //    //grdLogs.Rows.Add(GetImageByType(pEvent.LogType), pEvent.Id, pEvent.DateAndTime, pEvent.Message, pEvent.Source, pEvent.Machine, pEvent.User);


        //    foreach (DataGridViewRow row in grdLogs.Rows)
        //    {

        //        EventType wEventType = (EventType)row.Cells["Type"].Value;
        //        row.Cells["Logtype"].Value = GetImageByType(wEventType);
        //        row.Cells["Logtype"].ToolTipText = wEventType.ToString();
        //    }
        //}
        //void grdLogs_BindingContextChanged(object sender, EventArgs e)
        //{
        //    List<Event> pEvenList = (List<Event>)eventGridListBindingSource.DataSource;
        //    foreach (DataGridViewRow row in grdLogs.Rows)
        //    {
        //        Event x = (Event)row.DataBoundItem;

        //        row.Cells[0].Value = GetImageByType(x.LogType);
        //        row.Cells[0].ToolTipText = x.LogType.ToString();
        //    }
        //}
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
        Service,
        ServiceError,
        Other
    }

}