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
    internal class Dictionaries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Dictionaries() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Crowdin.Api.UnitTesting.Resources.Dictionaries", typeof(Dictionaries).Assembly);
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
        ///   Looks up a localized string similar to [{&quot;path&quot;:&quot;/words&quot;,&quot;op&quot;:&quot;add&quot;,&quot;value&quot;:&quot;word 1&quot;},{&quot;path&quot;:&quot;/words&quot;,&quot;op&quot;:&quot;add&quot;,&quot;value&quot;:&quot;word 2&quot;}].
        /// </summary>
        internal static string EditDictionary_OpAdd_RightPatchesListJson {
            get {
                return ResourceManager.GetString("EditDictionary_OpAdd_RightPatchesListJson", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [{&quot;path&quot;:&quot;/words/3,2,1,0&quot;,&quot;op&quot;:&quot;remove&quot;}].
        /// </summary>
        internal static string EditDictionary_OpRemove_RightPatchesListJson_MultiIndexesWithDuplicates {
            get {
                return ResourceManager.GetString("EditDictionary_OpRemove_RightPatchesListJson_MultiIndexesWithDuplicates", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [{&quot;path&quot;:&quot;/words/3&quot;,&quot;op&quot;:&quot;remove&quot;}].
        /// </summary>
        internal static string EditDictionary_OpRemove_RightPatchesListJson_SingleIndex {
            get {
                return ResourceManager.GetString("EditDictionary_OpRemove_RightPatchesListJson_SingleIndex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: [
        ///    {
        ///      &quot;data&quot;: {
        ///        &quot;languageId&quot;: &quot;en&quot;,
        ///        &quot;words&quot;: [
        ///          &quot;string&quot;
        ///        ]
        ///      }
        ///    }
        ///  ],
        ///  &quot;pagination&quot;: {
        ///    &quot;offset&quot;: 0,
        ///    &quot;limit&quot;: 25
        ///  }
        ///}.
        /// </summary>
        internal static string ListDictionaries {
            get {
                return ResourceManager.GetString("ListDictionaries", resourceCulture);
            }
        }
    }
}
