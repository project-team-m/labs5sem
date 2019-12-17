//#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <string>
#include <fstream>

using namespace std;

struct WAVHEADER
{
	char                chunkId[4];                 // Информация о формате файла (RIFF), Содержит символы “RIFF” в ASCII кодировке;
	unsigned long       ChunkSize;                  // Размер без  chunkId[4];
	char                format[4];                  // Формат потоковых данных (WAVE);
	char                subchunk1Id[4];             // Описание параметров WAV-файла (fmt-chunk);
	unsigned long       subchunk1Size;              // Размер подструктуры  subchunk1  (16 байт);
	unsigned short      wFomatTag;                  // Аудио формат (PCM = 1);
	unsigned short      nChannels;                  // Количество каналов (Моно = 1, Стерео = 2);
	unsigned long       SamplesPerSec;              // Частота дискретизации в Гц;
	unsigned long       ByteRate;                   // Кол-во передаваемых байт в секунду воспроизведения;
	unsigned short      blockAlign;                 // Размер сэмпла в байтах 16 бит = 2 байта моно, 32 бита = 4 байта стерео (включая все каналы);
	unsigned short      BitsPerSample;              // Количество бит в сэмпле. Так называемая “глубина” или точность звучания. 8 бит, 16 бит и т.д. /// битов на отсчет
	char                Subchunk2ID[4];             // Символы "Data", начало чанка данных;
	unsigned long       Subchunk2Size;              // Размер области данных в байтах;
};

void Info()
{
	FILE* file;
	errno_t error;
	error = fopen_s(&file, "1.wav", "rb");
	WAVHEADER header;

	fread_s(&header, sizeof(WAVHEADER), sizeof(WAVHEADER), 1, file);

	// Выводим полученные данные
	cout << "Информация о файле:" << endl;
	cout << "Инфо о формате:        " << hex << (int)header.chunkId[0] << " " << (int)header.chunkId[1] << " " << (int)header.chunkId[2] << " " << (int)header.chunkId[3] << endl;
	cout << "Формат данных:         " << hex << (int)header.format[0] << " " << (int)header.format[1] << " " << (int)header.format[2] << " " << (int)header.format[3] << endl;
	cout << "Параметы WAV-файла:    " << hex << (int)header.subchunk1Id[0] << " " << (int)header.subchunk1Id[1] << " " << (int)header.subchunk1Id[2] << " " << (int)header.subchunk1Id[3] << endl;
	cout << "Размер:                " << dec << header.ChunkSize << " байт" << endl;
	cout << "Частота:               " << header.SamplesPerSec << " Гц" << endl;
	cout << "Каналов:               " << header.nChannels;
	if (header.nChannels == 2) cout << " => Стерео" << endl;
	else cout << " => Моно" << endl;

	cout << "Байт в секунду:        " << header.ByteRate << endl;
	cout << "Размер сэмпла:         " << header.BitsPerSample << endl;
	cout << "Размер области данных: " << header.Subchunk2Size << " байт" << endl;

	// Длительность воспроизведения в секундах
	double fDurationSeconds = 1.f * header.Subchunk2Size / (header.BitsPerSample / 8) / header.nChannels / header.SamplesPerSec;
	int iDurationMinutes = (int)floor(fDurationSeconds) / 60;
	fDurationSeconds = fDurationSeconds - (iDurationMinutes * 60);
	//cout << "Продолжительность: " << iDurationMinutes << ":" << fDurationSeconds << endl;
	fclose(file);
}

string cod(string str)
{
	fstream f("cod.txt", ios_base::out | ios::binary);
	char sym; //символ, который мы будем считывать
	int kol = 1;// количество повторяющихся символов
	string res;
	cout << "Сжатие начато!" << endl;
	for (int i = 0; i < str.length(); i++)
	{
		sym = str[i];//считываем символ
		if (sym != str[i + 1] || kol == 9)// если символ не совпадает со следующим символом в файле
		{
			res += (char)(kol + 48);
			res += sym;
			kol = 0;
		}
		kol++;
	}
	f << res;
	f.close();
	cout << "Сжато!" << endl;
	return res;
}

void decode()
{
	fstream f("cod.txt", ios_base::in | ios::binary);
	fstream file_decompr("dec.wav", ios_base::out | ios::binary);
	char sym1, sym2; // предыдущий и последующий символы
	const char zero = '0';
	cout << "Декомпрессия начата!" << endl;
	while (f.peek() != EOF)
	{
		f.get(sym1);
		f.get(sym2);
		for (int i = 0; i < sym1 - zero; i++)
			file_decompr << sym2;
	}
	f.close();
	file_decompr.close();
	cout << "Декомпрессия завершена!" << endl;
}

int main()
{
	setlocale(LC_ALL, "");
	Info();
	fstream f("1.wav", ios_base::in | ios::binary);
	string s;
	cout << "Подготовка файла для сжатия" << endl;
	while (!f.eof())s += f.get();
	f.close();
	cod(s);
	decode();
}