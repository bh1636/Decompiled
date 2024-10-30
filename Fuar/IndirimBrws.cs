// Decompiled with JetBrains decompiler
// Type: Fuar.IndirimBrws
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
  public class IndirimBrws : XtraForm
  {
    private IContainer components;
    private SimpleButton btn_kapat;
    private GridControl dtg_ind;
    private GridView grd_ind;

    public IndirimBrws() => this.InitializeComponent();

    private void IndirimBrws_Load(object sender, EventArgs e) => this.setgrid();

    private void btn_kapat_Click(object sender, EventArgs e) => this.Close();

    private void setgrid()
    {
      this.dtg_ind.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM INDIRIMLER");
      this.grd_ind.Columns["LOGREF"].Visible = false;
      foreach (GridColumn column in (CollectionBase) this.grd_ind.Columns)
        column.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
      this.grd_ind.RestoreLayoutFromRegistry("DmsFuar\\IndBrws");
    }

    private void IndirimBrws_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.grd_ind.SaveLayoutToRegistry("DmsFuar\\IndBrws");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btn_kapat = new SimpleButton();
      this.dtg_ind = new GridControl();
      this.grd_ind = new GridView();
      this.dtg_ind.BeginInit();
      this.grd_ind.BeginInit();
      this.SuspendLayout();
      this.btn_kapat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btn_kapat.Location = new Point(921, 413);
      this.btn_kapat.Name = "btn_kapat";
      this.btn_kapat.Size = new Size(75, 33);
      this.btn_kapat.TabIndex = 15;
      this.btn_kapat.Text = "Kapat";
      this.btn_kapat.Click += new EventHandler(this.btn_kapat_Click);
      this.dtg_ind.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_ind.Location = new Point(1, 2);
      this.dtg_ind.MainView = (BaseView) this.grd_ind;
      this.dtg_ind.Name = "dtg_ind";
      this.dtg_ind.Size = new Size(1006, 396);
      this.dtg_ind.TabIndex = 14;
      this.dtg_ind.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_ind
      });
      this.grd_ind.GridControl = this.dtg_ind;
      this.grd_ind.Name = "grd_ind";
      this.grd_ind.OptionsBehavior.Editable = false;
      this.grd_ind.OptionsCustomization.AllowRowSizing = true;
      this.grd_ind.OptionsView.ShowAutoFilterRow = true;
      this.grd_ind.OptionsView.ShowGroupPanel = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 458);
      this.Controls.Add((Control) this.btn_kapat);
      this.Controls.Add((Control) this.dtg_ind);
      this.Name = nameof (IndirimBrws);
      this.Text = nameof (IndirimBrws);
      this.WindowState = FormWindowState.Maximized;
      this.FormClosing += new FormClosingEventHandler(this.IndirimBrws_FormClosing);
      this.Load += new EventHandler(this.IndirimBrws_Load);
      this.dtg_ind.EndInit();
      this.grd_ind.EndInit();
      this.ResumeLayout(false);
    }
  }
}
