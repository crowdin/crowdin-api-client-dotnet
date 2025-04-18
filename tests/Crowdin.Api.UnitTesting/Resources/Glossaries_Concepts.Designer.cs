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
    internal class Glossaries_Concepts {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Glossaries_Concepts() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Crowdin.Api.UnitTesting.Resources.Glossaries_Concepts", typeof(Glossaries_Concepts).Assembly);
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
        ///    &quot;userId&quot;: 6,
        ///    &quot;glossaryId&quot;: 6,
        ///    &quot;subject&quot;: &quot;general&quot;,
        ///    &quot;definition&quot;: &quot;Some definition&quot;,
        ///    &quot;note&quot;: &quot;Any kind of note, such as a usage note, explanation, or instruction&quot;,
        ///    &quot;url&quot;: &quot;Base URL&quot;,
        ///    &quot;figure&quot;: &quot;Figure URL&quot;,
        ///    &quot;languagesDetails&quot;: [
        ///      {
        ///        &quot;languageId&quot;: &quot;en&quot;,
        ///        &quot;userId&quot;: 12,
        ///        &quot;definition&quot;: &quot;Some definition&quot;,
        ///        &quot;note&quot;: &quot;Some note&quot;,
        ///        &quot;createdAt&quot;: &quot;2019-09-19T14:14:00+00:00&quot;,
        ///        &quot;updatedAt&quot;: &quot;2019-09 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GetConcept_Response {
            get {
                return ResourceManager.GetString("GetConcept_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: [
        ///    {
        ///      &quot;data&quot;: {
        ///        &quot;id&quot;: 2,
        ///        &quot;userId&quot;: 6,
        ///        &quot;glossaryId&quot;: 6,
        ///        &quot;subject&quot;: &quot;general&quot;,
        ///        &quot;definition&quot;: &quot;Some definition&quot;,
        ///        &quot;note&quot;: &quot;Any kind of note, such as a usage note, explanation, or instruction&quot;,
        ///        &quot;url&quot;: &quot;Base URL&quot;,
        ///        &quot;figure&quot;: &quot;Figure URL&quot;,
        ///        &quot;languagesDetails&quot;: [
        ///          {
        ///            &quot;languageId&quot;: &quot;en&quot;,
        ///            &quot;userId&quot;: 12,
        ///            &quot;definition&quot;: &quot;Some definition&quot;,
        ///            &quot;note&quot;: &quot;Some note&quot;,
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ListConcepts_Response {
            get {
                return ResourceManager.GetString("ListConcepts_Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;subject&quot;: &quot;general&quot;,
        ///  &quot;definition&quot;: &quot;This is a sample definition.&quot;,
        ///  &quot;note&quot;: &quot;Any concept-level note information&quot;,
        ///  &quot;url&quot;: &quot;string&quot;,
        ///  &quot;figure&quot;: &quot;string&quot;,
        ///  &quot;languagesDetails&quot;: [
        ///    {
        ///      &quot;languageId&quot;: &quot;en&quot;,
        ///      &quot;definition&quot;: &quot;This is a sample definition.&quot;,
        ///      &quot;note&quot;: &quot;Any kind of note, such as a usage note, explanation, or instruction.&quot;
        ///    }
        ///  ]
        ///}.
        /// </summary>
        internal static string UpdateConcept_Request {
            get {
                return ResourceManager.GetString("UpdateConcept_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;data&quot;: {
        ///    &quot;id&quot;: 2,
        ///    &quot;userId&quot;: 6,
        ///    &quot;glossaryId&quot;: 6,
        ///    &quot;subject&quot;: &quot;general&quot;,
        ///    &quot;definition&quot;: &quot;Some definition&quot;,
        ///    &quot;note&quot;: &quot;Any kind of note, such as a usage note, explanation, or instruction&quot;,
        ///    &quot;url&quot;: &quot;Base URL&quot;,
        ///    &quot;figure&quot;: &quot;Figure URL&quot;,
        ///    &quot;languagesDetails&quot;: [
        ///      {
        ///        &quot;languageId&quot;: &quot;en&quot;,
        ///        &quot;userId&quot;: 12,
        ///        &quot;definition&quot;: &quot;Some definition&quot;,
        ///        &quot;note&quot;: &quot;Some note&quot;,
        ///        &quot;createdAt&quot;: &quot;2019-09-19T14:14:00+00:00&quot;,
        ///        &quot;updatedAt&quot;: &quot;2019-09 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string UpdateConcept_Response {
            get {
                return ResourceManager.GetString("UpdateConcept_Response", resourceCulture);
            }
        }
    }
}
