using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Samples.Web.Options;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.Cosmos.Samples.Web.Pages;

public class IndexPageModel : PageModel
{
    public Credentials? Credentials { get; }

    public AccountProperties? Properties { get; set; }

    public IndexPageModel(IOptions<Credentials> credentialOptions)
    {
        Credentials = credentialOptions.Value;
    }

    public async Task OnGetAsync()
    {
        if (Credentials is not null)
            if (!String.IsNullOrEmpty(Credentials.Endpoint) && !String.IsNullOrEmpty(Credentials.Key))
            {
                CosmosClient client = new(Credentials.Endpoint, Credentials.Key);

                Properties = await client.ReadAccountAsync();
            }
    }
}