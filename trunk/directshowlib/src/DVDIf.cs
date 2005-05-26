#region license

/* ====================================================================
 * The Apache Software License, Version 1.1
 *
 * Copyright (c) 2005 The Apache Software Foundation.  All rights
 * reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 *
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 *
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in
 *    the documentation and/or other materials provided with the
 *    distribution.
 *
 * 3. The end-user documentation included with the redistribution,
 *    if any, must include the following acknowledgment:
 *       "This product includes software developed by the
 *        Apache Software Foundation (http://www.apache.org/)."
 *    Alternately, this acknowledgment may appear in the software itself,
 *    if and wherever such third-party acknowledgments normally appear.
 *
 * 4. The names "Apache" and "Apache Software Foundation" must
 *    not be used to endorse or promote products derived from this
 *    software without prior written permission. For written
 *    permission, please contact apache@apache.org.
 *
 * 5. Products derived from this software may not be called "Apache",
 *    nor may "Apache" appear in their name, without prior written
 *    permission of the Apache Software Foundation.
 *
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED.  IN NO EVENT SHALL THE APACHE SOFTWARE FOUNDATION OR
 * ITS CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF
 * USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT
 * OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
 * SUCH DAMAGE.
 * ====================================================================
 *
 * This software consists of voluntary contributions made by many
 * individuals on behalf of the Apache Software Foundation.  For more
 * information on the Apache Software Foundation, please see
 * <http://www.apache.org/>.
 *
 * Portions of this software are based upon public domain software
 * originally written at the National Center for Supercomputing Applications,
 * University of Illinois, Urbana-Champaign.
 */

#endregion

using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DirectShowLib.Dvd
{

    #region Declarations

#if ALLOW_UNTESTED_STRUCTS
    /// <summary>
    /// From DVD_ATR
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DvdAtr
    {
        public int ulCAT;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.I1, SizeConst=768)] public byte[] registers;
    }

    /// <summary>
    /// From typedef BYTE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DvdVideoATR
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.I1, SizeConst=2)] public byte[] attributes;
    }

    /// <summary>
    /// From typedef BYTE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DvdAudioATR
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.I1, SizeConst=8)] public byte[] attributes;
    }

    /// <summary>
    /// From typedef BYTE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DvdSubpictureATR
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.I1, SizeConst=6)] public byte[] attributes;
    }

    /// <summary>
    /// From DVD_PLAYBACK_LOCATION
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DvdPlaybackLocation
    {
        public int TitleNum;
        public int ChapterNum;
        public int TimeCode;
    }

