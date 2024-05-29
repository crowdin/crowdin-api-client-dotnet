
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public enum ProjectFileType
    {
        [SerializedValue("auto")]
        Auto,

        [SerializedValue("android")]
        Android,

        [SerializedValue("macosx")]
        MacOsX,

        [SerializedValue("resx")]
        ResX,

        [SerializedValue("properties")]
        Properties,

        [SerializedValue("gettext")]
        GetText,

        [SerializedValue("yaml")]
        Yaml,

        [SerializedValue("php")]
        Php,

        [SerializedValue("json")]
        Json,

        [SerializedValue("fjs")]
        Fjs,

        [SerializedValue("xml")]
        Xml,

        [SerializedValue("ini")]
        Ini,

        [SerializedValue("rc")]
        Rc,

        [SerializedValue("resw")]
        Resw,

        [SerializedValue("resjson")]
        ResJson,

        [SerializedValue("qtts")]
        Qtts,

        [SerializedValue("joomla")]
        Joomla,

        [SerializedValue("chrome")]
        Chrome,

        [SerializedValue("react_intl")]
        ReactIntl,

        [SerializedValue("dtd")]
        Dtd,

        [SerializedValue("dklang")]
        Dklang,

        [SerializedValue("flex")]
        Flex,

        [SerializedValue("nsh")]
        Nsh,

        [SerializedValue("wxl")]
        Wxl,

        [SerializedValue("xliff")]
        Xliff,

        [SerializedValue("xliff_two")]
        XliffTwo,

        [SerializedValue("html")]
        Html,

        [SerializedValue("haml")]
        Haml,

        [SerializedValue("txt")]
        Txt,

        [SerializedValue("csv")]
        Csv,

        [SerializedValue("md")]
        Md,

        [SerializedValue("mdx_v1")]
        MdxV1,

        [SerializedValue("mdx_v2")]
        MdxV2,

        [SerializedValue("flsnp")]
        Flsnp,

        [SerializedValue("fm_html")]
        FmHtml,

        [SerializedValue("fm_md")]
        FmMd,

        [SerializedValue("mediawiki")]
        MediaWiki,

        [SerializedValue("docx")]
        DocX,

        [SerializedValue("sbv")]
        Sbv,

        [SerializedValue("properties_play")]
        PropertiesPlay,

        [SerializedValue("properties_xml")]
        PropertiesXml,

        [SerializedValue("maxthon")]
        Maxthon,

        [SerializedValue("go_json")]
        GoJson,

        [SerializedValue("dita")]
        Dita,

        [SerializedValue("mif")]
        Mif,

        [SerializedValue("idml")]
        Idml,

        [SerializedValue("stringsdict")]
        StringsDict,

        [SerializedValue("plist")]
        Plist,

        [SerializedValue("vtt")]
        Vtt,

        [SerializedValue("vdf")]
        Vdf,

        [SerializedValue("srt")]
        Srt,

        [SerializedValue("stf")]
        Stf,

        [SerializedValue("toml")]
        Toml,

        [SerializedValue("contentful_rt")]
        ContentfulRt,

        [SerializedValue("svg")]
        Svg,

        [SerializedValue("js")]
        Js,

        [SerializedValue("coffee")]
        Coffee,

        [SerializedValue("ts")]
        Ts,

        [SerializedValue("fbt")]
        Fbt,

        [SerializedValue("i18next_json")]
        I18NextJson,

        [SerializedValue("xaml")]
        Xaml,

        [SerializedValue("arb")]
        Arb,

        [SerializedValue("adoc")]
        Adoc,

        [SerializedValue("webxml")]
        WebXml
    }
}