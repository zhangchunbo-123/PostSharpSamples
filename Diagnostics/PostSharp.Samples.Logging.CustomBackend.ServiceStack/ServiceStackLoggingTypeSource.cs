using PostSharp.Patterns.Diagnostics;
using ServiceStack.Logging;
using System;

namespace PostSharp.Samples.Logging.CustomBackend.ServiceStack
{
  public class ServiceStackLoggingTypeSource : LoggingTypeSource
  {
    public ServiceStackLoggingTypeSource(LoggingNamespaceSource parent, string name, Type sourceType)
      : base(parent, name, sourceType )
    {
      Log = LogManager.GetLogger(sourceType);
    }

    public ILog Log { get; }

    protected override bool IsBackendEnabled(LogLevel level)
    {
      switch (level)
      {
        case LogLevel.Trace:
        case LogLevel.Debug:
          return Log.IsDebugEnabled;

        default:
          return true;
      }
    }
  }
}