cmake_minimum_required (VERSION 2.8)

if (TESTS)
    SET (PROJ_NAME "gtest-entrypoint")
    PROJECT (${PROJ_NAME})
    mark_lib_for_reuse(${PROJ_NAME})

if (IOS)
    export_ios_framework (${PROJ_NAME} GLKit)
    export_ios_framework (${PROJ_NAME} QuartzCore)
    export_ios_framework (${PROJ_NAME} CoreGraphics)
    export_ios_framework (${PROJ_NAME} OpenAL)
    export_ios_framework (${PROJ_NAME} CoreAudio)
    export_ios_framework (${PROJ_NAME} Foundation)
    export_ios_framework (${PROJ_NAME} UIKit)
    export_ios_framework (${PROJ_NAME} AudioToolbox)
    export_ios_framework (${PROJ_NAME} OpenGLES)
    export_ios_framework (${PROJ_NAME} MessageUI)
endif ()

    add_module_dependency(${PROJ_NAME} "gtest" "1.6.0")
    export_module_dependency(${PROJ_NAME} "gtest" "1.6.0")

    make_library(${PROJ_NAME})

    if (TARGET ${PROJ_NAME})
        link_module_dependencies(${PROJ_NAME})
    endif ()
endif ()
