﻿// Decompiled with JetBrains decompiler
// Type: Fuar.ExcelFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Fuar.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class ExcelFrm : XtraForm
  {
    private string t_conn;
    private string t_firmano;
    private string t_donemno = string.Empty;
    private DataTable dt_grid;
    private bool save = true;
    private IContainer components;
    private GroupBox groupBox1;
    private SimpleButton btn_sec;
    private TextEdit txt_path;
    private OpenFileDialog ofd;
    private SimpleButton btn_start;
    private MarqueeProgressBarControl pb1;
    private GridControl dtg_excel;
    private GridView grd_excel;
    private SimpleButton btn_kapat;
    private CheckEdit chk_stok;
    private ProgressBarControl pb2;
    public BackgroundWorker bw;
    private ListBoxControl log_list;
    private GroupControl groupControl1;
    private GroupControl groupControl2;

    public ExcelFrm() => this.InitializeComponent();

    private void ExcelFrm_Load(object sender, EventArgs e) => this.pb1.Properties.Stopped = true;

    private void btn_kapat_Click(object sender, EventArgs e) => this.Close();

    private void btn_sec_Click(object sender, EventArgs e)
    {
      try
      {
        this.ofd.Filter = "Excel Dosyası (*.xls,*.xlsx)|*.xls;*.xlsx";
        if (this.ofd.ShowDialog() != DialogResult.OK)
          return;
        string[] array = new string[this.GetSheetsNames(this.ofd.FileName).Count];
        this.GetSheetsNames(this.ofd.FileName).CopyTo(array);
        this.txt_path.Text = this.ofd.FileName;
        this.grd_excel.Columns.Clear();
        this.dt_grid = this.grid_doldur(this.ofd.FileName, array[0]);
        for (int index = 0; index < this.dt_grid.Rows.Count; ++index)
        {
          if (string.IsNullOrEmpty(this.dt_grid.Rows[index]["MALZEMEKOD"].ToString()) || string.IsNullOrEmpty(this.dt_grid.Rows[index]["MUSTERIKODU"].ToString()))
          {
            this.dt_grid.Rows.RemoveAt(index);
            --index;
          }
        }
        this.dtg_excel.DataSource = (object) this.dt_grid;
        this.alankontrol(this.dt_grid);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private List<string> GetSheetsNames(string path)
    {
      List<string> sheetsNames = new List<string>();
      string str1 = !path.ToLower().EndsWith("x") ? "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=YES'" : "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
      DbConnection connection = DbProviderFactories.GetFactory("System.Data.OleDb").CreateConnection();
      connection.ConnectionString = str1;
      connection.Open();
      DataTable schema = connection.GetSchema("Tables");
      connection.Close();
      foreach (DataRow row in (InternalDataCollectionBase) schema.Rows)
      {
        string str2 = (string) row["TABLE_NAME"];
        if (str2.EndsWith("$"))
          str2 = str2.Substring(0, str2.Length - 1);
        sheetsNames.Add(str2);
      }
      return sheetsNames;
    }

    private DataTable grid_doldur(string file_name, string sheet_name)
    {
      OleDbConnection connection = new OleDbConnection(!file_name.ToLower().EndsWith("x") ? "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file_name + ";Extended Properties='Excel 8.0;HDR=YES'" : "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file_name + ";Extended Properties='Excel 12.0 Xml;HDR=YES'");
      connection.Open();
      OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM [" + sheet_name + "$]", connection);
      OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
      oleDbDataAdapter.SelectCommand = oleDbCommand;
      DataTable dataTable = new DataTable();
      oleDbDataAdapter.Fill(dataTable);
      connection.Close();
      oleDbDataAdapter.Dispose();
      return dataTable;
    }

    private void bw_DoWork(object sender, DoWorkEventArgs e) => this.excel_aktar();

    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.pb1.Properties.Stopped = true;
      this.btn_kapat.Enabled = true;
      this.btn_sec.Enabled = true;
      this.btn_start.Enabled = true;
      this.pb1.Text = "Aktarım Tamamlandı.";
      this.AddToListBox((object) "...:::Aktarım tamamlandı:::...");
    }

    private void btn_start_Click(object sender, EventArgs e)
    {
      if (this.txt_path.Text.Length > 7)
      {
        if (MessageBox.Show("Aktarıma başlanacaktır. Onaylıyormusunuz?", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
          return;
        try
        {
          if (!this.alankontrol(this.dt_grid) || !this.ayaroku_degiskene())
            return;
          this.log_list.Items.Clear();
          this.btn_kapat.Enabled = false;
          this.btn_sec.Enabled = false;
          this.btn_start.Enabled = false;
          this.pb1.Properties.Stopped = false;
          this.pb1.Text = "Aktarım sürüyor...";
          this.bw.RunWorkerAsync();
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message);
        }
      }
      else
      {
        int num1 = (int) MessageBox.Show("Excel dosyası seçiniz.");
      }
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

    public DataTable Distinct(DataTable dataSource, string distinctColumn)
    {
      DataTable dataTable = new DataTable();
      foreach (DataColumn column in (InternalDataCollectionBase) dataSource.Columns)
        dataTable.Columns.Add(column.ColumnName, column.DataType);
      bool flag = false;
      foreach (DataRow row1 in (InternalDataCollectionBase) dataSource.Rows)
      {
        foreach (DataRow row2 in (InternalDataCollectionBase) dataTable.Rows)
        {
          if (row2[distinctColumn].ToString() == row1[distinctColumn].ToString())
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          dataTable.Rows.Add(row1.ItemArray);
        flag = false;
      }
      return dataTable;
    }

    private bool alankontrol(DataTable dt_)
    {
      bool flag = true;
      if (!dt_.Columns.Contains("SIPARISNO"))
      {
        int num = (int) MessageBox.Show("Gerekli Excel kolonu eksik : SIPARISNO");
        flag = false;
      }
      if (!dt_.Columns.Contains("SIPARISTARIHI"))
      {
        int num = (int) MessageBox.Show("Gerekli Excel kolonu eksik : SIPARISTARIHI");
        flag = false;
      }
      if (!dt_.Columns.Contains("MUSTERIKODU"))
      {
        int num = (int) MessageBox.Show("Gerekli Excel kolonu eksik : MUSTERIKODU");
        flag = false;
      }
      if (!dt_.Columns.Contains("MALZEMEKOD"))
      {
        int num = (int) MessageBox.Show("Gerekli Excel kolonu eksik : MALZEMEKOD");
        flag = false;
      }
      if (!dt_.Columns.Contains("MALZEMEAD"))
      {
        int num = (int) MessageBox.Show("Gerekli Excel kolonu eksik : MALZEMEAD");
        flag = false;
      }
      if (!dt_.Columns.Contains("BARKOD"))
      {
        int num = (int) MessageBox.Show("Gerekli Excel kolonu eksik : BARKOD");
        flag = false;
      }
      if (!dt_.Columns.Contains("BIRIM"))
      {
        int num = (int) MessageBox.Show("Gerekli Excel kolonu eksik : BIRIM");
        flag = false;
      }
      if (!dt_.Columns.Contains("MIKTAR"))
      {
        int num = (int) MessageBox.Show("Gerekli Excel kolonu eksik : MIKTAR");
        flag = false;
      }
      if (!dt_.Columns.Contains("BIRIMFIYAT"))
      {
        int num = (int) MessageBox.Show("Gerekli Excel kolonu eksik : BIRIMFIYAT");
        flag = false;
      }
      if (!dt_.Columns.Contains("NETTUTAR"))
      {
        int num = (int) MessageBox.Show("Gerekli Excel kolonu eksik : NETTUTAR");
        flag = false;
      }
      if (!dt_.Columns.Contains("TEDARIKCIKOD"))
      {
        int num = (int) MessageBox.Show("Gerekli Excel kolonu eksik : TEDARIKCIKOD");
        flag = false;
      }
      return flag;
    }

    private void excel_aktar()
    {
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      string empty6 = string.Empty;
      string empty7 = string.Empty;
      string empty8 = string.Empty;
      string empty9 = string.Empty;
      string empty10 = string.Empty;
      this.save = true;
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = new DataTable();
      DataTable dataTable3 = this.Distinct(this.dt_grid, "SIPARISNO");
      int count = dataTable3.Rows.Count;
      for (int index1 = 0; index1 < dataTable3.Rows.Count; ++index1)
      {
        string newSipno = this.get_new_sipno();
        try
        {
          this.save = true;
          DataTable filteredTable = this.get_filtered_table(this.dt_grid, dataTable3.Rows[index1]["SIPARISNO"].ToString());
          DataTable musteriref = this.get_musteriref(dataTable3.Rows[index1]["MUSTERIKODU"].ToString());
          if (musteriref.Rows.Count == 0)
          {
            this.AddToListBox((object) (dataTable3.Rows[index1]["MUSTERIKODU"].ToString() + " kodlu Müşteri bulunamadı"));
            this.save = false;
            break;
          }
          string str1 = musteriref.Rows[0]["ID"].ToString();
          string str2 = musteriref.Rows[0]["ODEMESEKLI"].ToString();
          for (int index2 = 0; index2 < filteredTable.Rows.Count; ++index2)
          {
            string str3 = filteredTable.Rows[index2]["BARKOD"].ToString();
            if (string.IsNullOrEmpty(str3))
            {
              this.AddToListBox((object) "Barkod alanı boş olamaz.");
              this.save = false;
              break;
            }
            DataTable dataTable4 = this.get_item(str3);
            string urunkodu;
            string tedarikciref;
            if (dataTable4.Rows.Count == 0)
            {
              if (this.chk_stok.Checked)
              {
                if (filteredTable.Columns.Contains("TEDARIKCIKOD"))
                  empty6 = filteredTable.Rows[index2]["TEDARIKCIKOD"].ToString();
                if (filteredTable.Columns.Contains("MALZEMEAD"))
                  empty8 = filteredTable.Rows[index2]["MALZEMEAD"].ToString();
                urunkodu = !filteredTable.Columns.Contains("MALZEMEKOD") ? str3 : filteredTable.Rows[index2]["MALZEMEKOD"].ToString();
                this.insert_mlz(str3, urunkodu, empty8, empty6);
                tedarikciref = this.get_tedarikciref(empty6);
              }
              else
              {
                this.AddToListBox((object) (str3 + " Barkodlu ürün bulunamadı"));
                this.save = false;
                this.delete_sip(dataTable3.Rows[index1]["SIPARISNO"].ToString());
                this.AddToListBox((object) (dataTable3.Rows[index1]["SIPARISNO"].ToString() + " nolu sipariş eklenemedi."));
                break;
              }
            }
            else
            {
              urunkodu = dataTable4.Rows[0]["KOD"].ToString();
              empty8 = dataTable4.Rows[0]["AD"].ToString();
              empty10 = dataTable4.Rows[0]["BIRIM"].ToString();
              empty6 = filteredTable.Rows[index2]["TEDARIKCIKOD"].ToString();
              if (empty6 == "")
              {
                this.AddToListBox((object) (urunkodu + " kodlu " + empty8 + " isimli üründe tedarikçi seçilmemiş."));
                this.save = false;
                this.delete_sip(dataTable3.Rows[index1]["SIPARISNO"].ToString());
                this.AddToListBox((object) (dataTable3.Rows[index1]["SIPARISNO"].ToString() + " nolu sipariş eklenemedi."));
                break;
              }
              tedarikciref = this.get_tedarikciref(empty6);
              if (tedarikciref == "")
              {
                this.AddToListBox((object) (urunkodu + " kodlu " + empty8 + " isimli üründe seçilen " + empty6 + " isimli tedarikçi bulunamadı!"));
                this.save = false;
                this.delete_sip(dataTable3.Rows[index1]["SIPARISNO"].ToString());
                this.AddToListBox((object) (dataTable3.Rows[index1]["SIPARISNO"].ToString() + " nolu sipariş eklenemedi."));
                break;
              }
            }
            if (this.save)
            {
              using (SqlConnection sqlConnection = new SqlConnection(_main.str_connection))
              {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                string str4 = "INSERT INTO SIPARISLER (SIPARISTARIHI, SIPARISSAATI, SIPARISNO, MUSTERIREF, KULLANICIREF, TEDARIKCIREF, ACIKLAMA, ODEMESEKLI, SATIRTURU, MALZEMEREF, MALZEMEKOD, " + "BIRIM, MIKTAR, BIRIMFIYAT, TUTAR, INDIRIMREF, INDIRIMORANI1, INDIRIMORANI2, INDIRIMTUTARI, NETTUTAR, KDVORANI, KDVTUTARI, SATIRACIKLAMA, TESLIMTARIHI, SATIRNO) " + "VALUES (@SIPARISTARIHI, CONVERT(TIME(0),GETDATE()), @SIPARISNO, @MUSTERIREF, @KULLANICIREF, @TEDARIKCIREF, @ACIKLAMA, @ODEMESEKLI, 'Malzeme', @MALZEMEREF, @MALZEMEKOD, " + "@BIRIM, @MIKTAR, @BIRIMFIYAT, @TUTAR, 0, 0, 0, 0, @NETTUTAR, 0, 0, '', @TESLIMTARIHI, @SATIRNO)";
                command.CommandText = str4;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@SIPARISTARIHI", filteredTable.Rows[index2]["SIPARISTARIHI"]);
                command.Parameters.AddWithValue("@SIPARISNO", (object) newSipno);
                command.Parameters.AddWithValue("@MUSTERIREF", (object) str1);
                command.Parameters.AddWithValue("@KULLANICIREF", _main.dt_user.Rows[0]["ID"]);
                command.Parameters.AddWithValue("@TEDARIKCIREF", (object) tedarikciref);
                command.Parameters.AddWithValue("@ACIKLAMA", (object) ("Excelden aktarıldı. Sipno: " + dataTable3.Rows[index1]["SIPARISNO"].ToString()));
                command.Parameters.AddWithValue("@ODEMESEKLI", (object) str2);
                command.Parameters.AddWithValue("@MALZEMEREF", (object) 0);
                command.Parameters.AddWithValue("@MALZEMEKOD", (object) urunkodu);
                command.Parameters.AddWithValue("@BIRIM", (object) empty10);
                command.Parameters.AddWithValue("@MIKTAR", filteredTable.Rows[index2]["MIKTAR"]);
                command.Parameters.AddWithValue("@BIRIMFIYAT", filteredTable.Rows[index2]["BIRIMFIYAT"]);
                command.Parameters.AddWithValue("@TUTAR", filteredTable.Rows[index2]["NETTUTAR"]);
                command.Parameters.AddWithValue("@NETTUTAR", filteredTable.Rows[index2]["NETTUTAR"]);
                command.Parameters.AddWithValue("@TESLIMTARIHI", filteredTable.Rows[index2]["SIPARISTARIHI"]);
                command.Parameters.AddWithValue("@SATIRNO", (object) (index2 + 1));
                command.ExecuteNonQuery();
              }
            }
          }
        }
        catch (Exception ex)
        {
          this.AddToListBox((object) ("Sipariş eklenmedi ('" + newSipno + "')"));
          this.AddToListBox((object) ex.Message);
          this.delete_sip(newSipno);
        }
      }
    }

    private DataTable get_musteriref(string code)
    {
      return _main.komutcalistir_dt("SELECT ID,ODEMESEKLI FROM MUSTERILER WHERE FIRMAKODU = '" + code + "'");
    }

    private string get_tedarikciref(string code)
    {
      string empty = string.Empty;
      string tedarikciref = _main.komutcalistir_str("SELECT ID FROM TEDARIKCILER WHERE TEDARIKCIKODU = '" + code + "'");
      if (string.IsNullOrEmpty(tedarikciref))
        tedarikciref = "";
      return tedarikciref;
    }

    private string get_new_sipno()
    {
      int result = 0;
      string newSipno = string.Empty;
      string s = _main.komutcalistir_str("SELECT MAX(CONVERT(INT, SIPARISNO,0)) FROM SIPARISLER");
      if (s == "")
        newSipno = "000001";
      else if (int.TryParse(s, out result))
      {
        ++result;
        newSipno = result.ToString("d6");
      }
      else
      {
        int num = (int) MessageBox.Show("Uygun FişNo Oluşturulamadı");
      }
      return newSipno;
    }

    public bool IsNumeric(string text) => Regex.IsMatch(text, "^\\d+$");

    private DataTable get_filtered_table(DataTable dt_, string siparis_no)
    {
      DataTable filteredTable = dt_.Clone();
      foreach (DataRow row in dt_.Select("SIPARISNO = '" + siparis_no + "'"))
        filteredTable.ImportRow(row);
      return filteredTable;
    }

    private string get_main_unit(string s_mkod)
    {
      string mainUnit = _main.komutcalistir_str("SELECT B.BIRIM FROM MALZEMEDETAY AS MD INNER JOIN MALZEMELER AS M ON MD.MALZEMEID = M.ID INNER JOIN BIRIMLER AS B ON MD.BIRIMID = B.ID " + "WHERE (MD.ANABIRIM = 1) AND (M.KOD = '" + s_mkod + "')");
      if (mainUnit == "")
        mainUnit = "ADET";
      return mainUnit;
    }

    private DataTable get_item(string barkod)
    {
      return _main.komutcalistir_dt("SELECT M.KOD, M.AD, B.BIRIM, MD.SATISFIYATI, MD.PARABIRIMI, MD.KDVORANI, MD.KDVDAHIL, ISNULL(M.TEDARIKCI,'') AS TEDARIKCI FROM MALZEMEDETAY AS MD INNER JOIN " + "MALZEMELER AS M ON MD.MALZEMEID = M.ID INNER JOIN BIRIMLER AS B ON MD.BIRIMID = B.ID " + "WHERE (MD.BARKOD1 = '" + barkod + "') OR (MD.BARKOD2 = '" + barkod + "') OR (MD.BARKOD3 = '" + barkod + "') OR (MD.BARKOD4 = '" + barkod + "') OR (MD.BARKOD5 = '" + barkod + "')");
    }

    private void insert_mlz(string barcode, string urunkodu, string urunadi, string tedarikci)
    {
      if (this.check_mlzkod(urunkodu))
      {
        this.AddToListBox((object) (urunkodu + " kodlu ürün zaten mevcut"));
        this.save = false;
      }
      else
      {
        SqlTransaction sqlTransaction = (SqlTransaction) null;
        string empty = string.Empty;
        string cmdText1 = "INSERT INTO MALZEMELER (KOD,AD,TEDARIKCI) " + "VALUES ('" + urunkodu + "','" + urunadi + "','" + tedarikci + "') " + "SELECT @ID = @@IDENTITY";
        string cmdText2 = "INSERT INTO MALZEMEDETAY (MALZEMEID,BIRIMID,SATIRNO,ANABIRIM,KATSAYI,BARKOD1) " + "VALUES (@MALZEMEID,@BIRIMID,@SATIRNO,@ANABIRIM,@KATSAYI,@BARKOD1)";
        try
        {
          SqlConnection connection = new SqlConnection(_main.str_connection);
          SqlCommand sqlCommand1 = new SqlCommand(cmdText1, connection);
          SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.Int);
          sqlParameter.Direction = ParameterDirection.Output;
          sqlCommand1.Parameters.Add(sqlParameter);
          connection.Open();
          sqlTransaction = connection.BeginTransaction();
          sqlCommand1.Transaction = sqlTransaction;
          sqlCommand1.ExecuteNonQuery();
          int result = 0;
          if (int.TryParse(sqlParameter.Value.ToString(), out result))
          {
            SqlCommand sqlCommand2 = new SqlCommand(cmdText2, connection);
            sqlCommand2.Transaction = sqlTransaction;
            sqlCommand2.Parameters.Clear();
            sqlCommand2.Parameters.AddWithValue("@MALZEMEID", (object) result);
            sqlCommand2.Parameters.AddWithValue("@BIRIMID", (object) this.get_birimid("ADET"));
            sqlCommand2.Parameters.AddWithValue("@SATIRNO", (object) "1");
            sqlCommand2.Parameters.AddWithValue("@ANABIRIM", (object) "1");
            sqlCommand2.Parameters.AddWithValue("@KATSAYI", (object) "1");
            sqlCommand2.Parameters.AddWithValue("@BARKOD1", (object) barcode);
            sqlCommand2.ExecuteNonQuery();
          }
          sqlTransaction.Commit();
          this.AddToListBox((object) (barcode + " barkodlu yeni malzeme eklendi."));
        }
        catch (Exception ex)
        {
          this.AddToListBox((object) ex.Message);
          this.AddToListBox((object) (barcode + " barkodlu yeni malzeme eklenemedi!"));
          sqlTransaction.Rollback();
          this.save = false;
        }
      }
    }

    private void delete_sip(string siparis_no)
    {
      _main.komutcalistir("DELETE FROM SIPARISLER WHERE SIPARISNO = '" + siparis_no + "'");
    }

    private string get_birimid(string s_birim)
    {
      return _main.komutcalistir_str("SELECT ID FROM BIRIMLER WHERE BIRIM = '" + s_birim + "'");
    }

    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    }

    private bool check_mlzkod(string s_mlzkod)
    {
      return _main.komutcalistir_dt("SELECT KOD FROM MALZEMELER WHERE KOD = '" + s_mlzkod + "'").Rows.Count != 0;
    }

    private void AddToListBox(object oo)
    {
      this.Invoke((Delegate) (() => this.log_list.Items.Add(oo)));
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
      this.pb2 = new ProgressBarControl();
      this.chk_stok = new CheckEdit();
      this.btn_kapat = new SimpleButton();
      this.pb1 = new MarqueeProgressBarControl();
      this.btn_start = new SimpleButton();
      this.txt_path = new TextEdit();
      this.btn_sec = new SimpleButton();
      this.ofd = new OpenFileDialog();
      this.bw = new BackgroundWorker();
      this.dtg_excel = new GridControl();
      this.grd_excel = new GridView();
      this.log_list = new ListBoxControl();
      this.groupControl1 = new GroupControl();
      this.groupControl2 = new GroupControl();
      this.groupBox1.SuspendLayout();
      this.pb2.Properties.BeginInit();
      this.chk_stok.Properties.BeginInit();
      this.pb1.Properties.BeginInit();
      this.txt_path.Properties.BeginInit();
      this.dtg_excel.BeginInit();
      this.grd_excel.BeginInit();
      ((ISupportInitialize) this.log_list).BeginInit();
      this.groupControl1.BeginInit();
      this.groupControl1.SuspendLayout();
      this.groupControl2.BeginInit();
      this.groupControl2.SuspendLayout();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.pb2);
      this.groupBox1.Controls.Add((Control) this.chk_stok);
      this.groupBox1.Controls.Add((Control) this.btn_kapat);
      this.groupBox1.Controls.Add((Control) this.pb1);
      this.groupBox1.Controls.Add((Control) this.btn_start);
      this.groupBox1.Controls.Add((Control) this.txt_path);
      this.groupBox1.Controls.Add((Control) this.btn_sec);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(755, 149);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Excel ==> Sipariş Aktarımı";
      this.pb2.Location = new Point(228, 103);
      this.pb2.Name = "pb2";
      this.pb2.Size = new Size(342, 25);
      this.pb2.TabIndex = 10;
      this.pb2.Visible = false;
      this.chk_stok.EditValue = (object) true;
      this.chk_stok.Location = new Point(13, 71);
      this.chk_stok.Name = "chk_stok";
      this.chk_stok.Properties.Caption = "Stok Kartı bulunamadığında eklensin";
      this.chk_stok.Size = new Size(209, 19);
      this.chk_stok.TabIndex = 9;
      this.btn_kapat.Cursor = Cursors.Hand;
      this.btn_kapat.Image = (Image) Resources.kapat__Custom_;
      this.btn_kapat.Location = new Point(598, 103);
      this.btn_kapat.Name = "btn_kapat";
      this.btn_kapat.Size = new Size(138, 36);
      this.btn_kapat.TabIndex = 8;
      this.btn_kapat.Text = "Kapat";
      this.btn_kapat.Click += new EventHandler(this.btn_kapat_Click);
      this.pb1.EditValue = (object) "";
      this.pb1.Location = new Point(228, 66);
      this.pb1.Name = "pb1";
      this.pb1.Properties.ShowTitle = true;
      this.pb1.Size = new Size(508, 24);
      this.pb1.TabIndex = 7;
      this.btn_start.Cursor = Cursors.Hand;
      this.btn_start.Image = (Image) Resources.note_add;
      this.btn_start.Location = new Point(15, 103);
      this.btn_start.Name = "btn_start";
      this.btn_start.Size = new Size(138, 36);
      this.btn_start.TabIndex = 6;
      this.btn_start.Text = "Aktarımı Başlat";
      this.btn_start.Click += new EventHandler(this.btn_start_Click);
      this.txt_path.Location = new Point(159, 29);
      this.txt_path.Name = "txt_path";
      this.txt_path.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.txt_path.Properties.Appearance.Options.UseFont = true;
      this.txt_path.Properties.ReadOnly = true;
      this.txt_path.Size = new Size(577, 22);
      this.txt_path.TabIndex = 3;
      this.btn_sec.Appearance.Options.UseTextOptions = true;
      this.btn_sec.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
      this.btn_sec.Image = (Image) Resources.Exel;
      this.btn_sec.ImageLocation = ImageLocation.MiddleRight;
      this.btn_sec.Location = new Point(15, 20);
      this.btn_sec.Name = "btn_sec";
      this.btn_sec.Size = new Size(138, 36);
      this.btn_sec.TabIndex = 2;
      this.btn_sec.Text = "Excel Dosyası Yükle";
      this.btn_sec.Click += new EventHandler(this.btn_sec_Click);
      this.bw.WorkerReportsProgress = true;
      this.bw.DoWork += new DoWorkEventHandler(this.bw_DoWork);
      this.bw.ProgressChanged += new ProgressChangedEventHandler(this.bw_ProgressChanged);
      this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
      this.dtg_excel.Dock = DockStyle.Fill;
      this.dtg_excel.Location = new Point(2, 21);
      this.dtg_excel.MainView = (BaseView) this.grd_excel;
      this.dtg_excel.Name = "dtg_excel";
      this.dtg_excel.Size = new Size(909, 240);
      this.dtg_excel.TabIndex = 1;
      this.dtg_excel.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_excel
      });
      this.grd_excel.GridControl = this.dtg_excel;
      this.grd_excel.Name = "grd_excel";
      this.grd_excel.OptionsBehavior.Editable = false;
      this.grd_excel.OptionsCustomization.AllowFilter = false;
      this.grd_excel.OptionsCustomization.AllowGroup = false;
      this.grd_excel.OptionsCustomization.AllowSort = false;
      this.grd_excel.OptionsHint.ShowColumnHeaderHints = false;
      this.grd_excel.OptionsMenu.EnableColumnMenu = false;
      this.grd_excel.OptionsMenu.EnableFooterMenu = false;
      this.grd_excel.OptionsMenu.EnableGroupPanelMenu = false;
      this.grd_excel.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.grd_excel.OptionsSelection.EnableAppearanceFocusedRow = false;
      this.grd_excel.OptionsSelection.UseIndicatorForSelection = false;
      this.grd_excel.OptionsView.ShowGroupPanel = false;
      this.log_list.Dock = DockStyle.Fill;
      this.log_list.Location = new Point(2, 21);
      this.log_list.Name = "log_list";
      this.log_list.Size = new Size(909, 129);
      this.log_list.TabIndex = 2;
      this.groupControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupControl1.Controls.Add((Control) this.dtg_excel);
      this.groupControl1.Location = new Point(12, 167);
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new Size(913, 263);
      this.groupControl1.TabIndex = 3;
      this.groupControl1.Text = "Excel Dosyası İçeriği";
      this.groupControl2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.groupControl2.Controls.Add((Control) this.log_list);
      this.groupControl2.Location = new Point(12, 436);
      this.groupControl2.Name = "groupControl2";
      this.groupControl2.Size = new Size(913, 152);
      this.groupControl2.TabIndex = 4;
      this.groupControl2.Text = "Aktarım Kayıtları";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(937, 600);
      this.Controls.Add((Control) this.groupControl2);
      this.Controls.Add((Control) this.groupControl1);
      this.Controls.Add((Control) this.groupBox1);
      this.MinimizeBox = false;
      this.Name = nameof (ExcelFrm);
      this.Text = "Excel ==> Sipariş Aktarımı";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.ExcelFrm_Load);
      this.groupBox1.ResumeLayout(false);
      this.pb2.Properties.EndInit();
      this.chk_stok.Properties.EndInit();
      this.pb1.Properties.EndInit();
      this.txt_path.Properties.EndInit();
      this.dtg_excel.EndInit();
      this.grd_excel.EndInit();
      ((ISupportInitialize) this.log_list).EndInit();
      this.groupControl1.EndInit();
      this.groupControl1.ResumeLayout(false);
      this.groupControl2.EndInit();
      this.groupControl2.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}