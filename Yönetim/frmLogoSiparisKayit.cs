// Decompiled with JetBrains decompiler
// Type: Yönetim.frmLogoSiparisKayit
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Yönetim.Properties;

#nullable disable
namespace Yönetim
{
  public class frmLogoSiparisKayit : Form
  {
    private string oku_DONEM = "";
    private string oku_FIRMA = "";
    private string oku_FIRMADONEM = "";
    private int SonRecNo = 0;
    private int CariRecno = 0;
    private int CariMuhasebeRec = 0;
    private IContainer components = (IContainer) null;
    private GroupControl groupControl1;
    private Label label7;
    private Label label8;
    private Label label5;
    private System.Windows.Forms.ProgressBar progressBar1;
    private Button button1;
    private TextBox txtServerAdi;
    private TextBox txtKullaniciAdi;
    private TextBox txtDatabase;
    private TextBox txtSifre;
    private Label label10;
    private Label label3;
    private Label label2;
    private Label label1;
    private System.Windows.Forms.ComboBox cmbLogoFirma;
    private Label label4;
    private Button button2;
    private System.Windows.Forms.ProgressBar progressBar2;
    private System.Windows.Forms.ComboBox CMBEUROSIRKET;
    private Label label9;
    private System.Windows.Forms.ComboBox CMBUSDSIRKET;
    private Label label6;
    private Label label11;
    private TextBox txtEvrakSeri;

    public frmLogoSiparisKayit() => this.InitializeComponent();

