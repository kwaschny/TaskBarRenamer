namespace TaskBarRenamer.Languages {
    using System;
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Language {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Language() {
        }
        
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
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string ClosingPrompt {
            get {
                return ResourceManager.GetString("ClosingPrompt", resourceCulture);
            }
        }
        
        internal static string ForegroundOnly {
            get {
                return ResourceManager.GetString("ForegroundOnly", resourceCulture);
            }
        }
        
        internal static string InputNewName {
            get {
                return ResourceManager.GetString("InputNewName", resourceCulture);
            }
        }
        
        internal static string NewUpdate {
            get {
                return ResourceManager.GetString("NewUpdate", resourceCulture);
            }
        }

        internal static string NotContainSemicolon {
            get {
                return ResourceManager.GetString("NotContainSemicolon", resourceCulture);
            }
        }
        
        internal static string NoUpdate {
            get {
                return ResourceManager.GetString("NoUpdate", resourceCulture);
            }
        }
        
        internal static string Search {
            get {
                return ResourceManager.GetString("Search", resourceCulture);
            }
        }
        
        internal static string UpdateRunning {
            get {
                return ResourceManager.GetString("UpdateRunning", resourceCulture);
            }
        }
        
        internal static string WebsiteError {
            get {
                return ResourceManager.GetString("WebsiteError", resourceCulture);
            }
        }
    }
}
