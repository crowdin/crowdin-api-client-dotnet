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
    internal class Notifications {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Notifications() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Crowdin.Api.UnitTesting.Resources.Notifications", typeof(Notifications).Assembly);
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
        ///  &quot;message&quot;: &quot;New notification message&quot;
        ///}.
        /// </summary>
        internal static string SendNotificationToAuthenticatedUser_Request {
            get {
                return ResourceManager.GetString("SendNotificationToAuthenticatedUser_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;role&quot;: &quot;owner&quot;,
        ///  &quot;message&quot;: &quot;New notification message&quot;
        ///}.
        /// </summary>
        internal static string SendNotificationToOrganizationMembers_Request_ByRole {
            get {
                return ResourceManager.GetString("SendNotificationToOrganizationMembers_Request_ByRole", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;userIds&quot;: [
        ///    2
        ///  ],
        ///  &quot;message&quot;: &quot;New notification message&quot;
        ///}.
        /// </summary>
        internal static string SendNotificationToOrganizationMembers_Request_ByUserIds {
            get {
                return ResourceManager.GetString("SendNotificationToOrganizationMembers_Request_ByUserIds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;role&quot;: &quot;owner&quot;,
        ///  &quot;message&quot;: &quot;New notification message&quot;
        ///}.
        /// </summary>
        internal static string SendNotificationToProjectMembers_Request_ByRole {
            get {
                return ResourceManager.GetString("SendNotificationToProjectMembers_Request_ByRole", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;userIds&quot;: [
        ///    1,2,3
        ///  ],
        ///  &quot;message&quot;: &quot;New notification message&quot;
        ///}.
        /// </summary>
        internal static string SendNotificationToProjectMembers_Request_ByUserIds {
            get {
                return ResourceManager.GetString("SendNotificationToProjectMembers_Request_ByUserIds", resourceCulture);
            }
        }
    }
}
