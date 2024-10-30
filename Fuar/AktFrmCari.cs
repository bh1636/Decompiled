// Decompiled with JetBrains decompiler
// Type: Fuar.AktFrmCari
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class AktFrmCari : XtraForm
  {
    private string t_conn;
    private string t_firmano;
    private string t_donemno = string.Empty;
    private IContainer components;
    private GroupBox groupBox1;
    private SimpleButton btn_kapat;
    private SimpleButton btn_aktar;
    private MarqueeProgressBarControl pb1;
    private BackgroundWorker bw;

    public AktFrmCari() => this.InitializeComponent();

    private void btn_kapat_Click(object sender, EventArgs e) => this.Close();

    private void btn_aktar_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Aktarıma başlanacaktır. Onaylıyormusunuz?", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      try
      {
        if (!this.ayaroku_degiskene())
          return;
        this.btn_kapat.Enabled = false;
        this.btn_aktar.Enabled = false;
        this.pb1.Properties.Stopped = false;
        this.bw.RunWorkerAsync();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void AktFrmCari_Load(object sender, EventArgs e) => this.pb1.Properties.Stopped = true;

    private void bw_DoWork(object sender, DoWorkEventArgs e) => this.aktar_cari();

    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.pb1.Properties.Stopped = true;
      this.btn_kapat.Enabled = true;
      this.btn_aktar.Enabled = true;
      int num = (int) MessageBox.Show("Aktarım tamamlandı");
    }

    private void aktar_cari()
    {
      string cmdText = "INSERT INTO FUARDB.dbo.MUSTERILER (FIRMAKODU, FIRMAADI, IL, ILCE, TELEFON1, TELEFON2, YETKILI, SATISELEMANI) " + "SELECT CODE, DEFINITION_, CITY, TOWN, TELNRS1, TELNRS2, INCHARGE, SPECODE FROM LG_" + this.t_firmano + "_CLCARD " + "WHERE (CODE NOT IN (SELECT FIRMAKODU FROM FUARDB.dbo.MUSTERILER)) AND ACTIVE = 0 AND CARDTYPE <> 22 AND SPECODE5 = 'FUAR'";
      SqlConnection connection = new SqlConnection(this.t_conn);
      SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
      connection.Open();
      sqlCommand.ExecuteNonQuery();
      connection.Close();
    }

    private bool ayaroku_degiskene()
    {
      try
      {
        if (new FileInfo("transfer.ini").Exists)
        {
          StreamReader streamReader = new StreamReader("transfer.ini");
          string end = streamReader.ReadToEnd();
          streamReader.Close();
          streamReader.Dispose();
          string[] strArray1 = new string[end.Replace("\r", "").Split('\n').Length];
          string[] strArray2 = end.Replace("\r", "").Split('\n');
          string str1 = strArray2[1];
          string str2 = _main.Decrypt(strArray2[2], "951623");
          string str3 = strArray2[3];
          string str4 = strArray2[4];
          this.t_firmano = strArray2[5];
          this.t_donemno = strArray2[6];
          this.t_conn = "Data Source=" + str3 + ";Initial Catalog=" + str4 + ";User Id=" + str1 + ";Password=" + str2;
          return true;
        }
        int num = (int) MessageBox.Show("Aktarım ayarları yapılmamış.Ayarlar menüsünden aktarım ayarlarınızı yapıp kaydedin.");
        return false;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        return false;
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
      this.groupBox1 = new GroupBox();
      this.pb1 = new MarqueeProgressBarControl();
      this.btn_kapat = new SimpleButton();
      this.btn_aktar = new SimpleButton();
      this.bw = new BackgroundWorker();
      this.groupBox1.SuspendLayout();
      this.pb1.Properties.BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.pb1);
      this.groupBox1.Controls.Add((Control) this.btn_kapat);
      this.groupBox1.Controls.Add((Control) this.btn_aktar);
      this.groupBox1.Location = new Point(12, 14);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(487, 109);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Müşteriler Aktarımı";
      this.pb1.EditValue = (object) 0;
      this.pb1.Location = new Point(23, 24);
      this.pb1.Name = "pb1";
      this.pb1.Size = new Size(440, 24);
      this.pb1.TabIndex = 4;
      this.btn_kapat.Location = new Point((int) byte.MaxValue, 68);
      this.btn_kapat.Name = "btn_kapat";
      this.btn_kapat.Size = new Size(107, 23);
      this.btn_kapat.TabIndex = 2;
      this.btn_kapat.Text = "Kapat";
      this.btn_kapat.Click += new EventHandler(this.btn_kapat_Click);
      this.btn_aktar.Location = new Point(124, 68);
      this.btn_aktar.Name = "btn_aktar";
      this.btn_aktar.Size = new Size(107, 23);
      this.btn_aktar.TabIndex = 1;
      this.btn_aktar.Text = "Aktarımı Başlat";
      this.btn_aktar.Click += new EventHandler(this.btn_aktar_Click);
      this.bw.DoWork += new DoWorkEventHandler(this.bw_DoWork);
      this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(511, 136);
      this.Controls.Add((Control) this.groupBox1);
      this.MinimizeBox = false;
      this.Name = nameof (AktFrmCari);
      this.Text = "Müşteriler Aktarımı";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.AktFrmCari_Load);
      this.groupBox1.ResumeLayout(false);
      this.pb1.Properties.EndInit();
      this.ResumeLayout(false);
    }
  }
}
