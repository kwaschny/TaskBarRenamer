﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskBarRenamer.Languages {
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
    internal class Language {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Language() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TaskBarRenamer.Languages.Language", typeof(Language).Assembly);
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
        ///   Looks up a localized string similar to Currently there are renamed windows with forced names. If you close this program, the renamed windows names will be no longer forced. Are you sure that you want to quit?.
        /// </summary>
        internal static string ClosingPrompt {
            get {
                return ResourceManager.GetString("ClosingPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If this option is enabled, the &quot;Automatic Rename&quot; feature does only work as long as the program is not minimized. Are you sure that you want to enable this option?.
        /// </summary>
        internal static string ForegroundOnly {
            get {
                return ResourceManager.GetString("ForegroundOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type in the new name of the window:.
        /// </summary>
        internal static string InputNewName {
            get {
                return ResourceManager.GetString("InputNewName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The regular expression is invalid..
        /// </summary>
        internal static string InvalidRegExp {
            get {
                return ResourceManager.GetString("InvalidRegExp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The wildcard pattern is invalid..
        /// </summary>
        internal static string InvalidWildcard {
            get {
                return ResourceManager.GetString("InvalidWildcard", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The name must not contain any semicolon..
        /// </summary>
        internal static string NotContainSemicolon {
            get {
                return ResourceManager.GetString("NotContainSemicolon", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \1 - \9 to backreference captures.
        /// </summary>
        internal static string RegExpHint {
            get {
                return ResourceManager.GetString("RegExpHint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Search....
        /// </summary>
        internal static string Search {
            get {
                return ResourceManager.GetString("Search", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occurred while trying to open the website. Your default web browser might not be set. Try to open the website manually with the following link:.
        /// </summary>
        internal static string WebsiteError {
            get {
                return ResourceManager.GetString("WebsiteError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ? = any single character, * = any number of characters.
        /// </summary>
        internal static string WildcardHint {
            get {
                return ResourceManager.GetString("WildcardHint", resourceCulture);
            }
        }
    }
}
