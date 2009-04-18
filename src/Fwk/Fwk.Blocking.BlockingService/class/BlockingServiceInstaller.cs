using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Fwk.Blocking.BlockingService
{
	[RunInstaller(true)]
	public partial class BlockingServiceInstaller: Installer
	{
		public BlockingServiceInstaller()
		{
			InitializeComponent();
            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            //# Service Account Information
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceProcessInstaller.Username = null;
            serviceProcessInstaller.Password = null;

            //# Service Information
            serviceInstaller.DisplayName = "Fwk - Pessimistic Blocking Service";
            serviceInstaller.Description = "Servicio de limpieza de marcas de bloqueo.";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            //# This must be identical to the WindowsService.ServiceBase name
            //# set in the constructor of WindowsService.cs
            serviceInstaller.ServiceName = "Fwk.Blocking.BlockingService";

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);
		}
	}
}