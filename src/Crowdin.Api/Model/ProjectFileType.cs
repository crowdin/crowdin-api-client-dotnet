/*
 * Crowdin API v2
 *
 *  # Introduction Welcome to Crowdin API v2 documentation.  Our API is a full-featured RESTful API that helps you to integrate localization into your development process. The endpoints that we use allow you to easily make calls to retrieve information and to execute actions needed.  Most of the functionality of Crowdin is available through the API. It allows you to create projects for translations, add and update files, download translations, and much more. In this way, you can script the complex actions that your situation requires.  Documentation starts with a general overview of the design and technology that was implemented and is followed by detailed information on specific methods and endpoints.  ## Asynchronous Operations Methods such as report generation, project build, and file download need some time to be completed and are finalized in several steps. It is what we call asynchronous operations. This  approach allows the application to work without interruptions while the method is running at the background.  To run asynchronous operations, 3 subsequent API methods are used:  *     Method to start operation – returns the status __Found__ if the resource you’re requesting is already generated. Typically, __201 Accepted__ status is returned along with the operation identifier. The operation status is then checked with the help of this identifier.  *     Method to check the status of operation – returns  the completion percentage.  *     Method to get the temporary link for resource download – mostly used for export operations. When the operation is completed, you can run this method to get a temporary link for resource download.  __Note:__ Download link is active for a few minutes.  For example, to download a Translation Memory (TM), you need to run following sequence of API methods:  *     [_Export TM_](#operation/api.tms.exports.post)  *     [_Check TM Export Status_](#operation/api.tms.exports.get)  *     [_Download TM_](#operation/api.tms.exports.getMany)  ## File Upload With Crowdin API v2 all files such as files for localization, screenshots, Glossaries, and Translation Memories should be first uploaded to the [Storage](#tag/Storage). After you upload file to the Storage it will have a unique storage id using which you can then add the file to the project.  For example, to upload a localization file to your project, you need to run the following sequence of API methods:  *     [_Add Storage_](#operation/api.storages.post) – upload localization file body to storage at Crowdin server  *     [_Add File_](#operation/api.projects.files.post) – define where to add the localization file with specific _storage id_  ## Authorization To work with Crowdin API v2 generate the personal access token by going to __Crowdin Account Settings > API & SSO > New Token__  Make sure to use the following __header__ in your requests:  `Authorization: Bearer ACCESS_TOKEN`  Responses in case authorization fail:  __401 Unauthorized__ ``` {   \"error\": {     \"message\": \"Unauthorized\",     \"code\": 401   } } ```  __403 Forbidden__ ``` {   \"error\": {     \"message\": \"Not allowed endpoint for token scopes\",     \"code\": 403   } } ``` ``` {   \"error\": {     \"message\": \"Not allowed space for your token\",     \"code\": 403   } } ```  ## Requests All requests should be made using the HTTPS protocol so that traffic is encrypted. The interface responds to different methods depending on the action required.  When a request is successful, a response will typically be sent back in the form of a JSON object. If you specify `Accept` header response will be `application/json`. It’s not required to specify `Accept` header so you can leave it empty.  The API expects all writing requests (_POST_, _PUT_, _PATCH_) in JSON format with the `Content-Type: application/json` header. This ensures that your request is interpreted correctly.  __Note:__ `Content-Type` header can be different (e.g. `image/jpeg`, `text/csv`) if you upload the file using _POST_ methods with a specified content type.  RESTful APIs enable you to call individual API endpoints to perform the following requests:  *     <span class='http-method method-list get'>GET</span> - for simple retrieval of information about source files, translations, or projects. The information you request will be returned to you as a JSON object. The attributes defined by the JSON object can be used to form additional requests.  *     <span class='http-method method-list post'>POST</span> - to create or add a new element. This request includes all of the attributes necessary to create a new object.  *     <span class='http-method method-list put'>PUT</span> - to update or replace the specific element. This request sets the state of the target using the provided values, regardless of their current values.  *     <span class='http-method method-list patch'>PATCH</span> - to edit some specific fields of an entity. With these requests, you only need to provide the data you want to change.  *     <span class='http-method method-list delete'>DELETE</span> - to remove element from your account. Request works if specified object is found. If it is not found, the operation will return a response indicating that the object was not found.  For example, to edit the name and description of a project, where the requested resource is the project with `id` = 1, the request is the following:  __Example Endpoint__ <div class='well well-sm'> <span class='http-method patch'>PATCH</span> https://api.crowdin.com/api/v2/<span class='api-section-block-highlighted'>projects/1</span> </div>  where <span class='api-section-block-highlighted'>projects/1</span> is the requested resource.  __Content-Type header:__ `application/json`  __Request body__ ``` [   {\"op\":\"replace\", \"path\":\"/name\", \"value\":\"Project new name\"},   {\"op\":\"replace\", \"path\":\"/description\", \"value\":\"New description for the project\"} ] ```  ## Rate Limits The number of simultaneous API requests per account is 20 requests. Response code __429 Too Many Requests__ is returned when the limit is exceeded.  ## Crowdin API Clients The Crowdin API clients are the lightweight interfaces developed for the Crowdin API v2. They provide common services for making API requests.  You may find detailed information on each client in its respective GitHub repository:  [_Crowdin JavaScript client_](https://github.com/crowdin/crowdin-api-client-js)\\ [_Crowdin PHP client_](https://github.com/crowdin/crowdin-api-client-php)\\ [_Crowdin Java client_](https://github.com/crowdin/crowdin-api-client-java)\\ [_Crowdin Python client_](https://github.com/crowdin/crowdin-api-client-python)\\ _Crowdin .NET client_ _(Coming soon)_  
 *
 * The version of the OpenAPI document: 2.0
 * Contact: support@crowdin.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Crowdin.Api.Client.OpenAPIDateConverter;

namespace Crowdin.Api.Model
{
    /// <summary>
    /// Values available:  *          empty value or &#39;auto&#39; — Try to detect file type by extension or MIME type  *          &#39;android&#39; — Android (*.xml)  *          &#39;macosx&#39; — Mac OS X / iOS (*.strings)  *          &#39;resx&#39; — .NET, Windows Phone (*.resx)  *          &#39;properties&#39; — Java (*.properties)  *          &#39;gettext&#39; — GNU GetText (*.po, *.pot)  *          &#39;yaml&#39; — Ruby On Rails (*.yaml)  *          &#39;php&#39; — Hypertext Preprocessor (*.php)  *          &#39;json&#39; — Generic JSON (*.json)  *          &#39;xml&#39; — Generic XML (*.xml)  *          &#39;ini&#39; — Generic INI (*.ini)  *          &#39;rc&#39; — Windows Resources (*.rc)  *          &#39;resw&#39; — Windows 8 Metro (*.resw)  *          &#39;resjson&#39; — Windows 8 Metro (*.resjson)  *          &#39;qtts&#39; — Nokia Qt (*.ts)  *          &#39;joomla&#39; — Joomla localizable resources (*.ini)  *          &#39;chrome&#39; — Google Chrome Extension (*.json)  *          &#39;dtd&#39; — Mozilla DTD (*.dtd)  *          &#39;dklang&#39; — Delphi DKLang (*.dklang)  *          &#39;flex&#39; — Flex (*.properties)  *          &#39;nsh&#39; — NSIS Installer Resources (*.nsh)  *          &#39;wxl&#39; — WiX Installer (*.wxl)  *          &#39;xliff&#39; — XLIFF (*.xliff)  *          &#39;html&#39; — HTML (*.html, *.htm, *.xhtml, *.xhtm)  *          &#39;haml&#39; — Haml (*.haml)  *          &#39;txt&#39; — Plain Text (*.txt)  *          &#39;csv&#39; — Comma Separated Values (*.csv)  *          &#39;md&#39; — Markdown (*.md, *.text, *.markdown...)  *          &#39;flsnp&#39; — MadCap Flare (*.flnsp, .flpgpl .fltoc)  *          &#39;fm_html&#39; — Jekyll HTML (*.html)  *          &#39;fm_md&#39; — Jekyll Markdown (*.md)  *          &#39;mediawiki&#39; — MediaWiki (*.wiki, *.wikitext, *.mediawiki)  *          &#39;docx&#39; — Microsoft Office, OpenOffice.org Documents, Adobe InDesign, Adobe FrameMaker(*.docx, *.dotx, *.odt, *.ott, *.xslx, *.xltx, *.pptx, *.potx, *.ods, *.ots, *.odg, *.otg, *.odp, *.otp, *.imdl, *.mif)  *          &#39;sbv&#39; — Youtube .sbv (*.sbv)  *          &#39;properties_play&#39; — Play Framework  *          &#39;properties_xml&#39; — Java Application (*.xml)  *          &#39;maxthon&#39; — Maxthon Browser (*.ini)  *          &#39;go_json&#39; — Go (*.json)  *          &#39;dita&#39; — DITA Document (*.dita, *.ditamap)  *          &#39;mif&#39; — Adobe FrameMaker (*.mif)  *          &#39;idml&#39; — Adobe InDesign (*.idml)  *          &#39;stringsdict&#39; — iOS (*.stringsdict)  *          &#39;vtt&#39; — Video Subtitling and WebVTT (*.vtt)  *          &#39;srt&#39; — SubRip .srt (*.srt)  *          &#39;toml&#39; — Toml (*.toml)  *          &#39;contentful_rt&#39; — Contentful (*.json)  *          &#39;svg&#39; — SVG (*.svg)  *          &#39;js&#39; — JavaScript (*.js)  *          &#39;coffee&#39; — CoffeeScript (*.coffee)  *          &#39;ts&#39; — TypeScript (*.ts)  *          &#39;fbt&#39; — FBT (*.json)  *          &#39;i18next_json&#39; — i18next (*.json)  *          &#39;xaml&#39; — XAML (*.xaml)  *          &#39;adoc&#39; — AsciiDoc (*.adoc)
    /// </summary>
    /// <value>Values available:  *          empty value or &#39;auto&#39; — Try to detect file type by extension or MIME type  *          &#39;android&#39; — Android (*.xml)  *          &#39;macosx&#39; — Mac OS X / iOS (*.strings)  *          &#39;resx&#39; — .NET, Windows Phone (*.resx)  *          &#39;properties&#39; — Java (*.properties)  *          &#39;gettext&#39; — GNU GetText (*.po, *.pot)  *          &#39;yaml&#39; — Ruby On Rails (*.yaml)  *          &#39;php&#39; — Hypertext Preprocessor (*.php)  *          &#39;json&#39; — Generic JSON (*.json)  *          &#39;xml&#39; — Generic XML (*.xml)  *          &#39;ini&#39; — Generic INI (*.ini)  *          &#39;rc&#39; — Windows Resources (*.rc)  *          &#39;resw&#39; — Windows 8 Metro (*.resw)  *          &#39;resjson&#39; — Windows 8 Metro (*.resjson)  *          &#39;qtts&#39; — Nokia Qt (*.ts)  *          &#39;joomla&#39; — Joomla localizable resources (*.ini)  *          &#39;chrome&#39; — Google Chrome Extension (*.json)  *          &#39;dtd&#39; — Mozilla DTD (*.dtd)  *          &#39;dklang&#39; — Delphi DKLang (*.dklang)  *          &#39;flex&#39; — Flex (*.properties)  *          &#39;nsh&#39; — NSIS Installer Resources (*.nsh)  *          &#39;wxl&#39; — WiX Installer (*.wxl)  *          &#39;xliff&#39; — XLIFF (*.xliff)  *          &#39;html&#39; — HTML (*.html, *.htm, *.xhtml, *.xhtm)  *          &#39;haml&#39; — Haml (*.haml)  *          &#39;txt&#39; — Plain Text (*.txt)  *          &#39;csv&#39; — Comma Separated Values (*.csv)  *          &#39;md&#39; — Markdown (*.md, *.text, *.markdown...)  *          &#39;flsnp&#39; — MadCap Flare (*.flnsp, .flpgpl .fltoc)  *          &#39;fm_html&#39; — Jekyll HTML (*.html)  *          &#39;fm_md&#39; — Jekyll Markdown (*.md)  *          &#39;mediawiki&#39; — MediaWiki (*.wiki, *.wikitext, *.mediawiki)  *          &#39;docx&#39; — Microsoft Office, OpenOffice.org Documents, Adobe InDesign, Adobe FrameMaker(*.docx, *.dotx, *.odt, *.ott, *.xslx, *.xltx, *.pptx, *.potx, *.ods, *.ots, *.odg, *.otg, *.odp, *.otp, *.imdl, *.mif)  *          &#39;sbv&#39; — Youtube .sbv (*.sbv)  *          &#39;properties_play&#39; — Play Framework  *          &#39;properties_xml&#39; — Java Application (*.xml)  *          &#39;maxthon&#39; — Maxthon Browser (*.ini)  *          &#39;go_json&#39; — Go (*.json)  *          &#39;dita&#39; — DITA Document (*.dita, *.ditamap)  *          &#39;mif&#39; — Adobe FrameMaker (*.mif)  *          &#39;idml&#39; — Adobe InDesign (*.idml)  *          &#39;stringsdict&#39; — iOS (*.stringsdict)  *          &#39;vtt&#39; — Video Subtitling and WebVTT (*.vtt)  *          &#39;srt&#39; — SubRip .srt (*.srt)  *          &#39;toml&#39; — Toml (*.toml)  *          &#39;contentful_rt&#39; — Contentful (*.json)  *          &#39;svg&#39; — SVG (*.svg)  *          &#39;js&#39; — JavaScript (*.js)  *          &#39;coffee&#39; — CoffeeScript (*.coffee)  *          &#39;ts&#39; — TypeScript (*.ts)  *          &#39;fbt&#39; — FBT (*.json)  *          &#39;i18next_json&#39; — i18next (*.json)  *          &#39;xaml&#39; — XAML (*.xaml)  *          &#39;adoc&#39; — AsciiDoc (*.adoc)</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProjectFileType
    {
        /// <summary>
        /// Enum Auto for value: auto
        /// </summary>
        [EnumMember(Value = "auto")]
        Auto = 1,

        /// <summary>
        /// Enum Android for value: android
        /// </summary>
        [EnumMember(Value = "android")]
        Android = 2,

        /// <summary>
        /// Enum Macosx for value: macosx
        /// </summary>
        [EnumMember(Value = "macosx")]
        Macosx = 3,

        /// <summary>
        /// Enum Resx for value: resx
        /// </summary>
        [EnumMember(Value = "resx")]
        Resx = 4,

        /// <summary>
        /// Enum Properties for value: properties
        /// </summary>
        [EnumMember(Value = "properties")]
        Properties = 5,

        /// <summary>
        /// Enum Gettext for value: gettext
        /// </summary>
        [EnumMember(Value = "gettext")]
        Gettext = 6,

        /// <summary>
        /// Enum Yaml for value: yaml
        /// </summary>
        [EnumMember(Value = "yaml")]
        Yaml = 7,

        /// <summary>
        /// Enum Php for value: php
        /// </summary>
        [EnumMember(Value = "php")]
        Php = 8,

        /// <summary>
        /// Enum Json for value: json
        /// </summary>
        [EnumMember(Value = "json")]
        Json = 9,

        /// <summary>
        /// Enum Xml for value: xml
        /// </summary>
        [EnumMember(Value = "xml")]
        Xml = 10,

        /// <summary>
        /// Enum Ini for value: ini
        /// </summary>
        [EnumMember(Value = "ini")]
        Ini = 11,

        /// <summary>
        /// Enum Rc for value: rc
        /// </summary>
        [EnumMember(Value = "rc")]
        Rc = 12,

        /// <summary>
        /// Enum Resw for value: resw
        /// </summary>
        [EnumMember(Value = "resw")]
        Resw = 13,

        /// <summary>
        /// Enum Resjson for value: resjson
        /// </summary>
        [EnumMember(Value = "resjson")]
        Resjson = 14,

        /// <summary>
        /// Enum Qtts for value: qtts
        /// </summary>
        [EnumMember(Value = "qtts")]
        Qtts = 15,

        /// <summary>
        /// Enum Joomla for value: joomla
        /// </summary>
        [EnumMember(Value = "joomla")]
        Joomla = 16,

        /// <summary>
        /// Enum Chrome for value: chrome
        /// </summary>
        [EnumMember(Value = "chrome")]
        Chrome = 17,

        /// <summary>
        /// Enum Dtd for value: dtd
        /// </summary>
        [EnumMember(Value = "dtd")]
        Dtd = 18,

        /// <summary>
        /// Enum Dklang for value: dklang
        /// </summary>
        [EnumMember(Value = "dklang")]
        Dklang = 19,

        /// <summary>
        /// Enum Flex for value: flex
        /// </summary>
        [EnumMember(Value = "flex")]
        Flex = 20,

        /// <summary>
        /// Enum Nsh for value: nsh
        /// </summary>
        [EnumMember(Value = "nsh")]
        Nsh = 21,

        /// <summary>
        /// Enum Wxl for value: wxl
        /// </summary>
        [EnumMember(Value = "wxl")]
        Wxl = 22,

        /// <summary>
        /// Enum Xliff for value: xliff
        /// </summary>
        [EnumMember(Value = "xliff")]
        Xliff = 23,

        /// <summary>
        /// Enum Html for value: html
        /// </summary>
        [EnumMember(Value = "html")]
        Html = 24,

        /// <summary>
        /// Enum Haml for value: haml
        /// </summary>
        [EnumMember(Value = "haml")]
        Haml = 25,

        /// <summary>
        /// Enum Txt for value: txt
        /// </summary>
        [EnumMember(Value = "txt")]
        Txt = 26,

        /// <summary>
        /// Enum Csv for value: csv
        /// </summary>
        [EnumMember(Value = "csv")]
        Csv = 27,

        /// <summary>
        /// Enum Md for value: md
        /// </summary>
        [EnumMember(Value = "md")]
        Md = 28,

        /// <summary>
        /// Enum Flsnp for value: flsnp
        /// </summary>
        [EnumMember(Value = "flsnp")]
        Flsnp = 29,

        /// <summary>
        /// Enum FmHtml for value: fm_html
        /// </summary>
        [EnumMember(Value = "fm_html")]
        FmHtml = 30,

        /// <summary>
        /// Enum FmMd for value: fm_md
        /// </summary>
        [EnumMember(Value = "fm_md")]
        FmMd = 31,

        /// <summary>
        /// Enum Mediawiki for value: mediawiki
        /// </summary>
        [EnumMember(Value = "mediawiki")]
        Mediawiki = 32,

        /// <summary>
        /// Enum Docx for value: docx
        /// </summary>
        [EnumMember(Value = "docx")]
        Docx = 33,

        /// <summary>
        /// Enum Sbv for value: sbv
        /// </summary>
        [EnumMember(Value = "sbv")]
        Sbv = 34,

        /// <summary>
        /// Enum PropertiesPlay for value: properties_play
        /// </summary>
        [EnumMember(Value = "properties_play")]
        PropertiesPlay = 35,

        /// <summary>
        /// Enum PropertiesXml for value: properties_xml
        /// </summary>
        [EnumMember(Value = "properties_xml")]
        PropertiesXml = 36,

        /// <summary>
        /// Enum Maxthon for value: maxthon
        /// </summary>
        [EnumMember(Value = "maxthon")]
        Maxthon = 37,

        /// <summary>
        /// Enum GoJson for value: go_json
        /// </summary>
        [EnumMember(Value = "go_json")]
        GoJson = 38,

        /// <summary>
        /// Enum Dita for value: dita
        /// </summary>
        [EnumMember(Value = "dita")]
        Dita = 39,

        /// <summary>
        /// Enum Idml for value: idml
        /// </summary>
        [EnumMember(Value = "idml")]
        Idml = 40,

        /// <summary>
        /// Enum Mif for value: mif
        /// </summary>
        [EnumMember(Value = "mif")]
        Mif = 41,

        /// <summary>
        /// Enum Stringsdict for value: stringsdict
        /// </summary>
        [EnumMember(Value = "stringsdict")]
        Stringsdict = 42,

        /// <summary>
        /// Enum Vtt for value: vtt
        /// </summary>
        [EnumMember(Value = "vtt")]
        Vtt = 43,

        /// <summary>
        /// Enum Srt for value: srt
        /// </summary>
        [EnumMember(Value = "srt")]
        Srt = 44,

        /// <summary>
        /// Enum Toml for value: toml
        /// </summary>
        [EnumMember(Value = "toml")]
        Toml = 45,

        /// <summary>
        /// Enum ContentfulRt for value: contentful_rt
        /// </summary>
        [EnumMember(Value = "contentful_rt")]
        ContentfulRt = 46,

        /// <summary>
        /// Enum Svg for value: svg
        /// </summary>
        [EnumMember(Value = "svg")]
        Svg = 47,

        /// <summary>
        /// Enum Js for value: js
        /// </summary>
        [EnumMember(Value = "js")]
        Js = 48,

        /// <summary>
        /// Enum Coffee for value: coffee
        /// </summary>
        [EnumMember(Value = "coffee")]
        Coffee = 49,

        /// <summary>
        /// Enum Ts for value: ts
        /// </summary>
        [EnumMember(Value = "ts")]
        Ts = 50,

        /// <summary>
        /// Enum Fbt for value: fbt
        /// </summary>
        [EnumMember(Value = "fbt")]
        Fbt = 51,

        /// <summary>
        /// Enum I18nextJson for value: i18next_json
        /// </summary>
        [EnumMember(Value = "i18next_json")]
        I18nextJson = 52,

        /// <summary>
        /// Enum Xaml for value: xaml
        /// </summary>
        [EnumMember(Value = "xaml")]
        Xaml = 53,

        /// <summary>
        /// Enum Adoc for value: adoc
        /// </summary>
        [EnumMember(Value = "adoc")]
        Adoc = 54

    }

}
