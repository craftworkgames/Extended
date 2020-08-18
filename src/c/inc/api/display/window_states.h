// Copyright (c) Lucas Girouard-Stranks All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#pragma once
#pragma ide diagnostic ignored "hicpp-signed-bitwise"

enum window_states
{
    WINDOW_STATES_NONE = 0x0,
    WINDOW_STATES_IS_VISIBLE = 1 << 1,
    WINDOW_STATES_IS_MINIMIZED = 1 << 2,
    WINDOW_STATES_IS_MAXIMIZED = 1 << 3,
    WINDOW_STATES_IS_FOCUSED = 1 << 4,
    WINDOW_STATES_FORCE_U16 = 0xFFFF
};

typedef enum window_states window_states;

