﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Teams_GroupTeams {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Teams_GroupTeams() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Crowdin.Api.UnitTesting.Resources.Teams_GroupTeams", typeof(Teams_GroupTeams).Assembly);
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
        ///  &quot;data&quot;: [
        ///    {
        ///      &quot;data&quot;: {
        ///        &quot;id&quot;: 27,
        ///        &quot;team&quot;: {
        ///          &quot;id&quot;: 2,
        ///          &quot;name&quot;: &quot;Translators Team&quot;,
        ///          &quot;totalMembers&quot;: 8,
        ///          &quot;webUrl&quot;: &quot;https://example.crowdin.com/u/teams/1&quot;,
        ///          &quot;createdAt&quot;: &quot;2019-09-23T09:04:29+00:00&quot;,
        ///          &quot;updatedAt&quot;: &quot;2019-09-23T09:04:29+00:00&quot;
        ///        }
        ///      }
        ///    }
        ///  ],
        ///  &quot;pagination&quot;: {
        ///    &quot;offset&quot;: 0,
        ///    &quot;limit&quot;: 25
        ///  }
        ///}.
        /// </summary>
        internal static string CommonResponses_Multi {
            get {
                return ResourceManager.GetString("CommonResponses_Multi", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;id&quot;: 27,
        ///    &quot;team&quot;: {
        ///      &quot;id&quot;: 2,
        ///      &quot;name&quot;: &quot;Translators Team&quot;,
        ///      &quot;totalMembers&quot;: 8,
        ///      &quot;webUrl&quot;: &quot;https://example.crowdin.com/u/teams/1&quot;,
        ///      &quot;createdAt&quot;: &quot;2019-09-23T09:04:29+00:00&quot;,
        ///      &quot;updatedAt&quot;: &quot;2019-09-23T09:04:29+00:00&quot;
        ///    }
        ///  }
        ///}.
        /// </summary>
        internal static string CommonResponses_Single {
            get {
                return ResourceManager.GetString("CommonResponses_Single", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [
        ///  {
        ///
        ///    &quot;path&quot;: &quot;/-&quot;,
        ///    &quot;op&quot;: &quot;add&quot;,
        ///    &quot;value&quot;: {
        ///      &quot;teamId&quot;: 18
        ///    }
        ///  },
        ///  {
        ///
        ///    &quot;path&quot;: &quot;/24&quot;,
        ///    &quot;op&quot;: &quot;remove&quot;
        ///  }
        ///].
        /// </summary>
        internal static string UpdateGroupTeams_Request {
            get {
                return ResourceManager.GetString("UpdateGroupTeams_Request", resourceCulture);
            }
        }
    }
}
