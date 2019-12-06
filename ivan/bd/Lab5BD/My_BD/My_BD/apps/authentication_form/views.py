from django.shortcuts import render
from django.http import Http404, HttpResponseRedirect
from django.urls import reverse
from My_BD.apps import BD

scripts = None

def index(request):
    return render(request, 'authentication_form/main_form.html', {'scripts': BD.scripts})

def check_user(request):
    BD.a = BD.BD(request.POST['login'], request.POST['password'], )
    if BD.a.login:
        return HttpResponseRedirect(reverse('root:show_tables'))
    BD.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))