// Decompiled with JetBrains decompiler
// Type: Fuar.AktFrmFiyat
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class AktFrmFiyat : XtraForm
  {
    private string t_conn;
    private string t_firmano;
    private string t_donemno = string.Empty;
    private IContainer components;
    public BackgroundWorker bw;
    private GroupBox groupBox1;
    private SimpleButton btn_kapat;
    private SimpleButton btn_aktar;
    private CheckEdit chk_recstatus;
    private TimeEdit t_time;
    private Timer timer1;
    private ProgressBarControl pb2;

    public AktFrmFiyat() => this.InitializeComponent();

    private void btn_kapat_Click(object sender, EventArgs e) => this.Close();

    private void AktFrmFiyat_Load(object sender, EventArgs e)
    {
      this.t_time.Properties.AllowFocused = false;
    }

    private void bw_DoWork(object sender, DoWorkEventArgs e) => this.aktar_fiyat();

    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.btn_kapat.Enabled = true;
      this.btn_aktar.Enabled = true;
      this.chk_recstatus.Enabled = true;
      this.pb2.EditValue = (object) 100;
      this.timer1.Stop();
      int num = (int) MessageBox.Show("Aktarım tamamlandı");
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

    private void btn_aktar_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Aktarıma başlanacaktır. Onaylıyormusunuz?", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      try
      {
        if (!this.ayaroku_degiskene())
          return;
        this.timer1.Enabled = true;
        this.timer1.Start();
        this.btn_kapat.Enabled = false;
        this.btn_aktar.Enabled = false;
        this.chk_recstatus.Enabled = false;
        this.bw.RunWorkerAsync();
      }
      catch (Exception ex)
      {
        _main.txt_yaz(ex.Message, "fiyat_trf_err.txt");
      }
    }

    public DataTable t_komutcalistir_dt(string str_query)
    {
      DataTable dataTable = new DataTable();
      SqlConnection connection = new SqlConnection(this.t_conn);
      SqlCommand sqlCommand = new SqlCommand(str_query, connection);
      connection.Open();
      SqlDataReader reader = sqlCommand.ExecuteReader();
      dataTable.Load((IDataReader) reader);
      connection.Close();
      return dataTable;
    }

    public void t_komutcalistir(string str_query)
    {
      SqlConnection connection = new SqlConnection(this.t_conn);
      SqlCommand sqlCommand = new SqlCommand(str_query, connection);
      connection.Open();
      sqlCommand.ExecuteNonQuery();
      connection.Close();
    }

    private void aktar_fiyat()
    {
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string str_query = "SELECT CODE FROM LG_" + this.t_firmano + "_ITEMS WHERE ACTIVE = 0 ";
      if (this.chk_recstatus.Checked)
        str_query += "AND RECSTATUS <> 0";
      DataTable dataTable1 = this.t_komutcalistir_dt(str_query);
      for (int index = 0; index < dataTable1.Rows.Count; ++index)
      {
        try
        {
          DataTable dataTable2 = this.t_komutcalistir_dt("SELECT   TOP 1  I.CODE AS KOD, ISNULL(B.BARCODE, '') AS BARCODE, U.NAME AS BIRIM, U.MAINUNIT AS ANABIRIM, I.VAT AS KDVORANI, ISNULL(P.PRICE, 0) AS FIYAT, " + "ISNULL(P.INCVAT, 0) AS KDVDAHIL, CASE ISNULL(P.CURRENCY, 160) " + "WHEN 160 THEN 'TRL' WHEN 1 THEN 'USD' WHEN 20 THEN 'EUR' WHEN 17 THEN 'GBP' END AS PARABIRIMI " + "FROM LG_" + this.t_firmano + "_PRCLIST AS P RIGHT OUTER JOIN " + "LG_" + this.t_firmano + "_ITMUNITA AS IA INNER JOIN " + "LG_" + this.t_firmano + "_UNITSETL AS U ON IA.UNITLINEREF = U.LOGICALREF RIGHT OUTER JOIN " + "LG_" + this.t_firmano + "_ITEMS AS I ON IA.ITEMREF = I.LOGICALREF AND U.UNITSETREF = I.UNITSETREF ON P.UOMREF = IA.UNITLINEREF AND " + "P.CARDREF = I.LOGICALREF LEFT OUTER JOIN " + "LG_" + this.t_firmano + "_UNITBARCODE AS B ON IA.LOGICALREF = B.ITMUNITAREF LEFT OUTER JOIN " + "LG_" + this.t_firmano + "_MARK AS M ON I.MARKREF = M.LOGICALREF " + "WHERE (P.PTYPE = 2 OR P.PTYPE IS NULL) AND (I.ACTIVE = 0) AND (I.CARDTYPE = 1) AND (I.CODE = '" + dataTable1.Rows[index]["CODE"].ToString() + "') " + "AND (P.ACTIVE = 0) " + "ORDER BY P.BEGDATE DESC");
          if (dataTable2.Rows.Count > 0)
            _main.komutcalistir("DECLARE @MLZID AS INT,@BIRIMID AS NVARCHAR(50) " + "IF EXISTS (SELECT ID FROM MALZEMELER WHERE KOD = '" + dataTable2.Rows[0]["KOD"].ToString() + "') BEGIN " + "SELECT @MLZID = ID FROM MALZEMELER WHERE KOD = '" + dataTable2.Rows[0]["KOD"].ToString() + "' " + "SELECT @BIRIMID = ID FROM BIRIMLER WHERE BIRIM = '" + dataTable2.Rows[0]["BIRIM"].ToString() + "' " + "UPDATE MALZEMEDETAY SET SATISFIYATI = " + dataTable2.Rows[0]["FIYAT"].ToString().Replace(",", ".") + ",PARABIRIMI = '" + dataTable2.Rows[0]["PARABIRIMI"].ToString() + "', " + "KDVORANI = " + dataTable2.Rows[0]["KDVORANI"].ToString() + ", KDVDAHIL = " + dataTable2.Rows[0]["KDVDAHIL"].ToString() + " WHERE MALZEMEID = @MLZID AND BIRIMID = @BIRIMID END");
          string str = "UPDATE LG_001_ITEMS SET RECSTATUS = 0 WHERE CODE = '" + dataTable1.Rows[index]["CODE"].ToString() + "'";
          this.bw.ReportProgress(index * 100 / dataTable1.Rows.Count);
        }
        catch (Exception ex)
        {
          _main.txt_yaz(ex.Message, "fiyat_trf_det_err.txt");
        }
      }
    }

    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      this.pb2.EditValue = (object) e.ProgressPercentage;
      this.pb2.Text = e.ProgressPercentage.ToString();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.t_time.Time = this.t_time.Time.AddSeconds(1.0);
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
      this.bw = new BackgroundWorker();
      this.groupBox1 = new GroupBox();
      this.btn_kapat = new SimpleButton();
      this.btn_aktar = new SimpleButton();
      this.chk_recstatus = new CheckEdit();
      this.t_time = new TimeEdit();
      this.timer1 = new Timer(this.components);
      this.pb2 = new ProgressBarControl();
      this.groupBox1.SuspendLayout();
      this.chk_recstatus.Properties.BeginInit();
      this.t_time.Properties.BeginInit();
      this.pb2.Properties.BeginInit();
      this.SuspendLayout();
      this.bw.WorkerReportsProgress = true;
      this.bw.DoWork += new DoWorkEventHandler(this.bw_DoWork);
      this.bw.ProgressChanged += new ProgressChangedEventHandler(this.bw_ProgressChanged);
      this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
      this.groupBox1.Controls.Add((Control) this.pb2);
      this.groupBox1.Controls.Add((Control) this.t_time);
      this.groupBox1.Controls.Add((Control) this.chk_recstatus);
      this.groupBox1.Controls.Add((Control) this.btn_kapat);
      this.groupBox1.Controls.Add((Control) this.btn_aktar);
      this.groupBox1.Location = new Point(12, 14);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(487, 112);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Malzeme Fiyatları Aktarımı";
      this.btn_kapat.Location = new Point((int) byte.MaxValue, 79);
      this.btn_kapat.Name = "btn_kapat";
      this.btn_kapat.Size = new Size(107, 23);
      this.btn_kapat.TabIndex = 2;
      this.btn_kapat.Text = "Kapat";
      this.btn_kapat.Click += new EventHandler(this.btn_kapat_Click);
      this.btn_aktar.Location = new Point(124, 79);
      this.btn_aktar.Name = "btn_aktar";
      this.btn_aktar.Size = new Size(107, 23);
      this.btn_aktar.TabIndex = 1;
      this.btn_aktar.Text = "Aktarımı Başlat";
      this.btn_aktar.Click += new EventHandler(this.btn_aktar_Click);
      this.chk_recstatus.Location = new Point(301, 54);
      this.chk_recstatus.Name = "chk_recstatus";
      this.chk_recstatus.Properties.Caption = "Sadece değişenleri güncelle";
      this.chk_recstatus.Size = new Size(162, 19);
      this.chk_recstatus.TabIndex = 5;
      this.t_time.EditValue = (object) new DateTime(2012, 4, 14, 0, 0, 0, 0);
      this.t_time.Enabled = false;
      this.t_time.Location = new Point(23, 54);
      this.t_time.Name = "t_time";
      this.t_time.Properties.AllowMouseWheel = false;
      this.t_time.Properties.ReadOnly = true;
      this.t_time.Size = new Size(60, 20);
      this.t_time.TabIndex = 9;
      this.t_time.TabStop = false;
      this.timer1.Interval = 1000;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.pb2.Location = new Point(23, 20);
      this.pb2.Name = "pb2";
      this.pb2.Properties.ShowTitle = true;
      this.pb2.Size = new Size(440, 26);
      this.pb2.TabIndex = 10;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(511, 137);
      this.Controls.Add((Control) this.groupBox1);
      this.MinimizeBox = false;
      this.Name = nameof (AktFrmFiyat);
      this.Text = "Malzeme Fiyat Güncelleme Formu";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.AktFrmFiyat_Load);
      this.groupBox1.ResumeLayout(false);
      this.chk_recstatus.Properties.EndInit();
      this.t_time.Properties.EndInit();
      this.pb2.Properties.EndInit();
      this.ResumeLayout(false);
    }
  }
}
