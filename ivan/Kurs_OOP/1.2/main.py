# Импортируем классы: File, Dir, Find из views.py
from views import *


# Класс из которого будут наследоваться потомки всех меню
class Menu:
    # Статическая переменная для объекта с директорией
    dir = None

    # Конструктор, в котором инициализируется protected массив элементов меню с один элементом "Выход"
    def __init__(self):
        self._el = ['Выход']

    # Функция для работы с выбранными пунктами меню
    def case(self, el):
        if el == str(len(self._el)):
            return 1

    # Перегрузка операции len() для того, чтобы при написании len(object_Menu) возращалась длина массива элементов меню
    def __len__(self):
        return len(self._el)

    # Возращает строку для вывода его на экран
    def __str__(self):
        s = '1) {}'.format(self._el[0])
        for i in range(1, len(self._el)):
            s = '{}\n{}) {}'.format(s, i + 1, self._el[i])

        return '{}\n{}'.format(s, 'Выберете пункт: ')


# Это меню используется, если пользователь указал неверный путь. Класс наследуется от Menu
class RepeatDirMenu(Menu):
    def __init__(self):
        Menu.__init__(self)
        self._el = [
            'Указать путь ещё раз.',
            self._el[-1]
        ]

    # Дополняем функцию case из класса Menu
    def case(self, el):
        if el == '1':
            return el
        return Menu.case(self, el)


# Меню для вывода содержимого файла
class PrintFile(Menu):
    def __init__(self):
        Menu.__init__(self)
        # Если пользователь указал путь до директории, то в меню будет выбор из этих файлов
        if Menu.dir:
            mass = Menu.dir.get_files()
        else:
            mass = []

        self._el = mass + [
            'Указать путь до нового файла.',
            self._el[-1]
        ]

    # Дополняем функцию case из класса Menu
    def case(self, el):
        if el == str(len(self._el) - 1):
            way = input('Укажите путь до файла: ')

            if len(way.split('/')) == 1:
                tmp = File(way)
            else:
                tmp = File(way.split('/')[-1], way[:(-1 * len(way.split('/')[-1])) - 1])
            if tmp:
                # Если пользователь указал путь до существующего файла и его можно открыть,
                # то его содержимое будет выведено на экран
                print(tmp.__str__())
            else:
                # Иначе вызывается меню для повтора или выхода из данного пункта
                print('Неудача')
                Now_menu = RepeatDirMenu()
                while True:
                    print(Now_menu)
                    switch = Now_menu.case(input())
                    if switch == '1':
                        self.case(el)
                        break
                    elif switch:
                        break

        elif not Menu.case(self, el):
            try:
                # Если пользователь выбрал один из файлов, находящихся в директории, которую он указал ранее,
                # то будет выведен этот файл
                print(Menu.dir.show(int(el) - 1).__str__())
            except:
                print('Неверно выбран пункт.')

        return Menu.case(self, el)


# Меню в котором происходит поиск по шаблону
class ChangeFind(PrintFile):
    def __init__(self):
        PrintFile.__init__(self)

        # Дополняем функцию case из класса Menu
        def case(self, el):
            if el == str(len(self._el) - 1):
                way = input('Укажите путь до файла: ')

                if len(way.split('/')) == 1:
                    tmp = File(way)
                else:
                    tmp = File(way.split('/')[-1], way[:(-1 * len(way.split('/')[-1])) - 1])
                if tmp:
                    # Если пользователь указал корректный путь до файла, то ему будет предложенно ввести,
                    # текст который нужно найти в файле
                    while True:
                        print('Для файла {} введите текст который хотели бы найти'.format(tmp.file_name))
                        #print(Now_menu)
                        #switch = Now_menu.case(input())
                        switch = case(input())
                        if switch:
                            if switch != 1:
                                # После выбора кодировки записываем в файл содержимое в новой кодировке
                                Find.find(tmp.__str__(), switch)
                                break
                            else:
                                break

                else:
                    print('Неудача')
                    Now_menu = RepeatDirMenu()
                    while True:
                        print(Now_menu)
                        switch = Now_menu.case(input())
                        if switch == '1':
                            self.case(el)
                            break
                        elif switch:
                            break
            elif not Menu.case(self, el):
                try:
                    # То же самое, что и для файла, который пользователь указал по пути, за исключением того,
                    # что берётся файл класса Dir из массива файлов класса Files
                    while True:
                        print('Для файла {} с кодировкой  выберете новую кодировку из списка'.format(
                            Menu.dir.show(int(el) - 1).file_name)
                        )
                        #print(Now_menu)
                        #switch = Now_menu.case(input())
                        switch = case(input())
                        if switch:
                            if switch != 1:
                                Menu.dir.show(int(el) - 1).write(Find.find(Menu.dir.show(int(el) - 1).__str__(),
                                                                                  switch))
                                break
                            else:
                                break
                except:
                    print('Неверно выбран пункт.')

            return Menu.case(self, el)

class MainMenu(Menu):
    def __init__(self):
        Menu.__init__(self)
        self._el = [
            'Выбрать дирректорию.',
            'Вывести содержание файла.',
            'Вывести все файлы и папки в дирректории.',
            'Найти текст.',
            self._el[-1]
        ]

    # Дополняем функцию case из класса Menu
    def case(self, el):
        if el == '1':
            way = input('Введите дирректорию, для выбора текущего каталога нажмите enter: ')
            try:
                # Создаём объект класса Dir, по пути, который указал пользователь
                Menu.dir = Dir(way)
                print('Успешно')
            except:
                # Если не удалось, то даём пользователю возможность указать ещё раз или выйти назад.
                print('Неудача')
                Now_menu = RepeatDirMenu()
                while True:
                    print(Now_menu)
                    switch = Now_menu.case(input())
                    if switch == el:
                        self.case(el)
                        break
                    elif switch:
                        break
        elif el == '2':
            # Выводит содержимое файла
            Now_menu = PrintFile()
            while True:
                print(Now_menu)
                if Now_menu.case(input()):
                    break
        elif el == '3':
            # Выводит названия всех файлов, в которых можно изменить кодировку, по пути, что указал пользователь
            if Menu.dir:
                print(Menu.dir)
            else:
                print('Директория пуста или не выбрана.')
        elif el == '4':
            # Изменяет кодировку файла
            Now_menu = ChangeFind()
            while True:
                print(Now_menu)
                if Now_menu.case(input()):
                    break

        return Menu.case(self, el)

    # Дополяем вывод на экран, для возможности выбора пункта меню
    def __str__(self):
        while True:
            print(Menu.__str__(self))
            if self.case(input()):
                break

        return 'Выход из программы'


# Точка входа
if __name__ == '__main__':
    a = MainMenu()
    print(a)