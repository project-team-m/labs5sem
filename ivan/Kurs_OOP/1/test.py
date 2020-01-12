import os, shutil, random


class Catalog():

    def __init__(self):
        self.CATALOG = input('Введите название каталога: ')
        self.way = self.CATALOG

    def notEmpty(self):
        if os.path.exists(self.way):
            print(os.path.exists(self.way))
        else:
            os.path.exists(self.way)
            print(os.path.exists(self.way))

    def creatCatalog(self):
        try:
            os.mkdir(self.way)
        except OSError:
            print("Создать дирректорию {} не удалось".format(self.way))
        else:
            print("Успешно создана директория {} ".format(self.way))

    def deleteCatalog(self):
        try:
            shutil.rmtree(self.way)
        except OSError:
            print("Удалить директорию {} не удалось".format(self.way))
        else:
            print("Успешно удалена директория {} ".format(self.way))

    def createFile(self, file):
        a = File(file)
        a.createFile(self.way)
        self.files.append(a)

    def fillFile(self, file):
        a = File(file)

        a.write()

    def deletFile(self, file):
        for i in self.files:
            if file == i.file_name:
                i.deleteFile(self.way)

    def outCatalog(self):
        try:
            os.listdir(self.way)
            self.CATALOG = os.listdir(self.way)
        except OSError:
            print("Каталог не существует")
        else:
            print(self.CATALOG)


class File():
    def __init__(self, file_name):
        self.file_name = file_name

    def __new__(cls, file_name):
        try:
            open(file_name, 'rb')
            return object.__new__(cls)
        except:
            print('Файл {} не существует'.format(file_name))
            return None

    def write(self):
        N = 10
        print('Файл: {}'.format(self.file_name))
        with open('{}/{}.{}'.format(self.way, self.file_name, "txt"), 'w') as f:
            for x in range(0, N):
                f.write(str(random.randint(0, 1)) + "")

    def createFile(self, way):
        with open('{}/{}.{}'.format(way, self.file_name, "txt"), 'w') as f:
            pass

    def deleteFile(self, way):
        os.remove('{}/{}.{}'.format(way, self.file_name, "txt"))

    def searchFile(self, way, search):
        pass


if __name__ == '__main__':
    a = Catalog()
    a.creatCatalog()
    a.createFile('xczxc')
    a.createFile('sdaasdas')
    a.createFile('tuhfg')
    a.createFile('nvbnv')
    a.createFile('pkljh')
    # a.fillFile()
    a.deletFile('nvbnv')
