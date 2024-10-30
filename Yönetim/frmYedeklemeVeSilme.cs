// Decompiled with JetBrains decompiler
// Type: Yönetim.frmYedeklemeVeSilme
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
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
using Yönetim.Properties;

#nullable disable
namespace Yönetim
{
  public class frmYedeklemeVeSilme : Form
  {
    private IContainer components = (IContainer) null;
    private Label label1;
    private ButtonEdit buttonEdit1;
    private RadioButton rdTumKayitlar;
    private RadioButton rdSeciliSiparişs;
    private CheckBox checkBox1;
    private Button button1;
    private GridControl gridControl1;
    private GridView gridView1;
    private GridColumn gridColumn12;
    private GridColumn gridColumn1;
    private GridColumn gridColumn2;
    private GridColumn gridColumn3;
    private GridColumn gridColumn4;
    private GridColumn gridColumn7;
    private GridColumn gridColumn5;
    private GridColumn gridColumn6;
    private GridColumn gridColumn8;
    private GridColumn gridColumn9;
    private GridColumn gridColumn10;
    private GridColumn gridColumn11;
    private RepositoryItemCheckEdit repositoryItemCheckEdit1;

    public frmYedeklemeVeSilme() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
      if (this.rdTumKayitlar.Checked)
      {
        DataTable dataTable = DBManager.sqlGetDataTable(new SqlCommand("SELECT * FROM SIPARISLER"));
        if (this.buttonEdit1.Text != "")
        {
          dataTable.WriteXml(this.buttonEdit1.Text, XmlWriteMode.WriteSchema);
          if (this.checkBox1.Checked)
            DBManager.sqlRunCommand(new SqlCommand("DELETE FROM SIPARISLER"));
          int num = (int) MessageBox.Show("Yedekleme Ve Silme İşlemleri Tamamlandı", "Sonuc");
        }
      }
      if (!this.rdSeciliSiparişs.Checked || !(this.buttonEdit1.Text != ""))
        return;
      string str1 = "";
      foreach (int selectedRow in this.gridView1.GetSelectedRows())
      {
        string str2 = this.gridView1.GetRowCellValue(selectedRow, "SERİ").ToString();
        string str3 = this.gridView1.GetRowCellValue(selectedRow, "SIRA").ToString();
        str1 = str1 + "'" + str2 + str3 + "',";
      }
      string str4 = str1.Substring(0, str1.Length - 1);
      DBManager.sqlGetDataTable(new SqlCommand("SELECT * FROM SIPARISLER WHERE sip_evrakno_seri+Convert(nvarchar(10),sip_evrakno_sira) IN (" + str4 + ")")).WriteXml(this.buttonEdit1.Text, XmlWriteMode.WriteSchema);
      if (this.checkBox1.Checked)
        DBManager.sqlRunCommand(new SqlCommand("DELETE FROM SIPARISLER WHERE  sip_evrakno_seri+Convert(nvarchar(10),sip_evrakno_sira) IN (" + str4 + ")"));
      int num1 = (int) MessageBox.Show("Yedekleme Ve Silme İşlemleri Tamamlandı", "Sonuc", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
    }

