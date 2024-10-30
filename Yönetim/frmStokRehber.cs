// Decompiled with JetBrains decompiler
// Type: Yönetim.frmStokRehber
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
  public class frmStokRehber : Form
  {
    public string kod = "";
    public string isim = "";
    public int kdv = 0;
    public string birimAdi = "";
    public string fiyat = "";
    public string isk1 = "";
    public string isk2 = "";
    private IContainer components = (IContainer) null;
    private GridControl gridControl1;
    private GridView gridView1;
    private GridColumn gridColumn1;
    private GridColumn gridColumn2;
    private GridColumn gridColumn3;
    private GridColumn gridColumn4;
    private GridColumn gridColumn5;

    public frmStokRehber() => this.InitializeComponent();

    private void frmStokRehber_Load(object sender, EventArgs e)
    {
      this.gridControl1.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("SELECT * FROM extraw_STOKLISTESI Where  sto_birim1_ad=SKBIRIM"));
    }

    private void gridControl1_DoubleClick(object sender, EventArgs e)
    {
      if (this.gridView1.SelectedRowsCount <= 0)
        return;
      this.birimAdi = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "sto_birim1_ad").ToString();
      this.kod = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "sto_kod").ToString();
      this.isim = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "sto_isim").ToString();
      this.isk2 = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "isk_isk2_yuzde").ToString();
      this.isk1 = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "isk_isk1_yuzde").ToString();
      this.kdv = Convert.ToInt32(this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "sto_perakende_vergi").ToString());
      this.fiyat = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "sfyt_fiyat").ToString();
      this.Close();
    }

    private void gridView1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.gridControl1_DoubleClick(sender, new EventArgs());
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmStokRehber));
      this.gridControl1 = new GridControl();
      this.gridView1 = new GridView();
      this.gridColumn1 = new GridColumn();
      this.gridColumn2 = new GridColumn();
      this.gridColumn3 = new GridColumn();
      this.gridColumn4 = new GridColumn();
      this.gridColumn5 = new GridColumn();
      this.gridControl1.BeginInit();
      this.gridView1.BeginInit();
      this.SuspendLayout();
      this.gridControl1.Dock = DockStyle.Fill;
      this.gridControl1.Location = new Point(0, 0);
      this.gridControl1.MainView = (BaseView) this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new Size(826, 545);
      this.gridControl1.TabIndex = 0;
      this.gridControl1.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView1
      });
      this.gridControl1.DoubleClick += new EventHandler(this.gridControl1_DoubleClick);
      this.gridView1.Columns.AddRange(new GridColumn[5]
      {
        this.gridColumn1,
        this.gridColumn2,
        this.gridColumn3,
        this.gridColumn4,
        this.gridColumn5
      });
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsBehavior.Editable = false;
      this.gridView1.OptionsCustomization.AllowGroup = false;
      this.gridView1.OptionsView.ShowAutoFilterRow = true;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.gridView1.KeyDown += new KeyEventHandler(this.gridView1_KeyDown);
      this.gridColumn1.Caption = "STOK KOD";
      this.gridColumn1.FieldName = "sto_kod";
      this.gridColumn1.Name = "gridColumn1";
      this.gridColumn1.Visible = true;
      this.gridColumn1.VisibleIndex = 0;
      this.gridColumn1.Width = 94;
      this.gridColumn2.Caption = "STOK ADI";
      this.gridColumn2.FieldName = "sto_isim";
      this.gridColumn2.Name = "gridColumn2";
      this.gridColumn2.Visible = true;
      this.gridColumn2.VisibleIndex = 1;
      this.gridColumn2.Width = 294;
      this.gridColumn3.Caption = "sto_perakende_vergi";
      this.gridColumn3.FieldName = "sto_perakende_vergi";
      this.gridColumn3.Name = "gridColumn3";
      this.gridColumn4.Caption = "BİRİM";
      this.gridColumn4.FieldName = "sto_birim1_ad";
      this.gridColumn4.Name = "gridColumn4";
      this.gridColumn4.Visible = true;
      this.gridColumn4.VisibleIndex = 2;
      this.gridColumn5.Caption = "sto_fiyat";
      this.gridColumn5.FieldName = "sto_fiyat";
      this.gridColumn5.Name = "gridColumn5";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(826, 545);
      this.Controls.Add((Control) this.gridControl1);
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmStokRehber);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Extra Sipariş  Sistemi";
      this.Load += new EventHandler(this.frmStokRehber_Load);
      this.gridControl1.EndInit();
      this.gridView1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
