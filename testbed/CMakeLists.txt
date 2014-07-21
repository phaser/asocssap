cmake_minimum_required (VERSION 2.8)

SET (PROJ_NAME "testbed")
SET (CMAKE_MODULE_PATH ${CMAKE_MODULE_PATH} ${KRAL_PATH}) # Necessary for all the other modules to find
                                                          # the macros in KRAL
PROJECT (${PROJ_NAME})
INCLUDE (KRALMain)

if (WIN32)
    SET (BUILD_TYPE WIN32 CACHE INTERNAL "Build type" FORCE)
elseif (IOS)
    SET (BUILD_TYPE MACOSX_BUNDLE CACHE INTERNAL "Build type" FORCE)
endif (WIN32)

add_module_dependency(${PROJ_NAME} "euler" "")
add_module_dependency(${PROJ_NAME} "infoarena" "")
add_module_dependency(${PROJ_NAME} "timus" "")
add_module_dependency(${PROJ_NAME} "codeforces" "")
add_module_dependency(${PROJ_NAME} "usaco" "")

build_module(${PROJ_NAME} ${BUILD_TYPE})

link_module_dependencies(${PROJ_NAME})