    private void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Yedek Dosyası |*.xml";
      int num = (int) saveFileDialog.ShowDialog();
      if (!(saveFileDialog.FileName != ""))
        return;
      this.buttonEdit1.Text = saveFileDialog.FileName;
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
      if (this.rdSeciliSiparişs.Checked)
      {
        this.gridControl1.Enabled = true;
        this.gridControl1.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("\r\nSELECT  sip_Tarih as 'TARIH',\r\n        sip_evrakno_seri as 'SERİ',\r\n        sip_evrakno_sira as 'SIRA',\r\n        sip_musteri_kod AS 'MÜŞTERİ KOD',\r\n        cari_unvan1 AS 'CARİ UNVANI',\r\n        convert(decimal(18,2), SUM(sip_tutar)) as 'TUTAR',\r\n        COUNT(*) AS 'SATIR',\r\n        sip_aciklama as ACIKLAMA, \r\n        convert(decimal(18,2),SUM(sip_tutar)+SUM(sip_vergi)) as 'KDVLI' ,\r\n        sip_altfirma\r\nFROM   SIPARISLER\r\n       JOIN CARI_HESAPLAR\r\n            ON  sip_musteri_kod = CARI_HESAPLAR.cari_kod\r\nGROUP BY sip_Tarih,\r\n       sip_evrakno_seri,\r\n       sip_evrakno_sira,\r\n       sip_musteri_kod,sip_aciklama,\r\n       cari_unvan1,sip_altfirma"));
        this.gridView1.BestFitColumns();
        for (int index = 0; index < ((DataTable) this.gridControl1.DataSource).Columns.Count; ++index)
        {
          if (((DataTable) this.gridControl1.DataSource).Columns[index].DataType.Name == "Double" || ((DataTable) this.gridControl1.DataSource).Columns[index].DataType.Name == "Decimal")
          {
            this.gridView1.Columns[((DataTable) this.gridControl1.DataSource).Columns[index].Caption].DisplayFormat.FormatString = "D";
            this.gridView1.Columns[((DataTable) this.gridControl1.DataSource).Columns[index].Caption].DisplayFormat.FormatType = FormatType.Numeric;
            this.gridView1.Columns[((DataTable) this.gridControl1.DataSource).Columns[index].Caption].SummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,##0.00} TL");
          }
        }
        for (int index = 0; index < this.gridView1.Columns.Count; ++index)
        {
          if (this.gridView1.Columns[index].ColumnType.FullName != "System.String" && this.gridView1.Columns[index].ColumnType.FullName != "System.Int32")
          {
            this.gridView1.Columns[index].DisplayFormat.FormatType = FormatType.Numeric;
            this.gridView1.Columns[index].DisplayFormat.FormatString = "C";
          }
        }
      }
      if (this.rdSeciliSiparişs.Checked)
        return;
      this.gridControl1.Enabled = false;
    }

    private void WW(object sender, EventArgs e)
    {
    }

    private void gridView1_Click(object sender, EventArgs e)
    {
    }

    private void gridView1_DoubleClick(object sender, EventArgs e)
    {
      if (this.gridView1.SelectedRowsCount <= 0)
        return;
      int num = (int) new frmSiparis()
      {
        Seri = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "SERİ").ToString(),
        Sira = Convert.ToInt32(this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "SIRA").ToString()),
        CariKod = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "MÜŞTERİ KOD").ToString(),
        CariUnvan = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "CARİ UNVANI").ToString()
      }.ShowDialog();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmYedeklemeVeSilme));
      this.label1 = new Label();
      this.buttonEdit1 = new ButtonEdit();
      this.rdTumKayitlar = new RadioButton();
      this.rdSeciliSiparişs = new RadioButton();
      this.checkBox1 = new CheckBox();
      this.button1 = new Button();
      this.gridControl1 = new GridControl();
      this.gridView1 = new GridView();
      this.gridColumn12 = new GridColumn();
      this.repositoryItemCheckEdit1 = new RepositoryItemCheckEdit();
      this.gridColumn1 = new GridColumn();
      this.gridColumn2 = new GridColumn();
      this.gridColumn3 = new GridColumn();
      this.gridColumn4 = new GridColumn();
      this.gridColumn7 = new GridColumn();
      this.gridColumn5 = new GridColumn();
      this.gridColumn6 = new GridColumn();
      this.gridColumn8 = new GridColumn();
      this.gridColumn9 = new GridColumn();
      this.gridColumn10 = new GridColumn();
      this.gridColumn11 = new GridColumn();
      this.buttonEdit1.Properties.BeginInit();
      this.gridControl1.BeginInit();
      this.gridView1.BeginInit();
      this.repositoryItemCheckEdit1.BeginInit();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label1.ForeColor = Color.Red;
      this.label1.Location = new Point(4, 15);
      this.label1.Name = "label1";
      this.label1.Size = new Size(118, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Yedekleme Adresi : ";
      this.buttonEdit1.Location = new Point(125, 12);
      this.buttonEdit1.Name = "buttonEdit1";
      this.buttonEdit1.Properties.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.buttonEdit1.Properties.Appearance.Options.UseFont = true;
      this.buttonEdit1.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.buttonEdit1.Size = new Size(984, 20);
      this.buttonEdit1.TabIndex = 1;
      this.buttonEdit1.ButtonClick += new ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
      this.rdTumKayitlar.AutoSize = true;
      this.rdTumKayitlar.Checked = true;
      this.rdTumKayitlar.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.rdTumKayitlar.ForeColor = Color.Red;
      this.rdTumKayitlar.Location = new Point(4, 37);
      this.rdTumKayitlar.Name = "rdTumKayitlar";
      this.rdTumKayitlar.Size = new Size((int) byte.MaxValue, 17);
      this.rdTumKayitlar.TabIndex = 3;
      this.rdTumKayitlar.TabStop = true;
      this.rdTumKayitlar.Text = "Tüm Kayıtları Tek Dosya Halinde Yedekle";
      this.rdTumKayitlar.UseVisualStyleBackColor = true;
      this.rdSeciliSiparişs.AutoSize = true;
      this.rdSeciliSiparişs.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.rdSeciliSiparişs.ForeColor = Color.Blue;
      this.rdSeciliSiparişs.Location = new Point(326, 37);
      this.rdSeciliSiparişs.Name = "rdSeciliSiparişs";
      this.rdSeciliSiparişs.Size = new Size(205, 17);
      this.rdSeciliSiparişs.TabIndex = 4;
      this.rdSeciliSiparişs.Text = "Sadece Secili Siparişleri Yedekle";
      this.rdSeciliSiparişs.UseVisualStyleBackColor = true;
      this.rdSeciliSiparişs.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
      this.checkBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.checkBox1.AutoSize = true;
      this.checkBox1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.checkBox1.ForeColor = Color.Red;
      this.checkBox1.Location = new Point(4, 539);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(344, 30);
      this.checkBox1.TabIndex = 5;
      this.checkBox1.Text = "Yedeklemeden Sonra Kayıtları Sil\r\n( Sipariş Bazlı Yedekleme Yaptığınızda Sadece Secili Siparişleir Siler )";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.button1.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.button1.ForeColor = Color.Black;
      this.button1.Image = (Image) Resources.database_import;
      this.button1.ImageAlign = ContentAlignment.MiddleLeft;
      this.button1.Location = new Point(879, 535);
      this.button1.Name = "button1";
      this.button1.Size = new Size(238, 38);
      this.button1.TabIndex = 6;
      this.button1.Text = "Yedeklemeyi Başlat";
      this.button1.TextAlign = ContentAlignment.MiddleRight;
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.gridControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gridControl1.Enabled = false;
      this.gridControl1.Location = new Point(4, 60);
      this.gridControl1.LookAndFeel.SkinName = "Liquid Sky";
      this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.gridControl1.MainView = (BaseView) this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.RepositoryItems.AddRange(new RepositoryItem[1]
      {
        (RepositoryItem) this.repositoryItemCheckEdit1
      });
      this.gridControl1.Size = new Size(1113, 471);
      this.gridControl1.TabIndex = 7;
      this.gridControl1.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView1
      });
      this.gridView1.Columns.AddRange(new GridColumn[12]
      {
        this.gridColumn12,
        this.gridColumn1,
        this.gridColumn2,
        this.gridColumn3,
        this.gridColumn4,
        this.gridColumn7,
        this.gridColumn5,
        this.gridColumn6,
        this.gridColumn8,
        this.gridColumn9,
        this.gridColumn10,
        this.gridColumn11
      });
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsBehavior.Editable = false;
      this.gridView1.OptionsSelection.MultiSelect = true;
      this.gridView1.OptionsView.ShowAutoFilterRow = true;
      this.gridView1.OptionsView.ShowFooter = true;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.gridView1.Click += new EventHandler(this.gridView1_Click);
      this.gridView1.DoubleClick += new EventHandler(this.gridView1_DoubleClick);
      this.gridColumn12.Caption = " ";
      this.gridColumn12.ColumnEdit = (RepositoryItem) this.repositoryItemCheckEdit1;
      this.gridColumn12.FieldName = "CHK";
      this.gridColumn12.Name = "gridColumn12";
      this.gridColumn12.Width = 27;
      this.repositoryItemCheckEdit1.AutoHeight = false;
      this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
      this.gridColumn1.Caption = "SERİ";
      this.gridColumn1.FieldName = "SERİ";
      this.gridColumn1.Name = "gridColumn1";
      this.gridColumn1.Visible = true;
      this.gridColumn1.VisibleIndex = 1;
      this.gridColumn1.Width = 38;
      this.gridColumn2.Caption = "SIRA";
      this.gridColumn2.FieldName = "SIRA";
      this.gridColumn2.Name = "gridColumn2";
      this.gridColumn2.Visible = true;
      this.gridColumn2.VisibleIndex = 2;
      this.gridColumn2.Width = 51;
      this.gridColumn3.Caption = "CARI KOD";
      this.gridColumn3.FieldName = "MÜŞTERİ KOD";
      this.gridColumn3.Name = "gridColumn3";
      this.gridColumn3.Visible = true;
      this.gridColumn3.VisibleIndex = 3;
      this.gridColumn3.Width = 69;
      this.gridColumn4.Caption = "CARİ UNVAN";
      this.gridColumn4.FieldName = "CARİ UNVANI";
      this.gridColumn4.Name = "gridColumn4";
      this.gridColumn4.Visible = true;
      this.gridColumn4.VisibleIndex = 4;
      this.gridColumn4.Width = 214;
      this.gridColumn7.Caption = "IL/ILCE";
      this.gridColumn7.FieldName = "ACIKLAMA";
      this.gridColumn7.Name = "gridColumn7";
      this.gridColumn7.Visible = true;
      this.gridColumn7.VisibleIndex = 6;
      this.gridColumn7.Width = 153;
      this.gridColumn5.Caption = "TUTAR";
      this.gridColumn5.DisplayFormat.FormatString = "{0:c} ";
      this.gridColumn5.DisplayFormat.FormatType = FormatType.Numeric;
      this.gridColumn5.FieldName = "TUTAR";
      this.gridColumn5.Name = "gridColumn5";
      this.gridColumn5.Visible = true;
      this.gridColumn5.VisibleIndex = 7;
      this.gridColumn5.Width = 95;
      this.gridColumn6.Caption = "SATIR";
      this.gridColumn6.FieldName = "SATIR";
      this.gridColumn6.Name = "gridColumn6";
      this.gridColumn6.Visible = true;
      this.gridColumn6.VisibleIndex = 8;
      this.gridColumn6.Width = 61;
      this.gridColumn8.Caption = "TARIH";
      this.gridColumn8.FieldName = "TARIH";
      this.gridColumn8.Name = "gridColumn8";
      this.gridColumn8.Visible = true;
      this.gridColumn8.VisibleIndex = 0;
      this.gridColumn8.Width = 46;
      this.gridColumn9.Caption = "KDVLİ TUTAR";
      this.gridColumn9.DisplayFormat.FormatString = "C";
      this.gridColumn9.DisplayFormat.FormatType = FormatType.Numeric;
      this.gridColumn9.FieldName = "KDVLI";
      this.gridColumn9.Name = "gridColumn9";
      this.gridColumn9.Width = 63;
      this.gridColumn10.Caption = "ALT FIRMA";
      this.gridColumn10.FieldName = "sip_altfirma";
      this.gridColumn10.Name = "gridColumn10";
      this.gridColumn10.Visible = true;
      this.gridColumn10.VisibleIndex = 5;
      this.gridColumn10.Width = 68;
      this.gridColumn11.Caption = "ARA BAYİ";
      this.gridColumn11.FieldName = "sip_arafirmaAdi";
      this.gridColumn11.Name = "gridColumn11";
      this.gridColumn11.Visible = true;
      this.gridColumn11.VisibleIndex = 9;
      this.gridColumn11.Width = 76;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(1122, 577);
      this.Controls.Add((Control) this.gridControl1);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.rdSeciliSiparişs);
      this.Controls.Add((Control) this.rdTumKayitlar);
      this.Controls.Add((Control) this.buttonEdit1);
      this.Controls.Add((Control) this.label1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmYedeklemeVeSilme);
      this.Text = "Yedekleme ve Silme";
      this.Click += new EventHandler(this.WW);
      this.buttonEdit1.Properties.EndInit();
      this.gridControl1.EndInit();
      this.gridView1.EndInit();
      this.repositoryItemCheckEdit1.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
