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
CMAKE_SOURCE_DIR = /home/dekeyel/Projects/labs5sem/dima/oop/lab6

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /home/dekeyel/Projects/labs5sem/dima/oop/lab6/cmake-build-debug

# Include any dependencies generated for this target.
include CMakeFiles/lab6.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/lab6.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/lab6.dir/flags.make

CMakeFiles/lab6.dir/main.cpp.o: CMakeFiles/lab6.dir/flags.make
CMakeFiles/lab6.dir/main.cpp.o: ../main.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/dekeyel/Projects/labs5sem/dima/oop/lab6/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/lab6.dir/main.cpp.o"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/lab6.dir/main.cpp.o -c /home/dekeyel/Projects/labs5sem/dima/oop/lab6/main.cpp

CMakeFiles/lab6.dir/main.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/lab6.dir/main.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/dekeyel/Projects/labs5sem/dima/oop/lab6/main.cpp > CMakeFiles/lab6.dir/main.cpp.i

CMakeFiles/lab6.dir/main.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/lab6.dir/main.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/dekeyel/Projects/labs5sem/dima/oop/lab6/main.cpp -o CMakeFiles/lab6.dir/main.cpp.s

CMakeFiles/lab6.dir/first.cpp.o: CMakeFiles/lab6.dir/flags.make
CMakeFiles/lab6.dir/first.cpp.o: ../first.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/dekeyel/Projects/labs5sem/dima/oop/lab6/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Building CXX object CMakeFiles/lab6.dir/first.cpp.o"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/lab6.dir/first.cpp.o -c /home/dekeyel/Projects/labs5sem/dima/oop/lab6/first.cpp

CMakeFiles/lab6.dir/first.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/lab6.dir/first.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/dekeyel/Projects/labs5sem/dima/oop/lab6/first.cpp > CMakeFiles/lab6.dir/first.cpp.i

CMakeFiles/lab6.dir/first.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/lab6.dir/first.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/dekeyel/Projects/labs5sem/dima/oop/lab6/first.cpp -o CMakeFiles/lab6.dir/first.cpp.s

CMakeFiles/lab6.dir/second.cpp.o: CMakeFiles/lab6.dir/flags.make
CMakeFiles/lab6.dir/second.cpp.o: ../second.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/dekeyel/Projects/labs5sem/dima/oop/lab6/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_3) "Building CXX object CMakeFiles/lab6.dir/second.cpp.o"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/lab6.dir/second.cpp.o -c /home/dekeyel/Projects/labs5sem/dima/oop/lab6/second.cpp

CMakeFiles/lab6.dir/second.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/lab6.dir/second.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/dekeyel/Projects/labs5sem/dima/oop/lab6/second.cpp > CMakeFiles/lab6.dir/second.cpp.i

CMakeFiles/lab6.dir/second.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/lab6.dir/second.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/dekeyel/Projects/labs5sem/dima/oop/lab6/second.cpp -o CMakeFiles/lab6.dir/second.cpp.s

# Object files for target lab6
lab6_OBJECTS = \
"CMakeFiles/lab6.dir/main.cpp.o" \
"CMakeFiles/lab6.dir/first.cpp.o" \
"CMakeFiles/lab6.dir/second.cpp.o"

# External object files for target lab6
lab6_EXTERNAL_OBJECTS =

lab6: CMakeFiles/lab6.dir/main.cpp.o
lab6: CMakeFiles/lab6.dir/first.cpp.o
lab6: CMakeFiles/lab6.dir/second.cpp.o
lab6: CMakeFiles/lab6.dir/build.make
lab6: CMakeFiles/lab6.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/home/dekeyel/Projects/labs5sem/dima/oop/lab6/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_4) "Linking CXX executable lab6"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/lab6.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/lab6.dir/build: lab6

.PHONY : CMakeFiles/lab6.dir/build

CMakeFiles/lab6.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/lab6.dir/cmake_clean.cmake
.PHONY : CMakeFiles/lab6.dir/clean

CMakeFiles/lab6.dir/depend:
	cd /home/dekeyel/Projects/labs5sem/dima/oop/lab6/cmake-build-debug && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /home/dekeyel/Projects/labs5sem/dima/oop/lab6 /home/dekeyel/Projects/labs5sem/dima/oop/lab6 /home/dekeyel/Projects/labs5sem/dima/oop/lab6/cmake-build-debug /home/dekeyel/Projects/labs5sem/dima/oop/lab6/cmake-build-debug /home/dekeyel/Projects/labs5sem/dima/oop/lab6/cmake-build-debug/CMakeFiles/lab6.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/lab6.dir/depend

