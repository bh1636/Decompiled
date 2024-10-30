// Decompiled with JetBrains decompiler
// Type: Fuar.siparis
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

#nullable disable
namespace Fuar
{
  [DesignerCategory("code")]
  [XmlSchemaProvider("GetTypedDataSetSchema")]
  [HelpKeyword("vs.data.DataSet")]
  [XmlRoot("siparis")]
  [ToolboxItem(true)]
  [Serializable]
  public class siparis : DataSet
  {
    private siparis.SIPARISLERDataTable tableSIPARISLER;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public siparis()
    {
      this.BeginInit();
      this.InitClass();
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      base.Tables.CollectionChanged += changeEventHandler;
      base.Relations.CollectionChanged += changeEventHandler;
      this.EndInit();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected siparis(SerializationInfo info, StreamingContext context)
      : base(info, context, false)
    {
      if (this.IsBinarySerialized(info, context))
      {
        this.InitVars(false);
        CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
        this.Tables.CollectionChanged += changeEventHandler;
        this.Relations.CollectionChanged += changeEventHandler;
      }
      else
      {
        string s = (string) info.GetValue("XmlSchema", typeof (string));
        if (this.DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema)
        {
          DataSet dataSet = new DataSet();
          dataSet.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
          if (dataSet.Tables[nameof (SIPARISLER)] != null)
            base.Tables.Add((DataTable) new siparis.SIPARISLERDataTable(dataSet.Tables[nameof (SIPARISLER)]));
          this.DataSetName = dataSet.DataSetName;
          this.Prefix = dataSet.Prefix;
          this.Namespace = dataSet.Namespace;
          this.Locale = dataSet.Locale;
          this.CaseSensitive = dataSet.CaseSensitive;
          this.EnforceConstraints = dataSet.EnforceConstraints;
          this.Merge(dataSet, false, MissingSchemaAction.Add);
          this.InitVars();
        }
        else
          this.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
        this.GetSerializationData(info, context);
        CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
        base.Tables.CollectionChanged += changeEventHandler;
        this.Relations.CollectionChanged += changeEventHandler;
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Browsable(false)]
    [DebuggerNonUserCode]
    public siparis.SIPARISLERDataTable SIPARISLER => this.tableSIPARISLER;

    [DebuggerNonUserCode]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Browsable(true)]
    public override SchemaSerializationMode SchemaSerializationMode
    {
      get => this._schemaSerializationMode;
      set => this._schemaSerializationMode = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataTableCollection Tables => base.Tables;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DebuggerNonUserCode]
    public new DataRelationCollection Relations => base.Relations;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    protected override void InitializeDerivedDataSet()
    {
      this.BeginInit();
      this.InitClass();
      this.EndInit();
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public override DataSet Clone()
    {
      siparis siparis = (siparis) base.Clone();
      siparis.InitVars();
      siparis.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) siparis;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    protected override bool ShouldSerializeTables() => false;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    protected override bool ShouldSerializeRelations() => false;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    protected override void ReadXmlSerializable(XmlReader reader)
    {
      if (this.DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
      {
        this.Reset();
        DataSet dataSet = new DataSet();
        int num = (int) dataSet.ReadXml(reader);
        if (dataSet.Tables["SIPARISLER"] != null)
          base.Tables.Add((DataTable) new siparis.SIPARISLERDataTable(dataSet.Tables["SIPARISLER"]));
        this.DataSetName = dataSet.DataSetName;
        this.Prefix = dataSet.Prefix;
        this.Namespace = dataSet.Namespace;
        this.Locale = dataSet.Locale;
        this.CaseSensitive = dataSet.CaseSensitive;
        this.EnforceConstraints = dataSet.EnforceConstraints;
        this.Merge(dataSet, false, MissingSchemaAction.Add);
        this.InitVars();
      }
      else
      {
        int num = (int) this.ReadXml(reader);
        this.InitVars();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected override XmlSchema GetSchemaSerializable()
    {
      MemoryStream memoryStream = new MemoryStream();
      this.WriteXmlSchema((XmlWriter) new XmlTextWriter((Stream) memoryStream, (Encoding) null));
      memoryStream.Position = 0L;
      return XmlSchema.Read((XmlReader) new XmlTextReader((Stream) memoryStream), (ValidationEventHandler) null);
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    internal void InitVars() => this.InitVars(true);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    internal void InitVars(bool initTable)
    {
      this.tableSIPARISLER = (siparis.SIPARISLERDataTable) base.Tables["SIPARISLER"];
      if (!initTable || this.tableSIPARISLER == null)
        return;
      this.tableSIPARISLER.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (siparis);
      this.Prefix = "";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tableSIPARISLER = new siparis.SIPARISLERDataTable();
      base.Tables.Add((DataTable) this.tableSIPARISLER);
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    private bool ShouldSerializeSIPARISLER() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private void SchemaChanged(object sender, CollectionChangeEventArgs e)
    {
      if (e.Action != CollectionChangeAction.Remove)
        return;
      this.InitVars();
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
    {
      siparis siparis = new siparis();
      XmlSchemaComplexType typedDataSetSchema = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = siparis.Namespace
      });
      typedDataSetSchema.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = siparis.GetSchemaSerializable();
      if (xs.Contains(schemaSerializable.TargetNamespace))
      {
        MemoryStream memoryStream1 = new MemoryStream();
        MemoryStream memoryStream2 = new MemoryStream();
        try
        {
          schemaSerializable.Write((Stream) memoryStream1);
          IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
          while (enumerator.MoveNext())
          {
            XmlSchema current = (XmlSchema) enumerator.Current;
            memoryStream2.SetLength(0L);
            current.Write((Stream) memoryStream2);
            if (memoryStream1.Length == memoryStream2.Length)
            {
              memoryStream1.Position = 0L;
              memoryStream2.Position = 0L;
              do
                ;
              while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
              if (memoryStream1.Position == memoryStream1.Length)
                return typedDataSetSchema;
            }
          }
        }
        finally
        {
          memoryStream1?.Close();
          memoryStream2?.Close();
        }
      }
      xs.Add(schemaSerializable);
      return typedDataSetSchema;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public delegate void SIPARISLERRowChangeEventHandler(
      object sender,
      siparis.SIPARISLERRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class SIPARISLERDataTable : TypedTableBase<siparis.SIPARISLERRow>
    {
      private DataColumn columnSIPARISTARIHI;
      private DataColumn columnSIPARISSAATI;
      private DataColumn columnSIPARISNO;
      private DataColumn columnACIKLAMA;
      private DataColumn columnODEMESEKLI;
      private DataColumn columnSATIRTURU;
      private DataColumn columnSATIRNO;
      private DataColumn columnBIRIM;
      private DataColumn columnMIKTAR;
      private DataColumn columnBIRIMFIYAT;
      private DataColumn columnTUTAR;
      private DataColumn columnINDIRIMORANI1;
      private DataColumn columnINDIRIMORANI2;
      private DataColumn columnINDIRIMTUTARI;
      private DataColumn columnNETTUTAR;
      private DataColumn columnSATIRACIKLAMA;
      private DataColumn columnTESLIMTARIHI;
      private DataColumn columnFIRMAKODU;
      private DataColumn columnFIRMAADI;
      private DataColumn columnYETKILI;
      private DataColumn columnTELEFON1;
      private DataColumn columnTELEFON2;
      private DataColumn columnILCE;
      private DataColumn columnIL;
      private DataColumn columnTEDARIKCIKODU;
      private DataColumn columnTEDARIKCIADI;
      private DataColumn columnTEDARIKCILOGOSU;
      private DataColumn columnADI;
      private DataColumn columnSOYADI;
      private DataColumn columnEPOSTA;
      private DataColumn columnRESIM;
      private DataColumn columnMALZEME_KODU;
      private DataColumn columnMALZEME_ADI;
      private DataColumn columnURETICIKODU;
      private DataColumn columnMARKA;
      private DataColumn columnGRUPKODU;
      private DataColumn columnTEDARIKCI;
      private DataColumn columnANAKATEGORI;
      private DataColumn columnALTKATEGORI;
      private DataColumn columnKRESIM;
      private DataColumn columnRESIM1;
      private DataColumn columnRESIM2;
      private DataColumn columnRESIM3;
      private DataColumn columnKDVTUTARI;
      private DataColumn columnNETTOPLAM;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public SIPARISLERDataTable()
      {
        this.TableName = "SIPARISLER";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      internal SIPARISLERDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected SIPARISLERDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn SIPARISTARIHIColumn => this.columnSIPARISTARIHI;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn SIPARISSAATIColumn => this.columnSIPARISSAATI;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn SIPARISNOColumn => this.columnSIPARISNO;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn ACIKLAMAColumn => this.columnACIKLAMA;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn ODEMESEKLIColumn => this.columnODEMESEKLI;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn SATIRTURUColumn => this.columnSATIRTURU;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn SATIRNOColumn => this.columnSATIRNO;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn BIRIMColumn => this.columnBIRIM;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn MIKTARColumn => this.columnMIKTAR;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn BIRIMFIYATColumn => this.columnBIRIMFIYAT;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn TUTARColumn => this.columnTUTAR;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn INDIRIMORANI1Column => this.columnINDIRIMORANI1;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn INDIRIMORANI2Column => this.columnINDIRIMORANI2;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn INDIRIMTUTARIColumn => this.columnINDIRIMTUTARI;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn NETTUTARColumn => this.columnNETTUTAR;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn SATIRACIKLAMAColumn => this.columnSATIRACIKLAMA;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn TESLIMTARIHIColumn => this.columnTESLIMTARIHI;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn FIRMAKODUColumn => this.columnFIRMAKODU;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn FIRMAADIColumn => this.columnFIRMAADI;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn YETKILIColumn => this.columnYETKILI;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn TELEFON1Column => this.columnTELEFON1;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn TELEFON2Column => this.columnTELEFON2;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn ILCEColumn => this.columnILCE;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn ILColumn => this.columnIL;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn TEDARIKCIKODUColumn => this.columnTEDARIKCIKODU;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn TEDARIKCIADIColumn => this.columnTEDARIKCIADI;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn TEDARIKCILOGOSUColumn => this.columnTEDARIKCILOGOSU;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn ADIColumn => this.columnADI;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn SOYADIColumn => this.columnSOYADI;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn EPOSTAColumn => this.columnEPOSTA;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn RESIMColumn => this.columnRESIM;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn MALZEME_KODUColumn => this.columnMALZEME_KODU;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn MALZEME_ADIColumn => this.columnMALZEME_ADI;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn URETICIKODUColumn => this.columnURETICIKODU;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn MARKAColumn => this.columnMARKA;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn GRUPKODUColumn => this.columnGRUPKODU;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn TEDARIKCIColumn => this.columnTEDARIKCI;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn ANAKATEGORIColumn => this.columnANAKATEGORI;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn ALTKATEGORIColumn => this.columnALTKATEGORI;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn KRESIMColumn => this.columnKRESIM;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn RESIM1Column => this.columnRESIM1;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn RESIM2Column => this.columnRESIM2;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn RESIM3Column => this.columnRESIM3;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn KDVTUTARIColumn => this.columnKDVTUTARI;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataColumn NETTOPLAMColumn => this.columnNETTOPLAM;

      [DebuggerNonUserCode]
      [Browsable(false)]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public int Count => this.Rows.Count;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public siparis.SIPARISLERRow this[int index] => (siparis.SIPARISLERRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event siparis.SIPARISLERRowChangeEventHandler SIPARISLERRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event siparis.SIPARISLERRowChangeEventHandler SIPARISLERRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event siparis.SIPARISLERRowChangeEventHandler SIPARISLERRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event siparis.SIPARISLERRowChangeEventHandler SIPARISLERRowDeleted;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void AddSIPARISLERRow(siparis.SIPARISLERRow row) => this.Rows.Add((DataRow) row);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public siparis.SIPARISLERRow AddSIPARISLERRow(
        DateTime SIPARISTARIHI,
        TimeSpan SIPARISSAATI,
        string SIPARISNO,
        string ACIKLAMA,
        string ODEMESEKLI,
        string SATIRTURU,
        int SATIRNO,
        string BIRIM,
        double MIKTAR,
        double BIRIMFIYAT,
        double TUTAR,
        double INDIRIMORANI1,
        double INDIRIMORANI2,
        double INDIRIMTUTARI,
        double NETTUTAR,
        string SATIRACIKLAMA,
        DateTime TESLIMTARIHI,
        string FIRMAKODU,
        string FIRMAADI,
        string YETKILI,
        string TELEFON1,
        string TELEFON2,
        string ILCE,
        string IL,
        string TEDARIKCIKODU,
        string TEDARIKCIADI,
        byte[] TEDARIKCILOGOSU,
        string ADI,
        string SOYADI,
        string EPOSTA,
        byte[] RESIM,
        string MALZEME_KODU,
        string MALZEME_ADI,
        string URETICIKODU,
        string MARKA,
        string GRUPKODU,
        string TEDARIKCI,
        string ANAKATEGORI,
        string ALTKATEGORI,
        byte[] KRESIM,
        byte[] RESIM1,
        byte[] RESIM2,
        byte[] RESIM3,
        double KDVTUTARI,
        double NETTOPLAM)
      {
        siparis.SIPARISLERRow row = (siparis.SIPARISLERRow) this.NewRow();
        object[] objArray = new object[45]
        {
          (object) SIPARISTARIHI,
          (object) SIPARISSAATI,
          (object) SIPARISNO,
          (object) ACIKLAMA,
          (object) ODEMESEKLI,
          (object) SATIRTURU,
          (object) SATIRNO,
          (object) BIRIM,
          (object) MIKTAR,
          (object) BIRIMFIYAT,
          (object) TUTAR,
          (object) INDIRIMORANI1,
          (object) INDIRIMORANI2,
          (object) INDIRIMTUTARI,
          (object) NETTUTAR,
          (object) SATIRACIKLAMA,
          (object) TESLIMTARIHI,
          (object) FIRMAKODU,
          (object) FIRMAADI,
          (object) YETKILI,
          (object) TELEFON1,
          (object) TELEFON2,
          (object) ILCE,
          (object) IL,
          (object) TEDARIKCIKODU,
          (object) TEDARIKCIADI,
          (object) TEDARIKCILOGOSU,
          (object) ADI,
          (object) SOYADI,
          (object) EPOSTA,
          (object) RESIM,
          (object) MALZEME_KODU,
          (object) MALZEME_ADI,
          (object) URETICIKODU,
          (object) MARKA,
          (object) GRUPKODU,
          (object) TEDARIKCI,
          (object) ANAKATEGORI,
          (object) ALTKATEGORI,
          (object) KRESIM,
          (object) RESIM1,
          (object) RESIM2,
          (object) RESIM3,
          (object) KDVTUTARI,
          (object) NETTOPLAM
        };
        row.ItemArray = objArray;
        this.Rows.Add((DataRow) row);
        return row;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public override DataTable Clone()
      {
        siparis.SIPARISLERDataTable siparislerDataTable = (siparis.SIPARISLERDataTable) base.Clone();
        siparislerDataTable.InitVars();
        return (DataTable) siparislerDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override DataTable CreateInstance()
      {
        return (DataTable) new siparis.SIPARISLERDataTable();
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      internal void InitVars()
      {
        this.columnSIPARISTARIHI = this.Columns["SIPARISTARIHI"];
        this.columnSIPARISSAATI = this.Columns["SIPARISSAATI"];
        this.columnSIPARISNO = this.Columns["SIPARISNO"];
        this.columnACIKLAMA = this.Columns["ACIKLAMA"];
        this.columnODEMESEKLI = this.Columns["ODEMESEKLI"];
        this.columnSATIRTURU = this.Columns["SATIRTURU"];
        this.columnSATIRNO = this.Columns["SATIRNO"];
        this.columnBIRIM = this.Columns["BIRIM"];
        this.columnMIKTAR = this.Columns["MIKTAR"];
        this.columnBIRIMFIYAT = this.Columns["BIRIMFIYAT"];
        this.columnTUTAR = this.Columns["TUTAR"];
        this.columnINDIRIMORANI1 = this.Columns["INDIRIMORANI1"];
        this.columnINDIRIMORANI2 = this.Columns["INDIRIMORANI2"];
        this.columnINDIRIMTUTARI = this.Columns["INDIRIMTUTARI"];
        this.columnNETTUTAR = this.Columns["NETTUTAR"];
        this.columnSATIRACIKLAMA = this.Columns["SATIRACIKLAMA"];
        this.columnTESLIMTARIHI = this.Columns["TESLIMTARIHI"];
        this.columnFIRMAKODU = this.Columns["FIRMAKODU"];
        this.columnFIRMAADI = this.Columns["FIRMAADI"];
        this.columnYETKILI = this.Columns["YETKILI"];
        this.columnTELEFON1 = this.Columns["TELEFON1"];
        this.columnTELEFON2 = this.Columns["TELEFON2"];
        this.columnILCE = this.Columns["ILCE"];
        this.columnIL = this.Columns["IL"];
        this.columnTEDARIKCIKODU = this.Columns["TEDARIKCIKODU"];
        this.columnTEDARIKCIADI = this.Columns["TEDARIKCIADI"];
        this.columnTEDARIKCILOGOSU = this.Columns["TEDARIKCILOGOSU"];
        this.columnADI = this.Columns["ADI"];
        this.columnSOYADI = this.Columns["SOYADI"];
        this.columnEPOSTA = this.Columns["EPOSTA"];
        this.columnRESIM = this.Columns["RESIM"];
        this.columnMALZEME_KODU = this.Columns["MALZEME KODU"];
        this.columnMALZEME_ADI = this.Columns["MALZEME ADI"];
        this.columnURETICIKODU = this.Columns["URETICIKODU"];
        this.columnMARKA = this.Columns["MARKA"];
        this.columnGRUPKODU = this.Columns["GRUPKODU"];
        this.columnTEDARIKCI = this.Columns["TEDARIKCI"];
        this.columnANAKATEGORI = this.Columns["ANAKATEGORI"];
        this.columnALTKATEGORI = this.Columns["ALTKATEGORI"];
        this.columnKRESIM = this.Columns["KRESIM"];
        this.columnRESIM1 = this.Columns["RESIM1"];
        this.columnRESIM2 = this.Columns["RESIM2"];
        this.columnRESIM3 = this.Columns["RESIM3"];
        this.columnKDVTUTARI = this.Columns["KDVTUTARI"];
        this.columnNETTOPLAM = this.Columns["NETTOPLAM"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      private void InitClass()
      {
        this.columnSIPARISTARIHI = new DataColumn("SIPARISTARIHI", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSIPARISTARIHI);
        this.columnSIPARISSAATI = new DataColumn("SIPARISSAATI", typeof (TimeSpan), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSIPARISSAATI);
        this.columnSIPARISNO = new DataColumn("SIPARISNO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSIPARISNO);
        this.columnACIKLAMA = new DataColumn("ACIKLAMA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnACIKLAMA);
        this.columnODEMESEKLI = new DataColumn("ODEMESEKLI", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnODEMESEKLI);
        this.columnSATIRTURU = new DataColumn("SATIRTURU", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSATIRTURU);
        this.columnSATIRNO = new DataColumn("SATIRNO", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSATIRNO);
        this.columnBIRIM = new DataColumn("BIRIM", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnBIRIM);
        this.columnMIKTAR = new DataColumn("MIKTAR", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMIKTAR);
        this.columnBIRIMFIYAT = new DataColumn("BIRIMFIYAT", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnBIRIMFIYAT);
        this.columnTUTAR = new DataColumn("TUTAR", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTUTAR);
        this.columnINDIRIMORANI1 = new DataColumn("INDIRIMORANI1", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnINDIRIMORANI1);
        this.columnINDIRIMORANI2 = new DataColumn("INDIRIMORANI2", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnINDIRIMORANI2);
        this.columnINDIRIMTUTARI = new DataColumn("INDIRIMTUTARI", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnINDIRIMTUTARI);
        this.columnNETTUTAR = new DataColumn("NETTUTAR", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNETTUTAR);
        this.columnSATIRACIKLAMA = new DataColumn("SATIRACIKLAMA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSATIRACIKLAMA);
        this.columnTESLIMTARIHI = new DataColumn("TESLIMTARIHI", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTESLIMTARIHI);
        this.columnFIRMAKODU = new DataColumn("FIRMAKODU", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFIRMAKODU);
        this.columnFIRMAADI = new DataColumn("FIRMAADI", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFIRMAADI);
        this.columnYETKILI = new DataColumn("YETKILI", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnYETKILI);
        this.columnTELEFON1 = new DataColumn("TELEFON1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTELEFON1);
        this.columnTELEFON2 = new DataColumn("TELEFON2", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTELEFON2);
        this.columnILCE = new DataColumn("ILCE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnILCE);
        this.columnIL = new DataColumn("IL", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIL);
        this.columnTEDARIKCIKODU = new DataColumn("TEDARIKCIKODU", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTEDARIKCIKODU);
        this.columnTEDARIKCIADI = new DataColumn("TEDARIKCIADI", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTEDARIKCIADI);
        this.columnTEDARIKCILOGOSU = new DataColumn("TEDARIKCILOGOSU", typeof (byte[]), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTEDARIKCILOGOSU);
        this.columnADI = new DataColumn("ADI", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnADI);
        this.columnSOYADI = new DataColumn("SOYADI", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSOYADI);
        this.columnEPOSTA = new DataColumn("EPOSTA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEPOSTA);
        this.columnRESIM = new DataColumn("RESIM", typeof (byte[]), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRESIM);
        this.columnMALZEME_KODU = new DataColumn("MALZEME KODU", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMALZEME_KODU);
        this.columnMALZEME_ADI = new DataColumn("MALZEME ADI", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMALZEME_ADI);
        this.columnURETICIKODU = new DataColumn("URETICIKODU", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnURETICIKODU);
        this.columnMARKA = new DataColumn("MARKA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMARKA);
        this.columnGRUPKODU = new DataColumn("GRUPKODU", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnGRUPKODU);
        this.columnTEDARIKCI = new DataColumn("TEDARIKCI", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTEDARIKCI);
        this.columnANAKATEGORI = new DataColumn("ANAKATEGORI", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnANAKATEGORI);
        this.columnALTKATEGORI = new DataColumn("ALTKATEGORI", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnALTKATEGORI);
        this.columnKRESIM = new DataColumn("KRESIM", typeof (byte[]), (string) null, MappingType.Element);
        this.Columns.Add(this.columnKRESIM);
        this.columnRESIM1 = new DataColumn("RESIM1", typeof (byte[]), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRESIM1);
        this.columnRESIM2 = new DataColumn("RESIM2", typeof (byte[]), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRESIM2);
        this.columnRESIM3 = new DataColumn("RESIM3", typeof (byte[]), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRESIM3);
        this.columnKDVTUTARI = new DataColumn("KDVTUTARI", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnKDVTUTARI);
        this.columnNETTOPLAM = new DataColumn("NETTOPLAM", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNETTOPLAM);
        this.columnSIPARISNO.MaxLength = 50;
        this.columnACIKLAMA.MaxLength = 200;
        this.columnODEMESEKLI.MaxLength = 50;
        this.columnSATIRTURU.MaxLength = 50;
        this.columnBIRIM.MaxLength = 50;
        this.columnSATIRACIKLAMA.MaxLength = 200;
        this.columnFIRMAKODU.MaxLength = 50;
        this.columnFIRMAADI.MaxLength = 150;
        this.columnYETKILI.MaxLength = 50;
        this.columnTELEFON1.MaxLength = 50;
        this.columnTELEFON2.MaxLength = 50;
        this.columnILCE.MaxLength = 50;
        this.columnIL.MaxLength = 50;
        this.columnTEDARIKCIKODU.MaxLength = 50;
        this.columnTEDARIKCIADI.MaxLength = 50;
        this.columnADI.MaxLength = 50;
        this.columnSOYADI.MaxLength = 50;
        this.columnEPOSTA.MaxLength = 50;
        this.columnMALZEME_KODU.MaxLength = 50;
        this.columnMALZEME_ADI.MaxLength = 150;
        this.columnURETICIKODU.MaxLength = 50;
        this.columnMARKA.MaxLength = 50;
        this.columnGRUPKODU.MaxLength = 50;
        this.columnTEDARIKCI.MaxLength = 50;
        this.columnANAKATEGORI.MaxLength = 50;
        this.columnALTKATEGORI.MaxLength = 50;
        this.columnNETTOPLAM.ReadOnly = true;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public siparis.SIPARISLERRow NewSIPARISLERRow() => (siparis.SIPARISLERRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
      {
        return (DataRow) new siparis.SIPARISLERRow(builder);
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      protected override Type GetRowType() => typeof (siparis.SIPARISLERRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.SIPARISLERRowChanged == null)
          return;
        this.SIPARISLERRowChanged((object) this, new siparis.SIPARISLERRowChangeEvent((siparis.SIPARISLERRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.SIPARISLERRowChanging == null)
          return;
        this.SIPARISLERRowChanging((object) this, new siparis.SIPARISLERRowChangeEvent((siparis.SIPARISLERRow) e.Row, e.Action));
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.SIPARISLERRowDeleted == null)
          return;
        this.SIPARISLERRowDeleted((object) this, new siparis.SIPARISLERRowChangeEvent((siparis.SIPARISLERRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.SIPARISLERRowDeleting == null)
          return;
        this.SIPARISLERRowDeleting((object) this, new siparis.SIPARISLERRowChangeEvent((siparis.SIPARISLERRow) e.Row, e.Action));
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void RemoveSIPARISLERRow(siparis.SIPARISLERRow row) => this.Rows.Remove((DataRow) row);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType typedTableSchema = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        siparis siparis = new siparis();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = 0M;
        xmlSchemaAny1.MaxOccurs = Decimal.MaxValue;
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = 1M;
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        typedTableSchema.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = siparis.Namespace
        });
        typedTableSchema.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (SIPARISLERDataTable)
        });
        typedTableSchema.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = siparis.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return typedTableSchema;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return typedTableSchema;
      }
    }

    public class SIPARISLERRow : DataRow
    {
      private siparis.SIPARISLERDataTable tableSIPARISLER;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      internal SIPARISLERRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tableSIPARISLER = (siparis.SIPARISLERDataTable) this.Table;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DateTime SIPARISTARIHI
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableSIPARISLER.SIPARISTARIHIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'SIPARISTARIHI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.SIPARISTARIHIColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public TimeSpan SIPARISSAATI
      {
        get
        {
          try
          {
            return (TimeSpan) this[this.tableSIPARISLER.SIPARISSAATIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'SIPARISSAATI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.SIPARISSAATIColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string SIPARISNO
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.SIPARISNOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'SIPARISNO' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.SIPARISNOColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string ACIKLAMA
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.ACIKLAMAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ACIKLAMA' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.ACIKLAMAColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string ODEMESEKLI
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.ODEMESEKLIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ODEMESEKLI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.ODEMESEKLIColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string SATIRTURU
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.SATIRTURUColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'SATIRTURU' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.SATIRTURUColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public int SATIRNO
      {
        get
        {
          try
          {
            return (int) this[this.tableSIPARISLER.SATIRNOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'SATIRNO' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.SATIRNOColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string BIRIM
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.BIRIMColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'BIRIM' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.BIRIMColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public double MIKTAR
      {
        get
        {
          try
          {
            return (double) this[this.tableSIPARISLER.MIKTARColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'MIKTAR' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.MIKTARColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public double BIRIMFIYAT
      {
        get
        {
          try
          {
            return (double) this[this.tableSIPARISLER.BIRIMFIYATColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'BIRIMFIYAT' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.BIRIMFIYATColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public double TUTAR
      {
        get
        {
          try
          {
            return (double) this[this.tableSIPARISLER.TUTARColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TUTAR' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.TUTARColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public double INDIRIMORANI1
      {
        get
        {
          try
          {
            return (double) this[this.tableSIPARISLER.INDIRIMORANI1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'INDIRIMORANI1' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.INDIRIMORANI1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public double INDIRIMORANI2
      {
        get
        {
          try
          {
            return (double) this[this.tableSIPARISLER.INDIRIMORANI2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'INDIRIMORANI2' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.INDIRIMORANI2Column] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public double INDIRIMTUTARI
      {
        get
        {
          try
          {
            return (double) this[this.tableSIPARISLER.INDIRIMTUTARIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'INDIRIMTUTARI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.INDIRIMTUTARIColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public double NETTUTAR
      {
        get
        {
          try
          {
            return (double) this[this.tableSIPARISLER.NETTUTARColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'NETTUTAR' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.NETTUTARColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string SATIRACIKLAMA
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.SATIRACIKLAMAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'SATIRACIKLAMA' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.SATIRACIKLAMAColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DateTime TESLIMTARIHI
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableSIPARISLER.TESLIMTARIHIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TESLIMTARIHI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.TESLIMTARIHIColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string FIRMAKODU
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.FIRMAKODUColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FIRMAKODU' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.FIRMAKODUColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string FIRMAADI
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.FIRMAADIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FIRMAADI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.FIRMAADIColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string YETKILI
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.YETKILIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'YETKILI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.YETKILIColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string TELEFON1
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.TELEFON1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TELEFON1' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.TELEFON1Column] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string TELEFON2
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.TELEFON2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TELEFON2' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.TELEFON2Column] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string ILCE
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.ILCEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ILCE' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.ILCEColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string IL
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.ILColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'IL' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.ILColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string TEDARIKCIKODU
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.TEDARIKCIKODUColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TEDARIKCIKODU' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.TEDARIKCIKODUColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string TEDARIKCIADI
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.TEDARIKCIADIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TEDARIKCIADI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.TEDARIKCIADIColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public byte[] TEDARIKCILOGOSU
      {
        get
        {
          try
          {
            return (byte[]) this[this.tableSIPARISLER.TEDARIKCILOGOSUColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TEDARIKCILOGOSU' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.TEDARIKCILOGOSUColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string ADI
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.ADIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ADI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.ADIColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string SOYADI
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.SOYADIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'SOYADI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.SOYADIColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string EPOSTA
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.EPOSTAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'EPOSTA' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.EPOSTAColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public byte[] RESIM
      {
        get
        {
          try
          {
            return (byte[]) this[this.tableSIPARISLER.RESIMColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'RESIM' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.RESIMColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string MALZEME_KODU
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.MALZEME_KODUColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'MALZEME KODU' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.MALZEME_KODUColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string MALZEME_ADI
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.MALZEME_ADIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'MALZEME ADI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.MALZEME_ADIColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string URETICIKODU
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.URETICIKODUColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'URETICIKODU' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.URETICIKODUColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string MARKA
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.MARKAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'MARKA' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.MARKAColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string GRUPKODU
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.GRUPKODUColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'GRUPKODU' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.GRUPKODUColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string TEDARIKCI
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.TEDARIKCIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TEDARIKCI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.TEDARIKCIColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string ANAKATEGORI
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.ANAKATEGORIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ANAKATEGORI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.ANAKATEGORIColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public string ALTKATEGORI
      {
        get
        {
          try
          {
            return (string) this[this.tableSIPARISLER.ALTKATEGORIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ALTKATEGORI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.ALTKATEGORIColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public byte[] KRESIM
      {
        get
        {
          try
          {
            return (byte[]) this[this.tableSIPARISLER.KRESIMColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'KRESIM' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.KRESIMColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public byte[] RESIM1
      {
        get
        {
          try
          {
            return (byte[]) this[this.tableSIPARISLER.RESIM1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'RESIM1' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.RESIM1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public byte[] RESIM2
      {
        get
        {
          try
          {
            return (byte[]) this[this.tableSIPARISLER.RESIM2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'RESIM2' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.RESIM2Column] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public byte[] RESIM3
      {
        get
        {
          try
          {
            return (byte[]) this[this.tableSIPARISLER.RESIM3Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'RESIM3' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.RESIM3Column] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public double KDVTUTARI
      {
        get
        {
          try
          {
            return (double) this[this.tableSIPARISLER.KDVTUTARIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'KDVTUTARI' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.KDVTUTARIColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public double NETTOPLAM
      {
        get
        {
          try
          {
            return (double) this[this.tableSIPARISLER.NETTOPLAMColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'NETTOPLAM' in table 'SIPARISLER' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSIPARISLER.NETTOPLAMColumn] = (object) value;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsSIPARISTARIHINull() => this.IsNull(this.tableSIPARISLER.SIPARISTARIHIColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetSIPARISTARIHINull()
      {
        this[this.tableSIPARISLER.SIPARISTARIHIColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsSIPARISSAATINull() => this.IsNull(this.tableSIPARISLER.SIPARISSAATIColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetSIPARISSAATINull()
      {
        this[this.tableSIPARISLER.SIPARISSAATIColumn] = Convert.DBNull;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsSIPARISNONull() => this.IsNull(this.tableSIPARISLER.SIPARISNOColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetSIPARISNONull() => this[this.tableSIPARISLER.SIPARISNOColumn] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsACIKLAMANull() => this.IsNull(this.tableSIPARISLER.ACIKLAMAColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetACIKLAMANull() => this[this.tableSIPARISLER.ACIKLAMAColumn] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsODEMESEKLINull() => this.IsNull(this.tableSIPARISLER.ODEMESEKLIColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetODEMESEKLINull()
      {
        this[this.tableSIPARISLER.ODEMESEKLIColumn] = Convert.DBNull;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsSATIRTURUNull() => this.IsNull(this.tableSIPARISLER.SATIRTURUColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetSATIRTURUNull() => this[this.tableSIPARISLER.SATIRTURUColumn] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsSATIRNONull() => this.IsNull(this.tableSIPARISLER.SATIRNOColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetSATIRNONull() => this[this.tableSIPARISLER.SATIRNOColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsBIRIMNull() => this.IsNull(this.tableSIPARISLER.BIRIMColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetBIRIMNull() => this[this.tableSIPARISLER.BIRIMColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsMIKTARNull() => this.IsNull(this.tableSIPARISLER.MIKTARColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetMIKTARNull() => this[this.tableSIPARISLER.MIKTARColumn] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsBIRIMFIYATNull() => this.IsNull(this.tableSIPARISLER.BIRIMFIYATColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetBIRIMFIYATNull()
      {
        this[this.tableSIPARISLER.BIRIMFIYATColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsTUTARNull() => this.IsNull(this.tableSIPARISLER.TUTARColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetTUTARNull() => this[this.tableSIPARISLER.TUTARColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsINDIRIMORANI1Null() => this.IsNull(this.tableSIPARISLER.INDIRIMORANI1Column);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetINDIRIMORANI1Null()
      {
        this[this.tableSIPARISLER.INDIRIMORANI1Column] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsINDIRIMORANI2Null() => this.IsNull(this.tableSIPARISLER.INDIRIMORANI2Column);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetINDIRIMORANI2Null()
      {
        this[this.tableSIPARISLER.INDIRIMORANI2Column] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsINDIRIMTUTARINull() => this.IsNull(this.tableSIPARISLER.INDIRIMTUTARIColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetINDIRIMTUTARINull()
      {
        this[this.tableSIPARISLER.INDIRIMTUTARIColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsNETTUTARNull() => this.IsNull(this.tableSIPARISLER.NETTUTARColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetNETTUTARNull() => this[this.tableSIPARISLER.NETTUTARColumn] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsSATIRACIKLAMANull() => this.IsNull(this.tableSIPARISLER.SATIRACIKLAMAColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetSATIRACIKLAMANull()
      {
        this[this.tableSIPARISLER.SATIRACIKLAMAColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsTESLIMTARIHINull() => this.IsNull(this.tableSIPARISLER.TESLIMTARIHIColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetTESLIMTARIHINull()
      {
        this[this.tableSIPARISLER.TESLIMTARIHIColumn] = Convert.DBNull;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsFIRMAKODUNull() => this.IsNull(this.tableSIPARISLER.FIRMAKODUColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetFIRMAKODUNull() => this[this.tableSIPARISLER.FIRMAKODUColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsFIRMAADINull() => this.IsNull(this.tableSIPARISLER.FIRMAADIColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetFIRMAADINull() => this[this.tableSIPARISLER.FIRMAADIColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsYETKILINull() => this.IsNull(this.tableSIPARISLER.YETKILIColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetYETKILINull() => this[this.tableSIPARISLER.YETKILIColumn] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsTELEFON1Null() => this.IsNull(this.tableSIPARISLER.TELEFON1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetTELEFON1Null() => this[this.tableSIPARISLER.TELEFON1Column] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsTELEFON2Null() => this.IsNull(this.tableSIPARISLER.TELEFON2Column);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetTELEFON2Null() => this[this.tableSIPARISLER.TELEFON2Column] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsILCENull() => this.IsNull(this.tableSIPARISLER.ILCEColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetILCENull() => this[this.tableSIPARISLER.ILCEColumn] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsILNull() => this.IsNull(this.tableSIPARISLER.ILColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetILNull() => this[this.tableSIPARISLER.ILColumn] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsTEDARIKCIKODUNull() => this.IsNull(this.tableSIPARISLER.TEDARIKCIKODUColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetTEDARIKCIKODUNull()
      {
        this[this.tableSIPARISLER.TEDARIKCIKODUColumn] = Convert.DBNull;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsTEDARIKCIADINull() => this.IsNull(this.tableSIPARISLER.TEDARIKCIADIColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetTEDARIKCIADINull()
      {
        this[this.tableSIPARISLER.TEDARIKCIADIColumn] = Convert.DBNull;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsTEDARIKCILOGOSUNull()
      {
        return this.IsNull(this.tableSIPARISLER.TEDARIKCILOGOSUColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetTEDARIKCILOGOSUNull()
      {
        this[this.tableSIPARISLER.TEDARIKCILOGOSUColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsADINull() => this.IsNull(this.tableSIPARISLER.ADIColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetADINull() => this[this.tableSIPARISLER.ADIColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsSOYADINull() => this.IsNull(this.tableSIPARISLER.SOYADIColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetSOYADINull() => this[this.tableSIPARISLER.SOYADIColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsEPOSTANull() => this.IsNull(this.tableSIPARISLER.EPOSTAColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetEPOSTANull() => this[this.tableSIPARISLER.EPOSTAColumn] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsRESIMNull() => this.IsNull(this.tableSIPARISLER.RESIMColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetRESIMNull() => this[this.tableSIPARISLER.RESIMColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsMALZEME_KODUNull() => this.IsNull(this.tableSIPARISLER.MALZEME_KODUColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetMALZEME_KODUNull()
      {
        this[this.tableSIPARISLER.MALZEME_KODUColumn] = Convert.DBNull;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsMALZEME_ADINull() => this.IsNull(this.tableSIPARISLER.MALZEME_ADIColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetMALZEME_ADINull()
      {
        this[this.tableSIPARISLER.MALZEME_ADIColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsURETICIKODUNull() => this.IsNull(this.tableSIPARISLER.URETICIKODUColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetURETICIKODUNull()
      {
        this[this.tableSIPARISLER.URETICIKODUColumn] = Convert.DBNull;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsMARKANull() => this.IsNull(this.tableSIPARISLER.MARKAColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetMARKANull() => this[this.tableSIPARISLER.MARKAColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsGRUPKODUNull() => this.IsNull(this.tableSIPARISLER.GRUPKODUColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetGRUPKODUNull() => this[this.tableSIPARISLER.GRUPKODUColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsTEDARIKCINull() => this.IsNull(this.tableSIPARISLER.TEDARIKCIColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetTEDARIKCINull() => this[this.tableSIPARISLER.TEDARIKCIColumn] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsANAKATEGORINull() => this.IsNull(this.tableSIPARISLER.ANAKATEGORIColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetANAKATEGORINull()
      {
        this[this.tableSIPARISLER.ANAKATEGORIColumn] = Convert.DBNull;
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsALTKATEGORINull() => this.IsNull(this.tableSIPARISLER.ALTKATEGORIColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetALTKATEGORINull()
      {
        this[this.tableSIPARISLER.ALTKATEGORIColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsKRESIMNull() => this.IsNull(this.tableSIPARISLER.KRESIMColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetKRESIMNull() => this[this.tableSIPARISLER.KRESIMColumn] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsRESIM1Null() => this.IsNull(this.tableSIPARISLER.RESIM1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetRESIM1Null() => this[this.tableSIPARISLER.RESIM1Column] = Convert.DBNull;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public bool IsRESIM2Null() => this.IsNull(this.tableSIPARISLER.RESIM2Column);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetRESIM2Null() => this[this.tableSIPARISLER.RESIM2Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsRESIM3Null() => this.IsNull(this.tableSIPARISLER.RESIM3Column);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetRESIM3Null() => this[this.tableSIPARISLER.RESIM3Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsKDVTUTARINull() => this.IsNull(this.tableSIPARISLER.KDVTUTARIColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetKDVTUTARINull() => this[this.tableSIPARISLER.KDVTUTARIColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsNETTOPLAMNull() => this.IsNull(this.tableSIPARISLER.NETTOPLAMColumn);

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public void SetNETTOPLAMNull() => this[this.tableSIPARISLER.NETTOPLAMColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public class SIPARISLERRowChangeEvent : EventArgs
    {
      private siparis.SIPARISLERRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public SIPARISLERRowChangeEvent(siparis.SIPARISLERRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public siparis.SIPARISLERRow Row => this.eventRow;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [DebuggerNonUserCode]
      public DataRowAction Action => this.eventAction;
    }
  }
}
