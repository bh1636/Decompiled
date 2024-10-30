// Decompiled with JetBrains decompiler
// Type: Fuar.BirimlerBrws
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
  public class BirimlerBrws : XtraForm
  {
    private IContainer components;
    private GridControl dtg_birim;
    private GridView grd_birim;
    private SimpleButton btn_sil;
    private SimpleButton btn_duzenle;
    private SimpleButton btn_ekle;
    private SimpleButton btn_iptal;
    private BarManager bm1;
    private BarDockControl barDockControlTop;
    private BarDockControl barDockControlBottom;
    private BarDockControl barDockControlLeft;
    private BarDockControl barDockControlRight;
    private BarButtonItem bb_ekle;
    private BarButtonItem bb_sil;
    private BarButtonItem bb_duzenle;
    private PopupMenu pp1;

    public BirimlerBrws() => this.InitializeComponent();

    private void BirimlerBrws_Load(object sender, EventArgs e) => this.set_right(_main.y_kartlar);

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

    private void setgrid()
    {
      this.dtg_birim.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM BIRIMLER");
      this.grd_birim.Columns["ID"].Visible = false;
      this.grd_birim.RestoreLayoutFromRegistry("DmsFuar\\BirimBrws");
    }

    private void btn_iptal_Click_1(object sender, EventArgs e) => this.Close();

    private void btn_ekle_Click(object sender, EventArgs e)
    {
      BirimFrm birimFrm = new BirimFrm();
      birimFrm.MdiParent = this.MdiParent;
      birimFrm._id = "";
      birimFrm.Show();
    }

    private void btn_duzenle_Click(object sender, EventArgs e)
    {
      if (this.hareket_kontrol(this.grd_birim.GetFocusedRowCellDisplayText("BIRIM")))
      {
        int num = (int) MessageBox.Show("Hareket görmüş kayıtlar değiştirilemez.");
      }
      else
      {
        BirimFrm birimFrm = new BirimFrm();
        birimFrm.MdiParent = this.MdiParent;
        birimFrm._id = this.grd_birim.GetFocusedRowCellDisplayText("ID");
        birimFrm.Show();
      }
    }

    private void btn_sil_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.grd_birim.GetFocusedRowCellDisplayText("ID")))
        return;
      if (this.hareket_kontrol(this.grd_birim.GetFocusedRowCellDisplayText("BIRIM")))
      {
        int num = (int) MessageBox.Show("Hareket görmüş kayıtlar silinemez.");
      }
      else
      {
        if (MessageBox.Show(this.grd_birim.GetFocusedRowCellDisplayText("BIRIM") + " İsimli Birimi silmek istediğinize eminmisiniz ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
          return;
        _main.komutcalistir("DELETE FROM BIRIMLER WHERE ID = " + this.grd_birim.GetFocusedRowCellDisplayText("ID"));
        this.setgrid();
      }
    }

    private void dtg_birim_DoubleClick(object sender, EventArgs e)
    {
      this.btn_duzenle_Click(sender, e);
    }

    private void BirimlerBrws_Activated(object sender, EventArgs e) => this.setgrid();

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

    private void dtg_birim_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.pp1.ShowPopup(Control.MousePosition);
    }

    private void BirimlerBrws_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.grd_birim.SaveLayoutToRegistry("DmsFuar\\BirimBrws");
    }

    private bool hareket_kontrol(string str_birim)
    {
      return _main.komutcalistir_dt("SELECT * FROM SIPARISLER WHERE BIRIM = '" + str_birim + "'").Rows.Count > 0;
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
      this.dtg_birim = new GridControl();
      this.grd_birim = new GridView();
      this.btn_sil = new SimpleButton();
      this.btn_duzenle = new SimpleButton();
      this.btn_ekle = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.bm1 = new BarManager(this.components);
      this.barDockControlTop = new BarDockControl();
      this.barDockControlBottom = new BarDockControl();
      this.barDockControlLeft = new BarDockControl();
      this.barDockControlRight = new BarDockControl();
      this.bb_ekle = new BarButtonItem();
      this.bb_sil = new BarButtonItem();
      this.bb_duzenle = new BarButtonItem();
      this.pp1 = new PopupMenu(this.components);
      this.dtg_birim.BeginInit();
      this.grd_birim.BeginInit();
      this.bm1.BeginInit();
      this.pp1.BeginInit();
      this.SuspendLayout();
      this.dtg_birim.Dock = DockStyle.Top;
      this.dtg_birim.Location = new Point(0, 0);
      this.dtg_birim.MainView = (BaseView) this.grd_birim;
      this.dtg_birim.Name = "dtg_birim";
      this.dtg_birim.Size = new Size(762, 363);
      this.dtg_birim.TabIndex = 0;
      this.dtg_birim.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_birim
      });
      this.dtg_birim.DoubleClick += new EventHandler(this.dtg_birim_DoubleClick);
      this.dtg_birim.MouseUp += new MouseEventHandler(this.dtg_birim_MouseUp);
      this.grd_birim.ActiveFilterEnabled = false;
      this.grd_birim.GridControl = this.dtg_birim;
      this.grd_birim.Name = "grd_birim";
      this.grd_birim.OptionsBehavior.Editable = false;
      this.grd_birim.OptionsCustomization.AllowFilter = false;
      this.grd_birim.OptionsCustomization.AllowSort = false;
      this.grd_birim.OptionsMenu.EnableColumnMenu = false;
      this.grd_birim.OptionsView.ShowGroupPanel = false;
      this.btn_sil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_sil.Location = new Point(202, 378);
      this.btn_sil.Name = "btn_sil";
      this.btn_sil.Size = new Size(75, 33);
      this.btn_sil.TabIndex = 15;
      this.btn_sil.Text = "Sil";
      this.btn_sil.Click += new EventHandler(this.btn_sil_Click);
      this.btn_duzenle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_duzenle.Location = new Point(106, 378);
      this.btn_duzenle.Name = "btn_duzenle";
      this.btn_duzenle.Size = new Size(75, 33);
      this.btn_duzenle.TabIndex = 14;
      this.btn_duzenle.Text = "Düzenle";
      this.btn_duzenle.Click += new EventHandler(this.btn_duzenle_Click);
      this.btn_ekle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_ekle.Location = new Point(12, 378);
      this.btn_ekle.Name = "btn_ekle";
      this.btn_ekle.Size = new Size(75, 33);
      this.btn_ekle.TabIndex = 13;
      this.btn_ekle.Text = "Ekle";
      this.btn_ekle.Click += new EventHandler(this.btn_ekle_Click);
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btn_iptal.Location = new Point(675, 378);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 12;
      this.btn_iptal.Text = "Kapat";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click_1);
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
      this.barDockControlTop.Size = new Size(762, 0);
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = DockStyle.Bottom;
      this.barDockControlBottom.Location = new Point(0, 423);
      this.barDockControlBottom.Size = new Size(762, 0);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 0);
      this.barDockControlLeft.Size = new Size(0, 423);
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = DockStyle.Right;
      this.barDockControlRight.Location = new Point(762, 0);
      this.barDockControlRight.Size = new Size(0, 423);
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
      this.ClientSize = new Size(762, 423);
      this.Controls.Add((Control) this.btn_sil);
      this.Controls.Add((Control) this.btn_duzenle);
      this.Controls.Add((Control) this.btn_ekle);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.dtg_birim);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Controls.Add((Control) this.barDockControlRight);
      this.Controls.Add((Control) this.barDockControlBottom);
      this.Controls.Add((Control) this.barDockControlTop);
      this.Name = nameof (BirimlerBrws);
      this.Text = nameof (BirimlerBrws);
      this.WindowState = FormWindowState.Maximized;
      this.Activated += new EventHandler(this.BirimlerBrws_Activated);
      this.FormClosing += new FormClosingEventHandler(this.BirimlerBrws_FormClosing);
      this.Load += new EventHandler(this.BirimlerBrws_Load);
      this.dtg_birim.EndInit();
      this.grd_birim.EndInit();
      this.bm1.EndInit();
      this.pp1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
