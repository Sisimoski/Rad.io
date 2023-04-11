namespace Rad.io.Client.WinUITemplate.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
