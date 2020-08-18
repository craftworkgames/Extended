#pragma once

enum ak_display_parameters {
    AK_WINDOW_MODE_NONE = 0x0,
    AK_WINDOW_MODE_FULLSCREEN_DEDICATED,
    AK_WINDOW_MODE_FULLSCREEN_BORDERLESS,
    AK_WINDOW_MODE_BORDERLESS,
    AK_WINDOW_MODE_RESIZEABLE,
    _AK_WINDOW_DISPLAY_MODE_FORCE_U8 = 0xFF //NOLINT
};

typedef enum ak_display_parameters ak_window_mode;