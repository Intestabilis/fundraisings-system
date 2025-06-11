using Fundraisings.Domain.Abstractions;
using Fundraisings.Persistence.DataAccess.Repositories;
using Microsoft.Extensions.Logging;

namespace Fundraisings.Application.Services.UseCases;

public class UpdateFundraisingAmountsUseCase
{
    private readonly FundraisingsRepository _fundraisingsRepository;
    private readonly IDonationAmountParser _donationAmountParser;
    private readonly ILogger<UpdateFundraisingAmountsUseCase> _logger;

    public UpdateFundraisingAmountsUseCase(FundraisingsRepository fundraisingRepository,
        IDonationAmountParser donationAmountParser,
        ILogger<UpdateFundraisingAmountsUseCase> logger)
    {
        _fundraisingsRepository = fundraisingRepository;
        _donationAmountParser = donationAmountParser;
        _logger = logger;
    }

    public async Task UpdateAllAsync(CancellationToken cancellationToken)
    {
        var fundraisings = await _fundraisingsRepository.GetAllActiveFundraisingsAsync(cancellationToken);

        foreach (var fundraising in fundraisings)
        {
            try
            {
                var newAmount = await _donationAmountParser.ParseCurrentAmountAsync(fundraising.DonationUrl, cancellationToken);
                if (newAmount != fundraising.CurrentAmount)
                {
                    await _fundraisingsRepository.UpdateCurrentAmountAsync(fundraising.Id, newAmount, cancellationToken);
                    _logger.LogInformation($"Updated fundraising {fundraising.Id} current amount to {newAmount}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update fundraising {fundraising.Id}");
            }
        }
    }
}