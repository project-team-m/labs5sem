import os, random, re


class File:
    def __init__(self, file_name):
        self.file_name = file_name

    def __new__(cls, file_name):
        try:
            open(file_name, 'r')
            return object.__new__(cls)
        except:
            print('Файл {} не существует'.format(file_name))
            return None

    def write(self):
        print('Файл {}'.format(self.file_name))
        with open(self.file_name, 'w') as f:
            f.write(self.fill())

    def fill(self):
        N = 1000
        tmp = ''
        for x in range(0, N):
            tmp += (str(random.randint(0, 5)) + " ")
        return tmp

    def __str__(self):
        string = ''
        with open(self.file_name, 'r') as lines:
            for line in lines:
                string = '{}{}'.format(string, line)

        return string

    def find(self, word):
        result = self.__str__()
        tmp = False
        for m in re.finditer(r'{}'.format(word), result):
            tmp = True
            print('Слово {} найдено в позиции'.format(word), m.start())
        if tmp == False:
            print('Слово {} не было найдено в файле {}'.format(word, self.file_name))


class Dir:
    def __init__(self, path):
        if path == '':
            path = '.'
        self.path = path
        self.all_files = os.listdir(path)
        self.__files = []
        for file in self.all_files:
            if re.search(r'.txt\b', file):
                tmp = File(file)
                if tmp:
                    self.__files.append(tmp)

    def __new__(cls, path):
        try:
            return object.__new__(cls)
        except:
            print('Дирректория не существует')
            return None

    def show(self):
        tmp = 0
        for file in self.all_files:
            if re.search(r'.txt', file):
                print(tmp, file)
                tmp += 1

    def showfile(self, ind):
        try:
            return self.__files[ind]
        except:
            return None

    def __str__(self):
        files = self.all_files[0]
        for file in self.all_files[1:]:
            files = '{}, {}'.format(files, file)
        return '{}\n{}'.format(self.path, files)



if __name__ == '__main__':
    a = Dir('')
    b = File('asdasdasd.txt')
