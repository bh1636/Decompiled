// Decompiled with JetBrains decompiler
// Type: Yönetim.frmCariRehber
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
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
  public class frmCariRehber : Form
  {
    public string CariKod = "";
    public string CariIsim = "";
    private IContainer components = (IContainer) null;
    private GridControl gridControl1;
    private GridView gridView1;
    private GridColumn gridColumn2;
    private GridColumn gridColumn1;

    public frmCariRehber() => this.InitializeComponent();

    private void frmCariRehber_Load(object sender, EventArgs e)
    {
      this.gridControl1.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("select cari_kod,cari_unvan1 from CARI_HESAPLAR"));
    }

    private void gridView1_DoubleClick(object sender, EventArgs e)
    {
      if (this.gridView1.SelectedRowsCount <= 0)
        return;
      this.CariKod = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "cari_kod").ToString();
      this.CariIsim = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "cari_unvan1").ToString();
      this.Close();
    }

    private void gridView1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.gridView1_DoubleClick(sender, new EventArgs());
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmCariRehber));
      this.gridControl1 = new GridControl();
      this.gridView1 = new GridView();
      this.gridColumn2 = new GridColumn();
      this.gridColumn1 = new GridColumn();
      this.gridControl1.BeginInit();
      this.gridView1.BeginInit();
      this.SuspendLayout();
      this.gridControl1.Dock = DockStyle.Fill;
      this.gridControl1.Location = new Point(0, 0);
      this.gridControl1.LookAndFeel.SkinName = "Liquid Sky";
      this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.gridControl1.MainView = (BaseView) this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new Size(385, 559);
      this.gridControl1.TabIndex = 0;
      this.gridControl1.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView1
      });
      this.gridView1.Columns.AddRange(new GridColumn[2]
      {
        this.gridColumn2,
        this.gridColumn1
      });
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
      this.gridView1.OptionsBehavior.Editable = false;
      this.gridView1.OptionsView.ShowAutoFilterRow = true;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.gridView1.KeyDown += new KeyEventHandler(this.gridView1_KeyDown);
      this.gridView1.DoubleClick += new EventHandler(this.gridView1_DoubleClick);
      this.gridColumn2.Caption = "Cari Kod";
      this.gridColumn2.FieldName = "cari_kod";
      this.gridColumn2.Name = "gridColumn2";
      this.gridColumn2.Visible = true;
      this.gridColumn2.VisibleIndex = 0;
      this.gridColumn2.Width = 109;
      this.gridColumn1.Caption = "Cari Ad";
      this.gridColumn1.FieldName = "cari_unvan1";
      this.gridColumn1.Name = "gridColumn1";
      this.gridColumn1.Visible = true;
      this.gridColumn1.VisibleIndex = 1;
      this.gridColumn1.Width = 243;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(385, 559);
      this.Controls.Add((Control) this.gridControl1);
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmCariRehber);
      this.Text = "Cari Rehber";
      this.Load += new EventHandler(this.frmCariRehber_Load);
      this.gridControl1.EndInit();
      this.gridView1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
