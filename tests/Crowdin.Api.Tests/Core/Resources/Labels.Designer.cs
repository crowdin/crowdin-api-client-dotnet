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
    internal class Labels {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Labels() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Crowdin.Api.Tests.Core.Resources.Labels", typeof(Labels).Assembly);
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
        ///   Looks up a localized string similar to {&quot;title&quot;: &quot;main&quot;}.
        /// </summary>
        internal static string AddLabel_Request {
            get {
                return ResourceManager.GetString("AddLabel_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;id&quot;: 34,
        ///    &quot;title&quot;: &quot;main&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string AddLabel_Response {
            get {
                return ResourceManager.GetString("AddLabel_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;screenshotIds&quot;: [
        ///    1, 2, 3
        ///  ]
        ///}.
        /// </summary>
        internal static string AssignLabelToScreenshots_Request {
            get {
                return ResourceManager.GetString("AssignLabelToScreenshots_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;stringIds&quot;: [
        ///    1, 2, 3, 4, 5
        ///  ]
        ///}.
        /// </summary>
        internal static string AssignLabelToStrings_Request {
            get {
                return ResourceManager.GetString("AssignLabelToStrings_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: [
        ///    {
        ///      &quot;data&quot;: {
        ///        &quot;id&quot;: 2814,
        ///        &quot;projectId&quot;: 2,
        ///        &quot;fileId&quot;: 48,
        ///        &quot;branchId&quot;: 12,
        ///        &quot;directoryId&quot;: 13,
        ///        &quot;identifier&quot;: &quot;name&quot;,
        ///        &quot;text&quot;: &quot;Not all videos are shown to users. See more&quot;,
        ///        &quot;type&quot;: &quot;text&quot;,
        ///        &quot;context&quot;: &quot;shown on main page&quot;,
        ///        &quot;maxLength&quot;: 35,
        ///        &quot;isHidden&quot;: false,
        ///        &quot;revision&quot;: 1,
        ///        &quot;hasPlurals&quot;: false,
        ///        &quot;isIcu&quot;: false,
        ///        &quot;labelIds&quot;: [
        ///          3
        ///        ],
        ///        [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AssignLabelToStrings_Response {
            get {
                return ResourceManager.GetString("AssignLabelToStrings_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: [
        ///    {
        ///      &quot;data&quot;: {
        ///        &quot;id&quot;: 2,
        ///        &quot;userId&quot;: 6,
        ///        &quot;url&quot;: &quot;https://production-enterprise-screenshots.downloads.crowdin.com/992000002/6/2/middle.jpg?X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&amp;X-Amz-Algorithm=AWS4-HMAC-SHA256&amp;X-Amz-Credential=AKIAIGJKLQV66ZXPMMEA%2F20190923%2Fus-east-1%2Fs3%2Faws4_request&amp;X-Amz-Date=20190923T093016Z&amp;X-Amz-SignedHeaders=host&amp;X-Amz-Expires=120&amp;X-Amz-Signature=8df06f57594f7d1804b7c037629f6916224415e9b935c4f6619fbe002fb25e73&quot;,
        ///        &quot;name&quot;: &quot;tra [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CommonResponses_LabelToScreenshots {
            get {
                return ResourceManager.GetString("CommonResponses_LabelToScreenshots", resourceCulture);
            }
        }
    }
}
