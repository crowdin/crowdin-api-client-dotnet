﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crowdin.Api.Tests.Testing.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class AI_Reports {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AI_Reports() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Crowdin.Api.Tests.Testing.Resources.AI_Reports", typeof(AI_Reports).Assembly);
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
        ///  &quot;data&quot;: {
        ///    &quot;identifier&quot;: &quot;50fb3506-4127-4ba8-8296-f97dc7e3e0c3&quot;,
        ///    &quot;status&quot;: &quot;finished&quot;,
        ///    &quot;progress&quot;: 100,
        ///    &quot;attributes&quot;: {
        ///      &quot;format&quot;: &quot;json&quot;,
        ///      &quot;reportType&quot;: &quot;tokens-usage-raw-data&quot;,
        ///      &quot;schema&quot;: {}
        ///    },
        ///    &quot;createdAt&quot;: &quot;2024-01-23T11:26:54+00:00&quot;,
        ///    &quot;updatedAt&quot;: &quot;2024-01-23T11:26:54+00:00&quot;,
        ///    &quot;startedAt&quot;: &quot;2024-01-23T11:26:54+00:00&quot;,
        ///    &quot;finishedAt&quot;: &quot;2024-01-23T11:26:54+00:00&quot;,
        ///    &quot;eta&quot;: &quot;1 second&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string CommonResponses_AiReportGenerationStatus {
            get {
                return ResourceManager.GetString("CommonResponses_AiReportGenerationStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;url&quot;: &quot;https://test.com&quot;,
        ///    &quot;expireIn&quot;: &quot;2019-09-20T10:31:21+00:00&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string DownloadAiReport_Response {
            get {
                return ResourceManager.GetString("DownloadAiReport_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;type&quot;: &quot;tokens-usage-raw-data&quot;,
        ///  &quot;schema&quot;: {
        ///    &quot;dateFrom&quot;: &quot;2024-01-23T07:00:14+00:00&quot;,
        ///    &quot;dateTo&quot;: &quot;2024-09-27T07:00:14+00:00&quot;,
        ///    &quot;format&quot;: &quot;json&quot;,
        ///    &quot;projectIds&quot;: [
        ///      22
        ///    ],
        ///    &quot;promptIds&quot;: [
        ///      18
        ///    ],
        ///    &quot;userIds&quot;: [
        ///      1
        ///    ]
        ///  }
        ///}.
        /// </summary>
        internal static string GenerateAiReport_Request {
            get {
                return ResourceManager.GetString("GenerateAiReport_Request", resourceCulture);
            }
        }
    }
}
