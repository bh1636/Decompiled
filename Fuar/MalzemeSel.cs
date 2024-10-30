// Decompiled with JetBrains decompiler
// Type: Fuar.MalzemeSel
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
  public class MalzemeSel : Form
  {
    private IContainer components;
    private SimpleButton btn_iptal;
    private SimpleButton btn_sec;
    private GridControl dtg_mlz;
    private GridView grd_mlz;

    public MalzemeSel() => this.InitializeComponent();

    private void btn_iptal_Click(object sender, EventArgs e)
    {
      SiparisFrm.mlz_ad = "";
      SiparisFrm.mlz_kod = "";
      this.Close();
    }

    private void MalzemeSel_Load(object sender, EventArgs e) => this.set_grid();

    private void btn_sec_Click(object sender, EventArgs e)
    {
      string rowCellDisplayText = this.grd_mlz.GetFocusedRowCellDisplayText("KOD");
      if (string.IsNullOrEmpty(rowCellDisplayText))
        return;
      SiparisFrm.mlz_kod = rowCellDisplayText;
      SiparisFrm.mlz_ad = this.grd_mlz.GetFocusedRowCellDisplayText("AD");
      this.Close();
    }

    private void set_grid()
    {
      string sql_str = "SELECT KOD,AD,MARKA,URETICIKODU FROM MALZEMELER";
      if (_main.dt_user.Rows[0]["KULLANICIADI"].ToString() != "ADMIN")
        sql_str = sql_str + " WHERE TEDARIKCI = '" + _main.dt_user.Rows[0]["TEDARIKCIADI"].ToString() + "' OR KOD IN ('1')";
      this.dtg_mlz.DataSource = (object) _main.komutcalistir_dt(sql_str);
      foreach (GridColumn column in (CollectionBase) this.grd_mlz.Columns)
        column.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
    }

    private void dtg_mlz_DoubleClick(object sender, EventArgs e) => this.btn_sec_Click(sender, e);

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
      this.dtg_mlz = new GridControl();
      this.grd_mlz = new GridView();
      this.dtg_mlz.BeginInit();
      this.grd_mlz.BeginInit();
      this.SuspendLayout();
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(115, 361);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 5;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.btn_sec.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_sec.Location = new Point(18, 361);
      this.btn_sec.Name = "btn_sec";
      this.btn_sec.Size = new Size(75, 33);
      this.btn_sec.TabIndex = 4;
      this.btn_sec.Text = "Seç";
      this.btn_sec.Click += new EventHandler(this.btn_sec_Click);
      this.dtg_mlz.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_mlz.Location = new Point(2, 3);
      this.dtg_mlz.MainView = (BaseView) this.grd_mlz;
      this.dtg_mlz.Name = "dtg_mlz";
      this.dtg_mlz.Size = new Size(776, 345);
      this.dtg_mlz.TabIndex = 3;
      this.dtg_mlz.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_mlz
      });
      this.dtg_mlz.DoubleClick += new EventHandler(this.dtg_mlz_DoubleClick);
      this.grd_mlz.FocusRectStyle = DrawFocusRectStyle.RowFocus;
      this.grd_mlz.GridControl = this.dtg_mlz;
      this.grd_mlz.Name = "grd_mlz";
      this.grd_mlz.OptionsBehavior.Editable = false;
      this.grd_mlz.OptionsSelection.MultiSelect = true;
      this.grd_mlz.OptionsView.ShowAutoFilterRow = true;
      this.grd_mlz.OptionsView.ShowGroupPanel = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(779, 408);
      this.ControlBox = false;
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.btn_sec);
      this.Controls.Add((Control) this.dtg_mlz);
      this.MinimizeBox = false;
      this.Name = nameof (MalzemeSel);
      this.Text = "Ürünler";
      this.Load += new EventHandler(this.MalzemeSel_Load);
      this.dtg_mlz.EndInit();
      this.grd_mlz.EndInit();
      this.ResumeLayout(false);
    }
  }
}
