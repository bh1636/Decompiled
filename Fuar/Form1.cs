// Decompiled with JetBrains decompiler
// Type: Fuar.Form1
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Fuar.Properties;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class Form1 : XtraForm
  {
    private SplashScreen1 ss;
    private IContainer components;
    private CheckBox chk_hatirla;
    private SimpleButton btn_baglan;
    private SimpleButton btn_vazgec;
    private TextBox txt_kadi;
    private TextBox txt_sifre;
    private Label label1;
    private Label label2;
    private LinkLabel lnk_resetpass;
    private GroupBox groupBox1;
    public System.Windows.Forms.Timer tt;

    public Form1() => this.InitializeComponent();

    private void btn_baglan_Click(object sender, EventArgs e)
    {
      this.get_user_info(this.txt_kadi.Text, this.txt_sifre.Text);
      if (_main.dt_user.Rows.Count > 0)
      {
        this.reg_write(this.chk_hatirla.Checked);
        this.Hide();
        new MainMenu().Show();
      }
      else
      {
        int num = (int) MessageBox.Show("Kullanıcı Adı veya Şifre geçersiz...");
      }
    }

    private void btn_vazgec_Click(object sender, EventArgs e) => this.Close();

    private void Form1_Load(object sender, EventArgs e)
    {
      try
      {
        if (!System.IO.File.Exists("ayarlar.ini"))
          return;
        this.ayaroku_degiskene();
        this.mainuser_kontrol();
        this.reg_read();
        this.Hide();
        this.ss = new SplashScreen1();
        this.ss.Properties.UseFadeOutEffect = false;
        this.tt.Start();
        int num = (int) this.ss.ShowDialog();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void tt_Tick(object sender, EventArgs e)
    {
      if (this.ss.IsDisposed)
      {
        this.tt.Stop();
        this.tt.Dispose();
      }
      else
        this.ss.Close();
    }

    private void ayaroku_degiskene()
    {
      try
      {
        if (System.IO.File.Exists("ayarlar.ini"))
        {
          StreamReader streamReader = new StreamReader("ayarlar.ini");
          string end = streamReader.ReadToEnd();
          streamReader.Close();
          streamReader.Dispose();
          string[] strArray1 = new string[end.Replace("\r", "").Split('\n').Length];
          string[] strArray2 = end.Replace("\r", "").Split('\n');
          _main.s_kadi = strArray2[1];
          _main.s_sifre = _main.Decrypt(strArray2[2], "951623");
          _main.s_sunucu = strArray2[3];
          _main.s_db = strArray2[4];
          _main.str_connection = "Data Source=" + _main.s_sunucu + ";Initial Catalog=" + _main.s_db + ";User Id=" + _main.s_kadi + ";Password=" + _main.s_sifre;
        }
        else
        {
          int num = (int) MessageBox.Show("ayarlar.ini dosyası bulunamadı");
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.StackTrace, ex.Message);
      }
    }

    private void mainuser_kontrol()
    {
      try
      {
        string str = _main.komutcalistir_str("IF NOT EXISTS (SELECT ID FROM GRUPLAR WHERE GRUPADI = 'YONETICI') BEGIN INSERT INTO GRUPLAR (GRUPADI) VALUES ('YONETICI') SELECT @@IDENTITY AS GRUPID END ELSE BEGIN SELECT ID AS GRUPID FROM GRUPLAR WHERE GRUPADI = 'YONETICI' END");
        if (_main.komutcalistir_int("SELECT COUNT(*) FROM KULLANICILAR WHERE KULLANICIADI = 'ADMIN'") > 0)
          return;
        string cmdText = "INSERT INTO KULLANICILAR (KULLANICIADI,SIFRE,ADI,EPOSTA,GRUPID,RESIM) " + "VALUES ('ADMIN','zW4K9/nRJ1ZLHEKwCD9neg==','SUPERUSER','software@dmsbilgisayar.com','" + str + "',@RESIM)";
        byte[] byteArray = _main.imageToByteArray((Image) Resources.no_photo);
        SqlConnection connection = new SqlConnection(_main.str_connection);
        SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
        sqlCommand.Parameters.AddWithValue("@RESIM", (object) byteArray);
        connection.Open();
        sqlCommand.ExecuteNonQuery();
        connection.Close();
      }
      catch
      {
      }
    }

    private void reg_read()
    {
      Registry.CurrentUser.CreateSubKey("DmsFuar\\UserInfo");
      RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("DmsFuar\\UserInfo", true);
      if (registryKey.GetValue("UserName") != null)
      {
        this.txt_kadi.Text = registryKey.GetValue("UserName").ToString();
        this.chk_hatirla.Checked = true;
        if (registryKey.GetValue("UserPass") != null)
          this.txt_sifre.Text = _main.Decrypt(registryKey.GetValue("UserPass").ToString(), "951623");
      }
      registryKey.Flush();
      registryKey.Dispose();
    }

    private void reg_write(bool hatirla)
    {
      RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("DmsFuar\\UserInfo", true);
      if (hatirla)
      {
        registryKey.SetValue("UserName", (object) this.txt_kadi.Text);
        registryKey.SetValue("UserPass", (object) _main.Encrypt(this.txt_sifre.Text, "951623"));
      }
      else
      {
        registryKey.DeleteValue("UserName", false);
        registryKey.DeleteValue("UserPass", false);
      }
      registryKey.Flush();
      registryKey.Dispose();
    }

    private void get_user_info(string username, string password)
    {
      string str = _main.Encrypt(password, "951623");
      _main.dt_user = _main.komutcalistir_dt("SELECT K.*,G.GRUPADI FROM KULLANICILAR AS K LEFT OUTER JOIN GRUPLAR AS G ON K.GRUPID = G.ID WHERE K.KULLANICIADI = '" + username + "' AND K.SIFRE = '" + str + "'");
    }

    private void lnk_resetpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      int num = (int) new ResetPass().ShowDialog();
    }

    private bool isRealDomain(string inputEmail)
    {
      bool flag = false;
      try
      {
        IPEndPoint remoteEP = new IPEndPoint(Dns.GetHostEntry(inputEmail.Split('@')[1]).AddressList[0], 25);
        Socket socket = new Socket(remoteEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect((EndPoint) remoteEP);
        socket.Close();
        flag = true;
      }
      catch (Exception ex)
      {
      }
      return flag;
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.btn_baglan_Click(sender, (EventArgs) e);
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
      SplashScreenManager splashScreenManager = new SplashScreenManager((Form) this, typeof (SplashScreen1), true, true);
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.chk_hatirla = new CheckBox();
      this.btn_baglan = new SimpleButton();
      this.btn_vazgec = new SimpleButton();
      this.txt_kadi = new TextBox();
      this.txt_sifre = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.lnk_resetpass = new LinkLabel();
      this.groupBox1 = new GroupBox();
      this.tt = new System.Windows.Forms.Timer(this.components);
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.chk_hatirla.AutoSize = true;
      this.chk_hatirla.Location = new Point(97, 74);
      this.chk_hatirla.Name = "chk_hatirla";
      this.chk_hatirla.Size = new Size(80, 17);
      this.chk_hatirla.TabIndex = 3;
      this.chk_hatirla.Text = "Beni Hatırla";
      this.chk_hatirla.UseVisualStyleBackColor = true;
      this.btn_baglan.Location = new Point(48, 129);
      this.btn_baglan.Name = "btn_baglan";
      this.btn_baglan.Size = new Size(87, 33);
      this.btn_baglan.TabIndex = 4;
      this.btn_baglan.Text = "Bağlan";
      this.btn_baglan.Click += new EventHandler(this.btn_baglan_Click);
      this.btn_vazgec.Location = new Point(167, 129);
      this.btn_vazgec.Name = "btn_vazgec";
      this.btn_vazgec.Size = new Size(87, 33);
      this.btn_vazgec.TabIndex = 5;
      this.btn_vazgec.Text = "Vazgeç";
      this.btn_vazgec.Click += new EventHandler(this.btn_vazgec_Click);
      this.txt_kadi.CharacterCasing = CharacterCasing.Upper;
      this.txt_kadi.Font = new Font("Courier New", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.txt_kadi.Location = new Point(97, 19);
      this.txt_kadi.Name = "txt_kadi";
      this.txt_kadi.Size = new Size(149, 22);
      this.txt_kadi.TabIndex = 1;
      this.txt_sifre.CharacterCasing = CharacterCasing.Upper;
      this.txt_sifre.Font = new Font("Courier New", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.txt_sifre.Location = new Point(97, 45);
      this.txt_sifre.Name = "txt_sifre";
      this.txt_sifre.Size = new Size(149, 22);
      this.txt_sifre.TabIndex = 2;
      this.txt_sifre.UseSystemPasswordChar = true;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(18, 27);
      this.label1.Name = "label1";
      this.label1.Size = new Size(72, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "Kullanıcı Adı : ";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(18, 48);
      this.label2.Name = "label2";
      this.label2.Size = new Size(29, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Şifre";
      this.lnk_resetpass.AutoSize = true;
      this.lnk_resetpass.Location = new Point(106, 171);
      this.lnk_resetpass.Name = "lnk_resetpass";
      this.lnk_resetpass.Size = new Size(83, 13);
      this.lnk_resetpass.TabIndex = 6;
      this.lnk_resetpass.TabStop = true;
      this.lnk_resetpass.Text = "Şifremi Unuttum";
      this.lnk_resetpass.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lnk_resetpass_LinkClicked);
      this.groupBox1.Controls.Add((Control) this.txt_kadi);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.chk_hatirla);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.txt_sifre);
      this.groupBox1.Location = new Point(17, 17);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(268, 98);
      this.groupBox1.TabIndex = 8;
      this.groupBox1.TabStop = false;
      this.tt.Enabled = true;
      this.tt.Interval = 1500;
      this.tt.Tick += new EventHandler(this.tt_Tick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(302, 204);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.lnk_resetpass);
      this.Controls.Add((Control) this.btn_vazgec);
      this.Controls.Add((Control) this.btn_baglan);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (Form1);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Load += new EventHandler(this.Form1_Load);
      this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
