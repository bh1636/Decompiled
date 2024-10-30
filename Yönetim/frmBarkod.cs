// Decompiled with JetBrains decompiler
// Type: Yönetim.frmBarkod
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Yönetim
{
  public class frmBarkod : Form
  {
    public string sTOKkoD = "";
    private IContainer components = (IContainer) null;
    private Label label1;
    private TextBox textBox1;
    private Label label2;
    private TextBox textBox2;
    private Button button1;

    public frmBarkod() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
      SqlCommand mCommand = new SqlCommand();
      mCommand.CommandText = "INSERT INTO  [BARKOD_TANIMLARI]\r\n           (\r\n            bar_Recno\r\n           ,bar_stokkod\r\n           ,bar_kodu\r\n           ,bar_birim)\r\n     VALUES\r\n           (0,\r\n            @KOD\r\n           ,@barkod\r\n           ,@birim\r\n            )";
      mCommand.Parameters.AddWithValue("@KOD", (object) this.sTOKkoD);
      mCommand.Parameters.AddWithValue("@birim", (object) this.textBox2.Text);
      mCommand.Parameters.AddWithValue("@barkod", (object) this.textBox1.Text);
      DBManager.sqlRunCommand(mCommand);
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.textBox1 = new TextBox();
      this.label2 = new Label();
      this.textBox2 = new TextBox();
      this.button1 = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(13, 21);
      this.label1.Margin = new Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(70, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Barkodu :";
      this.textBox1.Location = new Point(91, 14);
      this.textBox1.Margin = new Padding(4, 4, 4, 4);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(208, 23);
      this.textBox1.TabIndex = 1;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(13, 50);
      this.label2.Margin = new Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(48, 16);
      this.label2.TabIndex = 0;
      this.label2.Text = "Birim :";
      this.textBox2.Location = new Point(91, 43);
      this.textBox2.Margin = new Padding(4, 4, 4, 4);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(208, 23);
      this.textBox2.TabIndex = 2;
      this.button1.Location = new Point(91, 73);
      this.button1.Name = "button1";
      this.button1.Size = new Size(208, 32);
      this.button1.TabIndex = 3;
      this.button1.Text = "Kayıt Et";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(323, 117);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.Margin = new Padding(4, 4, 4, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmBarkod);
      this.Text = "Barkod Ekleme";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
