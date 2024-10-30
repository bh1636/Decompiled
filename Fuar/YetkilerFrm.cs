// Decompiled with JetBrains decompiler
// Type: Fuar.YetkilerFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class YetkilerFrm : XtraForm
  {
    private IContainer components;
    private GridControl dtg_yetki;
    private GridView grd_yetki;
    private SimpleButton btn_kaydet;
    private SimpleButton btn_iptal;
    private GridColumn c_grup;
    private GridColumn c_modul;
    private GridColumn c_browse;
    private GridColumn c_insert;
    private GridColumn c_edit;
    private GridColumn c_delete;

    public YetkilerFrm() => this.InitializeComponent();

    private void YetkilerFrm_Load(object sender, EventArgs e)
    {
    }

    private void xgrid_doldur()
    {
      string empty = string.Empty;
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = _main.komutcalistir_dt("SELECT * FROM GRUPLAR");
      for (int index = 0; index < dataTable2.Rows.Count; ++index)
      {
        string str = "SELECT Y.MODUL, Y.CANBROWSE, Y.CANINSERT, Y.CANEDIT, Y.CANDELETE FROM GRUPLAR AS G LEFT OUTER JOIN YETKILER AS Y ON G.ID = Y.GRUPID WHERE G.GRUPADI = '" + dataTable2.Rows[index]["GRUPADI"].ToString() + "'";
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.dtg_yetki = new GridControl();
      this.grd_yetki = new GridView();
      this.c_grup = new GridColumn();
      this.c_modul = new GridColumn();
      this.c_browse = new GridColumn();
      this.c_insert = new GridColumn();
      this.c_edit = new GridColumn();
      this.c_delete = new GridColumn();
      this.btn_kaydet = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.dtg_yetki.BeginInit();
      this.grd_yetki.BeginInit();
      this.SuspendLayout();
      this.dtg_yetki.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_yetki.Location = new Point(0, 1);
      this.dtg_yetki.MainView = (BaseView) this.grd_yetki;
      this.dtg_yetki.Name = "dtg_yetki";
      this.dtg_yetki.Size = new Size(928, 461);
      this.dtg_yetki.TabIndex = 2;
      this.dtg_yetki.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_yetki
      });
      this.grd_yetki.Columns.AddRange(new GridColumn[6]
      {
        this.c_grup,
        this.c_modul,
        this.c_browse,
        this.c_insert,
        this.c_edit,
        this.c_delete
      });
      this.grd_yetki.GridControl = this.dtg_yetki;
      this.grd_yetki.Name = "grd_yetki";
      this.grd_yetki.OptionsCustomization.AllowFilter = false;
      this.grd_yetki.OptionsCustomization.AllowSort = false;
      this.grd_yetki.OptionsMenu.EnableColumnMenu = false;
      this.grd_yetki.OptionsView.ShowGroupPanel = false;
      this.c_grup.Caption = "Grup";
      this.c_grup.Name = "c_grup";
      this.c_grup.OptionsColumn.AllowEdit = false;
      this.c_grup.OptionsColumn.AllowFocus = false;
      this.c_grup.OptionsColumn.AllowMove = false;
      this.c_grup.OptionsColumn.AllowShowHide = false;
      this.c_grup.OptionsColumn.ReadOnly = true;
      this.c_grup.Visible = true;
      this.c_grup.VisibleIndex = 0;
      this.c_modul.Caption = "Modül";
      this.c_modul.Name = "c_modul";
      this.c_modul.OptionsColumn.AllowEdit = false;
      this.c_modul.OptionsColumn.AllowFocus = false;
      this.c_modul.OptionsColumn.ReadOnly = true;
      this.c_modul.Visible = true;
      this.c_modul.VisibleIndex = 1;
      this.c_browse.Caption = "Görebilir";
      this.c_browse.Name = "c_browse";
      this.c_browse.Visible = true;
      this.c_browse.VisibleIndex = 2;
      this.c_insert.Caption = "Ekleyebilir";
      this.c_insert.Name = "c_insert";
      this.c_insert.Visible = true;
      this.c_insert.VisibleIndex = 3;
      this.c_edit.Caption = "Düzenleyebilir";
      this.c_edit.Name = "c_edit";
      this.c_edit.Visible = true;
      this.c_edit.VisibleIndex = 4;
      this.c_delete.Caption = "Silebilir";
      this.c_delete.Name = "c_delete";
      this.c_delete.Visible = true;
      this.c_delete.VisibleIndex = 5;
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(12, 477);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 15;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(98, 477);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 16;
      this.btn_iptal.Text = "İptal";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(928, 522);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.dtg_yetki);
      this.MinimizeBox = false;
      this.Name = nameof (YetkilerFrm);
      this.Text = "Yetki Tanımları";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.YetkilerFrm_Load);
      this.dtg_yetki.EndInit();
      this.grd_yetki.EndInit();
      this.ResumeLayout(false);
    }
  }
}
