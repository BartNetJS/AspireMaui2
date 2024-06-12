var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireMaui2_ApiService>("apiservice");

// MAUI projects are registered differently than other project types, with AddMobileProject. Aspire settings
// that are normally set as environment variables at launch time are in the case of MAUI instead generated
// in the specified MAUI app project directory, in the AspireAppSettings.g.cs file.
builder.AddMobileProject("mauiclient", "../AspireMaui2")
    .WithReference(apiService);

builder.AddMobileProject("mauiblazor", "../AspireMaui2.Blazor.Mobile")
    .WithReference(apiService);

builder.AddProject<Projects.AspireMaui2_Web>("aspiremaui2-web");

builder.Build().Run();
