using Microsoft.EntityFrameworkCore;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using v12.Data;

namespace v12.NotificationHandler;

public class RunDBMigrations : INotificationAsyncHandler<UmbracoApplicationStartedNotification> {

    private MyContext _context;

    public RunDBMigrations(MyContext context) {

        _context = context;
    }

    public async Task HandleAsync(UmbracoApplicationStartedNotification notification, CancellationToken cancellationToken) {

        var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();

        if (pendingMigrations.Any()) {
            _context.Database.MigrateAsync();
        }
    }
}
