﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crowdin.Api.Tests.Core.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TranslationMemory {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TranslationMemory() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Crowdin.Api.Tests.Core.Resources.TranslationMemory", typeof(TranslationMemory).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;name&quot;: &quot;Knowledge Base&apos;s TM&quot;,
        ///  &quot;languageId&quot;: &quot;fr&quot;,
        ///  &quot;groupId&quot;: 2
        ///}.
        /// </summary>
        internal static string AddTm_Request {
            get {
                return ResourceManager.GetString("AddTm_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;identifier&quot;: &quot;50fb3506-4127-4ba8-8296-f97dc7e3e0c3&quot;,
        ///    &quot;status&quot;: &quot;finished&quot;,
        ///    &quot;progress&quot;: 100,
        ///    &quot;attributes&quot;: {
        ///      &quot;sourceLanguageId&quot;: &quot;en&quot;,
        ///      &quot;targetLanguageId&quot;: &quot;de&quot;,
        ///      &quot;format&quot;: &quot;csv&quot;
        ///    },
        ///    &quot;createdAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;,
        ///    &quot;updatedAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;,
        ///    &quot;startedAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;,
        ///    &quot;finishedAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string CheckTmExportStatus_Response {
            get {
                return ResourceManager.GetString("CheckTmExportStatus_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;identifier&quot;: &quot;b5215a34-1305-4b21-8054-fc2eb252842f&quot;,
        ///    &quot;status&quot;: &quot;created&quot;,
        ///    &quot;progress&quot;: 0,
        ///    &quot;attributes&quot;: {
        ///      &quot;tmId&quot;: 10,
        ///      &quot;storageId&quot;: 28,
        ///      &quot;firstLineContainsHeader&quot;: 10,
        ///      &quot;scheme&quot;: {
        ///        &quot;en&quot;: 0,
        ///        &quot;de&quot;: 2
        ///      }
        ///    },
        ///    &quot;createdAt&quot;: &quot;2019-09-23T11:51:08+00:00&quot;,
        ///    &quot;updatedAt&quot;: &quot;2019-09-23T11:51:08+00:00&quot;,
        ///    &quot;startedAt&quot;: &quot;2019-09-23T11:51:08+00:00&quot;,
        ///    &quot;finishedAt&quot;: &quot;2019-09-23T11:51:08+00:00&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string CheckTmImportStatus_Response {
            get {
                return ResourceManager.GetString("CheckTmImportStatus_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: [
        ///    {
        ///      &quot;data&quot;: {
        ///        &quot;id&quot;: 4,
        ///        &quot;groupId&quot;: 2,
        ///        &quot;userId&quot;: 2,
        ///        &quot;name&quot;: &quot;Knowledge Base&apos;s TM&quot;,
        ///        &quot;languageId&quot;: &quot;fr&quot;,
        ///        &quot;languageIds&quot;: [
        ///          &quot;el&quot;
        ///        ],
        ///        &quot;segmentsCount&quot;: 21,
        ///        &quot;defaultProjectId&quot;: 0,
        ///        &quot;defaultProjectIds&quot;: [
        ///          2
        ///        ],
        ///        &quot;projectIds&quot;: [
        ///          2
        ///        ],
        ///        &quot;createdAt&quot;: &quot;2019-09-16T13:42:04+00:00&quot;
        ///      }
        ///    }
        ///  ],
        ///  &quot;pagination&quot;: {
        ///    &quot;offset&quot;: 0,
        ///    &quot;lim [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CommonResponse_Multi {
            get {
                return ResourceManager.GetString("CommonResponse_Multi", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;id&quot;: 4,
        ///    &quot;groupId&quot;: 2,
        ///    &quot;userId&quot;: 2,
        ///    &quot;name&quot;: &quot;Knowledge Base&apos;s TM&quot;,
        ///    &quot;languageId&quot;: &quot;fr&quot;,
        ///    &quot;languageIds&quot;: [
        ///      &quot;el&quot;
        ///    ],
        ///    &quot;segmentsCount&quot;: 21,
        ///    &quot;defaultProjectIds&quot;: [
        ///      2
        ///    ],
        ///    &quot;projectIds&quot;: [
        ///      2
        ///    ],
        ///    &quot;createdAt&quot;: &quot;2019-09-16T13:42:04+00:00&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string CommonResponse_Single {
            get {
                return ResourceManager.GetString("CommonResponse_Single", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;sourceLanguageId&quot;: &quot;en&quot;,
        ///  &quot;targetLanguageId&quot;: &quot;de&quot;,
        ///  &quot;autoSubstitution&quot;: true,
        ///  &quot;minRelevant&quot;: 60,
        ///  &quot;expression&quot;: &quot;Welcome!&quot;
        ///}.
        /// </summary>
        internal static string ConcordanceSearch_Request {
            get {
                return ResourceManager.GetString("ConcordanceSearch_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: [
        ///    {
        ///      &quot;data&quot;: {
        ///        &quot;tm&quot;: {
        ///          &quot;id&quot;: 4,
        ///          &quot;userId&quot;: 2,
        ///          &quot;name&quot;: &quot;Knowledge Base&apos;s TM&quot;,
        ///          &quot;languageId&quot;: &quot;fr&quot;,
        ///          &quot;languageIds&quot;: [
        ///            &quot;el&quot;
        ///          ],
        ///          &quot;segmentsCount&quot;: 21,
        ///          &quot;defaultProjectIds&quot;: [
        ///            2
        ///          ],
        ///          &quot;projectIds&quot;: [
        ///            2
        ///          ],
        ///          &quot;createdAt&quot;: &quot;2019-09-16T13:42:04+00:00&quot;
        ///        },
        ///        &quot;recordId&quot;: 34,
        ///        &quot;source&quot;: &quot;Welcome!&quot;,
        ///        [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ConcordanceSearch_Response {
            get {
                return ResourceManager.GetString("ConcordanceSearch_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;url&quot;: &quot;https://production-enterprise-importer.downloads.crowdin.com/992000002/2/14.xliff?response-content-disposition=attachment%3B%20filename%3D%22APP.xliff%22&amp;X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&amp;X-Amz-Algorithm=AWS4-HMAC-SHA256&amp;X-Amz-Credential=AKIAIGJKLQV66ZXPMMEA%2F20190920%2Fus-east-1%2Fs3%2Faws4_request&amp;X-Amz-Date=20190920T093121Z&amp;X-Amz-SignedHeaders=host&amp;X-Amz-Expires=3600&amp;X-Amz-Signature=439ebd69a1b7e4c23e6d17891a491c94f832e0c82e4692dedb35a6cd1e624b62&quot;,
        ///    &quot;expireIn&quot;: &quot;2019- [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DownloadTm_Response {
            get {
                return ResourceManager.GetString("DownloadTm_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [
        ///  {
        ///
        ///    &quot;path&quot;: &quot;/name&quot;,
        ///    &quot;op&quot;: &quot;replace&quot;,
        ///    &quot;value&quot;: &quot;Knowledge Base&apos;s TM&quot;
        ///  }
        ///].
        /// </summary>
        internal static string EditTm_Request {
            get {
                return ResourceManager.GetString("EditTm_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;sourceLanguageId&quot;: &quot;en&quot;,
        ///  &quot;targetLanguageId&quot;: &quot;de&quot;,
        ///  &quot;format&quot;: &quot;csv&quot;
        ///}.
        /// </summary>
        internal static string ExportTm_Request {
            get {
                return ResourceManager.GetString("ExportTm_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;identifier&quot;: &quot;50fb3506-4127-4ba8-8296-f97dc7e3e0c3&quot;,
        ///    &quot;status&quot;: &quot;finished&quot;,
        ///    &quot;progress&quot;: 100,
        ///    &quot;attributes&quot;: {
        ///      &quot;sourceLanguageId&quot;: &quot;en&quot;,
        ///      &quot;targetLanguageId&quot;: &quot;de&quot;,
        ///      &quot;format&quot;: &quot;csv&quot;
        ///    },
        ///    &quot;createdAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;,
        ///    &quot;updatedAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;,
        ///    &quot;startedAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;,
        ///    &quot;finishedAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string ExportTm_Response {
            get {
                return ResourceManager.GetString("ExportTm_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;storageId&quot;: 28,
        ///  &quot;firstLineContainsHeader&quot;: false,
        ///  &quot;scheme&quot;: {
        ///    &quot;en&quot;: 0,
        ///    &quot;de&quot;: 1,
        ///    &quot;pl&quot;: 2,
        ///    &quot;uk&quot;: 4
        ///  }
        ///}.
        /// </summary>
        internal static string ImportTm_Request {
            get {
                return ResourceManager.GetString("ImportTm_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;identifier&quot;: &quot;b5215a34-1305-4b21-8054-fc2eb252842f&quot;,
        ///    &quot;status&quot;: &quot;created&quot;,
        ///    &quot;progress&quot;: 0,
        ///    &quot;attributes&quot;: {
        ///      &quot;tmId&quot;: 10,
        ///      &quot;storageId&quot;: 28,
        ///      &quot;firstLineContainsHeader&quot;: 10,
        ///      &quot;scheme&quot;: {
        ///        &quot;en&quot;: 0,
        ///        &quot;de&quot;: 2
        ///      }
        ///    },
        ///    &quot;createdAt&quot;: &quot;2019-09-23T11:51:08+00:00&quot;,
        ///    &quot;updatedAt&quot;: &quot;2019-09-23T11:51:08+00:00&quot;,
        ///    &quot;startedAt&quot;: &quot;2019-09-23T11:51:08+00:00&quot;,
        ///    &quot;finishedAt&quot;: &quot;2019-09-23T11:51:08+00:00&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string ImportTm_Response {
            get {
                return ResourceManager.GetString("ImportTm_Response", resourceCulture);
            }
        }
    }
}