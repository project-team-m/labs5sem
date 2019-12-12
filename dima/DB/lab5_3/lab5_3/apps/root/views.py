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
            return render(request, 'root/show_table.html', {
                'tables': DB.a.get_tables(),
                'table': link,
                'titles': DB.a.output_titles(link),
                'strings': DB.a.search_component(request.POST['table'], request.POST['search']),
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
            mass = []
            m = DB.a.output_titles(DB.link)
            for i in request.POST:
                if i in m:
                    mass.append(request.POST[i])
            DB.a.insert(mass, DB.link)
            # DB.a.rollback()
            # DB.scripts = 'incorrect input'
        return HttpResponseRedirect(reverse('root:show_table'))

    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def show_brands(request):
    if DB.a.login and DB.a.lvl == 3:
        save = DB.scripts
        DB.scripts = None
        link = 'http://127.0.0.1:8000/root/enter_brands/'
        link2 = 'http://127.0.0.1:8000/root/enter_brands_s/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_brands()[0], 'strings': DB.a.show_brands()[1:], 'link': link,
                       'link2': link2, 'last': DB.a.show_brands()[-1], 'scripts': save})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def show_stocks(request):
    if DB.a.login and DB.a.lvl == 3:
        save = DB.scripts
        DB.scripts = None
        link = 'http://127.0.0.1:8000/root/enter_stocks/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_stocks()[0], 'strings': DB.a.show_stocks()[1:], 'link': link,
                       'last': DB.a.show_stocks()[-1], 'scripts': save})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def show_stock(request):
    if DB.a.login and DB.a.lvl == 3:
        save = DB.scripts
        DB.scripts = None
        link = 'http://127.0.0.1:8000/root/enter_stock/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_stock()[0], 'strings': DB.a.show_stock()[1:], 'link': link,
                       'last': DB.a.show_stock()[-1], 'scripts': save})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def show_clients(request):
    if DB.a.login and DB.a.lvl == 3:
        save = DB.scripts
        DB.scripts = None
        link = 'http://127.0.0.1:8000/root/enter_clients/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_clients()[0], 'strings': DB.a.show_clients()[1:], 'link': link,
                       'last': DB.a.show_clients()[-1], 'scripts': save})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def show_workers(request):
    if DB.a.login and DB.a.lvl == 3:
        save = DB.scripts
        DB.scripts = None
        link = 'http://127.0.0.1:8000/root/enter_workers/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_workers()[0], 'strings': DB.a.show_workers()[1:], 'link': link,
                       'last': DB.a.show_workers()[-1], 'scripts': save})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def show_positions(request):
    if DB.a.login and DB.a.lvl == 3:
        save = DB.scripts
        DB.scripts = None
        link = 'http://127.0.0.1:8000/root/enter_positions/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_positions()[0], 'strings': DB.a.show_positions()[1:], 'link': link,
                       'last': DB.a.show_positions()[-1], 'scripts': save})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def show_basket(request):
    if DB.a.login and DB.a.lvl == 3:
        save = DB.scripts
        DB.scripts = None
        link = 'http://127.0.0.1:8000/root/enter_basket/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_basket()[0], 'strings': DB.a.show_basket()[1:], 'link': link,
                       'last': DB.a.show_basket()[-1], 'scripts': save})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def show_orders(request):
    if DB.a.login and DB.a.lvl == 3:
        save = DB.scripts
        DB.scripts = None
        link = 'http://127.0.0.1:8000/root/enter_orders/'
        return render(request, 'root/show_table.html',
                      {'tittles': DB.a.show_orders()[0], 'strings': DB.a.show_orders()[1:], 'link': link,
                       'last': DB.a.show_orders()[-1], 'scripts': save})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def enter_components(request):
    if DB.a.login and DB.a.lvl == 3:
        if '_edit' in request.POST:
            try:
                DB.a.enter_component([DB.a.change_to_norm_none(request.POST['id']),
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
                                      DB.a.change_to_norm_none(request.POST['id brand']),
                                      DB.a.change_to_norm_none(request.POST['id_old'])])
            except:
                DB.a.rollback()
                DB.scripts = 'incorrect input'
        else:
            DB.a.del_string(request.POST['id_old'], 'components')
        return HttpResponseRedirect(reverse('root:components'))
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def enter_brands(request):
    if DB.a.login and DB.a.lvl == 3:
        if '_edit' in request.POST:
            try:
                DB.a.enter_brands([DB.a.change_to_norm_none(request.POST['id']),
                                   DB.a.change_to_norm_none(request.POST['name']),
                                   DB.a.change_to_norm_none(request.POST['id_old'])])
            except:
                DB.a.rollback()
                DB.scripts = 'incorrect input'
        else:
            DB.a.del_string(request.POST['id_old'], 'brands')
        return HttpResponseRedirect(reverse('root:brands'))
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def enter_stocks(request):
    if DB.a.login and DB.a.lvl == 3:
        if '_edit' in request.POST:
            try:
                DB.a.enter_stocks([DB.a.change_to_norm_none(request.POST['id']),
                                   DB.a.change_to_norm_none(request.POST['name']),
                                   DB.a.change_to_norm_none(request.POST['inn']),
                                   DB.a.change_to_norm_none(request.POST['ogrn']),
                                   DB.a.change_to_norm_none(request.POST['address']),
                                   DB.a.change_to_norm_none(request.POST['date create']),
                                   DB.a.change_to_norm_none(request.POST['id storekeeper']),
                                   DB.a.change_to_norm_none(request.POST['id_old'])])
            except:
                DB.a.rollback()
                DB.scripts = 'incorrect input'
        else:
            DB.a.del_string(request.POST['id_old'], 'stocks')
        return HttpResponseRedirect(reverse('root:stocks'))
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def enter_stock(request):
    if DB.a.login and DB.a.lvl == 3:
        if '_edit' in request.POST:
            try:
                DB.a.enter_stock([DB.a.change_to_norm_none(request.POST['id']),
                                  DB.a.change_to_norm_none(request.POST['id component']),
                                  DB.a.change_to_norm_none(request.POST['id stock']),
                                  DB.a.change_to_norm_none(request.POST['balance']),
                                  DB.a.change_to_norm_none(request.POST['id_old'])])
            except:
                DB.a.rollback()
                DB.scripts = 'incorrect input'
        else:
            DB.a.del_string(request.POST['id_old'], 'stock')
        return HttpResponseRedirect(reverse('root:stock'))
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def enter_clients(request):
    if DB.a.login and DB.a.lvl == 3:
        if '_edit' in request.POST:
            try:
                DB.a.enter_clients([DB.a.change_to_norm_none(request.POST['id']),
                                    DB.a.change_to_norm_none(request.POST['name']),
                                    DB.a.change_to_norm_none(request.POST['phone number']),
                                    DB.a.change_to_norm_none(request.POST['discount card']),
                                    DB.a.change_to_norm_none(request.POST['login']),
                                    DB.a.change_to_norm_none(request.POST['password']),
                                    DB.a.change_to_norm_none(request.POST['id_old'])])
            except:
                DB.a.rollback()
                DB.scripts = 'incorrect input'
        else:
            DB.a.del_string(request.POST['id_old'], 'clients')
        return HttpResponseRedirect(reverse('root:clients'))
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def enter_workers(request):
    if DB.a.login and DB.a.lvl == 3:
        if '_edit' in request.POST:
            try:
                DB.a.enter_workers([DB.a.change_to_norm_none(request.POST['id']),
                                    DB.a.change_to_norm_none(request.POST['name']),
                                    DB.a.change_to_norm_none(request.POST['login']),
                                    DB.a.change_to_norm_none(request.POST['password']),
                                    DB.a.change_to_norm_none(request.POST['address']),
                                    DB.a.change_to_norm_none(request.POST['phone number']),
                                    DB.a.change_to_norm_none(request.POST['id position']),
                                    DB.a.change_to_norm_none(request.POST['email']),
                                    DB.a.change_to_norm_none(request.POST['date employment']),
                                    DB.a.change_to_norm_none(request.POST['id_old'])])
            except:
                DB.a.rollback()
                DB.scripts = 'incorrect input'
        else:
            DB.a.del_string(request.POST['id_old'], 'workers')
        return HttpResponseRedirect(reverse('root:workers'))
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def enter_positions(request):
    if DB.a.login and DB.a.lvl == 3:
        if '_edit' in request.POST:
            try:
                DB.a.enter_positions([DB.a.change_to_norm_none(request.POST['id']),
                                      DB.a.change_to_norm_none(request.POST['name']),
                                      DB.a.change_to_norm_none(request.POST['id_old'])])
            except:
                DB.a.rollback()
                DB.scripts = 'incorrect input'
        else:
            DB.a.del_string(request.POST['id_old'], 'positions')
        return HttpResponseRedirect(reverse('root:positions'))
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def enter_basket(request):
    if DB.a.login and DB.a.lvl == 3:
        if '_edit' in request.POST:
            try:
                DB.a.enter_basket([DB.a.change_to_norm_none(request.POST['id']),
                                   DB.a.change_to_norm_none(request.POST['id component']),
                                   DB.a.change_to_norm_none(request.POST['quantity']),
                                   DB.a.change_to_norm_none(request.POST['id client']),
                                   DB.a.change_to_norm_none(request.POST['id order']),
                                   DB.a.change_to_norm_none(request.POST['id_old'])])
            except:
                DB.a.rollback()
                DB.scripts = 'incorrect input'
        else:
            DB.a.del_string(request.POST['id_old'], 'basket')
        return HttpResponseRedirect(reverse('root:basket'))
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def enter_orders(request):
    if DB.a.login and DB.a.lvl == 3:
        if '_edit' in request.POST:
            try:
                DB.a.enter_orders([DB.a.change_to_norm_none(request.POST['id']),
                                   DB.a.change_to_norm_none(request.POST['date order']),
                                   DB.a.change_to_norm_none(request.POST['id manager']),
                                   DB.a.change_to_norm_none(request.POST['discount']),
                                   DB.a.change_to_norm_none(request.POST['clock']),
                                   DB.a.change_to_norm_none(request.POST['cores']),
                                   DB.a.change_to_norm_none(request.POST['threads']),
                                   DB.a.change_to_norm_none(request.POST['clock memory']),
                                   DB.a.change_to_norm_none(request.POST['bus width']),
                                   DB.a.change_to_norm_none(request.POST['memory']),
                                   DB.a.change_to_norm_none(request.POST['timing']),
                                   DB.a.change_to_norm_none(request.POST['id brand']),
                                   DB.a.change_to_norm_none(request.POST['id_old'])])
            except:
                DB.a.rollback()
                DB.scripts = 'incorrect input'
        else:
            DB.a.del_string(request.POST['id_old'], 'orders')
        return HttpResponseRedirect(reverse('root:orders'))
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def enter_components_s(request):
    if DB.a.login and DB.a.lvl == 3:
        if '_search' in request.POST:
            save = DB.scripts
            DB.scripts = None
            link = 'http://127.0.0.1:8000/root/enter_components/'
            link2 = 'http://127.0.0.1:8000/root/enter_components_s/'
            if request.POST['search']:
                return render(request, 'root/show_table.html',
                              {'tittles': DB.a.search_component(request.POST['search'])[0],
                               'strings': DB.a.search_component(request.POST['search'])[1:], 'link': link,
                               'link2': link2, 'last': DB.a.search_component(request.POST['search'])[-1],
                               'scripts': save})
            else:
                return render(request, 'root/show_table.html',
                              {'tittles': DB.a.show_components()[0], 'strings': DB.a.show_components()[1:],
                               'link': link,
                               'link2': link2, 'last': DB.a.show_components()[-1], 'scripts': save})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))


def enter_brands_s(request):
    if DB.a.login and DB.a.lvl == 3:
        save = DB.scripts
        DB.scripts = None
        link = 'http://127.0.0.1:8000/root/enter_brands/'
        link2 = 'http://127.0.0.1:8000/root/enter_brands_s/'
        if request.POST['search']:
            return render(request, 'root/show_table.html',
                          {'tittles': DB.a.search_brands(request.POST['search'])[0],
                           'strings': DB.a.search_brands(request.POST['search'])[1:], 'link': link, 'link2': link2,
                           'last': DB.a.search_brands(request.POST['search'])[-1], 'scripts': save})
        else:
            return render(request, 'root/show_table.html',
                          {'tittles': DB.a.show_brands()[0], 'strings': DB.a.show_brands()[1:], 'link': link,
                           'last': DB.a.show_brands()[-1], 'scripts': save})
    DB.scripts = 'wrong password or login'
    return HttpResponseRedirect(reverse('main_form:index'))
