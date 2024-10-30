// Decompiled with JetBrains decompiler
// Type: Yönetim.frmStokKart
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Yönetim
{
  public class frmStokKart : Form
  {
    private int Yukseklik = 0;
    private int Genislik = 0;
    private DataTable dtFiyat = new DataTable();
    private SqlDataAdapter dtpfiyat = (SqlDataAdapter) null;
    private DataTable dtBarkod = new DataTable();
    private SqlDataAdapter dtpBarkod = (SqlDataAdapter) null;
    private IContainer components = (IContainer) null;
    private SplitContainer splitContainer1;
    private GroupControl groupControl3;
    private GridControl gridControl2;
    private GridView gridView2;
    private GridColumn gridColumn2;
    private GridColumn gridColumn3;
    private GridColumn gridColumn4;
    private GridColumn gridColumn5;
    private GridColumn gridColumn6;
    private GridColumn gridColumn7;
    private GridColumn gridColumn8;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private GroupControl groupControl2;
    private GridControl gridControl1;
    private GridView gridView1;
    private GridColumn gridColumn1;
    private GridColumn gridColumn9;
    private TabPage tabPage2;
    private GroupControl groupControl1;
    private GridControl gridControl3;
    private GridView gridView3;
    private TabPage tabPage3;
    private GroupControl groupControl4;
    private GridControl gridControl4;
    private GridView gridView4;
    private GridColumn gridColumn10;
    private GridColumn gridColumn11;
    private GridColumn gridColumn12;
    private GridColumn gridColumn13;
    private GridColumn gridColumn14;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;

    public frmStokKart() => this.InitializeComponent();

    private void frmStokKart_Load(object sender, EventArgs e)
    {
      this.gridControl2.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("SELECT sto_Recno,sto_kod,sto_isim, sto_perakende_vergi, sto_bakiye,0 AS 'SIPARISMIKTAR' FROM STOKLAR"));
    }

    private void frmStokKart_LocationChanged(object sender, EventArgs e)
    {
    }

    private void gridControl2_DoubleClick(object sender, EventArgs e)
    {
      try
      {
        try
        {
          DBManager.Update(this.dtFiyat, this.dtpfiyat);
          DBManager.Update(this.dtBarkod, this.dtpBarkod);
        }
        catch (Exception ex)
        {
        }
        string str = this.gridView2.GetRowCellValue(this.gridView2.GetSelectedRows()[0], this.gridColumn3).ToString();
        this.dtBarkod = DBManager.sqlGetDataTable(new SqlCommand("SELECT * FROM  dbo.BARKOD_TANIMLARI WHERE bar_stokkod='" + str + "'"));
        this.gridControl1.DataSource = (object) this.dtBarkod;
        this.dtpBarkod = DBManager.adp;
        this.dtBarkod.RowChanged += new DataRowChangeEventHandler(this.dtBarkod_RowChanged);
        this.gridControl3.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("SELECT sip_evrakno_seri  AS 'SERİ',sip_evrakno_sira AS 'SIRA',sip_musteri_kod AS 'MUŞTERİ',cari_unvan1 AS 'MUŞTERİ ADI',sip_miktar AS  'Miktar' FROM SIPARISLER JOIN CARI_HESAPLAR ON CARI_HESAPLAR.cari_kod=sip_musteri_kod  where sip_stok_kod='" + str + "'"));
        this.dtFiyat = DBManager.sqlGetDataTable(new SqlCommand("SELECT sfyt_iskonto1,sfyt_iskonto2,sfyt_fiyat,case sfiyat_doviz when 0 then 'TL' WHEN 1 THEN 'USD' WHEN 2 THEN 'EURO' END sfiyat_doviz,ID,sfiyat_cariKod FROM FIYAT_LISTESI  where sfyt_stokkod='" + str + "'"));
        this.gridControl4.DataSource = (object) this.dtFiyat;
        this.dtpfiyat = DBManager.adp;
      }
      catch
      {
      }
    }

    private void dtBarkod_RowChanged(object sender, DataRowChangeEventArgs e)
    {
      if (e.Action != DataRowAction.Add)
        return;
      string str = this.gridView2.GetRowCellValue(this.gridView2.GetSelectedRows()[0], this.gridColumn3).ToString();
      for (int index = 0; index < this.dtBarkod.Rows.Count; ++index)
      {
        this.dtBarkod.Rows[index]["bar_Recno"] = (object) 0;
        this.dtBarkod.Rows[index]["bar_stokkod"] = (object) str;
      }
    }

    private void gridControl2_Click(object sender, EventArgs e)
    {
    }

    private void gridControl3_DragDrop(object sender, DragEventArgs e)
    {
    }

    private void gridControl3_DoubleClick(object sender, EventArgs e)
    {
      if (this.gridView3.SelectedRowsCount <= 0)
        return;
      int num = (int) new frmSiparis()
      {
        Seri = this.gridView3.GetRowCellValue(this.gridView3.GetSelectedRows()[0], "SERİ").ToString(),
        Sira = Convert.ToInt32(this.gridView3.GetRowCellValue(this.gridView3.GetSelectedRows()[0], "SIRA").ToString()),
        CariKod = this.gridView3.GetRowCellValue(this.gridView3.GetSelectedRows()[0], "MUŞTERİ").ToString(),
        CariUnvan = this.gridView3.GetRowCellValue(this.gridView3.GetSelectedRows()[0], "MUŞTERİ ADI").ToString()
      }.ShowDialog();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      int num = (int) new frmBarkod()
      {
        sTOKkoD = this.gridView2.GetRowCellValue(this.gridView2.GetSelectedRows()[0], this.gridColumn3).ToString()
      }.ShowDialog();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      int num = (int) new frmYeniStokKart().ShowDialog();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      try
      {
        SqlCommand mCommand = new SqlCommand();
        mCommand.CommandText = "DELETE FROM BARKOD_TANIMLARI WHERE bar_kodu='" + this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], this.gridColumn1).ToString() + "'";
        DBManager.sqlRunCommand(mCommand);
        this.gridControl2_DoubleClick(sender, e);
      }
      catch (Exception ex)
      {
      }
    }

    private void gridControl2_DockChanged(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmStokKart));
      this.splitContainer1 = new SplitContainer();
      this.groupControl3 = new GroupControl();
      this.button2 = new Button();
      this.gridControl2 = new GridControl();
      this.gridView2 = new GridView();
      this.gridColumn2 = new GridColumn();
      this.gridColumn3 = new GridColumn();
      this.gridColumn4 = new GridColumn();
      this.gridColumn5 = new GridColumn();
      this.gridColumn6 = new GridColumn();
      this.gridColumn7 = new GridColumn();
      this.gridColumn8 = new GridColumn();
      this.tabControl1 = new TabControl();
      this.tabPage1 = new TabPage();
      this.groupControl2 = new GroupControl();
      this.button4 = new Button();
      this.button3 = new Button();
      this.button1 = new Button();
      this.gridControl1 = new GridControl();
      this.gridView1 = new GridView();
      this.gridColumn1 = new GridColumn();
      this.gridColumn9 = new GridColumn();
      this.tabPage2 = new TabPage();
      this.groupControl1 = new GroupControl();
      this.gridControl3 = new GridControl();
      this.gridView3 = new GridView();
      this.tabPage3 = new TabPage();
      this.groupControl4 = new GroupControl();
      this.gridControl4 = new GridControl();
      this.gridView4 = new GridView();
      this.gridColumn10 = new GridColumn();
      this.gridColumn11 = new GridColumn();
      this.gridColumn12 = new GridColumn();
      this.gridColumn13 = new GridColumn();
      this.gridColumn14 = new GridColumn();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.groupControl3.BeginInit();
      this.groupControl3.SuspendLayout();
      this.gridControl2.BeginInit();
      this.gridView2.BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.groupControl2.BeginInit();
      this.groupControl2.SuspendLayout();
      this.gridControl1.BeginInit();
      this.gridView1.BeginInit();
      this.tabPage2.SuspendLayout();
      this.groupControl1.BeginInit();
      this.groupControl1.SuspendLayout();
      this.gridControl3.BeginInit();
      this.gridView3.BeginInit();
      this.tabPage3.SuspendLayout();
      this.groupControl4.BeginInit();
      this.groupControl4.SuspendLayout();
      this.gridControl4.BeginInit();
      this.gridView4.BeginInit();
      this.SuspendLayout();
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = Orientation.Horizontal;
      this.splitContainer1.Panel1.Controls.Add((Control) this.groupControl3);
      this.splitContainer1.Panel2.Controls.Add((Control) this.tabControl1);
      this.splitContainer1.Size = new Size(960, 632);
      this.splitContainer1.SplitterDistance = 353;
      this.splitContainer1.TabIndex = 3;
      this.groupControl3.Controls.Add((Control) this.button2);
      this.groupControl3.Controls.Add((Control) this.gridControl2);
      this.groupControl3.Dock = DockStyle.Fill;
      this.groupControl3.Location = new Point(0, 0);
      this.groupControl3.LookAndFeel.Style = LookAndFeelStyle.Office2003;
      this.groupControl3.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl3.Name = "groupControl3";
      this.groupControl3.Size = new Size(960, 353);
      this.groupControl3.TabIndex = 2;
      this.groupControl3.Text = "Stok Listesi";
      this.button2.Location = new Point(107, -1);
      this.button2.Name = "button2";
      this.button2.Size = new Size(166, 21);
      this.button2.TabIndex = 1;
      this.button2.Text = "Yeni Stok Kartı";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.gridControl2.Dock = DockStyle.Fill;
      this.gridControl2.Location = new Point(2, 19);
      this.gridControl2.MainView = (BaseView) this.gridView2;
      this.gridControl2.Name = "gridControl2";
      this.gridControl2.Size = new Size(956, 332);
      this.gridControl2.TabIndex = 0;
      this.gridControl2.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView2
      });
      this.gridControl2.DoubleClick += new EventHandler(this.gridControl2_DoubleClick);
      this.gridControl2.DockChanged += new EventHandler(this.gridControl2_DockChanged);
      this.gridControl2.Click += new EventHandler(this.gridControl2_Click);
      this.gridView2.Columns.AddRange(new GridColumn[7]
      {
        this.gridColumn2,
        this.gridColumn3,
        this.gridColumn4,
        this.gridColumn5,
        this.gridColumn6,
        this.gridColumn7,
        this.gridColumn8
      });
      this.gridView2.GridControl = this.gridControl2;
      this.gridView2.Name = "gridView2";
      this.gridView2.OptionsBehavior.Editable = false;
      this.gridView2.OptionsCustomization.AllowFilter = false;
      this.gridView2.OptionsView.ShowAutoFilterRow = true;
      this.gridView2.OptionsView.ShowGroupPanel = false;
      this.gridColumn2.Caption = "Kayit No";
      this.gridColumn2.Name = "gridColumn2";
      this.gridColumn2.Width = 62;
      this.gridColumn3.Caption = "Stok Kod";
      this.gridColumn3.FieldName = "sto_kod";
      this.gridColumn3.Name = "gridColumn3";
      this.gridColumn3.Visible = true;
      this.gridColumn3.VisibleIndex = 0;
      this.gridColumn3.Width = 90;
      this.gridColumn4.Caption = "Stok İsim";
      this.gridColumn4.FieldName = "sto_isim";
      this.gridColumn4.Name = "gridColumn4";
      this.gridColumn4.Visible = true;
      this.gridColumn4.VisibleIndex = 1;
      this.gridColumn4.Width = 414;
      this.gridColumn5.Caption = "Stok Vergi";
      this.gridColumn5.FieldName = "sto_perakende_vergi";
      this.gridColumn5.Name = "gridColumn5";
      this.gridColumn5.Width = 104;
      this.gridColumn6.Caption = "Birim";
      this.gridColumn6.Name = "gridColumn6";
      this.gridColumn6.Width = 76;
      this.gridColumn7.Caption = "Stok Bakiye";
      this.gridColumn7.FieldName = "sto_bakiye";
      this.gridColumn7.Name = "gridColumn7";
      this.gridColumn7.Visible = true;
      this.gridColumn7.VisibleIndex = 2;
      this.gridColumn7.Width = 88;
      this.gridColumn8.Caption = "Alinan Sipariş Miktari";
      this.gridColumn8.FieldName = "SIPARISMIKTAR";
      this.gridColumn8.Name = "gridColumn8";
      this.gridColumn8.Width = 141;
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Controls.Add((Control) this.tabPage3);
      this.tabControl1.Dock = DockStyle.Fill;
      this.tabControl1.Location = new Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(960, 275);
      this.tabControl1.TabIndex = 1;
      this.tabPage1.Controls.Add((Control) this.groupControl2);
      this.tabPage1.Location = new Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(952, 249);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Barkod Listesi";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.groupControl2.Controls.Add((Control) this.button4);
      this.groupControl2.Controls.Add((Control) this.button3);
      this.groupControl2.Controls.Add((Control) this.button1);
      this.groupControl2.Controls.Add((Control) this.gridControl1);
      this.groupControl2.Dock = DockStyle.Fill;
      this.groupControl2.Location = new Point(3, 3);
      this.groupControl2.LookAndFeel.Style = LookAndFeelStyle.Office2003;
      this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl2.Name = "groupControl2";
      this.groupControl2.Size = new Size(946, 243);
      this.groupControl2.TabIndex = 4;
      this.groupControl2.Text = "Barkod Listesi";
      this.button4.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.button4.ForeColor = Color.Red;
      this.button4.Location = new Point(399, -1);
      this.button4.Name = "button4";
      this.button4.Size = new Size(136, 21);
      this.button4.TabIndex = 4;
      this.button4.Text = "Barkod Basım";
      this.button4.UseVisualStyleBackColor = true;
      this.button3.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.button3.ForeColor = Color.Red;
      this.button3.Location = new Point(266, -1);
      this.button3.Name = "button3";
      this.button3.Size = new Size(133, 21);
      this.button3.TabIndex = 3;
      this.button3.Text = "Secili Barkodu Sil";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.button1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.button1.ForeColor = Color.Red;
      this.button1.Location = new Point(100, -1);
      this.button1.Name = "button1";
      this.button1.Size = new Size(166, 21);
      this.button1.TabIndex = 2;
      this.button1.Text = "Yeni Barkod";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.gridControl1.Dock = DockStyle.Fill;
      this.gridControl1.Location = new Point(2, 19);
      this.gridControl1.MainView = (BaseView) this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new Size(942, 222);
      this.gridControl1.TabIndex = 1;
      this.gridControl1.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView1
      });
      this.gridView1.Columns.AddRange(new GridColumn[2]
      {
        this.gridColumn1,
        this.gridColumn9
      });
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.gridColumn1.Caption = "Barkod";
      this.gridColumn1.FieldName = "bar_kodu";
      this.gridColumn1.Name = "gridColumn1";
      this.gridColumn1.Visible = true;
      this.gridColumn1.VisibleIndex = 0;
      this.gridColumn9.Caption = "Birim";
      this.gridColumn9.FieldName = "bar_birim";
      this.gridColumn9.Name = "gridColumn9";
      this.gridColumn9.Visible = true;
      this.gridColumn9.VisibleIndex = 1;
      this.tabPage2.Controls.Add((Control) this.groupControl1);
      this.tabPage2.Location = new Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(952, 249);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Sipariş Listesi";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.groupControl1.Controls.Add((Control) this.gridControl3);
      this.groupControl1.Dock = DockStyle.Fill;
      this.groupControl1.Location = new Point(3, 3);
      this.groupControl1.LookAndFeel.Style = LookAndFeelStyle.Office2003;
      this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new Size(946, 243);
      this.groupControl1.TabIndex = 5;
      this.groupControl1.Text = "Barkod Listesi";
      this.gridControl3.Dock = DockStyle.Fill;
      this.gridControl3.Location = new Point(2, 19);
      this.gridControl3.MainView = (BaseView) this.gridView3;
      this.gridControl3.Name = "gridControl3";
      this.gridControl3.Size = new Size(942, 222);
      this.gridControl3.TabIndex = 0;
      this.gridControl3.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView3
      });
      this.gridControl3.DoubleClick += new EventHandler(this.gridControl3_DoubleClick);
      this.gridControl3.DragDrop += new DragEventHandler(this.gridControl3_DragDrop);
      this.gridView3.GridControl = this.gridControl3;
      this.gridView3.Name = "gridView3";
      this.gridView3.OptionsBehavior.Editable = false;
      this.gridView3.OptionsCustomization.AllowGroup = false;
      this.gridView3.OptionsView.ShowGroupPanel = false;
      this.tabPage3.Controls.Add((Control) this.groupControl4);
      this.tabPage3.Location = new Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new Padding(3);
      this.tabPage3.Size = new Size(952, 249);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Fiyat Listesi";
      this.tabPage3.UseVisualStyleBackColor = true;
      this.groupControl4.Controls.Add((Control) this.gridControl4);
      this.groupControl4.Dock = DockStyle.Fill;
      this.groupControl4.Location = new Point(3, 3);
      this.groupControl4.LookAndFeel.Style = LookAndFeelStyle.Office2003;
      this.groupControl4.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl4.Name = "groupControl4";
      this.groupControl4.Size = new Size(946, 243);
      this.groupControl4.TabIndex = 5;
      this.groupControl4.Text = "Fiyat Listesi";
      this.gridControl4.Dock = DockStyle.Fill;
      this.gridControl4.Location = new Point(2, 19);
      this.gridControl4.MainView = (BaseView) this.gridView4;
      this.gridControl4.Name = "gridControl4";
      this.gridControl4.Size = new Size(942, 222);
      this.gridControl4.TabIndex = 1;
      this.gridControl4.UseEmbeddedNavigator = true;
      this.gridControl4.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView4
      });
      this.gridView4.Columns.AddRange(new GridColumn[5]
      {
        this.gridColumn10,
        this.gridColumn11,
        this.gridColumn12,
        this.gridColumn13,
        this.gridColumn14
      });
      this.gridView4.GridControl = this.gridControl4;
      this.gridView4.Name = "gridView4";
      this.gridView4.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
      this.gridView4.OptionsView.ShowGroupPanel = false;
      this.gridColumn10.Caption = "Fiyat";
      this.gridColumn10.FieldName = "sfyt_fiyat";
      this.gridColumn10.Name = "gridColumn10";
      this.gridColumn10.Visible = true;
      this.gridColumn10.VisibleIndex = 0;
      this.gridColumn10.Width = 148;
      this.gridColumn11.Caption = "Döviz Tipi";
      this.gridColumn11.FieldName = "sfiyat_doviz";
      this.gridColumn11.Name = "gridColumn11";
      this.gridColumn11.Visible = true;
      this.gridColumn11.VisibleIndex = 3;
      this.gridColumn11.Width = 107;
      this.gridColumn12.Caption = "İskonto 1";
      this.gridColumn12.FieldName = "sfyt_iskonto1";
      this.gridColumn12.Name = "gridColumn12";
      this.gridColumn12.Visible = true;
      this.gridColumn12.VisibleIndex = 1;
      this.gridColumn12.Width = 148;
      this.gridColumn13.Caption = "İskonto 2";
      this.gridColumn13.FieldName = "sfyt_iskonto2";
      this.gridColumn13.Name = "gridColumn13";
      this.gridColumn13.Visible = true;
      this.gridColumn13.VisibleIndex = 2;
      this.gridColumn13.Width = 148;
      this.gridColumn14.Caption = "Cari Kodu";
      this.gridColumn14.FieldName = "sfiyat_cariKod";
      this.gridColumn14.Name = "gridColumn14";
      this.gridColumn14.Visible = true;
      this.gridColumn14.VisibleIndex = 4;
      this.gridColumn14.Width = 118;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(960, 632);
      this.Controls.Add((Control) this.splitContainer1);
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmStokKart);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Extra Sipariş Sistemi  [  STOK YÖNETİM ]";
      this.Load += new EventHandler(this.frmStokKart_Load);
      this.LocationChanged += new EventHandler(this.frmStokKart_LocationChanged);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.groupControl3.EndInit();
      this.groupControl3.ResumeLayout(false);
      this.gridControl2.EndInit();
      this.gridView2.EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.groupControl2.EndInit();
      this.groupControl2.ResumeLayout(false);
      this.gridControl1.EndInit();
      this.gridView1.EndInit();
      this.tabPage2.ResumeLayout(false);
      this.groupControl1.EndInit();
      this.groupControl1.ResumeLayout(false);
      this.gridControl3.EndInit();
      this.gridView3.EndInit();
      this.tabPage3.ResumeLayout(false);
      this.groupControl4.EndInit();
      this.groupControl4.ResumeLayout(false);
      this.gridControl4.EndInit();
      this.gridView4.EndInit();
      this.ResumeLayout(false);
    }
  }
}
