
using Crowdin.Api.Core.Converters;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    [StrictStringRepresentation]
    public enum ReportCurrency
    {
        USD,
        EUR,
        JPY,
        GBP,
        AUD,
        CAD,
        CHF,
        CNY,
        SEK,
        NZD,
        MXN,
        SGD,
        HKD,
        NOK,
        KRW,
        TRY,
        RUB,
        INR,
        BRL,
        ZAR,
        GEL,
        UAH
    }
}