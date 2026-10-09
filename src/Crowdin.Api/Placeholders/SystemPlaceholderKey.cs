#nullable enable

using System;
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Placeholders
{
    [PublicAPI]
    public enum SystemPlaceholderKey
    {
        [Description("wrappedAmpersand")]
        WrappedAmpersand,

        [Description("appleStringsdictPlural")]
        AppleStringsdictPlural,

        [Description("dollarInsideBraces")]
        DollarInsideBraces,

        [Description("dollarOutsideBraces")]
        DollarOutsideBraces,

        [Description("wrappedColon")]
        WrappedColon,

        [Description("wrappedDollar")]
        WrappedDollar,

        [Description("dollarParentheses")]
        DollarParentheses,

        [Description("i18nextNesting")]
        I18nextNesting,

        [Description("i18nextLegacy")]
        I18nextLegacy,

        [Description("rubyInterpolation")]
        RubyInterpolation,

        [Description("mailchimpMergeTag")]
        MailchimpMergeTag,

        [Description("swiftInterpolation")]
        SwiftInterpolation,

        [Description("bracesTriple")]
        BracesTriple,

        [Description("bracesDouble")]
        BracesDouble,

        [Description("bracesSingle")]
        BracesSingle,

        [Description("bracesDoubleFormatted")]
        BracesDoubleFormatted,

        [Description("dateTimePattern")]
        DateTimePattern,

        [Description("appleStringCatalogNamed")]
        AppleStringCatalogNamed,

        [Description("printfSpecifier")]
        PrintfSpecifier,

        [Description("pythonPercentFormat")]
        PythonPercentFormat,

        [Description("railsI18n")]
        RailsI18n,

        [Description("javaMessageFormat")]
        JavaMessageFormat,

        [Description("dotNetCompositeFormat")]
        DotNetCompositeFormat,

        [Description("twig")]
        Twig,

        [Description("phpInterpolation")]
        PhpInterpolation,

        [Description("freemarkerDirective")]
        FreemarkerDirective,

        [Description("wrappedPercent")]
        WrappedPercent,

        [Description("dateTimeSpecifier")]
        DateTimeSpecifier
    }
}
