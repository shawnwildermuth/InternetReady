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
  var filePath = logName.ParsedValue;
  if (log.HasValue() && !string.IsNullOrWhiteSpace(filePath))
  {
    var path = Path.Combine(Environment.CurrentDirectory, filePath);
    File.AppendAllText(path, message);
  }
}