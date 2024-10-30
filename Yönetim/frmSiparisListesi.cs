// Decompiled with JetBrains decompiler
// Type: Yönetim.frmSiparisListesi
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#nullable disable
namespace Yönetim
{
  public class frmSiparisListesi : Form
  {
    private int Yukseklik = 0;
    private int Genislik = 0;
    private IContainer components = (IContainer) null;
    private GridControl gridControl1;
    private GridView gridView1;
    private GridColumn gridColumn1;
    private GridColumn gridColumn2;
    private GridColumn gridColumn3;
    private GridColumn gridColumn4;
    private GridColumn gridColumn5;
    private GridColumn gridColumn6;

    public frmSiparisListesi() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
      int num = (int) new frmSiparis().ShowDialog();
    }

    private void frmSiparisListesi_Load(object sender, EventArgs e)
    {
      this.gridControl1.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("SELECT sip_evrakno_seri as 'SERİ',\r\n       sip_evrakno_sira as 'SIRA',\r\n       sip_musteri_kod AS 'MÜŞTERİ KOD',\r\n       cari_unvan1 AS 'CARİ UNVANI',\r\n       SUM(sip_tutar) as 'TUTAR',COUNT(*) AS 'SATIR'\r\nFROM   SIPARISLER\r\n       JOIN CARI_HESAPLAR\r\n            ON  sip_musteri_kod = CARI_HESAPLAR.cari_kod\r\nGROUP BY\r\n       sip_evrakno_seri,\r\n       sip_evrakno_sira,\r\n       sip_musteri_kod,\r\n       cari_unvan1"));
      this.gridView1.BestFitColumns();
    }

    private void frmSiparisListesi_LocationChanged(object sender, EventArgs e)
    {
    }

    private void gridControl1_DoubleClick(object sender, EventArgs e)
    {
      try
      {
        if (this.gridView1.SelectedRowsCount <= 0)
          return;
        int num = (int) new frmSiparis()
        {
          Seri = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "SERİ").ToString(),
          Sira = Convert.ToInt32(this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "SIRA").ToString()),
          CariKod = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "MÜŞTERİ KOD").ToString(),
          CariUnvan = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "CARİ UNVANI").ToString()
        }.ShowDialog();
      }
      catch
      {
      }
    }

    private void gridControl1_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmSiparisListesi));
      this.gridControl1 = new GridControl();
      this.gridView1 = new GridView();
      this.gridColumn1 = new GridColumn();
      this.gridColumn2 = new GridColumn();
      this.gridColumn3 = new GridColumn();
      this.gridColumn4 = new GridColumn();
      this.gridColumn5 = new GridColumn();
      this.gridColumn6 = new GridColumn();
      this.gridControl1.BeginInit();
      this.gridView1.BeginInit();
      this.SuspendLayout();
      this.gridControl1.Dock = DockStyle.Fill;
      this.gridControl1.EmbeddedNavigator.Name = "";
      this.gridControl1.Location = new Point(0, 0);
      this.gridControl1.MainView = (BaseView) this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new Size(802, 557);
      this.gridControl1.TabIndex = 0;
      this.gridControl1.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView1
      });
      this.gridControl1.DoubleClick += new EventHandler(this.gridControl1_DoubleClick);
      this.gridControl1.Click += new EventHandler(this.gridControl1_Click);
      this.gridView1.Appearance.ColumnFilterButton.BackColor = Color.FromArgb(221, 236, 254);
      this.gridView1.Appearance.ColumnFilterButton.BackColor2 = Color.FromArgb(132, 171, 228);
      this.gridView1.Appearance.ColumnFilterButton.BorderColor = Color.FromArgb(221, 236, 254);
      this.gridView1.Appearance.ColumnFilterButton.ForeColor = Color.Black;
      this.gridView1.Appearance.ColumnFilterButton.GradientMode = LinearGradientMode.Vertical;
      this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
      this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
      this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
      this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = Color.FromArgb(247, 251, (int) byte.MaxValue);
      this.gridView1.Appearance.ColumnFilterButtonActive.BackColor2 = Color.FromArgb(154, 190, 243);
      this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = Color.FromArgb(247, 251, (int) byte.MaxValue);
      this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = Color.Black;
      this.gridView1.Appearance.ColumnFilterButtonActive.GradientMode = LinearGradientMode.Vertical;
      this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
      this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
      this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
      this.gridView1.Appearance.Empty.BackColor = Color.White;
      this.gridView1.Appearance.Empty.Options.UseBackColor = true;
      this.gridView1.Appearance.EvenRow.BackColor = Color.FromArgb(231, 242, 254);
      this.gridView1.Appearance.EvenRow.ForeColor = Color.Black;
      this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
      this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
      this.gridView1.Appearance.FilterCloseButton.BackColor = Color.FromArgb(221, 236, 254);
      this.gridView1.Appearance.FilterCloseButton.BackColor2 = Color.FromArgb(132, 171, 228);
      this.gridView1.Appearance.FilterCloseButton.BorderColor = Color.FromArgb(221, 236, 254);
      this.gridView1.Appearance.FilterCloseButton.ForeColor = Color.Black;
      this.gridView1.Appearance.FilterCloseButton.GradientMode = LinearGradientMode.Vertical;
      this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
      this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
      this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
      this.gridView1.Appearance.FilterPanel.BackColor = Color.FromArgb(62, 109, 185);
      this.gridView1.Appearance.FilterPanel.ForeColor = Color.White;
      this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
      this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
      this.gridView1.Appearance.FixedLine.BackColor = Color.FromArgb(59, 97, 156);
      this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
      this.gridView1.Appearance.FocusedCell.BackColor = Color.White;
      this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
      this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
      this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
      this.gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(49, 106, 197);
      this.gridView1.Appearance.FocusedRow.ForeColor = Color.White;
      this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
      this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
      this.gridView1.Appearance.FooterPanel.BackColor = Color.FromArgb(221, 236, 254);
      this.gridView1.Appearance.FooterPanel.BackColor2 = Color.FromArgb(132, 171, 228);
      this.gridView1.Appearance.FooterPanel.BorderColor = Color.FromArgb(221, 236, 254);
      this.gridView1.Appearance.FooterPanel.ForeColor = Color.Black;
      this.gridView1.Appearance.FooterPanel.GradientMode = LinearGradientMode.Vertical;
      this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
      this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
      this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
      this.gridView1.Appearance.GroupButton.BackColor = Color.FromArgb(193, 216, 247);
      this.gridView1.Appearance.GroupButton.BorderColor = Color.FromArgb(193, 216, 247);
      this.gridView1.Appearance.GroupButton.ForeColor = Color.Black;
      this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
      this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
      this.gridView1.Appearance.GroupButton.Options.UseForeColor = true;
      this.gridView1.Appearance.GroupFooter.BackColor = Color.FromArgb(193, 216, 247);
      this.gridView1.Appearance.GroupFooter.BorderColor = Color.FromArgb(193, 216, 247);
      this.gridView1.Appearance.GroupFooter.ForeColor = Color.Black;
      this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
      this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
      this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
      this.gridView1.Appearance.GroupPanel.BackColor = Color.FromArgb(62, 109, 185);
      this.gridView1.Appearance.GroupPanel.ForeColor = Color.FromArgb(221, 236, 254);
      this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
      this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
      this.gridView1.Appearance.GroupRow.BackColor = Color.FromArgb(193, 216, 247);
      this.gridView1.Appearance.GroupRow.BorderColor = Color.FromArgb(193, 216, 247);
      this.gridView1.Appearance.GroupRow.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      this.gridView1.Appearance.GroupRow.ForeColor = Color.Black;
      this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
      this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
      this.gridView1.Appearance.GroupRow.Options.UseFont = true;
      this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
      this.gridView1.Appearance.HeaderPanel.BackColor = Color.FromArgb(221, 236, 254);
      this.gridView1.Appearance.HeaderPanel.BackColor2 = Color.FromArgb(132, 171, 228);
      this.gridView1.Appearance.HeaderPanel.BorderColor = Color.FromArgb(221, 236, 254);
      this.gridView1.Appearance.HeaderPanel.ForeColor = Color.Black;
      this.gridView1.Appearance.HeaderPanel.GradientMode = LinearGradientMode.Vertical;
      this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
      this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
      this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
      this.gridView1.Appearance.HideSelectionRow.BackColor = Color.FromArgb(106, 153, 228);
      this.gridView1.Appearance.HideSelectionRow.ForeColor = Color.FromArgb(208, 224, 251);
      this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
      this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
      this.gridView1.Appearance.HorzLine.BackColor = Color.FromArgb(99, (int) sbyte.MaxValue, 196);
      this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
      this.gridView1.Appearance.OddRow.BackColor = Color.White;
      this.gridView1.Appearance.OddRow.ForeColor = Color.Black;
      this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
      this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
      this.gridView1.Appearance.Preview.BackColor = Color.FromArgb(249, 252, (int) byte.MaxValue);
      this.gridView1.Appearance.Preview.ForeColor = Color.FromArgb(88, 129, 185);
      this.gridView1.Appearance.Preview.Options.UseBackColor = true;
      this.gridView1.Appearance.Preview.Options.UseForeColor = true;
      this.gridView1.Appearance.Row.BackColor = Color.White;
      this.gridView1.Appearance.Row.ForeColor = Color.Black;
      this.gridView1.Appearance.Row.Options.UseBackColor = true;
      this.gridView1.Appearance.Row.Options.UseForeColor = true;
      this.gridView1.Appearance.RowSeparator.BackColor = Color.White;
      this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
      this.gridView1.Appearance.SelectedRow.BackColor = Color.FromArgb(69, 126, 217);
      this.gridView1.Appearance.SelectedRow.ForeColor = Color.White;
      this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
      this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
      this.gridView1.Appearance.VertLine.BackColor = Color.FromArgb(99, (int) sbyte.MaxValue, 196);
      this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
      this.gridView1.Columns.AddRange(new GridColumn[6]
      {
        this.gridColumn1,
        this.gridColumn2,
        this.gridColumn3,
        this.gridColumn4,
        this.gridColumn5,
        this.gridColumn6
      });
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsBehavior.Editable = false;
      this.gridView1.OptionsCustomization.AllowFilter = false;
      this.gridView1.OptionsCustomization.AllowGroup = false;
      this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
      this.gridView1.OptionsView.EnableAppearanceOddRow = true;
      this.gridView1.OptionsView.ShowAutoFilterRow = true;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.gridView1.PaintStyleName = "Style3D";
      this.gridColumn1.Caption = "SERİ";
      this.gridColumn1.FieldName = "SERİ";
      this.gridColumn1.Name = "gridColumn1";
      this.gridColumn1.Visible = true;
      this.gridColumn1.VisibleIndex = 0;
      this.gridColumn1.Width = 82;
      this.gridColumn2.Caption = "SIRA";
      this.gridColumn2.FieldName = "SIRA";
      this.gridColumn2.Name = "gridColumn2";
      this.gridColumn2.Visible = true;
      this.gridColumn2.VisibleIndex = 1;
      this.gridColumn2.Width = 139;
      this.gridColumn3.Caption = "CARI KOD";
      this.gridColumn3.FieldName = "MÜŞTERİ KOD";
      this.gridColumn3.Name = "gridColumn3";
      this.gridColumn3.Visible = true;
      this.gridColumn3.VisibleIndex = 2;
      this.gridColumn3.Width = 148;
      this.gridColumn4.Caption = "CARİ UNVAN";
      this.gridColumn4.FieldName = "CARİ UNVANI";
      this.gridColumn4.Name = "gridColumn4";
      this.gridColumn4.Visible = true;
      this.gridColumn4.VisibleIndex = 3;
      this.gridColumn4.Width = 299;
      this.gridColumn5.Caption = "TUTAR";
      this.gridColumn5.DisplayFormat.FormatString = "f";
      this.gridColumn5.DisplayFormat.FormatType = FormatType.Numeric;
      this.gridColumn5.FieldName = "TUTAR";
      this.gridColumn5.Name = "gridColumn5";
      this.gridColumn5.Visible = true;
      this.gridColumn5.VisibleIndex = 4;
      this.gridColumn5.Width = 123;
      this.gridColumn6.Caption = "SATIR";
      this.gridColumn6.FieldName = "SATIR";
      this.gridColumn6.Name = "gridColumn6";
      this.gridColumn6.Visible = true;
      this.gridColumn6.VisibleIndex = 5;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(802, 557);
      this.Controls.Add((Control) this.gridControl1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmSiparisListesi);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Extra Sipariş  Sistemi";
      this.Load += new EventHandler(this.frmSiparisListesi_Load);
      this.LocationChanged += new EventHandler(this.frmSiparisListesi_LocationChanged);
      this.gridControl1.EndInit();
      this.gridView1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
