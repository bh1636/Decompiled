// Decompiled with JetBrains decompiler
// Type: Fuar.MusteriSel
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class MusteriSel : Form
  {
    public string s_kod_sel = string.Empty;
    public string s_name_sel = string.Empty;
    public string s_sender = string.Empty;
    private IContainer components;
    private SimpleButton btn_iptal;
    private SimpleButton btn_sec;
    private GridControl dtg_muss;
    private GridView grd_muss;

    public MusteriSel() => this.InitializeComponent();

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void MusteriSel_Load(object sender, EventArgs e)
    {
      this.dtg_muss.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM MUSTERILER");
      this.grd_muss.Columns["FIRMAKODU"].Caption = "LOGOKODU";
      this.grd_muss.Columns["ID"].Caption = "FIRMAKODU";
      foreach (GridColumn column in (CollectionBase) this.grd_muss.Columns)
        column.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
      if (this.s_kod_sel != "")
      {
        this.grd_muss.SetRowCellValue(-999997, "FIRMAKODU", (object) this.s_kod_sel);
      }
      else
      {
        if (!(this.s_name_sel != ""))
          return;
        this.grd_muss.SetRowCellValue(-999997, "FIRMAADI", (object) this.s_name_sel);
      }
    }

    private void btn_sec_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.grd_muss.GetFocusedRowCellValue("ID").ToString()))
        return;
      if (this.s_sender == "cariakt")
      {
        AktCariTrans.mus_id = this.grd_muss.GetFocusedRowCellValue("ID").ToString();
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      else if (this.s_sender == "cariakt_y")
      {
        AktCariTrans.mus_id_y = this.grd_muss.GetFocusedRowCellValue("ID").ToString();
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      else if (this.s_sender == "fast_sip")
      {
        SiparisFrmSimple.mus_id = this.grd_muss.GetFocusedRowCellValue("ID").ToString();
        SiparisFrmSimple.mus_kod = this.grd_muss.GetFocusedRowCellValue("FIRMAKODU").ToString();
        SiparisFrmSimple.mus_name = this.grd_muss.GetFocusedRowCellValue("FIRMAADI").ToString();
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      else
      {
        SiparisFrm.mus_id = this.grd_muss.GetFocusedRowCellValue("ID").ToString();
        SiparisFrm.mus_kod = this.grd_muss.GetFocusedRowCellValue("FIRMAKODU").ToString();
        SiparisFrm.mus_name = this.grd_muss.GetFocusedRowCellValue("FIRMAADI").ToString();
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void dtg_muss_DoubleClick(object sender, EventArgs e) => this.btn_sec_Click(sender, e);

    public GridView getgrid => this.grd_muss;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btn_iptal = new SimpleButton();
      this.btn_sec = new SimpleButton();
      this.dtg_muss = new GridControl();
      this.grd_muss = new GridView();
      this.dtg_muss.BeginInit();
      this.grd_muss.BeginInit();
      this.SuspendLayout();
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(109, 434);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 8;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.btn_sec.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_sec.Location = new Point(12, 434);
      this.btn_sec.Name = "btn_sec";
      this.btn_sec.Size = new Size(75, 33);
      this.btn_sec.TabIndex = 7;
      this.btn_sec.Text = "Seç";
      this.btn_sec.Click += new EventHandler(this.btn_sec_Click);
      this.dtg_muss.AccessibleName = "grd";
      this.dtg_muss.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_muss.Location = new Point(1, 4);
      this.dtg_muss.MainView = (BaseView) this.grd_muss;
      this.dtg_muss.Name = "dtg_muss";
      this.dtg_muss.Size = new Size(804, 412);
      this.dtg_muss.TabIndex = 6;
      this.dtg_muss.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_muss
      });
      this.dtg_muss.DoubleClick += new EventHandler(this.dtg_muss_DoubleClick);
      this.grd_muss.FocusRectStyle = DrawFocusRectStyle.RowFocus;
      this.grd_muss.GridControl = this.dtg_muss;
      this.grd_muss.Name = "grd_muss";
      this.grd_muss.OptionsBehavior.Editable = false;
      this.grd_muss.OptionsSelection.MultiSelect = true;
      this.grd_muss.OptionsView.ShowAutoFilterRow = true;
      this.grd_muss.OptionsView.ShowGroupPanel = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(807, 476);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.btn_sec);
      this.Controls.Add((Control) this.dtg_muss);
      this.Name = nameof (MusteriSel);
      this.Text = "Firmalar";
      this.Load += new EventHandler(this.MusteriSel_Load);
      this.dtg_muss.EndInit();
      this.grd_muss.EndInit();
      this.ResumeLayout(false);
    }
  }
}
