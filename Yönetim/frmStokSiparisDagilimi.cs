// Decompiled with JetBrains decompiler
// Type: Yönetim.frmStokSiparisDagilimi
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Yönetim.Properties;

#nullable disable
namespace Yönetim
{
  public class frmStokSiparisDagilimi : Form
  {
    public string Rapor = "";
    private IContainer components = (IContainer) null;
    private ToolStrip toolStrip1;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton toolStripButton2;
    private GridControl gridControl1;
    private GridView gridView1;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton toolStripButton1;

    public frmStokSiparisDagilimi() => this.InitializeComponent();

    private void frmStokSiparisDagilimi_Load(object sender, EventArgs e)
    {
      if (this.Rapor == "1")
      {
        this.gridControl1.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("SELECT \r\nsto_kod  AS 'Kod',\r\nsto_isim AS  'Isim',sto_birim as 'Birim',\r\nISNULL((SELECT sum(sip_tutar) FROM SIPARISLER WHERE sip_stok_kod=sto_kod),0) AS 'Siparis Tutari',\r\nISNULL((SELECT sum(sip_miktar) FROM SIPARISLER WHERE sip_stok_kod=sto_kod),0) AS 'Miktarı'\r\nFROM STOKLAR "));
        this.gridView1.BestFitColumns();
      }
      if (this.Rapor == "2")
      {
        this.gridControl1.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("\r\nSELECT \r\ncari_kod as 'KOD',\r\nCARI_HESAPLAR.cari_unvan1 AS 'İSİM',\r\nround(SUM(sip_tutar),2) AS 'TUTAR',\r\nSUM(sip_miktar)  AS 'MIKTAR'\r\nFROM SIPARISLER \r\nJOIN CARI_HESAPLAR \r\nON CARI_HESAPLAR.cari_kod=sip_musteri_kod\r\nGROUP BY cari_kod,\r\nCARI_HESAPLAR.cari_unvan1\r\n"));
        this.gridView1.BestFitColumns();
      }
      for (int index = 0; index < this.gridView1.Columns.Count; ++index)
      {
        if (this.gridView1.Columns[index].ColumnType.FullName != "System.String" && this.gridView1.Columns[index].ColumnType.FullName != "System.Int32" && this.gridView1.Columns[index].FieldName != "sip_miktar" && this.gridView1.Columns[index].FieldName != "sip_iskonto_1" && this.gridView1.Columns[index].FieldName != "sip_iskonto_2" && this.gridView1.Columns[index].FieldName != "Miktarı")
        {
          this.gridView1.Columns[index].DisplayFormat.FormatType = FormatType.Numeric;
          this.gridView1.Columns[index].DisplayFormat.FormatString = "C";
        }
      }
      for (int index = 0; index < ((DataTable) this.gridControl1.DataSource).Columns.Count; ++index)
      {
        if (((DataTable) this.gridControl1.DataSource).Columns[index].DataType.Name == "Double" || ((DataTable) this.gridControl1.DataSource).Columns[index].DataType.Name == "Decimal")
        {
          if (this.gridView1.Columns[index].FieldName != "Miktarı")
          {
            this.gridView1.Columns[((DataTable) this.gridControl1.DataSource).Columns[index].Caption].DisplayFormat.FormatString = "D";
            this.gridView1.Columns[((DataTable) this.gridControl1.DataSource).Columns[index].Caption].DisplayFormat.FormatType = FormatType.Numeric;
            this.gridView1.Columns[((DataTable) this.gridControl1.DataSource).Columns[index].Caption].SummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,##0.00} TL");
          }
          else
          {
            this.gridView1.Columns[((DataTable) this.gridControl1.DataSource).Columns[index].Caption].DisplayFormat.FormatString = "D";
            this.gridView1.Columns[((DataTable) this.gridControl1.DataSource).Columns[index].Caption].DisplayFormat.FormatType = FormatType.Numeric;
            this.gridView1.Columns[((DataTable) this.gridControl1.DataSource).Columns[index].Caption].SummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,##0}");
          }
        }
      }
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
      this.gridControl1.ShowPreview();
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Excelle Aktar |*.xls";
      int num = (int) saveFileDialog.ShowDialog();
      this.gridControl1.ExportToExcelOld(saveFileDialog.FileName);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      GridLevelNode gridLevelNode = new GridLevelNode();
      this.toolStrip1 = new ToolStrip();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripButton2 = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripButton1 = new ToolStripButton();
      this.gridControl1 = new GridControl();
      this.gridView1 = new GridView();
      this.toolStrip1.SuspendLayout();
      this.gridControl1.BeginInit();
      this.gridView1.BeginInit();
      this.SuspendLayout();
      this.toolStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripButton2,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripButton1
      });
      this.toolStrip1.Location = new Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(891, 25);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.toolStripButton2.Image = (Image) Resources.print;
      this.toolStripButton2.ImageTransparentColor = Color.Magenta;
      this.toolStripButton2.Name = "toolStripButton2";
      this.toolStripButton2.Size = new Size(59, 22);
      this.toolStripButton2.Text = "Yazdir";
      this.toolStripButton2.Click += new EventHandler(this.toolStripButton2_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 25);
      this.toolStripButton1.Image = (Image) Resources.Excel;
      this.toolStripButton1.ImageTransparentColor = Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new Size(93, 22);
      this.toolStripButton1.Text = "Excelle Aktar";
      this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click);
      this.gridControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      gridLevelNode.RelationName = "Level1";
      this.gridControl1.LevelTree.Nodes.AddRange(new GridLevelNode[1]
      {
        gridLevelNode
      });
      this.gridControl1.Location = new Point(2, 29);
      this.gridControl1.LookAndFeel.SkinName = "Liquid Sky";
      this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.gridControl1.MainView = (BaseView) this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new Size(886, 513);
      this.gridControl1.TabIndex = 1;
      this.gridControl1.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView1
      });
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsView.ShowAutoFilterRow = true;
      this.gridView1.OptionsView.ShowFooter = true;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(891, 545);
      this.Controls.Add((Control) this.gridControl1);
      this.Controls.Add((Control) this.toolStrip1);
      this.Name = nameof (frmStokSiparisDagilimi);
      this.Text = "Stok Sipariş Dağılımı";
      this.Load += new EventHandler(this.frmStokSiparisDagilimi_Load);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.gridControl1.EndInit();
      this.gridView1.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
