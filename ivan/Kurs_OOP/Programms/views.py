import os, shutil


class Catalog():

    def __init__(self):
        self.CATALOG = input('Введите название каталога: ')
        self.way = self.CATALOG
        self.files = []


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
    def __init__(self, file):
        self.file_name = file

    def createFile(self, way):
        with open('{}/{}.{}'.format(way, self.file_name, "txt"), 'w') as f:
            pass

    def deleteFile(self, way):
        os.remove('{}/{}.{}'.format(way, self.file_name, "txt"))

    def searchFile(self, way, search):
        pass


if __name__ == '__main__':
    a = Catalog()
    #a.creatCatalog()
    a.createFile('xczxc')
    a.createFile('sdaasdas')
    a.createFile('tuhfg')
    a.createFile('nvbnv')
    a.createFile('pkljh')
    a.deletFile('nvbnv')