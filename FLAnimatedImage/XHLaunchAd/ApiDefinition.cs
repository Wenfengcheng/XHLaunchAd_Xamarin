using System;
using FLAnimatedImage;
using AVKit;
using CoreGraphics;
using Foundation;
using MediaPlayer;
using ObjCRuntime;
using UIKit;

namespace XHLaunchAd
{
    // typedef void (^XHLaunchAdDownloadProgressBlock)(unsigned long long, unsigned long long);
    delegate void XHLaunchAdDownloadProgressBlock(ulong arg0, ulong arg1);

    // typedef void (^XHLaunchAdDownloadImageCompletedBlock)(UIImage * _Nullable, NSData * _Nullable, NSError * _Nullable);
    delegate void XHLaunchAdDownloadImageCompletedBlock([NullAllowed] UIImage arg0, [NullAllowed] NSData arg1, [NullAllowed] NSError arg2);

    // typedef void (^XHLaunchAdDownloadVideoCompletedBlock)(NSURL * _Nullable, NSError * _Nullable);
    delegate void XHLaunchAdDownloadVideoCompletedBlock([NullAllowed] NSUrl arg0, [NullAllowed] NSError arg1);

    // typedef void (^XHLaunchAdBatchDownLoadAndCacheCompletedBlock)(NSArray * _Nonnull);
    delegate void XHLaunchAdBatchDownLoadAndCacheCompletedBlock(NSObject[] arg0);

    // @protocol XHLaunchAdDownloadDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface XHLaunchAdDownloadDelegate
    {
        // @required -(void)downloadFinishWithURL:(NSURL * _Nonnull)url;
        [Abstract]
        [Export("downloadFinishWithURL:")]
        void DownloadFinishWithURL(NSUrl url);
    }

