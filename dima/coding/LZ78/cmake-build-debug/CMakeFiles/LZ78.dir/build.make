# CMAKE generated file: DO NOT EDIT!
# Generated by "NMake Makefiles" Generator, CMake Version 3.15

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

!IF "$(OS)" == "Windows_NT"
NULL=
!ELSE
NULL=nul
!ENDIF
SHELL = cmd.exe

# The CMake executable.
CMAKE_COMMAND = "C:\Program Files\JetBrains\CLion 2019.2.5\bin\cmake\win\bin\cmake.exe"

# The command to remove a file.
RM = "C:\Program Files\JetBrains\CLion 2019.2.5\bin\cmake\win\bin\cmake.exe" -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = D:\Projects\labs5sem\dima\coding\LZ78

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = D:\Projects\labs5sem\dima\coding\LZ78\cmake-build-debug

# Include any dependencies generated for this target.
include CMakeFiles\LZ78.dir\depend.make

# Include the progress variables for this target.
include CMakeFiles\LZ78.dir\progress.make

# Include the compile flags for this target's objects.
include CMakeFiles\LZ78.dir\flags.make

CMakeFiles\LZ78.dir\main.cpp.obj: CMakeFiles\LZ78.dir\flags.make
CMakeFiles\LZ78.dir\main.cpp.obj: ..\main.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=D:\Projects\labs5sem\dima\coding\LZ78\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/LZ78.dir/main.cpp.obj"
	C:\PROGRA~2\MICROS~2\2019\COMMUN~1\VC\Tools\MSVC\1423~1.281\bin\Hostx86\x86\cl.exe @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) /FoCMakeFiles\LZ78.dir\main.cpp.obj /FdCMakeFiles\LZ78.dir\ /FS -c D:\Projects\labs5sem\dima\coding\LZ78\main.cpp
<<

CMakeFiles\LZ78.dir\main.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/LZ78.dir/main.cpp.i"
	C:\PROGRA~2\MICROS~2\2019\COMMUN~1\VC\Tools\MSVC\1423~1.281\bin\Hostx86\x86\cl.exe > CMakeFiles\LZ78.dir\main.cpp.i @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E D:\Projects\labs5sem\dima\coding\LZ78\main.cpp
<<

CMakeFiles\LZ78.dir\main.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/LZ78.dir/main.cpp.s"
	C:\PROGRA~2\MICROS~2\2019\COMMUN~1\VC\Tools\MSVC\1423~1.281\bin\Hostx86\x86\cl.exe @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) /FoNUL /FAs /FaCMakeFiles\LZ78.dir\main.cpp.s /c D:\Projects\labs5sem\dima\coding\LZ78\main.cpp
<<

# Object files for target LZ78
LZ78_OBJECTS = \
"CMakeFiles\LZ78.dir\main.cpp.obj"

# External object files for target LZ78
LZ78_EXTERNAL_OBJECTS =

LZ78.exe: CMakeFiles\LZ78.dir\main.cpp.obj
LZ78.exe: CMakeFiles\LZ78.dir\build.make
LZ78.exe: CMakeFiles\LZ78.dir\objects1.rsp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=D:\Projects\labs5sem\dima\coding\LZ78\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX executable LZ78.exe"
	"C:\Program Files\JetBrains\CLion 2019.2.5\bin\cmake\win\bin\cmake.exe" -E vs_link_exe --intdir=CMakeFiles\LZ78.dir --rc=C:\PROGRA~2\WI3CF2~1\10\bin\100183~1.0\x86\rc.exe --mt=C:\PROGRA~2\WI3CF2~1\10\bin\100183~1.0\x86\mt.exe --manifests  -- C:\PROGRA~2\MICROS~2\2019\COMMUN~1\VC\Tools\MSVC\1423~1.281\bin\Hostx86\x86\link.exe /nologo @CMakeFiles\LZ78.dir\objects1.rsp @<<
 /out:LZ78.exe /implib:LZ78.lib /pdb:D:\Projects\labs5sem\dima\coding\LZ78\cmake-build-debug\LZ78.pdb /version:0.0  /machine:X86 /debug /INCREMENTAL /subsystem:console kernel32.lib user32.lib gdi32.lib winspool.lib shell32.lib ole32.lib oleaut32.lib uuid.lib comdlg32.lib advapi32.lib 
<<

# Rule to build all files generated by this target.
CMakeFiles\LZ78.dir\build: LZ78.exe

.PHONY : CMakeFiles\LZ78.dir\build

CMakeFiles\LZ78.dir\clean:
	$(CMAKE_COMMAND) -P CMakeFiles\LZ78.dir\cmake_clean.cmake
.PHONY : CMakeFiles\LZ78.dir\clean

CMakeFiles\LZ78.dir\depend:
	$(CMAKE_COMMAND) -E cmake_depends "NMake Makefiles" D:\Projects\labs5sem\dima\coding\LZ78 D:\Projects\labs5sem\dima\coding\LZ78 D:\Projects\labs5sem\dima\coding\LZ78\cmake-build-debug D:\Projects\labs5sem\dima\coding\LZ78\cmake-build-debug D:\Projects\labs5sem\dima\coding\LZ78\cmake-build-debug\CMakeFiles\LZ78.dir\DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles\LZ78.dir\depend

