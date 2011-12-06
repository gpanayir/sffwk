using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Sereals;
using System.Management;

namespace SerealsGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                string hash = Sereal.GetMd5Hash(txtImput.Text);

                txtMD5Value.Text = hash;


            
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            txtKeyValue.Text = Fwk.Security.Cryptography.FwkSymetricAlg.GetNewK(); 
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeyValue.Text))
            { MessageBox.Show("Generate encryptation key"); txtKeyValue.Focus(); return; }
            try
            {
                Fwk.Security.Cryptography.FwkSymetricAlg gen = new Fwk.Security.Cryptography.FwkSymetricAlg(txtKeyValue.Text);
                txtEncryptedValue.Text = gen.Encrypt(txtValueToEncrypt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtKeyValue.Focus();
            }
            
        }

        private void btnValidateMD5_Click(object sender, EventArgs e)
        {
            if (Sereal.VerifyMd5Hash(txtImput.Text, txtMD5Value.Text))
            {
                MessageBox.Show("Is valid");
            }
            else
                MessageBox.Show("Is invalid");
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            DateTime f  = dateTimePicker1.Value;

            txtValueToEncrypt.Text = string.Concat(f.Day,"|",f.Month,"|",f.Year);
        }

         void init()
        {
            txtNroSerie.Text = GetDriverSerealNumber();
        }




  

        public String GetDriverSerealNumber()
        {
            OSVersion version = GetOSVersion();                               
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select Index,SerialNumber from Win32_DiskDrive where Index = 0");

           OSVersion v =  GetOSVersion();
           if (v == OSVersion.Windows_7)
           {
               searcher = new ManagementObjectSearcher("select Index,SerialNumber from Win32_DiskDrive where Index = 0");
               foreach (ManagementObject share in searcher.Get())
               {
                   //if (Convert.ToInt32(share["Index"]).Equals(0))
                   //{
                   return share["SerialNumber"].ToString();
                   //}
               }
           }
           if( v == OSVersion.Windows_XP)
           {
               searcher = new ManagementObjectSearcher("select Name,VolumeSerialNumber from Win32_LogicalDisk ");

               foreach (ManagementObject partion in searcher.Get())
               { //hdd = Convert.ToString(partion["VolumeSerialNumber"]); 
                   if (partion["Name"].Equals("C:")) 
                       return partion["VolumeSerialNumber"].ToString(); 
               }
           }

            return string.Empty;
        }

        public OSVersion GetOSVersion()
        {
            int _MajorVersion = Environment.OSVersion.Version.Major;
            switch (_MajorVersion)
            {
                case 5: return  OSVersion.Windows_XP;
                case 6:
                    {
                        switch (Environment.OSVersion.Version.Minor)
                        {
                            case 0: return OSVersion.Windows_Vista;
                            case 1: return OSVersion.Windows_7;
                            default: return OSVersion.Windows_Vista_and_above;
                        }
                   
                    }
                default: return OSVersion.Unknown;
            }
        }
       

    }
    public enum OSVersion
    {
        Windows_Vista=0,
        Windows_7 =1,
        Windows_XP = 5,
        Windows_Vista_and_above = 1000,
        Unknown = 1001
    }
    [Serializable]
    public struct NetworkAdapters
    {
        public String MACAddress;
        public Int32 AdapterTypeID;
    }

}
