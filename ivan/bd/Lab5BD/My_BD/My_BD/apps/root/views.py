from django.shortcuts import render
from django.http import Http404, HttpResponseRedirect
from django.urls import reverse
from django.db import transaction
from My_BD.apps import BD

def show_tables(request):
    if BD.a.login and BD.a.lvl == 3:
        return render(request, 'root/main_root.html', {'tables': BD.tables})
    BD.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_table(request):
    if BD.a.login and BD.a.lvl == 3:
        save = BD.scripts
        BD.scripts = None
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
            return render(request, 'root/show_table.html', {
                'tables': BD.tables,
                'table': link,
                'titles': BD.a.output_titles(link),
                'strings': BD.a.search_component(request.POST['table'], request.POST['search']),
                'last': last,
                'scripts': save
            })
        else:
            BD.link = link
            return render(request, 'root/show_table.html',
                          {'tables': BD.tables,
                           'table': link,
                           'titles': BD.a.output_titles(link),
                           'last': last,
                           'strings': BD.a.output_tables(link), 'scripts': save})
    BD.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def enter_table(request):
    if BD.a.login and BD.a.lvl == 3:
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
            mass = []
            m = BD.a.output_titles(BD.link)
            for i in request.POST:
                if i in m:
                    mass.append(request.POST[i])
            BD.a.insert(mass, BD.link)
            #BD.a.rollback()
            #BD.scripts = 'incorrect input'
        return HttpResponseRedirect(reverse('root:show_table'))



    BD.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))
