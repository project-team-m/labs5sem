#include <iostream>
#include <windows.h>
#include <stdio.h>
#include <tchar.h>
#include <fstream>
#include <string>


using namespace std;

void q1()
{
    ifstream file; // создаем объект класса ifstream
    file.open("E:\\Учеба\\Операционные системы\\Лаб 3\\Процессы.txt"); // открываем файл
    string line;
    STARTUPINFO si = { sizeof(si) };
    PROCESS_INFORMATION pi;
    while (getline(file, line)) {
        string name = line;
        wstring str = wstring(line.begin(), line.end());
        if (CreateProcess(str.c_str(), NULL, NULL, NULL, FALSE, NORMAL_PRIORITY_CLASS, NULL, NULL, &si, &pi))
        {
            CloseHandle(pi.hThread);
            WaitForInputIdle(pi.hProcess, INFINITE);
            getline(file, line);
            int time = stoi(line);
            if (WaitForSingleObject(pi.hProcess, time) == WAIT_TIMEOUT)
            {
                TerminateProcess(pi.hProcess, 0);
                cout << "Превышено время ожидания процесса " << name << endl;
            }
            CloseHandle(pi.hProcess);
            cout << "Процесс завершен " << name << endl;
        }
        else
        {
            ShellExecuteA(NULL, "open", "C:\\WINDOWS\\system32\\cmd.exe", "/k \"E:\\Учеба\\Операционные системы\\Лаб 3\\test.bat\"", 0, SW_SHOWNORMAL);
        }
    }

    file.close();
}

struct list
{
    string name;

};
const int n = 10;
list mas[n];


int q3()
{
	STARTUPINFO cif;
	ZeroMemory(&cif, sizeof(STARTUPINFO));
	PROCESS_INFORMATION pi;
	LPCWSTR str = L"C:\\Windows\\notepad.exe";
	string str2 = "F:\\Учеба\\Операционные системы\\Лаба 3\\output.txt";
	wchar_t path[] = L"C:\\Windows\\notepad.exe";
	if (CreateProcess(str, path,
		NULL, NULL, FALSE, NULL, NULL, NULL, &cif, &pi) == TRUE)
	{
		CloseHandle(pi.hThread);
		if (WaitForSingleObject(pi.hProcess, 5 * 1000) == WAIT_TIMEOUT)
		{
			//TerminateProcess(pi.hProcess, 0);
			cout << "+++" << endl;
		}
		//TerminateProcess(pi.hProcess, NO_ERROR);	// убрать процесс
		//CloseHandle(pi.hProcess);
	}

	STARTUPINFO si;					//Указатель на структуру типа STARTUPINFO, содержащей информацию о запуске процесса
	SECURITY_ATTRIBUTES sa;			// дескриптор защиты,обуславливает, может ли возвращенный дескриптор быть унаследован дочерними процессами.
	SECURITY_DESCRIPTOR sd;        //структура security для пайпов определяет дескриптор безопасности для нового потока.
	PROCESS_INFORMATION pi;		// Возвращаемые функцией дескрипторы и идентификаторы ID процесса и его главного потока

	HANDLE newstdin, newstdout;  //дескрипторы пайпов

	InitializeSecurityDescriptor(&sd, SECURITY_DESCRIPTOR_REVISION);
	SetSecurityDescriptorDacl(&sd, true, NULL, false);
	sa.lpSecurityDescriptor = &sd;
	sa.nLength = sizeof(SECURITY_ATTRIBUTES);
	sa.bInheritHandle = true;       //разрешаем наследование дескрипторов

	if (!CreatePipe(&newstdin, &newstdout, &sa, 0))   //создаем пайп  для stdin
	{
		cout << "Error CreatePipe" << endl;
		return 0;
	}

	if (!CreatePipe(&newstdin, &newstdout, &sa, 0)) //создаем пайп для stdout
	{
		cout << "Error CreatePipe" << endl;
		CloseHandle(newstdin);
		CloseHandle(newstdout);
		return 0;
	}

	fstream fp("F:\\lab_3\\Zad_3\\input.txt");
	fstream fr("F:\\lab_3\\Zad_3\\output.txt");
	for (int i = 0; i < n; i++) {
		fp >> mas[i].name;
		string a = mas[i].name;
		wstring s;
		s.assign(a.begin(), a.end());


		GetStartupInfo(&si);      //создаем startupinfo для дочернего процесса

		si.dwFlags = STARTF_USESTDHANDLES | STARTF_USESHOWWINDOW;
		si.wShowWindow = SW_HIDE;
		si.hStdOutput = newstdout;
		si.hStdError = newstdout;   //подменяем дескрипторы для
		si.hStdInput = newstdin;    // дочернего процесса

		if (!CreateProcess(s.c_str(), NULL, NULL, NULL, TRUE, CREATE_NEW_CONSOLE,
			NULL, NULL, &si, &pi))
		{
			cout << "CreateProcess" << endl;
			CloseHandle(newstdin);
			CloseHandle(newstdout);

			return 0;
		}
		else {
			fr << mas[i].name << endl;
		}


	}
}
*/
int main()
{
    setlocale(LC_ALL, "Russian");

    //q1();
    STARTUPINFO si = { sizeof(si) };
    PROCESS_INFORMATION pi;
    LPCWSTR str = L"C:\\Windows\\explorer.exe";
    if (CreateProcess(str, NULL, NULL, NULL, FALSE, NORMAL_PRIORITY_CLASS, NULL, NULL, &si, &pi))
    {
        CloseHandle(pi.hThread);
        WaitForInputIdle(pi.hProcess, INFINITE);

        if (WaitForSingleObject(pi.hProcess, 5 * 1000) == WAIT_TIMEOUT)
        {
            TerminateProcess(pi.hProcess, 0);
            cout << "+++" << endl;
        }
        CloseHandle(pi.hProcess);
        cout << "exit" << endl;
    }
}
