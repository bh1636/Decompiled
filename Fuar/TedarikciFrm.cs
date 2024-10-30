// Decompiled with JetBrains decompiler
// Type: Fuar.TedarikciFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
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
  public class TedarikciFrm : XtraForm
  {
    public string ted_id = string.Empty;
    private IContainer components;
    private SimpleButton btn_kaydet;
    private SimpleButton btn_iptal;
    private SimpleButton btn_sec;
    private SimpleButton btn_temizle;
    private Label label1;
    private Label label2;
    private PictureBox pb_ted;
    private TextBox txt_tedkodu;
    private TextBox txt_tedadi;
    private GroupBox groupBox1;
    private OpenFileDialog ofd2;

    public TedarikciFrm() => this.InitializeComponent();

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void TedarikciFrm_Load(object sender, EventArgs e)
    {
      if (!(this.ted_id != ""))
        return;
      DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM TEDARIKCILER WHERE ID = " + this.ted_id);
      if (dataTable.Rows.Count <= 0)
        return;
      this.txt_tedkodu.Text = dataTable.Rows[0]["TEDARIKCIKODU"].ToString();
      this.txt_tedadi.Text = dataTable.Rows[0]["TEDARIKCIADI"].ToString();
      if (dataTable.Rows[0]["TEDARIKCILOGOSU"] == DBNull.Value)
        return;
      this.pb_ted.Image = _main.byteArrayToImage((byte[]) dataTable.Rows[0]["TEDARIKCILOGOSU"]);
    }

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (this.ted_id == "")
        this.insert_ted();
      else
        this.update_ted();
      this.Close();
    }

    private void insert_ted()
    {
      byte[] numArray = this.pb_ted.Image != null ? _main.imageToByteArray(this.pb_ted.Image) : _main.imageToByteArray((Image) Resources.no_photo);
      string cmdText = "INSERT INTO TEDARIKCILER (TEDARIKCIKODU,TEDARIKCIADI,TEDARIKCILOGOSU) " + "VALUES ('" + this.txt_tedkodu.Text + "','" + this.txt_tedadi.Text + "',@RESIM)";
      SqlConnection connection = new SqlConnection(_main.str_connection);
      SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
      sqlCommand.Parameters.AddWithValue("@RESIM", (object) numArray);
      connection.Open();
      sqlCommand.ExecuteNonQuery();
      connection.Close();
    }

    private void update_ted()
    {
      byte[] numArray = this.pb_ted.Image != null ? _main.imageToByteArray(this.pb_ted.Image) : _main.imageToByteArray((Image) Resources.no_photo);
      string cmdText = "UPDATE TEDARIKCILER SET TEDARIKCIKODU = '" + this.txt_tedkodu.Text + "',TEDARIKCIADI = '" + this.txt_tedadi.Text + "',TEDARIKCILOGOSU = @RESIM" + " WHERE ID = " + this.ted_id;
      SqlConnection connection = new SqlConnection(_main.str_connection);
      SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
      sqlCommand.Parameters.AddWithValue("@RESIM", (object) numArray);
      connection.Open();
      sqlCommand.ExecuteNonQuery();
      connection.Close();
    }

    private void btn_sec_Click(object sender, EventArgs e)
    {
      this.ofd2.Filter = "Fotoğraf Dosyaları (*.jpg)|*.jpg";
      if (this.ofd2.ShowDialog() != DialogResult.OK)
        return;
      this.pb_ted.Image = Image.FromFile(this.ofd2.FileName);
    }

    private void btn_temizle_Click(object sender, EventArgs e) => this.pb_ted.Image = (Image) null;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btn_kaydet = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.btn_sec = new SimpleButton();
      this.btn_temizle = new SimpleButton();
      this.label1 = new Label();
      this.label2 = new Label();
      this.txt_tedkodu = new TextBox();
      this.txt_tedadi = new TextBox();
      this.pb_ted = new PictureBox();
      this.groupBox1 = new GroupBox();
      this.ofd2 = new OpenFileDialog();
      ((ISupportInitialize) this.pb_ted).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(21, 202);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 0;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(109, 202);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 1;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.btn_sec.Location = new Point(349, 134);
      this.btn_sec.Name = "btn_sec";
      this.btn_sec.Size = new Size(75, 23);
      this.btn_sec.TabIndex = 2;
      this.btn_sec.Text = "Logo Seç";
      this.btn_sec.Click += new EventHandler(this.btn_sec_Click);
      this.btn_temizle.Location = new Point(440, 134);
      this.btn_temizle.Name = "btn_temizle";
      this.btn_temizle.Size = new Size(75, 23);
      this.btn_temizle.TabIndex = 3;
      this.btn_temizle.Text = "Temizle";
      this.btn_temizle.Click += new EventHandler(this.btn_temizle_Click);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(20, 47);
      this.label1.Name = "label1";
      this.label1.Size = new Size(83, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Tedarikçi Kodu :";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(20, 96);
      this.label2.Name = "label2";
      this.label2.Size = new Size(74, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Tedarikçi Adı :";
      this.txt_tedkodu.Location = new Point(111, 44);
      this.txt_tedkodu.Name = "txt_tedkodu";
      this.txt_tedkodu.Size = new Size(196, 21);
      this.txt_tedkodu.TabIndex = 7;
      this.txt_tedadi.Location = new Point(111, 93);
      this.txt_tedadi.Name = "txt_tedadi";
      this.txt_tedadi.Size = new Size(196, 21);
      this.txt_tedadi.TabIndex = 8;
      this.pb_ted.BorderStyle = BorderStyle.FixedSingle;
      this.pb_ted.Location = new Point(349, 16);
      this.pb_ted.Name = "pb_ted";
      this.pb_ted.Size = new Size(166, 112);
      this.pb_ted.SizeMode = PictureBoxSizeMode.Zoom;
      this.pb_ted.TabIndex = 6;
      this.pb_ted.TabStop = false;
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.pb_ted);
      this.groupBox1.Controls.Add((Control) this.btn_temizle);
      this.groupBox1.Controls.Add((Control) this.txt_tedadi);
      this.groupBox1.Controls.Add((Control) this.btn_sec);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.txt_tedkodu);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(540, 167);
      this.groupBox1.TabIndex = 9;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Tedarikçi Tanımları";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(568, 247);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.btn_kaydet);
      this.MinimizeBox = false;
      this.Name = nameof (TedarikciFrm);
      this.Text = "Tedarikçi";
      this.Load += new EventHandler(this.TedarikciFrm_Load);
      ((ISupportInitialize) this.pb_ted).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
