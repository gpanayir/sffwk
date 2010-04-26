using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Fwk.HelperFunctions;

namespace Fwk.Cache.Test
{
    public partial class frmCacheFactoryTest : Form
    {
     
        frmSelectItem selectItemForm;
        public frmCacheFactoryTest()
        {
            InitializeComponent();
            selectItemForm = new frmSelectItem();
          

            cmbCacheMannagerSettingName.SelectedIndex = 0;
            cmbTimeMessure.SelectedIndex = 0;
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
            FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
            
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
                FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
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
                FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());

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
            FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
            wFwkCache.ClearAll();
            primitivesResultsTextBox.Text = "Se eliminaron todos los elementos de " + cmbCacheMannagerSettingName.SelectedItem.ToString() +  Environment.NewLine;
        }

        private void primitivesAddRandomButton_Click(object sender, EventArgs e)
        {

            FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
            
            try
            {
                for (int i = 1; i <= nudItemsCount.Value; i++)
                {
                    wFwkCache.SaveItemInCache(i.ToString() + DateTime.Now.ToString(), Helper.GetClienteCollection(), CacheItemPriority.Low, 10, Fwk.HelperFunctions.DateFunctions.TimeMeasuresEnum.FromMinutes,false);
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
            FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
            MessageBox.Show("Cantidad de elementos en " + wFwkCache.CacheManagerName + " = "+ wFwkCache.CacheManager.Count);
           

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClienteBE wCli = new ClienteBE();
            wCli.IdCliente = 100000000;
            wCli.Apellido = "Marcelo oviedo";
            wCli.Edad = 69;


            FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
            DateFunctions.TimeMeasuresEnum tm = (DateFunctions.TimeMeasuresEnum)Enum.Parse(typeof(DateFunctions.TimeMeasuresEnum),cmbTimeMessure.Text);
            wFwkCache.SaveItemInCache("TestTimeMeasuresEnum", wCli, 
                CacheItemPriority.Low, (double)numericUpDown1.Value, tm,false);

            MessageBox.Show("Se agrego correctamente TestTimeMeasuresEnum ");
            textBox1.Text = wCli.GetXml();

        }

        private void btnGetFromCache_Click(object sender, EventArgs e)
        {
            FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());

            ClienteBE wCli = (ClienteBE)wFwkCache.GetItemFromCache("TestTimeMeasuresEnum");

            if(wCli == null)
                MessageBox.Show("El item TestTimeMeasuresEnum no se encuentra en cache o expiro");
            else
                textBox1.Text = "Item de cache: " + Environment.NewLine  +  wCli.GetXml();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
            wFwkCache.RemoveItem("TestTimeMeasuresEnum");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Controller.SearchRelatedDomainsByUser("moviedo", false, cmbCacheMannagerSettingName.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SearchRelatedDomainsByUserRes res = Controller.GetFromCache("moviedo", cmbCacheMannagerSettingName.Text);
            if (res == null)
            {
                textBox2.Text = "No se encuentra el item en cache";
            }
            else
            {
                textBox2.Text = res.GetXml();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
            #region fill data
            SearchRelatedDomainsByUserRes wSearchRelatedDomainsByUserRes = new SearchRelatedDomainsByUserRes();
            wSearchRelatedDomainsByUserRes.BusinessData = new DomainList();
            Domain d = new Domain();
            d.DomainId = 111;
            d.Name = "Dominio A";
            wSearchRelatedDomainsByUserRes.BusinessData.Add(d);
            #endregion
            //wFwkCache.Add(pCahcheId, pObject, pPriority, wCacheRefreshAction, new SlidingTime(TimeSpan.FromDays(pExpirationTime)));
            wFwkCache.SaveItemInCache("SearchRelatedDomainsByUser", wSearchRelatedDomainsByUserRes);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(cmbCacheMannagerSettingName.SelectedItem.ToString());
            SearchRelatedDomainsByUserRes res = (SearchRelatedDomainsByUserRes)wFwkCache.GetItemFromCache("SearchRelatedDomainsByUser");
            if (res == null)
            {
                textBox2.Text = "No se encuentra el item en cache";
            }
            else
            {
                textBox2.Text = res.GetXml();
            }
        }
    }
}
