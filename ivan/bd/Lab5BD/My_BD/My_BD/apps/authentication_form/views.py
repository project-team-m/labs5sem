from django.shortcuts import render
from django.http import Http404, HttpResponseRedirect
from django.urls import reverse
from My_BD.apps import BD

scripts = None


def index(request):
    if 'login' in request.POST and 'password' in request.POST:
        BD.a = BD.BD(request.POST['login'], request.POST['password'], )
        if BD.a.lvl == 0:
            print(HttpResponseRedirect(reverse('op_od:show_tables')))
            return HttpResponseRedirect(reverse('op_od:show_tables'))
        elif BD.a.lvl == 3:
            print(1)
            return HttpResponseRedirect(reverse('root:show_tables'))
        BD.scripts = 'wrong password or login'
        return HttpResponseRedirect(reverse('main_form:index'))
    return render(request, 'authentication_form/main_form.html', {'scripts': BD.scripts})