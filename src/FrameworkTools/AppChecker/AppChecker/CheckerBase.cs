using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.IO;

namespace AppChecker
{
    public delegate void CheckEven(CheckMesage pCheckMesage);
    public  class CheckerBase : AppChecker.ICheckerBase
    {
        public event CheckEven StartEvent;
        public event CheckEven FinalizeEvent;
        public event CheckEven MessageEvent;
        protected void OnStartEvent(string msg,Image image)
        {
            if (StartEvent != null) StartEvent(new CheckMesage(msg, image));
        }
        protected void OnFinalizeEvent(string msg, Image image)
        {
            if (FinalizeEvent != null) FinalizeEvent(new CheckMesage(msg, null));
        }
        protected void OnMessageEvent(string msg,Image image2,Image image3)
        {

            
            if (MessageEvent != null) MessageEvent(new CheckMesage(msg,null, image2,image3));
        }


        public virtual void Run() { }


        public bool Contain(DirectoryInfo[] directorios,string str )
        {
            foreach (DirectoryInfo d in directorios)
            {
                if (d.Name.Contains(str)) return true;

            }
             return false;
        }
    }
}
