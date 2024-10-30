// Decompiled with JetBrains decompiler
// Type: Fuar.TedarikcilerBrws
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
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
  public class TedarikcilerBrws : XtraForm
  {
    private IContainer components;
    private GridControl dtg_ted;
    private GridView grd_ted;
    private SimpleButton btn_ekle;
    private SimpleButton btn_duzenle;
    private SimpleButton btn_sil;
    private SimpleButton btn_kapat;
    private BarManager bm1;
    private BarDockControl barDockControlTop;
    private BarDockControl barDockControlBottom;
    private BarDockControl barDockControlLeft;
    private BarDockControl barDockControlRight;
    private BarButtonItem bb_ekle;
    private BarButtonItem bb_sil;
    private BarButtonItem bb_duzenle;
    private PopupMenu pp1;

    public TedarikcilerBrws() => this.InitializeComponent();

    private void Tedarikciler_Load(object sender, EventArgs e) => this.set_right(_main.y_kartlar);

    private void btn_kapat_Click(object sender, EventArgs e) => this.Close();

    private void btn_sil_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.grd_ted.GetFocusedRowCellDisplayText("ID")) || MessageBox.Show(this.grd_ted.GetFocusedRowCellDisplayText("TEDARIKCIADI") + " İsimli tedarikçiyi silmek istediğinize eminmisiniz ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
        return;
      _main.komutcalistir("DELETE FROM TEDARIKCILER WHERE ID = " + this.grd_ted.GetFocusedRowCellDisplayText("ID"));
      this.setgrid();
    }

    private void btn_duzenle_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.grd_ted.GetFocusedRowCellDisplayText("ID")))
        return;
      TedarikciFrm tedarikciFrm = new TedarikciFrm();
      tedarikciFrm.MdiParent = this.MdiParent;
      tedarikciFrm.ted_id = this.grd_ted.GetFocusedRowCellDisplayText("ID");
      tedarikciFrm.Show();
    }

    private void btn_ekle_Click(object sender, EventArgs e)
    {
      TedarikciFrm tedarikciFrm = new TedarikciFrm();
      tedarikciFrm.MdiParent = this.MdiParent;
      tedarikciFrm.ted_id = "";
      tedarikciFrm.Show();
    }

    private void setgrid()
    {
      this.dtg_ted.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM TEDARIKCILER");
      this.grd_ted.Columns["TEDARIKCILOGOSU"].ColumnEdit = (RepositoryItem) new RepositoryItemPictureEdit()
      {
        SizeMode = PictureSizeMode.Zoom
      };
      this.grd_ted.Columns["ID"].Visible = false;
    }

    private void TedarikcilerBrws_Activated(object sender, EventArgs e) => this.setgrid();

    private void dtg_ted_DoubleClick(object sender, EventArgs e)
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

    private void dtg_ted_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.pp1.ShowPopup(Control.MousePosition);
    }

    private void TedarikcilerBrws_FormClosing(object sender, FormClosingEventArgs e)
    {
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
      this.dtg_ted = new GridControl();
      this.grd_ted = new GridView();
      this.btn_ekle = new SimpleButton();
      this.btn_duzenle = new SimpleButton();
      this.btn_sil = new SimpleButton();
      this.btn_kapat = new SimpleButton();
      this.bm1 = new BarManager(this.components);
      this.barDockControlTop = new BarDockControl();
      this.barDockControlBottom = new BarDockControl();
      this.barDockControlLeft = new BarDockControl();
      this.barDockControlRight = new BarDockControl();
      this.bb_ekle = new BarButtonItem();
      this.bb_sil = new BarButtonItem();
      this.bb_duzenle = new BarButtonItem();
      this.pp1 = new PopupMenu(this.components);
      this.dtg_ted.BeginInit();
      this.grd_ted.BeginInit();
      this.bm1.BeginInit();
      this.pp1.BeginInit();
      this.SuspendLayout();
      this.dtg_ted.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_ted.Location = new Point(1, 0);
      this.dtg_ted.MainView = (BaseView) this.grd_ted;
      this.dtg_ted.Name = "dtg_ted";
      this.dtg_ted.Size = new Size(967, 468);
      this.dtg_ted.TabIndex = 0;
      this.dtg_ted.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_ted
      });
      this.dtg_ted.DoubleClick += new EventHandler(this.dtg_ted_DoubleClick);
      this.dtg_ted.MouseUp += new MouseEventHandler(this.dtg_ted_MouseUp);
      this.grd_ted.GridControl = this.dtg_ted;
      this.grd_ted.Name = "grd_ted";
      this.grd_ted.OptionsBehavior.Editable = false;
      this.grd_ted.OptionsCustomization.AllowRowSizing = true;
      this.grd_ted.OptionsView.ShowGroupPanel = false;
      this.btn_ekle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_ekle.Location = new Point(12, 482);
      this.btn_ekle.Name = "btn_ekle";
      this.btn_ekle.Size = new Size(75, 33);
      this.btn_ekle.TabIndex = 1;
      this.btn_ekle.Text = "Ekle";
      this.btn_ekle.Click += new EventHandler(this.btn_ekle_Click);
      this.btn_duzenle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_duzenle.Location = new Point(106, 482);
      this.btn_duzenle.Name = "btn_duzenle";
      this.btn_duzenle.Size = new Size(75, 33);
      this.btn_duzenle.TabIndex = 2;
      this.btn_duzenle.Text = "Düzenle";
      this.btn_duzenle.Click += new EventHandler(this.btn_duzenle_Click);
      this.btn_sil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_sil.Location = new Point(202, 482);
      this.btn_sil.Name = "btn_sil";
      this.btn_sil.Size = new Size(75, 33);
      this.btn_sil.TabIndex = 3;
      this.btn_sil.Text = "Sil";
      this.btn_sil.Click += new EventHandler(this.btn_sil_Click);
      this.btn_kapat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btn_kapat.Location = new Point(880, 482);
      this.btn_kapat.Name = "btn_kapat";
      this.btn_kapat.Size = new Size(75, 33);
      this.btn_kapat.TabIndex = 4;
      this.btn_kapat.Text = "Kapat";
      this.btn_kapat.Click += new EventHandler(this.btn_kapat_Click);
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
      this.barDockControlTop.Size = new Size(967, 0);
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = DockStyle.Bottom;
      this.barDockControlBottom.Location = new Point(0, 526);
      this.barDockControlBottom.Size = new Size(967, 0);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 0);
      this.barDockControlLeft.Size = new Size(0, 526);
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = DockStyle.Right;
      this.barDockControlRight.Location = new Point(967, 0);
      this.barDockControlRight.Size = new Size(0, 526);
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
      this.ClientSize = new Size(967, 526);
      this.Controls.Add((Control) this.btn_kapat);
      this.Controls.Add((Control) this.btn_sil);
      this.Controls.Add((Control) this.btn_duzenle);
      this.Controls.Add((Control) this.btn_ekle);
      this.Controls.Add((Control) this.dtg_ted);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Controls.Add((Control) this.barDockControlRight);
      this.Controls.Add((Control) this.barDockControlBottom);
      this.Controls.Add((Control) this.barDockControlTop);
      this.MinimizeBox = false;
      this.Name = nameof (TedarikcilerBrws);
      this.ShowInTaskbar = false;
      this.Text = "Tedarikçiler";
      this.TopMost = true;
      this.WindowState = FormWindowState.Maximized;
      this.Activated += new EventHandler(this.TedarikcilerBrws_Activated);
      this.FormClosing += new FormClosingEventHandler(this.TedarikcilerBrws_FormClosing);
      this.Load += new EventHandler(this.Tedarikciler_Load);
      this.dtg_ted.EndInit();
      this.grd_ted.EndInit();
      this.bm1.EndInit();
      this.pp1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
