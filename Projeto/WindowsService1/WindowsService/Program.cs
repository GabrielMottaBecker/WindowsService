using System.ServiceProcess;
using WindowsService1;

namespace WindowsService1
{
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ServiceBase()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}