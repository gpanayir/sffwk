using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Fwk.Bases.Blocks.Functions
{
   public  class WinFunctions
    {
       /// <summary>
       /// Retorna el formulario MDI de cualquier user control o formulario
       /// </summary>
       /// <param name="pContainer"></param>
        /// <returns>Form</returns>
       public static Form GetMDIParent(ContainerControl pContainer)
       {
           if (pContainer.ParentForm == null) return null;
           if (!pContainer.ParentForm.IsMdiChild)
               return pContainer.ParentForm;
           else
               return GetMDIParent(pContainer.ParentForm);

       }
    }
}
