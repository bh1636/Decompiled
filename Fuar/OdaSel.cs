// Decompiled with JetBrains decompiler
// Type: Fuar.OdaSel
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
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
  public class OdaSel : XtraForm
  {
    private IContainer components;
    private SimpleButton btn_iptal;
    private SimpleButton btn_sec;
    private GridControl dtg_odas;
    private GridView grd_odas;

    public OdaSel() => this.InitializeComponent();

    private void OdaSel_Load(object sender, EventArgs e)
    {
      this.dtg_odas.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM ODATIP");
      this.grd_odas.Columns["ID"].Visible = false;
    }

    private void btn_sec_Click(object sender, EventArgs e)
    {
      string.IsNullOrEmpty(this.grd_odas.GetFocusedRowCellDisplayText("ID"));
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void dtg_odas_DoubleClick(object sender, EventArgs e) => this.btn_sec_Click(sender, e);

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
      this.dtg_odas = new GridControl();
      this.grd_odas = new GridView();
      this.dtg_odas.BeginInit();
      this.grd_odas.BeginInit();
      this.SuspendLayout();
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(109, 431);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 5;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.btn_sec.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_sec.Location = new Point(12, 431);
      this.btn_sec.Name = "btn_sec";
      this.btn_sec.Size = new Size(75, 33);
      this.btn_sec.TabIndex = 4;
      this.btn_sec.Text = "Seç";
      this.btn_sec.Click += new EventHandler(this.btn_sec_Click);
      this.dtg_odas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_odas.Location = new Point(1, 1);
      this.dtg_odas.MainView = (BaseView) this.grd_odas;
      this.dtg_odas.Name = "dtg_odas";
      this.dtg_odas.Size = new Size(804, 412);
      this.dtg_odas.TabIndex = 3;
      this.dtg_odas.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_odas
      });
      this.dtg_odas.DoubleClick += new EventHandler(this.dtg_odas_DoubleClick);
      this.grd_odas.FocusRectStyle = DrawFocusRectStyle.RowFocus;
      this.grd_odas.GridControl = this.dtg_odas;
      this.grd_odas.Name = "grd_odas";
      this.grd_odas.OptionsBehavior.Editable = false;
      this.grd_odas.OptionsSelection.MultiSelect = true;
      this.grd_odas.OptionsView.ShowGroupPanel = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(807, 476);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.btn_sec);
      this.Controls.Add((Control) this.dtg_odas);
      this.MinimizeBox = false;
      this.Name = nameof (OdaSel);
      this.Text = nameof (OdaSel);
      this.Load += new EventHandler(this.OdaSel_Load);
      this.dtg_odas.EndInit();
      this.grd_odas.EndInit();
      this.ResumeLayout(false);
    }
  }
}
