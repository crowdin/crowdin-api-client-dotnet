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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Labels {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Labels() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Crowdin.Api.Tests.Core.Resources.Labels", typeof(Labels).Assembly);
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
        
        internal static string AddLabel_Request {
            get {
                return ResourceManager.GetString("AddLabel_Request", resourceCulture);
            }
        }
        
        internal static string AddLabel_Response {
            get {
                return ResourceManager.GetString("AddLabel_Response", resourceCulture);
            }
        }
        
        internal static string AssignLabelToStrings_Request {
            get {
                return ResourceManager.GetString("AssignLabelToStrings_Request", resourceCulture);
            }
        }
        
        internal static string AssignLabelToStrings_Response {
            get {
                return ResourceManager.GetString("AssignLabelToStrings_Response", resourceCulture);
            }
        }
        
        internal static string AssignLabelToScreenshots_Request {
            get {
                return ResourceManager.GetString("AssignLabelToScreenshots_Request", resourceCulture);
            }
        }
        
        internal static string CommonResponses_LabelToScreenshots {
            get {
                return ResourceManager.GetString("CommonResponses_LabelToScreenshots", resourceCulture);
            }
        }
        
        internal static string ListLabels_Response {
            get {
                return ResourceManager.GetString("ListLabels_Response", resourceCulture);
            }
        }
    }
}
