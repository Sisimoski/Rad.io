using Rad.io.Client.WinUITemplate.Core.Models;

namespace Rad.io.Client.WinUITemplate.Core.Contracts.Services;

// Remove this class once your pages/features are using your data.
public interface ISampleDataService
{
    Task<IEnumerable<SampleOrder>> GetListDetailsDataAsync();
}
