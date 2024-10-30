// Decompiled with JetBrains decompiler
// Type: Fuar.RaporlarGrafik
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Printing;
using DevExpress.XtraCharts.Wizard;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
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
  public class RaporlarGrafik : XtraForm
  {
    private string str_path = string.Empty;
    private IContainer components;
    private SimpleButton btn_kapat;
    private SimpleButton btn_yazdir;
    private SimpleButton btn_pdf;
    private SimpleButton btn_excel;
    private LabelControl labelControl1;
    private GroupControl groupControl1;
    private SimpleButton btn_sorgula;
    private SaveFileDialog sdialog;
    private BarManager bm2;
    private BarDockControl barDockControl1;
    private BarDockControl barDockControl2;
    private BarDockControl barDockControl3;
    private BarDockControl barDockControl4;
    private BarButtonItem bb_kopyala;
    private BarButtonItem bb_kopyala3;
    private PopupMenu pp2;
    private LookUpEdit cmb_raporlar;
    private VGridControl vg_param;
    private RepositoryItemTextEdit rep_numedit;
    private RepositoryItemDateEdit rep_date;
    private RepositoryItemCheckEdit rep_check;
    private RepositoryItemTextEdit rep_text;
    private GroupControl groupControl2;
    private RepositoryItemTextEdit rep_double;
    private ChartControl dtg_chart;
    private PivotGridControl dtg_rapor;
    private SimpleButton btn_wiz;

    public RaporlarGrafik() => this.InitializeComponent();

    private void btn_kapat_Click(object sender, EventArgs e) => this.Close();

    private void btn_excel_Click(object sender, EventArgs e)
    {
      this.sdialog.Filter = "Excel Çalışma Kitabı|*.xls";
      if (this.sdialog.ShowDialog() != DialogResult.OK)
        return;
      this.dtg_chart.ExportToXls(this.sdialog.FileName);
    }

    private void btn_pdf_Click(object sender, EventArgs e)
    {
      this.sdialog.Filter = "Pdf File|*.pdf";
      if (this.sdialog.ShowDialog() != DialogResult.OK)
        return;
      this.dtg_chart.OptionsPrint.SizeMode = (PrintSizeMode) 2;
      this.dtg_chart.ExportToPdf(this.sdialog.FileName);
    }

    private void btn_yazdir_Click(object sender, EventArgs e)
    {
      this.dtg_chart.OptionsPrint.SizeMode = (PrintSizeMode) 2;
      this.dtg_chart.ShowPrintPreview();
    }

    private void btn_sorgula_Click(object sender, EventArgs e)
    {
      SplashScreenManager.ShowForm(typeof (WaitForm1), false, true);
      SqlConnection connection = new SqlConnection(_main.str_connection);
      bool flag = true;
      try
      {
        if (this.cmb_raporlar.EditValue != null)
        {
          string _id = this.cmb_raporlar.EditValue.ToString();
          string reportQ = this.get_report_q(_id);
          DataTable dataTable1 = new DataTable();
          SqlCommand sqlCommand = new SqlCommand(reportQ, connection);
          DataTable dataTable2 = _main.komutcalistir_dt("SELECT PARAMNAME,PARAMCAPTION,PARAMTYPE,DEFAULTVALUE FROM RAPORPARAMS WHERE REPORTID = " + _id);
          for (int index = 0; index < dataTable2.Rows.Count; ++index)
          {
            if (this.vg_param.Rows[index].Properties.Value == null)
            {
              int num = (int) MessageBox.Show(dataTable2.Rows[index]["PARAMCAPTION"].ToString() + " - " + dataTable2.Rows[index]["PARAMNAME"].ToString() + " isimli parametreye değer girilmemiş");
              flag = false;
            }
            else
            {
              SqlDbType dbtype = this.get_dbtype(dataTable2.Rows[index]["PARAMTYPE"].ToString());
              SqlParameter sqlParameter = new SqlParameter(dataTable2.Rows[index]["PARAMNAME"].ToString(), dbtype);
              sqlParameter.Value = this.vg_param.Rows[index].Properties.Value;
              sqlCommand.Parameters.Add(sqlParameter);
            }
          }
          if (flag)
          {
            connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            dataTable1.Load((IDataReader) reader);
            connection.Close();
            this.dtg_rapor.DataSource = (object) dataTable1;
            this.dtg_rapor.RetrieveFields();
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show("Lütfen önce rapor seçiniz.");
        }
      }
      catch (Exception ex)
      {
        if (SplashScreenManager.Default != null)
          SplashScreenManager.CloseForm();
        int num = (int) MessageBox.Show(ex.Message);
        if (connection.State == ConnectionState.Open)
          connection.Close();
      }
      if (SplashScreenManager.Default == null)
        return;
      SplashScreenManager.CloseForm();
    }

    private SqlDbType get_dbtype(string _type)
    {
      switch (_type)
      {
        case "Int":
          return SqlDbType.Int;
        case "Double":
          return SqlDbType.Float;
        case "Date":
          return SqlDbType.DateTime;
        case "Boolean":
          return SqlDbType.Bit;
        default:
          return SqlDbType.NVarChar;
      }
    }

    public void PrintPreview(GridControl sender)
    {
      PrintingSystem ps = new PrintingSystem();
      PrintableComponentLink printableComponentLink = new PrintableComponentLink();
      try
      {
        this.Cursor = Cursors.WaitCursor;
        printableComponentLink.Component = (IPrintable) sender;
        printableComponentLink.CreateDocument(ps);
        printableComponentLink.Landscape = true;
        ps.PageSettings.Landscape = true;
        int num = (int) ps.PreviewFormEx.ShowDialog();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
      finally
      {
        this.Cursor = Cursors.Default;
        ps.Dispose();
        printableComponentLink.Dispose();
      }
    }

    private void Raporlar_Load(object sender, EventArgs e)
    {
    }

    private void set_cmbraporlar()
    {
      this.cmb_raporlar.Properties.DataSource = (object) _main.komutcalistir_dt("SELECT ID,REPORTNAME,REPORTINFO FROM RAPORLAR WHERE REPORTTYPE = 'Grafik Rapor'");
      this.cmb_raporlar.Properties.DisplayMember = "REPORTNAME";
      this.cmb_raporlar.Properties.ValueMember = "ID";
    }

    private string get_report_q(string _id)
    {
      return _main.komutcalistir_str("SELECT REPORTDATA FROM RAPORLAR WHERE ID = " + _id);
    }

    private void get_report_params(string _id)
    {
      try
      {
        DataTable dataTable = _main.komutcalistir_dt("SELECT PARAMNAME,PARAMCAPTION,PARAMTYPE,DEFAULTVALUE FROM RAPORPARAMS WHERE REPORTID = " + _id);
        this.vg_param.Rows.Clear();
        for (int index = 0; index < dataTable.Rows.Count; ++index)
        {
          EditorRow row = new EditorRow(dataTable.Rows[index]["PARAMNAME"].ToString());
          row.Properties.Caption = dataTable.Rows[index]["PARAMCAPTION"].ToString();
          string str = dataTable.Rows[index]["DEFAULTVALUE"].ToString();
          switch (dataTable.Rows[index]["PARAMTYPE"].ToString())
          {
            case "Int":
              row.Properties.RowEdit = (RepositoryItem) this.rep_numedit;
              if (str != "")
                row.Properties.Value = (object) str;
              this.vg_param.Rows.Add((BaseRow) row);
              break;
            case "Double":
              row.Properties.RowEdit = (RepositoryItem) this.rep_double;
              if (str != "")
                row.Properties.Value = (object) str;
              this.vg_param.Rows.Add((BaseRow) row);
              break;
            case "Date":
              row.Properties.RowEdit = (RepositoryItem) this.rep_date;
              if (str != "")
                row.Properties.Value = (object) str;
              this.vg_param.Rows.Add((BaseRow) row);
              break;
            case "Boolean":
              row.Properties.RowEdit = (RepositoryItem) this.rep_check;
              if (str != "")
                row.Properties.Value = (object) str;
              this.vg_param.Rows.Add((BaseRow) row);
              break;
            default:
              row.Properties.RowEdit = (RepositoryItem) this.rep_text;
              if (str != "")
                row.Properties.Value = (object) str;
              this.vg_param.Rows.Add((BaseRow) row);
              break;
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void cmb_raporlar_EditValueChanged(object sender, EventArgs e)
    {
      if (this.cmb_raporlar.EditValue == null)
        return;
      this.get_report_params(this.cmb_raporlar.EditValue.ToString());
    }

    private void bb_kopyala_ItemClick(object sender, ItemClickEventArgs e)
    {
    }

    private void dtg_rapor_MouseUp(object sender, MouseEventArgs e)
    {
    }

    private void Raporlar_Activated(object sender, EventArgs e) => this.set_cmbraporlar();

    private void btn_wiz_Click(object sender, EventArgs e)
    {
      int num = (int) new ChartWizard((object) this.dtg_chart).ShowDialog();
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
      XYDiagram xyDiagram = new XYDiagram();
      SideBySideBarSeriesLabel sideBarSeriesLabel = new SideBySideBarSeriesLabel();
      this.btn_kapat = new SimpleButton();
      this.btn_yazdir = new SimpleButton();
      this.btn_pdf = new SimpleButton();
      this.btn_excel = new SimpleButton();
      this.labelControl1 = new LabelControl();
      this.groupControl1 = new GroupControl();
      this.cmb_raporlar = new LookUpEdit();
      this.bm2 = new BarManager(this.components);
      this.barDockControl1 = new BarDockControl();
      this.barDockControl2 = new BarDockControl();
      this.barDockControl3 = new BarDockControl();
      this.barDockControl4 = new BarDockControl();
      this.bb_kopyala = new BarButtonItem();
      this.bb_kopyala3 = new BarButtonItem();
      this.btn_sorgula = new SimpleButton();
      this.sdialog = new SaveFileDialog();
      this.pp2 = new PopupMenu(this.components);
      this.vg_param = new VGridControl();
      this.rep_numedit = new RepositoryItemTextEdit();
      this.rep_date = new RepositoryItemDateEdit();
      this.rep_check = new RepositoryItemCheckEdit();
      this.rep_text = new RepositoryItemTextEdit();
      this.rep_double = new RepositoryItemTextEdit();
      this.groupControl2 = new GroupControl();
      this.dtg_chart = new ChartControl();
      this.dtg_rapor = new PivotGridControl();
      this.btn_wiz = new SimpleButton();
      this.groupControl1.BeginInit();
      this.groupControl1.SuspendLayout();
      this.cmb_raporlar.Properties.BeginInit();
      this.bm2.BeginInit();
      this.pp2.BeginInit();
      this.vg_param.BeginInit();
      this.rep_numedit.BeginInit();
      this.rep_date.BeginInit();
      this.rep_date.VistaTimeProperties.BeginInit();
      this.rep_check.BeginInit();
      this.rep_text.BeginInit();
      this.rep_double.BeginInit();
      this.groupControl2.BeginInit();
      this.groupControl2.SuspendLayout();
      this.dtg_chart.BeginInit();
      ((ISupportInitialize) xyDiagram).BeginInit();
      ((ISupportInitialize) sideBarSeriesLabel).BeginInit();
      this.dtg_rapor.BeginInit();
      this.SuspendLayout();
      this.btn_kapat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btn_kapat.Image = (Image) Resources.kapat__Custom_;
      this.btn_kapat.ImageLocation = ImageLocation.MiddleLeft;
      this.btn_kapat.Location = new Point(836, 646);
      this.btn_kapat.Name = "btn_kapat";
      this.btn_kapat.Size = new Size(149, 37);
      this.btn_kapat.TabIndex = 59;
      this.btn_kapat.Text = "Kapat";
      this.btn_kapat.Click += new EventHandler(this.btn_kapat_Click);
      this.btn_yazdir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_yazdir.Image = (Image) Resources.printer;
      this.btn_yazdir.ImageLocation = ImageLocation.MiddleLeft;
      this.btn_yazdir.Location = new Point(321, 646);
      this.btn_yazdir.Name = "btn_yazdir";
      this.btn_yazdir.Size = new Size(149, 37);
      this.btn_yazdir.TabIndex = 58;
      this.btn_yazdir.Text = "Yazdır";
      this.btn_yazdir.Click += new EventHandler(this.btn_yazdir_Click);
      this.btn_pdf.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_pdf.Image = (Image) Resources.pdf;
      this.btn_pdf.ImageLocation = ImageLocation.MiddleLeft;
      this.btn_pdf.Location = new Point(166, 646);
      this.btn_pdf.Name = "btn_pdf";
      this.btn_pdf.Size = new Size(149, 37);
      this.btn_pdf.TabIndex = 57;
      this.btn_pdf.Text = "Pdf Kaydet";
      this.btn_pdf.Click += new EventHandler(this.btn_pdf_Click);
      this.btn_excel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_excel.Image = (Image) Resources.Exel;
      this.btn_excel.ImageLocation = ImageLocation.MiddleLeft;
      this.btn_excel.Location = new Point(11, 646);
      this.btn_excel.Name = "btn_excel";
      this.btn_excel.Size = new Size(149, 37);
      this.btn_excel.TabIndex = 56;
      this.btn_excel.Text = "Excel  Kaydet";
      this.btn_excel.Click += new EventHandler(this.btn_excel_Click);
      this.labelControl1.Location = new Point(38, 51);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new Size(36, 13);
      this.labelControl1.TabIndex = 61;
      this.labelControl1.Text = "Rapor :";
      this.groupControl1.Controls.Add((Control) this.cmb_raporlar);
      this.groupControl1.Controls.Add((Control) this.btn_sorgula);
      this.groupControl1.Controls.Add((Control) this.labelControl1);
      this.groupControl1.Location = new Point(12, 12);
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new Size(642, 98);
      this.groupControl1.TabIndex = 62;
      this.groupControl1.Text = "Rapor Seçenekleri";
      this.cmb_raporlar.Location = new Point(80, 48);
      this.cmb_raporlar.MenuManager = (IDXMenuManager) this.bm2;
      this.cmb_raporlar.Name = "cmb_raporlar";
      this.cmb_raporlar.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.cmb_raporlar.Properties.Columns.AddRange(new LookUpColumnInfo[2]
      {
        new LookUpColumnInfo("REPORTNAME", 40, "Rapor Adı"),
        new LookUpColumnInfo("REPORTINFO", "Rapor Ek Bilgi")
      });
      this.cmb_raporlar.Properties.NullText = "Seçiniz...";
      this.cmb_raporlar.Size = new Size(346, 20);
      this.cmb_raporlar.TabIndex = 63;
      this.cmb_raporlar.EditValueChanged += new EventHandler(this.cmb_raporlar_EditValueChanged);
      this.bm2.DockControls.Add(this.barDockControl1);
      this.bm2.DockControls.Add(this.barDockControl2);
      this.bm2.DockControls.Add(this.barDockControl3);
      this.bm2.DockControls.Add(this.barDockControl4);
      this.bm2.Form = (Control) this;
      this.bm2.Items.AddRange(new BarItem[2]
      {
        (BarItem) this.bb_kopyala,
        (BarItem) this.bb_kopyala3
      });
      this.bm2.MaxItemId = 3;
      this.barDockControl1.CausesValidation = false;
      this.barDockControl1.Dock = DockStyle.Top;
      this.barDockControl1.Location = new Point(0, 0);
      this.barDockControl1.Size = new Size(997, 0);
      this.barDockControl2.CausesValidation = false;
      this.barDockControl2.Dock = DockStyle.Bottom;
      this.barDockControl2.Location = new Point(0, 695);
      this.barDockControl2.Size = new Size(997, 0);
      this.barDockControl3.CausesValidation = false;
      this.barDockControl3.Dock = DockStyle.Left;
      this.barDockControl3.Location = new Point(0, 0);
      this.barDockControl3.Size = new Size(0, 695);
      this.barDockControl4.CausesValidation = false;
      this.barDockControl4.Dock = DockStyle.Right;
      this.barDockControl4.Location = new Point(997, 0);
      this.barDockControl4.Size = new Size(0, 695);
      this.bb_kopyala.Caption = "Kopyala";
      this.bb_kopyala.Id = 0;
      this.bb_kopyala.Name = "bb_kopyala";
      this.bb_kopyala.ItemClick += new ItemClickEventHandler(this.bb_kopyala_ItemClick);
      this.bb_kopyala3.Id = 2;
      this.bb_kopyala3.Name = "bb_kopyala3";
      this.btn_sorgula.Image = (Image) Resources.data_view;
      this.btn_sorgula.ImageLocation = ImageLocation.MiddleLeft;
      this.btn_sorgula.Location = new Point(451, 39);
      this.btn_sorgula.Name = "btn_sorgula";
      this.btn_sorgula.Size = new Size(149, 37);
      this.btn_sorgula.TabIndex = 62;
      this.btn_sorgula.Text = "Raporu Çalıştır";
      this.btn_sorgula.Click += new EventHandler(this.btn_sorgula_Click);
      this.pp2.LinksPersistInfo.AddRange(new LinkPersistInfo[1]
      {
        new LinkPersistInfo((BarItem) this.bb_kopyala)
      });
      this.pp2.Manager = this.bm2;
      this.pp2.Name = "pp2";
      this.vg_param.Dock = DockStyle.Fill;
      this.vg_param.Location = new Point(2, 21);
      this.vg_param.Name = "vg_param";
      this.vg_param.OptionsView.AutoScaleBands = true;
      this.vg_param.RepositoryItems.AddRange(new RepositoryItem[5]
      {
        (RepositoryItem) this.rep_numedit,
        (RepositoryItem) this.rep_date,
        (RepositoryItem) this.rep_check,
        (RepositoryItem) this.rep_text,
        (RepositoryItem) this.rep_double
      });
      this.vg_param.Size = new Size(282, 77);
      this.vg_param.TabIndex = 67;
      this.rep_numedit.AutoHeight = false;
      this.rep_numedit.DisplayFormat.FormatString = "N0";
      this.rep_numedit.DisplayFormat.FormatType = FormatType.Numeric;
      this.rep_numedit.EditFormat.FormatString = "N0";
      this.rep_numedit.EditFormat.FormatType = FormatType.Numeric;
      this.rep_numedit.ExportMode = ExportMode.Value;
      this.rep_numedit.Mask.SaveLiteral = false;
      this.rep_numedit.MaxLength = 50;
      this.rep_numedit.Name = "rep_numedit";
      this.rep_date.AutoHeight = false;
      this.rep_date.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.rep_date.DisplayFormat.FormatString = "yyyy-MM-dd";
      this.rep_date.DisplayFormat.FormatType = FormatType.Custom;
      this.rep_date.EditFormat.FormatString = "yyyy-MM-dd";
      this.rep_date.EditFormat.FormatType = FormatType.Custom;
      this.rep_date.ExportMode = ExportMode.Value;
      this.rep_date.Mask.EditMask = "yyyy-MM-dd";
      this.rep_date.Name = "rep_date";
      this.rep_date.ValidateOnEnterKey = true;
      this.rep_date.VistaTimeProperties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.rep_check.AutoHeight = false;
      this.rep_check.Name = "rep_check";
      this.rep_check.NullStyle = StyleIndeterminate.Unchecked;
      this.rep_text.AutoHeight = false;
      this.rep_text.MaxLength = 50;
      this.rep_text.Name = "rep_text";
      this.rep_double.AutoHeight = false;
      this.rep_double.DisplayFormat.FormatString = "n2";
      this.rep_double.DisplayFormat.FormatType = FormatType.Numeric;
      this.rep_double.EditFormat.FormatString = "n2";
      this.rep_double.EditFormat.FormatType = FormatType.Numeric;
      this.rep_double.Mask.SaveLiteral = false;
      this.rep_double.MaxLength = 50;
      this.rep_double.Name = "rep_double";
      this.groupControl2.Controls.Add((Control) this.vg_param);
      this.groupControl2.Location = new Point(660, 12);
      this.groupControl2.Name = "groupControl2";
      this.groupControl2.Size = new Size(286, 100);
      this.groupControl2.TabIndex = 72;
      this.groupControl2.Text = "Rapor Parametreleri";
      this.dtg_chart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_chart.DataSource = (object) this.dtg_rapor;
      ((Axis2D) xyDiagram.AxisX).Label.ResolveOverlappingMode = (AxisLabelResolveOverlappingMode) 2;
      ((Axis2D) xyDiagram.AxisX).Label.Staggered = true;
      ((AxisBase) xyDiagram.AxisX).Range.ScrollingRange.SideMarginsEnabled = true;
      ((AxisBase) xyDiagram.AxisX).Range.SideMarginsEnabled = true;
      ((Axis2D) xyDiagram.AxisX).VisibleInPanesSerializable = "-1";
      ((AxisBase) xyDiagram.AxisY).Range.ScrollingRange.SideMarginsEnabled = true;
      ((AxisBase) xyDiagram.AxisY).Range.SideMarginsEnabled = true;
      ((Axis2D) xyDiagram.AxisY).VisibleInPanesSerializable = "-1";
      this.dtg_chart.Diagram = (Diagram) xyDiagram;
      this.dtg_chart.Legend.MaxHorizontalPercentage = 30.0;
      this.dtg_chart.Location = new Point(660, 118);
      this.dtg_chart.Name = "dtg_chart";
      this.dtg_chart.SeriesDataMember = "Series";
      this.dtg_chart.SeriesSerializable = new Series[0];
      this.dtg_chart.SeriesTemplate.ArgumentDataMember = "Arguments";
      ((SeriesLabelBase) sideBarSeriesLabel).LineVisible = true;
      ((SeriesLabelBase) sideBarSeriesLabel).ResolveOverlappingMode = (ResolveOverlappingMode) 1;
      this.dtg_chart.SeriesTemplate.Label = (SeriesLabelBase) sideBarSeriesLabel;
      this.dtg_chart.SeriesTemplate.ValueDataMembersSerializable = "Values";
      this.dtg_chart.Size = new Size(325, 522);
      this.dtg_chart.TabIndex = 87;
      this.dtg_rapor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.dtg_rapor.Location = new Point(11, 118);
      this.dtg_rapor.Name = "dtg_rapor";
      this.dtg_rapor.OptionsBehavior.CopyToClipboardWithFieldValues = true;
      ((PivotGridOptionsChartDataSourceBase) this.dtg_rapor.OptionsChartDataSource).FieldValuesProvideMode = (PivotChartFieldValuesProvideMode) 1;
      ((OptionsLayoutGrid) this.dtg_rapor.OptionsLayout).Columns.StoreAllOptions = true;
      ((OptionsLayoutGrid) this.dtg_rapor.OptionsLayout).StoreAllOptions = true;
      ((OptionsLayoutGrid) this.dtg_rapor.OptionsLayout).StoreAppearance = true;
      this.dtg_rapor.OptionsLayout.StoreLayoutOptions = true;
      this.dtg_rapor.Size = new Size(643, 522);
      this.dtg_rapor.TabIndex = 92;
      this.btn_wiz.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_wiz.Image = (Image) Resources.astrologer;
      this.btn_wiz.ImageLocation = ImageLocation.MiddleLeft;
      this.btn_wiz.Location = new Point(660, 646);
      this.btn_wiz.Name = "btn_wiz";
      this.btn_wiz.Size = new Size(149, 37);
      this.btn_wiz.TabIndex = 97;
      this.btn_wiz.Text = "Sihirbazı Aç";
      this.btn_wiz.Click += new EventHandler(this.btn_wiz_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(997, 695);
      this.Controls.Add((Control) this.btn_wiz);
      this.Controls.Add((Control) this.dtg_rapor);
      this.Controls.Add((Control) this.dtg_chart);
      this.Controls.Add((Control) this.groupControl2);
      this.Controls.Add((Control) this.groupControl1);
      this.Controls.Add((Control) this.btn_kapat);
      this.Controls.Add((Control) this.btn_yazdir);
      this.Controls.Add((Control) this.btn_pdf);
      this.Controls.Add((Control) this.btn_excel);
      this.Controls.Add((Control) this.barDockControl3);
      this.Controls.Add((Control) this.barDockControl4);
      this.Controls.Add((Control) this.barDockControl2);
      this.Controls.Add((Control) this.barDockControl1);
      this.KeyPreview = true;
      this.Name = nameof (RaporlarGrafik);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Tablo Raporları";
      this.WindowState = FormWindowState.Maximized;
      this.Activated += new EventHandler(this.Raporlar_Activated);
      this.Load += new EventHandler(this.Raporlar_Load);
      this.groupControl1.EndInit();
      this.groupControl1.ResumeLayout(false);
      this.groupControl1.PerformLayout();
      this.cmb_raporlar.Properties.EndInit();
      this.bm2.EndInit();
      this.pp2.EndInit();
      this.vg_param.EndInit();
      this.rep_numedit.EndInit();
      this.rep_date.VistaTimeProperties.EndInit();
      this.rep_date.EndInit();
      this.rep_check.EndInit();
      this.rep_text.EndInit();
      this.rep_double.EndInit();
      this.groupControl2.EndInit();
      this.groupControl2.ResumeLayout(false);
      ((ISupportInitialize) xyDiagram).EndInit();
      ((ISupportInitialize) sideBarSeriesLabel).EndInit();
      this.dtg_chart.EndInit();
      this.dtg_rapor.EndInit();
      this.ResumeLayout(false);
    }
  }
}