#endif

    /// <summary>
    /// From DVD_DOMAIN
    /// </summary>
    public enum DvdDomain
    {
        FirstPlay = 1,
        VideoManagerMenu,
        VideoTitleSetMenu,
        Title,
        Stop
    }

    /// <summary>
    /// From DVD_MENU_ID
    /// </summary>
    public enum DvdMenuId
    {
        Title = 2,
        Root = 3,
        Subpicture = 4,
        Audio = 5,
        Angle = 6,
        Chapter = 7
    }

    /// <summary>
    /// From DVD_DISC_SIDE
    /// </summary>
    public enum DvdDiscSide
    {
        SideA = 1,
        SideB = 2
    }

    /// <summary>
    /// From DVD_PREFERRED_DISPLAY_MODE
    /// </summary>
    public enum DvdPreferredDisplayMode
    {
        DisplayContentDefault = 0,
        Display16x9 = 1,
        Display4x3PanScanPreferred = 2,
        Display4x3LetterBoxPreferred = 3
    }

    /// <summary>
    /// From DVD_FRAMERATE
    /// </summary>
    public enum DvdFrameRate
    {
        FPS25 = 1,
        FPS30NonDrop = 3
    }

    /// <summary>
    /// DVD_TIMECODE_FLAGS
    /// </summary>
    public enum DvdTimeCodeFlags
    {
        FPS25 = 0x00000001,
        FPS30 = 0x00000002,
        DropFrame = 0x00000004,
        Interpolated = 0x00000008,
    }

    /// <summary>
    /// From VALID_UOP_FLAG
    /// </summary>
    [Flags]
    public enum ValidUOPFlag
    {
        PlayTitleOrAtTime = 0x00000001,
        PlayChapter = 0x00000002,
        PlayTitle = 0x00000004,
        Stop = 0x00000008,
        ReturnFromSubMenu = 0x00000010,
        PlayChapterOrAtTime = 0x00000020,
        PlayPrevOrReplay_Chapter = 0x00000040,
        PlayNextChapter = 0x00000080,
        PlayForwards = 0x00000100,
        PlayBackwards = 0x00000200,
        ShowMenuTitle = 0x00000400,
        ShowMenuRoot = 0x00000800,
        ShowMenuSubPic = 0x00001000,
        ShowMenuAudio = 0x00002000,
        ShowMenuAngle = 0x00004000,
        ShowMenuChapter = 0x00008000,
        Resume = 0x00010000,
        SelectOrActivateButton = 0x00020000,
        StillOff = 0x00040000,
        PauseOn = 0x00080000,
        SelectAudioStream = 0x00100000,
        SelectSubPicStream = 0x00200000,
        SelectAngle = 0x00400000,
        SelectKaraokeAudioPresentationMode = 0x00800000,
        SelectVideoModePreference = 0x01000000
    }

    /// <summary>
    /// From DVD_CMD_FLAGS
    /// </summary>
    [Flags]
    public enum DvdCmdFlags
    {
        None = 0x00000000,
        Flush = 0x00000001,
        SendEvents = 0x00000002,
        Block = 0x00000004,
        StartWhenRendered = 0x00000008,
        EndAfterRendered = 0x00000010,
    }

    /// <summary>
    /// From DVD_OPTION_FLAG
    /// </summary>
    public enum DvdOptionFlag
    {
        ResetOnStop = 1,
        NotifyParentalLevelChange = 2,
        HMSFTimeCodeEvents = 3,
        AudioDuringFFwdRew = 4
    }

    /// <summary>
    /// From DVD_RELATIVE_BUTTON
    /// </summary>
    public enum DvdRelativeButton
    {
        Upper = 1,
        Lower = 2,
        Left = 3,
        Right = 4
    }

    /// <summary>
    /// From DVD_PARENTAL_LEVEL
    /// </summary>
    [Flags]
    public enum DvdParentalLevel
    {
        Level8 = 0x8000,
        Level7 = 0x4000,
        Level6 = 0x2000,
        Level5 = 0x1000,
        Level4 = 0x0800,
        Level3 = 0x0400,
        Level2 = 0x0200,
        Level1 = 0x0100
    }

    /// <summary>
    /// From DVD_AUDIO_LANG_EXT
    /// </summary>
    public enum DvdAudioLangExt
    {
        NotSpecified = 0,
        Captions = 1,
        VisuallyImpaired = 2,
        DirectorComments1 = 3,
        DirectorComments2 = 4,
    }

    /// <summary>
    /// From DVD_SUBPICTURE_LANG_EXT
    /// </summary>
    public enum DvdSubPictureLangExt
    {
        NotSpecified = 0,
        CaptionNormal = 1,
        CaptionBig = 2,
        CaptionChildren = 3,
        CCNormal = 5,
        CCBig = 6,
        CCChildren = 7,
        Forced = 9,
        DirectorCommentsNormal = 13,
        DirectorCommentsBig = 14,
        DirectorCommentsChildren = 15,
    }

    /// <summary>
    /// From DVD_AUDIO_APPMODE
    /// </summary>
    public enum DvdAudioAppMode
    {
        None = 0,
        Karaoke = 1,
        Surround = 2,
        Other = 3,
    }

    /// <summary>
    /// From DVD_AUDIO_FORMAT
    /// </summary>
    public enum DvdAudioFormat
    {
        AC3 = 0,
        MPEG1 = 1,
        MPEG1_DRC = 2,
        MPEG2 = 3,
        MPEG2_DRC = 4,
        LPCM = 5,
        DTS = 6,
        SDDS = 7,
        Other = 8
    }

    /// <summary>
    /// From DVD_KARAOKE_DOWNMIX
    /// </summary>
    [Flags]
    public enum DvdKaraokeDownMix
    {
        Mix_0to0 = 0x0001,
        Mix_1to0 = 0x0002,
        Mix_2to0 = 0x0004,
        Mix_3to0 = 0x0008,
        Mix_4to0 = 0x0010,
        Mix_Lto0 = 0x0020,
        Mix_Rto0 = 0x0040,
        Mix_0to1 = 0x0100,
        Mix_1to1 = 0x0200,
        Mix_2to1 = 0x0400,
        Mix_3to1 = 0x0800,
        Mix_4to1 = 0x1000,
        Mix_Lto1 = 0x2000,
        Mix_Rto1 = 0x4000,
    }

    /// <summary>
    /// From DVD_KARAOKE_CONTENTS
    /// </summary>
    [Flags]
    public enum DvdKaraokeContents : short
    {
        GuideVocal1 = 0x0001,
        GuideVocal2 = 0x0002,
        GuideMelody1 = 0x0004,
        GuideMelody2 = 0x0008,
        GuideMelodyA = 0x0010,
        GuideMelodyB = 0x0020,
        SoundEffectA = 0x0040,
        SoundEffectB = 0x0080
    }

    /// <summary>
    /// From DVD_KARAOKE_ASSIGNMENT
    /// </summary>
    public enum DvdKaraokeAssignment
    {
        reserved0 = 0,
        reserved1 = 1,
        LR = 2,
        LRM = 3,
        LR1 = 4,
        LRM1 = 5,
        LR12 = 6,
        LRM12 = 7
    }

    /// <summary>
    /// From DVD_VIDEO_COMPRESSION
    /// </summary>
    public enum DvdVideoCompression
    {
        Other = 0,
        Mpeg1 = 1,
        Mpeg2 = 2
    }

    /// <summary>
    /// From DVD_SUBPICTURE_TYPE
    /// </summary>
    public enum DvdSubPictureType
    {
        NotSpecified = 0,
        Language = 1,
        Other = 2,
    }

    /// <summary>
    /// From DVD_SUBPICTURE_CODING
    /// </summary>
    public enum DvdSubPictureCoding
    {
        RunLength = 0,
        Extended = 1,
        Other = 2,
    }

    /// <summary>
    /// From DVD_TITLE_APPMODE
    /// </summary>
    public enum DvdTitleAppMode
    {
        NotSpecified = 0,
        Karaoke = 1,
        Other = 3,
    }

    /// <summary>
    /// From DVD_TextStringType
    /// </summary>
    public enum DvdTextStringType
    {
        DVD_Struct_Volume = 0x01,
        DVD_Struct_Title = 0x02,
        DVD_Struct_ParentalID = 0x03,
        DVD_Struct_PartOfTitle = 0x04,
        DVD_Struct_Cell = 0x05,
        DVD_Stream_Audio = 0x10,
        DVD_Stream_Subpicture = 0x11,
        DVD_Stream_Angle = 0x12,
        DVD_Channel_Audio = 0x20,
        DVD_General_Name = 0x30,
        DVD_General_Comments = 0x31,
        DVD_Title_Series = 0x38,
        DVD_Title_Movie = 0x39,
        DVD_Title_Video = 0x3a,
        DVD_Title_Album = 0x3b,
        DVD_Title_Song = 0x3c,
        DVD_Title_Other = 0x3f,
        DVD_Title_Sub_Series = 0x40,
        DVD_Title_Sub_Movie = 0x41,
        DVD_Title_Sub_Video = 0x42,
        DVD_Title_Sub_Album = 0x43,
        DVD_Title_Sub_Song = 0x44,
        DVD_Title_Sub_Other = 0x47,
        DVD_Title_Orig_Series = 0x48,
        DVD_Title_Orig_Movie = 0x49,
        DVD_Title_Orig_Video = 0x4a,
        DVD_Title_Orig_Album = 0x4b,
        DVD_Title_Orig_Song = 0x4c,
        DVD_Title_Orig_Other = 0x4f,
        DVD_Other_Scene = 0x50,
        DVD_Other_Cut = 0x51,
        DVD_Other_Take = 0x52,
    }

    /// <summary>
    /// From DVD_TextCharSet
    /// </summary>
    public enum DvdTextCharSet
    {
        CharSet_Unicode = 0,
        CharSet_ISO646 = 1,
        CharSet_JIS_Roman_Kanji = 2,
        CharSet_ISO8859_1 = 3,
        CharSet_ShiftJIS_Kanji_Roman_Katakana = 4
    }

    /// <summary>
    /// From DVD_AUDIO_CAPS_* defines
    /// </summary>
    [Flags]
    public enum DvdAudioCaps
    {
        AC3 = 0x00000001,
        MPEG2 = 0x00000002,
        LPCM = 0x00000004,
        DTS = 0x00000008,
        SDDS = 0x00000010,
    }

    /// <summary>
    /// From AM_DVD_GRAPH_FLAGS
    /// </summary>
    [Flags]
    public enum AMDvdGraphFlags
    {
        HWDecPrefer = 0x01, // AM_DVD_HWDEC_PREFER
        HWDecOnly = 0x02, // AM_DVD_HWDEC_ONLY
        SWDecPrefer = 0x04, // AM_DVD_SWDEC_PREFER
        SWDecOnly = 0x08, // AM_DVD_SWDEC_ONLY
        NoVPE = 0x100, // AM_DVD_NOVPE
        VMR9Only = 0x800 // AM_DVD_VMR9_ONLY
    }

    /// <summary>
    /// From AM_DVD_STREAM_FLAGS
    /// </summary>
    [Flags]
    public enum AMDvdStreamFlags
    {
        None = 0x00,
        Video = 0x01, // AM_DVD_STREAM_VIDEO
        Audio = 0x02, // AM_DVD_STREAM_AUDIO
        SubPic = 0x04 // AM_DVD_STREAM_SUBPIC
    }

    [Flags]
    public enum AMOverlayNotifyFlags
    {
        VisibleChange = 0x00000001,
        SourceChange = 0x00000002,
        DestChange = 0x00000004
    }


    /// <summary>
    /// From typedef DVD_REGISTER
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GPRMArray
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.I2, SizeConst=16)] public short[] registers;
    }

    /// <summary>
    /// From typedef DVD_REGISTER
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SPRMArray
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.I2, SizeConst=24)] public short[] registers;
    }

    /// <summary>
    /// From DVD_HMSF_TIMECODE
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public class DvdHMSFTimeCode
    {
        public byte bHours;
        public byte bMinutes;
        public byte bSeconds;
        public byte bFrames;
    }

    /// <summary>
    /// From DVD_PLAYBACK_LOCATION2
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct DvdPlaybackLocation2
    {
        public int TitleNum;
        public int ChapterNum;
        public DvdHMSFTimeCode TimeCode;
        public int TimeCodeFlags;
    }

    /// <summary>
    /// From DVD_AudioAttributes
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DvdAudioAttributes
    {
        public DvdAudioAppMode AppMode;
        public byte AppModeData;
        public DvdAudioFormat AudioFormat;
        public int Language;
        public DvdAudioLangExt LanguageExtension;
        [MarshalAs(UnmanagedType.Bool)] public bool fHasMultichannelInfo;
        public int dwFrequency;
        public byte bQuantization;
        public byte bNumberOfChannels;
        public int dwReserved1;
        public int dwReserved2;
    }

    /// <summary>
    /// From DVD_MUA_MixingInfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DvdMUAMixingInfo
    {
        [MarshalAs(UnmanagedType.Bool)] public bool fMixTo0;
        [MarshalAs(UnmanagedType.Bool)] public bool fMixTo1;
        [MarshalAs(UnmanagedType.Bool)] public bool fMix0InPhase;
        [MarshalAs(UnmanagedType.Bool)] public bool fMix1InPhase;
        public int dwSpeakerPosition;
    }

    /// <summary>
    /// From DVD_MUA_Coeff
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DvdMUACoeff
    {
        public double log2_alpha;
        public double log2_beta;
    }

    /// <summary>
    /// From DVD_MultichannelAudioAttributes
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DvdMultichannelAudioAttributes
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.Struct, SizeConst=8)] public DvdMUAMixingInfo[] Info;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.Struct, SizeConst=8)] public DvdMUACoeff[] Coeff;
    }

    /// <summary>
    /// From DVD_KaraokeAttributes
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public class DvdKaraokeAttributes
    {
        public byte bVersion;
        public bool fMasterOfCeremoniesInGuideVocal1;
        public bool fDuet;
        public DvdKaraokeAssignment ChannelAssignment;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.I2, SizeConst=8)] public DvdKaraokeContents[] wChannelContents;
    }

    /// <summary>
    /// From DVD_VideoAttributes
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DvdVideoAttributes
    {
        [MarshalAs(UnmanagedType.Bool)] public bool panscanPermitted;
        [MarshalAs(UnmanagedType.Bool)] public bool letterboxPermitted;
        public int aspectX;
        public int aspectY;
        public int frameRate;
        public int frameHeight;
        public DvdVideoCompression compression;
        [MarshalAs(UnmanagedType.Bool)] public bool line21Field1InGOP;
        [MarshalAs(UnmanagedType.Bool)] public bool line21Field2InGOP;
        public int sourceResolutionX;
        public int sourceResolutionY;
        [MarshalAs(UnmanagedType.Bool)] public bool isSourceLetterboxed;
        [MarshalAs(UnmanagedType.Bool)] public bool isFilmMode;
    }

    /// <summary>
    /// From DVD_SubpictureAttributes
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DvdSubpictureAttributes
    {
        public DvdSubPictureType Type;
        public DvdSubPictureCoding CodingMode;
        public int Language;
        public DvdSubPictureLangExt LanguageExtension;
    }

    /// <summary>
    /// From DVD_TitleAttributes
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class DvdTitleAttributes
    {
        public DvdTitleAppMode AppMode;
        public DvdVideoAttributes VideoAttributes;
        public int ulNumberOfAudioStreams;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.Struct, SizeConst=8)] public DvdAudioAttributes[] AudioAttributes;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.Struct, SizeConst=8)] public DvdMultichannelAudioAttributes[] MultichannelAudioAttributes;
        public int ulNumberOfSubpictureStreams;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.Struct, SizeConst=32)] public DvdSubpictureAttributes[] SubpictureAttributes;
    }

    /// <summary>
    /// From DVD_MenuAttributes
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DvdMenuAttributes
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.Bool, SizeConst=8)] public bool[] fCompatibleRegion;
        public DvdVideoAttributes VideoAttributes;
        [MarshalAs(UnmanagedType.Bool)] public bool fAudioPresent;
        public DvdAudioAttributes AudioAttributes;
        [MarshalAs(UnmanagedType.Bool)] public bool fSubpicturePresent;
        public DvdSubpictureAttributes SubpictureAttributes;
    }

    /// <summary>
    /// From DVD_DECODER_CAPS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DvdDecoderCaps
    {
        public int dwSize;
        public DvdAudioCaps dwAudioCaps;
        public double dFwdMaxRateVideo;
        public double dFwdMaxRateAudio;
        public double dFwdMaxRateSP;
        public double dBwdMaxRateVideo;
        public double dBwdMaxRateAudio;
        public double dBwdMaxRateSP;
        public int dwRes1;
        public int dwRes2;
        public int dwRes3;
        public int dwRes4;
    }

    /// <summary>
    /// From AM_DVD_RENDERSTATUS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AMDvdRenderStatus
    {
        public int hrVPEStatus;
        [MarshalAs(UnmanagedType.Bool)] public bool bDvdVolInvalid;
        [MarshalAs(UnmanagedType.Bool)] public bool bDvdVolUnknown;
        [MarshalAs(UnmanagedType.Bool)] public bool bNoLine21In;
        [MarshalAs(UnmanagedType.Bool)] public bool bNoLine21Out;
        public int iNumStreams;
        public int iNumStreamsFailed;
        public AMDvdStreamFlags dwFailedStreamsFlag;
    }

    #endregion

    #region Interfaces

