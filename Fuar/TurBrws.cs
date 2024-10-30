// Decompiled with JetBrains decompiler
// Type: Fuar.TurBrws
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
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
  public class TurBrws : XtraForm
  {
    private IContainer components;
    private SimpleButton btn_iptal;
    private GridControl dtg_tur;
    private GridView grd_tur;
    private RepositoryItemTextEdit txt1;
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

    public TurBrws() => this.InitializeComponent();

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void TurBrws_Load(object sender, EventArgs e) => this.set_right(_main.y_kartlar);

    private void setgrid()
    {
      this.dtg_tur.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM TURBILGI");
      this.grd_tur.Columns["ID"].Visible = false;
      this.grd_tur.RestoreLayoutFromRegistry("DmsFuar\\TurBrws");
    }

    private void btn_ekle_Click(object sender, EventArgs e)
    {
      TurFrm turFrm = new TurFrm();
      turFrm.MdiParent = this.MdiParent;
      turFrm._id = "";
      turFrm.Show();
    }

    private void btn_duzenle_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.grd_tur.GetFocusedRowCellDisplayText("ID")))
        return;
      TurFrm turFrm = new TurFrm();
      turFrm.MdiParent = this.MdiParent;
      turFrm._id = this.grd_tur.GetFocusedRowCellDisplayText("ID");
      turFrm.Show();
    }

    private void btn_sil_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.grd_tur.GetFocusedRowCellDisplayText("ID")) || MessageBox.Show(this.grd_tur.GetFocusedRowCellDisplayText("TURADI") + " İsimli Tur Şirketini silmek istediğinize eminmisiniz ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
        return;
      _main.komutcalistir("DELETE FROM TURBILGI WHERE ID = " + this.grd_tur.GetFocusedRowCellDisplayText("ID"));
      this.setgrid();
    }

    private void TurBrws_Activated(object sender, EventArgs e) => this.setgrid();

    private void dtg_tur_DoubleClick(object sender, EventArgs e)
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

    private void dtg_tur_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.pp1.ShowPopup(Control.MousePosition);
    }

    private void TurBrws_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.grd_tur.SaveLayoutToRegistry("DmsFuar\\TurBrws");
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
      this.btn_iptal = new SimpleButton();
      this.dtg_tur = new GridControl();
      this.grd_tur = new GridView();
      this.txt1 = new RepositoryItemTextEdit();
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
      this.dtg_tur.BeginInit();
      this.grd_tur.BeginInit();
      this.txt1.BeginInit();
      this.bm1.BeginInit();
      this.pp1.BeginInit();
      this.SuspendLayout();
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btn_iptal.Location = new Point(683, 368);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 2;
      this.btn_iptal.Text = "Kapat";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.dtg_tur.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_tur.Location = new Point(1, 1);
      this.dtg_tur.MainView = (BaseView) this.grd_tur;
      this.dtg_tur.Name = "dtg_tur";
      this.dtg_tur.RepositoryItems.AddRange(new RepositoryItem[1]
      {
        (RepositoryItem) this.txt1
      });
      this.dtg_tur.Size = new Size(782, 350);
      this.dtg_tur.TabIndex = 3;
      this.dtg_tur.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_tur
      });
      this.dtg_tur.DoubleClick += new EventHandler(this.dtg_tur_DoubleClick);
      this.dtg_tur.MouseUp += new MouseEventHandler(this.dtg_tur_MouseUp);
      this.grd_tur.GridControl = this.dtg_tur;
      this.grd_tur.Name = "grd_tur";
      this.grd_tur.OptionsBehavior.Editable = false;
      this.grd_tur.OptionsSelection.MultiSelect = true;
      this.grd_tur.OptionsView.ShowGroupPanel = false;
      this.txt1.AllowNullInput = DefaultBoolean.False;
      this.txt1.AutoHeight = false;
      this.txt1.CharacterCasing = CharacterCasing.Lower;
      this.txt1.Mask.MaskType = MaskType.RegEx;
      this.txt1.Mask.ShowPlaceHolders = false;
      this.txt1.Mask.UseMaskAsDisplayFormat = true;
      this.txt1.Name = "txt1";
      this.txt1.NullValuePrompt = "Geçerli mail adresini giriniz";
      this.txt1.NullValuePromptShowForEmptyValue = true;
      this.btn_sil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_sil.Location = new Point(207, 368);
      this.btn_sil.Name = "btn_sil";
      this.btn_sil.Size = new Size(75, 33);
      this.btn_sil.TabIndex = 6;
      this.btn_sil.Text = "Sil";
      this.btn_sil.Click += new EventHandler(this.btn_sil_Click);
      this.btn_duzenle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_duzenle.Location = new Point(111, 368);
      this.btn_duzenle.Name = "btn_duzenle";
      this.btn_duzenle.Size = new Size(75, 33);
      this.btn_duzenle.TabIndex = 5;
      this.btn_duzenle.Text = "Düzenle";
      this.btn_duzenle.Click += new EventHandler(this.btn_duzenle_Click);
      this.btn_ekle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_ekle.Location = new Point(17, 368);
      this.btn_ekle.Name = "btn_ekle";
      this.btn_ekle.Size = new Size(75, 33);
      this.btn_ekle.TabIndex = 4;
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
      this.barDockControlTop.Size = new Size(783, 0);
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = DockStyle.Bottom;
      this.barDockControlBottom.Location = new Point(0, 413);
      this.barDockControlBottom.Size = new Size(783, 0);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 0);
      this.barDockControlLeft.Size = new Size(0, 413);
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = DockStyle.Right;
      this.barDockControlRight.Location = new Point(783, 0);
      this.barDockControlRight.Size = new Size(0, 413);
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
      this.ClientSize = new Size(783, 413);
      this.Controls.Add((Control) this.btn_sil);
      this.Controls.Add((Control) this.btn_duzenle);
      this.Controls.Add((Control) this.btn_ekle);
      this.Controls.Add((Control) this.dtg_tur);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Controls.Add((Control) this.barDockControlRight);
      this.Controls.Add((Control) this.barDockControlBottom);
      this.Controls.Add((Control) this.barDockControlTop);
      this.MinimizeBox = false;
      this.Name = nameof (TurBrws);
      this.Text = "Tur Şirketleri";
      this.WindowState = FormWindowState.Maximized;
      this.Activated += new EventHandler(this.TurBrws_Activated);
      this.FormClosing += new FormClosingEventHandler(this.TurBrws_FormClosing);
      this.Load += new EventHandler(this.TurBrws_Load);
      this.dtg_tur.EndInit();
      this.grd_tur.EndInit();
      this.txt1.EndInit();
      this.bm1.EndInit();
      this.pp1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
