#pragma once

#include <stdlib.h>
#include <stdbool.h>

#include "target_platform.h"

#ifndef ANKURA_API_DECL
#if TARGET_WINDOWS
#define ANKURA_API_DECL __declspec(dllexport)
#else
#define ANKURA_API_DECL extern
#endif
#endif

#include "u8.h"
#include "u16.h"
#include "u32.h"
#include "u64.h"
#include "i8.h"
#include "i16.h"
#include "i32.h"
#include "i64.h"
#include "ak_result.h"
#include "rectangle_u32.h"
#include "size_u32.h"
#include "size_i32.h"