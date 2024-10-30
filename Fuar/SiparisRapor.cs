// Decompiled with JetBrains decompiler
// Type: Fuar.SiparisRapor
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Shape;
using DevExpress.XtraReports.UI;
using Fuar.siparisTableAdapters;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;

#nullable disable
namespace Fuar
{
  public class SiparisRapor : XtraReport
  {
    private IContainer components;
    private DetailBand Detail;
    private XRLabel xrLabel24;
    private XRLabel xrLabel15;
    private XRLabel xrLabel13;
    private XRLabel xrLabel16;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRControlStyle Title;
    private XRLabel xrLabel21;
    private XRLabel xrLabel4;
    private PageFooterBand pageFooterBand1;
    private XRLabel xrLabel5;
    private XRLabel xrLabel3;
    private CalculatedField cf1;
    private ReportFooterBand ReportFooter;
    private XRLine xrLine3;
    private XRLabel xrLabel29;
    private XRLine xrLine2;
    private XRLabel xrLabel30;
    private XRLabel xrLabel27;
    private XRLine xrLine1;
    private XRLabel xrLabel26;
    private XRLabel xrLabel25;
    private XRLabel xrLabel17;
    private XRLabel xrLabel6;
    private XRShape xrShape2;
    private XRLabel xrLabel22;
    private XRLabel xrLabel20;
    private XRLabel xrLabel9;
    private PageHeaderBand pageHeaderBand1;
    private XRPictureBox xrPictureBox2;
    private XRLabel xrLabel14;
    private XRLabel xrLabel23;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRLabel xrLabel28;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel32;
    private XRLabel xrLabel33;
    private XRLabel xrLabel31;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private BottomMarginBand bottomMarginBand1;
    private FormattingRule formattingRule1;
    private XRControlStyle FieldCaption;
    private GroupHeaderBand groupHeaderBand1;
    private TopMarginBand topMarginBand1;
    private siparis siparis1;
    private SIPARISLERAdapter sIPARISLERAdapter;
    private XRLabel xrLabel35;
    private XRLine xrLine4;
    private XRLabel xrLabel34;
    private XRPageInfo xrPageInfo2;
    private XRPictureBox xrPictureBox1;
    private XRLabel xrLabel54;
    private XRShape xrShape1;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrLabel38;
    private XRLabel xrLabel36;
    private XRLabel xrLabel39;
    private XRLabel xrLabel37;
    private SIPARISLERAdapter sıparıslerAdapter1;
    private XRLabel xrLabel41;
    private XRLabel xrLabel40;

