from django.shortcuts import render
from django.http import Http404, HttpResponseRedirect
from django.urls import reverse
from django.db import transaction
from My_BD.apps import BD

def show_tables(request):
    if BD.a.login and BD.a.lvl == 0:
        return render(request, 'root/main_root.html', {'tables': BD.tables})
    BD.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_table(request):
    if BD.a.login and BD.a.lvl == 0:
        save = BD.scripts
        BD.scripts = None
        if BD.link:
            link = BD.link
        else:
            link = request.POST['link']

        if BD.a.output_tables(link):
            last = BD.a.output_tables(link)[-1]
        else:
            last = None
        return render(request, 'root/show_table.html',
                      {'tables': BD.tables,
                       'table': link,
                       'titles': BD.a.output_titles(link),
                       'last': last,
                       'strings': BD.a.output_tables(link), 'scripts': save})
    BD.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def enter_table(request):
    if BD.a.login and BD.a.lvl == 0:
        if '_del' in request.POST:
            print(request.POST['table'])
            BD.a.del_string(request.POST['id_old'], request.POST['table'])
            BD.link = request.POST['table']
            return HttpResponseRedirect(reverse('root:show_table'))
    BD.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))
