#define LOGRESULTS
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;

namespace InternetReady
{
  /// <summary>
  /// Main form for the app.
  /// </summary>
  public partial class MainForm : Form
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:MainForm"/> class.
    /// </summary>
    public MainForm()
    {
      InitializeComponent();
    }

    const string filename = "results.log";
    bool _isDown = false;

    /// <summary>
    /// Does the ping.
    /// </summary>
    /// <returns></returns>
    bool DoPing()
    {
#if LOGRESULTS
      using (FileStream strm = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
      using (StreamWriter writer = new StreamWriter(strm))
#endif
      using (Ping p = new Ping())
      {
        try
        {
          IPHostEntry entry = Dns.GetHostEntry(addressBox.Text);
          PingReply reply = p.Send(entry.AddressList[0], 10000);
          if (reply.Status == IPStatus.Success)
          {
#if LOGRESULTS
            strm.Position = strm.Length;
            writer.WriteLine(string.Format("{0:yyyy-MM-dd HH:mm:ss} - Ping to {1} succeeded.", DateTime.Now, addressBox.Text));
            writer.Close();
            strm.Close();
#endif
            return true;
          }
        }
        catch
        {
          // NOOP
        }

#if LOGRESULTS
        strm.Position = strm.Length;
        writer.WriteLine(string.Format("{0:yyyy-MM-dd HH:mm:ss} - Ping to {1} failed.", DateTime.Now, addressBox.Text));
        writer.Close();
        strm.Close();
#endif
        return false;
      }
    }

    /// <summary>
    /// Handles the Tick event of the monitorTimer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    private void monitorTimer_Tick(object sender, EventArgs e)
    {
      monitorTimer.Enabled = false;
      monitorWorker.RunWorkerAsync();
    }

    /// <summary>
    /// Handles the Load event of the MainForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    private void MainForm_Load(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// Handles the DoWork event of the monitorWorker control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
    private void monitorWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      e.Result = DoPing();
    }

    /// <summary>
    /// Handles the RunWorkerCompleted event of the monitorWorker control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
    private void monitorWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if ((bool)e.Result)
      {
        Icon = Properties.Resources.UpIcon;
        if (_isDown && alertMeCheckbox.Checked)
        {
          new ItsUpDialog().Show();
        }
        _isDown = false;
        monitorTimer.Interval = 30000;
      }
      else
      {
        Icon = Properties.Resources.DownIcon;
        monitorTimer.Interval = 5000;
        _isDown = true;
      }

      monitorTimer.Enabled = true;
    }

    /// <summary>
    /// Handles the Click event of the logButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    private void logButton_Click(object sender, EventArgs e)
    {
      System.Diagnostics.Process proc = System.Diagnostics.Process.Start(filename);
    }

    private void checkNowButton_Click(object sender, EventArgs e)
    {
      monitorTimer.Interval = 250;
    }

  }
}