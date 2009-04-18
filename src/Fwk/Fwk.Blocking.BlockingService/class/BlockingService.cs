using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using Timer = System.Timers;
using Fwk.Configuration;

namespace Fwk.Blocking.PessimisticBlocking
{
	public class BlockingService : ServiceBase
	{
		#region --[Private Properties]--

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		/// <summary>
		/// Este es el timer que maneja las llamadas al método
		/// que limpia las BlockingMarks.
		/// </summary>
		private System.Timers.Timer _Timer;
		private double _Interval = 0;
		private int _WaitForComplete = 0;
		

		#endregion

		#region --[Constructor & Main]--
		/// <summary>
		/// Constructor
		/// </summary>
		public BlockingService()
		{
			// This call is required by the Windows.Forms Component Designer.
			InitializeComponent();

			/// Inicializa los componentes y variables privadas del servicio.
			Initialize();
		}

		// The main entry point for the process
		static void Main()
		{
			ServiceBase[] ServicesToRun;
	
			// More than one user Service may run within the same process. To add
			// another service to this process, change the following line to
			// create a second service object. For example,
			//
			//   ServicesToRun = new System.ServiceProcess.ServiceBase[] {new BlockingService(), new MySecondUserService()};
			//
			ServicesToRun = new ServiceBase[] { new BlockingService() };

			ServiceBase.Run(ServicesToRun);
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new Container();
			this.ServiceName = "BlockingService";
		}
		#endregion

		#region --[Dispose]--
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region --[Start]--

		/// <summary>
		/// Set things in motion so your service can do its work.
		/// </summary>
		protected override void OnStart(string[] args)
		{
			/// Inicia el Timer.
			_Timer.Start();

			BlockingHelper.WriteLog("Servicio de blocking iniciado.", EventLogEntryType.Information);
		}

		#endregion
 
		#region --[Stop]--

		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			_Timer.Stop();

			BlockingHelper.WriteLog("Servicio de blocking detenido.", EventLogEntryType.Information);
		}

		#endregion

		#region --[Inicializador]--

		/// <summary>
		/// Inicializa todas las variables y objetos privados del servicio.
		/// </summary>
		private void Initialize()
		{
			try
			{
				/// Controla que está configurado el intervalo de  ejecución
				/// del servicio.
                //BlockingHelper.WriteLog("Interval", EventLogEntryType.FailureAudit);
                _Interval = Fwk.Blocking.BlockingService.Properties.Settings.Default.Interval;// ConfigurationManager.GetProperty("BlockingModel", "Interval");
             

                _WaitForComplete = Fwk.Blocking.BlockingService.Properties.Settings.Default.WaitForComplete;
				

				/// Inicializa el Timer
				_Timer = new Timer.Timer();

				/// Agrega el event handler para los intervalos del Timer.
				_Timer.Elapsed +=new Timer.ElapsedEventHandler(_Timer_Elapsed);

				/// Setea el intervalo de  ejecución del Timer a partir
				/// del archivo de configuración.
				_Timer.Interval = _Interval * 1000;
			}
			catch(Exception ex)
			{
				BlockingHelper.WriteLog("\r\nSe produjo una excepción al inicializar el servicio." +
					"\r\n\r\n" + ex.ToString(),
					EventLogEntryType.Error);

				throw ex;
			}
		}

		#endregion

		#region --[Timer]--

		/// <summary>
		/// Event Handler para los intervalos del Timer.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _Timer_Elapsed(object sender, Timer.ElapsedEventArgs e)
		{
			try
			{
				/// Crea un thread para la  ejecución de ClearBlockingMarks.
				Thread thread = new Thread (new ThreadStart(ClearBlockingMarks));
				thread.Start();

				/// Espera hasta que se cumpla el tiempo estipulado
				/// de espera.
				thread.Join(_WaitForComplete * 1000);

				/// Si el thread todavía está vivo lo mata.
				if(thread.IsAlive)
				{
					BlockingHelper.WriteLog("\r\nHay un thread que ha superado el tiempo de espera estipulado.",
						EventLogEntryType.Error);

					thread.Abort();

					throw new Exception("\r\nHay un thread que ha superado el tiempo de espera estipulado.");
				}
			}
			catch(Exception ex)
			{
				BlockingHelper.WriteLog("\r\nSe produjo una excepción al llamar a " +
					"ClearBlockingMarks.\r\nDescripción  Técnica: " + ex.Message +
					"\r\n\r\n" + ex.ToString(), EventLogEntryType.Error);
			}
		}

		private void ClearBlockingMarks()
		{
			try
			{
				/// Llama al método que limpia las marcas para las
				/// cuales se cumplióel TTL.
				BlockingEngineBase.ClearBlockingMarks();
			}
			catch(Exception ex)
			{
				BlockingHelper.WriteLog("\r\nSe produjo una excepción al llamar a " +
					"ClearBlockingMarks.\r\nDescripción  Técnica: " + ex.Message +
					"\r\n\r\n" + ex.ToString(), EventLogEntryType.Error);
			}
		}

		#endregion
	}
}