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
    internal class StringTranslations {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringTranslations() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Crowdin.Api.Tests.Core.Resources.StringTranslations", typeof(StringTranslations).Assembly);
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
        ///  &quot;stringId&quot;: 35434,
        ///  &quot;languageId&quot;: &quot;uk&quot;,
        ///  &quot;text&quot;: &quot;Цю стрічку перекладено&quot;,
        ///  &quot;pluralCategoryName&quot;: &quot;few&quot;
        ///}.
        /// </summary>
        internal static string AddTranslation_Request {
            get {
                return ResourceManager.GetString("AddTranslation_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;id&quot;: 190695,
        ///    &quot;text&quot;: &quot;Цю стрічку перекладено&quot;,
        ///    &quot;pluralCategoryName&quot;: &quot;few&quot;,
        ///    &quot;user&quot;: {
        ///      &quot;id&quot;: 19,
        ///      &quot;username&quot;: &quot;john_doe&quot;,
        ///      &quot;fullName&quot;: &quot;John Smith&quot;,
        ///      &quot;avatarUrl&quot;: &quot;&quot;
        ///    },
        ///    &quot;rating&quot;: 10,
        ///    &quot;createdAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string AddTranslation_Response {
            get {
                return ResourceManager.GetString("AddTranslation_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;data&quot;: [
        ///      {
        ///        &quot;data&quot;: {
        ///          &quot;stringId&quot;: 6356,
        ///          &quot;contentType&quot;: &quot;text/plain&quot;,
        ///          &quot;translationId&quot;: 732,
        ///          &quot;text&quot;: &quot;Confirm New Password&quot;,
        ///          &quot;user&quot;: {
        ///            &quot;id&quot;: 19,
        ///            &quot;username&quot;: &quot;john_doe&quot;,
        ///            &quot;fullName&quot;: &quot;John Smith&quot;,
        ///            &quot;avatarUrl&quot;: &quot;&quot;
        ///          },
        ///          &quot;createdAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;
        ///        }
        ///      },
        ///      {
        ///          &quot;data&quot;: {
        ///              &quot;stringId&quot;: 6357,
        ///              &quot;content [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ListLanguageTranslations_Response {
            get {
                return ResourceManager.GetString("ListLanguageTranslations_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;id&quot;: 190695,
        ///    &quot;text&quot;: &quot;Цю стрічку перекладено&quot;,
        ///    &quot;pluralCategoryName&quot;: &quot;few&quot;,
        ///    &quot;user&quot;: {
        ///      &quot;id&quot;: 19,
        ///      &quot;username&quot;: &quot;john_doe&quot;,
        ///      &quot;fullName&quot;: &quot;John Smith&quot;,
        ///      &quot;avatarUrl&quot;: &quot;&quot;
        ///    },
        ///    &quot;rating&quot;: 10,
        ///    &quot;createdAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string RestoreTranslation_Response {
            get {
                return ResourceManager.GetString("RestoreTranslation_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;sourceLanguageId&quot;: &quot;en&quot;,
        ///  &quot;targetLanguageId&quot;: &quot;de&quot;,
        ///  &quot;text&quot;: &quot;Your password has been reset successfully!&quot;
        ///}.
        /// </summary>
        internal static string TranslationAlignment_Request {
            get {
                return ResourceManager.GetString("TranslationAlignment_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;words&quot;: [
        ///      {
        ///        &quot;text&quot;: &quot;password&quot;,
        ///        &quot;alignments&quot;: [
        ///          {
        ///            &quot;sourceWord&quot;: &quot;Password&quot;,
        ///            &quot;sourceLemma&quot;: &quot;password&quot;,
        ///            &quot;targetWord&quot;: &quot;Пароль&quot;,
        ///            &quot;targetLemma&quot;: &quot;пароль&quot;,
        ///            &quot;match&quot;: 2,
        ///            &quot;probability&quot;: 2
        ///          }
        ///        ]
        ///      }
        ///    ]
        ///  }
        ///}.
        /// </summary>
        internal static string TranslationAlignment_Response {
            get {
                return ResourceManager.GetString("TranslationAlignment_Response", resourceCulture);
            }
        }
    }
}