    public SiparisRapor() => this.InitializeComponent();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      XRSummary xrSummary1 = new XRSummary();
      XRSummary xrSummary2 = new XRSummary();
      XRSummary xrSummary3 = new XRSummary();
      XRSummary xrSummary4 = new XRSummary();
      XRSummary xrSummary5 = new XRSummary();
      XRSummary xrSummary6 = new XRSummary();
      ShapeRectangle shapeRectangle1 = new ShapeRectangle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (SiparisRapor));
      ShapeRectangle shapeRectangle2 = new ShapeRectangle();
      this.Detail = new DetailBand();
      this.xrLabel41 = new XRLabel();
      this.xrLabel24 = new XRLabel();
      this.xrLabel15 = new XRLabel();
      this.xrLabel13 = new XRLabel();
      this.xrLabel16 = new XRLabel();
      this.xrLabel12 = new XRLabel();
      this.xrLabel11 = new XRLabel();
      this.xrLabel10 = new XRLabel();
      this.Title = new XRControlStyle();
      this.xrLabel21 = new XRLabel();
      this.xrLabel4 = new XRLabel();
      this.pageFooterBand1 = new PageFooterBand();
      this.xrLabel35 = new XRLabel();
      this.xrLine4 = new XRLine();
      this.xrLabel34 = new XRLabel();
      this.xrLabel5 = new XRLabel();
      this.xrLabel3 = new XRLabel();
      this.cf1 = new CalculatedField();
      this.ReportFooter = new ReportFooterBand();
      this.xrLabel39 = new XRLabel();
      this.xrLabel37 = new XRLabel();
      this.xrLabel38 = new XRLabel();
      this.xrLabel36 = new XRLabel();
      this.xrLine3 = new XRLine();
      this.xrLabel29 = new XRLabel();
      this.xrLine2 = new XRLine();
      this.xrLabel30 = new XRLabel();
      this.xrLabel27 = new XRLabel();
      this.xrLine1 = new XRLine();
      this.xrLabel26 = new XRLabel();
      this.xrLabel25 = new XRLabel();
      this.xrLabel17 = new XRLabel();
      this.siparis1 = new siparis();
      this.xrLabel6 = new XRLabel();
      this.xrShape2 = new XRShape();
      this.xrLabel22 = new XRLabel();
      this.xrLabel20 = new XRLabel();
      this.xrLabel9 = new XRLabel();
      this.pageHeaderBand1 = new PageHeaderBand();
      this.xrLabel40 = new XRLabel();
      this.xrPageInfo2 = new XRPageInfo();
      this.xrPictureBox1 = new XRPictureBox();
      this.xrLabel54 = new XRLabel();
      this.xrShape1 = new XRShape();
      this.xrPageInfo1 = new XRPageInfo();
      this.xrPictureBox2 = new XRPictureBox();
      this.xrLabel14 = new XRLabel();
      this.xrLabel23 = new XRLabel();
      this.xrLabel8 = new XRLabel();
      this.xrLabel7 = new XRLabel();
      this.xrLabel2 = new XRLabel();
      this.xrLabel1 = new XRLabel();
      this.xrLabel28 = new XRLabel();
      this.xrLabel18 = new XRLabel();
      this.xrLabel19 = new XRLabel();
      this.xrLabel32 = new XRLabel();
      this.xrLabel33 = new XRLabel();
      this.xrLabel31 = new XRLabel();
      this.PageInfo = new XRControlStyle();
      this.DataField = new XRControlStyle();
      this.bottomMarginBand1 = new BottomMarginBand();
      this.formattingRule1 = new FormattingRule();
      this.FieldCaption = new XRControlStyle();
      this.groupHeaderBand1 = new GroupHeaderBand();
      this.topMarginBand1 = new TopMarginBand();
      this.sIPARISLERAdapter = new SIPARISLERAdapter();
      this.sıparıslerAdapter1 = new SIPARISLERAdapter();
      this.siparis1.BeginInit();
      this.BeginInit();
      this.Detail.Controls.AddRange(new XRControl[8]
      {
        (XRControl) this.xrLabel41,
        (XRControl) this.xrLabel24,
        (XRControl) this.xrLabel15,
        (XRControl) this.xrLabel13,
        (XRControl) this.xrLabel16,
        (XRControl) this.xrLabel12,
        (XRControl) this.xrLabel11,
        (XRControl) this.xrLabel10
      });
      this.Detail.Dpi = 254f;
      this.Detail.HeightF = 58.42001f;
      this.Detail.Name = "Detail";
      this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 254f);
      this.Detail.StyleName = "DataField";
      this.Detail.TextAlignment = TextAlignment.TopLeft;
      this.xrLabel41.CanGrow = false;
      this.xrLabel41.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.BIRIMFIYAT")
      });
      this.xrLabel41.Dpi = 254f;
      this.xrLabel41.Font = new Font("Times New Roman", 9f);
      this.xrLabel41.LocationFloat = new PointFloat(1292.324f, 0.0f);
      this.xrLabel41.Name = "xrLabel41";
      this.xrLabel41.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel41.SizeF = new SizeF(210.5093f, 58.42f);
      this.xrLabel41.StylePriority.UseFont = false;
      this.xrLabel41.StylePriority.UseTextAlignment = false;
      this.xrLabel41.Text = "xrLabel12";
      this.xrLabel41.TextAlignment = TextAlignment.TopRight;
      this.xrLabel41.WordWrap = false;
      this.xrLabel24.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.MALZEME KODU")
      });
      this.xrLabel24.Dpi = 254f;
      this.xrLabel24.LocationFloat = new PointFloat(13.22917f, 0.0f);
      this.xrLabel24.Name = "xrLabel24";
      this.xrLabel24.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel24.SizeF = new SizeF(278.7708f, 58.42f);
      this.xrLabel24.Text = "xrLabel24";
      this.xrLabel15.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.URETICIKODU")
      });
      this.xrLabel15.Dpi = 254f;
      this.xrLabel15.LocationFloat = new PointFloat(915.605f, 0.0f);
      this.xrLabel15.Name = "xrLabel15";
      this.xrLabel15.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel15.SizeF = new SizeF(194.532f, 58.42001f);
      this.xrLabel15.Text = "xrLabel15";
      this.xrLabel13.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.TUTAR", "{0:c2}")
      });
      this.xrLabel13.Dpi = 254f;
      this.xrLabel13.LocationFloat = new PointFloat(1740f, 0.0f);
      this.xrLabel13.Name = "xrLabel13";
      this.xrLabel13.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel13.SizeF = new SizeF(254f, 58.42f);
      this.xrLabel13.StylePriority.UseTextAlignment = false;
      this.xrLabel13.Text = "[TUTAR]";
      this.xrLabel13.TextAlignment = TextAlignment.TopRight;
      this.xrLabel16.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.BIRIM")
      });
      this.xrLabel16.Dpi = 254f;
      this.xrLabel16.Font = new Font("Times New Roman", 9f);
      this.xrLabel16.LocationFloat = new PointFloat(1615.646f, 0.0f);
      this.xrLabel16.Name = "xrLabel16";
      this.xrLabel16.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel16.SizeF = new SizeF(124.3542f, 58.42f);
      this.xrLabel16.StylePriority.UseFont = false;
      this.xrLabel16.Text = "xrLabel16";
      this.xrLabel12.CanGrow = false;
      this.xrLabel12.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.MIKTAR")
      });
      this.xrLabel12.Dpi = 254f;
      this.xrLabel12.Font = new Font("Times New Roman", 9f);
      this.xrLabel12.LocationFloat = new PointFloat(1502.833f, 0.0f);
      this.xrLabel12.Name = "xrLabel12";
      this.xrLabel12.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel12.SizeF = new SizeF(112.8126f, 58.42f);
      this.xrLabel12.StylePriority.UseFont = false;
      this.xrLabel12.StylePriority.UseTextAlignment = false;
      this.xrLabel12.Text = "xrLabel12";
      this.xrLabel12.TextAlignment = TextAlignment.TopRight;
      this.xrLabel12.WordWrap = false;
      this.xrLabel11.CanGrow = false;
      this.xrLabel11.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.MARKA")
      });
      this.xrLabel11.Dpi = 254f;
      this.xrLabel11.Font = new Font("Times New Roman", 9f);
      this.xrLabel11.LocationFloat = new PointFloat(1110.138f, 0.0f);
      this.xrLabel11.Name = "xrLabel11";
      this.xrLabel11.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel11.SizeF = new SizeF(182.1857f, 58.42f);
      this.xrLabel11.StylePriority.UseFont = false;
      this.xrLabel11.Text = "xrLabel11";
      this.xrLabel11.WordWrap = false;
      this.xrLabel10.CanGrow = false;
      this.xrLabel10.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.MALZEME ADI")
      });
      this.xrLabel10.Dpi = 254f;
      this.xrLabel10.Font = new Font("Times New Roman", 9f);
      this.xrLabel10.LocationFloat = new PointFloat(292f, 0.0f);
      this.xrLabel10.Name = "xrLabel10";
      this.xrLabel10.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel10.SizeF = new SizeF(623.605f, 58.42f);
      this.xrLabel10.StylePriority.UseFont = false;
      this.xrLabel10.Text = "xrLabel10";
      this.xrLabel10.WordWrap = false;
      this.Title.BackColor = Color.White;
      this.Title.BorderColor = SystemColors.ControlText;
      this.Title.Borders = BorderSide.None;
      this.Title.BorderWidth = 1;
      this.Title.Font = new Font("Times New Roman", 20f, FontStyle.Bold);
      this.Title.ForeColor = Color.Maroon;
      this.Title.Name = "Title";
      this.xrLabel21.Dpi = 254f;
      this.xrLabel21.Font = new Font("Times New Roman", 9.75f, FontStyle.Underline);
      this.xrLabel21.LocationFloat = new PointFloat(1615.646f, 420.5318f);
      this.xrLabel21.Name = "xrLabel21";
      this.xrLabel21.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel21.SizeF = new SizeF(124.3542f, 58.42f);
      this.xrLabel21.StylePriority.UseFont = false;
      this.xrLabel21.StylePriority.UseTextAlignment = false;
      this.xrLabel21.Text = "Birim";
      this.xrLabel4.Dpi = 254f;
      this.xrLabel4.LocationFloat = new PointFloat(64.4584f, 268.2675f);
      this.xrLabel4.Name = "xrLabel4";
      this.xrLabel4.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel4.SizeF = new SizeF(227.5416f, 58.42001f);
      this.xrLabel4.Text = "Sipariş Tarihi :";
      this.pageFooterBand1.Controls.AddRange(new XRControl[3]
      {
        (XRControl) this.xrLabel35,
        (XRControl) this.xrLine4,
        (XRControl) this.xrLabel34
      });
      this.pageFooterBand1.Dpi = 254f;
      this.pageFooterBand1.HeightF = 105.75f;
      this.pageFooterBand1.Name = "pageFooterBand1";
      this.pageFooterBand1.PrintOn = PrintOnPages.NotWithReportFooter;
      this.xrLabel35.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.TUTAR")
      });
      this.xrLabel35.Dpi = 254f;
      this.xrLabel35.LocationFloat = new PointFloat(1740f, 635f / 16f);
      this.xrLabel35.Name = "xrLabel35";
      this.xrLabel35.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel35.SizeF = new SizeF(253.9995f, 58.41999f);
      this.xrLabel35.StylePriority.UseTextAlignment = false;
      xrSummary1.FormatString = "{0:c2}";
      xrSummary1.IgnoreNullValues = true;
      xrSummary1.Running = SummaryRunning.Page;
      this.xrLabel35.Summary = xrSummary1;
      this.xrLabel35.Text = "xrLabel30";
      this.xrLabel35.TextAlignment = TextAlignment.TopRight;
      this.xrLine4.Dpi = 254f;
      this.xrLine4.LineWidth = 3;
      this.xrLine4.LocationFloat = new PointFloat(1218.772f, (float) sbyte.MaxValue / 16f);
      this.xrLine4.Name = "xrLine4";
      this.xrLine4.SizeF = new SizeF(783.3519f, 22.68749f);
      this.xrLabel34.Dpi = 254f;
      this.xrLabel34.LocationFloat = new PointFloat(1409.272f, 635f / 16f);
      this.xrLabel34.Name = "xrLabel34";
      this.xrLabel34.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel34.SizeF = new SizeF(330.7286f, 58.41999f);
      this.xrLabel34.Text = "Sayfa Toplamı :";
      this.xrLabel5.Dpi = 254f;
      this.xrLabel5.LocationFloat = new PointFloat(64.45844f, 5227f / 16f);
      this.xrLabel5.Name = "xrLabel5";
      this.xrLabel5.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel5.SizeF = new SizeF(227.5416f, 58.42001f);
      this.xrLabel5.Text = "Sipariş Saati :";
      this.xrLabel3.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.FIRMAADI")
      });
      this.xrLabel3.Dpi = 254f;
      this.xrLabel3.LocationFloat = new PointFloat(753.75f, 204.7675f);
      this.xrLabel3.Name = "xrLabel3";
      this.xrLabel3.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel3.SizeF = new SizeF(866.2458f, 58.42001f);
      this.xrLabel3.Text = "xrLabel3";
      this.cf1.DataMember = "SIPARISLER";
      this.cf1.Expression = "Iif([SATIRTURU]  == 'Promosyon',[BIRIMFIYAT],0)\r\n";
      this.cf1.Name = "cf1";
      this.ReportFooter.Controls.AddRange(new XRControl[13]
      {
        (XRControl) this.xrLabel39,
        (XRControl) this.xrLabel37,
        (XRControl) this.xrLabel38,
        (XRControl) this.xrLabel36,
        (XRControl) this.xrLine3,
        (XRControl) this.xrLabel29,
        (XRControl) this.xrLine2,
        (XRControl) this.xrLabel30,
        (XRControl) this.xrLabel27,
        (XRControl) this.xrLine1,
        (XRControl) this.xrLabel26,
        (XRControl) this.xrLabel25,
        (XRControl) this.xrLabel17
      });
      this.ReportFooter.Dpi = 254f;
      this.ReportFooter.HeightF = 414.4794f;
      this.ReportFooter.Name = "ReportFooter";
      this.xrLabel39.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.NETTOPLAM")
      });
      this.xrLabel39.Dpi = 254f;
      this.xrLabel39.LocationFloat = new PointFloat(1740f, 352.1075f);
      this.xrLabel39.Name = "xrLabel39";
      this.xrLabel39.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel39.SizeF = new SizeF(254f, 58.42f);
      this.xrLabel39.StylePriority.UseTextAlignment = false;
      xrSummary2.FormatString = "{0:c2}";
      xrSummary2.IgnoreNullValues = true;
      xrSummary2.Running = SummaryRunning.Report;
      this.xrLabel39.Summary = xrSummary2;
      this.xrLabel39.Text = "xrLabel39";
      this.xrLabel39.TextAlignment = TextAlignment.TopRight;
      this.xrLabel37.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.KDVTUTARI")
      });
      this.xrLabel37.Dpi = 254f;
      this.xrLabel37.LocationFloat = new PointFloat(1740f, 264.5833f);
      this.xrLabel37.Name = "xrLabel37";
      this.xrLabel37.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel37.SizeF = new SizeF(254f, 58.42f);
      this.xrLabel37.StylePriority.UseTextAlignment = false;
      xrSummary3.FormatString = "{0:c2}";
      xrSummary3.IgnoreNullValues = true;
      xrSummary3.Running = SummaryRunning.Report;
      this.xrLabel37.Summary = xrSummary3;
      this.xrLabel37.Text = "xrLabel37";
      this.xrLabel37.TextAlignment = TextAlignment.TopRight;
      this.xrLabel38.Dpi = 254f;
      this.xrLabel38.LocationFloat = new PointFloat(1409.271f, 352.1075f);
      this.xrLabel38.Name = "xrLabel38";
      this.xrLabel38.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel38.SizeF = new SizeF(330.7291f, 58.41998f);
      this.xrLabel38.Text = "Net Toplam :";
      this.xrLabel36.Dpi = 254f;
      this.xrLabel36.LocationFloat = new PointFloat(1409.271f, 264.5833f);
      this.xrLabel36.Name = "xrLabel36";
      this.xrLabel36.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel36.SizeF = new SizeF(330.7291f, 58.41998f);
      this.xrLabel36.Text = "Kdv Toplamı :";
      this.xrLine3.BorderDashStyle = BorderDashStyle.Double;
      this.xrLine3.Dpi = 254f;
      this.xrLine3.LineWidth = 3;
      this.xrLine3.LocationFloat = new PointFloat(1409.271f, 323.0033f);
      this.xrLine3.Name = "xrLine3";
      this.xrLine3.SizeF = new SizeF(584.7281f, 29.10417f);
      this.xrLine3.StylePriority.UseBorderDashStyle = false;
      this.xrLabel29.Dpi = 254f;
      this.xrLabel29.LocationFloat = new PointFloat(1409.271f, 189.1427f);
      this.xrLabel29.Name = "xrLabel29";
      this.xrLabel29.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel29.SizeF = new SizeF(330.7291f, 58.41998f);
      this.xrLabel29.Text = "Kdv'siz Toplam :";
      this.xrLine2.BorderDashStyle = BorderDashStyle.Double;
      this.xrLine2.Dpi = 254f;
      this.xrLine2.LineWidth = 3;
      this.xrLine2.LocationFloat = new PointFloat(1409.271f, 154.0386f);
      this.xrLine2.Name = "xrLine2";
      this.xrLine2.SizeF = new SizeF(584.7281f, 29.10416f);
      this.xrLine2.StylePriority.UseBorderDashStyle = false;
      this.xrLabel30.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.TUTAR")
      });
      this.xrLabel30.Dpi = 254f;
      this.xrLabel30.LocationFloat = new PointFloat(1740f, 24.99993f);
      this.xrLabel30.Name = "xrLabel30";
      this.xrLabel30.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel30.SizeF = new SizeF(253.9995f, 58.41999f);
      this.xrLabel30.StylePriority.UseTextAlignment = false;
      xrSummary4.FormatString = "{0:c2}";
      xrSummary4.IgnoreNullValues = true;
      xrSummary4.Running = SummaryRunning.Report;
      this.xrLabel30.Summary = xrSummary4;
      this.xrLabel30.Text = "xrLabel30";
      this.xrLabel30.TextAlignment = TextAlignment.TopRight;
      this.xrLabel27.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.INDIRIMTUTARI")
      });
      this.xrLabel27.Dpi = 254f;
      this.xrLabel27.LocationFloat = new PointFloat(1740f, 95.61852f);
      this.xrLabel27.Name = "xrLabel27";
      this.xrLabel27.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel27.SizeF = new SizeF(253.9995f, 58.42001f);
      this.xrLabel27.StylePriority.UseTextAlignment = false;
      xrSummary5.FormatString = "{0:c2}";
      xrSummary5.IgnoreNullValues = true;
      xrSummary5.Running = SummaryRunning.Report;
      this.xrLabel27.Summary = xrSummary5;
      this.xrLabel27.Text = "xrLabel27";
      this.xrLabel27.TextAlignment = TextAlignment.TopRight;
      this.xrLine1.Dpi = 254f;
      this.xrLine1.LineWidth = 3;
      this.xrLine1.LocationFloat = new PointFloat(1218.648f, 0.0f);
      this.xrLine1.Name = "xrLine1";
      this.xrLine1.SizeF = new SizeF(783.3519f, 22.68749f);
      this.xrLabel26.Dpi = 254f;
      this.xrLabel26.LocationFloat = new PointFloat(1409.271f, 95.61852f);
      this.xrLabel26.Name = "xrLabel26";
      this.xrLabel26.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel26.SizeF = new SizeF(330.7286f, 58.42001f);
      this.xrLabel26.Text = "İndirimler Toplamı :";
      this.xrLabel25.Dpi = 254f;
      this.xrLabel25.LocationFloat = new PointFloat(1409.271f, 24.99993f);
      this.xrLabel25.Name = "xrLabel25";
      this.xrLabel25.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel25.SizeF = new SizeF(330.7286f, 58.41999f);
      this.xrLabel25.Text = "Toplam :";
      this.xrLabel17.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.NETTUTAR")
      });
      this.xrLabel17.Dpi = 254f;
      this.xrLabel17.Font = new Font("Times New Roman", 9.75f);
      this.xrLabel17.LocationFloat = new PointFloat(1740f, 189.1427f);
      this.xrLabel17.Name = "xrLabel17";
      this.xrLabel17.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel17.SizeF = new SizeF(254f, 58.41999f);
      this.xrLabel17.StylePriority.UseFont = false;
      this.xrLabel17.StylePriority.UseTextAlignment = false;
      xrSummary6.FormatString = "{0:c2}";
      xrSummary6.IgnoreNullValues = true;
      xrSummary6.Running = SummaryRunning.Report;
      this.xrLabel17.Summary = xrSummary6;
      this.xrLabel17.Text = "xrLabel17";
      this.xrLabel17.TextAlignment = TextAlignment.TopRight;
      this.siparis1.DataSetName = "siparis";
      this.siparis1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.xrLabel6.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.SIPARISTARIHI", "{0:dd.MM.yyyy}")
      });
      this.xrLabel6.Dpi = 254f;
      this.xrLabel6.LocationFloat = new PointFloat(292f, 268.2675f);
      this.xrLabel6.Name = "xrLabel6";
      this.xrLabel6.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel6.SizeF = new SizeF(2921f / 16f, 58.42f);
      this.xrLabel6.Text = "xrLabel6";
      this.xrShape2.Dpi = 254f;
      this.xrShape2.LocationFloat = new PointFloat(17.00021f, 190.0175f);
      this.xrShape2.Name = "xrShape2";
      this.xrShape2.Shape = (ShapeBase) shapeRectangle1;
      this.xrShape2.SizeF = new SizeF(1977f, 219.5143f);
      this.xrLabel22.Dpi = 254f;
      this.xrLabel22.Font = new Font("Times New Roman", 9.75f, FontStyle.Underline);
      this.xrLabel22.LocationFloat = new PointFloat(1740f, 420.5319f);
      this.xrLabel22.Name = "xrLabel22";
      this.xrLabel22.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel22.SizeF = new SizeF(254f, 58.42001f);
      this.xrLabel22.StylePriority.UseFont = false;
      this.xrLabel22.StylePriority.UseTextAlignment = false;
      this.xrLabel22.Text = "Tutar";
      this.xrLabel22.TextAlignment = TextAlignment.TopCenter;
      this.xrLabel20.Dpi = 254f;
      this.xrLabel20.Font = new Font("Times New Roman", 9.75f, FontStyle.Underline);
      this.xrLabel20.LocationFloat = new PointFloat(1502.833f, 420.5318f);
      this.xrLabel20.Name = "xrLabel20";
      this.xrLabel20.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel20.SizeF = new SizeF(112.8126f, 58.42f);
      this.xrLabel20.StylePriority.UseFont = false;
      this.xrLabel20.StylePriority.UseTextAlignment = false;
      this.xrLabel20.Text = "Miktar";
      this.xrLabel9.Dpi = 254f;
      this.xrLabel9.LocationFloat = new PointFloat(528.2501f, 268.2675f);
      this.xrLabel9.Name = "xrLabel9";
      this.xrLabel9.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel9.SizeF = new SizeF(225.4999f, 58.42001f);
      this.xrLabel9.Text = "Tedarikçi Adı :";
      this.pageHeaderBand1.Controls.AddRange(new XRControl[28]
      {
        (XRControl) this.xrLabel40,
        (XRControl) this.xrPageInfo2,
        (XRControl) this.xrPictureBox1,
        (XRControl) this.xrLabel54,
        (XRControl) this.xrShape1,
        (XRControl) this.xrPageInfo1,
        (XRControl) this.xrPictureBox2,
        (XRControl) this.xrLabel14,
        (XRControl) this.xrLabel23,
        (XRControl) this.xrLabel9,
        (XRControl) this.xrLabel8,
        (XRControl) this.xrLabel7,
        (XRControl) this.xrLabel6,
        (XRControl) this.xrLabel5,
        (XRControl) this.xrLabel4,
        (XRControl) this.xrLabel3,
        (XRControl) this.xrLabel2,
        (XRControl) this.xrLabel1,
        (XRControl) this.xrLabel28,
        (XRControl) this.xrLabel18,
        (XRControl) this.xrLabel19,
        (XRControl) this.xrLabel20,
        (XRControl) this.xrLabel21,
        (XRControl) this.xrLabel22,
        (XRControl) this.xrLabel32,
        (XRControl) this.xrShape2,
        (XRControl) this.xrLabel33,
        (XRControl) this.xrLabel31
      });
      this.pageHeaderBand1.Dpi = 254f;
      this.pageHeaderBand1.HeightF = 478.9519f;
      this.pageHeaderBand1.Name = "pageHeaderBand1";
      this.xrLabel40.Dpi = 254f;
      this.xrLabel40.Font = new Font("Times New Roman", 9.75f, FontStyle.Underline);
      this.xrLabel40.LocationFloat = new PointFloat(1292.324f, 420.5317f);
      this.xrLabel40.Name = "xrLabel40";
      this.xrLabel40.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel40.SizeF = new SizeF(210.5093f, 58.41998f);
      this.xrLabel40.StylePriority.UseFont = false;
      this.xrLabel40.StylePriority.UseTextAlignment = false;
      this.xrLabel40.Text = "Birim Fiyat";
      this.xrLabel40.TextAlignment = TextAlignment.TopRight;
      this.xrPageInfo2.Dpi = 254f;
      this.xrPageInfo2.Format = "Sayfa {0} / {1}";
      this.xrPageInfo2.LocationFloat = new PointFloat(1634.874f, 105.8333f);
      this.xrPageInfo2.Name = "xrPageInfo2";
      this.xrPageInfo2.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrPageInfo2.SizeF = new SizeF(296.3336f, 58.42f);
      this.xrPageInfo2.StyleName = "PageInfo";
      this.xrPageInfo2.TextAlignment = TextAlignment.TopRight;
      this.xrPictureBox1.Dpi = 254f;
      this.xrPictureBox1.Image = (Image) componentResourceManager.GetObject("xrPictureBox1.Image");
      this.xrPictureBox1.LocationFloat = new PointFloat(30.00021f, 20.67003f);
      this.xrPictureBox1.Name = "xrPictureBox1";
      this.xrPictureBox1.SizeF = new SizeF(656.1666f, 137.5833f);
      this.xrPictureBox1.Sizing = ImageSizeMode.ZoomImage;
      this.xrLabel54.Dpi = 254f;
      this.xrLabel54.LocationFloat = new PointFloat(779.0002f, 38.74998f);
      this.xrLabel54.Name = "xrLabel54";
      this.xrLabel54.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel54.SizeF = new SizeF(461.6449f, 83.82001f);
      this.xrLabel54.StyleName = "Title";
      this.xrLabel54.Text = "Sipariş Formu";
      this.xrShape1.Dpi = 254f;
      this.xrShape1.LineWidth = 2;
      this.xrShape1.LocationFloat = new PointFloat(17.00021f, 0.0f);
      this.xrShape1.Name = "xrShape1";
      this.xrShape1.Shape = (ShapeBase) shapeRectangle2;
      this.xrShape1.SizeF = new SizeF(1977f, 2875f / 16f);
      this.xrPageInfo1.Dpi = 254f;
      this.xrPageInfo1.LocationFloat = new PointFloat(1509.25f, 31.74998f);
      this.xrPageInfo1.Name = "xrPageInfo1";
      this.xrPageInfo1.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
      this.xrPageInfo1.SizeF = new SizeF(421.9575f, 58.42001f);
      this.xrPageInfo1.StyleName = "PageInfo";
      this.xrPageInfo1.StylePriority.UseTextAlignment = false;
      this.xrPageInfo1.TextAlignment = TextAlignment.TopRight;
      this.xrPictureBox2.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Image", (object) null, "SIPARISLER.TEDARIKCILOGOSU")
      });
      this.xrPictureBox2.Dpi = 254f;
      this.xrPictureBox2.LocationFloat = new PointFloat(1646.353f, 204.7675f);
      this.xrPictureBox2.Name = "xrPictureBox2";
      this.xrPictureBox2.SizeF = new SizeF(296.3333f, 180.3401f);
      this.xrPictureBox2.Sizing = ImageSizeMode.ZoomImage;
      this.xrLabel14.Dpi = 254f;
      this.xrLabel14.Font = new Font("Times New Roman", 9.75f, FontStyle.Underline);
      this.xrLabel14.LocationFloat = new PointFloat(13.22915f, 420.5319f);
      this.xrLabel14.Name = "xrLabel14";
      this.xrLabel14.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel14.SizeF = new SizeF(278.7708f, 58.42001f);
      this.xrLabel14.StylePriority.UseFont = false;
      this.xrLabel14.StylePriority.UseTextAlignment = false;
      this.xrLabel14.Text = "Malzeme Kodu";
      this.xrLabel23.Dpi = 254f;
      this.xrLabel23.Font = new Font("Times New Roman", 9.75f, FontStyle.Underline);
      this.xrLabel23.LocationFloat = new PointFloat(915.605f, 420.5319f);
      this.xrLabel23.Name = "xrLabel23";
      this.xrLabel23.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel23.SizeF = new SizeF(194.533f, 58.42001f);
      this.xrLabel23.StylePriority.UseFont = false;
      this.xrLabel23.StylePriority.UseTextAlignment = false;
      this.xrLabel23.Text = "Üretici Kodu";
      this.xrLabel8.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.TEDARIKCIADI")
      });
      this.xrLabel8.Dpi = 254f;
      this.xrLabel8.LocationFloat = new PointFloat(753.75f, 268.2675f);
      this.xrLabel8.Name = "xrLabel8";
      this.xrLabel8.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel8.SizeF = new SizeF(866.2458f, 58.41999f);
      this.xrLabel8.Text = "xrLabel8";
      this.xrLabel7.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.SIPARISSAATI")
      });
      this.xrLabel7.Dpi = 254f;
      this.xrLabel7.LocationFloat = new PointFloat(292f, 5227f / 16f);
      this.xrLabel7.Name = "xrLabel7";
      this.xrLabel7.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel7.SizeF = new SizeF(2921f / 16f, 58.42f);
      this.xrLabel7.Text = "xrLabel7";
      this.xrLabel2.Dpi = 254f;
      this.xrLabel2.LocationFloat = new PointFloat(528.2501f, 204.7675f);
      this.xrLabel2.Name = "xrLabel2";
      this.xrLabel2.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel2.SizeF = new SizeF(225.4999f, 58.42001f);
      this.xrLabel2.Text = "Firma Adı :";
      this.xrLabel1.Dpi = 254f;
      this.xrLabel1.LocationFloat = new PointFloat(64.4584f, 204.7675f);
      this.xrLabel1.Name = "xrLabel1";
      this.xrLabel1.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel1.SizeF = new SizeF(227.5416f, 58.42001f);
      this.xrLabel1.Text = "Sipariş No:";
      this.xrLabel28.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.SIPARISNO")
      });
      this.xrLabel28.Dpi = 254f;
      this.xrLabel28.LocationFloat = new PointFloat(292f, 204.7675f);
      this.xrLabel28.Name = "xrLabel28";
      this.xrLabel28.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel28.SizeF = new SizeF(2921f / 16f, 58.42f);
      this.xrLabel28.Text = "xrLabel28";
      this.xrLabel18.Dpi = 254f;
      this.xrLabel18.Font = new Font("Times New Roman", 9.75f, FontStyle.Underline);
      this.xrLabel18.LocationFloat = new PointFloat(292.0002f, 420.5318f);
      this.xrLabel18.Name = "xrLabel18";
      this.xrLabel18.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel18.SizeF = new SizeF(623.6049f, 58.42001f);
      this.xrLabel18.StylePriority.UseFont = false;
      this.xrLabel18.StylePriority.UseTextAlignment = false;
      this.xrLabel18.Text = "Malzeme Adı";
      this.xrLabel19.Dpi = 254f;
      this.xrLabel19.Font = new Font("Times New Roman", 9.75f, FontStyle.Underline);
      this.xrLabel19.LocationFloat = new PointFloat(1110.138f, 420.5318f);
      this.xrLabel19.Name = "xrLabel19";
      this.xrLabel19.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel19.SizeF = new SizeF(182.1857f, 58.42001f);
      this.xrLabel19.StylePriority.UseFont = false;
      this.xrLabel19.StylePriority.UseTextAlignment = false;
      this.xrLabel19.Text = "Marka";
      this.xrLabel32.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.SOYADI")
      });
      this.xrLabel32.Dpi = 254f;
      this.xrLabel32.LocationFloat = new PointFloat(1061.096f, 5227f / 16f);
      this.xrLabel32.Name = "xrLabel32";
      this.xrLabel32.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel32.SizeF = new SizeF(558.8997f, 58.42004f);
      this.xrLabel32.Text = "xrLabel32";
      this.xrLabel33.Dpi = 254f;
      this.xrLabel33.LocationFloat = new PointFloat(528.2501f, 5227f / 16f);
      this.xrLabel33.Name = "xrLabel33";
      this.xrLabel33.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel33.SizeF = new SizeF(225.4999f, 58.42003f);
      this.xrLabel33.Text = "Siparişi Alan :";
      this.xrLabel31.DataBindings.AddRange(new XRBinding[1]
      {
        new XRBinding("Text", (object) null, "SIPARISLER.ADI")
      });
      this.xrLabel31.Dpi = 254f;
      this.xrLabel31.LocationFloat = new PointFloat(753.75f, 5227f / 16f);
      this.xrLabel31.Name = "xrLabel31";
      this.xrLabel31.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.xrLabel31.SizeF = new SizeF(307.3463f, 58.42004f);
      this.xrLabel31.Text = "xrLabel31";
      this.PageInfo.BackColor = Color.White;
      this.PageInfo.BorderColor = SystemColors.ControlText;
      this.PageInfo.Borders = BorderSide.None;
      this.PageInfo.BorderWidth = 1;
      this.PageInfo.Font = new Font("Times New Roman", 10f, FontStyle.Bold);
      this.PageInfo.ForeColor = SystemColors.ControlText;
      this.PageInfo.Name = "PageInfo";
      this.DataField.BackColor = Color.White;
      this.DataField.BorderColor = SystemColors.ControlText;
      this.DataField.Borders = BorderSide.None;
      this.DataField.BorderWidth = 1;
      this.DataField.Font = new Font("Times New Roman", 10f);
      this.DataField.ForeColor = SystemColors.ControlText;
      this.DataField.Name = "DataField";
      this.DataField.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
      this.bottomMarginBand1.Dpi = 254f;
      this.bottomMarginBand1.HeightF = 178f;
      this.bottomMarginBand1.Name = "bottomMarginBand1";
      this.formattingRule1.DataMember = "SIPARISLER";
      this.formattingRule1.Name = "formattingRule1";
      this.FieldCaption.BackColor = Color.White;
      this.FieldCaption.BorderColor = SystemColors.ControlText;
      this.FieldCaption.Borders = BorderSide.None;
      this.FieldCaption.BorderWidth = 1;
      this.FieldCaption.Font = new Font("Arial", 10f, FontStyle.Bold);
      this.FieldCaption.ForeColor = Color.Maroon;
      this.FieldCaption.Name = "FieldCaption";
      this.groupHeaderBand1.Dpi = 254f;
      this.groupHeaderBand1.GroupFields.AddRange(new GroupField[1]
      {
        new GroupField("SIPARISNO", XRColumnSortOrder.Ascending)
      });
      this.groupHeaderBand1.HeightF = 5.92002f;
      this.groupHeaderBand1.Name = "groupHeaderBand1";
      this.groupHeaderBand1.StyleName = "DataField";
      this.topMarginBand1.Dpi = 254f;
      this.topMarginBand1.HeightF = 132f;
      this.topMarginBand1.Name = "topMarginBand1";
      this.sIPARISLERAdapter.ClearBeforeFill = true;
      this.sıparıslerAdapter1.ClearBeforeFill = true;
      this.Bands.AddRange(new Band[7]
      {
        (Band) this.Detail,
        (Band) this.pageHeaderBand1,
        (Band) this.groupHeaderBand1,
        (Band) this.pageFooterBand1,
        (Band) this.topMarginBand1,
        (Band) this.bottomMarginBand1,
        (Band) this.ReportFooter
      });
      this.CalculatedFields.AddRange(new CalculatedField[1]
      {
        this.cf1
      });
      this.DataAdapter = (object) this.sıparıslerAdapter1;
      this.Dpi = 254f;
      this.FormattingRuleSheet.AddRange(new FormattingRule[1]
      {
        this.formattingRule1
      });
      this.Margins = new Margins(71, 79, 132, 178);
      this.PageHeight = 2794;
      this.PageWidth = 2159;
      this.ReportPrintOptions.PrintOnEmptyDataSource = false;
      this.ReportUnit = ReportUnit.TenthsOfAMillimeter;
      this.SnapGridSize = 31.75f;
      this.StyleSheet.AddRange(new XRControlStyle[4]
      {
        this.Title,
        this.FieldCaption,
        this.PageInfo,
        this.DataField
      });
      this.Version = "11.2";
      this.siparis1.EndInit();
      this.EndInit();
    }
  }
}
