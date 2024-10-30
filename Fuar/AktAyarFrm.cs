// Decompiled with JetBrains decompiler
// Type: Fuar.AktAyarFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class AktAyarFrm : XtraForm
  {
    private IContainer components;
    private GroupBox groupBox1;
    private MaskedTextBox txt_firmano;
    private Label label5;
    private TextBox txt_veritabani;
    private TextBox txt_sunucu;
    private TextBox txt_sifre;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private TextBox txt_kadi;
    private SimpleButton btn_kaydet;
    private SimpleButton btn_iptal;
    private SimpleButton btn_test;
    private MaskedTextBox txt_donemno;
    private Label label6;
    private ErrorProvider ep;

    public AktAyarFrm() => this.InitializeComponent();

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void AktAyarFrm_Load(object sender, EventArgs e) => this.ayaroku();

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (!this.alan_kontrol() || !this.test_conn(this.txt_kadi.Text, this.txt_sifre.Text, this.txt_sunucu.Text, this.txt_veritabani.Text, this.txt_firmano.Text, this.txt_donemno.Text))
        return;
      this.ayaryaz(this.txt_kadi.Text, this.txt_sifre.Text, this.txt_sunucu.Text, this.txt_veritabani.Text, this.txt_firmano.Text, this.txt_donemno.Text);
      this.Close();
    }

    private void btn_test_Click(object sender, EventArgs e)
    {
      if (!this.alan_kontrol())
        return;
      this.test_conn(this.txt_kadi.Text, this.txt_sifre.Text, this.txt_sunucu.Text, this.txt_veritabani.Text, this.txt_firmano.Text, this.txt_donemno.Text);
    }

    private void ayaroku()
    {
      try
      {
        if (!new FileInfo("transfer.ini").Exists)
          return;
        StreamReader streamReader = new StreamReader("transfer.ini");
        string end = streamReader.ReadToEnd();
        streamReader.Close();
        streamReader.Dispose();
        string[] strArray1 = new string[end.Replace("\r", "").Split('\n').Length];
        string[] strArray2 = end.Replace("\r", "").Split('\n');
        this.txt_kadi.Text = strArray2[1];
        this.txt_sifre.Text = _main.Decrypt(strArray2[2], "951623");
        this.txt_sunucu.Text = strArray2[3];
        this.txt_veritabani.Text = strArray2[4];
        this.txt_firmano.Text = strArray2[5];
        this.txt_donemno.Text = strArray2[6];
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void ayaryaz(
      string kadi,
      string sifre,
      string sunucu,
      string database,
      string firmano,
      string donemno)
    {
      try
      {
        if (File.Exists("transfer.ini"))
          File.Delete("transfer.ini");
        StreamWriter streamWriter = new StreamWriter("transfer.ini");
        streamWriter.WriteLine("[AYARLAR]");
        streamWriter.WriteLine(kadi);
        streamWriter.WriteLine(_main.Encrypt(sifre, "951623"));
        streamWriter.WriteLine(sunucu);
        streamWriter.WriteLine(database);
        streamWriter.WriteLine(firmano);
        streamWriter.WriteLine(donemno);
        streamWriter.Close();
        streamWriter.Dispose();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private bool test_conn(
      string kadi,
      string sifre,
      string sunucu,
      string database,
      string firmano,
      string donemno)
    {
      try
      {
        string connectionString1 = "Provider=sqloledb;data source=" + sunucu + ";uid=" + kadi + ";password=" + sifre + ";database=master";
        string selectCommandText1 = "SELECT Name FROM sysdatabases WHERE name = '" + database + "'";
        DataTable dataTable1 = new DataTable();
        OleDbConnection selectConnection1 = new OleDbConnection(connectionString1);
        new OleDbDataAdapter(selectCommandText1, selectConnection1).Fill(dataTable1);
        selectConnection1.Close();
        if (dataTable1.Rows.Count > 0)
        {
          string connectionString2 = "data source=" + sunucu + ";uid=" + kadi + ";password=" + sifre + ";database=" + database;
          string selectCommandText2 = "SELECT * FROM L_CAPIPERIOD WHERE FIRMNR = '" + firmano + "' AND NR = '" + donemno + "'";
          SqlConnection selectConnection2 = new SqlConnection(connectionString2);
          SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText2, selectConnection2);
          DataTable dataTable2 = new DataTable();
          sqlDataAdapter.Fill(dataTable2);
          selectConnection2.Close();
          if (dataTable2.Rows.Count > 0)
          {
            int num = (int) MessageBox.Show("Test başarılı.");
            return true;
          }
          int num1 = (int) MessageBox.Show("FirmaNo veya DönemNo bulunamadı.");
          return false;
        }
        int num2 = (int) MessageBox.Show("Veritabanı bulunamadı.");
        return false;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        return false;
      }
    }

    private bool alan_kontrol()
    {
      bool flag = true;
      if (this.txt_kadi.Text.Length == 0)
      {
        flag = false;
        this.ep.SetError((Control) this.txt_kadi, "Alan boş olamaz");
      }
      else
        this.ep.SetError((Control) this.txt_kadi, "");
      if (this.txt_sunucu.Text.Length == 0)
      {
        flag = false;
        this.ep.SetError((Control) this.txt_sunucu, "Alan boş olamaz");
      }
      else
        this.ep.SetError((Control) this.txt_sunucu, "");
      if (this.txt_veritabani.Text.Length == 0)
      {
        flag = false;
        this.ep.SetError((Control) this.txt_veritabani, "Alan boş olamaz");
      }
      else
        this.ep.SetError((Control) this.txt_veritabani, "");
      if (!this.txt_firmano.MaskFull)
      {
        flag = false;
        this.ep.SetError((Control) this.txt_firmano, "Alan boş olamaz");
      }
      else
        this.ep.SetError((Control) this.txt_firmano, "");
      if (!this.txt_donemno.MaskCompleted)
      {
        flag = false;
        this.ep.SetError((Control) this.txt_donemno, "Alan boş olamaz");
      }
      else
        this.ep.SetError((Control) this.txt_donemno, "");
      return flag;
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
      this.groupBox1 = new GroupBox();
      this.txt_firmano = new MaskedTextBox();
      this.label5 = new Label();
      this.txt_veritabani = new TextBox();
      this.txt_sunucu = new TextBox();
      this.txt_sifre = new TextBox();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.txt_kadi = new TextBox();
      this.btn_kaydet = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.btn_test = new SimpleButton();
      this.txt_donemno = new MaskedTextBox();
      this.label6 = new Label();
      this.ep = new ErrorProvider(this.components);
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.ep).BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.txt_donemno);
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.txt_firmano);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.txt_veritabani);
      this.groupBox1.Controls.Add((Control) this.txt_sunucu);
      this.groupBox1.Controls.Add((Control) this.txt_sifre);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.txt_kadi);
      this.groupBox1.Font = new Font("Tahoma", 8.25f);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(425, 243);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Logo Database Bağlantı Ayarları";
      this.txt_firmano.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
      this.txt_firmano.Font = new Font("Tahoma", 8.25f);
      this.txt_firmano.Location = new Point(134, 167);
      this.txt_firmano.Mask = "000";
      this.txt_firmano.Name = "txt_firmano";
      this.txt_firmano.Size = new Size(100, 21);
      this.txt_firmano.TabIndex = 4;
      this.txt_firmano.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Tahoma", 8.25f);
      this.label5.Location = new Point(22, 169);
      this.label5.Name = "label5";
      this.label5.Size = new Size(82, 13);
      this.label5.TabIndex = 11;
      this.label5.Text = "Logo Firma No :";
      this.txt_veritabani.Font = new Font("Tahoma", 8.25f);
      this.txt_veritabani.Location = new Point(134, 131);
      this.txt_veritabani.Name = "txt_veritabani";
      this.txt_veritabani.Size = new Size(275, 21);
      this.txt_veritabani.TabIndex = 3;
      this.txt_sunucu.Font = new Font("Tahoma", 8.25f);
      this.txt_sunucu.Location = new Point(134, 96);
      this.txt_sunucu.Name = "txt_sunucu";
      this.txt_sunucu.Size = new Size(275, 21);
      this.txt_sunucu.TabIndex = 2;
      this.txt_sifre.Font = new Font("Tahoma", 8.25f);
      this.txt_sifre.Location = new Point(134, 61);
      this.txt_sifre.Name = "txt_sifre";
      this.txt_sifre.Size = new Size(275, 21);
      this.txt_sifre.TabIndex = 1;
      this.txt_sifre.UseSystemPasswordChar = true;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Tahoma", 8.25f);
      this.label4.Location = new Point(22, 134);
      this.label4.Name = "label4";
      this.label4.Size = new Size(62, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Veritabanı :";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Tahoma", 8.25f);
      this.label3.Location = new Point(22, 99);
      this.label3.Name = "label3";
      this.label3.Size = new Size(49, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Sunucu :";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Tahoma", 8.25f);
      this.label2.Location = new Point(22, 64);
      this.label2.Name = "label2";
      this.label2.Size = new Size(36, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Şifre :";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Tahoma", 8.25f);
      this.label1.Location = new Point(22, 29);
      this.label1.Name = "label1";
      this.label1.Size = new Size(69, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Kullanıcı Adı :";
      this.txt_kadi.Font = new Font("Tahoma", 8.25f);
      this.txt_kadi.Location = new Point(134, 26);
      this.txt_kadi.Name = "txt_kadi";
      this.txt_kadi.Size = new Size(275, 21);
      this.txt_kadi.TabIndex = 0;
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(12, 275);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 6;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(110, 275);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 7;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.btn_test.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_test.Location = new Point(250, 275);
      this.btn_test.Name = "btn_test";
      this.btn_test.Size = new Size(122, 33);
      this.btn_test.TabIndex = 8;
      this.btn_test.Text = "Bağlantıyı Test Et";
      this.btn_test.Click += new EventHandler(this.btn_test_Click);
      this.txt_donemno.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
      this.txt_donemno.Font = new Font("Tahoma", 8.25f);
      this.txt_donemno.Location = new Point(134, 204);
      this.txt_donemno.Mask = "00";
      this.txt_donemno.Name = "txt_donemno";
      this.txt_donemno.Size = new Size(100, 21);
      this.txt_donemno.TabIndex = 5;
      this.txt_donemno.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Tahoma", 8.25f);
      this.label6.Location = new Point(22, 206);
      this.label6.Name = "label6";
      this.label6.Size = new Size(89, 13);
      this.label6.TabIndex = 13;
      this.label6.Text = "Logo Dönem No :";
      this.ep.ContainerControl = (ContainerControl) this;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(450, 327);
      this.Controls.Add((Control) this.btn_test);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Controls.Add((Control) this.groupBox1);
      this.MinimizeBox = false;
      this.Name = nameof (AktAyarFrm);
      this.Text = "Aktarım Ayarları";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.AktAyarFrm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.ep).EndInit();
      this.ResumeLayout(false);
    }
  }
}
