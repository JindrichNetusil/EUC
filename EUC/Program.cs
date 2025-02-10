using EUC.Components;
using EUC.Configuration;
using EUC.Repository;
using EUC.Services;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddMudServices();
builder.Services.AddLocalization();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<INationalityService, NationalityService>();
builder.Services.AddScoped<ISexService, SexService>();
builder.Services.AddScoped<IQuestionnaireService, QuestionnaireService>();
builder.Services.AddScoped<IQuestionnaireRepository, QuestionnaireRepository>();
builder.Services.AddControllers();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

string[] supportedCultures = ["cs-CZ", "en-GB"];
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("cs-CZ")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapControllers();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await app.RunAsync();
