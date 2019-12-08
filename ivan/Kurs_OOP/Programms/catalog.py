import os, shutil

CATALOG = ""


class Catalog():

    def __init__(self):
        CATALOG = input('Введите название каталога: ')
        self.way = os.getcwd() + "/" + CATALOG

    def notEmpty(self):
        if os.path.exists(self.way):
            print(os.path.exists(self.way))
        else:
            os.path.exists(self.way)
            print(os.path.exists(self.way))

    def createCatalog(self):
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

    def outCatalog(self):
        try:
            os.listdir(self.way)
            catalog = os.listdir(self.way)
        except OSError:
            print("Каталог не существует")
        else:
            print(catalog)


if __name__ == "__main__":
    a = Catalog()
    a.createCatalog()
    a.outCatalog()
