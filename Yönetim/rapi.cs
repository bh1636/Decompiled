// Decompiled with JetBrains decompiler
// Type: Yönetim.rapi
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace Yönetim
{
  public class rapi
  {
    public const short INVALID_HANDLE_VALUE = -1;
    public const int GENERIC_WRITE = 1073741824;
    public const short CREATE_NEW = 1;
    public const short CREATE_ALWAYS = 2;
    public const short OPEN_EXISTING = 3;
    public const short ERROR_FILE_EXISTS = 80;
    public const short ERROR_INVALID_PARAMETER = 87;
    public const short ERROR_DISK_FULL = 112;
    private ProgressBar progBar;
    private Label m_infoLabel;
    public short FILE_ATTRIBUTE_NORMAL;
    public int GENERIC_READ;

    public rapi()
    {
      this.FILE_ATTRIBUTE_NORMAL = (short) 128;
      this.GENERIC_READ = int.MinValue;
    }

    [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
    private static extern int CeCloseHandle(int hobject);

    [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
    private static extern int CeCreateFile(
      string lpfilename,
      int dwDesiredAccess,
      int dwShareMode,
      int lpSecurityAttributes,
      int dwCreationDisposition,
      int dwFlagsAndAttributes,
      int hTemplatefile);

    [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
    private static extern long CeRapiInitEx(rapi.RAPIINIT prapiinit);

    [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
    private static extern int CeRapiInit();

    [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
    private static extern int CeRapiUninit();

    [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
    private static extern int CeReadFile(
      int hFile,
      byte[] lpBuffer,
      int nNumberOfBytesToRead,
      ref int lpNumberOfBytesRead,
      int lpOverlapped);

    [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
    private static extern int CeWriteFile(
      int hFile,
      byte[] lpBuffer,
      int nNumberofbytestoWrite,
      ref int lpNumberofBytesWritten,
      int lpOverlapped);

    [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
    private static extern int GetLastError();

    [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
    private static extern int CeSetEndOfFile(int hFile);

    [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
    private static extern int CeGetFileSize(int hFile, int lpFileSizeHigh);

    [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
    private static extern int CeGetLastError();

    [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
    private static extern int CeCreateProcess(
      string Filename,
      string param,
      int procAttr,
      int threadAttr,
      int boolh,
      int creFlags,
      int env,
      string curDir,
      int si,
      ref rapi.PROCESSINFO pi);

    [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
    private static extern int CeCreateDirectory(string lpPathName, int lpSecurityAttributes);

    private void CallBack(int bytesCopied, int totalBytes)
    {
      if (this.progBar == null)
        return;
      this.progressBar.Maximum = totalBytes;
      this.progressBar.Value = bytesCopied;
    }

    public bool PPCConnected()
    {
      int num = rapi.CeRapiInit();
      rapi.CeRapiUninit();
      return Conversions.ToBoolean(Interaction.IIf(num == 0, (object) true, (object) false));
    }

    public bool copyFileToPDA(string deskTopFileName, string PDAFileName)
    {
      if (this.progressBar != null)
        this.progressBar.Visible = true;
      if (this.InfoLabel != null)
      {
        this.InfoLabel.Text = "Copy desktop file: " + deskTopFileName + " to PDA as " + PDAFileName;
        this.InfoLabel.Visible = true;
        this.InfoLabel.Update();
      }
      bool pda = this.copyFileToPDA(deskTopFileName, PDAFileName, (rapi.CopyFileCallBack) null);
      if (this.progressBar != null)
        this.progressBar.Visible = false;
      if (this.InfoLabel != null)
        this.InfoLabel.Visible = false;
      return pda;
    }

    public int GetFileSize(string PDAFileName)
    {
      rapi.CeRapiInit();
      int fileSize = rapi.CeGetFileSize(rapi.CeCreateFile(PDAFileName, this.GENERIC_READ, 0, 0, 3, (int) this.FILE_ATTRIBUTE_NORMAL, 0), 0);
      rapi.CeRapiUninit();
      return fileSize;
    }

    public bool copyFileToDesktop(string deskTopFileName, string PDAFileName)
    {
      if (this.progressBar != null)
        this.progressBar.Visible = true;
      if (this.InfoLabel != null)
      {
        this.InfoLabel.Text = "Copy PDAfile " + PDAFileName + " to Desktop as " + deskTopFileName;
        this.InfoLabel.Visible = true;
        this.InfoLabel.Update();
      }
      bool desktop = this.copyFileToDesktop(deskTopFileName, PDAFileName, (rapi.CopyFileCallBack) null);
      if (this.progressBar != null)
        this.progressBar.Visible = false;
      if (this.InfoLabel != null)
        this.InfoLabel.Visible = false;
      return desktop;
    }

    public bool copyFileToPDA(string deskTopFileName, string PDAFileName, rapi.CopyFileCallBack cb)
    {
      int num1 = 32768;
      byte[] numArray = new byte[num1 + 1];
      rapi.CeRapiInit();
      int file = rapi.CeCreateFile(PDAFileName, this.GENERIC_READ | 1073741824, 0, 0, 2, (int) this.FILE_ATTRIBUTE_NORMAL, 0);
      FileStream input = new FileStream(deskTopFileName, FileMode.Open, FileAccess.Read);
      int length = (int) input.Length;
      int bytesCopied = 0;
      int num2 = num1;
      if (length < num1)
        num2 = length;
      BinaryReader binaryReader = new BinaryReader((Stream) input);
      while (bytesCopied < length)
      {
        int lpNumberofBytesWritten = 0;
        byte[] lpBuffer = binaryReader.ReadBytes(num2);
        rapi.CeWriteFile(file, lpBuffer, num2, ref lpNumberofBytesWritten, 0);
        bytesCopied += num2;
        if (length - bytesCopied < num1)
          num2 = length - bytesCopied;
        if (cb != null)
          cb(bytesCopied, length);
        else
          this.CallBack(bytesCopied, length);
      }
      rapi.CeCloseHandle(file);
      rapi.CeRapiUninit();
      binaryReader.Close();
      return true;
    }

    public bool copyFileToDesktop(
      string deskTopFileName,
      string PDAFileName,
      rapi.CopyFileCallBack cb)
    {
      int num1 = 32768;
      byte[] numArray = new byte[num1 + 1];
      rapi.CeRapiInit();
      try
      {
        FileStream fileStream = new FileStream(deskTopFileName, FileMode.Create, FileAccess.Write);
        int lpNumberOfBytesRead = num1;
        int file = rapi.CeCreateFile(PDAFileName, this.GENERIC_READ, 0, 0, 3, (int) this.FILE_ATTRIBUTE_NORMAL, 0);
        int fileSize = rapi.CeGetFileSize(file, 0);
        int nNumberOfBytesToRead = num1;
        int bytesCopied = 0;
        while (lpNumberOfBytesRead > 0)
        {
          rapi.CeReadFile(file, numArray, nNumberOfBytesToRead, ref lpNumberOfBytesRead, 0);
          fileStream.Write(numArray, 0, lpNumberOfBytesRead);
          bytesCopied += lpNumberOfBytesRead;
          if (cb != null)
            cb(bytesCopied, fileSize);
          else
            this.CallBack(bytesCopied, fileSize);
        }
        fileStream.Close();
        rapi.CeCloseHandle(file);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num2 = (int) MessageBox.Show(ex.Message);
        ProjectData.ClearProjectError();
      }
      rapi.CeRapiUninit();
      return true;
    }

    public bool CreateDirectory(string Path)
    {
      rapi.CeRapiInit();
      Path = Strings.Left(Path, Strings.Len(Path) - 1);
      int directory = rapi.CeCreateDirectory(Path, 0);
      rapi.CeRapiUninit();
      return directory != 0;
    }

    public bool RunPDAProgram(string fileName, [Optional] string CmdLine)
    {
      rapi.PROCESSINFO pi = new rapi.PROCESSINFO();
      rapi.CeRapiInit();
      int num = Operators.CompareString(CmdLine, string.Empty, false) != 0 ? rapi.CeCreateProcess(fileName, CmdLine, 0, 0, 0, 0, 0, (string) null, 0, ref pi) : rapi.CeCreateProcess(fileName, (string) null, 0, 0, 0, 0, 0, (string) null, 0, ref pi);
      rapi.CeRapiUninit();
      return num == 0;
    }

    public ProgressBar progressBar
    {
      get => this.progBar;
      set => this.progBar = value;
    }

    public Label InfoLabel
    {
      get => this.m_infoLabel;
      set => this.m_infoLabel = value;
    }

    public delegate void CopyFileCallBack(int bytesCopied, int totalBytes);

    public struct OSVERSIONINFO
    {
      public int dwOSVersionInfoSize;
      public int dwMajorVersion;
      public int dwMinorVersion;
      public int dwBuildNumber;
      public int dwPlatformId;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
      public string szCSDVersion;
    }

    public struct RAPIINIT
    {
      public int cbSize;
      public int heRapiInit;
      public int hrRapiInit;
    }

    public struct SECURITY_ATTRIBUTES
    {
      public int nLength;
      public int lpSecurityDescriptor;
      public int bInheritHandle;
    }

    public struct PROCESSINFO
    {
      public IntPtr hProcess;
      public IntPtr hThread;
      public IntPtr dwProcessId;
      public IntPtr dwThreadId;
    }
  }
}
