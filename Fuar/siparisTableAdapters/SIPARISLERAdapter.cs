// Decompiled with JetBrains decompiler
// Type: Fuar.siparisTableAdapters.SIPARISLERAdapter
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

#nullable disable
namespace Fuar.siparisTableAdapters
{
  [DataObject(true)]
  [HelpKeyword("vs.data.TableAdapter")]
  [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  public class SIPARISLERAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public SIPARISLERAdapter() => this.ClearBeforeFill = true;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    private SqlDataAdapter Adapter
    {
      get
      {
        if (this._adapter == null)
          this.InitAdapter();
        return this._adapter;
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    internal SqlConnection Connection
    {
      get
      {
        if (this._connection == null)
          this.InitConnection();
        return this._connection;
      }
      set
      {
        this._connection = value;
        if (this.Adapter.InsertCommand != null)
          this.Adapter.InsertCommand.Connection = value;
        if (this.Adapter.DeleteCommand != null)
          this.Adapter.DeleteCommand.Connection = value;
        if (this.Adapter.UpdateCommand != null)
          this.Adapter.UpdateCommand.Connection = value;
        for (int index = 0; index < this.CommandCollection.Length; ++index)
        {
          if (this.CommandCollection[index] != null)
            this.CommandCollection[index].Connection = value;
        }
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected SqlCommand[] CommandCollection
    {
      get
      {
        if (this._commandCollection == null)
          this.InitCommandCollection();
        return this._commandCollection;
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool ClearBeforeFill
    {
      get => this._clearBeforeFill;
      set => this._clearBeforeFill = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private void InitAdapter()
    {
      this._adapter = new SqlDataAdapter();
      this._adapter.TableMappings.Add((object) new DataTableMapping()
      {
        SourceTable = "Table",
        DataSetTable = "SIPARISLER",
        ColumnMappings = {
          {
            "SIPARISTARIHI",
            "SIPARISTARIHI"
          },
          {
            "SIPARISSAATI",
            "SIPARISSAATI"
          },
          {
            "SIPARISNO",
            "SIPARISNO"
          },
          {
            "ACIKLAMA",
            "ACIKLAMA"
          },
          {
            "ODEMESEKLI",
            "ODEMESEKLI"
          },
          {
            "SATIRTURU",
            "SATIRTURU"
          },
          {
            "SATIRNO",
            "SATIRNO"
          },
          {
            "BIRIM",
            "BIRIM"
          },
          {
            "MIKTAR",
            "MIKTAR"
          },
          {
            "BIRIMFIYAT",
            "BIRIMFIYAT"
          },
          {
            "TUTAR",
            "TUTAR"
          },
          {
            "INDIRIMORANI1",
            "INDIRIMORANI1"
          },
          {
            "INDIRIMORANI2",
            "INDIRIMORANI2"
          },
          {
            "INDIRIMTUTARI",
            "INDIRIMTUTARI"
          },
          {
            "NETTUTAR",
            "NETTUTAR"
          },
          {
            "SATIRACIKLAMA",
            "SATIRACIKLAMA"
          },
          {
            "TESLIMTARIHI",
            "TESLIMTARIHI"
          },
          {
            "FIRMAKODU",
            "FIRMAKODU"
          },
          {
            "FIRMAADI",
            "FIRMAADI"
          },
          {
            "YETKILI",
            "YETKILI"
          },
          {
            "TELEFON1",
            "TELEFON1"
          },
          {
            "TELEFON2",
            "TELEFON2"
          },
          {
            "ILCE",
            "ILCE"
          },
          {
            "IL",
            "IL"
          },
          {
            "TEDARIKCIKODU",
            "TEDARIKCIKODU"
          },
          {
            "TEDARIKCIADI",
            "TEDARIKCIADI"
          },
          {
            "TEDARIKCILOGOSU",
            "TEDARIKCILOGOSU"
          },
          {
            "ADI",
            "ADI"
          },
          {
            "SOYADI",
            "SOYADI"
          },
          {
            "EPOSTA",
            "EPOSTA"
          },
          {
            "RESIM",
            "RESIM"
          },
          {
            "MALZEME KODU",
            "MALZEME KODU"
          },
          {
            "MALZEME ADI",
            "MALZEME ADI"
          },
          {
            "URETICIKODU",
            "URETICIKODU"
          },
          {
            "MARKA",
            "MARKA"
          },
          {
            "GRUPKODU",
            "GRUPKODU"
          },
          {
            "TEDARIKCI",
            "TEDARIKCI"
          },
          {
            "ANAKATEGORI",
            "ANAKATEGORI"
          },
          {
            "ALTKATEGORI",
            "ALTKATEGORI"
          },
          {
            "KRESIM",
            "KRESIM"
          },
          {
            "RESIM1",
            "RESIM1"
          },
          {
            "RESIM2",
            "RESIM2"
          },
          {
            "RESIM3",
            "RESIM3"
          },
          {
            "KDVTUTARI",
            "KDVTUTARI"
          },
          {
            "NETTOPLAM",
            "NETTOPLAM"
          }
        }
      });
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private void InitConnection()
    {
      this._connection = new SqlConnection();
      this._connection.ConnectionString = "Data Source=.;Initial Catalog=FUARDB;Persist Security Info=True;User ID=sa;Password=951623";
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private void InitCommandCollection()
    {
      this._commandCollection = new SqlCommand[2];
      this._commandCollection[0] = new SqlCommand();
      this._commandCollection[0].Connection = this.Connection;
      this._commandCollection[0].CommandText = "SELECT     S.SIPARISTARIHI, S.SIPARISSAATI, S.SIPARISNO, MU.FIRMAKODU, MU.FIRMAADI, MU.YETKILI, MU.TELEFON1, MU.TELEFON2, MU.ILCE, MU.IL, T.TEDARIKCIKODU, \r\n                      T.TEDARIKCIADI, T.TEDARIKCILOGOSU, K.ADI, K.SOYADI, K.EPOSTA, K.RESIM, MA.KOD AS [MALZEME KODU], MA.AD AS [MALZEME ADI], MA.URETICIKODU, \r\n                      MA.MARKA, MA.GRUPKODU, MA.TEDARIKCI, MA.ANAKATEGORI, MA.ALTKATEGORI1 AS ALTKATEGORI, MA.KRESIM, MA.RESIM1, MA.RESIM2, MA.RESIM3, \r\n                      S.ACIKLAMA, S.ODEMESEKLI, S.SATIRTURU, S.SATIRNO, S.BIRIM, S.MIKTAR, S.BIRIMFIYAT, S.TUTAR, S.INDIRIMORANI1, S.INDIRIMORANI2, S.INDIRIMTUTARI, \r\n                      S.NETTUTAR, S.SATIRACIKLAMA, S.TESLIMTARIHI, S.KDVTUTARI, (S.KDVTUTARI+ S.NETTUTAR) AS NETTOPLAM\r\nFROM         MUSTERILER AS MU RIGHT OUTER JOIN\r\n                      SIPARISLER AS S ON MU.ID = S.MUSTERIREF LEFT OUTER JOIN\r\n                      KULLANICILAR AS K ON S.KULLANICIREF = K.ID LEFT OUTER JOIN\r\n                      MALZEMELER AS MA ON S.MALZEMEKOD = MA.KOD LEFT OUTER JOIN\r\n                      TEDARIKCILER AS T ON S.TEDARIKCIREF = T.ID";
      this._commandCollection[0].CommandType = CommandType.Text;
      this._commandCollection[1] = new SqlCommand();
      this._commandCollection[1].Connection = this.Connection;
      this._commandCollection[1].CommandText = "SELECT     S.SIPARISTARIHI, S.SIPARISSAATI, S.SIPARISNO, MU.FIRMAKODU, MU.FIRMAADI, MU.YETKILI, MU.TELEFON1, MU.TELEFON2, MU.ILCE, MU.IL, T.TEDARIKCIKODU, \r\n                      T.TEDARIKCIADI, T.TEDARIKCILOGOSU, K.ADI, K.SOYADI, K.EPOSTA, K.RESIM, MA.KOD AS [MALZEME KODU], MA.AD AS [MALZEME ADI], MA.URETICIKODU, \r\n                      MA.MARKA, MA.GRUPKODU, MA.TEDARIKCI, MA.ANAKATEGORI, MA.ALTKATEGORI1 AS ALTKATEGORI, MA.KRESIM, MA.RESIM1, MA.RESIM2, MA.RESIM3, \r\n                      S.ACIKLAMA, S.ODEMESEKLI, S.SATIRTURU, S.SATIRNO, S.BIRIM, S.MIKTAR, S.BIRIMFIYAT, S.TUTAR, S.INDIRIMORANI1, S.INDIRIMORANI2, S.INDIRIMTUTARI, \r\n                      S.NETTUTAR, S.SATIRACIKLAMA, S.TESLIMTARIHI,S.KDVTUTARI,(S.KDVTUTARI + S.NETTUTAR) AS NETTOPLAM \r\nFROM         MUSTERILER AS MU RIGHT OUTER JOIN\r\n                      SIPARISLER AS S ON MU.ID = S.MUSTERIREF LEFT OUTER JOIN\r\n                      KULLANICILAR AS K ON S.KULLANICIREF = K.ID LEFT OUTER JOIN\r\n                      MALZEMELER AS MA ON S.MALZEMEKOD = MA.KOD LEFT OUTER JOIN\r\n                      TEDARIKCILER AS T ON S.TEDARIKCIREF = T.ID";
      this._commandCollection[1].CommandType = CommandType.Text;
    }

    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public virtual int Fill(siparis.SIPARISLERDataTable dataTable)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      if (this.ClearBeforeFill)
        dataTable.Clear();
      return this.Adapter.Fill((DataTable) dataTable);
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DebuggerNonUserCode]
    public virtual siparis.SIPARISLERDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      siparis.SIPARISLERDataTable data = new siparis.SIPARISLERDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, false)]
    public virtual int FillBy(siparis.SIPARISLERDataTable dataTable)
    {
      this.Adapter.SelectCommand = this.CommandCollection[1];
      if (this.ClearBeforeFill)
        dataTable.Clear();
      return this.Adapter.Fill((DataTable) dataTable);
    }
  }
}