#if ALLOW_UNTESTED_INTERFACES
    [Guid("A70EFE61-E2A3-11d0-A9BE-00AA0061BE93"),
    Obsolete("The IDvdControl interface is deprecated. Use IDvdControl2 instead.", false),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdControl
    {
        [PreserveSig]
        int TitlePlay([In] int ulTitle);

        [PreserveSig]
        int ChapterPlay(
            [In] int ulTitle,
            [In] int ulChapter
            );

        [PreserveSig]
        int TimePlay(
            [In] int ulTitle,
            [In] int bcdTime
            );

        [PreserveSig]
        int StopForResume();

        [PreserveSig]
        int GoUp();

        [PreserveSig]
        int TimeSearch([In] int bcdTime);

        [PreserveSig]
        int ChapterSearch([In] int ulChapter);

        [PreserveSig]
        int PrevPGSearch();

        [PreserveSig]
        int TopPGSearch();

        [PreserveSig]
        int NextPGSearch();

        [PreserveSig]
        int ForwardScan([In] double dwSpeed);

        [PreserveSig]
        int BackwardScan([In] double dwSpeed);

        [PreserveSig]
        int MenuCall([In] DvdMenuId MenuID);

        [PreserveSig]
        int Resume();

        [PreserveSig]
        int UpperButtonSelect();

        [PreserveSig]
        int LowerButtonSelect();

        [PreserveSig]
        int LeftButtonSelect();

        [PreserveSig]
        int RightButtonSelect();

        [PreserveSig]
        int ButtonActivate();

        [PreserveSig]
        int ButtonSelectAndActivate([In] int ulButton);

        [PreserveSig]
        int StillOff();

        [PreserveSig]
        int PauseOn();

        [PreserveSig]
        int PauseOff();

        [PreserveSig]
        int MenuLanguageSelect([In] int Language);

        [PreserveSig]
        int AudioStreamChange([In] int ulAudio);

        [PreserveSig]
        int SubpictureStreamChange(
            [In] int ulSubPicture,
            [In, MarshalAs(UnmanagedType.Bool)] bool bDisplay
            );

        [PreserveSig]
        int AngleChange([In] int ulAngle);

        [PreserveSig]
        int ParentalLevelSelect([In] int ulParentalLevel);

        [PreserveSig]
        int ParentalCountrySelect([In] short wCountry);

        [PreserveSig]
        int KaraokeAudioPresentationModeChange([In] int ulMode);

        [PreserveSig]
        int VideoModePreferrence([In] int ulPreferredDisplayMode);

        [PreserveSig]
        int SetRoot([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath);

        [PreserveSig]
        int MouseActivate([In] Point point);

        [PreserveSig]
        int MouseSelect([In] Point point);

        [PreserveSig]
        int ChapterPlayAutoStop(
            [In] int ulTitle,
            [In] int ulChapter,
            [In] int ulChaptersToPlay
            );
    }

    [Guid("A70EFE60-E2A3-11d0-A9BE-00AA0061BE93"),
    Obsolete("The IDvdInfo interface is deprecated. Use IDvdInfo2 instead.", false),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdInfo
    {
        [PreserveSig]
        int GetCurrentDomain([Out] out DvdDomain pDomain);

        [PreserveSig]
        int GetCurrentLocation([Out] out DvdPlaybackLocation pLocation);

        [PreserveSig]
        int GetTotalTitleTime([Out] out int pulTotalTime);

        [PreserveSig]
        int GetCurrentButton(
            [Out] out int pulButtonsAvailable,
            [Out] out int pulCurrentButton
            );

        [PreserveSig]
        int GetCurrentAngle(
            [Out] out int pulAnglesAvailable,
            [Out] out int pulCurrentAngle
            );

        [PreserveSig]
        int GetCurrentAudio(
            [Out] out int pulStreamsAvailable,
            [Out] out int pulCurrentStream
            );

        [PreserveSig]
        int GetCurrentSubpicture(
            [Out] out int pulStreamsAvailable,
            [Out] out int pulCurrentStream,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pIsDisabled
            );

        [PreserveSig]
        int GetCurrentUOPS([Out] out int pUOP);

        [PreserveSig]
        int GetAllSPRMs([Out] out SPRMArray pRegisterArray);

        [PreserveSig]
        int GetAllGPRMs([Out] out GPRMArray pRegisterArray);

        [PreserveSig]
        int GetAudioLanguage(
            [In] int ulStream,
            [Out] out int pLanguage
            );

        [PreserveSig]
        int GetSubpictureLanguage(
            [In] int ulStream,
            [Out] out int pLanguage
            );

        [PreserveSig]
        int GetTitleAttributes(
            [In] int ulTitle,
            [Out] out DvdAtr pATR
            );

        [PreserveSig]
        int GetVMGAttributes([Out] out DvdAtr pATR);

        [PreserveSig]
        int GetCurrentVideoAttributes([Out] out DvdVideoATR pATR);

        [PreserveSig]
        int GetCurrentAudioAttributes([Out] out DvdAudioATR pATR);

        [PreserveSig]
        int GetCurrentSubpictureAttributes([Out] out DvdSubpictureATR pATR);


        [PreserveSig]
        int GetCurrentVolumeInfo(
            [Out] out int pulNumOfVol,
            [Out] out int pulThisVolNum,
            [Out] DvdDiscSide pSide,
            [Out] out int pulNumOfTitles
            );


        [PreserveSig]
        int GetDVDTextInfo(
            [Out] out IntPtr pTextManager, // BYTE *
            [In] int ulBufSize,
            [Out] out int pulActualSize
            );

        [PreserveSig]
        int GetPlayerParentalLevel(
            [Out] out int pulParentalLevel,
            [Out] out int pulCountryCode
            );

        [PreserveSig]
        int GetNumberOfChapters(
            [In] int ulTitle,
            [Out] out int pulNumberOfChapters
            );

        [PreserveSig]
        int GetTitleParentalLevels(
            [In] int ulTitle,
            [Out] out int pulParentalLevels
            );

        [PreserveSig]
        int GetRoot(
            [Out] out IntPtr pRoot, // LPSTR
            [In] int ulBufSize,
            [Out] out int pulActualSize
            );
    }

    [Guid("5a4a97e4-94ee-4a55-9751-74b5643aa27d"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdCmd
    {
        [PreserveSig]
        int WaitForStart();

        [PreserveSig]
        int WaitForEnd();
    }

    [Guid("86303d6d-1c4a-4087-ab42-f711167048ef"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdState
    {
        [PreserveSig]
        int GetDiscID([Out] out long pullUniqueID);

        [PreserveSig]
        int GetParentalLevel([Out] out int pulParentalLevel);
    }

    [Guid("153ACC21-D83B-11d1-82BF-00A0C9696C8F"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDDrawExclModeVideo
    {
        [PreserveSig]
        int SetDDrawObject([In, MarshalAs(UnmanagedType.IUnknown)] object pDDrawObject);

        [PreserveSig]
        int GetDDrawObject(
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppDDrawObject,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbUsingExternal
            );

        [PreserveSig]
        int SetDDrawSurface([In, MarshalAs(UnmanagedType.IUnknown)] object pDDrawSurface);

        [PreserveSig]
        int GetDDrawSurface(
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppDDrawSurface,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbUsingExternal
            );

        [PreserveSig]
        int SetDrawParameters(
            [In] Rectangle prcSource,
            [In] Rectangle prcTarget
            );

        [PreserveSig]
        int GetNativeVideoProps(
            [Out] out int pdwVideoWidth,
            [Out] out int pdwVideoHeight,
            [Out] out int pdwPictAspectRatioX,
            [Out] out int pdwPictAspectRatioY
            );

        [PreserveSig]
        int SetCallbackInterface(
            [In, MarshalAs(UnmanagedType.IUnknown)] object pCallback,
            [In] int dwFlags
            );
    }

    [Guid("913c24a0-20ab-11d2-9038-00a0c9697298"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDDrawExclModeVideoCallback
    {
        [PreserveSig]
        int OnUpdateOverlay(
            [In, MarshalAs(UnmanagedType.Bool)] bool bBefore,
            [In] AMOverlayNotifyFlags dwFlags,
            [In, MarshalAs(UnmanagedType.Bool)] bool bOldVisible,
            [In] Rectangle prcOldSrc,
            [In] Rectangle prcOldDest,
            [In, MarshalAs(UnmanagedType.Bool)] bool bNewVisible,
            [In] Rectangle prcNewSrc,
            [In] Rectangle prcNewDest
            );

        [PreserveSig]
        int OnUpdateColorKey(
            [In] ColorKey pKey,
            [In] int dwColor
            );

        [PreserveSig]
        int OnUpdateSize(
            [In] int dwWidth,
            [In] int dwHeight,
            [In] int dwARWidth,
            [In] int dwARHeight
            );
    }
#endif

    [Guid("FCC152B6-F372-11d0-8E00-00C04FD7C08B"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdGraphBuilder
    {
        [PreserveSig]
        int GetFiltergraph([Out] out IGraphBuilder ppGB);

        [PreserveSig]
        int GetDvdInterface(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppvIF
            );

        [PreserveSig]
        int RenderDvdVideoVolume(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwszPathName,
            [In] AMDvdGraphFlags dwFlags,
            [Out] out AMDvdRenderStatus pStatus
            );
    }

    [Guid("33BC7430-EEC0-11D2-8201-00A0C9D74842"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdControl2
    {
        [PreserveSig]
        int PlayTitle(
            [In] int ulTitle,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int PlayChapterInTitle(
            [In] int ulTitle,
            [In] int ulChapter,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int PlayAtTimeInTitle(
            [In] int ulTitle,
            [In] DvdHMSFTimeCode pStartTime,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int Stop();

        [PreserveSig]
        int ReturnFromSubmenu(
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int PlayAtTime(
            [In] DvdHMSFTimeCode pTime,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int PlayChapter(
            [In] int ulChapter,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int PlayPrevChapter(
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int ReplayChapter(
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int PlayNextChapter(
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int PlayForwards(
            [In] double dSpeed,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int PlayBackwards(
            [In] double dSpeed,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int ShowMenu(
            [In] DvdMenuId MenuID,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int Resume(
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int SelectRelativeButton(DvdRelativeButton buttonDir);

        [PreserveSig]
        int ActivateButton();

        [PreserveSig]
        int SelectButton([In] int ulButton);

        [PreserveSig]
        int SelectAndActivateButton([In] int ulButton);

        [PreserveSig]
        int StillOff();

        [PreserveSig]
        int Pause([In, MarshalAs(UnmanagedType.Bool)] bool bState);

        [PreserveSig]
        int SelectAudioStream(
            [In] int ulAudio,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int SelectSubpictureStream(
            [In] int ulSubPicture,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int SetSubpictureState(
            [In, MarshalAs(UnmanagedType.Bool)] bool bState,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int SelectAngle(
            [In] int ulAngle,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int SelectParentalLevel([In] int ulParentalLevel);

        [PreserveSig]
        int SelectParentalCountry([In, MarshalAs(UnmanagedType.LPArray)] byte[] bCountry);

        [PreserveSig]
        int SelectKaraokeAudioPresentationMode([In] DvdKaraokeDownMix ulMode);

        [PreserveSig]
        int SelectVideoModePreference([In] DvdPreferredDisplayMode ulPreferredDisplayMode);

        [PreserveSig]
        int SetDVDDirectory([In, MarshalAs(UnmanagedType.LPWStr)] string pszwPath);

        [PreserveSig]
        int ActivateAtPosition([In] Point point);

        [PreserveSig]
        int SelectAtPosition([In] Point point);

        [PreserveSig]
        int PlayChaptersAutoStop(
            [In] int ulTitle,
            [In] int ulChapter,
            [In] int ulChaptersToPlay,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int AcceptParentalLevelChange([In, MarshalAs(UnmanagedType.Bool)] bool bAccept);

        [PreserveSig]
        int SetOption(
            [In] DvdOptionFlag flag,
            [In, MarshalAs(UnmanagedType.Bool)] bool fState
            );

        [PreserveSig]
        int SetState(
            [In] IDvdState pState,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int PlayPeriodInTitleAutoStop(
            [In] int ulTitle,
            [In, MarshalAs(UnmanagedType.LPStruct)] DvdHMSFTimeCode pStartTime,
            [In, MarshalAs(UnmanagedType.LPStruct)] DvdHMSFTimeCode pEndTime,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int SetGPRM(
            [In] int ulIndex,
            [In] short wValue,
            [In] DvdCmdFlags dwFlags,
            [Out] out IDvdCmd ppCmd
            );

        [PreserveSig]
        int SelectDefaultMenuLanguage([In] int Language);

        [PreserveSig]
        int SelectDefaultAudioLanguage(
            [In] int Language,
            [In] DvdAudioLangExt audioExtension
            );

        [PreserveSig]
        int SelectDefaultSubpictureLanguage(
            [In] int Language,
            [In] DvdSubPictureLangExt subpictureExtension
            );
    }

    [Guid("34151510-EEC0-11D2-8201-00A0C9D74842"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdInfo2
    {
        [PreserveSig]
        int GetCurrentDomain([Out] out DvdDomain pDomain);

        [PreserveSig]
        int GetCurrentLocation([Out] out DvdPlaybackLocation2 pLocation);

        [PreserveSig]
        int GetTotalTitleTime(
            [Out] DvdHMSFTimeCode pTotalTime,
            [Out] out DvdTimeCodeFlags ulTimeCodeFlags
            );

        [PreserveSig]
        int GetCurrentButton(
            [Out] out int pulButtonsAvailable,
            [Out] out int pulCurrentButton
            );

        [PreserveSig]
        int GetCurrentAngle(
            [Out] out int pulAnglesAvailable,
            [Out] out int pulCurrentAngle
            );

        [PreserveSig]
        int GetCurrentAudio(
            [Out] out int pulStreamsAvailable,
            [Out] out int pulCurrentStream
            );

        [PreserveSig]
        int GetCurrentSubpicture(
            [Out] out int pulStreamsAvailable,
            [Out] out int pulCurrentStream,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbIsDisabled
            );

        [PreserveSig]
        int GetCurrentUOPS([Out] out ValidUOPFlag pulUOPs);

        [PreserveSig]
        int GetAllSPRMs([Out] out SPRMArray pRegisterArray);

        [PreserveSig]
        int GetAllGPRMs([Out] out GPRMArray pRegisterArray);

        [PreserveSig]
        int GetAudioLanguage(
            [In] int ulStream,
            [Out] out int pLanguage
            );

        [PreserveSig]
        int GetSubpictureLanguage(
            [In] int ulStream,
            [Out] out int pLanguage
            );

        [PreserveSig]
        int GetTitleAttributes(
            [In] int ulTitle,
            [Out] out DvdMenuAttributes pMenu,
            [In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(DTAMarshaler))] DvdTitleAttributes pTitle
            );

        [PreserveSig]
        int GetVMGAttributes([Out] out DvdMenuAttributes pATR);

        [PreserveSig]
        int GetCurrentVideoAttributes([Out] out DvdVideoAttributes pATR);

        [PreserveSig]
        int GetAudioAttributes(
            [In] int ulStream,
            [Out] out DvdAudioAttributes pATR
            );

        [PreserveSig]
        int GetKaraokeAttributes(
            [In] int ulStream,
            [In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(DKAMarshaler))] DvdKaraokeAttributes pAttributes
                );

        [PreserveSig]
        int GetSubpictureAttributes(
            [In] int ulStream,
            [Out] out DvdSubpictureAttributes pATR
            );

        [PreserveSig]
        int GetDVDVolumeInfo(
            [Out] out int pulNumOfVolumes,
            [Out] out int pulVolume,
            [Out] out DvdDiscSide pSide,
            [Out] out int pulNumOfTitles
            );

        [PreserveSig]
        int GetDVDTextNumberOfLanguages([Out] out int pulNumOfLangs);

        [PreserveSig]
        int GetDVDTextLanguageInfo(
            [In] int ulLangIndex,
            [Out] out int pulNumOfStrings,
            [Out] out int pLangCode,
            [Out] out DvdTextCharSet pbCharacterSet
            );

        [PreserveSig]
        int GetDVDTextStringAsNative(
            [In] int ulLangIndex,
            [In] int ulStringIndex,
            [MarshalAs(UnmanagedType.LPStr)]System.Text.StringBuilder pbBuffer, // BYTE *
            [In] int ulMaxBufferSize,
            [Out] out int pulActualSize,
            [Out] out DvdTextStringType pType
            );

        [PreserveSig]
        int GetDVDTextStringAsUnicode(
            [In] int ulLangIndex,
            [In] int ulStringIndex,
            System.Text.StringBuilder pchwBuffer, // WCHAR *
            [In] int ulMaxBufferSize,
            [Out] out int pulActualSize,
            [Out] out DvdTextStringType pType
            );

        [PreserveSig]
        int GetPlayerParentalLevel(
            [Out] out int pulParentalLevel,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst=2)] byte[] pbCountryCode
            //[In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(ByteMarshaler))] byte[] pbCountryCode
                );

        [PreserveSig]
        int GetNumberOfChapters(
            [In] int ulTitle,
            [Out] out int pulNumOfChapters
            );

        [PreserveSig]
        int GetTitleParentalLevels(
            [In] int ulTitle,
            [Out] out DvdParentalLevel pulParentalLevels
            );

        [PreserveSig]
        int GetDVDDirectory(
            System.Text.StringBuilder pszwPath, // LPWSTR
            [In] int ulMaxSize,
            [Out] out int pulActualSize
            );

        [PreserveSig]
        int IsAudioStreamEnabled(
            [In] int ulStreamNum,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbEnabled
            );

        [PreserveSig]
        int GetDiscID(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszwPath,
            [Out] out long pullDiscID
            );

        [PreserveSig]
        int GetState([Out] out IDvdState pStateData);

        [PreserveSig]
        int GetMenuLanguages(
            [MarshalAs(UnmanagedType.LPArray)] int [] pLanguages, // LCID *
            [In] int ulMaxLanguages,
            [Out] out int pulActualLanguages
            );

        [PreserveSig]
        int GetButtonAtPosition(
            [In] Point point,
            [Out] out int pulButtonIndex
            );

        [PreserveSig]
        int GetCmdFromEvent(
            [In] int lParam1,
            [Out] out IDvdCmd pCmdObj
            );

        [PreserveSig]
        int GetDefaultMenuLanguage([Out] out int pLanguage);

        [PreserveSig]
        int GetDefaultAudioLanguage(
            [Out] out int pLanguage,
            [Out] out DvdAudioLangExt pAudioExtension
            );

        [PreserveSig]
        int GetDefaultSubpictureLanguage(
            [Out] out int pLanguage,
            [Out] out DvdSubPictureLangExt pSubpictureExtension
            );

        [PreserveSig]
        int GetDecoderCaps(ref DvdDecoderCaps pCaps);

        [PreserveSig]
        int GetButtonRect(
            [In] int ulButton,
            [Out] out Rectangle pRect
            );

        [PreserveSig]
        int IsSubpictureStreamEnabled(
            [In] int ulStreamNum,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbEnabled
            );
    }

    #endregion

    // This abstract class contains definitions for use in implementing a custom marshaler.
    //
    // MarshalManagedToNative() gets called before the COM method, and MarshalNativeToManaged() gets
    // called after.  This allows for allocating a correctly sized memory block for the COM call,
    // then to break up the memory block and build an object that c# can digest.

    abstract internal class DVDMarshaler : ICustomMarshaler
    {
        #region Data Members
        // The cookie isn't currently being used.
        protected string m_cookie;

        // The managed object passed in to MarshalManagedToNative, and modified in MarshalNativeToManaged
        protected object m_obj;
        #endregion

        // The constructor.  This is called from GetInstance (below)
        public DVDMarshaler(string cookie)
        {
            // If we get a cookie, save it.
            m_cookie = cookie;
        }

        // Called just before invoking the COM method.  The returned IntPtr is what goes on the stack
        // for the COM call.  The input arg is the DvdTitleAttributes that was passed to the method.
        virtual public IntPtr MarshalManagedToNative(object managedObj)
        {
            // Save off the passed-in value.  Safe since we just checked the type.
            m_obj = managedObj;

            // Create an appropriately sized buffer, and send it to the marshaler to
            // make the COM call with.
            IntPtr p = Marshal.AllocCoTaskMem(GetNativeDataSize());

            return p;
        }

        // Called just after invoking the COM method.  The IntPtr is the same one that just got returned
        // from MarshalManagedToNative.  The return value is unused.
        virtual public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return m_obj;
        }

        // Release the (now unused) buffer
        virtual public void CleanUpNativeData(IntPtr pNativeData)
        {
            if (pNativeData != IntPtr.Zero)
            {
                Marshal.Release(pNativeData);
            }
        }

        // Release the (now unused) managed object
        virtual public void CleanUpManagedData(object managedObj)
        {
            m_obj = null;
        }

        // This routine is (apparently) never called by the marshaler.  However it can be useful.
        abstract public int GetNativeDataSize();

        // GetInstance is called by the marshaler in preparation to doing custom marshaling.  The (optional)
        // cookie is the value specified in MarshalCookie="asdf", or "" is none is specified.

        // It is commented out in this abstract class, but MUST be implemented in derived classes
        //public static ICustomMarshaler GetInstance(string cookie)
    }

    // c# does not correctly create structures that contain ByValArrays of structures (or enums!).  Instead
    // of allocating enough room for the ByValArray of structures, it only reserves room for a ref,
    // even when decorated with ByValArray and SizeConst.  Needless to say, if DirectShow tries to
    // write to this too-short buffer, bad things will happen.
    //
    // To work around this for the DvdTitleAttributes structure, use this custom marshaler
    // by declaring the parameter DvdTitleAttributes as:
    //
    //    [In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(DTAMarshaler))]
    //    DvdTitleAttributes pTitle
    //
    // See DVDMarshaler for more info on custom marshalers

    internal class DTAMarshaler : DVDMarshaler
    {
        public DTAMarshaler(string cookie) : base(cookie)
        {
        }

        // Called just after invoking the COM method.  The IntPtr is the same one that just got returned
        // from MarshalManagedToNative.  The return value is unused.
        override public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            DvdTitleAttributes dta = m_obj as DvdTitleAttributes;

            // Copy in the value, and advance the pointer
            dta.AppMode = (DvdTitleAppMode)Marshal.ReadInt32(pNativeData);
            pNativeData = (IntPtr)(pNativeData.ToInt64() + Marshal.SizeOf(typeof(int)));

            // Copy in the value, and advance the pointer
            dta.VideoAttributes = (DvdVideoAttributes) Marshal.PtrToStructure(pNativeData, typeof (DvdVideoAttributes));
            pNativeData = (IntPtr)(pNativeData.ToInt64() + Marshal.SizeOf(typeof(DvdVideoAttributes)));

            // Copy in the value, and advance the pointer
            dta.ulNumberOfAudioStreams = (int)Marshal.ReadInt32(pNativeData);
            pNativeData = (IntPtr)(pNativeData.ToInt64() + Marshal.SizeOf(typeof(int)));

            // Allocate a large enough array to hold all the returned structs.
            dta.AudioAttributes = new DvdAudioAttributes[8];
            for (int x=0; x < 8; x++)
            {
                // Copy in the value, and advance the pointer
                dta.AudioAttributes[x] = (DvdAudioAttributes) Marshal.PtrToStructure(pNativeData, typeof (DvdAudioAttributes));
                pNativeData = (IntPtr)(pNativeData.ToInt64() + Marshal.SizeOf(typeof(DvdAudioAttributes)));
            }

            // Allocate a large enough array to hold all the returned structs.
            dta.MultichannelAudioAttributes = new DvdMultichannelAudioAttributes[8];
            for (int x=0; x < 8; x++)
            {
                // MultichannelAudioAttributes has nested ByValArrays.  They need to be individually copied.

                dta.MultichannelAudioAttributes[x].Info = new DvdMUAMixingInfo[8];

                for (int y=0; y < 8; y++)
                {
                    // Copy in the value, and advance the pointer
                    dta.MultichannelAudioAttributes[x].Info[y] = (DvdMUAMixingInfo)Marshal.PtrToStructure(pNativeData, typeof(DvdMUAMixingInfo));
                    pNativeData = (IntPtr)(pNativeData.ToInt64() + Marshal.SizeOf(typeof(DvdMUAMixingInfo)));
                }

                dta.MultichannelAudioAttributes[x].Coeff = new DvdMUACoeff[8];

                for (int y=0; y < 8; y++)
                {
                    // Copy in the value, and advance the pointer
                    dta.MultichannelAudioAttributes[x].Coeff[y] = (DvdMUACoeff)Marshal.PtrToStructure(pNativeData, typeof(DvdMUACoeff));
                    pNativeData = (IntPtr)(pNativeData.ToInt64() + Marshal.SizeOf(typeof(DvdMUACoeff)));
                }
            }

            // The DvdMultichannelAudioAttributes needs to be 16 byte aligned
            pNativeData = (IntPtr)(pNativeData.ToInt64() + 4);

            // Copy in the value, and advance the pointer
            dta.ulNumberOfSubpictureStreams = (int)Marshal.ReadInt32(pNativeData);
            pNativeData = (IntPtr)(pNativeData.ToInt64() + Marshal.SizeOf(typeof(int)));

            // Allocate a large enough array to hold all the returned structs.
            dta.SubpictureAttributes = new DvdSubpictureAttributes[32];
            for (int x=0; x < 32; x++)
            {
                // Copy in the value, and advance the pointer
                dta.SubpictureAttributes[x] = (DvdSubpictureAttributes) Marshal.PtrToStructure(pNativeData, typeof (DvdSubpictureAttributes));
                pNativeData = (IntPtr)(pNativeData.ToInt64() + Marshal.SizeOf(typeof(DvdSubpictureAttributes)));
            }

            // Note that 4 bytes (more alignment) are unused at the end

            return null;
        }

        // The number of bytes to marshal out
        override public int GetNativeDataSize()
        {
            // This is the actual size of a DvdTitleAttributes structure
            return 3208;
        }

        // This method is called by interop to create the custom marshaler.  The (optional)
        // cookie is the value specified in MarshalCookie="asdf", or "" is none is specified.
        public static ICustomMarshaler GetInstance(string cookie)
        {
            return new DTAMarshaler(cookie);
        }
    }

    // See DTAMarshaler for an explanation of the problem.  This class is for marshaling
    // a DvdKaraokeAttributes structure.
    internal class DKAMarshaler : DVDMarshaler
    {
        // The constructor.  This is called from GetInstance (below)
        public DKAMarshaler(string cookie) : base(cookie)
        {
        }

        // Called just after invoking the COM method.  The IntPtr is the same one that just got returned
        // from MarshalManagedToNative.  The return value is unused.
        override public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            DvdKaraokeAttributes dka = m_obj as DvdKaraokeAttributes;

            // Copy in the value, and advance the pointer
            dka.bVersion = (byte)Marshal.ReadByte(pNativeData);
            pNativeData = (IntPtr)(pNativeData.ToInt64() + Marshal.SizeOf(typeof(byte)));

            // DWORD Align
            pNativeData = (IntPtr)(pNativeData.ToInt64() + 3);

            // Copy in the value, and advance the pointer
            dka.fMasterOfCeremoniesInGuideVocal1 = Marshal.ReadInt32(pNativeData) != 0;
            pNativeData = (IntPtr)(pNativeData.ToInt64() + Marshal.SizeOf(typeof(bool)));

            // Copy in the value, and advance the pointer
            dka.fDuet = Marshal.ReadInt32(pNativeData) != 0;
            pNativeData = (IntPtr)(pNativeData.ToInt64() + Marshal.SizeOf(typeof(bool)));

            // Copy in the value, and advance the pointer
            dka.ChannelAssignment = (DvdKaraokeAssignment)Marshal.ReadInt32(pNativeData);
            pNativeData = (IntPtr)(pNativeData.ToInt64() + Marshal.SizeOf(DvdKaraokeAssignment.GetUnderlyingType(typeof(DvdKaraokeAssignment))));

            // Allocate a large enough array to hold all the returned structs.
            dka.wChannelContents = new DvdKaraokeContents[8];
            for (int x=0; x < 8; x++)
            {
                // Copy in the value, and advance the pointer
                dka.wChannelContents[x] = (DvdKaraokeContents) Marshal.ReadInt16(pNativeData);
                pNativeData = (IntPtr)(pNativeData.ToInt64() + Marshal.SizeOf(DvdKaraokeContents.GetUnderlyingType(typeof(DvdKaraokeContents))));
            }

            return null;
        }

        // The number of bytes to marshal out
        override public int GetNativeDataSize()
        {
            // This is the actual size of a DvdKaraokeAttributes structure.
            return 32;
        }

        // This method is called by interop to create the custom marshaler.  The (optional)
        // cookie is the value specified in MarshalCookie="asdf", or "" is none is specified.
        public static ICustomMarshaler GetInstance(string cookie)
        {
            return new DKAMarshaler(cookie);
        }
    }
}