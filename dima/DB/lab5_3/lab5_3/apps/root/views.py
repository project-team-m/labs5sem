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
        DB.scripts = None
        link = 'http://127.0.0.1:8000/root/enter_components/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_components()[0], 'strings': DB.a.show_components()[1:], 'link': link, 'last': DB.a.show_components()[-1]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def enter_components(request):
    if DB.a.login:
        DB.a.add_component([DB.a.change_to_norm_none(request.POST['id']),
                            DB.a.change_to_norm_none(request.POST['name']),
                            DB.a.change_to_norm_none(request.POST['purchase price']),
                            DB.a.change_to_norm_none(request.POST['selling price']),
                            DB.a.change_to_norm_none(request.POST['clock']),
                            DB.a.change_to_norm_none(request.POST['cores']),
                            DB.a.change_to_norm_none(request.POST['threads']),
                            DB.a.change_to_norm_none(request.POST['clock memory']),
                            DB.a.change_to_norm_none(request.POST['bus width']),
                            DB.a.change_to_norm_none(request.POST['memory']),
                            DB.a.change_to_norm_none(request.POST['timing']),
                            DB.a.change_to_norm_none(request.POST['id brand'])])
        return HttpResponseRedirect(reverse('root:components'))
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_brands(request):
    if DB.a.login:
        link = 'http://127.0.0.1:8000/root/enter_brands/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_brands()[0], 'strings': DB.a.show_brands()[1:], 'link': link, 'last': DB.a.show_brands()[1]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_stocks(request):
    if DB.a.login:
        link = 'http://127.0.0.1:8000/root/enter_stocks/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_stocks()[0], 'strings': DB.a.show_stocks()[1:], 'link': link, 'last': DB.a.show_stocks()[1]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_stock(request):
    if DB.a.login:
        link = 'http://127.0.0.1:8000/root/enter_stock/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_stock()[0], 'strings': DB.a.show_stock()[1:], 'link': link, 'last': DB.a.show_stock()[1]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_clients(request):
    if DB.a.login:
        link = 'http://127.0.0.1:8000/root/enter_clients/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_clients()[0], 'strings': DB.a.show_clients()[1:], 'link': link, 'last': DB.a.show_clients()[1]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def show_workers(request):
    if DB.a.login:
        link = 'http://127.0.0.1:8000/root/enter_workers/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_workers()[0], 'strings': DB.a.show_workers()[1:], 'link': link, 'last': DB.a.show_workers()[1]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_positions(request):
    if DB.a.login:
        link = 'http://127.0.0.1:8000/root/enter_positions/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_positions()[0], 'strings': DB.a.show_positions()[1:], 'link': link, 'last': DB.a.show_positions()[1]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_basket(request):
    if DB.a.login:
        link = 'http://127.0.0.1:8000/root/enter_basket/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_basket()[0], 'strings': DB.a.show_basket()[1:], 'link': link, 'last': DB.a.show_basket()[1]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))

def show_orders(request):
    if DB.a.login:
        link = 'http://127.0.0.1:8000/root/enter_orders/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_orders()[0], 'strings': DB.a.show_orders()[1:], 'link': link, 'last': DB.a.show_orders()[1]})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))
