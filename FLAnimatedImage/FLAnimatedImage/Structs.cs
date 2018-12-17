using System;
using ObjCRuntime;

namespace FLAnimatedImage
{
    [Native]
    public enum FLLogLevel : ulong
    {
        None = 0,
        Error,
        Warn,
        Info,
        Debug,
        Verbose
    }
}
