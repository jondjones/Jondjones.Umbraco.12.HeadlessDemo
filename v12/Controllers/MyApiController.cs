using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Persistence.EFCore.Scoping;
using Umbraco.Cms.Web.Common.Controllers;
using v12.Data;

namespace v12.Controllers;

public class MyApiController : UmbracoApiController {

    private readonly IEFCoreScopeProvider<MyContext> _efCoreScopeProvider;

    public MyApiController(IEFCoreScopeProvider<MyContext> efCoreScopeProvider) {
        _efCoreScopeProvider = efCoreScopeProvider;
    }

    // URL umbraco/api/myapi/listusers
    [HttpGet]
    public async Task<IActionResult> ListUsers() {

        using IEfCoreScope<MyContext> scope = _efCoreScopeProvider.CreateScope();
        var comments = await scope.ExecuteWithContextAsync(async db => {
            return db.CustomUsers.ToList();
        });

        scope.Complete();
        return Ok(comments);
    }

    [HttpGet]
    public async Task<IActionResult> ErrorOne() {

        using IEfCoreScope<MyContext> scope = _efCoreScopeProvider.CreateScope();
        var comments = await scope.ExecuteWithContextAsync(async db => {
            return db.CustomUsers;
        });

        scope.Complete();
        return Ok(comments);
    }

    // URL umbraco/api/myapi/adddummyuser
    public async Task<IActionResult> AddDummyUser() {

        var comment = new CustomUser {
            Name = "test-code",
            Surname = "test-code",
        };

        using IEfCoreScope<MyContext> scope = _efCoreScopeProvider.CreateScope();
        await scope.ExecuteWithContextAsync<Task>(async db => {
            db.CustomUsers.Add(comment);
            await db.SaveChangesAsync();
        });

        scope.Complete();
        return Ok();
    }
}
