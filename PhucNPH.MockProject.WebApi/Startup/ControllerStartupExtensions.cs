using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using PhucNPH.MockProject.Domain.Validation;
using System.Diagnostics.CodeAnalysis;

namespace PhucNPH.MockProject.Presentation.Startup
{
    [ExcludeFromCodeCoverage]
    public static class ControllerStartupExtensions
    {
        public static void SetupControllers(this IServiceCollection services)
        {
            AssemblyScanner.FindValidatorsInAssemblyContaining<LoginModelValidation>()
                .ForEach(result => { services.AddTransient(result.InterfaceType, result.ValidatorType); });

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddControllers((options => options.Filters.Add<ValidateModelAttribute>()))
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<LoginModelValidation>();
                })
                .AddNewtonsoftJson();
        }
    }
}
