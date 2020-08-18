#pragma once

#include "../~core.h"
#include "~display.h"

#define _THIS struct ak_display_device *_this

struct ak_display_device
{
    u8* name;

    ak_display_window (*CreateWindow) (_THIS, ak_window_descriptor* descriptor);
    void (*DestroyWindow) (_THIS, ak_display_window window);
};

typedef struct ak_display_device ak_display_device;

ANKURA_API_DECL void ak_display_Setup(const ak_display_parameters* parameters);
ANKURA_API_DECL void ak_display_Shutdown();

ak_display_window ak_display_CreateWindow(ak_window_descriptor* descriptor);
void ak_window_DestroyWindow(ak_display_window window);