using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.HelperFunctions.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching;
namespace Fwk.Cache.Test
{
    public partial class frmCacheFactoryTest : Form
    {
        FwkCacheCollectionMannager _FwkCacheCollectionMannager = null;
        frmSelectItem selectItemForm;
        public frmCacheFactoryTest()
        {
            InitializeComponent();
            selectItemForm = new frmSelectItem();
            _FwkCacheCollectionMannager = new FwkCacheCollectionMannager();

            cmbCacheMannagerSettingName.SelectedIndex = 0;
            
        }

        private void viewFileButton_Click(object sender, EventArgs e)
        {
            FwkCache wFwkCache = new FwkCache("Ventas");

            ClienteBE wCli = new ClienteBE();
            wCli.IdCliente = 50999;
            wCli.Apellido = "Aguirre";
            wCli.Edad = 69;

            wFwkCache.SaveItemInCache(wCli.IdCliente.ToString(), wCli);
        }

        private void primitivesAddButton_Click(object sender, EventArgs e)
        {
            FwkCache wFwkCache = _FwkCacheCollectionMannager.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
            
            using (frmAddItem addItemForm = new frmAddItem())
            {
                if (addItemForm.ShowDialog() == DialogResult.OK)
                {
                    primitivesResultsTextBox.Text = "Se agrego a " + cmbCacheMannagerSettingName.SelectedItem.ToString() + " el id " + addItemForm.Id + Environment.NewLine;

                    wFwkCache.SaveItemInCache(addItemForm.Id,addItemForm.ClienteCollectionBE,true);
                }
            }
        }


        void AddScenarioSeparator(TextBox textBox)
        {
            textBox.Text += "----------------------------------------------------------" + Environment.NewLine;
            textBox.SelectAll();
            textBox.ScrollToCaret();
        }

        private void primitivesReadButton_Click(object sender, EventArgs e)
        {
            if (selectItemForm.ShowDialog() == DialogResult.OK)
            {
                FwkCache wFwkCache = _FwkCacheCollectionMannager.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
                ClienteCollectionBE wClienteCollectionBE = (ClienteCollectionBE)wFwkCache.GetItemFromCache(selectItemForm.ItemKey);
                if (wClienteCollectionBE != null)
                {
                    primitivesResultsTextBox.Text += wClienteCollectionBE.GetXml() + Environment.NewLine;
                }
                else
                {
                    primitivesResultsTextBox.Text += string.Format("No se encuentra en cache el item", selectItemForm.ItemKey) + Environment.NewLine;
                }
                AddScenarioSeparator(primitivesResultsTextBox);
            }
        }

        private void primitivesRemoveButton_Click(object sender, EventArgs e)
        {
            if (selectItemForm.ShowDialog() == DialogResult.OK)
            {
                FwkCache wFwkCache = _FwkCacheCollectionMannager.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());

                if (wFwkCache.CheckIfCachingExists(selectItemForm.ItemKey))
                {
                    wFwkCache.RemoveItem(selectItemForm.ItemKey);
                    primitivesResultsTextBox.Text = "Se elimino de " + cmbCacheMannagerSettingName.SelectedItem.ToString() + " el id " + selectItemForm.ItemKey + Environment.NewLine;
                }
                else
                {
                    primitivesResultsTextBox.Text = "En " + cmbCacheMannagerSettingName.SelectedItem.ToString() + " el id " + selectItemForm.ItemKey + " no existe" + Environment.NewLine ;
                }
            }
            AddScenarioSeparator(primitivesResultsTextBox);
        }

        private void primitivesFlushCacheButton_Click(object sender, EventArgs e)
        {
            FwkCache wFwkCache = _FwkCacheCollectionMannager.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
            wFwkCache.ClearAll();
            primitivesResultsTextBox.Text = "Se eliminaron todos los elementos de " + cmbCacheMannagerSettingName.SelectedItem.ToString() +  Environment.NewLine;
        }

        private void primitivesAddRandomButton_Click(object sender, EventArgs e)
        {

            FwkCache wFwkCache = _FwkCacheCollectionMannager.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
            
            try
            {
                for (int i = 1; i <= nudItemsCount.Value; i++)
                {
                    wFwkCache.SaveItemInCache(i.ToString() + DateTime.Now.ToString(), Helper.GetClienteCollection(), CacheItemPriority.Low, 10);
                }

                primitivesResultsTextBox.Text = "Se agregaron a " + cmbCacheMannagerSettingName.SelectedItem.ToString() + " " + nudItemsCount.Value + " elementos" + Environment.NewLine;

      
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            FwkCache wFwkCache = _FwkCacheCollectionMannager.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
            MessageBox.Show("Cantidad de elementos en " + wFwkCache.CacheManagerName + " = "+ wFwkCache.CacheManager.Count);
           

           

        }
    }
}
