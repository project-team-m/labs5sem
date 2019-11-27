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
    if DB.a.login:
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_components()[0], 'strings': DB.a.show_components()[1:]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_brands(request):
    if DB.a.login:
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_brands()[0], 'strings': DB.a.show_brands()[1:]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_stocks(request):
    if DB.a.login:
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_stocks()[0], 'strings': DB.a.show_stocks()[1:]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_stock(request):
    if DB.a.login:
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_stock()[0], 'strings': DB.a.show_stock()[1:]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_clients(request):
    if DB.a.login:
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_clients()[0], 'strings': DB.a.show_clients()[1:]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def show_workers(request):
    if DB.a.login:
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_workers()[0], 'strings': DB.a.show_workers()[1:]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_positions(request):
    if DB.a.login:
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_positions()[0], 'strings': DB.a.show_positions()[1:]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_basket(request):
    if DB.a.login:
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_basket()[0], 'strings': DB.a.show_basket()[1:]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_orders(request):
    if DB.a.login:
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_orders()[0], 'strings': DB.a.show_orders()[1:]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))
