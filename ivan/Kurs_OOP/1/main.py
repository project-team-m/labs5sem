from viewss import *

class Menu:
    def __init__(self):
        self.___args = ['Выход']

    def _case(self, arg):
        pass

    def __len__(self):
        return len(self.___args)

    def __str__(self):
        s = 'Выберете пункт: '
        for i in range(len(self.___args)):
            s = '{}\n{}){}'.format(s, i + 1, self.___args[i])

        return s


class Main_menu(Menu):
    def __init__(self):
        Menu.__init__(self)
        self.__args = [
            'Выбрать дирректорию.',
            'Вывести содержание файла.',
            'Вывести все файлы в дирректории.',
            self.__args[-1]
        ]
        self.path = None

    def _case(self, __args):
        if __args == '1':
            path = input('Введите дирректорию, для выбора текущего каталога нажмите enter: ')
            try:
                self.path = Dir(path)
                return 'Успешно'
            except:
                __args = input('Неудача, \n1) Венуться в предыдущее меню.\n2) Выбрать дирректорию ещё раз.')
                if __args == '1':
                    return None
                else:
                    self._case('1')
        elif __args == '2':
            pass



a = Main_menu()
print(a)