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
        with open('{}/{}'.format(self.way, self.file_name), 'r') as lines:
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

    # Возвращает массив имен файлов
    def get_files(self):
        mass = []
        for i in self._files:
            mass.append(i.file_name)
        return mass

    # Если директория существует, то вызываем конструктор
    def __new__(cls, way):
        try:
            return object.__new__(cls)
        except:
            return None

    # Выводит файлы из дирректории
    def show(self, el):
        return self._files[el].__str__()

    # Выводит все файлы из дирректории
    def __str__(self):
        string = "Файлы в папке {}: {}".format(self.way, self.all_files[0])
        for i in self.all_files[1:]:
            string = "{}, {}".format(string, i)
        return string


# Класс для поиска текста по шаблону
class Find:
    # Выводит текст и позиции которые были найдены в файле
    @staticmethod
    def find(string, word):
        result = []
        for m in re.finditer(r'{}'.format(word), string):
            result.append(m.start() + 1)

        return result
