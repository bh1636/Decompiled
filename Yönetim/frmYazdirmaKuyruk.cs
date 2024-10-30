// Decompiled with JetBrains decompiler
// Type: Yönetim.frmYazdirmaKuyruk
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
  public class frmYazdirmaKuyruk : Form
  {
    private IContainer components = (IContainer) null;
    private GroupControl groupControl1;
    private GridControl gridControl1;
    private GridView gridView1;

    public frmYazdirmaKuyruk() => this.InitializeComponent();

    private void frmYazdirmaKuyruk_Load(object sender, EventArgs e)
    {
      this.gridControl1.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("SELECT EVRAKSERI,EVRAKSIRA,PRINTER,case YAZDIRILDIMI WHEN  '1' THEN 'YAZDIRILDI' WHEN '' THEN 'BEKLİYOR'   END AS 'YAZDIRILDIMI' FROM RMZ_EVRAKLISTESI  ORDER BY  case YAZDIRILDIMI WHEN  '1' THEN 'YAZDIRILDI' WHEN '' THEN 'BEKLİYOR'   END "));
    }

    private void frmYazdirmaKuyruk_LocationChanged(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmYazdirmaKuyruk));
      this.groupControl1 = new GroupControl();
      this.gridControl1 = new GridControl();
      this.gridView1 = new GridView();
      this.groupControl1.BeginInit();
      this.groupControl1.SuspendLayout();
      this.gridControl1.BeginInit();
      this.gridView1.BeginInit();
      this.SuspendLayout();
      this.groupControl1.Controls.Add((Control) this.gridControl1);
      this.groupControl1.Dock = DockStyle.Fill;
      this.groupControl1.Location = new Point(0, 0);
      this.groupControl1.LookAndFeel.Style = LookAndFeelStyle.Office2003;
      this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new Size(895, 546);
      this.groupControl1.TabIndex = 0;
      this.groupControl1.Text = "Yazıcı Kuyruk Listesi";
      this.gridControl1.Dock = DockStyle.Fill;
      this.gridControl1.Location = new Point(2, 19);
      this.gridControl1.LookAndFeel.SkinName = "Black";
      this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.gridControl1.MainView = (BaseView) this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new Size(891, 525);
      this.gridControl1.TabIndex = 0;
      this.gridControl1.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView1
      });
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsCustomization.AllowFilter = false;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.gridView1.PaintStyleName = "Skin";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(895, 546);
      this.Controls.Add((Control) this.groupControl1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmYazdirmaKuyruk);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Extra Sipariş  Sistemi";
      this.Load += new EventHandler(this.frmYazdirmaKuyruk_Load);
      this.LocationChanged += new EventHandler(this.frmYazdirmaKuyruk_LocationChanged);
      this.groupControl1.EndInit();
      this.groupControl1.ResumeLayout(false);
      this.gridControl1.EndInit();
      this.gridView1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
