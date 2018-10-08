using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Course.Plugins
{
    public interface IBarcode
    {
        Task ScanAsync();

        void Stop();
    }
}