    // @interface XHLaunchAdDownload : NSObject
    [BaseType(typeof(NSObject))]
    interface XHLaunchAdDownload
    {
        [Wrap("WeakDelegate")]
        XHLaunchAdDownloadDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<XHLaunchAdDownloadDelegate> _Nonnull delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }
    }

    // @interface XHLaunchAdImageDownload : XHLaunchAdDownload
    [BaseType(typeof(XHLaunchAdDownload))]
    interface XHLaunchAdImageDownload
    {
    }

    // @interface XHLaunchAdVideoDownload : XHLaunchAdDownload
    [BaseType(typeof(XHLaunchAdDownload))]
    interface XHLaunchAdVideoDownload
    {
    }

    // @interface XHLaunchAdDownloader : NSObject
    [BaseType(typeof(NSObject))]
    interface XHLaunchAdDownloader
    {
        // +(instancetype _Nonnull)sharedDownloader;
        [Static]
        [Export("sharedDownloader")]
        XHLaunchAdDownloader SharedDownloader();

        // -(void)downloadImageWithURL:(NSURL * _Nonnull)url progress:(XHLaunchAdDownloadProgressBlock _Nullable)progressBlock completed:(XHLaunchAdDownloadImageCompletedBlock _Nullable)completedBlock;
        [Export("downloadImageWithURL:progress:completed:")]
        void DownloadImageWithURL(NSUrl url, [NullAllowed] XHLaunchAdDownloadProgressBlock progressBlock, [NullAllowed] XHLaunchAdDownloadImageCompletedBlock completedBlock);

        // -(void)downLoadImageAndCacheWithURLArray:(NSArray<NSURL *> * _Nonnull)urlArray;
        [Export("downLoadImageAndCacheWithURLArray:")]
        void DownLoadImageAndCacheWithURLArray(NSUrl[] urlArray);

        // -(void)downLoadImageAndCacheWithURLArray:(NSArray<NSURL *> * _Nonnull)urlArray completed:(XHLaunchAdBatchDownLoadAndCacheCompletedBlock _Nullable)completedBlock;
        [Export("downLoadImageAndCacheWithURLArray:completed:")]
        void DownLoadImageAndCacheWithURLArray(NSUrl[] urlArray, [NullAllowed] XHLaunchAdBatchDownLoadAndCacheCompletedBlock completedBlock);

        // -(void)downloadVideoWithURL:(NSURL * _Nonnull)url progress:(XHLaunchAdDownloadProgressBlock _Nullable)progressBlock completed:(XHLaunchAdDownloadVideoCompletedBlock _Nullable)completedBlock;
        [Export("downloadVideoWithURL:progress:completed:")]
        void DownloadVideoWithURL(NSUrl url, [NullAllowed] XHLaunchAdDownloadProgressBlock progressBlock, [NullAllowed] XHLaunchAdDownloadVideoCompletedBlock completedBlock);

        // -(void)downLoadVideoAndCacheWithURLArray:(NSArray<NSURL *> * _Nonnull)urlArray;
        [Export("downLoadVideoAndCacheWithURLArray:")]
        void DownLoadVideoAndCacheWithURLArray(NSUrl[] urlArray);

        // -(void)downLoadVideoAndCacheWithURLArray:(NSArray<NSURL *> * _Nonnull)urlArray completed:(XHLaunchAdBatchDownLoadAndCacheCompletedBlock _Nullable)completedBlock;
        [Export("downLoadVideoAndCacheWithURLArray:completed:")]
        void DownLoadVideoAndCacheWithURLArray(NSUrl[] urlArray, [NullAllowed] XHLaunchAdBatchDownLoadAndCacheCompletedBlock completedBlock);
    }

    // typedef void (^XHExternalCompletionBlock)(UIImage * _Nullable, NSData * _Nullable, NSError * _Nullable, NSURL * _Nullable);
    delegate void XHExternalCompletionBlock([NullAllowed] UIImage arg0, [NullAllowed] NSData arg1, [NullAllowed] NSError arg2, [NullAllowed] NSUrl arg3);

    // @interface XHLaunchAdImageManager : NSObject
    [BaseType(typeof(NSObject))]
    interface XHLaunchAdImageManager
    {
        // +(instancetype _Nonnull)sharedManager;
        [Static]
        [Export("sharedManager")]
        XHLaunchAdImageManager SharedManager();

        // -(void)loadImageWithURL:(NSURL * _Nullable)url options:(XHLaunchAdImageOptions)options progress:(XHLaunchAdDownloadProgressBlock _Nullable)progressBlock completed:(XHExternalCompletionBlock _Nullable)completedBlock;
        [Export("loadImageWithURL:options:progress:completed:")]
        void LoadImageWithURL([NullAllowed] NSUrl url, XHLaunchAdImageOptions options, [NullAllowed] XHLaunchAdDownloadProgressBlock progressBlock, [NullAllowed] XHExternalCompletionBlock completedBlock);
    }

    [Static]
    partial interface Constants
    {
        // extern NSString *const XHCacheImageUrlStringKey __attribute__((visibility("default")));
        [Field("XHCacheImageUrlStringKey", "__Internal")]
        NSString XHCacheImageUrlStringKey { get; }

        // extern NSString *const XHCacheVideoUrlStringKey __attribute__((visibility("default")));
        [Field("XHCacheVideoUrlStringKey", "__Internal")]
        NSString XHCacheVideoUrlStringKey { get; }

        // extern NSString *const XHLaunchAdWaitDataDurationArriveNotification __attribute__((visibility("default")));
        [Field("XHLaunchAdWaitDataDurationArriveNotification", "__Internal")]
        NSString XHLaunchAdWaitDataDurationArriveNotification { get; }

        // extern NSString *const XHLaunchAdDetailPageWillShowNotification __attribute__((visibility("default")));
        [Field("XHLaunchAdDetailPageWillShowNotification", "__Internal")]
        NSString XHLaunchAdDetailPageWillShowNotification { get; }

        // extern NSString *const XHLaunchAdDetailPageShowFinishNotification __attribute__((visibility("default")));
        [Field("XHLaunchAdDetailPageShowFinishNotification", "__Internal")]
        NSString XHLaunchAdDetailPageShowFinishNotification { get; }

        // extern NSString *const XHLaunchAdGIFImageCycleOnceFinishNotification __attribute__((visibility("default")));
        [Field("XHLaunchAdGIFImageCycleOnceFinishNotification", "__Internal")]
        NSString XHLaunchAdGIFImageCycleOnceFinishNotification { get; }

        // extern NSString *const XHLaunchAdVideoCycleOnceFinishNotification __attribute__((visibility("default")));
        [Field("XHLaunchAdVideoCycleOnceFinishNotification", "__Internal")]
        NSString XHLaunchAdVideoCycleOnceFinishNotification { get; }

        // extern NSString *const XHLaunchAdVideoPlayFailedNotification __attribute__((visibility("default")));
        [Field("XHLaunchAdVideoPlayFailedNotification", "__Internal")]
        NSString XHLaunchAdVideoPlayFailedNotification { get; }

        // extern BOOL XHLaunchAdPrefersHomeIndicatorAutoHidden __attribute__((visibility("default")));
        //[Field("XHLaunchAdPrefersHomeIndicatorAutoHidden", "__Internal")]
        //bool XHLaunchAdPrefersHomeIndicatorAutoHidden { get; }
    }

    // @interface XHLaunchAdConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    interface XHLaunchAdConfiguration
    {
        // @property (assign, nonatomic) NSInteger duration;
        [Export("duration")]
        nint Duration { get; set; }

        // @property (assign, nonatomic) SkipType skipButtonType;
        [Export("skipButtonType", ArgumentSemantic.Assign)]
        SkipType SkipButtonType { get; set; }

        // @property (assign, nonatomic) ShowFinishAnimate showFinishAnimate;
        [Export("showFinishAnimate", ArgumentSemantic.Assign)]
        ShowFinishAnimate ShowFinishAnimate { get; set; }

        // @property (assign, nonatomic) CGFloat showFinishAnimateTime;
        [Export("showFinishAnimateTime")]
        nfloat ShowFinishAnimateTime { get; set; }

        // @property (assign, nonatomic) CGRect frame;
        [Export("frame", ArgumentSemantic.Assign)]
        CGRect Frame { get; set; }

        // @property (assign, nonatomic) BOOL showEnterForeground;
        [Export("showEnterForeground")]
        bool ShowEnterForeground { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull openURLString __attribute__((deprecated("请使用openModel,点击事件代理方法请对应使用xhLaunchAd:clickAndOpenModel:clickPoint:")));
        [Export("openURLString")]
        string OpenURLString { get; set; }

        // @property (nonatomic, strong) id _Nonnull openModel;
        [Export("openModel", ArgumentSemantic.Strong)]
        NSObject OpenModel { get; set; }

        // @property (nonatomic, strong) UIView * _Nonnull customSkipView;
        [Export("customSkipView", ArgumentSemantic.Strong)]
        UIView CustomSkipView { get; set; }

        // @property (copy, nonatomic) NSArray<UIView *> * _Nullable subViews;
        [NullAllowed, Export("subViews", ArgumentSemantic.Copy)]
        UIView[] SubViews { get; set; }
    }

    // @interface XHLaunchImageAdConfiguration : XHLaunchAdConfiguration
    [BaseType(typeof(XHLaunchAdConfiguration))]
    interface XHLaunchImageAdConfiguration
    {
        // @property (copy, nonatomic) NSString * _Nonnull imageNameOrURLString;
        [Export("imageNameOrURLString")]
        string ImageNameOrURLString { get; set; }

        // @property (assign, nonatomic) UIViewContentMode contentMode;
        [Export("contentMode", ArgumentSemantic.Assign)]
        UIViewContentMode ContentMode { get; set; }

        // @property (assign, nonatomic) XHLaunchAdImageOptions imageOption;
        [Export("imageOption", ArgumentSemantic.Assign)]
        XHLaunchAdImageOptions ImageOption { get; set; }

        // @property (assign, nonatomic) BOOL GIFImageCycleOnce;
        [Export("GIFImageCycleOnce")]
        bool GIFImageCycleOnce { get; set; }

        // +(XHLaunchImageAdConfiguration * _Nonnull)defaultConfiguration;
        [Static]
        [Export("defaultConfiguration")]
        XHLaunchImageAdConfiguration DefaultConfiguration { get; }
    }

    // @interface XHLaunchVideoAdConfiguration : XHLaunchAdConfiguration
    [BaseType(typeof(XHLaunchAdConfiguration))]
    interface XHLaunchVideoAdConfiguration
    {
        // @property (copy, nonatomic) NSString * _Nonnull videoNameOrURLString;
        [Export("videoNameOrURLString")]
        string VideoNameOrURLString { get; set; }

        // @property (assign, nonatomic) MPMovieScalingMode scalingMode __attribute__((deprecated("请使用videoGravity")));
        [Export("scalingMode", ArgumentSemantic.Assign)]
        MPMovieScalingMode ScalingMode { get; set; }

        // @property (copy, nonatomic) AVLayerVideoGravity _Nonnull videoGravity;
        [Export("videoGravity")]
        string VideoGravity { get; set; }

        // @property (assign, nonatomic) BOOL videoCycleOnce;
        [Export("videoCycleOnce")]
        bool VideoCycleOnce { get; set; }

        // @property (assign, nonatomic) BOOL muted;
        [Export("muted")]
        bool Muted { get; set; }

        // +(XHLaunchVideoAdConfiguration * _Nonnull)defaultConfiguration;
        [Static]
        [Export("defaultConfiguration")]
        XHLaunchVideoAdConfiguration DefaultConfiguration { get; }
    }

    // @interface XHLaunchImageView : UIImageView
    [BaseType(typeof(UIImageView))]
    interface XHLaunchImageView
    {
        // -(instancetype)initWithSourceType:(SourceType)sourceType;
        [Export("initWithSourceType:")]
        IntPtr Constructor(SourceType sourceType);
    }

    // @protocol XHLaunchAdDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface XHLaunchAdDelegate
    {
        // @optional -(void)xhLaunchAd:(XHLaunchAd * _Nonnull)launchAd clickAndOpenModel:(id _Nonnull)openModel clickPoint:(CGPoint)clickPoint;
        [Export("xhLaunchAd:clickAndOpenModel:clickPoint:")]
        void XhLaunchAd(XHLaunchAd launchAd, NSObject openModel, CGPoint clickPoint);

        // @optional -(void)xhLaunchAd:(XHLaunchAd * _Nonnull)launchAd imageDownLoadFinish:(UIImage * _Nonnull)image imageData:(NSData * _Nonnull)imageData;
        [Export("xhLaunchAd:imageDownLoadFinish:imageData:")]
        void XhLaunchAd(XHLaunchAd launchAd, UIImage image, NSData imageData);

        // @optional -(void)xhLaunchAd:(XHLaunchAd * _Nonnull)launchAd videoDownLoadFinish:(NSURL * _Nonnull)pathURL;
        [Export("xhLaunchAd:videoDownLoadFinish:")]
        void XhLaunchAd(XHLaunchAd launchAd, NSUrl pathURL);

        // @optional -(void)xhLaunchAd:(XHLaunchAd * _Nonnull)launchAd videoDownLoadProgress:(float)progress total:(unsigned long long)total current:(unsigned long long)current;
        [Export("xhLaunchAd:videoDownLoadProgress:total:current:")]
        void XhLaunchAd(XHLaunchAd launchAd, float progress, ulong total, ulong current);

        // @optional -(void)xhLaunchAd:(XHLaunchAd * _Nonnull)launchAd customSkipView:(UIView * _Nonnull)customSkipView duration:(NSInteger)duration;
        [Export("xhLaunchAd:customSkipView:duration:")]
        void XhLaunchAd(XHLaunchAd launchAd, UIView customSkipView, nint duration);

        // @optional -(void)xhLaunchAdShowFinish:(XHLaunchAd * _Nonnull)launchAd;
        [Export("xhLaunchAdShowFinish:")]
        void XhLaunchAdShowFinish(XHLaunchAd launchAd);

        // @optional -(void)xhLaunchAd:(XHLaunchAd * _Nonnull)launchAd launchAdImageView:(UIImageView * _Nonnull)launchAdImageView URL:(NSURL * _Nonnull)url;
        [Export("xhLaunchAd:launchAdImageView:URL:")]
        void XhLaunchAd(XHLaunchAd launchAd, UIImageView launchAdImageView, NSUrl url);

        // @optional -(void)xhLaunchAd:(XHLaunchAd * _Nonnull)launchAd clickAndOpenURLString:(NSString * _Nonnull)openURLString __attribute__((deprecated("请使用xhLaunchAd:clickAndOpenModel:clickPoint:")));
        [Export("xhLaunchAd:clickAndOpenURLString:")]
        void XhLaunchAd(XHLaunchAd launchAd, string openURLString);

        // @optional -(void)xhLaunchAd:(XHLaunchAd * _Nonnull)launchAd clickAndOpenURLString:(NSString * _Nonnull)openURLString clickPoint:(CGPoint)clickPoint __attribute__((deprecated("请使用xhLaunchAd:clickAndOpenModel:clickPoint:")));
        [Export("xhLaunchAd:clickAndOpenURLString:clickPoint:")]
        void XhLaunchAd(XHLaunchAd launchAd, string openURLString, CGPoint clickPoint);

        // @optional -(void)xhLaunchAd:(XHLaunchAd * _Nonnull)launchAd imageDownLoadFinish:(UIImage * _Nonnull)image __attribute__((deprecated("请使用xhLaunchAd:imageDownLoadFinish:imageData:")));
        [Export("xhLaunchAd:imageDownLoadFinish:")]
        void XhLaunchAd(XHLaunchAd launchAd, UIImage image);

        // @optional -(void)xhLaunchShowFinish:(XHLaunchAd * _Nonnull)launchAd __attribute__((deprecated("请使用xhLaunchAdShowFinish:")));
        [Export("xhLaunchShowFinish:")]
        void XhLaunchShowFinish(XHLaunchAd launchAd);
    }

    // @interface XHLaunchAd : NSObject
    [BaseType(typeof(NSObject))]
    interface XHLaunchAd
    {
        [Wrap("WeakDelegate")]
        XHLaunchAdDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<XHLaunchAdDelegate> _Nonnull delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // +(void)setLaunchSourceType:(SourceType)sourceType;
        [Static]
        [Export("setLaunchSourceType:")]
        void SetLaunchSourceType(SourceType sourceType);

        // +(void)setWaitDataDuration:(NSInteger)waitDataDuration;
        [Static]
        [Export("setWaitDataDuration:")]
        void SetWaitDataDuration(nint waitDataDuration);

        // +(XHLaunchAd * _Nonnull)imageAdWithImageAdConfiguration:(XHLaunchImageAdConfiguration * _Nonnull)imageAdconfiguration;
        [Static]
        [Export("imageAdWithImageAdConfiguration:")]
        XHLaunchAd ImageAdWithImageAdConfiguration(XHLaunchImageAdConfiguration imageAdconfiguration);

        // +(XHLaunchAd * _Nonnull)imageAdWithImageAdConfiguration:(XHLaunchImageAdConfiguration * _Nonnull)imageAdconfiguration delegate:(id _Nullable)delegate;
        [Static]
        [Export("imageAdWithImageAdConfiguration:delegate:")]
        XHLaunchAd ImageAdWithImageAdConfiguration(XHLaunchImageAdConfiguration imageAdconfiguration, [NullAllowed] NSObject @delegate);

        // +(XHLaunchAd * _Nonnull)videoAdWithVideoAdConfiguration:(XHLaunchVideoAdConfiguration * _Nonnull)videoAdconfiguration;
        [Static]
        [Export("videoAdWithVideoAdConfiguration:")]
        XHLaunchAd VideoAdWithVideoAdConfiguration(XHLaunchVideoAdConfiguration videoAdconfiguration);

        // +(XHLaunchAd * _Nonnull)videoAdWithVideoAdConfiguration:(XHLaunchVideoAdConfiguration * _Nonnull)videoAdconfiguration delegate:(id _Nullable)delegate;
        [Static]
        [Export("videoAdWithVideoAdConfiguration:delegate:")]
        XHLaunchAd VideoAdWithVideoAdConfiguration(XHLaunchVideoAdConfiguration videoAdconfiguration, [NullAllowed] NSObject @delegate);

        // +(void)downLoadImageAndCacheWithURLArray:(NSArray<NSURL *> * _Nonnull)urlArray;
        [Static]
        [Export("downLoadImageAndCacheWithURLArray:")]
        void DownLoadImageAndCacheWithURLArray(NSUrl[] urlArray);

        // +(void)downLoadImageAndCacheWithURLArray:(NSArray<NSURL *> * _Nonnull)urlArray completed:(XHLaunchAdBatchDownLoadAndCacheCompletedBlock _Nullable)completedBlock;
        [Static]
        [Export("downLoadImageAndCacheWithURLArray:completed:")]
        void DownLoadImageAndCacheWithURLArray(NSUrl[] urlArray, [NullAllowed] XHLaunchAdBatchDownLoadAndCacheCompletedBlock completedBlock);

        // +(void)downLoadVideoAndCacheWithURLArray:(NSArray<NSURL *> * _Nonnull)urlArray;
        [Static]
        [Export("downLoadVideoAndCacheWithURLArray:")]
        void DownLoadVideoAndCacheWithURLArray(NSUrl[] urlArray);

        // +(void)downLoadVideoAndCacheWithURLArray:(NSArray<NSURL *> * _Nonnull)urlArray completed:(XHLaunchAdBatchDownLoadAndCacheCompletedBlock _Nullable)completedBlock;
        [Static]
        [Export("downLoadVideoAndCacheWithURLArray:completed:")]
        void DownLoadVideoAndCacheWithURLArray(NSUrl[] urlArray, [NullAllowed] XHLaunchAdBatchDownLoadAndCacheCompletedBlock completedBlock);

        // +(void)removeAndAnimated:(BOOL)animated;
        [Static]
        [Export("removeAndAnimated:")]
        void RemoveAndAnimated(bool animated);

        // +(BOOL)checkImageInCacheWithURL:(NSURL * _Nonnull)url;
        [Static]
        [Export("checkImageInCacheWithURL:")]
        bool CheckImageInCacheWithURL(NSUrl url);

        // +(BOOL)checkVideoInCacheWithURL:(NSURL * _Nonnull)url;
        [Static]
        [Export("checkVideoInCacheWithURL:")]
        bool CheckVideoInCacheWithURL(NSUrl url);

        // +(NSString * _Nonnull)cacheImageURLString;
        [Static]
        [Export("cacheImageURLString")]
        string CacheImageURLString { get; }

        // +(NSString * _Nonnull)cacheVideoURLString;
        [Static]
        [Export("cacheVideoURLString")]
        string CacheVideoURLString { get; }

        // +(void)clearDiskCache;
        [Static]
        [Export("clearDiskCache")]
        void ClearDiskCache();

        // +(void)clearDiskCacheWithImageUrlArray:(NSArray<NSURL *> * _Nonnull)imageUrlArray;
        [Static]
        [Export("clearDiskCacheWithImageUrlArray:")]
        void ClearDiskCacheWithImageUrlArray(NSUrl[] imageUrlArray);

        // +(void)clearDiskCacheExceptImageUrlArray:(NSArray<NSURL *> * _Nonnull)exceptImageUrlArray;
        [Static]
        [Export("clearDiskCacheExceptImageUrlArray:")]
        void ClearDiskCacheExceptImageUrlArray(NSUrl[] exceptImageUrlArray);

        // +(void)clearDiskCacheWithVideoUrlArray:(NSArray<NSURL *> * _Nonnull)videoUrlArray;
        [Static]
        [Export("clearDiskCacheWithVideoUrlArray:")]
        void ClearDiskCacheWithVideoUrlArray(NSUrl[] videoUrlArray);

        // +(void)clearDiskCacheExceptVideoUrlArray:(NSArray<NSURL *> * _Nonnull)exceptVideoUrlArray;
        [Static]
        [Export("clearDiskCacheExceptVideoUrlArray:")]
        void ClearDiskCacheExceptVideoUrlArray(NSUrl[] exceptVideoUrlArray);

        // +(float)diskCacheSize;
        [Static]
        [Export("diskCacheSize")]
        float DiskCacheSize { get; }

        // +(NSString * _Nonnull)xhLaunchAdCachePath;
        [Static]
        [Export("xhLaunchAdCachePath")]
        string XhLaunchAdCachePath { get; }

        // +(void)skipAction __attribute__((deprecated("请使用removeAndAnimated:")));
        [Static]
        [Export("skipAction")]
        void SkipAction();

        // +(void)setLaunchImagesSource:(LaunchImagesSource)launchImagesSource __attribute__((deprecated("请使用setLaunchSourceType:")));
        [Static]
        [Export("setLaunchImagesSource:")]
        void SetLaunchImagesSource(LaunchImagesSource launchImagesSource);
    }

    // typedef void (^SaveCompletionBlock)(BOOL, NSURL * _Nonnull);
    delegate void SaveCompletionBlock(bool arg0, NSUrl arg1);

    // @interface XHLaunchAdCache : NSObject
    [BaseType(typeof(NSObject))]
    interface XHLaunchAdCache
    {
        // +(UIImage * _Nonnull)getCacheImageWithURL:(NSURL * _Nonnull)url;
        [Static]
        [Export("getCacheImageWithURL:")]
        UIImage GetCacheImageWithURL(NSUrl url);

        // +(NSData * _Nonnull)getCacheImageDataWithURL:(NSURL * _Nonnull)url;
        [Static]
        [Export("getCacheImageDataWithURL:")]
        NSData GetCacheImageDataWithURL(NSUrl url);

        // +(BOOL)saveImageData:(NSData * _Nonnull)data imageURL:(NSURL * _Nonnull)url;
        [Static]
        [Export("saveImageData:imageURL:")]
        bool SaveImageData(NSData data, NSUrl url);

        // +(void)async_saveImageData:(NSData * _Nonnull)data imageURL:(NSURL * _Nonnull)url completed:(SaveCompletionBlock _Nullable)completedBlock;
        [Static]
        [Export("async_saveImageData:imageURL:completed:")]
        void Async_saveImageData(NSData data, NSUrl url, [NullAllowed] SaveCompletionBlock completedBlock);

        // +(BOOL)checkImageInCacheWithURL:(NSURL * _Nonnull)url;
        [Static]
        [Export("checkImageInCacheWithURL:")]
        bool CheckImageInCacheWithURL(NSUrl url);

        // +(BOOL)checkVideoInCacheWithURL:(NSURL * _Nonnull)url;
        [Static]
        [Export("checkVideoInCacheWithURL:")]
        bool CheckVideoInCacheWithURL(NSUrl url);

        // +(BOOL)checkVideoInCacheWithFileName:(NSString * _Nonnull)videoFileName;
        [Static]
        [Export("checkVideoInCacheWithFileName:")]
        bool CheckVideoInCacheWithFileName(string videoFileName);

        // +(NSURL * _Nullable)getCacheVideoWithURL:(NSURL * _Nonnull)url;
        [Static]
        [Export("getCacheVideoWithURL:")]
        [return: NullAllowed]
        NSUrl GetCacheVideoWithURL(NSUrl url);

        // +(BOOL)saveVideoAtLocation:(NSURL * _Nonnull)location URL:(NSURL * _Nonnull)url;
        [Static]
        [Export("saveVideoAtLocation:URL:")]
        bool SaveVideoAtLocation(NSUrl location, NSUrl url);

        // +(void)async_saveVideoAtLocation:(NSURL * _Nonnull)location URL:(NSURL * _Nonnull)url completed:(SaveCompletionBlock _Nullable)completedBlock;
        [Static]
        [Export("async_saveVideoAtLocation:URL:completed:")]
        void Async_saveVideoAtLocation(NSUrl location, NSUrl url, [NullAllowed] SaveCompletionBlock completedBlock);

        // +(NSString * _Nonnull)videoPathWithURL:(NSURL * _Nonnull)url;
        [Static]
        [Export("videoPathWithURL:")]
        string VideoPathWithURL(NSUrl url);

        // +(NSString * _Nonnull)videoPathWithFileName:(NSString * _Nonnull)videoFileName;
        [Static]
        [Export("videoPathWithFileName:")]
        string VideoPathWithFileName(string videoFileName);

        // +(void)async_saveImageUrl:(NSString * _Nonnull)url;
        [Static]
        [Export("async_saveImageUrl:")]
        void Async_saveImageUrl(string url);

        // +(NSString * _Nonnull)getCacheImageUrl;
        [Static]
        [Export("getCacheImageUrl")]
        string CacheImageUrl { get; }

        // +(void)async_saveVideoUrl:(NSString * _Nonnull)url;
        [Static]
        [Export("async_saveVideoUrl:")]
        void Async_saveVideoUrl(string url);

        // +(NSString * _Nonnull)getCacheVideoUrl;
        [Static]
        [Export("getCacheVideoUrl")]
        string CacheVideoUrl { get; }

        // +(NSString * _Nonnull)xhLaunchAdCachePath;
        [Static]
        [Export("xhLaunchAdCachePath")]
        string XhLaunchAdCachePath { get; }

        // +(void)clearDiskCache;
        [Static]
        [Export("clearDiskCache")]
        void ClearDiskCache();

        // +(void)clearDiskCacheWithImageUrlArray:(NSArray<NSURL *> * _Nonnull)imageUrlArray;
        [Static]
        [Export("clearDiskCacheWithImageUrlArray:")]
        void ClearDiskCacheWithImageUrlArray(NSUrl[] imageUrlArray);

        // +(void)clearDiskCacheExceptImageUrlArray:(NSArray<NSURL *> * _Nonnull)exceptImageUrlArray;
        [Static]
        [Export("clearDiskCacheExceptImageUrlArray:")]
        void ClearDiskCacheExceptImageUrlArray(NSUrl[] exceptImageUrlArray);

        // +(void)clearDiskCacheWithVideoUrlArray:(NSArray<NSURL *> * _Nonnull)videoUrlArray;
        [Static]
        [Export("clearDiskCacheWithVideoUrlArray:")]
        void ClearDiskCacheWithVideoUrlArray(NSUrl[] videoUrlArray);

        // +(void)clearDiskCacheExceptVideoUrlArray:(NSArray<NSURL *> * _Nonnull)exceptVideoUrlArray;
        [Static]
        [Export("clearDiskCacheExceptVideoUrlArray:")]
        void ClearDiskCacheExceptVideoUrlArray(NSUrl[] exceptVideoUrlArray);

        // +(float)diskCacheSize;
        [Static]
        [Export("diskCacheSize")]
        float DiskCacheSize { get; }

        // +(NSString * _Nonnull)md5String:(NSString * _Nonnull)string;
        [Static]
        [Export("md5String:")]
        string Md5String(string @string);
    }

    // @interface XHLaunchAdController : UIViewController
    [BaseType(typeof(UIViewController))]
    interface XHLaunchAdController
    {
    }

    // @interface XHLaunchAdImageView
    [BaseType(typeof(FLAnimatedImageView))]
    interface XHLaunchAdImageView
    {
        // @property (copy, nonatomic) void (^click)(CGPoint);
        [Export("click", ArgumentSemantic.Copy)]
        Action<CGPoint> Click { get; set; }
    }

    // @interface XHLaunchAdVideoView : UIView
    [BaseType(typeof(UIView))]
    interface XHLaunchAdVideoView
    {
        // @property (copy, nonatomic) void (^click)(CGPoint);
        [Export("click", ArgumentSemantic.Copy)]
        Action<CGPoint> Click { get; set; }

        // @property (nonatomic, strong) AVPlayerViewController * videoPlayer;
        [Export("videoPlayer", ArgumentSemantic.Strong)]
        AVPlayerViewController VideoPlayer { get; set; }

        // @property (assign, nonatomic) MPMovieScalingMode videoScalingMode;
        [Export("videoScalingMode", ArgumentSemantic.Assign)]
        MPMovieScalingMode VideoScalingMode { get; set; }

        // @property (assign, nonatomic) AVLayerVideoGravity videoGravity;
        [Export("videoGravity")]
        string VideoGravity { get; set; }

        // @property (assign, nonatomic) BOOL videoCycleOnce;
        [Export("videoCycleOnce")]
        bool VideoCycleOnce { get; set; }

        // @property (assign, nonatomic) BOOL muted;
        [Export("muted")]
        bool Muted { get; set; }

        // @property (nonatomic, strong) NSURL * contentURL;
        [Export("contentURL", ArgumentSemantic.Strong)]
        NSUrl ContentURL { get; set; }

        // -(void)stopVideoPlayer;
        [Export("stopVideoPlayer")]
        void StopVideoPlayer();
    }

    // @interface XHLaunchAdCache (XHLaunchAdImageView)
    [Category]
    [BaseType(typeof(XHLaunchAdImageView))]
    interface XHLaunchAdImageView_XHLaunchAdCache
    {
        // -(void)xh_setImageWithURL:(NSURL * _Nonnull)url;
        [Export("xh_setImageWithURL:")]
        void Xh_setImageWithURL(NSUrl url);

        // -(void)xh_setImageWithURL:(NSURL * _Nonnull)url placeholderImage:(UIImage * _Nullable)placeholder;
        [Export("xh_setImageWithURL:placeholderImage:")]
        void Xh_setImageWithURL(NSUrl url, [NullAllowed] UIImage placeholder);

        // -(void)xh_setImageWithURL:(NSURL * _Nonnull)url placeholderImage:(UIImage * _Nullable)placeholder options:(XHLaunchAdImageOptions)options;
        [Export("xh_setImageWithURL:placeholderImage:options:")]
        void Xh_setImageWithURL(NSUrl url, [NullAllowed] UIImage placeholder, XHLaunchAdImageOptions options);

        // -(void)xh_setImageWithURL:(NSURL * _Nonnull)url placeholderImage:(UIImage * _Nullable)placeholder completed:(XHExternalCompletionBlock _Nullable)completedBlock;
        [Export("xh_setImageWithURL:placeholderImage:completed:")]
        void Xh_setImageWithURL(NSUrl url, [NullAllowed] UIImage placeholder, [NullAllowed] XHExternalCompletionBlock completedBlock);

        // -(void)xh_setImageWithURL:(NSURL * _Nonnull)url completed:(XHExternalCompletionBlock _Nullable)completedBlock;
        [Export("xh_setImageWithURL:completed:")]
        void Xh_setImageWithURL(NSUrl url, [NullAllowed] XHExternalCompletionBlock completedBlock);

        // -(void)xh_setImageWithURL:(NSURL * _Nonnull)url placeholderImage:(UIImage * _Nullable)placeholder options:(XHLaunchAdImageOptions)options completed:(XHExternalCompletionBlock _Nullable)completedBlock;
        [Export("xh_setImageWithURL:placeholderImage:options:completed:")]
        void Xh_setImageWithURL(NSUrl url, [NullAllowed] UIImage placeholder, XHLaunchAdImageOptions options, [NullAllowed] XHExternalCompletionBlock completedBlock);

        // -(void)xh_setImageWithURL:(NSURL * _Nonnull)url placeholderImage:(UIImage * _Nullable)placeholder GIFImageCycleOnce:(BOOL)GIFImageCycleOnce options:(XHLaunchAdImageOptions)options GIFImageCycleOnceFinish:(void (^ _Nullable)(void))cycleOnceFinishBlock completed:(XHExternalCompletionBlock _Nullable)completedBlock;
        [Export("xh_setImageWithURL:placeholderImage:GIFImageCycleOnce:options:GIFImageCycleOnceFinish:completed:")]
        void Xh_setImageWithURL(NSUrl url, [NullAllowed] UIImage placeholder, bool GIFImageCycleOnce, XHLaunchAdImageOptions options, [NullAllowed] Action cycleOnceFinishBlock, [NullAllowed] XHExternalCompletionBlock completedBlock);
    }
}
