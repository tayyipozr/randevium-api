using OneSignalSDK.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Notification
{
    public class NotificationService
    {
        HttpClient _httpClient;
        public NotificationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
