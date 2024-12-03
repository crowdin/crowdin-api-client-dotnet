﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crowdin.Api.UnitTesting.Resources {
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
    internal class Tasks_SettingsTemplates {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Tasks_SettingsTemplates() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Crowdin.Api.UnitTesting.Resources.Tasks_SettingsTemplates", typeof(Tasks_SettingsTemplates).Assembly);
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
        ///  &quot;name&quot;: &quot;Default template&quot;,
        ///  &quot;config&quot;: {
        ///    &quot;languages&quot;: [
        ///      {
        ///        &quot;languageId&quot;: &quot;uk&quot;,
        ///        &quot;userIds&quot;: [
        ///          1
        ///        ],
        ///        &quot;teamIds&quot;: [
        ///          1
        ///        ]
        ///      }
        ///    ]
        ///  }
        ///}.
        /// </summary>
        internal static string AddTaskSettingsTemplates_Request {
            get {
                return ResourceManager.GetString("AddTaskSettingsTemplates_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [
        ///  {
        ///    &quot;path&quot;: &quot;/name&quot;,
        ///    &quot;op&quot;: &quot;replace&quot;,
        ///    &quot;value&quot;: &quot;New name&quot;
        ///  }
        ///].
        /// </summary>
        internal static string EditTaskSettingsTemplate_Request {
            get {
                return ResourceManager.GetString("EditTaskSettingsTemplate_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: [
        ///    {
        ///      &quot;data&quot;: {
        ///        &quot;id&quot;: 1,
        ///        &quot;name&quot;: &quot;Default template&quot;,
        ///        &quot;config&quot;: {
        ///          &quot;languages&quot;: [
        ///            {
        ///              &quot;languageId&quot;: &quot;uk&quot;,
        ///              &quot;userIds&quot;: [
        ///                1
        ///              ],
        ///              &quot;teamIds&quot;: [
        ///                1
        ///              ]
        ///            }
        ///          ]
        ///        },
        ///        &quot;createdAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;,
        ///        &quot;updatedAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;
        ///      }
        ///    }
        ///  ],
        ///  &quot;pagination&quot;: {
        ///    &quot;offs [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ListTaskSettingsTemplates_Response {
            get {
                return ResourceManager.GetString("ListTaskSettingsTemplates_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;id&quot;: 1,
        ///    &quot;name&quot;: &quot;Default template&quot;,
        ///    &quot;config&quot;: {
        ///      &quot;languages&quot;: [
        ///        {
        ///          &quot;languageId&quot;: &quot;uk&quot;,
        ///          &quot;userIds&quot;: [
        ///            1
        ///          ],
        ///          &quot;teamIds&quot;: [
        ///            1
        ///          ]
        ///        }
        ///      ]
        ///    },
        ///    &quot;createdAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;,
        ///    &quot;updatedAt&quot;: &quot;2019-09-23T11:26:54+00:00&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string Shared_SingleItem_Response {
            get {
                return ResourceManager.GetString("Shared_SingleItem_Response", resourceCulture);
            }
        }
    }
}