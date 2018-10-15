************
*          *
*  Mirror  *
*          *
************



What is Mirror?
---------------

Mirror copies a directory to another location. If the destination directory
already exists, Mirror only copies the files having been added, modified,
or deleted comparatively to the source directory.

Mirror is especially adapted to frequent backups. Compared to a classical
directory copy, time is saved because only added or modified files are
transferred. Moreover, when Mirror detects that a file is no more present
in the source directory, it deletes it in the destination directory too.
This saves disk space if you rename or move files.

Mirror is a command line tool, without graphical interface.
It can be easily used in scripts and BATCH files.


Where can I find Mirror?
------------------------

Web Site        http://utilfr42.free.fr/util/Mirror.php
Author          Guillaume Ryder
E-mail          guillaume@ryder.fr


How to install Mirror?
----------------------

Choose the EXE file matching your Windows version:
- if you have Windows 95/98/ME, take Mirror9x.exe,
- if you have Windows NT/2000/XP/Vista/7/8, take MirrorNT.exe.
- if you have a 64-bit system, take Mirror64.exe.

Copy the file to C:\Windows for Mirror to be accessible without having
to specify its full path. You can then launch Mirror from a console box.

You can rename the file MirrorXX.exe you have chosen to Mirror.exe
or any other name.


How do I use Mirror?
--------------------

Classical use:
C:\MyFiles is the source directory
C:\Backup\MyFiles is the target directory

Make sure the directory C:\Backup\MyFiles exists, by creating it
if necessary. Mirror will never create it automatically.

Then, open a console box (command.com ou cmd.exe) and type:
mirror.exe C:\MyFiles C:\Backup\MyFiles

You can automate the full procedure by creating a BATCH file
(.bat extension) containing those two lines:

@echo off
mirror.exe C:\MyFiles C:\Backup\MyFiles


Why has Mirror problems with modification times?
------------------------------------------------

When using Mirror with the source directory in a NTFS partition
and the destination directory in a FAT16 or FAT32 partition,
time precision issues may occur. Modification times in FAT partitions
are rounded to the nearest 2 seconds, while modification times
in NTFS partitions are very precise (100 nanoseconds). This limitation
explains why files you just mirrored may not have exactly the same
modification time.

By default, Mirror tries to avoid time precision problems by considering
that modification times having a difference less than 5 seconds as equal.
You can adjust this precision with the --time-precision option.

Moreover, FAT partitions modification times are local: they take into account
the timezone and the daylight saving time. Mirror converts FAT modification
times to universal time (UTC) before comparing times, supposing that the FAT
partition has the same timezone as your PC. This is sufficient in most
cases, but not if you change your timezone in Windows settings, or if you use
external drives coming from a foreign country together with your own local drives.

If default settings don't work for you, you have two options:
- Enable --log-time-diff option to print time difference, then set options
  --time-shift and --time-precision accordingly.
- Use the --time-compare-contents option to compare files contents when they
  have different modification times. This will be safer than the option above,
  and still faster than rewriting all files.
Both methods will update the modification time of all destination files,
including the ones which have not been updated.


What are Mirror options?
------------------------

Launch the program without any argument to display the full help.


Usage: mirror <source directory> <destination directory> [options]

Mirrors copies/deletes files in the destination directory make sure it is
identical to the source directory. Not existing files will be copied, modified
files will be updated (overwritten), files not found in the source directory
will be deleted from the destination directory.

By default, files are compared against their size and modification time, but
these settings can be changed (see below).

If no --exclude nor --include option is specified, all files are examined.

Returns 0 on success, 1 on error.

Options:
--help, -h, -?, /?
Display this help.

-x=<specification>, --exclude=<specification>
Ignore the files matching the specification. The specification can use
jokers such as`?' and `*'. Enclose the whole option in quotes if it
contains spaces. This option may be specified multiple times. Cannot be
used with --include options.

-i=<specification>, --include=<specification>
Include only the files matching the specification. The specification can
use jokers such as `?' and `*'. Enclose the whole option in quotes if it
contains spaces. This option may be specified multiple times. Cannot be
used with --exclude options.

-v, --virtual
Virtual mode: do not alter any file, only display logging information.

-ua, --unset-archive
Unset the archive attribute of mirrored files in source directory.

-nr, --no-recurse
Do not recurse in subdirectories.

-nj, --no-junctions
Do not recurse in junction directories.

-nd, --no-delete
Never delete files from the destination directory, even if they are not
found in the source directory.

-na, --no-add
Never add files to the destination directory, even if they are found in
the source directory and missing in the destination directory.

-nu, --no-update
Never update files to the destination directory, even if they are found
in the source directory and different.

-nm, --no-meta
Do not update file metadata in the destination directory when it is the
only difference: attributes, last modification time, filename case.

-ct[=y/n], --compare-time[=y/n], enabled by default
Take modification time into account to compare files.

-cs[=y/n], --compare-size[=y/n], enabled by default
Take file size into account to compare files.

-ca[=y/n], --compare-archive[=y/n]
Take archive attribute into account to compare files. Files in source
directory having the archive attribute set are considered as different
than the matching file in destination directory.

-cc[=y/n], --compare-contents[=y/n]
Compare the files contents byte per byte. Slow but safe.

-tcc[=y/n], --time-compare-contents[=y/n]
If the files don't have the same modification time, compare them in the
same way as --compare-contents above and do not take the modification
times into account.

-fsf[=y/n], --time-shift-fat[=y/n], enabled by default
Convert FAT files times from local to system time before comparing them,
to avoid daylight saving time problems.

-tp[=number], --time-precision[=number], 5 by default
Precision for time comparison, in seconds. Useful to solve FAT time
precision issues.

-ts[=number], --time-shift[=number], 0 by default
The time shift to apply to destination files, in seconds. Can be
negative. Useful to solve FAT time issues.

-tm[=y/n], --time-meta[=y/n]
Mirror last modification times as part of file metadata updates.

-lh[=y/n], --log-header[=y/n], enabled by default
Display the mirroring header, indicating the mirrored directories.

-lc[=y/n], --log-changes[=y/n], enabled by default
Log copied/updated/deleted files.

-le[=y/n], --log-equal[=y/n]
Log identical files (thus not altered).

-li[=y/n], --log-ignored[=y/n]
Log files ignored due to --no-delete, --no-add, or --no-update.

-lcc[=y/n], --log-compare-contents[=y/n], enabled by default
Display file names when they are compared byte per byte.

-ltd[=y/n], --log-time-diff[=y/n]
Display modification time difference of compared files, taking into
account all time shifting options.

-lm[=y/n], --log-meta[=y/n], enabled by default
Log files having their meta information updated: attributes,
modification time, file name case.

-ld[=y/n], --log-directories[=y/n]
Display directories name when they are analyzed.

-ll[=y/n], --log-list[=y/n]
Display only the list of affected files, without operation name nor
headers for each examined directory.

-lo[=y/n], --log-oem[=y/n], enabled by default
Output filenames using OEM (DOS) charset. Disable this option if you
plan to use the log results in a Win32 script or program.
