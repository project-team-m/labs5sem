import os
import re
from chardet.universaldetector import UniversalDetector

class File:
    def __init__(self, file_name):
        self.file_name = file_name

        detector = UniversalDetector()
        with open(self.file_name, 'rb') as lines:
            for line in lines:
                detector.feed(line)
                if detector.done:
                    break
        detector.close()

        self.encoding = detector.result['encoding']

    def __new__(cls, file_name):
        try:
            open(file_name, 'rb')
            return object.__new__(cls)
        except:
            print('File {} is not exists'.format(file_name))
            return None

    def write(self, text):
        print('File: {}'.format(self.file_name))
        with open(self.file_name, 'wb') as F:
            F.write(text)

    def __str__(self):
        string = ''
        with open(self.file_name, 'rb') as lines:
            for line in lines:
                string = '{}{}'.format(string, line)

        return string


class Dir:
    def __init__(self, path):
        self.path = path
        self.all_files = os.listdir(path)
        self.files = []
        for file in self.all_files:
            if re.search(r'.txt\b', file):
                tmp = File(file)
                if tmp:
                    self.files.append(tmp)

    def __new__(cls, path):
        try:
            return object.__new__(cls)
        except:
            print('No such directory')
            return None

    def show(self, ind):
        try:
            return self.files[ind]
        except:
            return None

    def __str__(self):
        files = self.all_files[0]
        for file in self.all_files[1:]:
            files = '{}, {}'.format(files, file)
        return '{}\n{}'.format(self.path, files)