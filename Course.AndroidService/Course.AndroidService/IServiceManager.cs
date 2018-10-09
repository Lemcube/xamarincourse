using System;
using System.Collections.Generic;
using System.Text;

namespace Course.AndroidService
{
    public interface IServiceManager
    {
        event Action<String> EventFromService;

        void StartService();
        void StopService();

    }
}
