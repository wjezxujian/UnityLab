cmake_minimum_required(VERSION 2.6)
project (hello-cmake)
# The version number.
set (Tutorial_VERSION_MAJOR 1)
set (Tutorial_VERSION_MINOR 0)

# should we use our own math functions
option (USE_MYMATH "Use tutorial provided math implementation" ON)

# configure a header file to pass some of the CMake settings to the source codes
configure_file (
	"${PROJECT_SOURCE_DIR}/TutorialConfig.h.in"
	"${PROJECT_BINARY_DIR}/TutorialConfig.h"
)

# add the binary tree to the seatch path for include files
# so that we will find TutorialConfig.h
include_directories("${PROJECT_BINARY_DIR}")

# add the MathFunctions library?
#
if (USE_MYMATH)
	include_directories("${PROKECT_SOURCE_DIR}/MathFunctions")
	add_subdirectory(MathFunctions)
	set (EXTRA_LIBS ${EXTRA_LIBS} MathFunctions)
endif (USE_MYMATH)




add_executable(hello-cmake hello.cpp)
# target_link_libraries(hello-cmake MathFunctions)
target_link_libraries(hello-cmake ${EXTRA_LIBS})