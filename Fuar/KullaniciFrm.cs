// Decompiled with JetBrains decompiler
// Type: Fuar.KullaniciFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Fuar.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class KullaniciFrm : XtraForm
  {
    public string kull_id = string.Empty;
    public static string ted_id = string.Empty;
    public static string ted_name = string.Empty;
    public static byte[] ted_logo;
    private IContainer components;
    private SimpleButton btn_kaydet;
    private SimpleButton btn_iptal;
    private TextBox txt_kadi;
    private TextBox txt_sifre;
    private TextBox txt_adi;
    private TextBox txt_soyadi;
    private TextBox txt_unvan;
    private TextBox txt_mail;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private PictureBox pb_kull;
    private SimpleButton btn_resim_ekle;
    private SimpleButton btn_resim_sil;
    private OpenFileDialog ofd;
    private MaskedTextBox txt_gsm;
    private ButtonEdit txt_tedarikci;
    private PictureBox pb_ted;
    private Label label10;
    private ErrorProvider ep1;
    private GroupBox groupBox1;

    public KullaniciFrm() => this.InitializeComponent();

    private void KullaniciFrm_Load(object sender, EventArgs e)
    {
      this.txt_gsm.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
      if (!(this.kull_id != ""))
        return;
      DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM KULLANICILAR WHERE ID = " + this.kull_id);
      if (dataTable.Rows.Count <= 0)
        return;
      this.txt_kadi.Text = dataTable.Rows[0]["KULLANICIADI"].ToString();
      this.txt_sifre.Text = _main.Decrypt(dataTable.Rows[0]["SIFRE"].ToString(), "951623");
      this.txt_adi.Text = dataTable.Rows[0]["ADI"].ToString();
      this.txt_soyadi.Text = dataTable.Rows[0]["SOYADI"].ToString();
      this.txt_unvan.Text = dataTable.Rows[0]["UNVAN"].ToString();
      this.txt_mail.Text = dataTable.Rows[0]["EPOSTA"].ToString();
      this.txt_gsm.Text = dataTable.Rows[0]["GSM"].ToString();
      this.txt_tedarikci.Text = KullaniciFrm.ted_name = dataTable.Rows[0]["TEDARIKCIADI"].ToString();
      KullaniciFrm.ted_id = dataTable.Rows[0]["TEDARIKCIID"].ToString();
      this.pb_kull.Image = _main.byteArrayToImage((byte[]) dataTable.Rows[0]["RESIM"]);
      DataTable tedarikciInfo = this.get_tedarikci_info(KullaniciFrm.ted_id);
      if (tedarikciInfo.Rows.Count > 0)
        KullaniciFrm.ted_logo = (byte[]) tedarikciInfo.Rows[0]["TEDARIKCILOGOSU"];
      if (KullaniciFrm.ted_logo == null)
        return;
      this.pb_ted.Image = _main.byteArrayToImage(KullaniciFrm.ted_logo);
    }

    private void btn_resim_ekle_Click(object sender, EventArgs e)
    {
      this.ofd.Filter = "Fotoğraf Dosyaları (*.jpg)|*.jpg";
      if (this.ofd.ShowDialog() != DialogResult.OK)
        return;
      this.pb_kull.Image = Image.FromFile(this.ofd.FileName);
    }

    private void btn_resim_sil_Click(object sender, EventArgs e)
    {
      this.pb_kull.Image = (Image) null;
    }

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.alan_kontrol())
          return;
        if (this.kull_id == "")
        {
          if (!this.check_username(this.txt_adi.Text))
            this.insert_user();
        }
        else if (!this.check_username(this.txt_adi.Text, this.kull_id))
          this.update_user(this.kull_id);
        this.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void insert_user()
    {
      byte[] numArray = this.pb_kull.Image != null ? _main.imageToByteArray(this.pb_kull.Image) : _main.imageToByteArray((Image) Resources.no_photo);
      string cmdText = "INSERT INTO KULLANICILAR (KULLANICIADI,SIFRE,ADI,SOYADI,UNVAN,EPOSTA,GSM,TEDARIKCIID,TEDARIKCIADI,GRUPID,RESIM) " + "VALUES ('" + this.txt_kadi.Text + "','" + _main.Encrypt(this.txt_sifre.Text.ToString(), "951623") + "','" + this.txt_adi.Text + "','" + this.txt_soyadi.Text + "','" + this.txt_unvan.Text + "','" + this.txt_mail.Text + "','" + this.txt_gsm.Text + "','" + KullaniciFrm.ted_id + "','" + this.txt_tedarikci.Text + "',0,@RESIM)";
      SqlConnection connection = new SqlConnection(_main.str_connection);
      SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
      sqlCommand.Parameters.AddWithValue("@RESIM", (object) numArray);
      connection.Open();
      sqlCommand.ExecuteNonQuery();
      connection.Close();
    }

    private void update_user(string kullanici_id)
    {
      byte[] numArray = this.pb_kull.Image != null ? _main.imageToByteArray(this.pb_kull.Image) : _main.imageToByteArray((Image) Resources.no_photo);
      string cmdText = " UPDATE KULLANICILAR SET KULLANICIADI = '" + this.txt_kadi.Text + "',SIFRE = '" + _main.Encrypt(this.txt_sifre.Text.ToString(), "951623") + "',ADI = '" + this.txt_adi.Text + "',SOYADI = '" + this.txt_soyadi.Text + "'," + "UNVAN = '" + this.txt_unvan.Text + "',EPOSTA = '" + this.txt_mail.Text + "',GSM = '" + this.txt_gsm.Text + "',TEDARIKCIID = " + KullaniciFrm.ted_id + ",TEDARIKCIADI = '" + this.txt_tedarikci.Text + "',RESIM = @RESIM " + " WHERE ID = " + kullanici_id;
      SqlConnection connection = new SqlConnection(_main.str_connection);
      SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
      sqlCommand.Parameters.AddWithValue("@RESIM", (object) numArray);
      connection.Open();
      sqlCommand.ExecuteNonQuery();
      connection.Close();
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void txt_tedarikci_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      TedarikcilerSel tedarikcilerSel = new TedarikcilerSel();
      tedarikcilerSel.MdiParent = this.MdiParent;
      tedarikcilerSel.Show();
    }

    private void KullaniciFrm_Activated(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Maximized;
      if (!(KullaniciFrm.ted_id != ""))
        return;
      this.txt_tedarikci.Text = KullaniciFrm.ted_name;
      this.pb_ted.Image = _main.byteArrayToImage(KullaniciFrm.ted_logo);
    }

    private bool alan_kontrol()
    {
      bool flag = true;
      if (this.txt_kadi.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_kadi, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      if (this.txt_sifre.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_sifre, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      if (this.txt_adi.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_adi, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      if (this.txt_mail.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_mail, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      if (this.txt_tedarikci.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_tedarikci, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      return flag;
    }

    private DataTable get_tedarikci_info(string s_ted_id)
    {
      DataTable tedarikciInfo = new DataTable();
      if (s_ted_id != "")
        tedarikciInfo = _main.komutcalistir_dt("SELECT * FROM TEDARIKCILER WHERE ID = " + s_ted_id);
      return tedarikciInfo;
    }

    private bool check_username(string username)
    {
      if (_main.komutcalistir_dt("SELECT ID FROM KULLANICILAR WHERE KULLANICIADI = '" + username + "'").Rows.Count <= 0)
        return false;
      int num = (int) MessageBox.Show("Aynı isimli bir kullanıcı var.");
      return true;
    }

    private bool check_username(string username, string id)
    {
      if (_main.komutcalistir_dt("SELECT ID FROM KULLANICILAR WHERE KULLANICIADI = '" + username + "' AND ID NOT IN ('" + id + "')").Rows.Count <= 0)
        return false;
      int num = (int) MessageBox.Show("Aynı isimli bir kullanıcı var.");
      return true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.btn_kaydet = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.txt_kadi = new TextBox();
      this.txt_sifre = new TextBox();
      this.txt_adi = new TextBox();
      this.txt_soyadi = new TextBox();
      this.txt_unvan = new TextBox();
      this.txt_mail = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.label8 = new Label();
      this.pb_kull = new PictureBox();
      this.btn_resim_ekle = new SimpleButton();
      this.btn_resim_sil = new SimpleButton();
      this.ofd = new OpenFileDialog();
      this.txt_gsm = new MaskedTextBox();
      this.txt_tedarikci = new ButtonEdit();
      this.pb_ted = new PictureBox();
      this.label10 = new Label();
      this.ep1 = new ErrorProvider(this.components);
      this.groupBox1 = new GroupBox();
      ((ISupportInitialize) this.pb_kull).BeginInit();
      this.txt_tedarikci.Properties.BeginInit();
      ((ISupportInitialize) this.pb_ted).BeginInit();
      ((ISupportInitialize) this.ep1).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(24, 457);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 0;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(118, 457);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 1;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.txt_kadi.CharacterCasing = CharacterCasing.Upper;
      this.txt_kadi.Location = new Point(98, 32);
      this.txt_kadi.Name = "txt_kadi";
      this.txt_kadi.Size = new Size(191, 21);
      this.txt_kadi.TabIndex = 2;
      this.txt_sifre.CharacterCasing = CharacterCasing.Upper;
      this.txt_sifre.Location = new Point(98, 73);
      this.txt_sifre.Name = "txt_sifre";
      this.txt_sifre.Size = new Size(191, 21);
      this.txt_sifre.TabIndex = 3;
      this.txt_sifre.UseSystemPasswordChar = true;
      this.txt_adi.CharacterCasing = CharacterCasing.Upper;
      this.txt_adi.Location = new Point(98, 114);
      this.txt_adi.Name = "txt_adi";
      this.txt_adi.Size = new Size(191, 21);
      this.txt_adi.TabIndex = 4;
      this.txt_soyadi.CharacterCasing = CharacterCasing.Upper;
      this.txt_soyadi.Location = new Point(98, 155);
      this.txt_soyadi.Name = "txt_soyadi";
      this.txt_soyadi.Size = new Size(191, 21);
      this.txt_soyadi.TabIndex = 5;
      this.txt_unvan.CharacterCasing = CharacterCasing.Upper;
      this.txt_unvan.Location = new Point(98, 196);
      this.txt_unvan.Name = "txt_unvan";
      this.txt_unvan.Size = new Size(191, 21);
      this.txt_unvan.TabIndex = 6;
      this.txt_mail.CharacterCasing = CharacterCasing.Lower;
      this.txt_mail.Location = new Point(98, 237);
      this.txt_mail.Name = "txt_mail";
      this.txt_mail.Size = new Size(191, 21);
      this.txt_mail.TabIndex = 7;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(22, 35);
      this.label1.Name = "label1";
      this.label1.Size = new Size(69, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "Kullanıcı Adı :";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(22, 76);
      this.label2.Name = "label2";
      this.label2.Size = new Size(36, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Şifre :";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(22, 117);
      this.label3.Name = "label3";
      this.label3.Size = new Size(29, 13);
      this.label3.TabIndex = 12;
      this.label3.Text = "Adı :";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(22, 158);
      this.label4.Name = "label4";
      this.label4.Size = new Size(46, 13);
      this.label4.TabIndex = 13;
      this.label4.Text = "Soyadı :";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(22, 199);
      this.label5.Name = "label5";
      this.label5.Size = new Size(45, 13);
      this.label5.TabIndex = 14;
      this.label5.Text = "Ünvan :";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(22, 239);
      this.label6.Name = "label6";
      this.label6.Size = new Size(51, 13);
      this.label6.TabIndex = 15;
      this.label6.Text = "E-posta :";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(22, 329);
      this.label7.Name = "label7";
      this.label7.Size = new Size(34, 13);
      this.label7.TabIndex = 16;
      this.label7.Text = "Gsm :";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(22, 288);
      this.label8.Name = "label8";
      this.label8.Size = new Size(56, 13);
      this.label8.TabIndex = 17;
      this.label8.Text = "Tedarikçi :";
      this.pb_kull.BorderStyle = BorderStyle.FixedSingle;
      this.pb_kull.Location = new Point(313, 32);
      this.pb_kull.Name = "pb_kull";
      this.pb_kull.Size = new Size(167, 190);
      this.pb_kull.SizeMode = PictureBoxSizeMode.Zoom;
      this.pb_kull.TabIndex = 21;
      this.pb_kull.TabStop = false;
      this.btn_resim_ekle.Location = new Point(313, 234);
      this.btn_resim_ekle.Name = "btn_resim_ekle";
      this.btn_resim_ekle.Size = new Size(80, 23);
      this.btn_resim_ekle.TabIndex = 22;
      this.btn_resim_ekle.Text = "Fotoğraf Ekle";
      this.btn_resim_ekle.Click += new EventHandler(this.btn_resim_ekle_Click);
      this.btn_resim_sil.Location = new Point(400, 234);
      this.btn_resim_sil.Name = "btn_resim_sil";
      this.btn_resim_sil.Size = new Size(80, 23);
      this.btn_resim_sil.TabIndex = 23;
      this.btn_resim_sil.Text = "Temizle";
      this.btn_resim_sil.Click += new EventHandler(this.btn_resim_sil_Click);
      this.txt_gsm.Location = new Point(98, 326);
      this.txt_gsm.Mask = "(0000) 000 00 00";
      this.txt_gsm.Name = "txt_gsm";
      this.txt_gsm.Size = new Size(115, 21);
      this.txt_gsm.TabIndex = 24;
      this.txt_tedarikci.Location = new Point(98, 285);
      this.txt_tedarikci.Name = "txt_tedarikci";
      this.txt_tedarikci.Properties.AllowFocused = false;
      this.txt_tedarikci.Properties.AllowHtmlDraw = DefaultBoolean.False;
      this.txt_tedarikci.Properties.AllowMouseWheel = false;
      this.txt_tedarikci.Properties.AllowNullInput = DefaultBoolean.False;
      this.txt_tedarikci.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.txt_tedarikci.Properties.ButtonsStyle = BorderStyles.Style3D;
      this.txt_tedarikci.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
      this.txt_tedarikci.Properties.ReadOnly = true;
      this.txt_tedarikci.Size = new Size(191, 20);
      this.txt_tedarikci.TabIndex = 25;
      this.txt_tedarikci.TabStop = false;
      this.txt_tedarikci.ButtonClick += new ButtonPressedEventHandler(this.txt_tedarikci_ButtonClick);
      this.pb_ted.BorderStyle = BorderStyle.FixedSingle;
      this.pb_ted.Location = new Point(313, 288);
      this.pb_ted.Name = "pb_ted";
      this.pb_ted.Size = new Size(167, 86);
      this.pb_ted.SizeMode = PictureBoxSizeMode.Zoom;
      this.pb_ted.TabIndex = 26;
      this.pb_ted.TabStop = false;
      this.label10.AutoSize = true;
      this.label10.Location = new Point(310, 274);
      this.label10.Name = "label10";
      this.label10.Size = new Size(75, 13);
      this.label10.TabIndex = 27;
      this.label10.Text = "Tedarikçi Logo";
      this.ep1.ContainerControl = (ContainerControl) this;
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.label10);
      this.groupBox1.Controls.Add((Control) this.txt_tedarikci);
      this.groupBox1.Controls.Add((Control) this.pb_ted);
      this.groupBox1.Controls.Add((Control) this.txt_kadi);
      this.groupBox1.Controls.Add((Control) this.txt_gsm);
      this.groupBox1.Controls.Add((Control) this.txt_sifre);
      this.groupBox1.Controls.Add((Control) this.btn_resim_sil);
      this.groupBox1.Controls.Add((Control) this.txt_adi);
      this.groupBox1.Controls.Add((Control) this.btn_resim_ekle);
      this.groupBox1.Controls.Add((Control) this.txt_soyadi);
      this.groupBox1.Controls.Add((Control) this.pb_kull);
      this.groupBox1.Controls.Add((Control) this.txt_unvan);
      this.groupBox1.Controls.Add((Control) this.txt_mail);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label8);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label7);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Location = new Point(24, 24);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(509, 400);
      this.groupBox1.TabIndex = 28;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Kullanıcı Tanımları";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(561, 502);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.btn_kaydet);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (KullaniciFrm);
      this.Text = "Kullanıcı";
      this.Activated += new EventHandler(this.KullaniciFrm_Activated);
      this.Load += new EventHandler(this.KullaniciFrm_Load);
      ((ISupportInitialize) this.pb_kull).EndInit();
      this.txt_tedarikci.Properties.EndInit();
      ((ISupportInitialize) this.pb_ted).EndInit();
      ((ISupportInitialize) this.ep1).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
