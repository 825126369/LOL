#include<windows.h>
#include<stdio.h>

const char* processName = "League of Legends (TM) Client";

int Width = 0;
int Height = 0;

void mouse(int m,int n)
{
    mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, (DWORD)(m / (double)Width * 65535), (DWORD)(n / (double)Height * 65535), 0, 0);
    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
    mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
	mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
	Sleep(5);
}

void PressKey(char Key)
{
	//keybd_event((byte)Key, 0, 0, 0);
	//keybd_event(162, (byte)MapVirtualKey((byte)162, 0), 0, 0);
    keybd_event((byte)Key, (byte)MapVirtualKey((byte)Key, 0), 0, 0);
	keybd_event((byte)Key, (byte)MapVirtualKey((byte)Key, 0), KEYEVENTF_KEYUP, 0);
	//keybd_event(162, (byte)MapVirtualKey((byte)162, 0), KEYEVENTF_KEYUP, 0);
	
	Sleep(1000);
}

void PressKey2(char Key)
{
	keybd_event((byte)Key, (byte)MapVirtualKey((byte)Key, 0), 0, 0);
	Sleep(1000);
	keybd_event((byte)Key, (byte)MapVirtualKey((byte)Key, 0), KEYEVENTF_KEYUP, 0);
	Sleep(1000);
}
 
void RandomMove()
{
	int posX = rand() % Width;
	int posY = rand() % Height;
	mouse(posX, posY);
	printf("mouse Position (%d, %d) \n", posX, posY);
}
 
void SetWidthHeight()
{
	DEVMODE devMode;
	devMode.dmSize = sizeof(DEVMODE);
	EnumDisplaySettings(NULL, ENUM_CURRENT_SETTINGS, &devMode);

	RECT fullscreenWindowRect = {
		devMode.dmPosition.x,
		devMode.dmPosition.y,
		devMode.dmPosition.x + (LONG)(devMode.dmPelsWidth),
		devMode.dmPosition.y + (LONG)(devMode.dmPelsHeight)
	};

	Width = fullscreenWindowRect.right - fullscreenWindowRect.left;
	Height = fullscreenWindowRect.bottom - fullscreenWindowRect.top;
	printf("WIdth: %d, Height: %d\n", Width, Height);
}

void ShowDesktop()
{
	keybd_event(VK_LWIN, 0, 0, 0);
	keybd_event('D', 0, 0, 0);
	keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0);
	keybd_event('D', 0, KEYEVENTF_KEYUP, 0);
}

int main()
{
	HWND mWnd = FindWindowA(NULL, processName);
	if (mWnd == NULL)
	{
		printf("Please Start %s !!!", processName); 
		Sleep(5000);
		return 1;
	}

	printf("Game Start %s\n", processName);
	SetWidthHeight();

	SendMessage(mWnd, WM_SETREDRAW, 0, 0);
	SendMessage(mWnd, WM_SETREDRAW, 1, 0);
	ShowDesktop();

	Sleep(1000);

	srand(1);
    while(1)
    {
		SendMessage(mWnd, WM_SETREDRAW, 1, 0);

		ShowWindow(mWnd, SW_SHOWNORMAL);
		//SwitchToThisWindow(mWnd, 1);
		if (!SetForegroundWindow(mWnd))
		{
			printf("SetForegroundWindow Fail \n");
		}

		MoveWindow(mWnd, 0, 0, Width, Height, 1);
		
		PressKey2(VK_SPACE);
		RandomMove();
		PressKey('Q');
		PressKey('W');
		PressKey('E');
		PressKey('R');
		PressKey('D');
		PressKey('F');
		PressKey2(VK_SPACE);

		PressKey(VK_RETURN);
		PressKey('H');
		const char* charInfo = "WO ZHENG ZAI GUA JI HA HA";
		for (int i = 0; i < strlen(charInfo); i++)
		{
			PressKey(charInfo[i]);
		}
		PressKey(VK_RETURN);

		SendMessage(mWnd, WM_SETREDRAW, 0, 0);
        Sleep(5000);
		PressKey(' ');
    }

    return 0;
}