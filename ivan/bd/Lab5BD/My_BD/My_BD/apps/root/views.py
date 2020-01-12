from django.shortcuts import render
from django.http import Http404, HttpResponseRedirect
from django.urls import reverse
from django.db import transaction
from My_BD.apps import BD


def show_tables(request):
    if BD.a.login and BD.a.lvl == 3:
        return render(request, 'root/main_root.html', {'tables': BD.a.get_tables()})
    BD.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def show_components(request):
    if BD.a.login and BD.a.lvl == 3:
        save = BD.scripts
        BD.scripts = None
        link = 'http://127.0.0.1:8000/root/enter_components/'
        link2 = 'http://127.0.0.1:8000/root/enter_components_s/'
        return render(request, 'root/show_table.html',
                      {'tittles': BD.a.show_components()[0], 'strings': BD.a.show_components()[1:], 'link': link,
                       'link2': link2, 'last': BD.a.show_components()[-1], 'scripts': save})
    BD.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_table_old(request):
    if BD.a.login and BD.a.lvl == 3:
        save = BD.scripts
        BD.scripts = None
        if 'table' in request.POST:
            BD.link = request.POST['table']
        if 'link' in request.POST:
            link = request.POST['link']
        else:
            link = BD.link
            BD.link = None
        BD.link = link
        if '_apply' in request.POST:
            print(request.POST['operation'] == 'INSERT')
            if request.POST['operation'] == 'INSERT':
                BD.a.del_string(request.POST['id'], request.POST['table'])
            elif request.POST['operation'] == 'DELETE':
                mass = []
                m = BD.a.output_titles(request.POST['table'])
                for i in request.POST:
                    if i in m:
                        mass.append(request.POST[i])
                BD.a.insert(mass, request.POST['table'])
            elif request.POST['operation'] == 'UPDATE':
                mass = []
                m = BD.a.output_titles(request.POST['table'])
                for i in request.POST:
                    if i in m:
                        mass.append(request.POST[i])
                mass.append(request.POST['id'])
                BD.a.update(mass, request.POST['table'])
            return HttpResponseRedirect(reverse('root:show_table'))
        else:
            return render(request, 'root/backups.html',
                          {'tables': BD.a.get_tables(),
                           'table': link,
                           'titles': BD.a.output_titles('{}_old'.format(link)),
                           'strings': BD.a.output_tables('{}_old'.format(link)), 'scripts': save})
    BD.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_table(request):
    if BD.a.login and BD.a.lvl == 3:
        save = BD.scripts
        BD.scripts = None
        if 'table' in request.POST:
            BD.link = request.POST['table']
        if '_del' in request.POST:
            BD.a.del_string(request.POST['id_old'], request.POST['table'])
        elif '_edit' in request.POST:
            mass = []
            m = BD.a.output_titles(BD.link)
            for i in request.POST:
                if i in m:
                    mass.append(request.POST[i])
            mass.append(request.POST['id_old'])
            try:
                BD.a.update(mass, BD.link)
            except:
                BD.a.rollback()
                BD.scripts = 'incorrect input'
        elif '_add' in request.POST:
            try:
                mass = []
                m = BD.a.output_titles(BD.link)
                for i in request.POST:
                    if i in m:
                        mass.append(request.POST[i])
                BD.a.insert(mass, BD.link)
            except:
                BD.a.rollback()
                BD.scripts = 'incorrect input'

        if 'link' in request.POST:
            link = request.POST['link']
        else:
            link = BD.link
            BD.link = None
        if BD.a.output_tables(link):
            last = BD.a.output_tables(link)[-1]
        else:
            last = None
        if '_search' in request.POST:
            BD.link = link
            mass = []
            m = BD.a.output_titles(BD.link)
            for i in request.POST:
                if i in m:
                    mass.append(request.POST[i])

            return render(request, 'root/show_table.html', {
                'tables': BD.a.get_tables(),
                'table': link,
                'titles': BD.a.output_titles(link),
                'strings': BD.a.search_component(request.POST['table'], mass),
                'last': last,
                'scripts': save
            })
        else:
            BD.link = link
            return render(request, 'root/show_table.html',
                          {'tables': BD.a.get_tables(),
                           'table': link,
                           'titles': BD.a.output_titles(link),
                           'last': last,
                           'strings': BD.a.output_tables(link), 'scripts': save})
    BD.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def enter_table(request):
    if BD.a.login and BD.a.lvl == 3:

        return HttpResponseRedirect(reverse('root:show_table'))

def back_num(request):
    if BD.a.login and BD.a.lvl == 3:
        BD.a.back_num(request.POST['num'], request.POST['table'])
        return HttpResponseRedirect(reverse('root:show_table'))

    BD.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

