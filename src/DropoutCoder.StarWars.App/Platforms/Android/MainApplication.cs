﻿namespace DropoutCoder.StarWars.App.Platforms.Android
{
    using global::Android.App;
    using global::Android.Runtime;

    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(nint handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
