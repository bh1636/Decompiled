// Decompiled with JetBrains decompiler
// Type: Yönetim.frmCariHesapRaporu
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Yönetim
{
  public class frmCariHesapRaporu : Form
  {
    private int Yukseklik = 0;
    private int Genislik = 0;
    private IContainer components = (IContainer) null;
    private SplitContainer splitContainer1;
    private GroupControl groupControl1;
    private GroupControl groupControl2;
    private GridControl gridControl1;
    private GridView gridView1;
    private GridControl gridControl2;
    private GridView gridView2;

    public frmCariHesapRaporu() => this.InitializeComponent();

    private void frmCariHesapRaporu_Load(object sender, EventArgs e)
    {
      this.gridControl1.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("SELECT cari_kod AS 'KOD',\r\n       cari_unvan1 AS 'CARI ISIM',\r\n       cari_adres AS 'ADRES',\r\n       cari_il AS 'IL',\r\n       cari_ilce AS 'ILCE',\r\n       cari_bakiye AS 'BAKIYE'\r\nFROM   CARI_HESAPLAR"));
      this.gridView1.BestFitColumns();
    }

    private void frmCariHesapRaporu_LocationChanged(object sender, EventArgs e)
    {
    }

    private void gridView1_DoubleClick(object sender, EventArgs e)
    {
      try
      {
        if (this.gridView1.SelectedRowsCount <= 0)
          return;
        this.gridControl2.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("SELECT cha_tarih AS 'TARIH',\r\n       cha_modul AS 'MODUL',\r\n       cha_evraktip AS 'EVRAKTIP',\r\n       cha_tutar AS 'TUTAR',\r\n       cha_kur AS 'KUR',\r\n       cha_tip AS 'TIP'\r\nFROM   CARI_HESAP_HAREKETLERI\r\nWHERE  cha_carikod = '" + this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "KOD").ToString() + "'"));
      }
      catch
      {
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmCariHesapRaporu));
      this.splitContainer1 = new SplitContainer();
      this.groupControl1 = new GroupControl();
      this.gridControl1 = new GridControl();
      this.gridView1 = new GridView();
      this.groupControl2 = new GroupControl();
      this.gridControl2 = new GridControl();
      this.gridView2 = new GridView();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.groupControl1.BeginInit();
      this.groupControl1.SuspendLayout();
      this.gridControl1.BeginInit();
      this.gridView1.BeginInit();
      this.groupControl2.BeginInit();
      this.groupControl2.SuspendLayout();
      this.gridControl2.BeginInit();
      this.gridView2.BeginInit();
      this.SuspendLayout();
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = Orientation.Horizontal;
      this.splitContainer1.Panel1.Controls.Add((Control) this.groupControl1);
      this.splitContainer1.Panel2.Controls.Add((Control) this.groupControl2);
      this.splitContainer1.Size = new Size(1177, 657);
      this.splitContainer1.SplitterDistance = 327;
      this.splitContainer1.TabIndex = 0;
      this.groupControl1.Controls.Add((Control) this.gridControl1);
      this.groupControl1.Dock = DockStyle.Fill;
      this.groupControl1.Location = new Point(0, 0);
      this.groupControl1.LookAndFeel.Style = LookAndFeelStyle.Office2003;
      this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new Size(1177, 327);
      this.groupControl1.TabIndex = 0;
      this.groupControl1.Text = "Cari Listesi";
      this.gridControl1.Dock = DockStyle.Fill;
      this.gridControl1.Location = new Point(2, 19);
      this.gridControl1.MainView = (BaseView) this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new Size(1173, 306);
      this.gridControl1.TabIndex = 0;
      this.gridControl1.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView1
      });
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsBehavior.Editable = false;
      this.gridView1.OptionsView.ShowAutoFilterRow = true;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.gridView1.DoubleClick += new EventHandler(this.gridView1_DoubleClick);
      this.groupControl2.Controls.Add((Control) this.gridControl2);
      this.groupControl2.Dock = DockStyle.Fill;
      this.groupControl2.Location = new Point(0, 0);
      this.groupControl2.LookAndFeel.Style = LookAndFeelStyle.Office2003;
      this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl2.Name = "groupControl2";
      this.groupControl2.Size = new Size(1177, 326);
      this.groupControl2.TabIndex = 1;
      this.groupControl2.Text = "Cari Hesap Hareketleri";
      this.gridControl2.Dock = DockStyle.Fill;
      this.gridControl2.Location = new Point(2, 19);
      this.gridControl2.MainView = (BaseView) this.gridView2;
      this.gridControl2.Name = "gridControl2";
      this.gridControl2.Size = new Size(1173, 305);
      this.gridControl2.TabIndex = 1;
      this.gridControl2.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView2
      });
      this.gridView2.GridControl = this.gridControl2;
      this.gridView2.Name = "gridView2";
      this.gridView2.OptionsBehavior.Editable = false;
      this.gridView2.OptionsView.ShowGroupPanel = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1177, 657);
      this.Controls.Add((Control) this.splitContainer1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmCariHesapRaporu);
      this.Text = "Extra Sipariş  Sistemi";
      this.Load += new EventHandler(this.frmCariHesapRaporu_Load);
      this.LocationChanged += new EventHandler(this.frmCariHesapRaporu_LocationChanged);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.groupControl1.EndInit();
      this.groupControl1.ResumeLayout(false);
      this.gridControl1.EndInit();
      this.gridView1.EndInit();
      this.groupControl2.EndInit();
      this.groupControl2.ResumeLayout(false);
      this.gridControl2.EndInit();
      this.gridView2.EndInit();
      this.ResumeLayout(false);
    }
  }
}
