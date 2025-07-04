﻿using System.ComponentModel.DataAnnotations;
using AppLanches.Services;
using AppLanches.Validations;
using Microsoft.Extensions.Logging;

namespace AppLanches;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddHttpClient();
        builder.Services.AddSingleton<ApiService>();
        builder.Services.AddSingleton<IValidator, Validations.Validator>();


        return builder.Build();
    }
}
