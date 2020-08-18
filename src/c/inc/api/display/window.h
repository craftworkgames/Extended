#pragma once

#include "~display.h"

struct window
{
    window_states state;
    ak_display_parameters displayMode;
    rectangle_u32 bounds;
    size_u32 minimumSize;
    size_u32 maximumSize;
    u8* title;
};
