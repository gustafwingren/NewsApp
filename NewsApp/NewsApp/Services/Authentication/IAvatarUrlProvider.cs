using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Services.Authentication
{
    public interface IAvatarUrlProvider
    {
        string GetAvatarUrl(string email);
    }
}
