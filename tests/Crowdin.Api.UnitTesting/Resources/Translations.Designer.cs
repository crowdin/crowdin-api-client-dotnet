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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Translations {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Translations() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Crowdin.Api.UnitTesting.Resources.Translations", typeof(Translations).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string ApplyPreTranslationResponse {
            get {
                return ResourceManager.GetString("ApplyPreTranslationResponse", resourceCulture);
            }
        }
        
        internal static string GetLanguageStatusResponse {
            get {
                return ResourceManager.GetString("GetLanguageStatusResponse", resourceCulture);
            }
        }
        
        internal static string UploadTranslationsResponse {
            get {
                return ResourceManager.GetString("UploadTranslationsResponse", resourceCulture);
            }
        }
        
        internal static string ListProjectBuildsResponse {
            get {
                return ResourceManager.GetString("ListProjectBuildsResponse", resourceCulture);
            }
        }
        
        internal static string GetPreTranslationStatus_Response {
            get {
                return ResourceManager.GetString("GetPreTranslationStatus_Response", resourceCulture);
            }
        }
        
        internal static string CommonResources_PreTranslations_List {
            get {
                return ResourceManager.GetString("CommonResources_PreTranslations_List", resourceCulture);
            }
        }
        
        internal static string CommonResources_PreTranslation {
            get {
                return ResourceManager.GetString("CommonResources_PreTranslation", resourceCulture);
            }
        }
        
        internal static string EditPreTranslation_Request {
            get {
                return ResourceManager.GetString("EditPreTranslation_Request", resourceCulture);
            }
        }
        
        internal static string PreTranslationReport_Response {
            get {
                return ResourceManager.GetString("PreTranslationReport_Response", resourceCulture);
            }
        }
    }
}
