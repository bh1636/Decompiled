// Decompiled with JetBrains decompiler
// Type: Yönetim.frmLogoVerial
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
  public class frmLogoVerial : Form
  {
    private string oku_DONEM = "";
    private string oku_FIRMA = "";
    private string oku_FIRMADONEM = "";
    private IContainer components = (IContainer) null;
    private GroupControl groupControl1;
    private Label label3;
    private Label label2;
    private Label label1;
    private TextBox txtServerAdi;
    private TextBox txtKullaniciAdi;
    private TextBox txtSifre;
    private Label label7;
    private Label label8;
    private Label label5;
    private System.Windows.Forms.ProgressBar progressBar1;
    private Button button1;
    private Button button2;
    private TextBox txtDatabase;
    private Label label10;
    private System.Windows.Forms.ComboBox cmbLogoFirma;
    private Label label4;

    public frmLogoVerial() => this.InitializeComponent();

    private void frmLogoVerial_Load(object sender, EventArgs e) => this.txtServerAdi.Focus();

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        this.LogoBaglan();
        SqlCommand mCommand = new SqlCommand();
        mCommand.CommandText = "\r\nIF EXISTS( SELECT * FROM sysobjects WHERE [name]='extrap_PadLeft') BEGIN DROP  FUNCTION extrap_PadLeft END";
        DBManager.sqlRunCommand(mCommand);
        mCommand.CommandText = " \r\n                CREATE FUNCTION extrap_PadLeft    \r\n                (\r\n                @Seq varchar(30),    \r\n                @PadWith char(1),    \r\n                @PadLength int    \r\n                )     \r\n                    \r\n                RETURNS varchar(16) AS    \r\n                    \r\n                BEGIN     \r\n                    \r\n                declare @curSeq varchar(30)    \r\n                    \r\n                SELECT @curSeq = ISNULL(REPLICATE(@PadWith, @PadLength - len(ISNULL(@Seq ,0))), '') + @Seq    \r\n                    \r\n                RETURN @curSeq    \r\n                    \r\n                END ";
        DBManager.sqlRunCommand(mCommand);
        DataTable dataTable = new DataTable();
        this.cmbLogoFirma.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("SELECT L_CAPIFIRM.LOGICALREF No,dbo.extrap_PadLeft(L_CAPIFIRM.NR,'0',3)+'_'+dbo.extrap_PadLeft(L_CAPIPERIOD.NR,'0',2) DONEM, dbo.extrap_PadLeft(L_CAPIPERIOD.NR,'0',2)+'-'+NAME Adi FROM L_CAPIFIRM JOIN L_CAPIPERIOD ON L_CAPIFIRM.NR=L_CAPIPERIOD.FIRMNR AND L_CAPIPERIOD.ENDDATE>CONVERT(DATETIME,GETDATE(),104)"));
        this.cmbLogoFirma.DisplayMember = "DONEM";
        this.cmbLogoFirma.ValueMember = "DONEM";
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Bağlantı Sağlanamadı");
      }
    }

    private void LogoBaglan()
    {
      DBManager.sqlDisConnect();
      DBManager.sqlConnect(string.Format("Data Source={0};Initial Catalog={1};User Id={2};password={3};", (object) this.txtServerAdi.Text, (object) this.txtDatabase.Text, (object) this.txtKullaniciAdi.Text, (object) this.txtSifre.Text));
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.LogoBaglan();
      DataTable dataTable1 = DBManager.sqlGetDataTable(new SqlCommand("SELECT LG_" + this.oku_FIRMA + "_ITEMS.LOGICALREF,LG_" + this.oku_FIRMA + "_ITEMS.CODE,LG_" + this.oku_FIRMA + "_ITEMS.NAME,VAT,(SELECT DESCR FROM LG_" + this.oku_FIRMA + "_MARK WHERE LOGICALREF=MARKREF) 'MARKA' ,LG_" + this.oku_FIRMA + "_UNITSETF.NAME  'BIRIM' ,(SELECT TOP 1 CONVFACT2 FROM code_StokBarkodList WHERE NAME=LG_" + this.oku_FIRMA + "_UNITSETF.NAME AND code_StokBarkodList.CODE=LG_" + this.oku_FIRMA + "_ITEMS.CODE) 'CARPAN' FROM LG_" + this.oku_FIRMA + "_ITEMS JOIN  LG_" + this.oku_FIRMA + "_UNITSETF ON UNITSETREF= .LG_" + this.oku_FIRMA + "_UNITSETF.LOGICALREF WHERE LG_" + this.oku_FIRMA + "_ITEMS.CODE NOT LIKE '[HM,YM]%' AND LG_" + this.oku_FIRMA + "_ITEMS.LOGICALREF IN (SELECT CARDREF FROM LG_004_PRCLIST WHERE GRPCODE='003' AND BEGDATE<GETDATE() AND ENDDATE>GETDATE())"));
      DBManager.sqlDisConnect();
      DBManager.sqlConnect("");
      this.label7.Text = "STOKLAR";
      DBManager.sqlRunCommand(new SqlCommand("DELETE FROM STOKLAR"));
      this.label8.Text = dataTable1.Rows.Count.ToString();
      this.progressBar1.Maximum = dataTable1.Rows.Count;
      this.progressBar1.Minimum = 0;
      this.progressBar1.Value = 0;
      foreach (DataRow row in (InternalDataCollectionBase) dataTable1.Rows)
      {
        SqlCommand mCommand = new SqlCommand("INSERT INTO STOKLAR (sto_Recno,sto_kod,sto_isim,sto_perakende_vergi,sto_Bakiye,sto_birim,MARKA,BIRIMCARPAN) values (@sto_Recno,@sto_kod,@sto_isim,@sto_perakende_vergi,@sto_Bakiye,@sto_birim,@MARKA,@BIRIMCARPAN)");
        mCommand.Parameters.AddWithValue("@sto_Recno", (object) row["LOGICALREF"].ToString());
        mCommand.Parameters.AddWithValue("@sto_kod", (object) row["CODE"].ToString());
        mCommand.Parameters.AddWithValue("@sto_isim", (object) row["NAME"].ToString());
        mCommand.Parameters.AddWithValue("@sto_perakende_vergi", (object) row["VAT"].ToString());
        mCommand.Parameters.AddWithValue("@sto_Bakiye", (object) "0");
        mCommand.Parameters.AddWithValue("@sto_birim", (object) row["BIRIM"].ToString());
        mCommand.Parameters.AddWithValue("@MARKA", (object) row["MARKA"].ToString());
        mCommand.Parameters.AddWithValue("@BIRIMCARPAN", (object) row["CARPAN"].ToString());
        DBManager.sqlRunCommand(mCommand);
        ++this.progressBar1.Value;
        Application.DoEvents();
      }
      this.LogoBaglan();
      DataTable dataTable2 = DBManager.sqlGetDataTable(new SqlCommand("SELECT LG_" + this.oku_FIRMA + "_UNITBARCODE.LOGICALREF ,LG_" + this.oku_FIRMA + "_ITEMS.CODE,LG_" + this.oku_FIRMA + "_UNITBARCODE..BARCODE,LG_" + this.oku_FIRMA + "_UNITSETL.CODE 'NAME',LG_" + this.oku_FIRMA + "_ITMUNITA.CONVFACT2 FROM LG_" + this.oku_FIRMA + "_UNITBARCODE  , LG_" + this.oku_FIRMA + "_ITMUNITA  ,LG_" + this.oku_FIRMA + "_ITEMS,LG_" + this.oku_FIRMA + "_UNITSETL WHERE  LG_" + this.oku_FIRMA + "_ITMUNITA.UNITLINEREF=LG_" + this.oku_FIRMA + "_UNITBARCODE.UNITLINEREF\tAND LG_" + this.oku_FIRMA + "_ITMUNITA.ITEMREF=LG_" + this.oku_FIRMA + "_UNITBARCODE.ITEMREF AND LG_" + this.oku_FIRMA + "_ITEMS.LOGICALREF=LG_" + this.oku_FIRMA + "_ITMUNITA.ITEMREF  AND LG_" + this.oku_FIRMA + "_UNITSETL.LOGICALREF=LG_" + this.oku_FIRMA + "_UNITBARCODE.UNITLINEREF ORDER BY LG_" + this.oku_FIRMA + "_ITEMS.CODE,LG_" + this.oku_FIRMA + "_ITMUNITA.CONVFACT2"));
      DBManager.sqlDisConnect();
      DBManager.sqlConnect("");
      this.label7.Text = "BARKOD TANIMLARI";
      DBManager.sqlRunCommand(new SqlCommand("DELETE FROM BARKOD_TANIMLARI"));
      this.progressBar1.Maximum = dataTable2.Rows.Count;
      this.progressBar1.Minimum = 0;
      this.progressBar1.Value = 0;
      this.label8.Text = dataTable2.Rows.Count.ToString();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
      {
        SqlCommand mCommand = new SqlCommand("INSERT INTO BARKOD_TANIMLARI (bar_Recno,bar_stokkod,bar_kodu,bar_birim,bar_carpan) values (@bar_Recno,@bar_stokkod,@bar_kodu,@bar_birim,@bar_carpan)");
        mCommand.Parameters.AddWithValue("@bar_Recno", (object) row["LOGICALREF"].ToString());
        mCommand.Parameters.AddWithValue("@bar_stokkod", (object) row["CODE"].ToString());
        mCommand.Parameters.AddWithValue("@bar_kodu", (object) row["BARCODE"].ToString());
        mCommand.Parameters.AddWithValue("@bar_birim", (object) row["NAME"].ToString());
        mCommand.Parameters.AddWithValue("@bar_carpan", (object) row["CONVFACT2"].ToString());
        DBManager.sqlRunCommand(mCommand);
        ++this.progressBar1.Value;
        Application.DoEvents();
      }
      this.LogoBaglan();
      DataTable dataTable3 = DBManager.sqlGetDataTable(new SqlCommand("SELECT LG_" + this.oku_FIRMA + "_CLCARD.LOGICALREF,CODE,DEFINITION_,ADDR1,ADDR2,CITY,0 AS 'DEBIT' FROM LG_" + this.oku_FIRMA + "_CLCARD"));
      DBManager.sqlDisConnect();
      DBManager.sqlConnect("");
      this.label7.Text = "CARI HESAPLAR";
      DBManager.sqlRunCommand(new SqlCommand("DELETE FROM CARI_HESAPLAR"));
      this.progressBar1.Maximum = dataTable3.Rows.Count;
      this.progressBar1.Minimum = 0;
      this.progressBar1.Value = 0;
      this.label8.Text = dataTable3.Rows.Count.ToString();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable3.Rows)
      {
        SqlCommand mCommand = new SqlCommand("INSERT INTO CARI_HESAPLAR (cari_recno,cari_kod,cari_unvan1,cari_adres,cari_il,cari_ilce,cari_bakiye) values (@cari_recno,@cari_kod,@cari_unvan1,@cari_adres,@cari_il,@cari_ilce,@cari_bakiye)");
        mCommand.Parameters.AddWithValue("@cari_recno", (object) row["LOGICALREF"].ToString());
        mCommand.Parameters.AddWithValue("@cari_kod", (object) row["CODE"].ToString());
        mCommand.Parameters.AddWithValue("@cari_unvan1", (object) row["DEFINITION_"].ToString());
        mCommand.Parameters.AddWithValue("@cari_adres", (object) (row["ADDR1"].ToString() + " " + row["ADDR2"].ToString()));
        mCommand.Parameters.AddWithValue("@cari_il", (object) row["CITY"].ToString());
        mCommand.Parameters.AddWithValue("@cari_ilce", (object) row["CITY"].ToString());
        mCommand.Parameters.AddWithValue("@cari_bakiye", (object) Convert.ToDecimal(row["DEBIT"].ToString()));
        DBManager.sqlRunCommand(mCommand);
        ++this.progressBar1.Value;
        Application.DoEvents();
      }
      this.LogoBaglan();
      DataTable dataTable4 = DBManager.sqlGetDataTable(new SqlCommand("SELECT LG_" + this.oku_FIRMA + "_ITEMS.CODE, LG_" + this.oku_FIRMA + "_PRCLIST.CODE AS 'PRICECODE',PRICE,CURRENCY,CLIENTCODE FROM LG_" + this.oku_FIRMA + "_PRCLIST  JOIN LG_" + this.oku_FIRMA + "_ITEMS ON LG_" + this.oku_FIRMA + "_ITEMS.LOGICALREF=LG_" + this.oku_FIRMA + "_PRCLIST.CARDREF WHERE GRPCODE='003' AND BEGDATE<GETDATE()  AND ENDDATE>GETDATE()"));
      DBManager.sqlDisConnect();
      DBManager.sqlConnect("");
      this.label7.Text = "FIYAT LISTESI";
      DBManager.sqlRunCommand(new SqlCommand("DELETE FROM FIYAT_LISTESI"));
      this.progressBar1.Maximum = dataTable4.Rows.Count;
      this.progressBar1.Minimum = 0;
      this.progressBar1.Value = 0;
      this.label8.Text = dataTable4.Rows.Count.ToString();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable4.Rows)
      {
        SqlCommand mCommand = new SqlCommand("INSERT INTO FIYAT_LISTESI (sfiyat_cariKod,sfyt_Recno,sfyt_no,sfyt_stokkod,sfyt_iskonto1,sfyt_iskonto2,sfyt_fiyat,sfiyat_doviz) values (@sfiyat_cariKod,@sfyt_Recno,@sfyt_no,@sfyt_stokkod,@sfyt_iskonto1,@sfyt_iskonto2,@sfyt_fiyat,@sfiyat_doviz)");
        mCommand.Parameters.AddWithValue("@sfyt_Recno", (object) 0);
        mCommand.Parameters.AddWithValue("@sfiyat_doviz", (object) row["CURRENCY"].ToString());
        mCommand.Parameters.AddWithValue("@sfyt_no", (object) "");
        mCommand.Parameters.AddWithValue("@sfyt_stokkod", (object) row["CODE"].ToString());
        mCommand.Parameters.AddWithValue("@sfyt_iskonto1", (object) 0);
        mCommand.Parameters.AddWithValue("@sfyt_iskonto2", (object) 0);
        mCommand.Parameters.AddWithValue("@sfiyat_cariKod", (object) row["CLIENTCODE"].ToString());
        mCommand.Parameters.AddWithValue("@sfyt_fiyat", (object) Convert.ToDecimal(row["PRICE"].ToString()));
        DBManager.sqlRunCommand(mCommand);
        ++this.progressBar1.Value;
        Application.DoEvents();
      }
      DBManager.sqlRunCommand(new SqlCommand("UPDATE FIYAT_LISTESI SET sfiyat_doviz=0 WHERE sfiyat_doviz=160"));
    }

    private void cmbLogoFirma_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        string[] strArray = this.cmbLogoFirma.SelectedValue.ToString().Split('_');
        if (strArray.Length <= 0)
          return;
        this.oku_FIRMA = strArray[0];
        this.oku_DONEM = strArray[1];
        this.oku_FIRMADONEM = this.cmbLogoFirma.SelectedValue.ToString();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmLogoVerial));
      this.groupControl1 = new GroupControl();
      this.button2 = new Button();
      this.label7 = new Label();
      this.label8 = new Label();
      this.label5 = new Label();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.button1 = new Button();
      this.txtServerAdi = new TextBox();
      this.txtKullaniciAdi = new TextBox();
      this.txtDatabase = new TextBox();
      this.txtSifre = new TextBox();
      this.cmbLogoFirma = new System.Windows.Forms.ComboBox();
      this.label10 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.groupControl1.BeginInit();
      this.groupControl1.SuspendLayout();
      this.SuspendLayout();
      this.groupControl1.BorderStyle = BorderStyles.Simple;
      this.groupControl1.Controls.Add((Control) this.button2);
      this.groupControl1.Controls.Add((Control) this.label7);
      this.groupControl1.Controls.Add((Control) this.label8);
      this.groupControl1.Controls.Add((Control) this.label5);
      this.groupControl1.Controls.Add((Control) this.progressBar1);
      this.groupControl1.Controls.Add((Control) this.button1);
      this.groupControl1.Controls.Add((Control) this.txtServerAdi);
      this.groupControl1.Controls.Add((Control) this.txtKullaniciAdi);
      this.groupControl1.Controls.Add((Control) this.txtDatabase);
      this.groupControl1.Controls.Add((Control) this.txtSifre);
      this.groupControl1.Controls.Add((Control) this.cmbLogoFirma);
      this.groupControl1.Controls.Add((Control) this.label10);
      this.groupControl1.Controls.Add((Control) this.label4);
      this.groupControl1.Controls.Add((Control) this.label3);
      this.groupControl1.Controls.Add((Control) this.label2);
      this.groupControl1.Controls.Add((Control) this.label1);
      this.groupControl1.Dock = DockStyle.Fill;
      this.groupControl1.Location = new Point(0, 0);
      this.groupControl1.LookAndFeel.SkinName = "Caramel";
      this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new Size(262, 284);
      this.groupControl1.TabIndex = 2;
      this.groupControl1.Text = "Logo Server Bilgileri :";
      this.button2.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.button2.Location = new Point(87, 117);
      this.button2.Name = "button2";
      this.button2.Size = new Size(170, 23);
      this.button2.TabIndex = 13;
      this.button2.Text = "Bağlantı Sağla";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.label7.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.label7.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label7.Location = new Point(5, 213);
      this.label7.Name = "label7";
      this.label7.Size = new Size(252, 21);
      this.label7.TabIndex = 12;
      this.label7.TextAlign = ContentAlignment.MiddleCenter;
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.White;
      this.label8.Location = new Point(98, 238);
      this.label8.Name = "label8";
      this.label8.Size = new Size(31, 13);
      this.label8.TabIndex = 11;
      this.label8.Text = "0.00";
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.White;
      this.label5.Location = new Point(4, 238);
      this.label5.Name = "label5";
      this.label5.Size = new Size(87, 13);
      this.label5.TabIndex = 8;
      this.label5.Text = "Toplam Kayit :";
      this.progressBar1.Location = new Point(5, (int) byte.MaxValue);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(252, 24);
      this.progressBar1.TabIndex = 7;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.button1.ForeColor = Color.Red;
      this.button1.Image = (Image) Resources.import1;
      this.button1.ImageAlign = ContentAlignment.MiddleLeft;
      this.button1.Location = new Point(5, 168);
      this.button1.Name = "button1";
      this.button1.Size = new Size(252, 42);
      this.button1.TabIndex = 5;
      this.button1.Text = "Aktarimi Başlat";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.txtServerAdi.BorderStyle = BorderStyle.FixedSingle;
      this.txtServerAdi.Location = new Point(87, 25);
      this.txtServerAdi.Name = "txtServerAdi";
      this.txtServerAdi.Size = new Size(170, 21);
      this.txtServerAdi.TabIndex = 1;
      this.txtKullaniciAdi.BorderStyle = BorderStyle.FixedSingle;
      this.txtKullaniciAdi.Location = new Point(87, 47);
      this.txtKullaniciAdi.Name = "txtKullaniciAdi";
      this.txtKullaniciAdi.Size = new Size(170, 21);
      this.txtKullaniciAdi.TabIndex = 2;
      this.txtDatabase.BorderStyle = BorderStyle.FixedSingle;
      this.txtDatabase.Location = new Point(87, 92);
      this.txtDatabase.Name = "txtDatabase";
      this.txtDatabase.Size = new Size(170, 21);
      this.txtDatabase.TabIndex = 3;
      this.txtDatabase.Text = "LOGODEMODB";
      this.txtSifre.BorderStyle = BorderStyle.FixedSingle;
      this.txtSifre.Location = new Point(87, 69);
      this.txtSifre.Name = "txtSifre";
      this.txtSifre.Size = new Size(170, 21);
      this.txtSifre.TabIndex = 3;
      this.cmbLogoFirma.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.cmbLogoFirma.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cmbLogoFirma.FormattingEnabled = true;
      this.cmbLogoFirma.Location = new Point(87, 144);
      this.cmbLogoFirma.Name = "cmbLogoFirma";
      this.cmbLogoFirma.Size = new Size(170, 21);
      this.cmbLogoFirma.TabIndex = 4;
      this.cmbLogoFirma.SelectedIndexChanged += new EventHandler(this.cmbLogoFirma_SelectedIndexChanged);
      this.label10.AutoSize = true;
      this.label10.Location = new Point(5, 103);
      this.label10.Name = "label10";
      this.label10.Size = new Size(85, 13);
      this.label10.TabIndex = 0;
      this.label10.Text = "Database       :";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(5, 152);
      this.label4.Name = "label4";
      this.label4.Size = new Size(83, 13);
      this.label4.TabIndex = 2;
      this.label4.Text = "Logo Şirketi  :";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(5, 80);
      this.label3.Name = "label3";
      this.label3.Size = new Size(84, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Şifre                :";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(5, 58);
      this.label2.Name = "label2";
      this.label2.Size = new Size(86, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Kullanici Adi   :";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(5, 36);
      this.label1.Name = "label1";
      this.label1.Size = new Size(84, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Server Adi     :";
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(262, 284);
      this.Controls.Add((Control) this.groupControl1);
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MaximumSize = new Size(278, 323);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(278, 323);
      this.Name = nameof (frmLogoVerial);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Logodan Verileri Al";
      this.Load += new EventHandler(this.frmLogoVerial_Load);
      this.groupControl1.EndInit();
      this.groupControl1.ResumeLayout(false);
      this.groupControl1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
