// Decompiled with JetBrains decompiler
// Type: Yönetim.frmMikroSiparisKayit
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
  public class frmMikroSiparisKayit : Form
  {
    private DataTable siplaris = (DataTable) null;
    private IContainer components = (IContainer) null;
    private GroupControl groupControl1;
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

    public frmMikroSiparisKayit() => this.InitializeComponent();

    private void LogoBaglan()
    {
      DBManager.sqlDisConnect();
      DBManager.sqlConnect(string.Format("Data Source={0};Initial Catalog={1};User Id={2};password={3};", (object) this.txtServerAdi.Text, (object) this.txtDatabase.Text, (object) this.txtKullaniciAdi.Text, (object) this.txtSifre.Text));
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.siplaris = DBManager.sqlGetDataTable(new SqlCommand("SELECT sip_evrakno_seri\r\n\t,sip_evrakno_sira\r\n\t,sip_stok_kod\r\n\t,sip_musteri_kod\r\n\t,sip_miktar\r\n\t,sip_b_fiyat\r\n\t,sip_tutar\r\n\t,sip_iskonto_1\r\n\t,sip_iskonto_2\r\n\t,sip_birim_pntr\r\n\t,0 sip_iskonto1\r\n\t,sip_vergi\r\n\t,ISNULL((Select TOP 1 UPPER(cari_unvan1) From CARI_HESAPLAR WHERE cari_kod=sip_arabayiadi),'KENDİSİ') 'sip_altfirma'\r\n\t,sip_aciklama\r\n\t,ISNULL((Select TOP 1 cari_telefon From CARI_HESAPLAR WHERE cari_kod=sip_arabayiadi),'') sip_alttelefon\r\n\t,ISNULL((Select TOP 1 UPPER(cari_il +'-'+ cari_ilce) From CARI_HESAPLAR WHERE cari_kod=sip_arabayiadi),'') sip_altyetkili\r\n    ,ARABAYIADI\r\nFROM SIPARISLER\r\nORDER BY sip_evrakno_seri\r\n\t,sip_evrakno_sira\r\n\t,sip_satirno\r\n"));
      this.label8.Text = this.siplaris.Rows.Count.ToString();
      this.LogoBaglan();
      this.progressBar1.Maximum = 0;
      this.progressBar1.Minimum = 0;
      int num1 = 0;
      this.progressBar1.Minimum = 0;
      this.progressBar1.Maximum = this.siplaris.Rows.Count;
      foreach (DataRow row in (InternalDataCollectionBase) this.siplaris.Rows)
      {
        Application.DoEvents();
        ++num1;
        this.progressBar1.Value = num1;
        this.label7.Text = this.progressBar1.Maximum.ToString() + " / " + num1.ToString();
        SqlCommand mCommand = new SqlCommand();
        mCommand.CommandText = "extrap_SIPARIS_KAYIT";
        mCommand.Parameters.AddWithValue("@SERI", (object) row["sip_evrakno_seri"].ToString());
        mCommand.Parameters.AddWithValue("@SIRA", (object) Convert.ToInt32(row["sip_evrakno_sira"].ToString()));
        mCommand.Parameters.AddWithValue("@STOKKODU", (object) row["sip_stok_kod"].ToString());
        mCommand.Parameters.AddWithValue("@MUSTERIKODU", (object) row["sip_musteri_kod"].ToString());
        mCommand.Parameters.AddWithValue("@MIKTAR", (object) Convert.ToDouble(row["sip_miktar"].ToString()));
        mCommand.Parameters.AddWithValue("@BFIYAT", (object) Convert.ToDouble(row["sip_b_fiyat"].ToString()));
        mCommand.Parameters.AddWithValue("@TUTAR", (object) Convert.ToDouble(row["sip_tutar"].ToString()));
        mCommand.Parameters.AddWithValue("@ISKONTO1", (object) Convert.ToDouble(row["sip_iskonto_1"].ToString()));
        mCommand.Parameters.AddWithValue("@ISKONTO2", (object) Convert.ToDouble(row["sip_iskonto_2"].ToString()));
        mCommand.Parameters.AddWithValue("@BIRIM", (object) 1);
        mCommand.Parameters.AddWithValue("@VERGIPNTR", (object) Convert.ToInt32(row["sip_birim_pntr"].ToString()));
        mCommand.Parameters.AddWithValue("@DOVIZ", (object) Convert.ToInt32(row["sip_iskonto1"].ToString()));
        mCommand.Parameters.AddWithValue("@ACIKLAMA", (object) "");
        mCommand.Parameters.AddWithValue("@BAYIKOD", (object) "");
        mCommand.Parameters.AddWithValue("@VERGI", (object) Convert.ToDouble(row["sip_vergi"].ToString()));
        mCommand.Parameters.AddWithValue("@FIRMA", (object) row["sip_altfirma"].ToString());
        mCommand.Parameters.AddWithValue("@YETKILI", (object) row["sip_aciklama"].ToString());
        mCommand.Parameters.AddWithValue("@TEL", (object) row["sip_alttelefon"].ToString());
        mCommand.Parameters.AddWithValue("@ADRES", (object) row["sip_altyetkili"].ToString());
        mCommand.Parameters.AddWithValue("@ARABAYI", (object) row["ARABAYIADI"].ToString());
        mCommand.CommandType = CommandType.StoredProcedure;
        DBManager.sqlRunCommand(mCommand);
      }
      int num2 = (int) MessageBox.Show("Aktarim Tamamlandı", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
      Application.Exit();
    }

    private void button2_Click(object sender, EventArgs e)
    {
    }

    private void frmMikroSiparisKayit_Load(object sender, EventArgs e)
    {
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmMikroSiparisKayit));
      this.groupControl1 = new GroupControl();
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
      this.SuspendLayout();
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
      this.groupControl1.LookAndFeel.SkinName = "Caramel";
      this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new Size(263, 282);
      this.groupControl1.TabIndex = 4;
      this.groupControl1.Text = "Mikro Server Bilgileri";
      this.groupControl1.Paint += new PaintEventHandler(this.groupControl1_Paint);
      this.label7.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.label7.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label7.ForeColor = Color.Blue;
      this.label7.Location = new Point(8, 210);
      this.label7.Name = "label7";
      this.label7.Size = new Size(250, 25);
      this.label7.TabIndex = 12;
      this.label7.TextAlign = ContentAlignment.MiddleCenter;
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.White;
      this.label8.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label8.ForeColor = Color.Blue;
      this.label8.Location = new Point(98, 238);
      this.label8.Name = "label8";
      this.label8.Size = new Size(31, 13);
      this.label8.TabIndex = 11;
      this.label8.Text = "0.00";
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.White;
      this.label5.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label5.ForeColor = Color.Blue;
      this.label5.Location = new Point(5, 238);
      this.label5.Name = "label5";
      this.label5.Size = new Size(87, 13);
      this.label5.TabIndex = 8;
      this.label5.Text = "Toplam Kayit :";
      this.progressBar1.Location = new Point(8, (int) byte.MaxValue);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(250, 24);
      this.progressBar1.TabIndex = 7;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.button1.ForeColor = Color.Red;
      this.button1.Image = (Image) Resources.import1;
      this.button1.ImageAlign = ContentAlignment.MiddleLeft;
      this.button1.Location = new Point(8, 116);
      this.button1.Name = "button1";
      this.button1.Size = new Size(250, 69);
      this.button1.TabIndex = 5;
      this.button1.Text = "Aktarimi Başlat";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.txtServerAdi.BorderStyle = BorderStyle.FixedSingle;
      this.txtServerAdi.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtServerAdi.ForeColor = Color.Red;
      this.txtServerAdi.Location = new Point(87, 25);
      this.txtServerAdi.Name = "txtServerAdi";
      this.txtServerAdi.Size = new Size(171, 21);
      this.txtServerAdi.TabIndex = 1;
      this.txtKullaniciAdi.BorderStyle = BorderStyle.FixedSingle;
      this.txtKullaniciAdi.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtKullaniciAdi.ForeColor = Color.Red;
      this.txtKullaniciAdi.Location = new Point(87, 47);
      this.txtKullaniciAdi.Name = "txtKullaniciAdi";
      this.txtKullaniciAdi.Size = new Size(171, 21);
      this.txtKullaniciAdi.TabIndex = 2;
      this.txtKullaniciAdi.Text = "fuar";
      this.txtDatabase.BorderStyle = BorderStyle.FixedSingle;
      this.txtDatabase.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtDatabase.ForeColor = Color.Red;
      this.txtDatabase.Location = new Point(87, 92);
      this.txtDatabase.Name = "txtDatabase";
      this.txtDatabase.Size = new Size(171, 21);
      this.txtDatabase.TabIndex = 3;
      this.txtDatabase.Text = "MikroDB_V14_HELVACI";
      this.txtSifre.BorderStyle = BorderStyle.FixedSingle;
      this.txtSifre.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtSifre.ForeColor = Color.Red;
      this.txtSifre.Location = new Point(87, 69);
      this.txtSifre.Name = "txtSifre";
      this.txtSifre.Size = new Size(171, 21);
      this.txtSifre.TabIndex = 3;
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label10.Location = new Point(5, 100);
      this.label10.Name = "label10";
      this.label10.Size = new Size(85, 13);
      this.label10.TabIndex = 0;
      this.label10.Text = "Database       :";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label3.Location = new Point(5, 77);
      this.label3.Name = "label3";
      this.label3.Size = new Size(84, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Şifre                :";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label2.Location = new Point(5, 55);
      this.label2.Name = "label2";
      this.label2.Size = new Size(86, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Kullanici Adi   :";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label1.Location = new Point(5, 33);
      this.label1.Name = "label1";
      this.label1.Size = new Size(84, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Server Adi     :";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(263, 282);
      this.Controls.Add((Control) this.groupControl1);
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MaximumSize = new Size(279, 321);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(279, 321);
      this.Name = nameof (frmMikroSiparisKayit);
      this.Text = "Mikroya Sipariş Aktarım";
      this.Load += new EventHandler(this.frmMikroSiparisKayit_Load);
      this.groupControl1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
