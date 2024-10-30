// Decompiled with JetBrains decompiler
// Type: Fuar.GrupBrws
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
  public class GrupBrws : XtraForm
  {
    private IContainer components;
    private PopupMenu pp1;
    private BarButtonItem bb_ekle;
    private BarButtonItem bb_duzenle;
    private BarButtonItem bb_sil;
    private BarManager bm1;
    private BarDockControl barDockControlTop;
    private BarDockControl barDockControlBottom;
    private BarDockControl barDockControlLeft;
    private BarDockControl barDockControlRight;
    private GridControl dtg_grp;
    private GridView grd_grp;
    private RepositoryItemPictureEdit pct1;
    private SimpleButton btn_kapat;
    private SimpleButton btn_sil;
    private SimpleButton btn_duzenle;
    private SimpleButton btn_ekle;

    public GrupBrws() => this.InitializeComponent();

    private void GrupBrws_Load(object sender, EventArgs e) => this.set_right(_main.y_kull);

    private void btn_kapat_Click(object sender, EventArgs e) => this.Close();

    private void btn_sil_Click(object sender, EventArgs e)
    {
      try
      {
        string rowCellDisplayText = this.grd_grp.GetFocusedRowCellDisplayText("ID");
        if (string.IsNullOrEmpty(rowCellDisplayText) || MessageBox.Show(this.grd_grp.GetFocusedRowCellDisplayText("GRUPADI") + " İsimli grubu silmek istediğinize eminmisiniz ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
          return;
        _main.komutcalistir("DELETE FROM GRUPLAR WHERE ID = " + rowCellDisplayText);
        _main.komutcalistir("DELETE FROM YETKILER WHERE GRUPID = " + rowCellDisplayText);
        _main.komutcalistir("UPDATE KULLANICILAR SET GRUPID = 0 WHERE GRUPID = " + rowCellDisplayText);
        this.setgrid();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void btn_duzenle_Click(object sender, EventArgs e)
    {
      try
      {
        string rowCellDisplayText1 = this.grd_grp.GetFocusedRowCellDisplayText("ID");
        string rowCellDisplayText2 = this.grd_grp.GetFocusedRowCellDisplayText("GRUPADI");
        if (string.IsNullOrEmpty(rowCellDisplayText1))
          return;
        GrupFrm grupFrm = new GrupFrm();
        grupFrm.MdiParent = this.MdiParent;
        grupFrm.grp_id = rowCellDisplayText1;
        grupFrm.grp_ad = rowCellDisplayText2;
        grupFrm.Show();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void btn_ekle_Click(object sender, EventArgs e)
    {
      GrupFrm grupFrm = new GrupFrm();
      grupFrm.MdiParent = this.MdiParent;
      grupFrm.Show();
    }

    private void setgrid()
    {
      this.dtg_grp.DataSource = (object) _main.komutcalistir_dt("SELECT ID,GRUPADI FROM GRUPLAR WHERE GRUPADI != 'YONETICI'");
      this.grd_grp.Columns["ID"].Visible = false;
    }

    private void GrupBrws_Activated(object sender, EventArgs e)
    {
      this.setgrid();
      this.WindowState = FormWindowState.Maximized;
    }

    private void grd_grp_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.pp1.ShowPopup(Control.MousePosition);
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
      this.pp1 = new PopupMenu(this.components);
      this.bb_ekle = new BarButtonItem();
      this.bb_duzenle = new BarButtonItem();
      this.bb_sil = new BarButtonItem();
      this.bm1 = new BarManager(this.components);
      this.barDockControlTop = new BarDockControl();
      this.barDockControlBottom = new BarDockControl();
      this.barDockControlLeft = new BarDockControl();
      this.barDockControlRight = new BarDockControl();
      this.dtg_grp = new GridControl();
      this.grd_grp = new GridView();
      this.pct1 = new RepositoryItemPictureEdit();
      this.btn_kapat = new SimpleButton();
      this.btn_sil = new SimpleButton();
      this.btn_duzenle = new SimpleButton();
      this.btn_ekle = new SimpleButton();
      this.pp1.BeginInit();
      this.bm1.BeginInit();
      this.dtg_grp.BeginInit();
      this.grd_grp.BeginInit();
      this.pct1.BeginInit();
      this.SuspendLayout();
      this.pp1.LinksPersistInfo.AddRange(new LinkPersistInfo[3]
      {
        new LinkPersistInfo((BarItem) this.bb_ekle),
        new LinkPersistInfo((BarItem) this.bb_duzenle),
        new LinkPersistInfo((BarItem) this.bb_sil)
      });
      this.pp1.Manager = this.bm1;
      this.pp1.Name = "pp1";
      this.bb_ekle.Caption = "Ekle";
      this.bb_ekle.Id = 0;
      this.bb_ekle.Name = "bb_ekle";
      this.bb_ekle.ItemClick += new ItemClickEventHandler(this.bb_ekle_ItemClick);
      this.bb_duzenle.Caption = "Düzenle";
      this.bb_duzenle.Id = 5;
      this.bb_duzenle.Name = "bb_duzenle";
      this.bb_duzenle.ItemClick += new ItemClickEventHandler(this.bb_duzenle_ItemClick);
      this.bb_sil.Caption = "Sil";
      this.bb_sil.Id = 2;
      this.bb_sil.Name = "bb_sil";
      this.bb_sil.ItemClick += new ItemClickEventHandler(this.bb_sil_ItemClick);
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
      this.barDockControlTop.Size = new Size(1138, 0);
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = DockStyle.Bottom;
      this.barDockControlBottom.Location = new Point(0, 556);
      this.barDockControlBottom.Size = new Size(1138, 0);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 0);
      this.barDockControlLeft.Size = new Size(0, 556);
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = DockStyle.Right;
      this.barDockControlRight.Location = new Point(1138, 0);
      this.barDockControlRight.Size = new Size(0, 556);
      this.dtg_grp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_grp.Location = new Point(-1, -1);
      this.dtg_grp.MainView = (BaseView) this.grd_grp;
      this.dtg_grp.Name = "dtg_grp";
      this.dtg_grp.RepositoryItems.AddRange(new RepositoryItem[1]
      {
        (RepositoryItem) this.pct1
      });
      this.dtg_grp.Size = new Size(1139, 505);
      this.dtg_grp.TabIndex = 10;
      this.dtg_grp.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_grp
      });
      this.grd_grp.GridControl = this.dtg_grp;
      this.grd_grp.Name = "grd_grp";
      this.grd_grp.OptionsBehavior.Editable = false;
      this.grd_grp.OptionsCustomization.AllowRowSizing = true;
      this.grd_grp.OptionsView.ShowGroupPanel = false;
      this.grd_grp.MouseUp += new MouseEventHandler(this.grd_grp_MouseUp);
      this.pct1.Name = "pct1";
      this.pct1.SizeMode = PictureSizeMode.Zoom;
      this.btn_kapat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btn_kapat.Location = new Point(1043, 514);
      this.btn_kapat.Name = "btn_kapat";
      this.btn_kapat.Size = new Size(75, 33);
      this.btn_kapat.TabIndex = 9;
      this.btn_kapat.Text = "Kapat";
      this.btn_kapat.Click += new EventHandler(this.btn_kapat_Click);
      this.btn_sil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_sil.Location = new Point(228, 514);
      this.btn_sil.Name = "btn_sil";
      this.btn_sil.Size = new Size(75, 33);
      this.btn_sil.TabIndex = 8;
      this.btn_sil.Text = "Sil";
      this.btn_sil.Click += new EventHandler(this.btn_sil_Click);
      this.btn_duzenle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_duzenle.Location = new Point(124, 514);
      this.btn_duzenle.Name = "btn_duzenle";
      this.btn_duzenle.Size = new Size(75, 33);
      this.btn_duzenle.TabIndex = 7;
      this.btn_duzenle.Text = "Düzenle";
      this.btn_duzenle.Click += new EventHandler(this.btn_duzenle_Click);
      this.btn_ekle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_ekle.Location = new Point(18, 514);
      this.btn_ekle.Name = "btn_ekle";
      this.btn_ekle.Size = new Size(75, 33);
      this.btn_ekle.TabIndex = 6;
      this.btn_ekle.Text = "Ekle";
      this.btn_ekle.Click += new EventHandler(this.btn_ekle_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1138, 556);
      this.Controls.Add((Control) this.dtg_grp);
      this.Controls.Add((Control) this.btn_kapat);
      this.Controls.Add((Control) this.btn_sil);
      this.Controls.Add((Control) this.btn_duzenle);
      this.Controls.Add((Control) this.btn_ekle);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Controls.Add((Control) this.barDockControlRight);
      this.Controls.Add((Control) this.barDockControlBottom);
      this.Controls.Add((Control) this.barDockControlTop);
      this.Name = nameof (GrupBrws);
      this.Text = "Gruplar";
      this.Activated += new EventHandler(this.GrupBrws_Activated);
      this.Load += new EventHandler(this.GrupBrws_Load);
      this.pp1.EndInit();
      this.bm1.EndInit();
      this.dtg_grp.EndInit();
      this.grd_grp.EndInit();
      this.pct1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
