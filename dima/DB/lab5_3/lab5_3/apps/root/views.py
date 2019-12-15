from django.shortcuts import render
from django.http import Http404, HttpResponseRedirect
from django.urls import reverse
from django.db import transaction
from lab5_3.apps import DB


def show_tables(request):
    if DB.a.login and DB.a.lvl == 3:
        return render(request, 'root/main_root.html', {'tables': DB.a.get_tables()})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def show_components(request):
    if DB.a.login and DB.a.lvl == 3:
        save = DB.scripts
        DB.scripts = None
        link = 'http://127.0.0.1:8000/root/enter_components/'
        link2 = 'http://127.0.0.1:8000/root/enter_components_s/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_components()[0], 'strings': DB.a.show_components()[1:], 'link': link,
                       'link2': link2, 'last': DB.a.show_components()[-1], 'scripts': save})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def show_table(request):
    if DB.a.login and DB.a.lvl == 3:
        save = DB.scripts
        DB.scripts = None
        if 'table' in request.POST:
            DB.link = request.POST['table']
        if '_del' in request.POST:
            DB.a.del_string(request.POST['id_old'], request.POST['table'])
        elif '_edit' in request.POST:
            mass = []
            m = DB.a.output_titles(DB.link)
            for i in request.POST:
                if i in m:
                    mass.append(request.POST[i])
            mass.append(request.POST['id_old'])
            try:
                DB.a.update(mass, DB.link)
            except:
                DB.a.rollback()
                DB.scripts = 'incorrect input'
        elif '_add' in request.POST:
            try:
                mass = []
                m = DB.a.output_titles(DB.link)
                for i in request.POST:
                    if i in m:
                        mass.append(request.POST[i])
                DB.a.insert(mass, DB.link)
            except:
                DB.a.rollback()
                DB.scripts = 'incorrect input'

        if 'link' in request.POST:
            link = request.POST['link']
        else:
            link = DB.link
            DB.link = None
        if DB.a.output_tables(link):
            last = DB.a.output_tables(link)[-1]
        else:
            last = None
        if '_search' in request.POST:
            DB.link = link
            mass = []
            m = DB.a.output_titles(DB.link)
            for i in request.POST:
                if i in m:
                    mass.append(request.POST[i])

            return render(request, 'root/show_table.html', {
                'tables': DB.a.get_tables(),
                'table': link,
                'titles': DB.a.output_titles(link),
                'strings': DB.a.search_component(request.POST['table'], mass),
                'last': last,
                'scripts': save
            })
        else:
            DB.link = link
            return render(request, 'root/show_table.html',
                          {'tables': DB.a.get_tables(),
                           'table': link,
                           'titles': DB.a.output_titles(link),
                           'last': last,
                           'strings': DB.a.output_tables(link), 'scripts': save})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def enter_table(request):
    if DB.a.login and DB.a.lvl == 3:

        return HttpResponseRedirect(reverse('root:show_table'))

    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

