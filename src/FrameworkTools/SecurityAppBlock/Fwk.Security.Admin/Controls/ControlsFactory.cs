﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using DevExpress.XtraNavBar;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Security;


namespace Fwk.Security.Admin.Controls
{


    internal class ControlsFactory
    {
         
        public static IAuthorizationProvider ruleProvider;
        static ControlsFactory()
        {
            ruleProvider = AuthorizationFactory.GetAuthorizationProvider("RuleProvider_Fwk");
        }

        static Dictionary<string, SecurityControlBase> _SecurityControlList = new Dictionary<string, SecurityControlBase>();

        internal static SecurityControlBase Get(NavBarItemLink pItem)
        {
            bool isNew;
            return Get(pItem.Item.Tag.ToString(), out isNew);
        }
        /// <summary>
        /// Obtiene el correspondiente mesh, si no existe lo crea
        /// </summary>
        /// <param name="meshId"></param>
        /// <param name="meshName"></param>
        /// <param name="node"></param>
        /// <param name="isNew">Parametro tipo out que determina si el Mesh existia o fue creado.-</param>
        /// <returns>Formulario Mesh</returns>
        internal static SecurityControlBase Get(string pName, out bool isNew)
        {


            isNew = false;

            SecurityControlBase wSecurityControl;
            if (_SecurityControlList.ContainsKey(pName))
            {
                wSecurityControl = (SecurityControlBase)_SecurityControlList[pName];
                isNew = false;
            }
            else
            {
                 wSecurityControl = (SecurityControlBase)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(pName);
                _SecurityControlList.Add(pName, wSecurityControl);
                isNew = true;
              
            }
            return wSecurityControl;
        }



        internal static SecurityControlBase Show(NavBarItemLink pItem, Control pContainer)
        {
            SecurityControlBase wSecurityControl  = Get(pItem);
            
            AddtoPanel(wSecurityControl, pContainer);
            wSecurityControl.Initialize();

            return wSecurityControl;
        }


        static void AddtoPanel(Control pControlToAdd, Control pContainerControl)
        {

            if (pContainerControl.Contains(pControlToAdd)) return;

            pControlToAdd.Location = new System.Drawing.Point(1, 1);
            pControlToAdd.Width = pContainerControl.Width - 60;
            pControlToAdd.Height = pContainerControl.Height - 60;
            pControlToAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                   | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            pContainerControl.Controls.Clear();
            pContainerControl.Controls.Add(pControlToAdd);

        }
    }
}