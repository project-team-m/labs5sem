# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.15

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


# Remove some rules from gmake that .SUFFIXES does not remove.
SUFFIXES =

.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /snap/clion/98/bin/cmake/linux/bin/cmake

# The command to remove a file.
RM = /snap/clion/98/bin/cmake/linux/bin/cmake -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /home/paket/Project/labs5sem/ivan/Codir/HAF

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /home/paket/Project/labs5sem/ivan/Codir/HAF/cmake-build-debug

# Include any dependencies generated for this target.
include CMakeFiles/HAF.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/HAF.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/HAF.dir/flags.make

CMakeFiles/HAF.dir/main.cpp.o: CMakeFiles/HAF.dir/flags.make
CMakeFiles/HAF.dir/main.cpp.o: ../main.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/paket/Project/labs5sem/ivan/Codir/HAF/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/HAF.dir/main.cpp.o"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/HAF.dir/main.cpp.o -c /home/paket/Project/labs5sem/ivan/Codir/HAF/main.cpp

CMakeFiles/HAF.dir/main.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/HAF.dir/main.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/paket/Project/labs5sem/ivan/Codir/HAF/main.cpp > CMakeFiles/HAF.dir/main.cpp.i

CMakeFiles/HAF.dir/main.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/HAF.dir/main.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/paket/Project/labs5sem/ivan/Codir/HAF/main.cpp -o CMakeFiles/HAF.dir/main.cpp.s

CMakeFiles/HAF.dir/main2.cpp.o: CMakeFiles/HAF.dir/flags.make
CMakeFiles/HAF.dir/main2.cpp.o: ../main2.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/paket/Project/labs5sem/ivan/Codir/HAF/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Building CXX object CMakeFiles/HAF.dir/main2.cpp.o"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/HAF.dir/main2.cpp.o -c /home/paket/Project/labs5sem/ivan/Codir/HAF/main2.cpp

CMakeFiles/HAF.dir/main2.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/HAF.dir/main2.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/paket/Project/labs5sem/ivan/Codir/HAF/main2.cpp > CMakeFiles/HAF.dir/main2.cpp.i

CMakeFiles/HAF.dir/main2.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/HAF.dir/main2.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/paket/Project/labs5sem/ivan/Codir/HAF/main2.cpp -o CMakeFiles/HAF.dir/main2.cpp.s

# Object files for target HAF
HAF_OBJECTS = \
"CMakeFiles/HAF.dir/main.cpp.o" \
"CMakeFiles/HAF.dir/main2.cpp.o"

# External object files for target HAF
HAF_EXTERNAL_OBJECTS =

HAF: CMakeFiles/HAF.dir/main.cpp.o
HAF: CMakeFiles/HAF.dir/main2.cpp.o
HAF: CMakeFiles/HAF.dir/build.make
HAF: CMakeFiles/HAF.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/home/paket/Project/labs5sem/ivan/Codir/HAF/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_3) "Linking CXX executable HAF"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/HAF.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/HAF.dir/build: HAF

.PHONY : CMakeFiles/HAF.dir/build

CMakeFiles/HAF.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/HAF.dir/cmake_clean.cmake
.PHONY : CMakeFiles/HAF.dir/clean

CMakeFiles/HAF.dir/depend:
	cd /home/paket/Project/labs5sem/ivan/Codir/HAF/cmake-build-debug && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /home/paket/Project/labs5sem/ivan/Codir/HAF /home/paket/Project/labs5sem/ivan/Codir/HAF /home/paket/Project/labs5sem/ivan/Codir/HAF/cmake-build-debug /home/paket/Project/labs5sem/ivan/Codir/HAF/cmake-build-debug /home/paket/Project/labs5sem/ivan/Codir/HAF/cmake-build-debug/CMakeFiles/HAF.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/HAF.dir/depend

