import os, re

# Класс котрый представляет из себя объект файла
class File:
    # Конструктор инициализации файла
    def __init__(self, file_name, way='.'):
        self.file_name = file_name
        self.way = way

    # Конструктор вызываемый при открытия текстового файла
    def __new__(cls, file_name, way='.'):
        try:
            open('{}/{}'.format(way, file_name), 'r')
            return object.__new__(cls)
        except:
            return None

    # Возвращает содержимое файла
    def __str__(self):
        string = ''
        with open(self.file_name, 'r') as lines:
            for line in lines:
                string = '{}{}'.format(string, line)

        return string


# Класс представляющий дирректорию
class Dir:
    # Инициализация каталога и содержимого каталога
    def __init__(self, way):
        if way == '':
            way = '.'
        self.way = way
        self.all_files = os.listdir(way)
        # Массив элементов класса File
        self._files = []
        for file in self.all_files:
            if re.search(r'.txt', file):
                tmp = File(file, way)
                if tmp:
                    self._files.append(tmp)

    # Если директория существует, то вызываем конструктор
    def __new__(cls, way):
        try:
            return object.__new__(cls)
        except:
            return None

    # Выводит все файлы в дирректории
    def show_all_files(self):
        if self.way == '.':
            way = 'текущей директории'
        else:
            way = 'директории {}'.format(self.way)
        s = 'Объекты в {}:'.format(way)
        if self.all_files:
            for i in self.all_files:
                s = '{} {}'.format(s, i)
        else:
            s = '{} {}'.format(s, 'Пусто')
        return s


# Класс для поиска текста по шаблону
class Find:
    # Инициализация файла
    def __init__(self, file_name):
        self.file_name = file_name

    # Возвращает содержимое файла
    def __str__(self):
        string = ''
        with open(self.file_name, 'r') as lines:
            for line in lines:
                string = '{}{}'.format(string, line)

        return string

    # Выводит текст и позиции которые были найдены в файле
    def find(self, word):
        result = self.__str__()
        tmp = False
        for m in re.finditer(r'{}'.format(word), result):
            tmp = True
            print('Слово {} найдено в позиции'.format(word), m.start())
        if tmp == False:
            print('Слово {} не было найдено в файле {}'.format(word, self.file_name))