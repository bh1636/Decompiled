// Decompiled with JetBrains decompiler
// Type: Fuar.TedarikcilerSel
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class TedarikcilerSel : XtraForm
  {
    private IContainer components;
    private GridControl dtg_ted;
    private GridView grd_ted;
    private SimpleButton btn_sec;
    private SimpleButton btn_iptal;

    public TedarikcilerSel() => this.InitializeComponent();

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void TedarikcilerSel_Load(object sender, EventArgs e)
    {
      this.grd_ted.RowHeight = 55;
      this.set_tedarikciler();
    }

    private void set_tedarikciler()
    {
      this.dtg_ted.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM TEDARIKCILER");
      this.grd_ted.Columns["TEDARIKCILOGOSU"].ColumnEdit = (RepositoryItem) new RepositoryItemPictureEdit()
      {
        SizeMode = PictureSizeMode.Zoom
      };
    }

    private void btn_sec_Click(object sender, EventArgs e)
    {
      string rowCellDisplayText = this.grd_ted.GetFocusedRowCellDisplayText("ID");
      if (string.IsNullOrEmpty(rowCellDisplayText))
        return;
      KullaniciFrm.ted_id = rowCellDisplayText;
      KullaniciFrm.ted_name = this.grd_ted.GetFocusedRowCellDisplayText("TEDARIKCIADI");
      if (this.grd_ted.GetFocusedRowCellValue("TEDARIKCILOGOSU") != DBNull.Value)
        KullaniciFrm.ted_logo = (byte[]) this.grd_ted.GetFocusedRowCellValue("TEDARIKCILOGOSU");
      this.Close();
    }

    private void dtg_ted_DoubleClick(object sender, EventArgs e) => this.btn_sec_Click(sender, e);

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.dtg_ted = new GridControl();
      this.grd_ted = new GridView();
      this.btn_sec = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.dtg_ted.BeginInit();
      this.grd_ted.BeginInit();
      this.SuspendLayout();
      this.dtg_ted.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_ted.Location = new Point(0, 0);
      this.dtg_ted.MainView = (BaseView) this.grd_ted;
      this.dtg_ted.Name = "dtg_ted";
      this.dtg_ted.Size = new Size(789, 371);
      this.dtg_ted.TabIndex = 0;
      this.dtg_ted.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_ted
      });
      this.dtg_ted.DoubleClick += new EventHandler(this.dtg_ted_DoubleClick);
      this.grd_ted.FocusRectStyle = DrawFocusRectStyle.RowFocus;
      this.grd_ted.GridControl = this.dtg_ted;
      this.grd_ted.Name = "grd_ted";
      this.grd_ted.OptionsBehavior.Editable = false;
      this.grd_ted.OptionsSelection.MultiSelect = true;
      this.grd_ted.OptionsView.ShowGroupPanel = false;
      this.btn_sec.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_sec.Location = new Point(23, 379);
      this.btn_sec.Name = "btn_sec";
      this.btn_sec.Size = new Size(75, 33);
      this.btn_sec.TabIndex = 1;
      this.btn_sec.Text = "Seç";
      this.btn_sec.Click += new EventHandler(this.btn_sec_Click);
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(120, 379);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 2;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.ClientSize = new Size(789, 418);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.btn_sec);
      this.Controls.Add((Control) this.dtg_ted);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (TedarikcilerSel);
      this.Text = "Tedarikçiler";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.TedarikcilerSel_Load);
      this.dtg_ted.EndInit();
      this.grd_ted.EndInit();
      this.ResumeLayout(false);
    }
  }
}
