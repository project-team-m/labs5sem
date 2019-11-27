from django.shortcuts import render
from django.http import Http404, HttpResponseRedirect
from django.urls import reverse
from lab5_3.apps import DB

def show_tables(request):
    if DB.a.login:
        return render(request, 'root/main_root.html', {'tables': DB.tables})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_components(request):
    DB.a = DB.DB('admin', 'admin')
    if not DB.a.login:
        return render(request, 'authentication_form/main_form.html')
    return render(request, 'root/show_table.html', {'names': a.show_components()[0], 'components': a.show_components()[1:]})
