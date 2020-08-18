#pragma once

#ifdef _WIN32
    #define TARGET_PLATFORM_WINDOWS
    #ifndef _WIN64
        #error "The target environment is Windows 32-bit; only 64-bit is supported."
    #endif
#elif __APPLE__
    #define TARGET_PLATFORM_APPLE
    #include "TargetConditionals.h"
    #if TARGET_RT_64_BIT == 0
        #error "The target environment is Apple 32-bit; only 64-bit is supported."
    #endif
    #if TARGET_OS_OSX
        #define TARGET_PLATFORM_MACOS
    #elif TARGET_OS_IOS
        #define TARGET_PLATFORM_IOS
    #elif TARGET_OS_TV
        #define TARGET_PLATFORM_TVOS
    #elif TARGET_OS_WATCH
        #define TARGET_PLATFORM_WATCHOS
    #endif
#elif __linux__
    #define TARGET_PLATFORM_LINUX
    //TODO: Expand Linux targets
    #error "Linux is planned, but not yet supported; please use an issue on GitHub about supporting your linux distro."
#else
    #error "The target environment is unknown; please use an issue on GitHub about supporting a new platform."
#endif