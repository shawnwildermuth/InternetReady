using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InternetReady
{

  /// <summary>
  /// The form that shows the success
  /// </summary>
  public partial class ItsUpDialog : Form
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:ItsUpDialog"/> class.
    /// </summary>
    public ItsUpDialog()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Handles the Click event of the closeButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    void closeButton_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}