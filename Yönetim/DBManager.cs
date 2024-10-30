// Decompiled with JetBrains decompiler
// Type: Yönetim.DBManager
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace Yönetim
{
  public static class DBManager
  {
    private static SqlConnection _Connection = (SqlConnection) null;
    public static string Database = "";
    public static SqlDataAdapter adp = (SqlDataAdapter) null;

    private static string Constr()
    {
      string str = "";
      if (File.Exists(Application.StartupPath + "\\Setting.cfg"))
      {
        StreamReader streamReader = new StreamReader(Application.StartupPath + "\\Setting.cfg");
        str = streamReader.ReadLine();
        streamReader.Close();
      }
      return str;
    }

    public static void sqlConnect(string constr)
    {
      if (DBManager._Connection == null)
        DBManager._Connection = new SqlConnection();
      if (constr.Length == 0)
        DBManager._Connection.ConnectionString = DBManager.Constr();
      else
        DBManager._Connection.ConnectionString = constr;
      DBManager._Connection.Open();
    }

    public static void sqlDisConnect()
    {
      if (DBManager._Connection == null)
        return;
      DBManager._Connection.Close();
    }

    public static void sqlRunCommand(SqlCommand mCommand)
    {
      if (!DBManager.hasActiveConnection())
        return;
      mCommand.Connection = DBManager._Connection;
      try
      {
        mCommand.ExecuteNonQuery();
      }
      catch (SqlException ex)
      {
        throw new Exception(ex.Message);
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static bool hasActiveConnection()
    {
      if (DBManager._Connection == null)
        DBManager._Connection = new SqlConnection();
      if (DBManager._Connection.State != ConnectionState.Open)
        DBManager.sqlConnect("");
      return true;
    }

    public static DataTable sqlGetDataTable(SqlCommand mCommand)
    {
      DataTable dataTable = new DataTable("Table");
      if (DBManager.hasActiveConnection())
      {
        mCommand.Connection = DBManager._Connection;
        DBManager.adp = new SqlDataAdapter(mCommand);
        DBManager.adp.Fill(dataTable);
      }
      return dataTable;
    }

    public static int sqlGetScalarValue(SqlCommand mCommand)
    {
      int scalarValue = 0;
      if (DBManager.hasActiveConnection())
      {
        mCommand.Connection = DBManager._Connection;
        try
        {
          scalarValue = Convert.ToInt32(mCommand.ExecuteScalar().ToString());
        }
        catch (SqlException ex)
        {
          throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
          scalarValue = 0;
        }
      }
      return scalarValue;
    }

    public static string sqlGetScalarValue(SqlCommand mCommand, string ds)
    {
      string scalarValue = "";
      if (DBManager.hasActiveConnection())
      {
        mCommand.Connection = DBManager._Connection;
        try
        {
          scalarValue = mCommand.ExecuteScalar().ToString();
        }
        catch (SqlException ex)
        {
          throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
          scalarValue = "";
        }
      }
      return scalarValue;
    }

    public static void Update(DataTable dt, SqlDataAdapter adp)
    {
      SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adp);
      adp.InsertCommand = sqlCommandBuilder.GetInsertCommand();
      adp.Update(dt);
    }
  }
}
