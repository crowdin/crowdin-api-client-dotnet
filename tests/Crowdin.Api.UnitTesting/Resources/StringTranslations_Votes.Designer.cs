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
    internal class StringTranslations_Votes {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringTranslations_Votes() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Crowdin.Api.UnitTesting.Resources.StringTranslations_Votes", typeof(StringTranslations_Votes).Assembly);
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
        ///  &quot;mark&quot;: &quot;up&quot;,
        ///  &quot;translationId&quot;: 653412
        ///}.
        /// </summary>
        internal static string AddVote_Request {
            get {
                return ResourceManager.GetString("AddVote_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;id&quot;: 6643,
        ///    &quot;user&quot;: {
        ///      &quot;id&quot;: 19,
        ///      &quot;username&quot;: &quot;john_doe&quot;,
        ///      &quot;fullName&quot;: &quot;John Smith&quot;,
        ///      &quot;avatarUrl&quot;: &quot;&quot;
        ///    },
        ///    &quot;translationId&quot;: 19069345,
        ///    &quot;votedAt&quot;: &quot;2019-09-19T12:42:12+00:00&quot;,
        ///    &quot;mark&quot;: &quot;up&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string AddVote_Response {
            get {
                return ResourceManager.GetString("AddVote_Response", resourceCulture);
            }
        }
    }
}
