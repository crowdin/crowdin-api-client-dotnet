
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public enum ProjectFileType
    {
        [Description("auto")]
        Auto,

        [Description("android")]
        Android,

        [Description("macosx")]
        MacOsX,

        [Description("resx")]
        ResX,

        [Description("properties")]
        Properties,

        [Description("gettext")]
        GetText,

        [Description("yaml")]
        Yaml,

        [Description("php")]
        Php,

        [Description("json")]
        Json,

        [Description("fjs")]
        Fjs,

        [Description("xml")]
        Xml,

        [Description("ini")]
        Ini,

        [Description("rc")]
        Rc,

        [Description("resw")]
        Resw,

        [Description("resjson")]
        ResJson,

        [Description("qtts")]
        Qtts,

        [Description("joomla")]
        Joomla,

        [Description("chrome")]
        Chrome,

        [Description("react_intl")]
        ReactIntl,

        [Description("dtd")]
        Dtd,

        [Description("dklang")]
        Dklang,

        [Description("flex")]
        Flex,

        [Description("nsh")]
        Nsh,

        [Description("wxl")]
        Wxl,

        [Description("xliff")]
        Xliff,

        [Description("xliff_two")]
        XliffTwo,

        [Description("html")]
        Html,

        [Description("haml")]
        Haml,

        [Description("txt")]
        Txt,

        [Description("csv")]
        Csv,

        [Description("md")]
        Md,

        [Description("mdx_v1")]
        MdxV1,

        [Description("mdx_v2")]
        MdxV2,

        [Description("flsnp")]
        Flsnp,

        [Description("fm_html")]
        FmHtml,

        [Description("fm_md")]
        FmMd,

        [Description("mediawiki")]
        MediaWiki,

        [Description("docx")]
        DocX,
        
        [Description("xlsx")]
        XlsX,

        [Description("sbv")]
        Sbv,

        [Description("properties_play")]
        PropertiesPlay,

        [Description("properties_xml")]
        PropertiesXml,

        [Description("maxthon")]
        Maxthon,

        [Description("go_json")]
        GoJson,

        [Description("dita")]
        Dita,

        [Description("mif")]
        Mif,

        [Description("idml")]
        Idml,

        [Description("stringsdict")]
        StringsDict,

        [Description("plist")]
        Plist,

        [Description("vtt")]
        Vtt,

        [Description("vdf")]
        Vdf,

        [Description("srt")]
        Srt,

        [Description("stf")]
        Stf,

        [Description("toml")]
        Toml,

        [Description("contentful_rt")]
        ContentfulRt,

        [Description("svg")]
        Svg,

        [Description("js")]
        Js,

        [Description("coffee")]
        Coffee,

        [Description("ts")]
        Ts,

        [Description("fbt")]
        Fbt,

        [Description("i18next_json")]
        I18NextJson,

        [Description("xaml")]
        Xaml,

        [Description("arb")]
        Arb,

        [Description("adoc")]
        Adoc,

        [Description("webxml")]
        WebXml
    }
}