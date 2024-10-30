// Decompiled with JetBrains decompiler
// Type: Fuar.MalzemeBrws
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class MalzemeBrws : XtraForm
  {
    private IContainer components;
    private SimpleButton btn_sil;
    private SimpleButton btn_duzenle;
    private SimpleButton btn_ekle;
    private GridView grd_mlz;
    private GridControl dtg_mlz;
    private SimpleButton btn_iptal;
    private RepositoryItemPictureEdit imgk;
    private RepositoryItemPictureEdit img1;
    private RepositoryItemPictureEdit img2;
    private RepositoryItemPictureEdit img3;
    private BarManager bm1;
    private BarDockControl barDockControlTop;
    private BarDockControl barDockControlBottom;
    private BarDockControl barDockControlLeft;
    private BarDockControl barDockControlRight;
    private BarButtonItem bb_ekle;
    private BarButtonItem bb_sil;
    private BarButtonItem bb_duzenle;
    private PopupMenu pp1;
    private BarButtonItem bb_kopyala;

    public MalzemeBrws() => this.InitializeComponent();

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_ekle_Click(object sender, EventArgs e)
    {
      MalzemeFrm malzemeFrm = new MalzemeFrm();
      malzemeFrm.MdiParent = this.MdiParent;
      malzemeFrm._id = "";
      malzemeFrm.Show();
    }

    private void btn_duzenle_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.grd_mlz.GetFocusedRowCellDisplayText("ID")))
        return;
      MalzemeFrm malzemeFrm = new MalzemeFrm();
      malzemeFrm.MdiParent = this.MdiParent;
      malzemeFrm._id = this.grd_mlz.GetFocusedRowCellDisplayText("ID");
      malzemeFrm._hareket_gormus = this.hareket_kontrol(this.grd_mlz.GetFocusedRowCellDisplayText("KOD"));
      malzemeFrm.Show();
    }

    private void btn_sil_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.grd_mlz.GetFocusedRowCellDisplayText("ID")))
        return;
      if (this.hareket_kontrol(this.grd_mlz.GetFocusedRowCellDisplayText("KOD")))
      {
        int num = (int) MessageBox.Show("Hareket Görmüş malzemeler silinemez.");
      }
      else
      {
        if (MessageBox.Show(this.grd_mlz.GetFocusedRowCellDisplayText("AD") + " İsimli Ürünü silmek istediğinize eminmisiniz ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
          return;
        _main.komutcalistir("DELETE FROM MALZEMELER WHERE ID = " + this.grd_mlz.GetFocusedRowCellDisplayText("ID"));
        _main.komutcalistir("DELETE FROM MALZEMEDETAY WHERE MALZEMEID = " + this.grd_mlz.GetFocusedRowCellDisplayText("ID"));
        this.setgrid();
      }
    }

    private void setgrid()
    {
      string sql_str = "SELECT [ID],[KOD],[AD],[URETICIKODU],[MARKA],[TEDARIKCI],[ANAKATEGORI],[ALTKATEGORI1],[ALTKATEGORI2] " + " FROM MALZEMELER";
      if (_main.dt_user.Rows[0]["KULLANICIADI"].ToString() != "ADMIN")
        sql_str = sql_str + " WHERE TEDARIKCI = '" + _main.dt_user.Rows[0]["TEDARIKCIADI"].ToString() + "'";
      this.dtg_mlz.DataSource = (object) _main.komutcalistir_dt(sql_str);
      this.grd_mlz.Columns["ID"].Visible = false;
      foreach (GridColumn column in (CollectionBase) this.grd_mlz.Columns)
        column.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
      this.grd_mlz.RestoreLayoutFromRegistry("DmsFuar\\MlzBrws");
    }

    private void MalzemeBrws_Load(object sender, EventArgs e) => this.set_right(_main.y_kartlar);

    private void dtg_mlz_DoubleClick(object sender, EventArgs e)
    {
      this.btn_duzenle_Click(sender, e);
    }

    private void MalzemeBrws_Activated(object sender, EventArgs e) => this.setgrid();

    private bool hareket_kontrol(string mal_kod)
    {
      bool flag = false;
      if (_main.komutcalistir_dt("SELECT * FROM SIPARISLER WHERE MALZEMEKOD = '" + mal_kod + "'").Rows.Count > 0)
        flag = true;
      return flag;
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

    private void dtg_mlz_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.pp1.ShowPopup(Control.MousePosition);
    }

    private void MalzemeBrws_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.grd_mlz.SaveLayoutToRegistry("DmsFuar\\MlzBrws");
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

    private void bb_kopyala_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (this.grd_mlz.FocusedValue != null)
        Clipboard.SetText(this.grd_mlz.FocusedValue.ToString());
      else
        Clipboard.Clear();
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
      this.btn_sil = new SimpleButton();
      this.btn_duzenle = new SimpleButton();
      this.btn_ekle = new SimpleButton();
      this.grd_mlz = new GridView();
      this.dtg_mlz = new GridControl();
      this.imgk = new RepositoryItemPictureEdit();
      this.img1 = new RepositoryItemPictureEdit();
      this.img2 = new RepositoryItemPictureEdit();
      this.img3 = new RepositoryItemPictureEdit();
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
      this.bb_kopyala = new BarButtonItem();
      this.grd_mlz.BeginInit();
      this.dtg_mlz.BeginInit();
      this.imgk.BeginInit();
      this.img1.BeginInit();
      this.img2.BeginInit();
      this.img3.BeginInit();
      this.bm1.BeginInit();
      this.pp1.BeginInit();
      this.SuspendLayout();
      this.btn_sil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_sil.Location = new Point(206, 352);
      this.btn_sil.Name = "btn_sil";
      this.btn_sil.Size = new Size(75, 33);
      this.btn_sil.TabIndex = 16;
      this.btn_sil.Text = "Sil";
      this.btn_sil.Click += new EventHandler(this.btn_sil_Click);
      this.btn_duzenle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_duzenle.Location = new Point(110, 352);
      this.btn_duzenle.Name = "btn_duzenle";
      this.btn_duzenle.Size = new Size(75, 33);
      this.btn_duzenle.TabIndex = 15;
      this.btn_duzenle.Text = "Düzenle";
      this.btn_duzenle.Click += new EventHandler(this.btn_duzenle_Click);
      this.btn_ekle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_ekle.Location = new Point(16, 352);
      this.btn_ekle.Name = "btn_ekle";
      this.btn_ekle.Size = new Size(75, 33);
      this.btn_ekle.TabIndex = 14;
      this.btn_ekle.Text = "Ekle";
      this.btn_ekle.Click += new EventHandler(this.btn_ekle_Click);
      this.grd_mlz.GridControl = this.dtg_mlz;
      this.grd_mlz.Name = "grd_mlz";
      this.grd_mlz.OptionsBehavior.Editable = false;
      this.grd_mlz.OptionsCustomization.AllowRowSizing = true;
      this.grd_mlz.OptionsSelection.MultiSelect = true;
      this.grd_mlz.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;
      this.grd_mlz.OptionsView.RowAutoHeight = true;
      this.grd_mlz.OptionsView.ShowAutoFilterRow = true;
      this.grd_mlz.OptionsView.ShowGroupPanel = false;
      this.dtg_mlz.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_mlz.Location = new Point(0, 2);
      this.dtg_mlz.MainView = (BaseView) this.grd_mlz;
      this.dtg_mlz.Name = "dtg_mlz";
      this.dtg_mlz.RepositoryItems.AddRange(new RepositoryItem[4]
      {
        (RepositoryItem) this.imgk,
        (RepositoryItem) this.img1,
        (RepositoryItem) this.img2,
        (RepositoryItem) this.img3
      });
      this.dtg_mlz.Size = new Size(791, 334);
      this.dtg_mlz.TabIndex = 13;
      this.dtg_mlz.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_mlz
      });
      this.dtg_mlz.DoubleClick += new EventHandler(this.dtg_mlz_DoubleClick);
      this.dtg_mlz.MouseUp += new MouseEventHandler(this.dtg_mlz_MouseUp);
      this.imgk.Name = "imgk";
      this.imgk.SizeMode = PictureSizeMode.Zoom;
      this.img1.Name = "img1";
      this.img1.SizeMode = PictureSizeMode.Zoom;
      this.img2.Name = "img2";
      this.img2.SizeMode = PictureSizeMode.Zoom;
      this.img3.Name = "img3";
      this.img3.SizeMode = PictureSizeMode.Zoom;
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btn_iptal.Location = new Point(704, 352);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 12;
      this.btn_iptal.Text = "Kapat";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.bm1.DockControls.Add(this.barDockControlTop);
      this.bm1.DockControls.Add(this.barDockControlBottom);
      this.bm1.DockControls.Add(this.barDockControlLeft);
      this.bm1.DockControls.Add(this.barDockControlRight);
      this.bm1.Form = (Control) this;
      this.bm1.Items.AddRange(new BarItem[4]
      {
        (BarItem) this.bb_ekle,
        (BarItem) this.bb_sil,
        (BarItem) this.bb_duzenle,
        (BarItem) this.bb_kopyala
      });
      this.bm1.MaxItemId = 9;
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = DockStyle.Top;
      this.barDockControlTop.Location = new Point(0, 0);
      this.barDockControlTop.Size = new Size(791, 0);
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = DockStyle.Bottom;
      this.barDockControlBottom.Location = new Point(0, 396);
      this.barDockControlBottom.Size = new Size(791, 0);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 0);
      this.barDockControlLeft.Size = new Size(0, 396);
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = DockStyle.Right;
      this.barDockControlRight.Location = new Point(791, 0);
      this.barDockControlRight.Size = new Size(0, 396);
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
      this.pp1.LinksPersistInfo.AddRange(new LinkPersistInfo[4]
      {
        new LinkPersistInfo((BarItem) this.bb_ekle),
        new LinkPersistInfo((BarItem) this.bb_duzenle),
        new LinkPersistInfo((BarItem) this.bb_sil),
        new LinkPersistInfo((BarItem) this.bb_kopyala, true)
      });
      this.pp1.Manager = this.bm1;
      this.pp1.Name = "pp1";
      this.bb_kopyala.Caption = "Kopyala";
      this.bb_kopyala.Id = 8;
      this.bb_kopyala.Name = "bb_kopyala";
      this.bb_kopyala.ItemClick += new ItemClickEventHandler(this.bb_kopyala_ItemClick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(791, 396);
      this.Controls.Add((Control) this.btn_sil);
      this.Controls.Add((Control) this.btn_duzenle);
      this.Controls.Add((Control) this.btn_ekle);
      this.Controls.Add((Control) this.dtg_mlz);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Controls.Add((Control) this.barDockControlRight);
      this.Controls.Add((Control) this.barDockControlBottom);
      this.Controls.Add((Control) this.barDockControlTop);
      this.MinimizeBox = false;
      this.Name = nameof (MalzemeBrws);
      this.Text = "Ürünler";
      this.WindowState = FormWindowState.Maximized;
      this.Activated += new EventHandler(this.MalzemeBrws_Activated);
      this.FormClosing += new FormClosingEventHandler(this.MalzemeBrws_FormClosing);
      this.Load += new EventHandler(this.MalzemeBrws_Load);
      this.grd_mlz.EndInit();
      this.dtg_mlz.EndInit();
      this.imgk.EndInit();
      this.img1.EndInit();
      this.img2.EndInit();
      this.img3.EndInit();
      this.bm1.EndInit();
      this.pp1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
