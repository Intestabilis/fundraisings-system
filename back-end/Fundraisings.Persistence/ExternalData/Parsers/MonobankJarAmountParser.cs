using Fundraisings.Domain.Abstractions;
using Microsoft.Playwright;

namespace Fundraisings.Persistence.ExternalData.Parsers;

public class MonobankJarAmountParser : IDonationAmountParser
{
    public async Task<decimal> ParseCurrentAmountAsync(string donationUrl, CancellationToken cancellationToken)
    {
        Console.WriteLine(donationUrl);
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        var page = await browser.NewPageAsync();

        await page.GotoAsync(donationUrl, new PageGotoOptions { Timeout = 30000 });
        await page.Locator(".stats-data-label").First.WaitForAsync(new LocatorWaitForOptions { Timeout = 10000 });

        var labelLocators = page.Locator(".stats-data-label");
        var valueLocators = page.Locator(".stats-data-value");

        int count = await labelLocators.CountAsync();
        for (int i = 0; i < count; i++)
        {
            var labelText = await labelLocators.Nth(i).InnerTextAsync();
            Console.WriteLine(labelText);

            var valueText = await valueLocators.Nth(i).InnerTextAsync();
            Console.WriteLine(valueText);

            var normalizedLabel = labelText.Trim().ToLower();
            if (normalizedLabel.Contains("collected") || normalizedLabel.Contains("накопичено") || normalizedLabel.Contains("зібрано"))
            {
                var cleaned = new string(valueText
                        .Where(c => !char.IsWhiteSpace(c))
                        .ToArray())
                    .Replace("₴", "")
                    .Replace(",", "")
                    .Trim();
                Console.WriteLine(cleaned);

                if (decimal.TryParse(cleaned, out var amount))
                {
                    return amount;
                }
            }
        }

        throw new Exception("Current amount not found or couldn't parse.");
    }
}