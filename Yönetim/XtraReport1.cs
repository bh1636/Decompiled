// Decompiled with JetBrains decompiler
// Type: Yönetim.XtraReport1
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.XtraReports.UI;
using System.ComponentModel;

#nullable disable
namespace Yönetim
{
  public class XtraReport1 : XtraReport
  {
    private IContainer components = (IContainer) null;
    private DetailBand Detail;
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;

    public XtraReport1() => this.InitializeComponent();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.Detail = new DetailBand();
      this.TopMargin = new TopMarginBand();
      this.BottomMargin = new BottomMarginBand();
      this.BeginInit();
      this.TopMargin.Height = 100;
      this.BottomMargin.Height = 100;
      this.Bands.AddRange(new Band[3]
      {
        (Band) this.Detail,
        (Band) this.TopMargin,
        (Band) this.BottomMargin
      });
      this.EndInit();
    }
  }
}
