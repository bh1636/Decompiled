// Decompiled with JetBrains decompiler
// Type: Yönetim.frmStokFiyatGuncelle
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Yönetim.Properties;

#nullable disable
namespace Yönetim
{
  public class frmStokFiyatGuncelle : Form
  {
    private DataTable dtListesi = (DataTable) null;
    private IContainer components = (IContainer) null;
    private GridControl gridControl1;
    private GridView gridView1;
    private GridColumn gridColumn1;
    private GridColumn gridColumn2;
    private GridColumn gridColumn3;
    private GridColumn gridColumn4;
    private ToolStrip toolStrip1;
    private ToolStripButton toolStripButton1;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton toolStripButton2;
    private GridColumn gridColumn5;
    private GridColumn gridColumn6;
    private GridColumn gridColumn7;
    private RepositoryItemComboBox repositoryItemComboBox1;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton toolStripButton3;
    private ProgressBar progressBar1;
    private GridColumn gridColumn8;
    private GridColumn gridColumn9;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripButton toolStripButton4;

    public frmStokFiyatGuncelle() => this.InitializeComponent();

    private void frmStokFiyatGuncelle_Load(object sender, EventArgs e)
    {
      this.dtListesi = DBManager.sqlGetDataTable(new SqlCommand("Select * From extraW_FiyatListesi"));
      this.gridControl1.DataSource = (object) this.dtListesi;
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Excell Dosya 2000-2003 | *.xls";
      int num = (int) saveFileDialog.ShowDialog();
      if (!(saveFileDialog.FileName != ""))
        return;
      this.gridControl1.ExportToExcelOld(saveFileDialog.FileName);
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Excell Dosya 2000-2003 | *.xls";
      int num = (int) openFileDialog.ShowDialog();
      if (!(openFileDialog.FileName != ""))
        return;
      OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
      oleDbDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM [FIYAT$]", new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source='" + openFileDialog.FileName + "';Extended Properties=Excel 8.0;"));
      this.dtListesi.Rows.Clear();
      Application.DoEvents();
      oleDbDataAdapter.Fill(this.dtListesi);
    }

    private void toolStripButton3_Click(object sender, EventArgs e)
    {
      this.progressBar1.Maximum = this.dtListesi.Rows.Count;
      this.progressBar1.Minimum = 0;
      for (int index = 0; index < this.dtListesi.Rows.Count; ++index)
      {
        SqlCommand mCommand1 = new SqlCommand();
        mCommand1.CommandText = "SELECT COUNT(*) FROM FIYAT_LISTESI WHERE sfyt_stokkod=@sfyt_stokkod";
        mCommand1.Parameters.AddWithValue("@sfyt_stokkod", (object) this.dtListesi.Rows[index]["STOK KOD"].ToString());
        if (DBManager.sqlGetScalarValue(mCommand1) > 0)
        {
          SqlCommand mCommand2 = new SqlCommand();
          mCommand2.CommandText = "UPDATE FIYAT_LISTESI SET sfyt_fiyat=@sfyt_fiyat,sfyt_iskonto1 = @isk1,sfyt_iskonto2 =@isk2,sfiyat_doviz = @doviz WHERE sfyt_stokkod=@sfyt_stokkod";
          mCommand2.Parameters.AddWithValue("@sfyt_fiyat", (object) Convert.ToDouble(this.dtListesi.Rows[index]["FIYAT"]));
          mCommand2.Parameters.AddWithValue("@isk1", (object) Convert.ToInt32(this.dtListesi.Rows[index]["ISKONTO 1"]));
          mCommand2.Parameters.AddWithValue("@isk2", (object) Convert.ToInt32(this.dtListesi.Rows[index]["ISKONTO 2"]));
          int num = 0;
          if (this.dtListesi.Rows[index]["DOVIZ TIPI"].ToString() == "TL")
            num = 0;
          if (this.dtListesi.Rows[index]["DOVIZ TIPI"].ToString() == "USD")
            num = 1;
          if (this.dtListesi.Rows[index]["DOVIZ TIPI"].ToString() == "EURO")
            num = 2;
          mCommand2.Parameters.AddWithValue("@doviz", (object) num);
          mCommand2.Parameters.AddWithValue("@sfyt_stokkod", this.dtListesi.Rows[index]["STOK KOD"]);
          DBManager.sqlRunCommand(mCommand2);
          this.progressBar1.Value = index;
          Application.DoEvents();
        }
        else
        {
          SqlCommand mCommand3 = new SqlCommand();
          mCommand3.CommandText = "INSERT INTO FIYAT_LISTESI\r\n                                            (\r\n\t                                            sfyt_Recno,\r\n\t                                            sfyt_no,\r\n\t                                            sfyt_stokkod,\r\n\t                                            sfyt_iskonto1,\r\n\t                                            sfyt_iskonto2,\r\n\t                                            sfyt_fiyat,\r\n\t                                            sfiyat_doviz \r\n                                             \r\n                                            )\r\n                                            VALUES\r\n                                            (\r\n\t                                            0,\r\n\t                                            0,\r\n\t                                            @sfyt_stokkod,\r\n\t                                            @sfyt_iskonto1,\r\n\t                                            @sfyt_iskonto2,\r\n\t                                            @sfyt_fiyat,\r\n\t                                            @sfiyat_doviz\r\n                                            )";
          mCommand3.Parameters.AddWithValue("@sfyt_fiyat", (object) Convert.ToDouble(this.dtListesi.Rows[index]["FIYAT"]));
          mCommand3.Parameters.AddWithValue("@sfyt_iskonto1", (object) Convert.ToInt32(this.dtListesi.Rows[index]["ISKONTO 1"]));
          mCommand3.Parameters.AddWithValue("@sfyt_iskonto2", (object) Convert.ToInt32(this.dtListesi.Rows[index]["ISKONTO 2"]));
          int num = 0;
          if (this.dtListesi.Rows[index]["DOVIZ TIPI"].ToString() == "TL")
            num = 0;
          if (this.dtListesi.Rows[index]["DOVIZ TIPI"].ToString() == "USD")
            num = 1;
          if (this.dtListesi.Rows[index]["DOVIZ TIPI"].ToString() == "EURO")
            num = 2;
          mCommand3.Parameters.AddWithValue("@sfiyat_doviz", (object) num);
          mCommand3.Parameters.AddWithValue("@sfyt_stokkod", this.dtListesi.Rows[index]["STOK KOD"]);
          DBManager.sqlRunCommand(mCommand3);
          this.progressBar1.Value = index;
          Application.DoEvents();
        }
      }
      int num1 = (int) MessageBox.Show("Fiyat Güncelleme İşlemi Tamamlandı");
    }

    private void toolStripButton4_Click(object sender, EventArgs e)
    {
      this.progressBar1.Maximum = this.dtListesi.Rows.Count;
      this.progressBar1.Minimum = 0;
      for (int index = 0; index < this.dtListesi.Rows.Count; ++index)
      {
        this.gridView1.FocusedRowHandle = index;
        Application.DoEvents();
        SqlCommand mCommand = new SqlCommand("UPDATE STOKLAR SET PROMOSYONORANI=@PROMOSYONORANI,PERAKENDE_PROMOSYON=@PERAKENDE_PROMOSYON WHERE sto_kod=@kod");
        mCommand.Parameters.AddWithValue("@PROMOSYONORANI", (object) this.dtListesi.Rows[index]["TOPTANCI"].ToString());
        mCommand.Parameters.AddWithValue("@PERAKENDE_PROMOSYON", (object) this.dtListesi.Rows[index]["PERAKENDE"].ToString());
        mCommand.Parameters.AddWithValue("@kod", (object) this.dtListesi.Rows[index]["STOK KOD"].ToString());
        DBManager.sqlRunCommand(mCommand);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmStokFiyatGuncelle));
      this.gridControl1 = new GridControl();
      this.gridView1 = new GridView();
      this.gridColumn1 = new GridColumn();
      this.gridColumn2 = new GridColumn();
      this.gridColumn3 = new GridColumn();
      this.gridColumn4 = new GridColumn();
      this.repositoryItemComboBox1 = new RepositoryItemComboBox();
      this.gridColumn5 = new GridColumn();
      this.gridColumn6 = new GridColumn();
      this.gridColumn7 = new GridColumn();
      this.gridColumn8 = new GridColumn();
      this.gridColumn9 = new GridColumn();
      this.toolStrip1 = new ToolStrip();
      this.toolStripButton1 = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripButton2 = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripButton3 = new ToolStripButton();
      this.progressBar1 = new ProgressBar();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.toolStripButton4 = new ToolStripButton();
      this.gridControl1.BeginInit();
      this.gridView1.BeginInit();
      this.repositoryItemComboBox1.BeginInit();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      this.gridControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gridControl1.Location = new Point(0, 25);
      this.gridControl1.MainView = (BaseView) this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.RepositoryItems.AddRange(new RepositoryItem[1]
      {
        (RepositoryItem) this.repositoryItemComboBox1
      });
      this.gridControl1.Size = new Size(1243, 355);
      this.gridControl1.TabIndex = 0;
      this.gridControl1.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView1
      });
      this.gridView1.Columns.AddRange(new GridColumn[9]
      {
        this.gridColumn1,
        this.gridColumn2,
        this.gridColumn3,
        this.gridColumn4,
        this.gridColumn5,
        this.gridColumn6,
        this.gridColumn7,
        this.gridColumn8,
        this.gridColumn9
      });
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsView.ShowAutoFilterRow = true;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.gridColumn1.Caption = "STOK KOD";
      this.gridColumn1.FieldName = "STOK KOD";
      this.gridColumn1.Name = "gridColumn1";
      this.gridColumn1.OptionsColumn.AllowEdit = false;
      this.gridColumn1.Visible = true;
      this.gridColumn1.VisibleIndex = 0;
      this.gridColumn1.Width = 154;
      this.gridColumn2.Caption = "STOK ADI";
      this.gridColumn2.FieldName = "STOK ADI";
      this.gridColumn2.Name = "gridColumn2";
      this.gridColumn2.OptionsColumn.AllowEdit = false;
      this.gridColumn2.Visible = true;
      this.gridColumn2.VisibleIndex = 1;
      this.gridColumn2.Width = 373;
      this.gridColumn3.Caption = "BIRIM";
      this.gridColumn3.FieldName = "BIRIM";
      this.gridColumn3.Name = "gridColumn3";
      this.gridColumn3.OptionsColumn.AllowEdit = false;
      this.gridColumn3.Visible = true;
      this.gridColumn3.VisibleIndex = 2;
      this.gridColumn3.Width = 105;
      this.gridColumn4.Caption = "DOVIZ TIPI";
      this.gridColumn4.ColumnEdit = (RepositoryItem) this.repositoryItemComboBox1;
      this.gridColumn4.FieldName = "DOVIZ TIPI";
      this.gridColumn4.Name = "gridColumn4";
      this.gridColumn4.Visible = true;
      this.gridColumn4.VisibleIndex = 3;
      this.gridColumn4.Width = 105;
      this.repositoryItemComboBox1.AutoHeight = false;
      this.repositoryItemComboBox1.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.repositoryItemComboBox1.Items.AddRange(new object[3]
      {
        (object) "TL",
        (object) "USD",
        (object) "EURO"
      });
      this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
      this.gridColumn5.Caption = "FIYAT";
      this.gridColumn5.DisplayFormat.FormatString = "f";
      this.gridColumn5.DisplayFormat.FormatType = FormatType.Numeric;
      this.gridColumn5.FieldName = "FIYAT";
      this.gridColumn5.Name = "gridColumn5";
      this.gridColumn5.Visible = true;
      this.gridColumn5.VisibleIndex = 4;
      this.gridColumn5.Width = 105;
      this.gridColumn6.Caption = "ISKONTO 1";
      this.gridColumn6.DisplayFormat.FormatType = FormatType.Numeric;
      this.gridColumn6.FieldName = "ISKONTO 1";
      this.gridColumn6.Name = "gridColumn6";
      this.gridColumn6.Visible = true;
      this.gridColumn6.VisibleIndex = 5;
      this.gridColumn6.Width = 105;
      this.gridColumn7.Caption = "ISKONTO 2";
      this.gridColumn7.DisplayFormat.FormatType = FormatType.Numeric;
      this.gridColumn7.FieldName = "ISKONTO 2";
      this.gridColumn7.Name = "gridColumn7";
      this.gridColumn7.Visible = true;
      this.gridColumn7.VisibleIndex = 6;
      this.gridColumn7.Width = 109;
      this.gridColumn8.Caption = "TOPTANCI";
      this.gridColumn8.FieldName = "TOPTANCI";
      this.gridColumn8.Name = "gridColumn8";
      this.gridColumn8.Visible = true;
      this.gridColumn8.VisibleIndex = 7;
      this.gridColumn8.Width = 100;
      this.gridColumn9.Caption = "PERAKENDE";
      this.gridColumn9.FieldName = "PERAKENDE";
      this.gridColumn9.Name = "gridColumn9";
      this.gridColumn9.Visible = true;
      this.gridColumn9.VisibleIndex = 8;
      this.gridColumn9.Width = 105;
      this.toolStrip1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.toolStrip1.Items.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.toolStripButton1,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripButton2,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripButton3,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.toolStripButton4
      });
      this.toolStrip1.Location = new Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(1243, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      this.toolStripButton1.Image = (Image) componentResourceManager.GetObject("toolStripButton1.Image");
      this.toolStripButton1.ImageTransparentColor = Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new Size(141, 22);
      this.toolStripButton1.Text = "Listeyi Excelle Aktar";
      this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.toolStripButton2.Image = (Image) componentResourceManager.GetObject("toolStripButton2.Image");
      this.toolStripButton2.ImageTransparentColor = Color.Magenta;
      this.toolStripButton2.Name = "toolStripButton2";
      this.toolStripButton2.Size = new Size(174, 22);
      this.toolStripButton2.Text = "Excellden Fiyat Listesini Al";
      this.toolStripButton2.Click += new EventHandler(this.toolStripButton2_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 25);
      this.toolStripButton3.Image = (Image) Resources.money2;
      this.toolStripButton3.ImageTransparentColor = Color.Magenta;
      this.toolStripButton3.Name = "toolStripButton3";
      this.toolStripButton3.Size = new Size(124, 22);
      this.toolStripButton3.Text = "Fiyatlari Güncelle";
      this.toolStripButton3.Click += new EventHandler(this.toolStripButton3_Click);
      this.progressBar1.Dock = DockStyle.Bottom;
      this.progressBar1.Location = new Point(0, 382);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(1243, 23);
      this.progressBar1.TabIndex = 2;
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(6, 25);
      this.toolStripButton4.Image = (Image) Resources.Actions_list_add1;
      this.toolStripButton4.ImageTransparentColor = Color.Magenta;
      this.toolStripButton4.Name = "toolStripButton4";
      this.toolStripButton4.Size = new Size(142, 22);
      this.toolStripButton4.Text = "Promosyon Guncelle";
      this.toolStripButton4.Click += new EventHandler(this.toolStripButton4_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1243, 405);
      this.Controls.Add((Control) this.progressBar1);
      this.Controls.Add((Control) this.toolStrip1);
      this.Controls.Add((Control) this.gridControl1);
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmStokFiyatGuncelle);
      this.Text = "Stok Fiyat Güncelleme";
      this.Load += new EventHandler(this.frmStokFiyatGuncelle_Load);
      this.gridControl1.EndInit();
      this.gridView1.EndInit();
      this.repositoryItemComboBox1.EndInit();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
