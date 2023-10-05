
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Remoter;

// <summary>
// Killing the process with p.Kill is not always what we need
// For example PAExec waits for CTRL+C signal, do some job, reports and exits only after that.
// So I need a way to send CTRL+C signal to windowless process
//
// See explanations and the code:
// https://stanislavs.org/stopping-command-line-applications-programatically-with-ctrl-c-events-from-net/
// https://stackoverflow.com/a/15281070
// </summary>

public static class KillConsoleProcess
{
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool AttachConsole(uint dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    static extern bool FreeConsole();

    [DllImport("kernel32.dll")]
    static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate HandlerRoutine, bool Add);

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GenerateConsoleCtrlEvent(CtrlTypes dwCtrlEvent, uint dwProcessGroupId);

    delegate bool ConsoleCtrlDelegate(CtrlTypes CtrlType);

    // Enumerated type for the control messages sent to the handler routine
    enum CtrlTypes : uint
    {
        CTRL_C_EVENT = 0,
        CTRL_BREAK_EVENT,
        CTRL_CLOSE_EVENT,
        CTRL_LOGOFF_EVENT = 5,
        CTRL_SHUTDOWN_EVENT
    }

    public static void StopByCtrlC(Process process, int waitForExitTimeout = 2000)
    {
        if (!AttachConsole((uint)process.Id))
        {
            return;
        }

        // Disable Ctrl-C handling for our program
        SetConsoleCtrlHandler(null, true);

        // Sent Ctrl-C to the attached console
        GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0);

        // Wait for the graceful end of the process.
        // If the process will not exit in time specified by 'waitForExitTimeout', the process will be killed
        using (new Timer((dummy => { if (!process.HasExited) process.Kill(); }), null, waitForExitTimeout, Timeout.Infinite))
        {
            // Must wait here. If we don't wait and re-enable Ctrl-C handling below too fast, we might terminate ourselves.
            process.WaitForExit();
        }

        FreeConsole();

        // Re-enable Ctrl-C handling or any subsequently started programs will inherit the disabled state.
        SetConsoleCtrlHandler(null, false);
    }

}