    private void BaslikAktar(
      string Fisno,
      string CariKod,
      double ToplamKdv,
      double GenelToplam,
      double KdvMatrahı,
      string Alt)
    {
      this.LogoBaglan();
      this.SonRecNo = DBManager.sqlGetScalarValue(new SqlCommand("SELECT LASTLREF FROM LG_" + this.oku_FIRMADONEM + "_ORFICHESEQ"));
      DBManager.sqlRunCommand(new SqlCommand("UPDATE LG_" + this.oku_FIRMADONEM + "_ORFICHESEQ SET LASTLREF=LASTLREF+1"));
      this.CariRecno = DBManager.sqlGetScalarValue(new SqlCommand("SELECT LOGICALREF FROM LG_" + this.oku_FIRMA + "_CLCARD WHERE CODE='" + CariKod + "'"));
      this.CariMuhasebeRec = DBManager.sqlGetScalarValue(new SqlCommand("SELECT ACCOUNTREF FROM LG_" + this.oku_FIRMA + "_CRDACREF WHERE CARDREF=" + (object) this.CariRecno));
      SqlCommand mCommand = new SqlCommand();
      mCommand.CommandText = "DELETE FROM LG_" + this.oku_FIRMADONEM + "_ORFICHE WHERE TRCODE=1 AND FICHENO='" + Fisno + "' AND CLIENTREF=" + (object) this.CariRecno;
      DBManager.sqlRunCommand(mCommand);
      mCommand.CommandText = "INSERT INTO LG_" + this.oku_FIRMADONEM + "_ORFICHE\r\n                                    (\r\n                                    LOGICALREF,\r\n                                    TRCODE,\r\n                                    FICHENO,\r\n                                    DATE_,\r\n                                    TIME_,\r\n                                    DOCODE,\r\n                                    SPECODE,\r\n                                    CYPHCODE,\r\n                                    CLIENTREF,\r\n                                    RECVREF,\r\n                                    ACCOUNTREF,\r\n                                    CENTERREF,\r\n                                    SOURCEINDEX,\r\n                                    SOURCECOSTGRP,\r\n                                    UPDCURR,\r\n                                    ADDDISCOUNTS,\r\n                                    TOTALDISCOUNTS,\r\n                                    TOTALDISCOUNTED,\r\n                                    ADDEXPENSES,\r\n                                    TOTALEXPENSES,\r\n                                    TOTALPROMOTIONS,\r\n                                    TOTALVAT,\r\n                                    GROSSTOTAL,\r\n                                    NETTOTAL,\r\n                                    REPORTRATE,\r\n                                    REPORTNET,\r\n                                    GENEXP1,\r\n                                    GENEXP2,\r\n                                    GENEXP3,\r\n                                    GENEXP4,\r\n                                    EXTENREF,\r\n                                    PAYDEFREF,\r\n                                    PRINTCNT,\r\n                                    BRANCH,\r\n                                    DEPARTMENT,\r\n                                    STATUS,\r\n                                    SALESMANREF,\r\n                                    SHPTYPCOD,\r\n                                    SHPAGNCOD,\r\n                                    GENEXCTYP,\r\n                                    LINEEXCTYP,\r\n                                    TRADINGGRP,\r\n                                    TEXTINC,\r\n                                    SITEID,\r\n                                    RECSTATUS,\r\n                                    ORGLOGICREF,\r\n                                    FACTORYNR,\r\n                                    WFSTATUS,\r\n                                    SHIPINFOREF,\r\n                                    CUSTORDNO,\r\n                                    SENDCNT,\r\n                                    DLVCLIENT,\r\n                                    DOCTRACKINGNR,\r\n                                    CANCELLED,\r\n                                    ORGLOGOID,\r\n                                    OFFERREF,\r\n                                    OFFALTREF,\r\n                                    TYP,\r\n                                    ALTNR,\r\n                                    ADVANCEPAYM,\r\n                                    TRCURR,\r\n                                    TRRATE,\r\n                                    TRNET,\r\n                                    PAYMENTTYPE,\r\n                                    ONLYONEPAYLINE,\r\n                                    OPSTAT,\r\n                                    WITHPAYTRANS,\r\n                                    PROJECTREF,\r\n                                    WFLOWCRDREF,\r\n                                    UPDTRCURR,\r\n                                    AFFECTCOLLATRL,\r\n                                    POFFERBEGDT,\r\n                                    POFFERENDDT,\r\n                                    REVISNR,\r\n                                    LASTREVISION,\r\n                                    CHECKAMOUNT,\r\n                                    SLSOPPRREF,\r\n                                    SLSACTREF,\r\n                                    SLSCUSTREF,\r\n                                    AFFECTRISK,\r\n                                    TOTALADDTAX,\r\n                                    TOTALEXADDTAX,\r\n                                    APPROVEDATE,\r\n                                    APPROVE\r\n                                    )\r\n                                    VALUES\r\n                                    (\r\n                                    " + (object) this.SonRecNo + ",--LOGICALREF\r\n                                    '1',--TRCODE\r\n                                    '" + Fisno + "',--FICHENO\r\n                                    convert(datetime,getdate(),103),--DATE_\r\n                                    '203948071',--TIME_\r\n                                    '" + Alt + "',--DOCODE\r\n                                    '',--SPECODE\r\n                                    '',--CYPHCODE\r\n                                    " + (object) this.CariRecno + ",--CLIENTREF\r\n                                    '0',--RECVREF\r\n                                    " + (object) this.CariMuhasebeRec + ",--ACCOUNTREF\r\n                                    '0',--CENTERREF\r\n                                    '0',--SOURCEINDEX\r\n                                    '0',--SOURCECOSTGRP\r\n                                    '0',--UPDCURR\r\n                                    '0',--ADDDISCOUNTS\r\n                                    '0',--TOTALDISCOUNTS\r\n                                    '0',--TOTALDISCOUNTED\r\n                                    '0',--ADDEXPENSES\r\n                                    '0',--TOTALEXPENSES\r\n                                    '0',--TOTALPROMOTIONS\r\n                                    " + Convert.ToString(ToplamKdv).Replace(',', '.') + ",--TOTALVAT\r\n                                    " + Convert.ToString(KdvMatrahı).Replace(',', '.') + ",--GROSSTOTAL\r\n                                    " + Convert.ToString(GenelToplam).Replace(',', '.') + ",--NETTOTAL\r\n                                    '1',--REPORTRATE\r\n                                    '0',--REPORTNET\r\n                                    '',--GENEXP1\r\n                                    '',--GENEXP2\r\n                                    '',--GENEXP3\r\n                                    '',--GENEXP4\r\n                                    '0',--EXTENREF\r\n                                    '0',--PAYDEFREF\r\n                                    '0',--PRINTCNT\r\n                                    '0',--BRANCH\r\n                                    '0',--DEPARTMENT\r\n                                    '4',--STATUS\r\n                                    '0',--SALESMANREF\r\n                                    '',--SHPTYPCOD\r\n                                    '',--SHPAGNCOD\r\n                                    '2',--GENEXCTYP\r\n                                    '0',--LINEEXCTYP\r\n                                    '',--TRADINGGRP\r\n                                    '0',--TEXTINC\r\n                                    '0',--SITEID\r\n                                    '2',--RECSTATUS\r\n                                    '0',--ORGLOGICREF\r\n                                    '0',--FACTORYNR\r\n                                    '0',--WFSTATUS\r\n                                    '0',--SHIPINFOREF\r\n                                    '',--CUSTORDNO\r\n                                    '0',--SENDCNT\r\n                                    '0',--DLVCLIENT\r\n                                    '',--DOCTRACKINGNR\r\n                                    '0',--CANCELLED\r\n                                    '',--ORGLOGOID\r\n                                    '0',--OFFERREF\r\n                                    '0',--OFFALTREF\r\n                                    '0',--TYP\r\n                                    '0',--ALTNR\r\n                                    '0',--ADVANCEPAYM\r\n                                    '0',--TRCURR\r\n                                    '0',--TRRATE\r\n                                    '0',--TRNET\r\n                                    '0',--PAYMENTTYPE\r\n                                    '0',--ONLYONEPAYLINE\r\n                                    '0',--OPSTAT\r\n                                    '0',--WITHPAYTRANS\r\n                                    '0',--PROJECTREF\r\n                                    '0',--WFLOWCRDREF\r\n                                    '0',--UPDTRCURR\r\n                                    '0',--AFFECTCOLLATRL\r\n                                    '',--POFFERBEGDT\r\n                                    '',--POFFERENDDT\r\n                                    '',--REVISNR\r\n                                    '0',--LASTREVISION\r\n                                    '0',--CHECKAMOUNT\r\n                                    '0',--SLSOPPRREF\r\n                                    '0',--SLSACTREF\r\n                                    '0',--SLSCUSTREF\r\n                                    '1',--AFFECTRISK\r\n                                    '0',--TOTALADDTAX\r\n                                    '0',--TOTALEXADDTAX\r\n                                    '',--APPROVEDATE\r\n                                    ''--APPROVE\r\n                                    )";
      DBManager.sqlRunCommand(mCommand);
    }

