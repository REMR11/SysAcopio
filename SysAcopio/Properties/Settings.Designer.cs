﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SysAcopio.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("workstation id=DbAcopioDeRL.mssql.somee.com;packet size=4096;user id=AMGC_SQLLogi" +
            "n_1;pwd=zbal1ojrif;data source=DbAcopioDeRL.mssql.somee.com;persist security inf" +
            "o=False;initial catalog=DbAcopioDeRL;TrustServerCertificate=True")]
        public string ConnectionStringDeRL {
            get {
                return ((string)(this["ConnectionStringDeRL"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AcopioDeRL;Integrated Security" +
            "=True")]
        public string ConnectionLocalString {
            get {
                return ((string)(this["ConnectionLocalString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DbAcopioDeRL.mssql.somee.com;Initial Catalog=DbAcopioDeRL;User ID=AMG" +
            "C_SQLLogin_1;Password=zbal1ojrif;TrustServerCertificate=True")]
        public string DbAcopioDeRLConnectionString {
            get {
                return ((string)(this["DbAcopioDeRLConnectionString"]));
            }
        }
    }
}
