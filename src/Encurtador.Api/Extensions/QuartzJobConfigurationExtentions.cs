using Encurtador.Api.Jobs;
using Quartz;

namespace Encurtador.Api.Extensions;

public static class QuartzJobConfigurationExtentions
{
    public static void JobConfiguration(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddQuartz(configurator =>
        {
            configurator.UseMicrosoftDependencyInjectionJobFactory();

            AddJob<ExcluirFisicamenteUrlEncurtadasExpiradasJob>(
                configurator,
                nameof(ExcluirFisicamenteUrlEncurtadasExpiradasJob));
            AddTrigger(
                configurator,
                nameof(ExcluirFisicamenteUrlEncurtadasExpiradasJob),
                $"{nameof(ExcluirFisicamenteUrlEncurtadasExpiradasJob)}-trigger",
                "0 0 12 ? * SUN *");

            AddJob<ExcluirLogicamenteUrlEncurtadasExpiradasJob>(
                configurator,
                nameof(ExcluirLogicamenteUrlEncurtadasExpiradasJob));
            AddTrigger(
                configurator,
                nameof(ExcluirLogicamenteUrlEncurtadasExpiradasJob),
                $"{nameof(ExcluirLogicamenteUrlEncurtadasExpiradasJob)}-trigger",
                "0 0 12 1/1 * ? *");
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    }

    private static void AddJob<TJob>(
        IServiceCollectionQuartzConfigurator configurator,
        string jobName) where TJob : IJob
    {
        configurator.AddJob<TJob>(opts => opts.WithIdentity(jobName));
    }

    private static void AddTrigger(
        IServiceCollectionQuartzConfigurator configurator,
        string jobName,
        string triggerName,
        string cronSchedule)
    {
        configurator.AddTrigger(opts => opts
            .ForJob(jobName)
            .WithIdentity(triggerName)
            .WithCronSchedule(cronSchedule));
    }
}
