// Decompiled with JetBrains decompiler
// Type: Fuar.Properties.Settings
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#nullable disable
namespace Fuar.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default => Settings.defaultInstance;

    [ApplicationScopedSetting]
    [SpecialSetting(SpecialSetting.ConnectionString)]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Data Source=.;Initial Catalog=FUARDB;Persist Security Info=True;User ID=sa;Password=951623")]
    public string FUARDBConnectionString => (string) this[nameof (FUARDBConnectionString)];
  }
}
