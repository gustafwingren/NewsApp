using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Services.Analytic
{
    public interface IAnalyticService
    {
        void TrackEvent(string name, Dictionary<string, string> properties = null);
    }
}
