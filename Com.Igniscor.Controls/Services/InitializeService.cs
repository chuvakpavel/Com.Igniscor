using Com.Igniscor.Controls.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace Com.Igniscor.Controls.Services
{
    public static class InitializeService
    {
        public static void Init(object app)
        {
            var type = app.GetType();
            var appAssembly = type.GetTypeInfo().Assembly;

            FontsHelper.Init(appAssembly);
        }
    }
}
