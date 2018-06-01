using System;
using Xamarin.Forms;

namespace NewsApp.Services.OpenUri
{
    public class OpenUriService : IOpenUriService
    {
        public void OpenUri(string uri)
        {
            Device.OpenUri(new Uri(uri));
        }
    }
}
