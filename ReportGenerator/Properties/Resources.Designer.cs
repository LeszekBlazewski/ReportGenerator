﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReportGenerator.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ReportGenerator.Properties.Resources", typeof(Resources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Client_Id,Request_id,Name,Quantity,Price
        ///1,1,Bułka,1,10.00
        ///1,2,Chleb,2,15.00
        ///1,2,Chleb,5,15.00
        ///2,1,Chleb,1,10.00.
        /// </summary>
        public static string CorrectCsvData {
            get {
                return ResourceManager.GetString("CorrectCsvData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;requests&gt;
        ///  &lt;request&gt;
        ///    &lt;clientId&gt;1&lt;/clientId&gt;
        ///    &lt;requestId&gt;1&lt;/requestId&gt;
        ///    &lt;name&gt;Bułka&lt;/name&gt;
        ///    &lt;quantity&gt;1&lt;/quantity&gt;
        ///    &lt;price&gt;10.00&lt;/price&gt;
        ///  &lt;/request&gt;
        ///  &lt;request&gt;
        ///    &lt;clientId&gt;1&lt;/clientId&gt;
        ///    &lt;requestId&gt;2&lt;/requestId&gt;
        ///    &lt;name&gt;Chleb&lt;/name&gt;
        ///    &lt;quantity&gt;2&lt;/quantity&gt;
        ///    &lt;price&gt;15.00&lt;/price&gt;
        ///  &lt;/request&gt;
        ///&lt;/requests&gt;.
        /// </summary>
        public static string CorrectXmlData {
            get {
                return ResourceManager.GetString("CorrectXmlData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;$schema&quot;: &quot;http://json-schema.org/draft-04/schema&quot;,
        ///  &quot;title&quot;: &quot;JSON Schema for Request based on basic schema&quot;,
        ///  &quot;description&quot;: &quot;Schema used to validate orders stored in json file&quot;,
        ///
        ///  &quot;type&quot;: &quot;object&quot;,
        ///  &quot;properties&quot;: {
        ///
        ///    &quot;clientId&quot;: {
        ///      &quot;type&quot;: &quot;string&quot;,
        ///      &quot;maxLength&quot;: 6,
        ///      &quot;pattern&quot;: &quot;^[\\p{L}0-9]*$&quot;
        ///    },
        ///
        ///    &quot;requestId&quot;: {
        ///      &quot;type&quot;: &quot;number&quot;
        ///    },
        ///
        ///    &quot;name&quot;: {
        ///      &quot;type&quot;: &quot;string&quot;,
        ///      &quot;maxLength&quot;: 255,
        ///      &quot;pattern&quot;: &quot;^[\\p{L}0-9 ]*$&quot;
        ///    },
        ///        /// [rest of string was truncated]&quot;;.
        /// </summary>
        public static string json_OrderSchema {
            get {
                return ResourceManager.GetString("json_OrderSchema", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///  &lt;xs:element name=&quot;requests&quot;&gt;
        ///    &lt;xs:complexType&gt;
        ///      &lt;xs:sequence&gt;
        ///        &lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;request&quot;&gt;
        ///          &lt;xs:complexType&gt;
        ///            &lt;xs:sequence&gt;
        ///              &lt;xs:element name=&quot;clientId&quot;&gt;
        ///                &lt;xs:simpleType&gt;
        ///                  &lt;xs:restriction base =&quot;xs:string&quot;&gt;
        ///                    &lt;xs:maxLe [rest of string was truncated]&quot;;.
        /// </summary>
        public static string xml_Schema {
            get {
                return ResourceManager.GetString("xml_Schema", resourceCulture);
            }
        }
    }
}
