// Decompiled with JetBrains decompiler
// Type: Fuar._main
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

#nullable disable
namespace Fuar
{
  internal class _main
  {
    internal static string str_connection;
    internal static string s_kadi;
    internal static string s_sifre;
    internal static string s_sunucu;
    internal static string s_db;
    internal static DataTable dt_user;
    internal static List<string> y_kartlar = new List<string>();
    internal static List<string> y_siparisler = new List<string>();
    internal static List<string> y_gchar = new List<string>();
    internal static List<string> y_kull = new List<string>();
    internal static List<string> y_logo_akt = new List<string>();
    internal static List<string> y_excel_akt = new List<string>();
    internal static List<string> y_rap = new List<string>();

    internal static string Decrypt(string cipherText, string Password)
    {
      byte[] cipherData = Convert.FromBase64String(cipherText);
      PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(Password, new byte[13]
      {
        (byte) 73,
        (byte) 118,
        (byte) 97,
        (byte) 110,
        (byte) 32,
        (byte) 77,
        (byte) 101,
        (byte) 100,
        (byte) 118,
        (byte) 101,
        (byte) 100,
        (byte) 101,
        (byte) 118
      });
      return Encoding.Unicode.GetString(_main.Decrypt(cipherData, passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16)));
    }

    internal static string Encrypt(string clearText, string Password)
    {
      byte[] bytes = Encoding.Unicode.GetBytes(clearText);
      PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(Password, new byte[13]
      {
        (byte) 73,
        (byte) 118,
        (byte) 97,
        (byte) 110,
        (byte) 32,
        (byte) 77,
        (byte) 101,
        (byte) 100,
        (byte) 118,
        (byte) 101,
        (byte) 100,
        (byte) 101,
        (byte) 118
      });
      return Convert.ToBase64String(_main.Encrypt(bytes, passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16)));
    }

    internal static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
    {
      MemoryStream memoryStream = new MemoryStream();
      Rijndael rijndael = Rijndael.Create();
      rijndael.Key = Key;
      rijndael.IV = IV;
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
      cryptoStream.Write(clearData, 0, clearData.Length);
      cryptoStream.Close();
      return memoryStream.ToArray();
    }

    internal static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
    {
      MemoryStream memoryStream = new MemoryStream();
      Rijndael rijndael = Rijndael.Create();
      rijndael.Key = Key;
      rijndael.IV = IV;
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
      cryptoStream.Write(cipherData, 0, cipherData.Length);
      cryptoStream.Close();
      return memoryStream.ToArray();
    }

    internal static bool mail_gonder(
      string gonderen,
      string alici,
      string sunucu,
      string kadi,
      string sifre,
      string konu,
      string mesaj,
      Attachment file)
    {
      try
      {
        MailMessage message = new MailMessage(gonderen, alici, konu, mesaj);
        SmtpClient smtpClient = new SmtpClient(sunucu, 26);
        message.Attachments.Add(file);
        smtpClient.Credentials = (ICredentialsByHost) new NetworkCredential(kadi, sifre);
        smtpClient.Send(message);
        return true;
      }
      catch (Exception ex)
      {
        _main.txt_yaz(ex.Message + "::\n" + ex.StackTrace, "mail_err.txt");
        return false;
      }
    }

    internal static bool mail_gonder_simple(string alici, string konu, string mesaj)
    {
      try
      {
        new SmtpClient("mail.dmsbilgisayar.com", 26)
        {
          Credentials = ((ICredentialsByHost) new NetworkCredential("server@dmsbilgisayar.com", "951623"))
        }.Send(new MailMessage("server@dmsbilgisayar.com", alici, konu, mesaj));
        return true;
      }
      catch (Exception ex)
      {
        _main.txt_yaz(ex.Message + "::\n" + ex.StackTrace, "mail_err.txt");
        return false;
      }
    }

    internal static void txt_yaz(string data, string dosya_adi)
    {
      FileInfo fileInfo = new FileInfo(dosya_adi);
      StreamWriter streamWriter = !fileInfo.Exists ? fileInfo.CreateText() : fileInfo.AppendText();
      streamWriter.WriteLine("\n" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "::\n");
      streamWriter.WriteLine(data);
      streamWriter.Close();
    }

    internal static void logyaz(
      string fistarihi,
      string fisno,
      string islemturu,
      string bilgi,
      string durum)
    {
      SqlConnection connection = new SqlConnection(_main.str_connection);
      try
      {
        SqlCommand sqlCommand = new SqlCommand("INSERT INTO FtpLogoTransferLogs (IslemTarihi,IslemTuru,FisNo,FisTarihi,Bilgi,Durum) " + "VALUES (GETDATE(),'" + islemturu + "','" + fisno + "',CONVERT(date, '" + fistarihi + "', 104),'" + bilgi + "','" + durum + "')", connection);
        connection.Open();
        sqlCommand.ExecuteNonQuery();
        connection.Close();
      }
      catch (Exception ex)
      {
        connection.Close();
        _main.txt_yaz(ex.Message + "::\n" + ex.StackTrace, "logyaz_err.txt");
      }
    }

    internal static int komutcalistir(string sql_str)
    {
      int num = 0;
      try
      {
        SqlConnection connection = new SqlConnection(_main.str_connection);
        SqlCommand sqlCommand = new SqlCommand(sql_str, connection);
        connection.Open();
        num = sqlCommand.ExecuteNonQuery();
        connection.Close();
        return num;
      }
      catch (Exception ex)
      {
        _main.txt_yaz(ex.Message + "::\n" + ex.StackTrace + "\n:::" + sql_str, "runcmd_err.txt");
        return num;
      }
    }

    internal static int komutcalistir_int(string sql_str)
    {
      int result = 0;
      try
      {
        SqlConnection connection = new SqlConnection(_main.str_connection);
        SqlCommand sqlCommand = new SqlCommand(sql_str, connection);
        connection.Open();
        object obj = sqlCommand.ExecuteScalar();
        connection.Close();
        if (obj == null)
          result = 0;
        else if (!int.TryParse(obj.ToString(), out result))
          result = 0;
        return result;
      }
      catch (Exception ex)
      {
        _main.txt_yaz(ex.Message + "::\n" + ex.StackTrace + "\n:::" + sql_str, "runcmd_err.txt");
        return result;
      }
    }

    internal static double komutcalistir_double(string sql_str)
    {
      double result = 0.0;
      try
      {
        SqlConnection connection = new SqlConnection(_main.str_connection);
        SqlCommand sqlCommand = new SqlCommand(sql_str, connection);
        connection.Open();
        object obj = sqlCommand.ExecuteScalar();
        connection.Close();
        if (obj == null)
          result = 0.0;
        else if (!double.TryParse(obj.ToString(), out result))
          result = 0.0;
        return result;
      }
      catch (Exception ex)
      {
        _main.txt_yaz(ex.Message + "::\n" + ex.StackTrace + "\n:::" + sql_str, "runcmd_err.txt");
        return result;
      }
    }

    internal static string komutcalistir_str(string sql_str)
    {
      try
      {
        SqlConnection connection = new SqlConnection(_main.str_connection);
        SqlCommand sqlCommand = new SqlCommand(sql_str, connection);
        connection.Open();
        object obj = sqlCommand.ExecuteScalar();
        connection.Close();
        if (obj == null)
          obj = (object) "";
        return obj.ToString();
      }
      catch (Exception ex)
      {
        _main.txt_yaz(ex.Message + "::\n" + ex.StackTrace, "runcmd_str_err.txt");
        return "".ToString();
      }
    }

    internal static DataTable komutcalistir_dt(string sql_str)
    {
      DataTable dataTable = new DataTable();
      try
      {
        SqlConnection connection = new SqlConnection(_main.str_connection);
        SqlCommand sqlCommand = new SqlCommand(sql_str, connection);
        connection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        dataTable.Load((IDataReader) reader);
        connection.Close();
        return dataTable;
      }
      catch (Exception ex)
      {
        _main.txt_yaz(ex.Message + "::\n" + ex.StackTrace + "\n:::" + sql_str, "runcmd_dt_err.txt");
        return dataTable;
      }
    }

    private byte[] fotografAl(string strPath)
    {
      FileStream input = new FileStream(strPath, FileMode.Open, FileAccess.Read);
      BinaryReader binaryReader = new BinaryReader((Stream) input);
      byte[] numArray = binaryReader.ReadBytes((int) input.Length);
      binaryReader.Close();
      input.Close();
      return numArray;
    }

    internal static byte[] imageToByteArray(Image imageIn)
    {
      MemoryStream memoryStream = new MemoryStream();
      imageIn.Save((Stream) memoryStream, ImageFormat.Gif);
      return memoryStream.ToArray();
    }

    internal static Image byteArrayToImage(byte[] byteArrayIn)
    {
      return Image.FromStream((Stream) new MemoryStream(byteArrayIn));
    }

    internal static void get_right()
    {
      if (_main.dt_user.Rows[0]["KULLANICIADI"].ToString() != "ADMIN")
      {
        DataView dataView = new DataView(_main.komutcalistir_dt("SELECT Y.MODUL, Y.CANBROWSE, Y.CANINSERT, Y.CANEDIT, Y.CANDELETE FROM GRUPLAR AS G LEFT OUTER JOIN YETKILER AS Y ON G.ID = Y.GRUPID " + "WHERE Y.GRUPID = '" + _main.dt_user.Rows[0]["GRUPID"].ToString() + "'"));
        dataView.RowFilter = "MODUL = 'Kartlar'";
        DataTable table1 = dataView.ToTable();
        if (table1.Rows.Count > 0)
        {
          _main.y_kartlar.Clear();
          _main.y_kartlar.Add(table1.Rows[0]["CANBROWSE"].ToString());
          _main.y_kartlar.Add(table1.Rows[0]["CANINSERT"].ToString());
          _main.y_kartlar.Add(table1.Rows[0]["CANEDIT"].ToString());
          _main.y_kartlar.Add(table1.Rows[0]["CANDELETE"].ToString());
        }
        else
        {
          _main.y_kartlar.Clear();
          _main.y_kartlar.Add("False");
          _main.y_kartlar.Add("False");
          _main.y_kartlar.Add("False");
          _main.y_kartlar.Add("False");
        }
        dataView.RowFilter = "MODUL = 'Siparişler'";
        DataTable table2 = dataView.ToTable();
        if (table2.Rows.Count > 0)
        {
          _main.y_siparisler.Clear();
          _main.y_siparisler.Add(table2.Rows[0]["CANBROWSE"].ToString());
          _main.y_siparisler.Add(table2.Rows[0]["CANINSERT"].ToString());
          _main.y_siparisler.Add(table2.Rows[0]["CANEDIT"].ToString());
          _main.y_siparisler.Add(table2.Rows[0]["CANDELETE"].ToString());
        }
        else
        {
          _main.y_siparisler.Clear();
          _main.y_siparisler.Add("False");
          _main.y_siparisler.Add("False");
          _main.y_siparisler.Add("False");
          _main.y_siparisler.Add("False");
        }
        dataView.RowFilter = "MODUL = 'G/Ç Hareketleri'";
        DataTable table3 = dataView.ToTable();
        if (table3.Rows.Count > 0)
        {
          _main.y_gchar.Clear();
          _main.y_gchar.Add(table3.Rows[0]["CANBROWSE"].ToString());
          _main.y_gchar.Add(table3.Rows[0]["CANINSERT"].ToString());
          _main.y_gchar.Add(table3.Rows[0]["CANEDIT"].ToString());
          _main.y_gchar.Add(table3.Rows[0]["CANDELETE"].ToString());
        }
        else
        {
          _main.y_gchar.Clear();
          _main.y_gchar.Add("False");
          _main.y_gchar.Add("False");
          _main.y_gchar.Add("False");
          _main.y_gchar.Add("False");
        }
        dataView.RowFilter = "MODUL = 'Kullanıcı Tanımları'";
        DataTable table4 = dataView.ToTable();
        if (table4.Rows.Count > 0)
        {
          _main.y_kull.Clear();
          _main.y_kull.Add(table4.Rows[0]["CANBROWSE"].ToString());
          _main.y_kull.Add(table4.Rows[0]["CANINSERT"].ToString());
          _main.y_kull.Add(table4.Rows[0]["CANEDIT"].ToString());
          _main.y_kull.Add(table4.Rows[0]["CANDELETE"].ToString());
        }
        else
        {
          _main.y_kull.Clear();
          _main.y_kull.Add("False");
          _main.y_kull.Add("False");
          _main.y_kull.Add("False");
          _main.y_kull.Add("False");
        }
        dataView.RowFilter = "MODUL = 'Logo Aktarımları'";
        DataTable table5 = dataView.ToTable();
        if (table5.Rows.Count > 0)
        {
          _main.y_logo_akt.Clear();
          _main.y_logo_akt.Add(table5.Rows[0]["CANBROWSE"].ToString());
          _main.y_logo_akt.Add(table5.Rows[0]["CANINSERT"].ToString());
          _main.y_logo_akt.Add(table5.Rows[0]["CANEDIT"].ToString());
          _main.y_logo_akt.Add(table5.Rows[0]["CANDELETE"].ToString());
        }
        else
        {
          _main.y_logo_akt.Clear();
          _main.y_logo_akt.Add("False");
          _main.y_logo_akt.Add("False");
          _main.y_logo_akt.Add("False");
          _main.y_logo_akt.Add("False");
        }
        dataView.RowFilter = "MODUL = 'Excel Aktarımları'";
        DataTable table6 = dataView.ToTable();
        if (table6.Rows.Count > 0)
        {
          _main.y_excel_akt.Clear();
          _main.y_excel_akt.Add(table6.Rows[0]["CANBROWSE"].ToString());
          _main.y_excel_akt.Add(table6.Rows[0]["CANINSERT"].ToString());
          _main.y_excel_akt.Add(table6.Rows[0]["CANEDIT"].ToString());
          _main.y_excel_akt.Add(table6.Rows[0]["CANDELETE"].ToString());
        }
        else
        {
          _main.y_excel_akt.Clear();
          _main.y_excel_akt.Add("False");
          _main.y_excel_akt.Add("False");
          _main.y_excel_akt.Add("False");
          _main.y_excel_akt.Add("False");
        }
        dataView.RowFilter = "MODUL = 'Raporlar'";
        DataTable table7 = dataView.ToTable();
        if (table7.Rows.Count > 0)
        {
          _main.y_rap.Clear();
          _main.y_rap.Add(table7.Rows[0]["CANBROWSE"].ToString());
          _main.y_rap.Add(table7.Rows[0]["CANINSERT"].ToString());
          _main.y_rap.Add(table7.Rows[0]["CANEDIT"].ToString());
          _main.y_rap.Add(table7.Rows[0]["CANDELETE"].ToString());
        }
        else
        {
          _main.y_rap.Clear();
          _main.y_rap.Add("False");
          _main.y_rap.Add("False");
          _main.y_rap.Add("False");
          _main.y_rap.Add("False");
        }
      }
      else
      {
        _main.y_kartlar.Clear();
        _main.y_kartlar.Add("True");
        _main.y_kartlar.Add("True");
        _main.y_kartlar.Add("True");
        _main.y_kartlar.Add("True");
        _main.y_siparisler.Clear();
        _main.y_siparisler.Add("True");
        _main.y_siparisler.Add("True");
        _main.y_siparisler.Add("True");
        _main.y_siparisler.Add("True");
        _main.y_gchar.Clear();
        _main.y_gchar.Add("True");
        _main.y_gchar.Add("True");
        _main.y_gchar.Add("True");
        _main.y_gchar.Add("True");
        _main.y_kull.Clear();
        _main.y_kull.Add("True");
        _main.y_kull.Add("True");
        _main.y_kull.Add("True");
        _main.y_kull.Add("True");
        _main.y_logo_akt.Clear();
        _main.y_logo_akt.Add("True");
        _main.y_logo_akt.Add("True");
        _main.y_logo_akt.Add("True");
        _main.y_logo_akt.Add("True");
        _main.y_excel_akt.Clear();
        _main.y_excel_akt.Add("True");
        _main.y_excel_akt.Add("True");
        _main.y_excel_akt.Add("True");
        _main.y_excel_akt.Add("True");
        _main.y_rap.Clear();
        _main.y_rap.Add("True");
        _main.y_rap.Add("True");
        _main.y_rap.Add("True");
        _main.y_rap.Add("True");
      }
    }
  }
}
