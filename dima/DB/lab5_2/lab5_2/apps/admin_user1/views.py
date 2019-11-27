from django.shortcuts import render
from django.http import Http404, HttpResponseRedirect, HttpResponse
from django.urls import reverse
from . import DB

def show_components(request):
    global a
    a = DB.DB('admin', 'admin')
    return render(request, 'admin_user1/show_components.html', {'components': a.show_components()})