    private void BaslikDetay(
      int RECNO,
      string StokKod,
      double Miktar,
      double BirimFiyat,
      string _RecNoo,
      string StokIsim)
    {
      this.LogoBaglan();
      if (!(StokKod != ""))
        return;
      int scalarValue1 = DBManager.sqlGetScalarValue(new SqlCommand("SELECT LOGICALREF FROM LG_" + this.oku_FIRMA + "_ITEMS WHERE CODE='" + StokKod + "'"));
      if (scalarValue1 == 0)
      {
        int num = (int) MessageBox.Show(StokKod + " - " + StokIsim + " Nolu Kart Bulunamad. Stok Kartını Logo Acınız Sonra Tamam'a Basınız.", "Barkod Bilisim");
        scalarValue1 = DBManager.sqlGetScalarValue(new SqlCommand("SELECT LOGICALREF FROM LG_" + this.oku_FIRMA + "_ITEMS WHERE CODE='" + StokKod + "'"));
      }
      if (scalarValue1 == 0)
      {
        int num = (int) MessageBox.Show(StokKod + " - " + StokIsim + "  Nolu Kart Bulunamad. Stok Kartını Logo Acınız Sonra Tamam'a Basınız.", "Barkod Bilisim");
        scalarValue1 = DBManager.sqlGetScalarValue(new SqlCommand("SELECT LOGICALREF FROM LG_" + this.oku_FIRMA + "_ITEMS WHERE CODE='" + StokKod + "'"));
      }
      int scalarValue2 = DBManager.sqlGetScalarValue(new SqlCommand("SELECT VAT FROM LG_" + this.oku_FIRMA + "_ITEMS WHERE LOGICALREF=" + (object) scalarValue1));
      int scalarValue3 = DBManager.sqlGetScalarValue(new SqlCommand("SELECT UNITSETREF FROM LG_" + this.oku_FIRMA + "_ITEMS WHERE LOGICALREF=" + (object) scalarValue1));
      int scalarValue4 = DBManager.sqlGetScalarValue(new SqlCommand("SELECT TOP 1 LOGICALREF FROM LG_" + this.oku_FIRMA + "_UNITSETL WHERE UNITSETREF=" + scalarValue3.ToString()));
      int scalarValue5 = DBManager.sqlGetScalarValue(new SqlCommand("SELECT LASTLREF+1 FROM LG_" + this.oku_FIRMADONEM + "_ORFLINESEQ"));
      DBManager.sqlRunCommand(new SqlCommand("UPDATE LG_" + this.oku_FIRMADONEM + "_ORFLINESEQ SET LASTLREF=LASTLREF+1"));
      this.CariMuhasebeRec = DBManager.sqlGetScalarValue(new SqlCommand("SELECT ACCOUNTREF FROM LG_" + this.oku_FIRMA + "_CRDACREF WHERE CARDREF=" + (object) this.CariRecno));
      SqlCommand mCommand = new SqlCommand();
      mCommand.CommandText = "INSERT INTO LG_" + this.oku_FIRMADONEM + "_ORFLINE\r\n                                            (\r\n                                            LOGICALREF,\r\n                                            STOCKREF,\r\n                                            ORDFICHEREF,\r\n                                            CLIENTREF,\r\n                                            LINETYPE,\r\n                                            PREVLINEREF,\r\n                                            PREVLINENO,\r\n                                            DETLINE,\r\n                                            LINENO_,\r\n                                            TRCODE,\r\n                                            DATE_,\r\n                                            TIME_,\r\n                                            GLOBTRANS,\r\n                                            CALCTYPE,\r\n                                            CENTERREF,\r\n                                            ACCOUNTREF,\r\n                                            VATACCREF,\r\n                                            VATCENTERREF,\r\n                                            PRACCREF,\r\n                                            PRCENTERREF,\r\n                                            PRVATACCREF,\r\n                                            PRVATCENREF,\r\n                                            PROMREF,\r\n                                            SPECODE,\r\n                                            DELVRYCODE,\r\n                                            AMOUNT,\r\n                                            PRICE,\r\n                                            TOTAL,\r\n                                            SHIPPEDAMOUNT,\r\n                                            DISCPER,\r\n                                            DISTCOST,\r\n                                            DISTDISC,\r\n                                            DISTEXP,\r\n                                            DISTPROM,\r\n                                            VAT,\r\n                                            VATAMNT,\r\n                                            VATMATRAH,\r\n                                            LINEEXP,\r\n                                            UOMREF,\r\n                                            USREF,\r\n                                            UINFO1,\r\n                                            UINFO2,\r\n                                            UINFO3,\r\n                                            UINFO4,\r\n                                            UINFO5,\r\n                                            UINFO6,\r\n                                            UINFO7,\r\n                                            UINFO8,\r\n                                            VATINC,\r\n                                            CLOSED,\r\n                                            DORESERVE,\r\n                                            INUSE,\r\n                                            DUEDATE,\r\n                                            PRCURR,\r\n                                            PRPRICE,\r\n                                            REPORTRATE,\r\n                                            BILLEDITEM,\r\n                                            PAYDEFREF,\r\n                                            EXTENREF,\r\n                                            CPSTFLAG,\r\n                                            SOURCEINDEX,\r\n                                            SOURCECOSTGRP,\r\n                                            BRANCH,\r\n                                            DEPARTMENT,\r\n                                            LINENET,\r\n                                            SALESMANREF,\r\n                                            STATUS,\r\n                                            DREF,\r\n                                            TRGFLAG,\r\n                                            SITEID,\r\n                                            RECSTATUS,\r\n                                            ORGLOGICREF,\r\n                                            FACTORYNR,\r\n                                            WFSTATUS,\r\n                                            NETDISCFLAG,\r\n                                            NETDISCPERC,\r\n                                            NETDISCAMNT,\r\n                                            CONDITIONREF,\r\n                                            DISTRESERVED,\r\n                                            ONVEHICLE,\r\n                                            CAMPAIGNREFS1,\r\n                                            CAMPAIGNREFS2,\r\n                                            CAMPAIGNREFS3,\r\n                                            CAMPAIGNREFS4,\r\n                                            CAMPAIGNREFS5,\r\n                                            POINTCAMPREF,\r\n                                            CAMPPOINT,\r\n                                            PROMCLASITEMREF,\r\n                                            REASONFORNOTSHP,\r\n                                            CMPGLINEREF,\r\n                                            PRRATE,\r\n                                            GROSSUINFO1,\r\n                                            GROSSUINFO2,\r\n                                            CANCELLED,\r\n                                            DEMPEGGEDAMNT,\r\n                                            TEXTINC,\r\n                                            OFFERREF,\r\n                                            ORDERPARAM,\r\n                                            ITEMASGREF,\r\n                                            EXIMAMOUNT,\r\n                                            OFFTRANSREF,\r\n                                            ORDEREDAMOUNT,\r\n                                            ORGLOGOID,\r\n                                            TRCURR,\r\n                                            TRRATE,\r\n                                            WITHPAYTRANS,\r\n                                            PROJECTREF,\r\n                                            POINTCAMPREFS1,\r\n                                            POINTCAMPREFS2,\r\n                                            POINTCAMPREFS3,\r\n                                            POINTCAMPREFS4,\r\n                                            CAMPPOINTS1,\r\n                                            CAMPPOINTS2,\r\n                                            CAMPPOINTS3,\r\n                                            CAMPPOINTS4,\r\n                                            CMPGLINEREFS1,\r\n                                            CMPGLINEREFS2,\r\n                                            CMPGLINEREFS3,\r\n                                            CMPGLINEREFS4,\r\n                                            PRCLISTREF,\r\n                                            AFFECTCOLLATRL,\r\n                                            FCTYP,\r\n                                            PURCHOFFNR,\r\n                                            DEMFICHEREF,\r\n                                            DEMTRANSREF,\r\n                                            ALTPROMFLAG,\r\n                                            VARIANTREF,\r\n                                            REFLVATACCREF,\r\n                                            REFLVATOTHACCREF,\r\n                                            PRIORITY,\r\n                                            AFFECTRISK,\r\n                                            BOMREF,\r\n                                            BOMREVREF,\r\n                                            ROUTINGREF,\r\n                                            OPERATIONREF,\r\n                                            WSREF,\r\n                                            ADDTAXRATE,\r\n                                            ADDTAXCONVFACT,\r\n                                            ADDTAXAMOUNT,\r\n                                            ADDTAXACCREF,\r\n                                            ADDTAXCENTERREF,\r\n                                            ADDTAXAMNTISUPD,\r\n                                            ADDTAXDISCAMOUNT,\r\n                                            EXADDTAXRATE,\r\n                                            EXADDTAXCONVF,\r\n                                            EXADDTAXAMNT,\r\n                                            EUVATSTATUS,\r\n                                            ADDTAXVATMATRAH\r\n                                            )\r\n                                            VALUES \r\n                                            (\r\n                                            " + (object) scalarValue5 + ", -- LOGICALREF\r\n                                            " + (object) scalarValue1 + ", -- STOCKREF\r\n                                            " + (object) this.SonRecNo + ", -- ORDFICHEREF\r\n                                            " + (object) this.CariRecno + ", -- CLIENTREF\r\n                                            '0', -- LINETYPE\r\n                                            '0', -- PREVLINEREF\r\n                                            '0', -- PREVLINENO\r\n                                            '0', -- DETLINE\r\n                                            '1', -- LINENO_\r\n                                            '1', -- TRCODE\r\n                                            convert(datetime,getdate(),103), -- DATE_\r\n                                            '203948071', -- TIME_\r\n                                            '0', -- GLOBTRANS\r\n                                            '0', -- CALCTYPE\r\n                                            '0', -- CENTERREF\r\n                                            " + (object) this.CariMuhasebeRec + ", -- ACCOUNTREF\r\n                                            '930', -- VATACCREF\r\n                                            '0', -- VATCENTERREF\r\n                                            '0', -- PRACCREF\r\n                                            '0', -- PRCENTERREF\r\n                                            '0', -- PRVATACCREF\r\n                                            '0', -- PRVATCENREF\r\n                                            '0', -- PROMREF\r\n                                            '', -- SPECODE\r\n                                            '', -- DELVRYCODE\r\n                                            " + Convert.ToDouble(Miktar).ToString().Replace(",", ".") + ", -- AMOUNT\r\n                                            " + Convert.ToDouble(BirimFiyat).ToString().Replace(",", ".") + ", -- PRICE\r\n                                            " + Convert.ToDouble(Miktar * BirimFiyat).ToString().Replace(",", ".") + ", -- TOTAL\r\n                                            '0', -- SHIPPEDAMOUNT\r\n                                            '0', -- DISCPER\r\n                                            '0', -- DISTCOST\r\n                                            '0', -- DISTDISC\r\n                                            '0', -- DISTEXP\r\n                                            '0', -- DISTPROM\r\n                                            " + (object) scalarValue2 + ", -- VAT\r\n                                            '0', -- VATAMNT\r\n                                            '0', -- VATMATRAH\r\n                                            '', -- LINEEXP\r\n                                            " + (object) scalarValue4 + ", -- UOMREF\r\n                                            " + (object) scalarValue3 + ", -- USREF\r\n                                            '1', -- UINFO1\r\n                                            '1', -- UINFO2\r\n                                            '0', -- UINFO3\r\n                                            '0', -- UINFO4\r\n                                            '0', -- UINFO5\r\n                                            '0', -- UINFO6\r\n                                            '0', -- UINFO7\r\n                                            '0', -- UINFO8\r\n                                            '0', -- VATINC\r\n                                            '0', -- CLOSED\r\n                                            '0', -- DORESERVE\r\n                                            '0', -- INUSE\r\n                                            convert(datetime,getdate(),103), -- DUEDATE\r\n                                            '0', -- PRCURR\r\n                                            '0', -- PRPRICE\r\n                                            '1', -- REPORTRATE\r\n                                            '0', -- BILLEDITEM\r\n                                            '0', -- PAYDEFREF\r\n                                            '0', -- EXTENREF\r\n                                            '0', -- CPSTFLAG\r\n                                            '0', -- SOURCEINDEX\r\n                                            '0', -- SOURCECOSTGRP\r\n                                            '0', -- BRANCH\r\n                                            '0', -- DEPARTMENT\r\n                                            '0', -- LINENET\r\n                                            '0', -- SALESMANREF\r\n                                            '4', -- STATUS\r\n                                            '0', -- DREF\r\n                                            '0', -- TRGFLAG\r\n                                            '0', -- SITEID\r\n                                            '2', -- RECSTATUS\r\n                                            '0', -- ORGLOGICREF\r\n                                            '0', -- FACTORYNR\r\n                                            '0', -- WFSTATUS\r\n                                            '0', -- NETDISCFLAG\r\n                                            '0', -- NETDISCPERC\r\n                                            '0', -- NETDISCAMNT\r\n                                            '0', -- CONDITIONREF\r\n                                            '0', -- DISTRESERVED\r\n                                            '0', -- ONVEHICLE\r\n                                            '0', -- CAMPAIGNREFS1\r\n                                            '0', -- CAMPAIGNREFS2\r\n                                            '0', -- CAMPAIGNREFS3\r\n                                            '0', -- CAMPAIGNREFS4\r\n                                            '0', -- CAMPAIGNREFS5\r\n                                            '0', -- POINTCAMPREF\r\n                                            '0', -- CAMPPOINT\r\n                                            '0', -- PROMCLASITEMREF\r\n                                            '0', -- REASONFORNOTSHP\r\n                                            '0', -- CMPGLINEREF\r\n                                            '0', -- PRRATE\r\n                                            '0', -- GROSSUINFO1\r\n                                            '0', -- GROSSUINFO2\r\n                                            '0', -- CANCELLED\r\n                                            '0', -- DEMPEGGEDAMNT\r\n                                            '0', -- TEXTINC\r\n                                            '0', -- OFFERREF\r\n                                            '0', -- ORDERPARAM\r\n                                            '0', -- ITEMASGREF\r\n                                            '0', -- EXIMAMOUNT\r\n                                            '0', -- OFFTRANSREF\r\n                                            '0', -- ORDEREDAMOUNT\r\n                                            '',  -- ORGLOGOID\r\n                                            '0', -- TRCURR\r\n                                            '0', -- TRRATE\r\n                                            '0', -- WITHPAYTRANS\r\n                                            '0', -- PROJECTREF\r\n                                            '0', -- POINTCAMPREFS1\r\n                                            '0', -- POINTCAMPREFS2\r\n                                            '0', -- POINTCAMPREFS3\r\n                                            '0', -- POINTCAMPREFS4\r\n                                            '0', -- CAMPPOINTS1\r\n                                            '0', -- CAMPPOINTS2\r\n                                            '0', -- CAMPPOINTS3\r\n                                            '0', -- CAMPPOINTS4\r\n                                            '0', -- CMPGLINEREFS1\r\n                                            '0', -- CMPGLINEREFS2\r\n                                            '0', -- CMPGLINEREFS3\r\n                                            '0', -- CMPGLINEREFS4\r\n                                            '0', -- PRCLISTREF\r\n                                            '0', -- AFFECTCOLLATRL\r\n                                            '0', -- FCTYP\r\n                                            '0', -- PURCHOFFNR\r\n                                            '0', -- DEMFICHEREF\r\n                                            '0', -- DEMTRANSREF\r\n                                            '0', -- ALTPROMFLAG\r\n                                            '0', -- VARIANTREF\r\n                                            '0', -- REFLVATACCREF\r\n                                            '0', -- REFLVATOTHACCREF\r\n                                            '0', -- PRIORITY\r\n                                            '1', -- AFFECTRISK\r\n                                            '0', -- BOMREF\r\n                                            '0', -- BOMREVREF\r\n                                            '0', -- ROUTINGREF\r\n                                            '0', -- OPERATIONREF\r\n                                            '0', -- WSREF\r\n                                            '0', -- ADDTAXRATE\r\n                                            '0', -- ADDTAXCONVFACT\r\n                                            '0', -- ADDTAXAMOUNT\r\n                                            '0', -- ADDTAXACCREF\r\n                                            '0', -- ADDTAXCENTERREF\r\n                                            '0', -- ADDTAXAMNTISUPD\r\n                                            '0', -- ADDTAXDISCAMOUNT\r\n                                            '0', -- EXADDTAXRATE\r\n                                            '0', -- EXADDTAXCONVF\r\n                                            '0', -- EXADDTAXAMNT\r\n                                            '0', -- EUVATSTATUS\r\n                                            ''   -- ADDTAXVATMATRAH\r\n                                            )\r\n                                            ";
      DBManager.sqlRunCommand(mCommand);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Aktarim Başlasın mı?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
        return;
      DBManager.sqlDisConnect();
      DBManager.sqlConnect("");
      DataTable dataTable1 = DBManager.sqlGetDataTable(new SqlCommand("SELECT sip_doviz_cinsi,sip_evrakno_seri,sip_evrakno_sira,sip_musteri_kod,sum(sip_vergi) as 'vergi',sum(sip_tutar) as 'tutar',substring(sip_aciklama,0,17) as 'Alt' FROM SIPARISLER   JOIN CARI_HESAPLAR ON  sip_musteri_kod = CARI_HESAPLAR.cari_kod GROUP BY sip_evrakno_seri,sip_evrakno_sira,sip_musteri_kod,sip_doviz_cinsi,substring(sip_aciklama,0,17)"));
      this.progressBar2.Maximum = 0;
      this.progressBar2.Maximum = dataTable1.Rows.Count;
      int num1 = 0;
      foreach (DataRow row1 in (InternalDataCollectionBase) dataTable1.Rows)
      {
        try
        {
          string[] strArray = this.cmbLogoFirma.SelectedValue.ToString().Split('_');
          if (strArray.Length > 0)
          {
            this.oku_FIRMA = strArray[0];
            this.oku_DONEM = strArray[1];
            this.oku_FIRMADONEM = this.cmbLogoFirma.SelectedValue.ToString();
            Application.DoEvents();
          }
        }
        catch
        {
        }
        ++num1;
        this.progressBar2.Value = num1;
        int num2 = 0;
        this.BaslikAktar(this.txtEvrakSeri.Text + row1["sip_evrakno_seri"].ToString() + row1["sip_evrakno_sira"].ToString(), row1["sip_musteri_kod"].ToString().Replace(".USD", ""), Convert.ToDouble(row1["vergi"].ToString()), Convert.ToDouble(row1["tutar"].ToString()) + Convert.ToDouble(row1["vergi"].ToString()), Convert.ToDouble(row1["tutar"].ToString()), row1["Alt"].ToString());
        DBManager.sqlDisConnect();
        this.label8.Text = dataTable1.Rows.Count.ToString();
        this.label7.Text = this.label8.Text + "/" + num1.ToString();
        Application.DoEvents();
        DataTable dataTable2 = DBManager.sqlGetDataTable(new SqlCommand("SELECT sip_evrakno_seri,sip_evrakno_sira,sip_stok_kod,sip_miktar,sip_b_fiyat,(select sto_RECno from STOKLAR WHERE sto_kod=sip_stok_kod) as 'RecNo',(select sto_isim from STOKLAR WHERE sto_kod=sip_stok_kod) as 'Isim' FROM SIPARISLER WHERE sip_evrakno_seri='" + row1["sip_evrakno_seri"].ToString() + "' and sip_miktar>0 and sip_evrakno_sira=" + row1["sip_evrakno_sira"].ToString() + " ORDER BY sip_stok_kod"));
        this.progressBar1.Minimum = 0;
        this.progressBar1.Maximum = dataTable2.Rows.Count;
        foreach (DataRow row2 in (InternalDataCollectionBase) dataTable2.Rows)
        {
          ++num2;
          this.progressBar1.Value = num2;
          this.BaslikDetay(this.SonRecNo, row2["sip_stok_kod"].ToString(), Convert.ToDouble(row2["sip_miktar"]), Convert.ToDouble(row2["sip_b_fiyat"].ToString()), row2["RecNo"].ToString(), row2["Isim"].ToString());
        }
      }
    }

