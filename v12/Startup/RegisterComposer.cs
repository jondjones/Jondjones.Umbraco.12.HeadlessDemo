using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Notifications;
using v12.NotificationHandler;

namespace v12.Startup;

public class RegisterDependencies : IComposer {

    public void Compose(IUmbracoBuilder builder) {
        builder.AddNotificationAsyncHandler<UmbracoApplicationStartedNotification, RunDBMigrations>();
    }
}