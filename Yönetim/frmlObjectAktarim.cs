// Decompiled with JetBrains decompiler
// Type: Yönetim.frmlObjectAktarim
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Yönetim
{
  public class frmlObjectAktarim : Form
  {
    private SqlConnection _sqlServer = new SqlConnection();
    private IContainer components = (IContainer) null;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Button button1;
    private TextBox txtLogoKullanici;
    private TextBox txtLogoKullaniciSifre;
    private TextBox txtLogoFirma;
    private TextBox txtLogoDonem;
    private ProgressBar progressBar1;
    private Button button2;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private TextBox txtSqlServerDb;
    private TextBox txtSqlServerPas;
    private TextBox txtSqlServerUser;
    private TextBox txtSqlServer;
    private ListBox listBox1;

    public frmlObjectAktarim() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void logoCikis()
    {
    }

    private void logoSiparisHazirla()
    {
    }

    private string siparisNoAl(string seri)
    {
      return new SqlCommand("Select ISNULL(MAX(SUBSTRING(FICHENO,5,30)),0)+1 From LG_004_01_ORFICHE WHERE FICHENO LIKE '" + seri + "-%'")
      {
        Connection = this._sqlServer
      }.ExecuteScalar().ToString();
    }

    private string logoAdresKayit(
      string cariAdi,
      string cariAdres,
      string il,
      string ilce,
      string fCarikod)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Parameters.AddWithValue("@NAME", (object) cariAdi);
      sqlCommand.Parameters.AddWithValue("@ADDR1", (object) cariAdres);
      sqlCommand.Parameters.AddWithValue("@CITY", (object) il);
      sqlCommand.Parameters.AddWithValue("@TOWN", (object) ilce);
      sqlCommand.Parameters.AddWithValue("@CARIKOD", (object) fCarikod);
      string str = " \r\n            DECLARE @CODE NVARCHAR(100)\r\n            DECLARE @CLIENTREF INT\r\n            SET @CLIENTREF=(SELECT LOGICALREF FROM LG_004_CLCARD WHERE CODE=@CARIKOD)\r\n            SET @CODE=(SELECT 'CT00'+CONVERT(NVARCHAR(100),MAX(CONVERT(INT,SUBSTRING(CODE,3,10)))+1) from LG_004_SHIPINFO WHERE CODE LIKE 'CT%')\r\n\r\n            INSERT INTO LG_004_SHIPINFO \r\n            ( \r\n            CLIENTREF,\r\n            CODE,\r\n            NAME,\r\n            SPECODE,\r\n            CYPHCODE,\r\n            ADDR1,\r\n            ADDR2,\r\n            CITY,\r\n            COUNTRY,\r\n            POSTCODE,\r\n            TELNRS1,\r\n            TELNRS2,\r\n            FAXNR,\r\n            CAPIBLOCK_CREATEDBY,\r\n            CAPIBLOCK_CREADEDDATE,\r\n            CAPIBLOCK_CREATEDHOUR,\r\n            CAPIBLOCK_CREATEDMIN,\r\n            CAPIBLOCK_CREATEDSEC,\r\n            CAPIBLOCK_MODIFIEDBY,\r\n            CAPIBLOCK_MODIFIEDDATE,\r\n            CAPIBLOCK_MODIFIEDHOUR,\r\n            CAPIBLOCK_MODIFIEDMIN,\r\n            CAPIBLOCK_MODIFIEDSEC,\r\n            SITEID,\r\n            RECSTATUS,\r\n            ORGLOGICREF,\r\n            TRADINGGRP,\r\n            VATNR,\r\n            TAXNR,\r\n            TAXOFFICE,\r\n            TOWNCODE,\r\n            TOWN,\r\n            DISTRICTCODE,\r\n            DISTRICT,\r\n            CITYCODE,\r\n            COUNTRYCODE,\r\n            ACTIVE,\r\n            TEXTINC,\r\n            EMAILADDR,\r\n            INCHANGE,\r\n            TELCODES1,\r\n            TELCODES2,\r\n            FAXCODE,\r\n            LONGITUDE,\r\n            LATITUTE,\r\n            CITYID,\r\n            TOWNID,\r\n            SHIPBEGTIME1,\r\n            SHIPBEGTIME2,\r\n            SHIPBEGTIME3,\r\n            SHIPENDTIME1,\r\n            SHIPENDTIME2,\r\n            SHIPENDTIME3) \r\n            SELECT  \r\n            @CLIENTREF,\r\n            @CODE,\r\n            @NAME,\r\n            SPECODE,\r\n            CYPHCODE,\r\n            @ADDR1,\r\n            ADDR2,\r\n            @CITY,\r\n            COUNTRY,\r\n            POSTCODE,\r\n            TELNRS1,\r\n            TELNRS2,\r\n            FAXNR,\r\n            CAPIBLOCK_CREATEDBY,\r\n            CAPIBLOCK_CREADEDDATE,\r\n            CAPIBLOCK_CREATEDHOUR,\r\n            CAPIBLOCK_CREATEDMIN,\r\n            CAPIBLOCK_CREATEDSEC,\r\n            CAPIBLOCK_MODIFIEDBY,\r\n            CAPIBLOCK_MODIFIEDDATE,\r\n            CAPIBLOCK_MODIFIEDHOUR,\r\n            CAPIBLOCK_MODIFIEDMIN,\r\n            CAPIBLOCK_MODIFIEDSEC,\r\n            SITEID,\r\n            RECSTATUS,\r\n            ORGLOGICREF,\r\n            TRADINGGRP,\r\n            VATNR,\r\n            TAXNR,\r\n            TAXOFFICE,\r\n            TOWNCODE,\r\n            @TOWN,\r\n            DISTRICTCODE,\r\n            DISTRICT,\r\n            CITYCODE,\r\n            COUNTRYCODE,\r\n            ACTIVE,\r\n            TEXTINC,\r\n            EMAILADDR,\r\n            INCHANGE,\r\n            TELCODES1,\r\n            TELCODES2,\r\n            FAXCODE,\r\n            LONGITUDE,\r\n            LATITUTE,\r\n            CITYID,\r\n            TOWNID,\r\n            SHIPBEGTIME1,\r\n            SHIPBEGTIME2,\r\n            SHIPBEGTIME3,\r\n            SHIPENDTIME1,\r\n            SHIPENDTIME2,\r\n            SHIPENDTIME3 FROM LG_004_SHIPINFO WHERE LOGICALREF=747 ;select @CODE ";
      sqlCommand.CommandText = str;
      sqlCommand.Connection = this._sqlServer;
      return sqlCommand.ExecuteScalar().ToString();
    }

    private void logoSiparisAktar(DataTable dtKalemler, DataRow drBaslik, string seri)
    {
    }

    private string LogoBaglan()
    {
      return string.Format("Data Source={0};Initial Catalog={1};User Id={2};password={3};", (object) this.txtSqlServer.Text, (object) this.txtSqlServerDb.Text, (object) this.txtSqlServerUser.Text, (object) this.txtSqlServerPas.Text);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      this._sqlServer.ConnectionString = this.LogoBaglan();
      this._sqlServer.Open();
      this.logoSiparisHazirla();
      this._sqlServer.Close();
      Cursor.Current = Cursors.Arrow;
      int num = (int) MessageBox.Show("AKTARIM BİTTİ");
    }

    private void frmlObjectAktarim_Load(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmlObjectAktarim));
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.button1 = new Button();
      this.txtLogoKullanici = new TextBox();
      this.txtLogoKullaniciSifre = new TextBox();
      this.txtLogoFirma = new TextBox();
      this.txtLogoDonem = new TextBox();
      this.progressBar1 = new ProgressBar();
      this.button2 = new Button();
      this.label6 = new Label();
      this.label7 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.txtSqlServerDb = new TextBox();
      this.txtSqlServerPas = new TextBox();
      this.txtSqlServerUser = new TextBox();
      this.txtSqlServer = new TextBox();
      this.listBox1 = new ListBox();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label1.Location = new Point(3, 13);
      this.label1.Name = "label1";
      this.label1.Size = new Size(97, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "LOGO KULLANICI :";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label2.Location = new Point(3, 36);
      this.label2.Name = "label2";
      this.label2.Size = new Size(98, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "LOGO ŞİFRE         :";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label3.Location = new Point(3, 59);
      this.label3.Name = "label3";
      this.label3.Size = new Size(98, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "FİRMA KODU        :";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label4.Location = new Point(3, 83);
      this.label4.Name = "label4";
      this.label4.Size = new Size(99, 13);
      this.label4.TabIndex = 3;
      this.label4.Text = "DÖNEM KODU       :";
      this.button1.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.button1.ForeColor = Color.Red;
      this.button1.Location = new Point(3, 102);
      this.button1.Name = "button1";
      this.button1.Size = new Size(291, 31);
      this.button1.TabIndex = 4;
      this.button1.Text = "LOGOYA BAĞLAN";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.txtLogoKullanici.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.txtLogoKullanici.Location = new Point(97, 5);
      this.txtLogoKullanici.Name = "txtLogoKullanici";
      this.txtLogoKullanici.Size = new Size(197, 21);
      this.txtLogoKullanici.TabIndex = 5;
      this.txtLogoKullanici.Text = "CENGIZ";
      this.txtLogoKullaniciSifre.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.txtLogoKullaniciSifre.Location = new Point(97, 28);
      this.txtLogoKullaniciSifre.Name = "txtLogoKullaniciSifre";
      this.txtLogoKullaniciSifre.PasswordChar = '*';
      this.txtLogoKullaniciSifre.Size = new Size(197, 21);
      this.txtLogoKullaniciSifre.TabIndex = 6;
      this.txtLogoKullaniciSifre.Text = "102030";
      this.txtLogoFirma.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.txtLogoFirma.Location = new Point(97, 51);
      this.txtLogoFirma.Name = "txtLogoFirma";
      this.txtLogoFirma.Size = new Size(197, 21);
      this.txtLogoFirma.TabIndex = 7;
      this.txtLogoFirma.Text = "4";
      this.txtLogoDonem.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.txtLogoDonem.Location = new Point(97, 75);
      this.txtLogoDonem.Name = "txtLogoDonem";
      this.txtLogoDonem.Size = new Size(197, 21);
      this.txtLogoDonem.TabIndex = 8;
      this.txtLogoDonem.Text = "1";
      this.progressBar1.Location = new Point(3, 137);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(609, 26);
      this.progressBar1.TabIndex = 9;
      this.button2.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.button2.FlatStyle = FlatStyle.Flat;
      this.button2.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.button2.ForeColor = Color.Blue;
      this.button2.Location = new Point(301, 102);
      this.button2.Name = "button2";
      this.button2.Size = new Size(311, 31);
      this.button2.TabIndex = 11;
      this.button2.Text = "AKTARIM";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Visible = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label6.Location = new Point(298, 13);
      this.label6.Name = "label6";
      this.label6.Size = new Size(89, 13);
      this.label6.TabIndex = 12;
      this.label6.Text = "LOGO SERVER   :";
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label7.Location = new Point(298, 36);
      this.label7.Name = "label7";
      this.label7.Size = new Size(88, 13);
      this.label7.TabIndex = 13;
      this.label7.Text = "SQL KULLANICI :";
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label8.Location = new Point(298, 59);
      this.label8.Name = "label8";
      this.label8.Size = new Size(89, 13);
      this.label8.TabIndex = 14;
      this.label8.Text = "SQL ŞİFRE         :";
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label9.Location = new Point(298, 83);
      this.label9.Name = "label9";
      this.label9.Size = new Size(88, 13);
      this.label9.TabIndex = 15;
      this.label9.Text = "SQL DB              :";
      this.txtSqlServerDb.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.txtSqlServerDb.Location = new Point(388, 75);
      this.txtSqlServerDb.Name = "txtSqlServerDb";
      this.txtSqlServerDb.Size = new Size(224, 21);
      this.txtSqlServerDb.TabIndex = 19;
      this.txtSqlServerDb.Text = "LKSDB";
      this.txtSqlServerPas.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.txtSqlServerPas.Location = new Point(388, 51);
      this.txtSqlServerPas.Name = "txtSqlServerPas";
      this.txtSqlServerPas.PasswordChar = '*';
      this.txtSqlServerPas.Size = new Size(224, 21);
      this.txtSqlServerPas.TabIndex = 18;
      this.txtSqlServerPas.Text = "1a2b3c4d";
      this.txtSqlServerUser.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.txtSqlServerUser.Location = new Point(388, 28);
      this.txtSqlServerUser.Name = "txtSqlServerUser";
      this.txtSqlServerUser.Size = new Size(224, 21);
      this.txtSqlServerUser.TabIndex = 17;
      this.txtSqlServerUser.Text = "pensanfuar";
      this.txtSqlServer.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.txtSqlServer.Location = new Point(388, 5);
      this.txtSqlServer.Name = "txtSqlServer";
      this.txtSqlServer.Size = new Size(224, 21);
      this.txtSqlServer.TabIndex = 16;
      this.txtSqlServer.Text = "192.168.2.206";
      this.listBox1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new Point(3, 166);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(609, 355);
      this.listBox1.TabIndex = 20;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(615, 525);
      this.Controls.Add((Control) this.listBox1);
      this.Controls.Add((Control) this.txtSqlServerDb);
      this.Controls.Add((Control) this.txtSqlServerPas);
      this.Controls.Add((Control) this.txtSqlServerUser);
      this.Controls.Add((Control) this.txtSqlServer);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.progressBar1);
      this.Controls.Add((Control) this.txtLogoDonem);
      this.Controls.Add((Control) this.txtLogoFirma);
      this.Controls.Add((Control) this.txtLogoKullaniciSifre);
      this.Controls.Add((Control) this.txtLogoKullanici);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmlObjectAktarim);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Logo Sipariş Aktarim";
      this.Load += new EventHandler(this.frmlObjectAktarim_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