    private void LogoBaglan()
    {
      DBManager.sqlDisConnect();
      DBManager.sqlConnect(string.Format("Data Source={0};Initial Catalog={1};User Id={2};password={3};", (object) this.txtServerAdi.Text, (object) this.txtDatabase.Text, (object) this.txtKullaniciAdi.Text, (object) this.txtSifre.Text));
    }

    private void frmLogoSiparisKayit_Load(object sender, EventArgs e)
    {
    }

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        this.LogoBaglan();
        SqlCommand mCommand1 = new SqlCommand();
        mCommand1.CommandText = "\r\n                IF EXISTS( SELECT * FROM sysobjects WHERE [name]='extrap_PadLeft') BEGIN DROP  FUNCTION extrap_PadLeft END";
        DBManager.sqlRunCommand(mCommand1);
        mCommand1.CommandText = " \r\n                CREATE FUNCTION extrap_PadLeft    \r\n                (\r\n                @Seq varchar(30),    \r\n                @PadWith char(1),    \r\n                @PadLength int    \r\n                )     \r\n                RETURNS varchar(16) AS    \r\n                BEGIN     \r\n                declare @curSeq varchar(30)    \r\n                SELECT @curSeq = ISNULL(REPLICATE(@PadWith, @PadLength - len(ISNULL(@Seq ,0))), '') + @Seq    \r\n                RETURN @curSeq    \r\n                END ";
        DBManager.sqlRunCommand(mCommand1);
        DataTable dataTable = new DataTable();
        SqlCommand mCommand2 = new SqlCommand("SELECT L_CAPIFIRM.LOGICALREF No,dbo.extrap_PadLeft(L_CAPIFIRM.NR,'0',3)+'_'+dbo.extrap_PadLeft(L_CAPIPERIOD.NR,'0',2) DONEM, dbo.extrap_PadLeft(L_CAPIPERIOD.NR,'0',2)+'-'+NAME Adi FROM L_CAPIFIRM JOIN L_CAPIPERIOD ON L_CAPIFIRM.NR=L_CAPIPERIOD.FIRMNR AND L_CAPIPERIOD.ENDDATE>CONVERT(DATETIME,GETDATE(),104)");
        this.cmbLogoFirma.DataSource = (object) DBManager.sqlGetDataTable(mCommand2);
        this.cmbLogoFirma.DisplayMember = "DONEM";
        this.cmbLogoFirma.ValueMember = "DONEM";
        this.cmbLogoFirma.SelectedIndex = 0;
        this.CMBUSDSIRKET.DataSource = (object) DBManager.sqlGetDataTable(mCommand2);
        this.CMBUSDSIRKET.DisplayMember = "DONEM";
        this.CMBUSDSIRKET.ValueMember = "DONEM";
        this.CMBUSDSIRKET.SelectedIndex = 0;
        this.CMBEUROSIRKET.DataSource = (object) DBManager.sqlGetDataTable(mCommand2);
        this.CMBEUROSIRKET.DisplayMember = "DONEM";
        this.CMBEUROSIRKET.ValueMember = "DONEM";
        this.CMBEUROSIRKET.SelectedIndex = 0;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Bağlantı Sağlanamadı");
      }
    }

    private void cmbLogoFirma_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        string[] strArray = this.cmbLogoFirma.SelectedValue.ToString().Split('_');
        if (strArray.Length <= 0)
          return;
        this.oku_FIRMA = strArray[0];
        this.oku_DONEM = strArray[1];
        this.oku_FIRMADONEM = this.cmbLogoFirma.SelectedValue.ToString();
        Application.DoEvents();
      }
      catch
      {
      }
    }

    private void groupControl1_Paint(object sender, PaintEventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmLogoSiparisKayit));
      this.groupControl1 = new GroupControl();
      this.txtEvrakSeri = new TextBox();
      this.label11 = new Label();
      this.progressBar2 = new System.Windows.Forms.ProgressBar();
      this.button2 = new Button();
      this.CMBEUROSIRKET = new System.Windows.Forms.ComboBox();
      this.label9 = new Label();
      this.CMBUSDSIRKET = new System.Windows.Forms.ComboBox();
      this.label6 = new Label();
      this.cmbLogoFirma = new System.Windows.Forms.ComboBox();
      this.label4 = new Label();
      this.label7 = new Label();
      this.label8 = new Label();
      this.label5 = new Label();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.button1 = new Button();
      this.txtServerAdi = new TextBox();
      this.txtKullaniciAdi = new TextBox();
      this.txtDatabase = new TextBox();
      this.txtSifre = new TextBox();
      this.label10 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.groupControl1.BeginInit();
      this.groupControl1.SuspendLayout();
      this.SuspendLayout();
      this.groupControl1.Controls.Add((Control) this.txtEvrakSeri);
      this.groupControl1.Controls.Add((Control) this.label11);
      this.groupControl1.Controls.Add((Control) this.progressBar2);
      this.groupControl1.Controls.Add((Control) this.button2);
      this.groupControl1.Controls.Add((Control) this.CMBEUROSIRKET);
      this.groupControl1.Controls.Add((Control) this.label9);
      this.groupControl1.Controls.Add((Control) this.CMBUSDSIRKET);
      this.groupControl1.Controls.Add((Control) this.label6);
      this.groupControl1.Controls.Add((Control) this.cmbLogoFirma);
      this.groupControl1.Controls.Add((Control) this.label4);
      this.groupControl1.Controls.Add((Control) this.label7);
      this.groupControl1.Controls.Add((Control) this.label8);
      this.groupControl1.Controls.Add((Control) this.label5);
      this.groupControl1.Controls.Add((Control) this.progressBar1);
      this.groupControl1.Controls.Add((Control) this.button1);
      this.groupControl1.Controls.Add((Control) this.txtServerAdi);
      this.groupControl1.Controls.Add((Control) this.txtKullaniciAdi);
      this.groupControl1.Controls.Add((Control) this.txtDatabase);
      this.groupControl1.Controls.Add((Control) this.txtSifre);
      this.groupControl1.Controls.Add((Control) this.label10);
      this.groupControl1.Controls.Add((Control) this.label3);
      this.groupControl1.Controls.Add((Control) this.label2);
      this.groupControl1.Controls.Add((Control) this.label1);
      this.groupControl1.Dock = DockStyle.Fill;
      this.groupControl1.Location = new Point(0, 0);
      this.groupControl1.LookAndFeel.SkinName = "Caramel";
      this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new Size(270, 383);
      this.groupControl1.TabIndex = 5;
      this.groupControl1.Text = "Logo Server Bilgileri";
      this.groupControl1.Paint += new PaintEventHandler(this.groupControl1_Paint);
      this.txtEvrakSeri.BorderStyle = BorderStyle.FixedSingle;
      this.txtEvrakSeri.Location = new Point(99, 215);
      this.txtEvrakSeri.Name = "txtEvrakSeri";
      this.txtEvrakSeri.Size = new Size(166, 20);
      this.txtEvrakSeri.TabIndex = 18;
      this.label11.AutoSize = true;
      this.label11.Location = new Point(10, 225);
      this.label11.Name = "label11";
      this.label11.Size = new Size(67, 13);
      this.label11.TabIndex = 17;
      this.label11.Text = "Kontrol Seri :";
      this.progressBar2.Location = new Point(11, 327);
      this.progressBar2.Name = "progressBar2";
      this.progressBar2.Size = new Size(256, 22);
      this.progressBar2.TabIndex = 16;
      this.button2.FlatStyle = FlatStyle.Flat;
      this.button2.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.button2.ForeColor = Color.Crimson;
      this.button2.Location = new Point(99, 117);
      this.button2.Name = "button2";
      this.button2.Size = new Size(166, 23);
      this.button2.TabIndex = 5;
      this.button2.Text = "Bağlantı Sağla";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.CMBEUROSIRKET.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.CMBEUROSIRKET.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CMBEUROSIRKET.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.CMBEUROSIRKET.FormattingEnabled = true;
      this.CMBEUROSIRKET.Location = new Point(99, 191);
      this.CMBEUROSIRKET.Name = "CMBEUROSIRKET";
      this.CMBEUROSIRKET.Size = new Size(166, 21);
      this.CMBEUROSIRKET.TabIndex = 8;
      this.CMBEUROSIRKET.SelectedIndexChanged += new EventHandler(this.cmbLogoFirma_SelectedIndexChanged);
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label9.Location = new Point(10, 202);
      this.label9.Name = "label9";
      this.label9.Size = new Size(89, 13);
      this.label9.TabIndex = 13;
      this.label9.Text = "EURO  Şirketi  :";
      this.CMBUSDSIRKET.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.CMBUSDSIRKET.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CMBUSDSIRKET.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.CMBUSDSIRKET.FormattingEnabled = true;
      this.CMBUSDSIRKET.Location = new Point(99, 167);
      this.CMBUSDSIRKET.Name = "CMBUSDSIRKET";
      this.CMBUSDSIRKET.Size = new Size(166, 21);
      this.CMBUSDSIRKET.TabIndex = 7;
      this.CMBUSDSIRKET.SelectedIndexChanged += new EventHandler(this.cmbLogoFirma_SelectedIndexChanged);
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label6.Location = new Point(10, 178);
      this.label6.Name = "label6";
      this.label6.Size = new Size(88, 13);
      this.label6.TabIndex = 13;
      this.label6.Text = "USD Şirketi     :";
      this.cmbLogoFirma.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.cmbLogoFirma.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cmbLogoFirma.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.cmbLogoFirma.FormattingEnabled = true;
      this.cmbLogoFirma.Location = new Point(99, 143);
      this.cmbLogoFirma.Name = "cmbLogoFirma";
      this.cmbLogoFirma.Size = new Size(166, 21);
      this.cmbLogoFirma.TabIndex = 6;
      this.cmbLogoFirma.SelectedIndexChanged += new EventHandler(this.cmbLogoFirma_SelectedIndexChanged);
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label4.Location = new Point(11, 154);
      this.label4.Name = "label4";
      this.label4.Size = new Size(87, 13);
      this.label4.TabIndex = 13;
      this.label4.Text = "TL  Şirketi       :";
      this.label7.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.label7.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label7.Location = new Point(11, 294);
      this.label7.Name = "label7";
      this.label7.Size = new Size(257, 16);
      this.label7.TabIndex = 12;
      this.label7.TextAlign = ContentAlignment.MiddleCenter;
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.White;
      this.label8.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label8.Location = new Point(105, 314);
      this.label8.Name = "label8";
      this.label8.Size = new Size(31, 13);
      this.label8.TabIndex = 11;
      this.label8.Text = "0.00";
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.White;
      this.label5.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label5.Location = new Point(11, 314);
      this.label5.Name = "label5";
      this.label5.Size = new Size(87, 13);
      this.label5.TabIndex = 8;
      this.label5.Text = "Toplam Kayit :";
      this.progressBar1.Location = new Point(12, 351);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(256, 21);
      this.progressBar1.TabIndex = 7;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.button1.ForeColor = Color.Crimson;
      this.button1.Image = (Image) Resources.import1;
      this.button1.ImageAlign = ContentAlignment.MiddleLeft;
      this.button1.Location = new Point(11, (int) byte.MaxValue);
      this.button1.Name = "button1";
      this.button1.Size = new Size(257, 38);
      this.button1.TabIndex = 9;
      this.button1.Text = "Aktarimi Başlat";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.txtServerAdi.BorderStyle = BorderStyle.FixedSingle;
      this.txtServerAdi.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtServerAdi.Location = new Point(99, 26);
      this.txtServerAdi.Name = "txtServerAdi";
      this.txtServerAdi.Size = new Size(166, 21);
      this.txtServerAdi.TabIndex = 1;
      this.txtKullaniciAdi.BorderStyle = BorderStyle.FixedSingle;
      this.txtKullaniciAdi.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtKullaniciAdi.Location = new Point(99, 48);
      this.txtKullaniciAdi.Name = "txtKullaniciAdi";
      this.txtKullaniciAdi.Size = new Size(166, 21);
      this.txtKullaniciAdi.TabIndex = 2;
      this.txtDatabase.BorderStyle = BorderStyle.FixedSingle;
      this.txtDatabase.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtDatabase.Location = new Point(99, 93);
      this.txtDatabase.Name = "txtDatabase";
      this.txtDatabase.Size = new Size(166, 21);
      this.txtDatabase.TabIndex = 4;
      this.txtDatabase.Text = "LKSDB";
      this.txtSifre.BorderStyle = BorderStyle.FixedSingle;
      this.txtSifre.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtSifre.Location = new Point(99, 70);
      this.txtSifre.Name = "txtSifre";
      this.txtSifre.PasswordChar = '*';
      this.txtSifre.Size = new Size(166, 21);
      this.txtSifre.TabIndex = 3;
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label10.Location = new Point(11, 104);
      this.label10.Name = "label10";
      this.label10.Size = new Size(85, 13);
      this.label10.TabIndex = 0;
      this.label10.Text = "Database       :";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label3.Location = new Point(11, 81);
      this.label3.Name = "label3";
      this.label3.Size = new Size(84, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Şifre                :";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label2.Location = new Point(11, 59);
      this.label2.Name = "label2";
      this.label2.Size = new Size(86, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Kullanici Adi   :";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label1.Location = new Point(11, 37);
      this.label1.Name = "label1";
      this.label1.Size = new Size(84, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Server Adi     :";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(270, 383);
      this.Controls.Add((Control) this.groupControl1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(278, 327);
      this.Name = nameof (frmLogoSiparisKayit);
      this.Text = "Siparişleri Logoya Aktarım";
      this.Load += new EventHandler(this.frmLogoSiparisKayit_Load);
      this.groupControl1.EndInit();
      this.groupControl1.ResumeLayout(false);
      this.groupControl1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
