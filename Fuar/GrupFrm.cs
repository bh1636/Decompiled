// Decompiled with JetBrains decompiler
// Type: Fuar.GrupFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class GrupFrm : XtraForm
  {
    public string grp_id = string.Empty;
    public string grp_ad = string.Empty;
    private IContainer components;
    private TextEdit txt_grupad;
    private LabelControl labelControl1;
    private SimpleButton btn_kaydet;
    private SimpleButton btn_iptal;
    private ListBoxControl lst_users;
    private ListBoxControl lst_grup_users;
    private GroupBox groupBox2;
    private LabelControl labelControl3;
    private LabelControl labelControl2;
    private ErrorProvider ep1;
    private GroupBox groupBox1;
    private GridControl dtg_yetki;
    private GridView grd_yetki;

    public GrupFrm() => this.InitializeComponent();

    private void GrupFrm_Load(object sender, EventArgs e)
    {
      if (this.grp_id != "")
      {
        DataTable grupUsers = this.get_grup_users(this.grp_id);
        for (int index = 0; index < grupUsers.Rows.Count; ++index)
          this.lst_grup_users.Items.Add((object) grupUsers.Rows[index][0].ToString());
        this.txt_grupad.Text = this.grp_ad;
      }
      DataTable freeUsers = this.get_free_users();
      for (int index = 0; index < freeUsers.Rows.Count; ++index)
        this.lst_users.Items.Add((object) freeUsers.Rows[index][0].ToString());
      this.xgrid_doldur();
    }

    private DataTable get_free_users()
    {
      DataTable dataTable = new DataTable();
      return _main.komutcalistir_dt("SELECT KULLANICIADI FROM KULLANICILAR WHERE GRUPID NOT IN (SELECT ID FROM GRUPLAR)");
    }

    private DataTable get_grup_users(string grup_id)
    {
      DataTable dataTable = new DataTable();
      return _main.komutcalistir_dt("SELECT KULLANICIADI FROM KULLANICILAR WHERE GRUPID = '" + grup_id + "'");
    }

    private void lst_users_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (this.lst_users.SelectedItems.Count <= 0 || this.lst_grup_users.Items.Contains((object) this.lst_users.SelectedItems))
        return;
      this.lst_grup_users.Items.Add((object) this.lst_users.SelectedValue.ToString());
      this.lst_users.Items.RemoveAt(this.lst_users.SelectedIndex);
    }

    private void lst_grup_users_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (this.lst_grup_users.SelectedItems.Count <= 0 || this.lst_users.Items.Contains((object) this.lst_grup_users.SelectedItems))
        return;
      this.lst_users.Items.Add((object) this.lst_grup_users.SelectedValue.ToString());
      this.lst_grup_users.Items.RemoveAt(this.lst_grup_users.SelectedIndex);
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (!this.alan_kontrol())
        return;
      if (this.grp_id == "")
        this.ins_grup();
      else
        this.upd_grup();
      this.Close();
    }

    private void upd_grup()
    {
      string empty = string.Empty;
      _main.komutcalistir("UPDATE GRUPLAR SET GRUPADI = '" + this.txt_grupad.Text + "' WHERE ID = " + this.grp_id);
      if (string.IsNullOrEmpty(this.grp_id))
        return;
      for (int index = 0; index < this.lst_grup_users.Items.Count; ++index)
        _main.komutcalistir("UPDATE KULLANICILAR SET GRUPID = " + this.grp_id + " WHERE KULLANICIADI = '" + this.lst_grup_users.Items[index].ToString() + "'");
      for (int index = 0; index < this.lst_users.Items.Count; ++index)
        _main.komutcalistir("UPDATE KULLANICILAR SET GRUPID = 0 WHERE KULLANICIADI = '" + this.lst_users.Items[index].ToString() + "'");
      this.ins_upd_yetkiler(this.grp_id);
    }

    private bool alan_kontrol()
    {
      bool flag = true;
      if (this.txt_grupad.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_grupad, "Alan boş olamaz.");
        flag = false;
      }
      else
        this.ep1.Clear();
      return flag;
    }

    private void ins_grup()
    {
      string empty = string.Empty;
      string grupid = _main.komutcalistir_str("INSERT INTO GRUPLAR (GRUPADI) " + "VALUES ('" + this.txt_grupad.Text + "') " + "SELECT @@IDENTITY AS OTELID ");
      if (string.IsNullOrEmpty(grupid))
        return;
      for (int index = 0; index < this.lst_grup_users.Items.Count; ++index)
        _main.komutcalistir("UPDATE KULLANICILAR SET GRUPID = " + grupid + " WHERE KULLANICIADI = '" + this.lst_grup_users.Items[index].ToString() + "'");
      for (int index = 0; index < this.lst_users.Items.Count; ++index)
        _main.komutcalistir("UPDATE KULLANICILAR SET GRUPID = 0 WHERE KULLANICIADI = '" + this.lst_users.Items[index].ToString() + "'");
      this.ins_upd_yetkiler(grupid);
    }

    private void xgrid_doldur()
    {
      string empty = string.Empty;
      DataTable dataTable = _main.komutcalistir_dt("SELECT Y.MODUL, Y.CANBROWSE, Y.CANINSERT, Y.CANEDIT, Y.CANDELETE FROM GRUPLAR AS G LEFT OUTER JOIN YETKILER AS Y ON G.ID = Y.GRUPID " + "WHERE G.GRUPADI = '" + this.txt_grupad.Text + "'");
      this.dtg_yetki.DataSource = (object) dataTable.Clone();
      RepositoryItemCheckEdit repositoryItemCheckEdit = new RepositoryItemCheckEdit();
      repositoryItemCheckEdit.NullStyle = StyleIndeterminate.Unchecked;
      this.grd_yetki.Columns["CANBROWSE"].ColumnEdit = (RepositoryItem) repositoryItemCheckEdit;
      this.grd_yetki.Columns["CANINSERT"].ColumnEdit = (RepositoryItem) repositoryItemCheckEdit;
      this.grd_yetki.Columns["CANEDIT"].ColumnEdit = (RepositoryItem) repositoryItemCheckEdit;
      this.grd_yetki.Columns["CANDELETE"].ColumnEdit = (RepositoryItem) repositoryItemCheckEdit;
      List<string> stringList = new List<string>();
      stringList.Add("Kartlar");
      stringList.Add("Siparişler");
      stringList.Add("G/Ç Hareketleri");
      stringList.Add("Kullanıcı Tanımları");
      stringList.Add("Logo Aktarımları");
      stringList.Add("Excel Aktarımları");
      stringList.Add("Raporlar");
      for (int index1 = 0; index1 < stringList.Count; ++index1)
      {
        this.grd_yetki.AddNewRow();
        this.grd_yetki.SetRowCellValue(this.grd_yetki.GetRowHandle(index1), "MODUL", (object) stringList[index1]);
        for (int index2 = 0; index2 < dataTable.Rows.Count; ++index2)
        {
          if (dataTable.Rows[index2]["MODUL"].ToString() == stringList[index1])
          {
            this.grd_yetki.SetFocusedRowCellValue("CANBROWSE", dataTable.Rows[index1]["CANBROWSE"]);
            this.grd_yetki.SetFocusedRowCellValue("CANINSERT", dataTable.Rows[index1]["CANINSERT"]);
            this.grd_yetki.SetFocusedRowCellValue("CANEDIT", dataTable.Rows[index1]["CANEDIT"]);
            this.grd_yetki.SetFocusedRowCellValue("CANDELETE", dataTable.Rows[index1]["CANDELETE"]);
          }
        }
      }
      this.grd_yetki.Columns["MODUL"].OptionsColumn.AllowFocus = false;
      this.grd_yetki.Columns["MODUL"].Caption = "Modül";
      this.grd_yetki.Columns["CANBROWSE"].Caption = "Görebilir";
      this.grd_yetki.Columns["CANINSERT"].Caption = "Ekleyebilir";
      this.grd_yetki.Columns["CANEDIT"].Caption = "Düzenleyebilir";
      this.grd_yetki.Columns["CANDELETE"].Caption = "Silebilir";
    }

    private void ins_upd_yetkiler(string grupid)
    {
      for (int dataSourceIndex = 0; dataSourceIndex < this.grd_yetki.RowCount; ++dataSourceIndex)
        _main.komutcalistir("IF EXISTS (SELECT ID FROM YETKILER WHERE GRUPID = " + grupid + " AND MODUL = '" + this.grd_yetki.GetRowCellValue(this.grd_yetki.GetRowHandle(dataSourceIndex), "MODUL") + "') BEGIN UPDATE YETKILER SET CANBROWSE = '" + this.grd_yetki.GetRowCellValue(this.grd_yetki.GetRowHandle(dataSourceIndex), "CANBROWSE") + "',CANINSERT = '" + this.grd_yetki.GetRowCellValue(this.grd_yetki.GetRowHandle(dataSourceIndex), "CANINSERT") + "',CANEDIT = '" + this.grd_yetki.GetRowCellValue(this.grd_yetki.GetRowHandle(dataSourceIndex), "CANEDIT") + "',CANDELETE = '" + this.grd_yetki.GetRowCellValue(this.grd_yetki.GetRowHandle(dataSourceIndex), "CANDELETE") + "' WHERE GRUPID = " + grupid + " AND MODUL = '" + this.grd_yetki.GetRowCellValue(this.grd_yetki.GetRowHandle(dataSourceIndex), "MODUL") + "' END " + "ELSE BEGIN INSERT INTO YETKILER (MODUL,CANBROWSE,CANINSERT,CANEDIT,CANDELETE,GRUPID) VALUES ('" + this.grd_yetki.GetRowCellValue(this.grd_yetki.GetRowHandle(dataSourceIndex), "MODUL") + "','" + this.grd_yetki.GetRowCellValue(this.grd_yetki.GetRowHandle(dataSourceIndex), "CANBROWSE") + "','" + this.grd_yetki.GetRowCellValue(this.grd_yetki.GetRowHandle(dataSourceIndex), "CANINSERT") + "','" + this.grd_yetki.GetRowCellValue(this.grd_yetki.GetRowHandle(dataSourceIndex), "CANEDIT") + "','" + this.grd_yetki.GetRowCellValue(this.grd_yetki.GetRowHandle(dataSourceIndex), "CANDELETE") + "'," + grupid + ") END ");
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
      this.txt_grupad = new TextEdit();
      this.labelControl1 = new LabelControl();
      this.btn_kaydet = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.lst_users = new ListBoxControl();
      this.lst_grup_users = new ListBoxControl();
      this.groupBox2 = new GroupBox();
      this.labelControl3 = new LabelControl();
      this.labelControl2 = new LabelControl();
      this.ep1 = new ErrorProvider(this.components);
      this.dtg_yetki = new GridControl();
      this.grd_yetki = new GridView();
      this.groupBox1 = new GroupBox();
      this.txt_grupad.Properties.BeginInit();
      ((ISupportInitialize) this.lst_users).BeginInit();
      ((ISupportInitialize) this.lst_grup_users).BeginInit();
      this.groupBox2.SuspendLayout();
      ((ISupportInitialize) this.ep1).BeginInit();
      this.dtg_yetki.BeginInit();
      this.grd_yetki.BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.txt_grupad.Location = new Point(68, 20);
      this.txt_grupad.Name = "txt_grupad";
      this.txt_grupad.Size = new Size(173, 20);
      this.txt_grupad.TabIndex = 1;
      this.labelControl1.Location = new Point(14, 23);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new Size(48, 13);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "Grup Adı :";
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(12, 388);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 26;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(98, 388);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 27;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.lst_users.Location = new Point(328, 65);
      this.lst_users.Name = "lst_users";
      this.lst_users.Size = new Size(245, 287);
      this.lst_users.TabIndex = 29;
      this.lst_users.MouseDoubleClick += new MouseEventHandler(this.lst_users_MouseDoubleClick);
      this.lst_grup_users.Location = new Point(12, 65);
      this.lst_grup_users.Name = "lst_grup_users";
      this.lst_grup_users.Size = new Size(229, 287);
      this.lst_grup_users.TabIndex = 30;
      this.lst_grup_users.MouseDoubleClick += new MouseEventHandler(this.lst_grup_users_MouseDoubleClick);
      this.groupBox2.Controls.Add((Control) this.labelControl3);
      this.groupBox2.Controls.Add((Control) this.labelControl2);
      this.groupBox2.Controls.Add((Control) this.txt_grupad);
      this.groupBox2.Controls.Add((Control) this.labelControl1);
      this.groupBox2.Controls.Add((Control) this.lst_users);
      this.groupBox2.Controls.Add((Control) this.lst_grup_users);
      this.groupBox2.Location = new Point(12, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(584, 365);
      this.groupBox2.TabIndex = 31;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Grup Tanımı";
      this.labelControl3.Location = new Point(81, 49);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new Size(76, 13);
      this.labelControl3.TabIndex = 32;
      this.labelControl3.Text = "Grup kullanıcıları";
      this.labelControl2.Location = new Point(404, 49);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new Size(92, 13);
      this.labelControl2.TabIndex = 31;
      this.labelControl2.Text = "Grup dışı kullanıcılar";
      this.ep1.ContainerControl = (ContainerControl) this;
      this.dtg_yetki.Dock = DockStyle.Fill;
      this.dtg_yetki.Location = new Point(3, 17);
      this.dtg_yetki.MainView = (BaseView) this.grd_yetki;
      this.dtg_yetki.Name = "dtg_yetki";
      this.dtg_yetki.Size = new Size(480, 345);
      this.dtg_yetki.TabIndex = 32;
      this.dtg_yetki.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_yetki
      });
      this.grd_yetki.Appearance.HeaderPanel.Options.UseTextOptions = true;
      this.grd_yetki.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
      this.grd_yetki.GridControl = this.dtg_yetki;
      this.grd_yetki.Name = "grd_yetki";
      this.grd_yetki.OptionsCustomization.AllowFilter = false;
      this.grd_yetki.OptionsCustomization.AllowSort = false;
      this.grd_yetki.OptionsMenu.EnableColumnMenu = false;
      this.grd_yetki.OptionsView.ShowGroupPanel = false;
      this.groupBox1.Controls.Add((Control) this.dtg_yetki);
      this.groupBox1.Location = new Point(614, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(486, 365);
      this.groupBox1.TabIndex = 33;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Yetkiler";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1112, 433);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Controls.Add((Control) this.btn_iptal);
      this.MinimizeBox = false;
      this.Name = nameof (GrupFrm);
      this.Text = "Grup Tanımı";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.GrupFrm_Load);
      this.txt_grupad.Properties.EndInit();
      ((ISupportInitialize) this.lst_users).EndInit();
      ((ISupportInitialize) this.lst_grup_users).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((ISupportInitialize) this.ep1).EndInit();
      this.dtg_yetki.EndInit();
      this.grd_yetki.EndInit();
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
