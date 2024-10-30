// Decompiled with JetBrains decompiler
// Type: Fuar.RaporTanimlariBrws
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class RaporTanimlariBrws : XtraForm
  {
    private IContainer components;
    private GridControl dtg_raporlar;
    private GridView grd_raporlar;
    private SimpleButton btn_kapat;
    private SimpleButton btn_sil;
    private SimpleButton btn_duzenle;
    private SimpleButton btn_ekle;
    private GridColumn g_id;
    private GridColumn g_ad;
    private GridColumn g_bilgi;
    private GridColumn g_tip;
    private GridColumn g_adduser;
    private GridColumn g_adddate;
    private GridColumn g_changeuser;
    private GridColumn g_changedate;
    private BarManager bm1;
    private BarDockControl barDockControlTop;
    private BarDockControl barDockControlBottom;
    private BarDockControl barDockControlLeft;
    private BarDockControl barDockControlRight;
    private BarButtonItem bb_ekle;
    private BarButtonItem bb_sil;
    private BarButtonItem bb_duzenle;
    private PopupMenu pp1;

    public RaporTanimlariBrws() => this.InitializeComponent();

    private void btn_kapat_Click(object sender, EventArgs e) => this.Close();

    private void RaporTanimlariBrws_Load(object sender, EventArgs e)
    {
    }

    private void btn_ekle_Click(object sender, EventArgs e)
    {
      RaporTanim raporTanim = new RaporTanim();
      raporTanim.MdiParent = this.MdiParent;
      raporTanim.Show();
    }

    private void btn_duzenle_Click(object sender, EventArgs e)
    {
      try
      {
        string rowCellDisplayText = this.grd_raporlar.GetFocusedRowCellDisplayText("ID");
        if (string.IsNullOrEmpty(rowCellDisplayText))
          return;
        RaporTanim raporTanim = new RaporTanim();
        raporTanim.MdiParent = this.MdiParent;
        raporTanim.rapor_id = rowCellDisplayText;
        raporTanim.Show();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void btn_sil_Click(object sender, EventArgs e)
    {
      try
      {
        string rowCellDisplayText = this.grd_raporlar.GetFocusedRowCellDisplayText("ID");
        if (string.IsNullOrEmpty(rowCellDisplayText) || MessageBox.Show(this.grd_raporlar.GetFocusedRowCellDisplayText("REPORTNAME") + " isimli raporu silmek istediğinize eminmisiniz ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
          return;
        _main.komutcalistir("DELETE FROM RAPORLAR WHERE ID = " + rowCellDisplayText + " " + "DELETE FROM RAPORPARAMS WHERE REPORTID = " + rowCellDisplayText);
        this.get_data();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void RaporTanimlariBrws_Activated(object sender, EventArgs e) => this.get_data();

    private void get_data()
    {
      this.dtg_raporlar.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM RAPORLAR");
    }

    private void dtg_raporlar_DoubleClick(object sender, EventArgs e)
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

    private void dtg_raporlar_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.pp1.ShowPopup(Control.MousePosition);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.dtg_raporlar = new GridControl();
      this.grd_raporlar = new GridView();
      this.g_id = new GridColumn();
      this.g_ad = new GridColumn();
      this.g_bilgi = new GridColumn();
      this.g_tip = new GridColumn();
      this.g_adduser = new GridColumn();
      this.g_adddate = new GridColumn();
      this.g_changeuser = new GridColumn();
      this.g_changedate = new GridColumn();
      this.btn_kapat = new SimpleButton();
      this.btn_sil = new SimpleButton();
      this.btn_duzenle = new SimpleButton();
      this.btn_ekle = new SimpleButton();
      this.bm1 = new BarManager();
      this.barDockControlTop = new BarDockControl();
      this.barDockControlBottom = new BarDockControl();
      this.barDockControlLeft = new BarDockControl();
      this.barDockControlRight = new BarDockControl();
      this.bb_ekle = new BarButtonItem();
      this.bb_sil = new BarButtonItem();
      this.bb_duzenle = new BarButtonItem();
      this.pp1 = new PopupMenu();
      this.dtg_raporlar.BeginInit();
      this.grd_raporlar.BeginInit();
      this.bm1.BeginInit();
      this.pp1.BeginInit();
      this.SuspendLayout();
      this.dtg_raporlar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_raporlar.Location = new Point(1, 0);
      this.dtg_raporlar.MainView = (BaseView) this.grd_raporlar;
      this.dtg_raporlar.Name = "dtg_raporlar";
      this.dtg_raporlar.Size = new Size(1064, 428);
      this.dtg_raporlar.TabIndex = 0;
      this.dtg_raporlar.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_raporlar
      });
      this.dtg_raporlar.DoubleClick += new EventHandler(this.dtg_raporlar_DoubleClick);
      this.dtg_raporlar.MouseUp += new MouseEventHandler(this.dtg_raporlar_MouseUp);
      this.grd_raporlar.Columns.AddRange(new GridColumn[8]
      {
        this.g_id,
        this.g_ad,
        this.g_bilgi,
        this.g_tip,
        this.g_adduser,
        this.g_adddate,
        this.g_changeuser,
        this.g_changedate
      });
      this.grd_raporlar.GridControl = this.dtg_raporlar;
      this.grd_raporlar.Name = "grd_raporlar";
      this.grd_raporlar.OptionsBehavior.Editable = false;
      this.grd_raporlar.OptionsBehavior.ReadOnly = true;
      this.grd_raporlar.OptionsCustomization.AllowColumnMoving = false;
      this.grd_raporlar.OptionsCustomization.AllowFilter = false;
      this.grd_raporlar.OptionsCustomization.AllowGroup = false;
      this.grd_raporlar.OptionsMenu.EnableColumnMenu = false;
      this.grd_raporlar.OptionsMenu.EnableFooterMenu = false;
      this.grd_raporlar.OptionsMenu.EnableGroupPanelMenu = false;
      this.grd_raporlar.OptionsView.ShowGroupPanel = false;
      this.g_id.Caption = "ID";
      this.g_id.FieldName = "ID";
      this.g_id.Name = "g_id";
      this.g_id.Visible = true;
      this.g_id.VisibleIndex = 0;
      this.g_ad.Caption = "Rapor Adı";
      this.g_ad.FieldName = "REPORTNAME";
      this.g_ad.Name = "g_ad";
      this.g_ad.Visible = true;
      this.g_ad.VisibleIndex = 1;
      this.g_bilgi.Caption = "Rapor Bilgileri";
      this.g_bilgi.FieldName = "REPORTINFO";
      this.g_bilgi.Name = "g_bilgi";
      this.g_bilgi.Visible = true;
      this.g_bilgi.VisibleIndex = 2;
      this.g_tip.Caption = "Rapor Tipi";
      this.g_tip.FieldName = "REPORTTYPE";
      this.g_tip.Name = "g_tip";
      this.g_tip.Visible = true;
      this.g_tip.VisibleIndex = 7;
      this.g_adduser.Caption = "Ekleyen Kullanıcı";
      this.g_adduser.FieldName = "ADDUSER";
      this.g_adduser.Name = "g_adduser";
      this.g_adduser.Visible = true;
      this.g_adduser.VisibleIndex = 3;
      this.g_adddate.Caption = "Eklenme Tarihi";
      this.g_adddate.FieldName = "ADDDATE";
      this.g_adddate.Name = "g_adddate";
      this.g_adddate.Visible = true;
      this.g_adddate.VisibleIndex = 4;
      this.g_changeuser.Caption = "En Son Değiştiren Kullanıcı";
      this.g_changeuser.FieldName = "CHANGEDUSER";
      this.g_changeuser.Name = "g_changeuser";
      this.g_changeuser.Visible = true;
      this.g_changeuser.VisibleIndex = 5;
      this.g_changedate.Caption = "En Son Değiştirilme Tarihi";
      this.g_changedate.FieldName = "CHANGEDATE";
      this.g_changedate.Name = "g_changedate";
      this.g_changedate.Visible = true;
      this.g_changedate.VisibleIndex = 6;
      this.btn_kapat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btn_kapat.Location = new Point(979, 441);
      this.btn_kapat.Name = "btn_kapat";
      this.btn_kapat.Size = new Size(75, 33);
      this.btn_kapat.TabIndex = 8;
      this.btn_kapat.Text = "Kapat";
      this.btn_kapat.Click += new EventHandler(this.btn_kapat_Click);
      this.btn_sil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_sil.Location = new Point(219, 441);
      this.btn_sil.Name = "btn_sil";
      this.btn_sil.Size = new Size(75, 33);
      this.btn_sil.TabIndex = 7;
      this.btn_sil.Text = "Sil";
      this.btn_sil.Click += new EventHandler(this.btn_sil_Click);
      this.btn_duzenle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_duzenle.Location = new Point(115, 441);
      this.btn_duzenle.Name = "btn_duzenle";
      this.btn_duzenle.Size = new Size(75, 33);
      this.btn_duzenle.TabIndex = 6;
      this.btn_duzenle.Text = "Düzenle";
      this.btn_duzenle.Click += new EventHandler(this.btn_duzenle_Click);
      this.btn_ekle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_ekle.Location = new Point(9, 441);
      this.btn_ekle.Name = "btn_ekle";
      this.btn_ekle.Size = new Size(75, 33);
      this.btn_ekle.TabIndex = 5;
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
      this.barDockControlTop.Size = new Size(1066, 0);
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = DockStyle.Bottom;
      this.barDockControlBottom.Location = new Point(0, 486);
      this.barDockControlBottom.Size = new Size(1066, 0);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 0);
      this.barDockControlLeft.Size = new Size(0, 486);
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = DockStyle.Right;
      this.barDockControlRight.Location = new Point(1066, 0);
      this.barDockControlRight.Size = new Size(0, 486);
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
      this.ClientSize = new Size(1066, 486);
      this.Controls.Add((Control) this.btn_kapat);
      this.Controls.Add((Control) this.btn_sil);
      this.Controls.Add((Control) this.btn_duzenle);
      this.Controls.Add((Control) this.btn_ekle);
      this.Controls.Add((Control) this.dtg_raporlar);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Controls.Add((Control) this.barDockControlRight);
      this.Controls.Add((Control) this.barDockControlBottom);
      this.Controls.Add((Control) this.barDockControlTop);
      this.Name = nameof (RaporTanimlariBrws);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Tanımlı Raporlar";
      this.WindowState = FormWindowState.Maximized;
      this.Activated += new EventHandler(this.RaporTanimlariBrws_Activated);
      this.Load += new EventHandler(this.RaporTanimlariBrws_Load);
      this.dtg_raporlar.EndInit();
      this.grd_raporlar.EndInit();
      this.bm1.EndInit();
      this.pp1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
