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
    internal class SecurityLogs {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SecurityLogs() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Crowdin.Api.UnitTesting.Resources.SecurityLogs", typeof(SecurityLogs).Assembly);
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
        ///    &quot;id&quot;: 2,
        ///    &quot;event&quot;: &quot;application.connected&quot;,
        ///    &quot;info&quot;: &quot;Some info&quot;,
        ///    &quot;userId&quot;: 4,
        ///    &quot;location&quot;: &quot;USA&quot;,
        ///    &quot;ipAddress&quot;: &quot;127.0.0.1&quot;,
        ///    &quot;deviceName&quot;: &quot;MacOs on MacBook&quot;,
        ///    &quot;createdAt&quot;: &quot;2019-09-19T15:10:43+00:00&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string GetUserSecurityLog_Response {
            get {
                return ResourceManager.GetString("GetUserSecurityLog_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: [
        ///    {
        ///      &quot;data&quot;: {
        ///        &quot;id&quot;: 2,
        ///        &quot;event&quot;: &quot;application.connected&quot;,
        ///        &quot;info&quot;: &quot;Some info&quot;,
        ///        &quot;userId&quot;: 4,
        ///        &quot;location&quot;: &quot;USA&quot;,
        ///        &quot;ipAddress&quot;: &quot;127.0.0.1&quot;,
        ///        &quot;deviceName&quot;: &quot;MacOs on MacBook&quot;,
        ///        &quot;createdAt&quot;: &quot;2019-09-19T15:10:43+00:00&quot;
        ///      }
        ///    }
        ///  ],
        ///  &quot;pagination&quot;: {
        ///    &quot;offset&quot;: 0,
        ///    &quot;limit&quot;: 25
        ///  }
        ///}.
        /// </summary>
        internal static string ListUserSecurityLogs_Response {
            get {
                return ResourceManager.GetString("ListUserSecurityLogs_Response", resourceCulture);
            }
        }
    }
}