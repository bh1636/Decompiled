// Decompiled with JetBrains decompiler
// Type: Fuar.OtelBrws
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class OtelBrws : XtraForm
  {
    private IContainer components;
    private GridControl dtg_otel;
    private GridView grd_otel;
    private SimpleButton btn_iptal;
    private SimpleButton btn_sil;
    private SimpleButton btn_duzenle;
    private SimpleButton btn_ekle;
    private BarManager bm1;
    private BarDockControl barDockControlTop;
    private BarDockControl barDockControlBottom;
    private BarDockControl barDockControlLeft;
    private BarDockControl barDockControlRight;
    private BarButtonItem bb_ekle;
    private BarButtonItem bb_sil;
    private BarButtonItem bb_duzenle;
    private PopupMenu pp1;

    public OtelBrws() => this.InitializeComponent();

    private void OtelBrws_Load(object sender, EventArgs e) => this.set_right(_main.y_kartlar);

    private void set_grid()
    {
      this.dtg_otel.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM OTELLER");
      this.grd_otel.Columns["ID"].Visible = false;
      this.grd_otel.RestoreLayoutFromRegistry("DmsFuar\\OtelBrws");
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void OtelBrws_Activated(object sender, EventArgs e) => this.set_grid();

    private void btn_ekle_Click(object sender, EventArgs e)
    {
      OtelFrm otelFrm = new OtelFrm();
      otelFrm.MdiParent = this.MdiParent;
      otelFrm.Show();
    }

    private void btn_duzenle_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.grd_otel.GetFocusedRowCellDisplayText("ID")))
        return;
      OtelFrm otelFrm = new OtelFrm();
      otelFrm._id = this.grd_otel.GetFocusedRowCellDisplayText("ID");
      otelFrm.MdiParent = this.MdiParent;
      otelFrm.Show();
    }

    private void btn_sil_Click(object sender, EventArgs e)
    {
      string rowCellDisplayText = this.grd_otel.GetFocusedRowCellDisplayText("ID");
      if (string.IsNullOrEmpty(rowCellDisplayText) || MessageBox.Show(this.grd_otel.GetFocusedRowCellDisplayText("OTELADI") + " İsimli Oteli silmek istediğinize eminmisiniz ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
        return;
      _main.komutcalistir("DELETE FROM OTELLER WHERE ID = " + rowCellDisplayText + " DELETE FROM ODALAR WHERE OTELID = " + rowCellDisplayText);
      this.set_grid();
    }

    private void dtg_otel_DoubleClick(object sender, EventArgs e)
    {
      this.btn_duzenle_Click(sender, e);
    }

    private void bb_ekle_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_ekle_Click(sender, (EventArgs) e);
    }

    private void bb_duzenle_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_duzenle_Click(sender, (EventArgs) e);
    }

    private void bb_sil_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_sil_Click(sender, (EventArgs) e);
    }

    private void dtg_otel_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.pp1.ShowPopup(Control.MousePosition);
    }

    private void OtelBrws_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.grd_otel.SaveLayoutToRegistry("DmsFuar\\OtelBrws");
    }

    private void set_right(List<string> lst)
    {
      if (lst[1] == "True")
      {
        this.btn_ekle.Enabled = true;
        this.bb_ekle.Enabled = true;
      }
      else
      {
        this.btn_ekle.Enabled = false;
        this.bb_ekle.Enabled = false;
      }
      if (lst[2] == "True")
      {
        this.btn_duzenle.Enabled = true;
        this.bb_duzenle.Enabled = true;
      }
      else
      {
        this.btn_duzenle.Enabled = false;
        this.bb_duzenle.Enabled = false;
      }
      if (lst[3] == "True")
      {
        this.btn_sil.Enabled = true;
        this.bb_sil.Enabled = true;
      }
      else
      {
        this.btn_sil.Enabled = false;
        this.bb_sil.Enabled = false;
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
      this.components = (IContainer) new System.ComponentModel.Container();
      this.dtg_otel = new GridControl();
      this.grd_otel = new GridView();
      this.btn_iptal = new SimpleButton();
      this.btn_sil = new SimpleButton();
      this.btn_duzenle = new SimpleButton();
      this.btn_ekle = new SimpleButton();
      this.bm1 = new BarManager(this.components);
      this.barDockControlTop = new BarDockControl();
      this.barDockControlBottom = new BarDockControl();
      this.barDockControlLeft = new BarDockControl();
      this.barDockControlRight = new BarDockControl();
      this.bb_ekle = new BarButtonItem();
      this.bb_sil = new BarButtonItem();
      this.bb_duzenle = new BarButtonItem();
      this.pp1 = new PopupMenu(this.components);
      this.dtg_otel.BeginInit();
      this.grd_otel.BeginInit();
      this.bm1.BeginInit();
      this.pp1.BeginInit();
      this.SuspendLayout();
      this.dtg_otel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_otel.Location = new Point(0, 0);
      this.dtg_otel.MainView = (BaseView) this.grd_otel;
      this.dtg_otel.Name = "dtg_otel";
      this.dtg_otel.Size = new Size(971, 444);
      this.dtg_otel.TabIndex = 0;
      this.dtg_otel.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_otel
      });
      this.dtg_otel.DoubleClick += new EventHandler(this.dtg_otel_DoubleClick);
      this.dtg_otel.MouseUp += new MouseEventHandler(this.dtg_otel_MouseUp);
      this.grd_otel.GridControl = this.dtg_otel;
      this.grd_otel.Name = "grd_otel";
      this.grd_otel.OptionsBehavior.Editable = false;
      this.grd_otel.OptionsView.ShowGroupPanel = false;
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btn_iptal.Location = new Point(872, 465);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 2;
      this.btn_iptal.Text = "Kapat";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.btn_sil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_sil.Location = new Point(207, 465);
      this.btn_sil.Name = "btn_sil";
      this.btn_sil.Size = new Size(75, 33);
      this.btn_sil.TabIndex = 9;
      this.btn_sil.Text = "Sil";
      this.btn_sil.Click += new EventHandler(this.btn_sil_Click);
      this.btn_duzenle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_duzenle.Location = new Point(111, 465);
      this.btn_duzenle.Name = "btn_duzenle";
      this.btn_duzenle.Size = new Size(75, 33);
      this.btn_duzenle.TabIndex = 8;
      this.btn_duzenle.Text = "Düzenle";
      this.btn_duzenle.Click += new EventHandler(this.btn_duzenle_Click);
      this.btn_ekle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_ekle.Location = new Point(17, 465);
      this.btn_ekle.Name = "btn_ekle";
      this.btn_ekle.Size = new Size(75, 33);
      this.btn_ekle.TabIndex = 7;
      this.btn_ekle.Text = "Ekle";
      this.btn_ekle.Click += new EventHandler(this.btn_ekle_Click);
      this.bm1.DockControls.Add(this.barDockControlTop);
      this.bm1.DockControls.Add(this.barDockControlBottom);
      this.bm1.DockControls.Add(this.barDockControlLeft);
      this.bm1.DockControls.Add(this.barDockControlRight);
      this.bm1.Form = (Control) this;
      this.bm1.Items.AddRange(new BarItem[3]
      {
        (BarItem) this.bb_ekle,
        (BarItem) this.bb_sil,
        (BarItem) this.bb_duzenle
      });
      this.bm1.MaxItemId = 8;
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = DockStyle.Top;
      this.barDockControlTop.Location = new Point(0, 0);
      this.barDockControlTop.Size = new Size(972, 0);
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = DockStyle.Bottom;
      this.barDockControlBottom.Location = new Point(0, 515);
      this.barDockControlBottom.Size = new Size(972, 0);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 0);
      this.barDockControlLeft.Size = new Size(0, 515);
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = DockStyle.Right;
      this.barDockControlRight.Location = new Point(972, 0);
      this.barDockControlRight.Size = new Size(0, 515);
      this.bb_ekle.Caption = "Ekle";
      this.bb_ekle.Id = 0;
      this.bb_ekle.Name = "bb_ekle";
      this.bb_ekle.ItemClick += new ItemClickEventHandler(this.bb_ekle_ItemClick);
      this.bb_sil.Caption = "Sil";
      this.bb_sil.Id = 2;
      this.bb_sil.Name = "bb_sil";
      this.bb_sil.ItemClick += new ItemClickEventHandler(this.bb_sil_ItemClick);
      this.bb_duzenle.Caption = "Düzenle";
      this.bb_duzenle.Id = 5;
      this.bb_duzenle.Name = "bb_duzenle";
      this.bb_duzenle.ItemClick += new ItemClickEventHandler(this.bb_duzenle_ItemClick);
      this.pp1.LinksPersistInfo.AddRange(new LinkPersistInfo[3]
      {
        new LinkPersistInfo((BarItem) this.bb_ekle),
        new LinkPersistInfo((BarItem) this.bb_duzenle),
        new LinkPersistInfo((BarItem) this.bb_sil)
      });
      this.pp1.Manager = this.bm1;
      this.pp1.Name = "pp1";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(972, 515);
      this.Controls.Add((Control) this.btn_sil);
      this.Controls.Add((Control) this.btn_duzenle);
      this.Controls.Add((Control) this.btn_ekle);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.dtg_otel);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Controls.Add((Control) this.barDockControlRight);
      this.Controls.Add((Control) this.barDockControlBottom);
      this.Controls.Add((Control) this.barDockControlTop);
      this.MinimizeBox = false;
      this.Name = nameof (OtelBrws);
      this.Text = "Oteller";
      this.WindowState = FormWindowState.Maximized;
      this.Activated += new EventHandler(this.OtelBrws_Activated);
      this.FormClosing += new FormClosingEventHandler(this.OtelBrws_FormClosing);
      this.Load += new EventHandler(this.OtelBrws_Load);
      this.dtg_otel.EndInit();
      this.grd_otel.EndInit();
      this.bm1.EndInit();
      this.pp1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
