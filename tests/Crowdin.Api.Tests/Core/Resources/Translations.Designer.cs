﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Translations {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Translations() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Crowdin.Api.Tests.Core.Resources.Translations", typeof(Translations).Assembly);
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
        ///    &quot;identifier&quot;: &quot;9e7de270-4f83-41cb-b606-2f90631f26e2&quot;,
        ///    &quot;status&quot;: &quot;created&quot;,
        ///    &quot;progress&quot;: 90,
        ///    &quot;attributes&quot;: {
        ///      &quot;languageIds&quot;: [
        ///        &quot;uk&quot;
        ///      ],
        ///      &quot;fileIds&quot;: [
        ///        0
        ///      ],
        ///      &quot;method&quot;: &quot;tm&quot;,
        ///      &quot;autoApproveOption&quot;: &quot;all&quot;,
        ///      &quot;duplicateTranslations&quot;: true,
        ///      &quot;translateUntranslatedOnly&quot;: true,
        ///      &quot;translateWithPerfectMatchOnly&quot;: true,
        ///      &quot;labelIds&quot;: [2, 3],
        ///      &quot;excludeLabelIds&quot;: [4]      
        ///    },
        ///    &quot;createdAt&quot;: &quot;2019-09 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ApplyPreTranslationResponse {
            get {
                return ResourceManager.GetString("ApplyPreTranslationResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: [
        ///    {
        ///      &quot;data&quot;: {
        ///        &quot;words&quot;: {
        ///          &quot;total&quot;: 7249,
        ///          &quot;translated&quot;: 3651,
        ///          &quot;approved&quot;: 3637
        ///        },
        ///        &quot;phrases&quot;: {
        ///          &quot;total&quot;: 3041,
        ///          &quot;translated&quot;: 2631,
        ///          &quot;approved&quot;: 2622
        ///        },
        ///        &quot;translationProgress&quot;: 86,
        ///        &quot;approvalProgress&quot;: 86,
        ///        &quot;fileId&quot;: 12,
        ///        &quot;eTag&quot;: &quot;fd0ea167420ef1687fd16635b9fb67a3&quot;
        ///      }
        ///    }
        ///  ],
        ///  &quot;pagination&quot;: {
        ///    &quot;offset&quot;: 0,
        ///    &quot;limit&quot;: 25
        ///  }
        ///}.
        /// </summary>
        internal static string GetLanguageStatusResponse {
            get {
                return ResourceManager.GetString("GetLanguageStatusResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;identifier&quot;: &quot;9e7de270-4f83-41cb-b606-2f90631f26e2&quot;,
        ///    &quot;status&quot;: &quot;created&quot;,
        ///    &quot;progress&quot;: 90,
        ///    &quot;attributes&quot;: {
        ///      &quot;languageIds&quot;: [
        ///        &quot;uk&quot;
        ///      ],
        ///      &quot;fileIds&quot;: [
        ///        0
        ///      ],
        ///      &quot;method&quot;: &quot;tm&quot;,
        ///      &quot;autoApproveOption&quot;: &quot;all&quot;,
        ///      &quot;duplicateTranslations&quot;: true,
        ///      &quot;skipApprovedTranslations&quot;: true,
        ///      &quot;translateUntranslatedOnly&quot;: true,
        ///      &quot;translateWithPerfectMatchOnly&quot;: true,
        ///      &quot;labelIds&quot;: [2, 3],
        ///      &quot;excludeLabelIds&quot;: [4] [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GetPreTranslationStatus_Response {
            get {
                return ResourceManager.GetString("GetPreTranslationStatus_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;data&quot;: [
        ///        {
        ///            &quot;data&quot;: {
        ///                &quot;id&quot;: 13,
        ///                &quot;projectId&quot;: 12345,
        ///                &quot;status&quot;: &quot;finished&quot;,
        ///                &quot;progress&quot;: 100,
        ///                &quot;createdAt&quot;: &quot;2022-03-31T18:31:28+00:00&quot;,
        ///                &quot;updatedAt&quot;: &quot;2022-03-31T18:45:15+00:00&quot;,
        ///                &quot;finishedAt&quot;: &quot;2022-03-31T18:45:15+00:00&quot;,
        ///                &quot;attributes&quot;: {
        ///                    &quot;branchId&quot;: null,
        ///                    &quot;directoryId&quot;: null,
        ///                    &quot;targetLang [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ListProjectBuildsResponse {
            get {
                return ResourceManager.GetString("ListProjectBuildsResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;projectId&quot;: 1,
        ///    &quot;storageId&quot;: 34,
        ///    &quot;languageId&quot;: &quot;es&quot;,
        ///    &quot;fileId&quot;: 56
        ///  }
        ///}.
        /// </summary>
        internal static string UploadTranslationsResponse {
            get {
                return ResourceManager.GetString("UploadTranslationsResponse", resourceCulture);
            }
        }
    }
}
