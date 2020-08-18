cmake_minimum_required(VERSION 3.16)
project(Ankura C)

set(CMAKE_C_STANDARD 11)

if(NOT("${CMAKE_SIZEOF_VOID_P}" STREQUAL "8"))
    message(FATAL_ERROR "Compilation for non-64-bit architecture is not supported.")
endif()

if(MSVC OR MSYS OR MINGW)
    set(RID win-x64)
elseif(APPLE)
    set(RID osx-x64)
elseif(UNIX)
    set(RID linux-x64)
endif()

set(ROOT_DIRECTORY ${CMAKE_CURRENT_SOURCE_DIR}../../..)


set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${ROOT_DIRECTORY}/lib/${PROJECT_NAME}/${RID}/${CMAKE_BUILD_TYPE})
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${ROOT_DIRECTORY}/lib/${PROJECT_NAME}/${RID}/${CMAKE_BUILD_TYPE})
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${ROOT_DIRECTORY}/bin/${PROJECT_NAME}/${RID}/${CMAKE_BUILD_TYPE})

add_library(Ankura SHARED src/ankura.c)