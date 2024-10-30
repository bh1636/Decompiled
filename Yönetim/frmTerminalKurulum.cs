// Decompiled with JetBrains decompiler
// Type: Yönetim.frmTerminalKurulum
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Yönetim.Properties;

#nullable disable
namespace Yönetim
{
  public class frmTerminalKurulum : Form
  {
    private IContainer components = (IContainer) null;
    private Button button1;
    private Label label1;
    private ProgressBar progressBar1;
    internal RadioButton rdp5;
    internal RadioButton rdp42;
    internal RadioButton rVersiyon;

    public frmTerminalKurulum() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
      this.button1.Enabled = false;
      rapi rapi = new rapi();
      this.button1.Text = "Bağlantı Kuruluyor..";
      if (rapi.PPCConnected())
      {
        this.button1.Text = "Bağlantı Kuruldu..";
        if (this.rdp42.Checked)
          this.Ce4_2(rapi);
        if (this.rdp5.Checked)
          this.Ce5(rapi);
        if (this.rVersiyon.Checked)
          this.update(rapi);
        this.button1.Text = "Kurulum Tamamlandı";
      }
      this.button1.Enabled = true;
    }

    public void update(rapi rapi_)
    {
      string str = "\\Flash Disk";
      string[] files = Directory.GetFiles(Application.StartupPath + "\\Ce\\");
      for (int index = 0; index <= files.Length - 1; ++index)
      {
        FileInfo fileInfo = new FileInfo(files[index]);
        rapi_.progressBar = this.progressBar1;
        rapi_.copyFileToPDA(files[index], str + "\\" + fileInfo.Name);
      }
    }

    private void Ce5(rapi kuru)
    {
      kuru.progressBar = this.progressBar1;
      kuru.copyFileToPDA(Application.StartupPath + "\\Cabs\\ExtraSiparis.cab", "\\ExtraSiparis.cab");
      kuru.RunPDAProgram("\\windows\\wceload.exe", "/noaskdest \\ExtraSiparis.cab");
      int num = (int) MessageBox.Show("Terminal Ekranından Kurulumu Tamamladıkdan Sonra \"Tamam\" Basınız", "Onay");
    }

    private void Ce4_2(rapi rapi_)
    {
      rapi_.progressBar = this.progressBar1;
      rapi_.copyFileToPDA(Application.StartupPath + "\\Cabs\\NETCFv2.wce4.ARMV4.cab", "\\NETCFv2.wce4.ARMV4.cab");
      rapi_.RunPDAProgram("\\windows\\wceload.exe", "/noaskdest \\NETCFv2.wce4.ARMV4.cab");
      int num1 = (int) MessageBox.Show("Terminal Ekranından Kurulumu Tamamladıkdan Sonra \"Tamam\" Basınız", "Onay");
      rapi_.copyFileToPDA(Application.StartupPath + "\\Cabs\\ExtraSiparis.cab", "\\ExtraSiparis.cab");
      rapi_.RunPDAProgram("\\windows\\wceload.exe", "/noaskdest \\ExtraSiparis.cab");
      int num2 = (int) MessageBox.Show("Terminal Ekranından Kurulumu Tamamladıkdan Sonra \"Tamam\" Basınız", "Onay");
      rapi_.copyFileToPDA(Application.StartupPath + "\\Cabs\\sql.ppc.wce4.armv4.CAB", "\\sql.ppc.wce4.armv4.CAB");
      rapi_.RunPDAProgram("\\windows\\wceload.exe", "/noaskdest \\sql.ppc.wce4.armv4.CAB");
      int num3 = (int) MessageBox.Show("Terminal Ekran1ndan Kurulumu Tamamlad1kdan Sonra \"Tamam\" Bas1n1z", "Onay");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmTerminalKurulum));
      this.label1 = new Label();
      this.progressBar1 = new ProgressBar();
      this.button1 = new Button();
      this.rdp5 = new RadioButton();
      this.rdp42 = new RadioButton();
      this.rVersiyon = new RadioButton();
      this.SuspendLayout();
      this.label1.Dock = DockStyle.Top;
      this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label1.Location = new Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(292, 47);
      this.label1.TabIndex = 1;
      this.label1.Text = "Program Kurulumuna Başlamadan Önce El Terminalini Bağladığınızdan Emin Olunuz.";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.progressBar1.Dock = DockStyle.Bottom;
      this.progressBar1.Location = new Point(0, 171);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(292, 23);
      this.progressBar1.TabIndex = 2;
      this.button1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.button1.Image = (Image) Resources.Setup;
      this.button1.ImageAlign = ContentAlignment.MiddleLeft;
      this.button1.Location = new Point(0, 113);
      this.button1.Name = "button1";
      this.button1.Size = new Size(292, 56);
      this.button1.TabIndex = 0;
      this.button1.Text = "Kurulumu Başlat";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.rdp5.AutoSize = true;
      this.rdp5.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.rdp5.ForeColor = Color.Maroon;
      this.rdp5.Location = new Point(55, 70);
      this.rdp5.Name = "rdp5";
      this.rdp5.Size = new Size(178, 17);
      this.rdp5.TabIndex = 6;
      this.rdp5.Text = "5.0 Os Sistme Programı Kur";
      this.rdp5.UseVisualStyleBackColor = true;
      this.rdp42.AutoSize = true;
      this.rdp42.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.rdp42.ForeColor = Color.Maroon;
      this.rdp42.Location = new Point(55, 50);
      this.rdp42.Name = "rdp42";
      this.rdp42.Size = new Size(178, 17);
      this.rdp42.TabIndex = 5;
      this.rdp42.Text = "4.2 Os Sistme Programı Kur";
      this.rdp42.UseVisualStyleBackColor = true;
      this.rVersiyon.AutoSize = true;
      this.rVersiyon.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.rVersiyon.ForeColor = Color.Red;
      this.rVersiyon.Location = new Point(55, 90);
      this.rVersiyon.Name = "rVersiyon";
      this.rVersiyon.Size = new Size(184, 17);
      this.rVersiyon.TabIndex = 7;
      this.rVersiyon.Text = "Program Versiyonu Güncelle";
      this.rVersiyon.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(292, 194);
      this.Controls.Add((Control) this.rVersiyon);
      this.Controls.Add((Control) this.rdp5);
      this.Controls.Add((Control) this.rdp42);
      this.Controls.Add((Control) this.progressBar1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.button1);
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmTerminalKurulum);
      this.Text = "El Terminali Program Kurulumu";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
