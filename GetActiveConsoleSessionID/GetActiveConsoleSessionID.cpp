#include <windows.h>
#include <iostream>

int main() {
    DWORD sessionId = WTSGetActiveConsoleSessionId();

    if (sessionId == 0xFFFFFFFF) {
        std::cerr << "Failed to get active console session ID." << std::endl;
        return 1;
    }

    std::cout << sessionId << std::endl;
    return 0;
}
