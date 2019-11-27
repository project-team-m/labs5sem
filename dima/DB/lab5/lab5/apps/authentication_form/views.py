from django.shortcuts import render
from django.http import Http404, HttpResponseRedirect, HttpResponse
from django.urls import reverse

def index(request):
    return render(request, 'authentication_form/main_form.html')

def check_user(request):
    a = (request.POST['login'], request.POST['password'],)
    print(a)
    return HttpResponse('ok')