
using Crowdin.Api.Core.Converters;
using JetBrains.Annotations;

// ReSharper disable InconsistentNaming

namespace Crowdin.Api
{
    [PublicAPI]
    [StrictStringRepresentation]
    public enum Currency
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