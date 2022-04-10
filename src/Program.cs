using System.Net;
using System.Net.NetworkInformation;
using McMaster.Extensions.CommandLineUtils;
using static System.Console;

var app = new CommandLineApplication();


app.HelpOption();
app.Description = "Internet Connection Tester";
app.ShowInHelpText = false;
app.FullName = "InternetReady.exe";
app.Name = "InternetReady";

CommandOption<string> testDomain = app.Option<string>("-t|--testdomain <TestDomain>",
  "Domain to use to Test for Internet (domain must support pinging)",
  CommandOptionType.SingleValue,
  cfg =>
  {
    cfg.DefaultValue = "google.com";
  });

CommandOption<bool> log = app.Option<bool>("-l|--log",
  "Log Results",
  CommandOptionType.NoValue,
  cfg => cfg.DefaultValue = false);

CommandOption<bool> clearLog = app.Option<bool>("--clear-log",
  "Clear log file before starting",
  CommandOptionType.NoValue,
  cfg => cfg.DefaultValue = false);


CommandOption<string> logName = app.Option<string>("-o|--output <FilePath>",
  "Log File Path",
  CommandOptionType.SingleValue, cfg =>
  {
    cfg.DefaultValue = "./internetready.log";
  });

CommandOption<int> interval = app.Option<int>("-i|--interval <TimeInMS>",
  "Time between attempts (in milliseconds)",
  CommandOptionType.SingleValue, cfg =>
  {
    cfg.DefaultValue = 5000;
  });

app.OnExecute(() =>
{
  using var p = new Ping();

  int tries = 0;
  
  WriteLine($"Testing Internet Connection Pinging {testDomain.ParsedValue}");

  // Delete Log if log is enabled and have specified clear log
  if (log.ParsedValue && clearLog.ParsedValue)
  {
    File.Delete(Path.Combine(Environment.CurrentDirectory, logName.ParsedValue));
  }

  while (true)
  {
    try
    { 
      IPHostEntry entry = Dns.GetHostEntry(testDomain.ParsedValue);
      foreach (var addr in entry.AddressList)
      {
        PingReply reply = p.Send(addr, 1000);
        if (reply.Status == IPStatus.Success)
        {
          var message = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - Ping to {testDomain.ParsedValue} succeeded.{Environment.NewLine}";
          // Log Success and exit.
          LogIfNecessary(message);
          WriteLine();
          WriteLine(message);
          Beep();
          Thread.Sleep(50);
          Beep();
          Thread.Sleep(50);
          Beep();
          Thread.Sleep(50);
          return 0;
        }
      }
    }
    catch
    {
      // Ignore Errors
    }

    // Log failure
    LogIfNecessary($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - Ping to {testDomain.ParsedValue} Failed.{Environment.NewLine}");

    // Show Status
    tries++;
    if (tries > 24)
    {
      WriteLine();
      tries = 0;
    }
    Write("-");

    // Wait and Try again
    Thread.Sleep(interval.ParsedValue);

  }
});

return app.Execute(args);

void LogIfNecessary(string message)
{
  if (log.ParsedValue && !string.IsNullOrWhiteSpace(logName.ParsedValue))
  {
    var path = Path.Combine(Environment.CurrentDirectory, logName.ParsedValue);
    File.AppendAllText(path, message);
  }
}