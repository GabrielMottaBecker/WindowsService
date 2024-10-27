using System;
using System.ServiceProcess;
using System.Timers;
using WindowsService1.Services;
using WindowsService1.Services;

namespace WindowsService1
{
    public partial class WindowsService1 : ServiceBase
    {
        private Timer _timer;
        private readonly DataProcessor _dataProcessor;

        public WindowsService1()
        {
            this.ServiceName = "WindowsService1";
            InitializeComponent();
            _dataProcessor = new DataProcessor();
        }

        protected override void OnStart(string[] args)
        {
            // Log de início do serviço
            LoggingService.Log("Serviço iniciado.");

            // Configura o timer para execução a cada 5 minutos
            _timer = new Timer(300000);
            _timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            _timer.Start();
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            // Chama o processamento de dados a cada execução
            _dataProcessor.Execute();
        }

        protected override void OnStop()
        {
            // Log de parada do serviço
            LoggingService.Log("Serviço parado.");
            _timer.Stop();
        }
    }
}