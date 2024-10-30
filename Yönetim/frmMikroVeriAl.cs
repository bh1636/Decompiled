// Decompiled with JetBrains decompiler
// Type: Yönetim.frmMikroVeriAl
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.XtraEditors;
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
  public class frmMikroVeriAl : Form
  {
    private IContainer components = (IContainer) null;
    private GroupControl groupControl1;
    private Button button2;
    private Label label7;
    private Label label8;
    private Label label5;
    private System.Windows.Forms.ProgressBar progressBar1;
    private Button button1;
    private TextBox txtServerAdi;
    private TextBox txtKullaniciAdi;
    private TextBox txtDatabase;
    private TextBox txtSifre;
    private Label label10;
    private Label label3;
    private Label label2;
    private Label label1;

    public frmMikroVeriAl() => this.InitializeComponent();

    private void LogoBaglan()
    {
      DBManager.sqlDisConnect();
      DBManager.sqlConnect(string.Format("Data Source={0};Initial Catalog={1};User Id={2};password={3};", (object) this.txtServerAdi.Text, (object) this.txtDatabase.Text, (object) this.txtKullaniciAdi.Text, (object) this.txtSifre.Text));
    }

    private void frmMikroVeriAl_Load(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.LogoBaglan();
      DataTable dataTable1 = DBManager.sqlGetDataTable(new SqlCommand("SELECT sto_RECno,sto_kod,sto_isim,sto_perakende_vergi,0 as 'Bakiye',sto_birim1_ad FROM STOKLAR  "));
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
        SqlCommand mCommand = new SqlCommand("INSERT INTO STOKLAR (sto_Recno,sto_kod,sto_isim,sto_perakende_vergi,sto_Bakiye,sto_birim) values (@sto_Recno,@sto_kod,@sto_isim,@sto_perakende_vergi,@sto_Bakiye,@birim)");
        mCommand.Parameters.AddWithValue("@sto_Recno", (object) row["sto_Recno"].ToString());
        mCommand.Parameters.AddWithValue("@sto_kod", (object) row["sto_kod"].ToString());
        mCommand.Parameters.AddWithValue("@sto_isim", (object) row["sto_isim"].ToString());
        mCommand.Parameters.AddWithValue("@birim", (object) row["sto_birim1_ad"].ToString());
        int num = 0;
        if (row["sto_perakende_vergi"].ToString() == "4")
          num = 18;
        if (row["sto_perakende_vergi"].ToString() == "3")
          num = 8;
        mCommand.Parameters.AddWithValue("@sto_perakende_vergi", (object) num);
        mCommand.Parameters.AddWithValue("@sto_Bakiye", (object) Convert.ToDecimal(row["Bakiye"].ToString()));
        DBManager.sqlRunCommand(mCommand);
        ++this.progressBar1.Value;
        Application.DoEvents();
      }
      this.LogoBaglan();
      DataTable dataTable2 = DBManager.sqlGetDataTable(new SqlCommand("SELECT bar_RECno,bar_stokkodu,bar_kodu,dbo.fn_StokBirimi(bar_stokkodu,bar_birimpntr) as 'Birim' FROM BARKOD_TANIMLARI"));
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
        SqlCommand mCommand = new SqlCommand("INSERT INTO BARKOD_TANIMLARI (bar_Recno,bar_stokkod,bar_kodu,bar_birim) values (@bar_Recno,@bar_stokkod,@bar_kodu,@bar_birim)");
        mCommand.Parameters.AddWithValue("@bar_Recno", (object) row["bar_recno"].ToString());
        mCommand.Parameters.AddWithValue("@bar_stokkod", (object) row["bar_stokkodu"].ToString());
        mCommand.Parameters.AddWithValue("@bar_kodu", (object) row["bar_kodu"].ToString());
        mCommand.Parameters.AddWithValue("@bar_birim", (object) row["Birim"].ToString());
        DBManager.sqlRunCommand(mCommand);
        ++this.progressBar1.Value;
        Application.DoEvents();
      }
      this.LogoBaglan();
      DataTable dataTable3 = DBManager.sqlGetDataTable(new SqlCommand("SELECT cari_kod,\r\n       cari_unvan1,\r\n       CARI_HESAP_ADRESLERI.adr_cadde,\r\n       CARI_HESAP_ADRESLERI.adr_sokak,\r\n       CARI_HESAP_ADRESLERI.adr_ilce,\r\n       CARI_HESAP_ADRESLERI.adr_il,\r\n       '' 'cari_tipi',\r\n       0 AS 'Bakiye',adr_ozel_not\r\n       FROM   CARI_HESAPLAR\r\n       left JOIN CARI_HESAP_ADRESLERI\r\n            ON  CARI_HESAP_ADRESLERI.adr_adres_no = 1\r\n            AND CARI_HESAP_ADRESLERI.adr_cari_kod = CARI_HESAPLAR.cari_kod\r\n\r\n\t\t\tUNION ALL\r\n\t\t\tSELECT  adaycr_kod,adaycr_unvan1,'','','',adaycr_unvan2,1,0,'' FROM ADAY_CARI_HESAPLAR"));
      DBManager.sqlDisConnect();
      DBManager.sqlConnect("");
      this.label7.Text = "CARI HESAPLAR";
      this.progressBar1.Maximum = dataTable3.Rows.Count;
      this.progressBar1.Minimum = 0;
      this.progressBar1.Value = 0;
      this.label8.Text = dataTable3.Rows.Count.ToString();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable3.Rows)
      {
        SqlCommand mCommand = new SqlCommand("DELETE FROM CARI_HESAPLAR where cari_kod=@cari_kod;INSERT INTO CARI_HESAPLAR (cari_kod,cari_unvan1,cari_adres,cari_il,cari_ilce,cari_bakiye,cari_telefon) values (@cari_kod,@cari_unvan1,@cari_adres,@cari_il,@cari_ilce,@cari_bakiye,@cari_telefon)");
        mCommand.Parameters.AddWithValue("@cari_telefon", (object) row["adr_ozel_not"].ToString());
        mCommand.Parameters.AddWithValue("@cari_kod", (object) row["cari_kod"].ToString());
        mCommand.Parameters.AddWithValue("@cari_unvan1", (object) row["cari_unvan1"].ToString());
        mCommand.Parameters.AddWithValue("@cari_adres", (object) (row["adr_cadde"].ToString() + " " + row["adr_sokak"].ToString()));
        mCommand.Parameters.AddWithValue("@cari_il", (object) row["adr_ilce"].ToString());
        mCommand.Parameters.AddWithValue("@cari_ilce", (object) row["adr_il"].ToString());
        mCommand.Parameters.AddWithValue("@cari_bakiye", (object) Convert.ToDecimal(row["Bakiye"].ToString()));
        DBManager.sqlRunCommand(mCommand);
        ++this.progressBar1.Value;
        Application.DoEvents();
      }
      this.LogoBaglan();
      this.LogoBaglan();
      DataTable dataTable4 = DBManager.sqlGetDataTable(new SqlCommand("SELECT sfiyat_RECno,sfiyat_stokkod, sfiyat_listesirano, sfiyat_fiyati FROM STOK_SATIS_FIYAT_LISTELERI where sfiyat_listesirano=1"));
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
        SqlCommand mCommand = new SqlCommand("INSERT INTO FIYAT_LISTESI (sfyt_Recno,sfyt_no,sfyt_stokkod,sfyt_iskonto1,sfyt_iskonto2,sfyt_fiyat) values (@sfyt_Recno,@sfyt_no,@sfyt_stokkod,@sfyt_iskonto1,@sfyt_iskonto2,@sfyt_fiyat)");
        mCommand.Parameters.AddWithValue("@sfyt_Recno", (object) 0);
        mCommand.Parameters.AddWithValue("@sfyt_no", (object) row["sfiyat_listesirano"].ToString());
        mCommand.Parameters.AddWithValue("@sfyt_stokkod", (object) row["sfiyat_stokkod"].ToString());
        mCommand.Parameters.AddWithValue("@sfyt_iskonto1", (object) 0);
        mCommand.Parameters.AddWithValue("@sfyt_iskonto2", (object) 0);
        mCommand.Parameters.AddWithValue("@sfyt_fiyat", (object) Convert.ToDouble(row["sfiyat_fiyati"].ToString()));
        DBManager.sqlRunCommand(mCommand);
        ++this.progressBar1.Value;
        Application.DoEvents();
      }
    }

    private void groupControl1_Paint(object sender, PaintEventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmMikroVeriAl));
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
      this.label10 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.groupControl1.BeginInit();
      this.groupControl1.SuspendLayout();
      this.SuspendLayout();
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
      this.groupControl1.Controls.Add((Control) this.label10);
      this.groupControl1.Controls.Add((Control) this.label3);
      this.groupControl1.Controls.Add((Control) this.label2);
      this.groupControl1.Controls.Add((Control) this.label1);
      this.groupControl1.Dock = DockStyle.Fill;
      this.groupControl1.Location = new Point(0, 0);
      this.groupControl1.LookAndFeel.SkinName = "Lilian";
      this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new Size(262, 285);
      this.groupControl1.TabIndex = 3;
      this.groupControl1.Text = "Mikro Server Bilgileri";
      this.groupControl1.Paint += new PaintEventHandler(this.groupControl1_Paint);
      this.button2.FlatStyle = FlatStyle.Flat;
      this.button2.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.button2.ForeColor = Color.Red;
      this.button2.Location = new Point(87, 118);
      this.button2.Name = "button2";
      this.button2.Size = new Size(172, 23);
      this.button2.TabIndex = 13;
      this.button2.Text = "Bağlantı Sağla";
      this.button2.UseVisualStyleBackColor = true;
      this.label7.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.label7.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label7.ForeColor = Color.Blue;
      this.label7.Location = new Point(5, 214);
      this.label7.Name = "label7";
      this.label7.Size = new Size(254, 21);
      this.label7.TabIndex = 12;
      this.label7.TextAlign = ContentAlignment.MiddleCenter;
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.White;
      this.label8.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label8.ForeColor = Color.Blue;
      this.label8.Location = new Point(98, 240);
      this.label8.Name = "label8";
      this.label8.Size = new Size(31, 13);
      this.label8.TabIndex = 11;
      this.label8.Text = "0.00";
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.White;
      this.label5.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label5.ForeColor = Color.Blue;
      this.label5.Location = new Point(4, 240);
      this.label5.Name = "label5";
      this.label5.Size = new Size(87, 13);
      this.label5.TabIndex = 8;
      this.label5.Text = "Toplam Kayit :";
      this.progressBar1.ForeColor = Color.Blue;
      this.progressBar1.Location = new Point(5, 257);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(254, 24);
      this.progressBar1.TabIndex = 7;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.button1.ForeColor = Color.Red;
      this.button1.Image = (Image) Resources.import1;
      this.button1.ImageAlign = ContentAlignment.MiddleLeft;
      this.button1.Location = new Point(5, 144);
      this.button1.Name = "button1";
      this.button1.Size = new Size(254, 64);
      this.button1.TabIndex = 5;
      this.button1.Text = "Aktarimi Başlat";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.txtServerAdi.BorderStyle = BorderStyle.FixedSingle;
      this.txtServerAdi.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtServerAdi.Location = new Point(87, 26);
      this.txtServerAdi.Name = "txtServerAdi";
      this.txtServerAdi.Size = new Size(172, 21);
      this.txtServerAdi.TabIndex = 1;
      this.txtKullaniciAdi.BorderStyle = BorderStyle.FixedSingle;
      this.txtKullaniciAdi.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtKullaniciAdi.Location = new Point(87, 48);
      this.txtKullaniciAdi.Name = "txtKullaniciAdi";
      this.txtKullaniciAdi.Size = new Size(172, 21);
      this.txtKullaniciAdi.TabIndex = 2;
      this.txtDatabase.BorderStyle = BorderStyle.FixedSingle;
      this.txtDatabase.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtDatabase.Location = new Point(87, 93);
      this.txtDatabase.Name = "txtDatabase";
      this.txtDatabase.Size = new Size(172, 21);
      this.txtDatabase.TabIndex = 3;
      this.txtDatabase.Text = "MikroDB_V12_";
      this.txtSifre.BorderStyle = BorderStyle.FixedSingle;
      this.txtSifre.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtSifre.Location = new Point(87, 70);
      this.txtSifre.Name = "txtSifre";
      this.txtSifre.Size = new Size(172, 21);
      this.txtSifre.TabIndex = 3;
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label10.Location = new Point(5, 104);
      this.label10.Name = "label10";
      this.label10.Size = new Size(85, 13);
      this.label10.TabIndex = 0;
      this.label10.Text = "Database       :";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label3.Location = new Point(5, 81);
      this.label3.Name = "label3";
      this.label3.Size = new Size(84, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Şifre                :";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label2.Location = new Point(5, 59);
      this.label2.Name = "label2";
      this.label2.Size = new Size(86, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Kullanici Adi   :";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label1.Location = new Point(5, 37);
      this.label1.Name = "label1";
      this.label1.Size = new Size(84, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Server Adi     :";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(262, 285);
      this.Controls.Add((Control) this.groupControl1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MaximumSize = new Size(278, 323);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(278, 323);
      this.Name = nameof (frmMikroVeriAl);
      this.Text = "Extra Sipariş  Sistemi";
      this.Load += new EventHandler(this.frmMikroVeriAl_Load);
      this.groupControl1.EndInit();
      this.groupControl1.ResumeLayout(false);
      this.groupControl1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
