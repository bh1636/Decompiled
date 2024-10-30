// Decompiled with JetBrains decompiler
// Type: Yönetim.frmPromosyon
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Yönetim
{
  public class frmPromosyon : Form
  {
    private IContainer components = (IContainer) null;
    private XtraTabControl xtraTabControl1;
    private XtraTabPage xtraTabPage1;
    private XtraTabPage xtraTabPage2;
    private XtraTabPage xtraTabPage3;
    private XtraTabPage xtraTabPage4;
    private XtraTabPage xtraTabPage5;
    private XtraTabPage xtraTabPage6;
    private ImageList ımageList1;

    public frmPromosyon() => this.InitializeComponent();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmPromosyon));
      this.xtraTabControl1 = new XtraTabControl();
      this.ımageList1 = new ImageList(this.components);
      this.xtraTabPage1 = new XtraTabPage();
      this.xtraTabPage2 = new XtraTabPage();
      this.xtraTabPage3 = new XtraTabPage();
      this.xtraTabPage4 = new XtraTabPage();
      this.xtraTabPage5 = new XtraTabPage();
      this.xtraTabPage6 = new XtraTabPage();
      this.xtraTabControl1.BeginInit();
      this.xtraTabControl1.SuspendLayout();
      this.SuspendLayout();
      this.xtraTabControl1.BorderStyle = BorderStyles.NoBorder;
      this.xtraTabControl1.BorderStylePage = BorderStyles.NoBorder;
      this.xtraTabControl1.Dock = DockStyle.Fill;
      this.xtraTabControl1.HeaderLocation = TabHeaderLocation.Left;
      this.xtraTabControl1.HeaderOrientation = TabOrientation.Horizontal;
      this.xtraTabControl1.Images = (object) this.ımageList1;
      this.xtraTabControl1.Location = new Point(0, 0);
      this.xtraTabControl1.LookAndFeel.SkinName = "Caramel";
      this.xtraTabControl1.LookAndFeel.Style = LookAndFeelStyle.UltraFlat;
      this.xtraTabControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.xtraTabControl1.Name = "xtraTabControl1";
      this.xtraTabControl1.PaintStyleName = "PropertyView";
      this.xtraTabControl1.RightToLeft = RightToLeft.Yes;
      this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
      this.xtraTabControl1.ShowHeaderFocus = DefaultBoolean.True;
      this.xtraTabControl1.ShowTabHeader = DefaultBoolean.True;
      this.xtraTabControl1.ShowToolTips = DefaultBoolean.False;
      this.xtraTabControl1.Size = new Size(808, 476);
      this.xtraTabControl1.TabIndex = 1;
      this.xtraTabControl1.TabPages.AddRange(new XtraTabPage[6]
      {
        this.xtraTabPage1,
        this.xtraTabPage2,
        this.xtraTabPage3,
        this.xtraTabPage4,
        this.xtraTabPage5,
        this.xtraTabPage6
      });
      this.ımageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("ımageList1.ImageStream");
      this.ımageList1.TransparentColor = Color.Transparent;
      this.ımageList1.Images.SetKeyName(0, "misc2.ico");
      this.ımageList1.Images.SetKeyName(1, "misc3.ico");
      this.ımageList1.Images.SetKeyName(2, "misc4.ico");
      this.xtraTabPage1.Appearance.Header.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.xtraTabPage1.Appearance.Header.ForeColor = Color.Black;
      this.xtraTabPage1.Appearance.Header.Options.UseFont = true;
      this.xtraTabPage1.Appearance.Header.Options.UseForeColor = true;
      this.xtraTabPage1.Appearance.Header.Options.UseTextOptions = true;
      this.xtraTabPage1.Appearance.Header.TextOptions.HAlignment = HorzAlignment.Near;
      this.xtraTabPage1.Appearance.Header.TextOptions.HotkeyPrefix = HKeyPrefix.Show;
      this.xtraTabPage1.Appearance.Header.TextOptions.WordWrap = WordWrap.Wrap;
      this.xtraTabPage1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.xtraTabPage1.ImageIndex = 0;
      this.xtraTabPage1.Name = "xtraTabPage1";
      this.xtraTabPage1.Size = new Size(554, 476);
      this.xtraTabPage1.Text = "Sipariş Toplam Tutarına göre İskonto";
      this.xtraTabPage1.TooltipIconType = ToolTipIconType.Hand;
      this.xtraTabPage2.Appearance.Header.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.xtraTabPage2.Appearance.Header.ForeColor = Color.Black;
      this.xtraTabPage2.Appearance.Header.Options.UseFont = true;
      this.xtraTabPage2.Appearance.Header.Options.UseForeColor = true;
      this.xtraTabPage2.Appearance.Header.Options.UseTextOptions = true;
      this.xtraTabPage2.Appearance.Header.TextOptions.HAlignment = HorzAlignment.Near;
      this.xtraTabPage2.Appearance.Header.TextOptions.HotkeyPrefix = HKeyPrefix.Show;
      this.xtraTabPage2.Appearance.Header.TextOptions.WordWrap = WordWrap.Wrap;
      this.xtraTabPage2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.xtraTabPage2.ImageIndex = 1;
      this.xtraTabPage2.Name = "xtraTabPage2";
      this.xtraTabPage2.ShowCloseButton = DefaultBoolean.False;
      this.xtraTabPage2.Size = new Size(554, 476);
      this.xtraTabPage2.Text = "Sipariş Toplam Tutarına Göre Ürün Hediyesi";
      this.xtraTabPage2.TooltipIconType = ToolTipIconType.Exclamation;
      this.xtraTabPage3.Appearance.Header.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.xtraTabPage3.Appearance.Header.ForeColor = Color.Black;
      this.xtraTabPage3.Appearance.Header.Options.UseFont = true;
      this.xtraTabPage3.Appearance.Header.Options.UseForeColor = true;
      this.xtraTabPage3.Appearance.Header.Options.UseTextOptions = true;
      this.xtraTabPage3.Appearance.Header.TextOptions.HAlignment = HorzAlignment.Near;
      this.xtraTabPage3.Appearance.Header.TextOptions.HotkeyPrefix = HKeyPrefix.Show;
      this.xtraTabPage3.Appearance.Header.TextOptions.WordWrap = WordWrap.Wrap;
      this.xtraTabPage3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.xtraTabPage3.ImageIndex = 2;
      this.xtraTabPage3.Name = "xtraTabPage3";
      this.xtraTabPage3.ShowCloseButton = DefaultBoolean.False;
      this.xtraTabPage3.Size = new Size(554, 476);
      this.xtraTabPage3.Text = "Ürün Miktarına Göre İskonto";
      this.xtraTabPage3.TooltipIconType = ToolTipIconType.Exclamation;
      this.xtraTabPage4.Appearance.Header.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.xtraTabPage4.Appearance.Header.ForeColor = Color.Black;
      this.xtraTabPage4.Appearance.Header.Options.UseFont = true;
      this.xtraTabPage4.Appearance.Header.Options.UseForeColor = true;
      this.xtraTabPage4.Appearance.Header.Options.UseTextOptions = true;
      this.xtraTabPage4.Appearance.Header.TextOptions.HAlignment = HorzAlignment.Near;
      this.xtraTabPage4.Appearance.Header.TextOptions.HotkeyPrefix = HKeyPrefix.Show;
      this.xtraTabPage4.Appearance.Header.TextOptions.WordWrap = WordWrap.Wrap;
      this.xtraTabPage4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.xtraTabPage4.ImageIndex = 0;
      this.xtraTabPage4.Name = "xtraTabPage4";
      this.xtraTabPage4.ShowCloseButton = DefaultBoolean.False;
      this.xtraTabPage4.Size = new Size(554, 476);
      this.xtraTabPage4.Text = "Ürün Miktarına Göre Ürün Hediyesi";
      this.xtraTabPage4.TooltipIconType = ToolTipIconType.Exclamation;
      this.xtraTabPage5.Appearance.Header.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.xtraTabPage5.Appearance.Header.ForeColor = Color.Black;
      this.xtraTabPage5.Appearance.Header.Options.UseFont = true;
      this.xtraTabPage5.Appearance.Header.Options.UseForeColor = true;
      this.xtraTabPage5.Appearance.Header.Options.UseTextOptions = true;
      this.xtraTabPage5.Appearance.Header.TextOptions.HAlignment = HorzAlignment.Near;
      this.xtraTabPage5.Appearance.Header.TextOptions.HotkeyPrefix = HKeyPrefix.Show;
      this.xtraTabPage5.Appearance.Header.TextOptions.WordWrap = WordWrap.Wrap;
      this.xtraTabPage5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.xtraTabPage5.ImageIndex = 1;
      this.xtraTabPage5.Name = "xtraTabPage5";
      this.xtraTabPage5.ShowCloseButton = DefaultBoolean.False;
      this.xtraTabPage5.Size = new Size(554, 476);
      this.xtraTabPage5.Text = "Ürün Toplam Satışına Göre İskonto";
      this.xtraTabPage5.TooltipIconType = ToolTipIconType.Exclamation;
      this.xtraTabPage6.Appearance.Header.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.xtraTabPage6.Appearance.Header.ForeColor = Color.Black;
      this.xtraTabPage6.Appearance.Header.Options.UseFont = true;
      this.xtraTabPage6.Appearance.Header.Options.UseForeColor = true;
      this.xtraTabPage6.Appearance.Header.Options.UseTextOptions = true;
      this.xtraTabPage6.Appearance.Header.TextOptions.HAlignment = HorzAlignment.Near;
      this.xtraTabPage6.Appearance.Header.TextOptions.HotkeyPrefix = HKeyPrefix.Show;
      this.xtraTabPage6.Appearance.Header.TextOptions.WordWrap = WordWrap.Wrap;
      this.xtraTabPage6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.xtraTabPage6.ImageIndex = 2;
      this.xtraTabPage6.Name = "xtraTabPage6";
      this.xtraTabPage6.ShowCloseButton = DefaultBoolean.False;
      this.xtraTabPage6.Size = new Size(554, 476);
      this.xtraTabPage6.Text = "Ürün Toplam Satışına Göre Ürün Hediyesi";
      this.xtraTabPage6.TooltipIconType = ToolTipIconType.Exclamation;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(808, 476);
      this.Controls.Add((Control) this.xtraTabControl1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmPromosyon);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Promosyon Tanımları";
      this.xtraTabControl1.EndInit();
      this.xtraTabControl1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
