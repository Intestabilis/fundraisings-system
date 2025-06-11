namespace Fundraisings.Domain.Abstractions;

public interface IDonationAmountParser
{
    Task<decimal> ParseCurrentAmountAsync(string donationUrl, CancellationToken cancellationToken);
}