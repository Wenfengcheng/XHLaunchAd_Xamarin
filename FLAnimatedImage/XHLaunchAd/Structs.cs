using System;
using ObjCRuntime;

namespace XHLaunchAd
{
    [Native]
    public enum XHLaunchAdImageOptions : ulong
    {
        Default = 1 << 0,
        OnlyLoad = 1 << 1,
        RefreshCached = 1 << 2,
        CacheInBackground = 1 << 3
    }

    [Native]
    public enum ShowFinishAnimate : long
    {
        None = 1,
        Fadein = 2,
        Lite = 3,
        FlipFromLeft = 4,
        FlipFromBottom = 5,
        CurlUp = 6
    }

    [Native]
    public enum SourceType : long
    {
        Image = 1,
        Screen = 2
    }

    [Native]
    public enum LaunchImagesSource : long
    {
        Image = 1,
        Screen = 2
    }

    [Native]
    public enum SkipType : long
    {
        None = 1,
        Time = 2,
        Text = 3,
        TimeText = 4,
        RoundTime = 5,
        RoundText = 6,
        RoundProgressTime = 7,
        RoundProgressText = 8
    }
}
