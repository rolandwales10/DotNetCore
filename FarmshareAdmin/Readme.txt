Provides admin functions for Senior Farmshare

to do:
get senior living facilities delete and index up to date with logging best practice

Created as a .net core 3.1 application using Studio 2022.
Project type is a .net core web razor pages app.

Software Features:
- When an error is trapped, logs all inner exceptions.  See Utilities.Error
- When data is saved, logs exceptions.  See BusinessAreaLayer.UnitOfWork
- Use of generic methods to update and insert rows in the database.  See BusinessAreaLayer.GenericRepository
- Role based Active Directory security. See Pages.BasePage
- Read configuration values in program.cs: builder.Configuration.GetValue<string>("Environment");
- Read configuration values in a controller: _config.GetValue<string>("Environment");
- Using the built in logging class to log to a file using Serilog.
https://github.com/serilog/serilog/wiki/Provided-Sinks
https://github.com/serilog/serilog-sinks-file
- An API call in Razor Pages.  Called in FarmAllocation/Manage.

Issues:
For Vue 3, we need @Scripts.Render in the cshtml.  Did not succeed in getting this to work.
Did not succeed in writing logs to a database table.  Here is an attempt:

var logDB = "Server=localhost;Database=ACF_Farmshare;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
var sinkOpts = new MSSqlServerSinkOptions();
sinkOpts.TableName = "Logs";
var columnOpts = new ColumnOptions();
columnOpts.Store.Remove(StandardColumn.Properties);
columnOpts.Store.Add(StandardColumn.LogEvent);
columnOpts.LogEvent.DataLength = 2048;
columnOpts.TimeStamp.NonClusteredIndex = true;

var log = new LoggerConfiguration()
    .WriteTo.MSSqlServer(
        connectionString: logDB,
        sinkOptions: sinkOpts,
        columnOptions: columnOpts
    ).CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(log);

to do:
async methods
get the environment
Data namespace
