using System;
using System.ComponentModel;
using CoreGraphics;
using FLAnimatedImage;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace FLAnimatedImage
{
    // @interface FLAnimatedImageView : UIImageView
    [BaseType(typeof(UIImageView))]
    interface FLAnimatedImageView
    {
        // @property (nonatomic, strong) FLAnimatedImage * animatedImage;
        [Export("animatedImage", ArgumentSemantic.Strong)]
        FLAnimatedImage AnimatedImage { get; set; }

        // @property (copy, nonatomic) void (^loopCompletionBlock)(NSUInteger);
        [Export("loopCompletionBlock", ArgumentSemantic.Copy)]
        Action<nuint> LoopCompletionBlock { get; set; }

        // @property (readonly, nonatomic, strong) UIImage * currentFrame;
        [Export("currentFrame", ArgumentSemantic.Strong)]
        UIImage CurrentFrame { get; }

        // @property (readonly, assign, nonatomic) NSUInteger currentFrameIndex;
        [Export("currentFrameIndex")]
        nuint CurrentFrameIndex { get; }

        // @property (copy, nonatomic) NSString * runLoopMode;
        [Export("runLoopMode")]
        string RunLoopMode { get; set; }
    }

    [Static]
    partial interface FLAnimatedImageDelayTime
    {
        // extern const NSTimeInterval kFLAnimatedImageDelayTimeIntervalMinimum;
        [Field("kFLAnimatedImageDelayTimeIntervalMinimum", "__Internal")]
        double IntervalMinimum { get; }
    }

    // @interface FLAnimatedImage : NSObject
    [BaseType(typeof(NSObject))]
    interface FLAnimatedImage
    {
        // @property (readonly, nonatomic, strong) UIImage * posterImage;
        [Export("posterImage", ArgumentSemantic.Strong)]
        UIImage PosterImage { get; }

        // @property (readonly, assign, nonatomic) CGSize size;
        [Export("size", ArgumentSemantic.Assign)]
        CGSize Size { get; }

        // @property (readonly, assign, nonatomic) NSUInteger loopCount;
        [Export("loopCount")]
        nuint LoopCount { get; }

        // @property (readonly, nonatomic, strong) NSDictionary * delayTimesForIndexes;
        [Export("delayTimesForIndexes", ArgumentSemantic.Strong)]
        NSDictionary DelayTimesForIndexes { get; }

        // @property (readonly, assign, nonatomic) NSUInteger frameCount;
        [Export("frameCount")]
        nuint FrameCount { get; }

        // @property (readonly, assign, nonatomic) NSUInteger frameCacheSizeCurrent;
        [Export("frameCacheSizeCurrent")]
        nuint FrameCacheSizeCurrent { get; }

        // @property (assign, nonatomic) NSUInteger frameCacheSizeMax;
        [Export("frameCacheSizeMax")]
        nuint FrameCacheSizeMax { get; set; }

        // -(UIImage *)imageLazilyCachedAtIndex:(NSUInteger)index;
        [Export("imageLazilyCachedAtIndex:")]
        UIImage ImageLazilyCachedAtIndex(nuint index);

        // +(CGSize)sizeForImage:(id)image;
        [Static]
        [Export("sizeForImage:")]
        CGSize SizeForImage(NSObject image);

        // -(instancetype)initWithAnimatedGIFData:(NSData *)data;
        [Export("initWithAnimatedGIFData:")]
        IntPtr Constructor(NSData data);

        // -(instancetype)initWithAnimatedGIFData:(NSData *)data optimalFrameCacheSize:(NSUInteger)optimalFrameCacheSize predrawingEnabled:(BOOL)isPredrawingEnabled __attribute__((objc_designated_initializer));
        [Export("initWithAnimatedGIFData:optimalFrameCacheSize:predrawingEnabled:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSData data, nuint optimalFrameCacheSize, bool isPredrawingEnabled);

        // +(instancetype)animatedImageWithGIFData:(NSData *)data;
        [Static]
        [Export("animatedImageWithGIFData:")]
        FLAnimatedImage AnimatedImageWithGIFData(NSData data);

        // @property (readonly, nonatomic, strong) NSData * data;
        [Export("data", ArgumentSemantic.Strong)]
        NSData Data { get; }
    }

    // @interface Logging (FLAnimatedImage)
    [Category]
    [BaseType(typeof(FLAnimatedImage))]
    interface FLAnimatedImage_Logging
    {
        // +(void)setLogBlock:(void (^)(NSString *, FLLogLevel))logBlock logLevel:(FLLogLevel)logLevel;
        [Static]
        [Export("setLogBlock:logLevel:")]
        void SetLogBlock(Action<NSString, FLLogLevel> logBlock, FLLogLevel logLevel);

        // +(void)logStringFromBlock:(NSString *(^)(void))stringBlock withLevel:(FLLogLevel)level;
        [Static]
        [Export("logStringFromBlock:withLevel:")]
        void LogStringFromBlock(Func<NSString> stringBlock, FLLogLevel level);
    }

    // @interface FLWeakProxy : NSProxy
    [BaseType(typeof(NSObject))]
    interface FLWeakProxy
    {
        // +(instancetype)weakProxyForObject:(id)targetObject;
        [Static]
        [Export("weakProxyForObject:")]
        FLWeakProxy WeakProxyForObject(NSObject targetObject);
    }
}