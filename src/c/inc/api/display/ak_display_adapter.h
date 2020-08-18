#pragma once

#include "~display.h"

struct ak_display_adapter
{
    u32 pixelFormat;
    size_u32 resolution;
    u32 refreshRate;
};

typedef struct ak_display_adapter ak_display_adapter;

